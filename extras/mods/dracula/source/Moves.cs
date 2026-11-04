using System;
using System.Collections.Generic;
using RecompOne.Runtime.Context;
using RecompOne.Runtime.Memory;
using RecompOne.Runtime.Modding;
using Sotn;

namespace DraculaMod;

/// <summary>
/// Dracula's five moves.
///
/// Driven two ways, because one of them does not exist on every platform:
///
/// - **Hooks (desktop).** PreHooks on the player's step functions, which is where the game
///   itself sets velocity - anything written at the frame boundary is overwritten by the player
///   update later in the same frame. The functions chosen are all large (PlayerStepStand is 951
///   source lines, Crouch 708, Jump 458), so no detour can be lost to inlining.
/// - **VSync (Android).** MonoMod.RuntimeDetour does not support android-arm64:
///   HookManager.Commit() fails with Arg_NotImplementedException, every hook registers and none
///   ever runs. Verified on a Retroid Pocket 6 - the palette recolour worked while no step hook
///   fired once. So when no hook has been seen for a few frames the same logic runs from the
///   VSync event instead, which is plain managed dispatch and needs no detour.
///
/// See <see cref="HooksLive"/>. The fallback costs a little velocity precision and nothing else;
/// the moves are mostly projectile spawns, which are not timing-sensitive.
/// </summary>
public static class Moves
{
    // MP costs.
    const int CostVolley = 8;
    const int CostInferno = 25;
    const int CostTeleport = 10;
    const int CostMeteor = 40;
    const int CostBats = 15;

    // Cooldowns, in frames, so a held button cannot spray.
    const int CdVolley = 22;
    const int CdInferno = 55;
    const int CdTeleport = 30;
    const int CdMeteor = 110;
    const int CdBats = 45;

    const int TeleportFrames = 8;
    const int TeleportSpeed = 0x30000;   // fixed point, ~3 px/frame
    const int TeleportIFrames = 26;

    const int MeteorCount = 5;
    const int MeteorSpread = 56;         // px either side of the player
    const int MeteorHeight = 96;         // px above
    const int MeteorFall = 0x18000;      // downward velocity
    const int MeteorStagger = 6;         // frames between drops

    const int BatCount = 3;
    const int BatLift = -0x40000;

    static int _cdVolley, _cdInferno, _cdTeleport, _cdMeteor, _cdBats;

    // An active Demonic Teleport: frames remaining and the direction.
    static int _teleportFrames;
    static int _teleportDir;
    static byte _savedBlend;
    static byte _savedOpacity;
    static bool _blendSaved;

    /// <summary>Meteors still queued to drop, so the volley arrives as a wave rather than a wall.</summary>
    static readonly List<(int Delay, int X, int Y)> _meteorQueue = new();

    /// <summary>
    /// Projectiles whose velocity we override. The entity sets its own velocity in step 0,
    /// which runs on the frame after we create it, so a one-shot write at spawn time is lost.
    /// These are re-stamped every frame while alive instead.
    /// </summary>
    static readonly List<(Entity Entity, int Vx, int Vy, int Frames)> _steered = new();

    public static void Reset()
    {
        _cdVolley = _cdInferno = _cdTeleport = _cdMeteor = _cdBats = 0;
        _teleportFrames = 0;
        _meteorQueue.Clear();
        _steered.Clear();
        RestoreBlend();
    }

    /// <summary>Frame bookkeeping. Safe at VSync - it touches no game functions.</summary>
    public static void Tick()
    {
        _frame++;

        if (_cdVolley > 0) _cdVolley--;
        if (_cdInferno > 0) _cdInferno--;
        if (_cdTeleport > 0) _cdTeleport--;
        if (_cdMeteor > 0) _cdMeteor--;
        if (_cdBats > 0) _cdBats--;

        // The teleport countdown belongs here, not in the step hooks: this runs exactly once per
        // frame, whereas several step functions can run in a single frame during a transition.
        if (_teleportFrames > 0 && --_teleportFrames == 0) RestoreBlend();

        SteerProjectiles();

        // Fallback driver. Only engages when the detours are not running (Android), so desktop
        // behaviour is unchanged.
        if (!HooksLive)
        {
            Update(GroundedNow());
            AfterStep();
        }
    }

    /// <summary>Grounded-ness read from the player's step, for the VSync driver.</summary>
    static bool GroundedNow()
    {
        try
        {
            var step = Player.Step;
            return step == PlayerStep.Standing || step == PlayerStep.Walking || step == PlayerStep.Crouching;
        }
        catch { return true; }
    }

    /// <summary>Entry point used by the step hooks; records that the detours are alive.</summary>
    public static void FromHook(bool grounded)
    {
        _lastHookFrame = _frame;
        Update(grounded);
    }

    /// <summary>Post-step entry point used by the hooks.</summary>
    public static void FromHookAfter()
    {
        _lastHookFrame = _frame;
        AfterStep();
    }

    static void SteerProjectiles()
    {
        for (int i = _steered.Count - 1; i >= 0; i--)
        {
            var (e, vx, vy, frames) = _steered[i];
            if (frames <= 0 || !e.IsValid || !e.IsAlive)
            {
                _steered.RemoveAt(i);
                continue;
            }
            e.VelocityX = vx;
            e.VelocityY = vy;
            _steered[i] = (e, vx, vy, frames - 1);
        }
    }

    // --- Entry point from the step hooks -------------------------------------------------

    static long _frame;
    static long _lastHookFrame = -1;

    /// <summary>
    /// Whether the step detours are actually installed. On android-arm64 they are not:
    /// MonoMod.RuntimeDetour has no support there and HookManager.Commit() fails with
    /// Arg_NotImplementedException, so every hook registers and none ever run. Rather than lose
    /// the moveset on the platform this fork exists for, the same logic is driven from VSync
    /// when no hook has been seen recently. Desktop keeps the hook path, which has better
    /// timing because it runs inside the player update.
    /// </summary>
    public static bool HooksLive => _lastHookFrame >= 0 && _frame - _lastHookFrame <= 8;

    /// <summary>
    /// Reads input and starts moves. Runs before the vanilla step function, and deliberately
    /// never suppresses it: an earlier version returned false from the PreHook to skip vanilla
    /// during a teleport, which also skips whatever collision and animation handling lives in
    /// that step - the very thing the teleport design was trying to avoid. Velocity is imposed
    /// afterwards in <see cref="AfterStep"/> instead, so all vanilla physics still run and this
    /// mod simply gets the last word.
    /// </summary>
    public static void Update(bool grounded)
    {
        if (!Settings.IsDracula || !Ready()) return;

        DropQueuedMeteors();

        if (_teleportFrames > 0) return;   // a teleport in flight ignores new input
        if (!Input.ModifierPressed) return;

        if (Input.Up) { TryMeteorRain(); return; }
        if (Input.DownDir) { if (grounded) TryDarkInferno(); else TryBatSwarm(); return; }
        if (Input.AnyHorizontal) { TryDemonicTeleport(); return; }
        TryHellfireVolley();
    }

    /// <summary>
    /// Runs after the vanilla step function, which is where velocity overrides belong - vanilla
    /// calls SetSpeedX inside the step, so anything written beforehand is overwritten.
    /// </summary>
    public static void AfterStep()
    {
        if (!Settings.IsDracula || !Ready()) return;

        // Applies only - the countdown lives in Tick(), which runs exactly once per frame. A step
        // transition can run two step functions in the same frame, and decrementing here would
        // cut the teleport short by however many that happened to be.
        if (_teleportFrames > 0) Player.VelocityX = _teleportDir * TeleportSpeed;
    }

    static bool Ready() => Game.Available && Game.InGame && !Game.IsLoading && Player.HasControl;

    static bool Spend(int mp, ref int cooldown, int cooldownFrames)
    {
        if (cooldown > 0) return false;
        int cost = (int)Math.Round(mp * Settings.MpCostScale);
        if (cost > 0 && Player.Mp < cost) return false;
        if (cost > 0) Player.Mp -= cost;
        cooldown = cooldownFrames;
        return true;
    }

    // --- The moves ----------------------------------------------------------------------

    /// <summary>
    /// Three fireballs in a fan. Params 0/1/2 are exactly the three the vanilla Hellfire cast
    /// uses, so the spread and speeds are the game's own rather than invented.
    /// </summary>
    static bool TryHellfireVolley()
    {
        if (!Settings.HellfireVolley) return false;
        if (!Spend(CostVolley, ref _cdVolley, CdVolley)) return false;

        // Hand the whole cast to the game by putting the player into its own Hellfire step.
        //
        // Two earlier attempts spawned the fireball entity directly - once by hand, once through
        // the entity factory - and both produced a projectile that rendered as a pale sphere and
        // died in a frame or two. That is stage CHR being drawn as a fireball: Hellfire's graphics
        // are not resident until the spell itself loads them, which happens in the step, not in
        // the spawn. Driving the step gets the load, the animation, the sound and the three
        // fireballs, all of it exactly as vanilla.
        Player.Step = PlayerStep.Hellfire;
        Player.StepSub = 0;
        return false;
    }

    static bool TryDarkInferno()
    {
        if (!Settings.DarkInferno) return false;
        if (!Spend(CostInferno, ref _cdInferno, CdInferno)) return false;

        var e = Spawn.BigFireball(Player.PosX, Player.PosY - 8);
        Presence.Empower(e);
        return false;
    }

    /// <summary>
    /// The shatter-and-reappear. Implemented as a very fast, brief, invulnerable slide rather
    /// than by writing a new position: setting PosX directly walks straight through walls and
    /// can strand the player inside geometry, and a softlock is worse than a slightly less
    /// magical-looking blink. The flourish entities and the fade sell the teleport instead.
    /// </summary>
    static bool TryDemonicTeleport()
    {
        if (!Settings.DemonicTeleport) return false;
        if (!Spend(CostTeleport, ref _cdTeleport, CdTeleport)) return false;

        _teleportDir = Input.Facing;
        _teleportFrames = TeleportFrames;
        Player.FacingLeft = _teleportDir < 0;

        Spawn.TeleportFlash(Player.PosX, Player.PosY);
        Player.InvincibilityTimer = TeleportIFrames;
        FadeOut();
        return true;
    }

    /// <summary>Queues a wave of meteors above the player; they are released over the next few frames.</summary>
    static bool TryMeteorRain()
    {
        if (!Settings.MeteorRain) return false;
        if (!Spend(CostMeteor, ref _cdMeteor, CdMeteor)) return false;

        int cx = Player.PosX, cy = Player.PosY - MeteorHeight;
        for (int i = 0; i < MeteorCount; i++)
        {
            // Spread evenly across the player, left to right.
            int offset = MeteorCount == 1 ? 0 : -MeteorSpread + i * (MeteorSpread * 2 / (MeteorCount - 1));
            _meteorQueue.Add((i * MeteorStagger, cx + offset, cy));
        }
        return false;
    }

    static void DropQueuedMeteors()
    {
        for (int i = _meteorQueue.Count - 1; i >= 0; i--)
        {
            var (delay, x, y) = _meteorQueue[i];
            if (delay > 0)
            {
                _meteorQueue[i] = (delay - 1, x, y);
                continue;
            }

            _meteorQueue.RemoveAt(i);
            var e = Spawn.Fireball(x, y, 0);
            if (!e.IsValid) continue;
            // Force it downward for the rest of its life; its own step 0 would send it sideways.
            _steered.Add((e, 0, MeteorFall, 150));
            Presence.Empower(e);
        }
    }

    static bool TryBatSwarm()
    {
        if (!Settings.BatSwarm) return false;
        if (!Spend(CostBats, ref _cdBats, CdBats)) return false;

        int x = Player.PosX, y = Player.PosY;
        for (int i = 0; i < BatCount; i++)
        {
            var e = Spawn.BatProjectile(x, y - i * 10);
            Presence.Empower(e);
        }

        Player.VelocityY = BatLift;
        Player.InvincibilityTimer = (short)Math.Max((int)Player.InvincibilityTimer, 12);
        return false;
    }

    // --- Presentation -------------------------------------------------------------------

    static void FadeOut()
    {
        var e = Player.Entity;
        if (!_blendSaved)
        {
            _savedBlend = e.BlendMode;
            _savedOpacity = e.Opacity;
            _blendSaved = true;
        }
        e.BlendMode = (byte)Sotn.BlendMode.Transparent;
        e.Opacity = 0x40;
    }

    static void RestoreBlend()
    {
        if (!_blendSaved) return;
        try
        {
            var e = Player.Entity;
            e.BlendMode = _savedBlend;
            e.Opacity = _savedOpacity;
            Spawn.TeleportFlash(Player.PosX, Player.PosY);
        }
        catch { }
        _blendSaved = false;
    }

    // --- Optional movement feel ---------------------------------------------------------

    /// <summary>
    /// Makes him walk like something ancient. Opt-in only, and applied only while actually
    /// walking: scaling airborne velocity would shorten jumps, and a gap somewhere in the castle
    /// becoming uncrossable is a softlock rather than a bad stat.
    /// </summary>
    static void ApplyHeavyWalk()
    {
        if (!Settings.HeavyMovement) return;
        int vx = Player.VelocityX;
        if (vx != 0) Player.VelocityX = vx / 4 * 3;
    }

    // --- Hooks --------------------------------------------------------------------------
    //
    // PreHook starts moves; PostHook imposes velocity. Nothing here ever returns false, so the
    // vanilla step always runs and keeps handling collision, animation and damage.
    //
    // Every function hooked here is large (PlayerStepStand is 951 source lines, Crouch 708,
    // Jump 458) and the step machine reaches them through a function-pointer table, so neither
    // inlining nor the dispatch path can bypass the detour.

    [PreHook("dra", "PlayerStepStand")]
    public static void OnStand(CpuContext c, IMemory m) => FromHook(grounded: true);

    [PostHook("dra", "PlayerStepStand")]
    public static void AfterStand(CpuContext c, IMemory m) => FromHookAfter();

    [PreHook("dra", "PlayerStepCrouch")]
    public static void OnCrouch(CpuContext c, IMemory m) => FromHook(grounded: true);

    [PostHook("dra", "PlayerStepCrouch")]
    public static void AfterCrouch(CpuContext c, IMemory m) => FromHookAfter();

    [PreHook("dra", "PlayerStepJump")]
    public static void OnJump(CpuContext c, IMemory m) => FromHook(grounded: false);

    [PostHook("dra", "PlayerStepJump")]
    public static void AfterJump(CpuContext c, IMemory m) => FromHookAfter();

    [PreHook("dra", "PlayerStepFall")]
    public static void OnFall(CpuContext c, IMemory m) => FromHook(grounded: false);

    [PostHook("dra", "PlayerStepFall")]
    public static void AfterFall(CpuContext c, IMemory m) => FromHookAfter();

    [PreHook("dra", "PlayerStepWalk")]
    public static void OnWalk(CpuContext c, IMemory m) => FromHook(grounded: true);

    /// <summary>
    /// The only place heavy walk is applied. It must run after vanilla, which calls SetSpeedX
    /// inside the step - anything written to VelocityX beforehand is simply overwritten.
    /// </summary>
    [PostHook("dra", "PlayerStepWalk")]
    public static void AfterWalk(CpuContext c, IMemory m)
    {
        FromHookAfter();
        if (Settings.IsDracula && Ready() && _teleportFrames == 0) ApplyHeavyWalk();
    }
}
