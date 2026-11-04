using System;
using Sotn;

namespace DraculaMod;

/// <summary>
/// Renames the character in the game's own pause menu.
///
/// MenuDrawStats picks one of two name strings through pointers in DRA's data - one for Alucard,
/// one for Richter - and hands it to MenuDrawStr. Those strings live in main RAM, so the name can
/// be swapped by writing over it. No hook is involved, which matters: MonoMod detours do not
/// install on android-arm64, so anything that depends on a hook is dead on the device this fork
/// exists for.
///
/// "ALUCARD" and "DRACULA" are both seven characters, so this is an exact in-place overwrite that
/// cannot run into whatever follows the string.
/// </summary>
public static class MenuIdentity
{
    // The two pointers MenuDrawStats chooses between, read straight out of the recompiled code
    // at 0x800F7518 / 0x800F7528.
    const uint NamePointerA = 0x800A8300u;
    const uint NamePointerB = 0x800A8258u;

    const string Alucard = "ALUCARD";
    const string Dracula = "DRACULA";
    const int NameLength = 7;

    /// <summary>Re-checked periodically rather than cached forever: reloading DRA restores the original bytes.</summary>
    const int CheckEvery = 30;

    static int _tick;

    public static void Reset() => _tick = 0;

    public static void Tick()
    {
        if (!Game.Available) return;
        if (++_tick < CheckEvery) return;
        _tick = 0;

        string want = Settings.IsDracula ? Dracula : Alucard;
        string other = Settings.IsDracula ? Alucard : Dracula;

        try
        {
            Apply(NamePointerA, want, other);
            Apply(NamePointerB, want, other);
        }
        catch
        {
            // Menu strings are cosmetic; never let this disturb the game.
        }
    }

    /// <summary>
    /// Rewrites the string behind <paramref name="pointer"/> only if it currently reads the name
    /// we want replaced. Leaves Richter's name, and anything unexpected, completely alone.
    /// </summary>
    static void Apply(uint pointer, string want, string other)
    {
        uint addr = Mem.ReadU32(pointer);
        if (addr < 0x80000000u || addr >= 0x80800000u) return;   // not a sane RAM pointer

        string current = Text.ReadRaw(addr, NameLength + 1);
        if (!string.Equals(current, other, StringComparison.OrdinalIgnoreCase)) return;

        Text.WriteRaw(addr, want, NameLength);
    }

    static RecompOne.Runtime.Memory.IMemory Mem => RecompOne.Runtime.Runtime.Mem!;

    /// <summary>Puts Alucard's name back. Called when the mod unloads.</summary>
    public static void Restore()
    {
        if (!Game.Available) return;
        try
        {
            Apply(NamePointerA, Alucard, Dracula);
            Apply(NamePointerB, Alucard, Dracula);
        }
        catch { }
    }
}
