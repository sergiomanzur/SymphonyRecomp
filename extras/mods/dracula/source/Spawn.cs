using RecompOne.Runtime.Memory;
using Sotn;

namespace DraculaMod;

/// <summary>
/// Creates the projectiles Dracula's moves are built from.
///
/// Everything here lives in the DRA overlay, which is resident in every room. Dracula's own
/// code and art are in ST0, the final-stage overlay - and every stage overlay shares base
/// 0x80180000, so only one is ever loaded. His real entities simply cannot exist anywhere but
/// the throne room. What can is the machinery Alucard inherited from him: Hellfire's fireballs,
/// the teleport shatter, the bat projectiles. Those are the same powers, so building his moveset
/// out of them is using the right seam rather than working around a missing one.
/// </summary>
public static class Spawn
{
    // Verified against the DRA function table in generated/dra.cs.
    public const uint FnNormalFireball = 0x801274DCu;
    public const uint FnBigFireball = 0x80127840u;
    public const uint FnTeleport = 0x801243B0u;
    public const uint FnBatFireball = 0x8012768Cu;

    public const uint FnSetPlayerAnim = 0x8010DA48u;

    /// <summary>
    /// CreateEntFactoryFromEntity. The game's own spawner: given the player and a blueprint id it
    /// builds the whole effect - graphics, animation, count, timing - exactly as vanilla does.
    /// </summary>
    public const uint FnCreateEntFactory = 0x8011AAFCu;

    /// <summary>Blueprint the vanilla Hellfire cast uses, read straight out of PlayerStepHellfire.</summary>
    public const int BlueprintHellfire = 0x21;

    /// <summary>
    /// Highest safe <see cref="Sotn.Entity.Params"/> for a normal fireball. Step 0 uses Params
    /// as an index into the speed tables at 0x800B0830 (X) and 0x800B083C (Y); the vanilla
    /// Hellfire cast uses 0, 1 and 2, which is the three-way fan. Going past the end of those
    /// tables reads whatever follows them and launches the fireball at a garbage velocity, so
    /// this is clamped rather than trusted.
    /// </summary>
    public const int MaxFireballParams = 2;

    static IMemory Mem => RecompOne.Runtime.Runtime.Mem!;

    /// <summary>
    /// Takes a free entity slot, wipes it, and points it at one of the DRA update functions.
    /// The entity runs its own step 0 next frame and sets up its animation, hitbox, flags and
    /// velocity itself - the same way the game's entity factory leaves it.
    /// </summary>
    public static Entity At(uint updateFn, int x, int y, int prms = 0)
    {
        var e = Entities.GetFreeStage();
        if (!e.IsValid) return e;

        e.Write(new byte[Entity.Stride]);
        e.PosX = x;
        e.PosY = y;
        e.Params = (ushort)prms;
        e.Step = 0;
        e.StepSub = 0;
        e.Update = updateFn;
        return e;
    }

    /// <summary>
    /// Spawns through the game's own entity factory rather than by hand.
    ///
    /// Hand-rolling an entity (take a free slot, zero it, point Update at the fireball) does
    /// spawn something, and it was verified doing so on device - but the result rendered with the
    /// wrong graphics and died within a frame or two, because the factory does setup that step 0
    /// alone does not: loading the effect's CHR, wiring the parent, and sequencing the shots. Let
    /// the game do it.
    /// </summary>
    public static bool Factory(int blueprint)
    {
        try
        {
            // a0 is the player entity; PlayerStepHellfire passes the current-entity pointer, and
            // the player is slot 0.
            return GameApi.Call(FnCreateEntFactory, Sotn.Game.EntitiesAddr, (uint)blueprint, 0) != 0;
        }
        catch { return false; }
    }

    /// <summary>One fireball from the vanilla fan. <paramref name="variant"/> is clamped to the table.</summary>
    public static Entity Fireball(int x, int y, int variant)
    {
        if (variant < 0) variant = 0;
        if (variant > MaxFireballParams) variant = MaxFireballParams;
        return At(FnNormalFireball, x, y, variant);
    }

    public static Entity BigFireball(int x, int y) => At(FnBigFireball, x, y, 0);

    public static Entity BatProjectile(int x, int y) => At(FnBatFireball, x, y, 0);

    /// <summary>The dissolve-and-reform flourish the game uses for teleports.</summary>
    public static Entity TeleportFlash(int x, int y) => At(FnTeleport, x, y, 0);

    /// <summary>
    /// A fireball with a velocity we choose rather than one from the table. Spawned a frame
    /// "pre-run" is not possible, so instead this is applied on the frame after creation by
    /// <see cref="Moves"/> - see the pending-override list there.
    /// </summary>
    public static void Override(Entity e, int vx, int vy)
    {
        if (!e.IsValid) return;
        e.VelocityX = vx;
        e.VelocityY = vy;
    }

    public static void PlaySfx(int id)
    {
        try { GameApi.PlaySfx(id); } catch { }
    }

    /// <summary>Sets the player's animation through the game's own helper.</summary>
    public static void SetPlayerAnim(int anim)
    {
        try { GameApi.Call(FnSetPlayerAnim, (uint)anim); } catch { }
    }
}
