using System;
using System.Collections.Generic;
using RecompOne.Runtime.Context;
using RecompOne.Runtime.Memory;
using RecompOne.Runtime.Modding;
using Sotn;

namespace DraculaMod;

/// <summary>
/// Dracula's passives: how he looks, how much punishment he shrugs off, and how his magic
/// regenerates.
///
/// Nothing here writes to the save. The recolour goes to the palette in VRAM and is restored
/// from the cached original; toughness is a post-hit HP refund rather than a change to HpMax;
/// magic power is stamped onto the projectiles this mod itself spawned. Toggling Dracula off
/// therefore leaves the save file byte-identical, which was the whole point of a live toggle.
/// </summary>
public static class Presence
{
    /// <summary>
    /// Dracula's colour ramp, darkest to brightest, in PSX 5-bit channels.
    ///
    /// A flat channel multiply (r x 1.6, g x 0.34, b x 0.46) was the first attempt and it just
    /// looked like Alucard under a red light. This instead keeps each original colour's
    /// *brightness* and re-maps its hue along a ramp authored to read as him: black armour
    /// through blood red, ending in the warm gold of his trim rather than white. Because it keys
    /// off luminance it needs no knowledge of which palette index is skin, cloak or metal.
    /// </summary>
    static readonly int[][] DraculaRamp =
    {
        new[] {  2,  1,  3 },   // near black
        new[] {  8,  2,  5 },   // crimson black
        new[] { 17,  3,  6 },   // dried blood
        new[] { 25,  7,  8 },   // blood red
        new[] { 31, 17, 11 },   // ember
        new[] { 31, 27, 18 },   // pale gold highlight
    };

    const int MpRegenPeriod = 18;   // frames per point
    const float DamageTaken = 0.68f; // keeps 68% of incoming damage, refunds the rest
    const float MagicPower = 1.45f;  // multiplier on this mod's own projectiles

    static readonly HashSet<int> _tinted = new();
    static int _mpTick;
    static int _hpBeforeHit;
    static int _lastHp = -1;

    /// <summary>Projectiles this mod spawned, stamped for a few frames so step 0 cannot undo it.</summary>
    static readonly List<(Entity Entity, int Frames)> _empowered = new();

    public static void Reset()
    {
        _mpTick = 0;
        _lastHp = -1;
        _empowered.Clear();
    }

    public static void Tick()
    {
        if (!Ready()) return;

        if (Settings.IsDracula)
        {
            if (Settings.Recolour) ApplyRecolour();
            if (Settings.MpRegen) RegenerateMp();
            if (Settings.StrongerAttacks) StampEmpowered();
            if (Settings.DamageResistance && !Moves.HooksLive) RefundFromHpDrop();
        }
        else if (_tinted.Count > 0)
        {
            RestoreRecolour();
        }
    }

    static bool Ready() => Game.Available && Game.InGame && !Game.IsLoading;

    // --- Appearance ----------------------------------------------------------------------

    static readonly ushort[] _scratch = new ushort[Palette.Colors];

    static void ApplyRecolour()
    {
        int id = Player.PaletteId;
        if (id <= 0) return;

        // Original() caches the untouched palette per stage, so this is idempotent and restores
        // cleanly however many times it runs.
        var src = Palette.Original(id);
        if (Palette.IsEmpty(src)) return;

        for (int i = 0; i < Palette.Colors; i++) _scratch[i] = Recolour(src[i]);
        Palette.Write(id, _scratch);
        _tinted.Add(id);
    }

    /// <summary>Maps one colour onto <see cref="DraculaRamp"/> by its luminance, keeping the mask bit.</summary>
    static ushort Recolour(ushort colour)
    {
        if (colour == 0) return 0;   // transparent stays transparent

        int r = colour & 0x1F, g = (colour >> 5) & 0x1F, b = (colour >> 10) & 0x1F;
        int mask = colour & 0x8000;

        // Rec.601-ish weighting, kept in integers.
        float lum = (r * 0.299f + g * 0.587f + b * 0.114f) / 31f;
        if (lum < 0f) lum = 0f;
        if (lum > 1f) lum = 1f;

        int last = DraculaRamp.Length - 1;
        float pos = lum * last;
        int i = (int)pos;

        int nr, ng, nb;
        if (i >= last)
        {
            nr = DraculaRamp[last][0]; ng = DraculaRamp[last][1]; nb = DraculaRamp[last][2];
        }
        else
        {
            float t = pos - i;
            nr = (int)(DraculaRamp[i][0] + (DraculaRamp[i + 1][0] - DraculaRamp[i][0]) * t);
            ng = (int)(DraculaRamp[i][1] + (DraculaRamp[i + 1][1] - DraculaRamp[i][1]) * t);
            nb = (int)(DraculaRamp[i][2] + (DraculaRamp[i + 1][2] - DraculaRamp[i][2]) * t);
        }

        // Clamped by hand rather than with Math.Clamp: mod source is compiled on device against
        // the trimmed framework, and framework members the app never calls can be missing there.
        if (nr < 0) nr = 0; else if (nr > 31) nr = 31;
        if (ng < 0) ng = 0; else if (ng > 31) ng = 31;
        if (nb < 0) nb = 0; else if (nb > 31) nb = 31;

        return (ushort)(nr | (ng << 5) | (nb << 10) | mask);
    }

    /// <summary>Puts back every palette this mod touched. Safe to call when nothing was touched.</summary>
    public static void RestoreRecolour()
    {
        if (_tinted.Count == 0) return;
        foreach (int id in _tinted)
        {
            try { Palette.Restore(id); } catch { }
        }
        _tinted.Clear();
    }

    // --- Magic -------------------------------------------------------------------------

    static void RegenerateMp()
    {
        if (Player.Mp >= Player.MpMax) { _mpTick = 0; return; }
        if (++_mpTick < MpRegenPeriod) return;
        _mpTick = 0;
        Player.Mp = Math.Min(Player.MpMax, Player.Mp + 1);
    }

    public static void Empower(Entity e)
    {
        if (!Settings.StrongerAttacks || !e.IsValid) return;
        // Three frames covers the entity's own step 0 running after we created it.
        _empowered.Add((e, 3));
    }

    static void StampEmpowered()
    {
        for (int i = _empowered.Count - 1; i >= 0; i--)
        {
            var (e, frames) = _empowered[i];
            if (frames <= 0 || !e.IsValid || !e.IsAlive)
            {
                _empowered.RemoveAt(i);
                continue;
            }

            short attack = e.Attack;
            if (attack > 0)
            {
                int scaled = (int)(attack * MagicPower);
                // Literal rather than short.MaxValue: the Android Release trimmer strips that
                // constant's metadata, and the on-device Roslyn build then cannot resolve it.
                e.Attack = (short)Math.Min(scaled, 32767);
            }

            _empowered[i] = (e, frames - 1);
        }
    }

    /// <summary>
    /// Hookless toughness, for Android where the damage detour never installs. Watches HP frame
    /// to frame and gives part of any drop back.
    ///
    /// Cruder than the hook path on purpose: it cannot tell a hit from any other loss, so it only
    /// refunds small, plausible drops. A large fall - a death, a menu action, a room transition
    /// resetting stats - is left alone rather than guessed at, and the tracker resamples instead.
    /// </summary>
    static void RefundFromHpDrop()
    {
        int hp = Player.Hp;
        int max = Player.HpMax;

        if (_lastHp < 0 || hp <= 0 || max <= 0) { _lastHp = hp; return; }

        int lost = _lastHp - hp;
        // Anything past a third of the bar in one frame is not an ordinary hit.
        if (lost > 0 && lost <= Math.Max(1, max / 3))
        {
            int refund = (int)Math.Round(lost * (1.0 - DamageTaken));
            if (refund > 0) hp = Math.Min(max, hp + refund);
            Player.Hp = hp;
        }

        _lastHp = hp;
    }

    // --- Toughness ---------------------------------------------------------------------

    /// <summary>
    /// Rather than raise HpMax - which would be written into the player's save the next time
    /// they used a save room - the hit is allowed to land in full and part of it is given back
    /// immediately. The net effect on survivability is the same and the file never changes.
    /// </summary>
    [PreHook("dra", "AlucardHandleDamage")]
    public static void BeforeDamage(CpuContext c, IMemory m)
    {
        _hpBeforeHit = Settings.IsDracula && Settings.DamageResistance && Game.Available ? Player.Hp : -1;
    }

    [PostHook("dra", "AlucardHandleDamage")]
    public static void AfterDamage(CpuContext c, IMemory m)
    {
        if (_hpBeforeHit < 0) return;
        int before = _hpBeforeHit;
        _hpBeforeHit = -1;

        if (!Settings.IsDracula || !Settings.DamageResistance) return;

        int lost = before - Player.Hp;
        if (lost <= 0) return;

        int refund = (int)Math.Round(lost * (1.0 - DamageTaken));
        if (refund <= 0) return;

        // Never resurrect: if the hit was fatal, leave it fatal.
        if (Player.Hp <= 0) return;
        Player.Hp = Math.Min(Player.HpMax, Player.Hp + refund);
    }
}
