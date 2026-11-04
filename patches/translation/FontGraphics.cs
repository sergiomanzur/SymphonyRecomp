using System.Buffers.Binary;
using RecompOne.Runtime.Dispatch;
using RecompOne.Runtime.Memory;

namespace Recompiled.Translation;

internal static class FontGraphics
{
    private static readonly Dictionary<(string Id, int Offset), byte[]> Originals = [];
    private static string? _small;
    private static byte[]? _menuPalette;
    private static byte[]? _debugPixels;
    private static byte[]? _debugPalette;

    private static byte[] Read(IMemory memory, uint address, int length)
    {
        var data = new byte[length];
        for (int i = 0; i < length; i++) data[i] = memory.ReadU8(address + (uint)i);
        return data;
    }

    internal static void Capture(string id, IMemory memory, uint address, int offset)
    {
        if (id == "menu")
        {
            if (offset is not (0x22000 or 0x26000)) return;
        }
        else
        {
            if (offset is not (0x30000 or 0x40000)) return;
            _small = id;
        }
        Originals[(id, offset)] = Read(memory, address, 0x2000);
    }

    internal static void Loaded(string id, IMemory memory, uint address, int offset)
    {
        (int X, int Y, int Start, int Length)? region = (id, offset) switch
        {
            ("menu", 0x22000) => (0x320, 0, 0, 0x2000),
            ("menu", 0x26000) => (0x320, 128, 0, 0x2000),
            (not "menu", 0x30000) => (0x380, 0x100, 0, 0x2000),
            (not "menu", 0x40000) => (96, 249, 0x12C0, 32),
            _ => null
        };
        if (region is { } r) Uploaded[(r.X, r.Y)] = Read(memory, address + (uint)r.Start, r.Length);
    }

    internal static void LoadedMenuPalette(byte[] palette) => Uploaded[(0, 8)] = palette;

    internal static void CaptureMenu(IMemory memory) => _menuPalette ??= Read(memory, 0x8018CD54, 32);
    internal static void CaptureDebug(IMemory memory)
    {
        _debugPixels ??= Read(memory, 0x8002BA18, 2048);
        _debugPalette ??= Read(memory, 0x8002B818, 32);
    }

    private static byte[] Chunk(FontPack pack, string id, int offset, byte[] original)
    {
        byte[] result = (byte[])original.Clone();
        if (!pack.Segments.TryGetValue(id, out var segments)) return result;
        foreach (var segment in segments)
        {
            int start = Math.Max(offset, segment.Offset), end = Math.Min(offset + result.Length, segment.Offset + segment.Data.Length);
            if (end > start) segment.Data.AsSpan(start - segment.Offset, end - start).CopyTo(result.AsSpan(start - offset));
        }
        return result;
    }

    internal static void Apply(FontPack pack, IMemory memory)
    {
        if (_small != null)
        {
            if (Originals.TryGetValue((_small, 0x30000), out var pixels))
                Upload(0x380, 0x100, 32, 128, Chunk(pack, _small, 0x30000, pixels), pixels);
            if (Originals.TryGetValue((_small, 0x40000), out var palette))
            {
                byte[] original = palette.AsSpan(0x12C0, 32).ToArray();
                byte[] colors = Chunk(pack, _small, 0x40000, palette).AsSpan(0x12C0, 32).ToArray();
                if (Upload(96, 249, 16, 1, colors, original)) memory.LoadBytes(0x8006FE8C, colors);
            }
        }
        if (Dispatcher.ActiveNames.Contains("sel", StringComparer.OrdinalIgnoreCase))
        {
            foreach (int offset in new[] { 0x22000, 0x26000 })
                if (Originals.TryGetValue(("menu", offset), out var pixels))
                {
                    byte[] data = Chunk(pack, "menu-alphabet", offset, pixels);
                    data = Chunk(pack, "menu-digits", offset, data);
                    Upload(0x320, offset == 0x22000 ? 0 : 128, 32, 128, data, pixels);
                }
            byte[]? palette = pack.Atlases.TryGetValue("menu-alphabet", out var letters) ? letters.Palette : pack.Atlases.TryGetValue("menu-digits", out var digits) ? digits.Palette : _menuPalette;
            if (palette != null && _menuPalette != null && Upload(0, 8, 16, 1, palette, _menuPalette))
                memory.LoadBytes(0x8018CD54, palette);
        }
        if (_debugPixels != null)
        {
            var font = pack.Atlases.GetValueOrDefault("sdk-debug");
            memory.LoadBytes(0x8002BA18, font?.Pixels ?? _debugPixels);
            memory.LoadBytes(0x8002B818, font?.Palette ?? _debugPalette!);
        }
    }

    private static readonly Dictionary<(int X, int Y), byte[]> Uploaded = [];

    private static bool Upload(int x, int y, int width, int height, byte[] data, byte[] original)
    {
        var gpu = RecompOne.Runtime.Runtime.Gpu;
        if (gpu == null) return false;
        if (!InVram(gpu, x, y, width, height, original) &&
            !(Uploaded.TryGetValue((x, y), out var previous) && InVram(gpu, x, y, width, height, previous)))
            return false;

        gpu.WriteGp0(0x01000000);
        gpu.WriteGp0(0xA0000000);
        gpu.WriteGp0((uint)x | (uint)y << 16);
        gpu.WriteGp0((uint)width | (uint)height << 16);
        for (int i = 0; i < data.Length; i += 4) gpu.WriteGp0(BinaryPrimitives.ReadUInt32LittleEndian(data.AsSpan(i, 4)));
        Uploaded[(x, y)] = data;
        return true;
    }

    private static bool InVram(RecompOne.Runtime.Gpu gpu, int x, int y, int width, int height, byte[] data)
    {
        if (data.Length < width * height * 2) return false;
        var vram = gpu.Vram;
        for (int row = 0; row < height; row++)
            for (int column = 0; column < width; column++)
            {
                int i = (row * width + column) * 2;
                if (vram[(y + row) * RecompOne.Runtime.Gpu.VramWidth + x + column] != (ushort)(data[i] | data[i + 1] << 8))
                    return false;
            }
        return true;
    }
}
