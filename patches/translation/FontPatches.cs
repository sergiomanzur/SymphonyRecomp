using RecompOne.Runtime.Context;
using RecompOne.Runtime.Memory;

namespace Recompiled.Translation;

public static class FontPatches
{
    private const uint CdCallbackAddr = 0x80137F58;
    private const uint CdLocAddr = 0x80137F5C;
    private const uint CdPhaseAddr = 0x80137F70;
    private const uint CdBlockAddr = 0x80137F74;
    private const int GameChrLba = 0x61CE;
    private const int RichterGameChrLba = 0x6252;
    private const int SelChrLba = 0x74B6;

    private static int Bcd(byte value) => (value >> 4) * 10 + (value & 0xF);

    private static int LoadingLba(IMemory m) =>
        (Bcd(m.ReadU8(CdLocAddr)) * 60 + Bcd(m.ReadU8(CdLocAddr + 1))) * 75 + Bcd(m.ReadU8(CdLocAddr + 2)) - 150;

    public static void PrepareCdGraphics(CpuContext c, IMemory m)
    {
        GameLanguage.EnsureLoaded();
        uint phase = m.ReadU32(CdPhaseAddr);
        if (phase is not (3 or 7)) return;
        uint callback = m.ReadU32(CdCallbackAddr);
        int file = LoadingLba(m);
        int offset = checked((int)m.ReadU32(CdBlockAddr) * 0x2000);
        uint buffer = phase == 7 ? 0x801EE000u : 0x801EC000u;
        if (callback == 1 && file is GameChrLba or RichterGameChrLba)
        {
            string id = file == RichterGameChrLba ? "small-richter" : "small-alucard";
            FontGraphics.Capture(id, m, buffer, offset);
            GameLanguage.Fonts?.ApplyChunk(id, m, buffer, offset, 0x2000);
            FontGraphics.Loaded(id, m, buffer, offset);
        }
        else if (callback == 2 && file == SelChrLba)
        {
            FontGraphics.Capture("menu", m, buffer, offset);
            GameLanguage.Fonts?.ApplyChunk("menu-alphabet", m, buffer, offset, 0x2000);
            GameLanguage.Fonts?.ApplyChunk("menu-digits", m, buffer, offset, 0x2000);
            FontGraphics.Loaded("menu", m, buffer, offset);
        }
    }

    public static void PrepareMenuPalette(CpuContext c, IMemory m)
    {
        GameLanguage.EnsureLoaded();
        FontGraphics.CaptureMenu(m);
        if (GameLanguage.Fonts is not { } pack) return;
        if (pack.Atlases.TryGetValue("menu-alphabet", out var font) ||
            pack.Atlases.TryGetValue("menu-digits", out font))
        {
            m.LoadBytes(0x8018CD54, font.Palette);
            FontGraphics.LoadedMenuPalette(font.Palette);
        }
    }

    public static void PrepareDebugFont(CpuContext c, IMemory m)
    {
        GameLanguage.EnsureLoaded();
        FontGraphics.CaptureDebug(m);
        if (GameLanguage.Fonts is not { } pack || !pack.Atlases.TryGetValue("sdk-debug", out var font)) return;
        m.LoadBytes(0x8002BA18, font.Pixels);
        m.LoadBytes(0x8002B818, font.Palette);
    }

    public static void PrepareBiosFallback(CpuContext c, IMemory m)
    {
        GameLanguage.EnsureLoaded();
        if (GameLanguage.Fonts is not { Fallback: { } bitmap } pack) return;
        m.LoadBytes(0x800AC914, bitmap);
        m.WriteU16(0x800AC910, pack.FallbackCode);
    }

    internal static bool TryFallback(ushort code, out byte[] bitmap)
    {
        GameLanguage.EnsureLoaded();
        if (GameLanguage.Fonts is { } pack && pack.FallbackGlyphs.TryGetValue(code, out bitmap!)) return true;
        bitmap = [];
        return false;
    }

    public static bool KromGlyph(CpuContext context, IMemory memory)
    {
        if (!TryFallback((ushort)context.A0, out var bitmap)) return true;
        memory.LoadBytes(0x800AC914, bitmap);
        context.V0 = 0x800AC914;
        return false;
    }
}
