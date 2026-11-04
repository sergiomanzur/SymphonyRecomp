using System;
using System.IO;
using RecompOne.Runtime.Gpu.Hle;
using RecompOne.Runtime.Modding;

namespace DraculaMod;

/// <summary>
/// Reads and writes raw VRAM.
///
/// This is what makes an authored Dracula sprite possible at all. His own artwork cannot be used
/// outside the throne room - his sprites *and* his animation frame tables live in the ST0 overlay,
/// and every stage overlay shares base 0x80180000, so only one is ever resident. But that only
/// blocks using *his* assets. Alucard's animation tables are always resident, so replacing the
/// pixels his frames point at leaves every frame size, offset and timing intact and simply draws
/// something else. The game keeps animating; it just animates Dracula.
///
/// Step one is being able to see the sheet, hence the dump.
/// </summary>
public static class VramTool
{
    public const int VramWidth = 1024;
    public const int VramHeight = 512;

    /// <summary>Where dumps land: next to the mod, which on Android is reachable over USB.</summary>
    public static string OutputDir =>
        string.IsNullOrEmpty(ModLoader.Root) ? "." : ModLoader.Root;

    /// <summary>
    /// Reads a VRAM rectangle. Prefers the GPU backend, which is authoritative while the HLE
    /// renderer is running, and falls back to the CPU-side shadow copy.
    /// </summary>
    public static bool Read(int x, int y, int w, int h, ushort[] into)
    {
        if (into == null || into.Length < w * h) return false;

        var backend = GpuHle.Backend;
        if (GpuHle.Active && backend is { Ready: true })
        {
            backend.ReadVram(x, y, w, h, into.AsSpan(0, w * h));
            return true;
        }

        var gpu = RecompOne.Runtime.Runtime.Gpu;
        if (gpu == null) return false;

        for (int row = 0; row < h; row++)
            for (int col = 0; col < w; col++)
                into[row * w + col] = gpu.Shadow[x + col, y + row];
        return true;
    }

    /// <summary>Writes a VRAM rectangle to both the shadow and the backend, mirroring how palettes are written.</summary>
    public static void Write(int x, int y, int w, int h, ReadOnlySpan<ushort> px)
    {
        var gpu = RecompOne.Runtime.Runtime.Gpu;
        if (gpu != null)
            for (int row = 0; row < h; row++)
                for (int col = 0; col < w; col++)
                    gpu.Shadow[x + col, y + row] = px[row * w + col];

        var backend = GpuHle.Backend;
        if (GpuHle.Active && backend is { Ready: true })
            backend.WriteVram(x, y, w, h, px);
    }

    /// <summary>
    /// Dumps all of VRAM as raw little-endian 16-bit pixels, 1024x512.
    ///
    /// Deliberately not a PNG: encoding one would mean depending on ImageSharp surviving the
    /// Android trimmer, and a headerless dump converts on the desktop side in a few lines.
    /// </summary>
    public static string DumpAll()
    {
        var buf = new ushort[VramWidth * VramHeight];
        if (!Read(0, 0, VramWidth, VramHeight, buf))
            return "VRAM not available yet";

        string path = Path.Combine(OutputDir, "vram.bin");
        try
        {
            var bytes = new byte[buf.Length * 2];
            for (int i = 0; i < buf.Length; i++)
            {
                bytes[i * 2] = (byte)(buf[i] & 0xFF);
                bytes[i * 2 + 1] = (byte)(buf[i] >> 8);
            }
            File.WriteAllBytes(path, bytes);
            Console.WriteLine($"[Dracula] VRAM dumped to {path}");
            return path;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Dracula] VRAM dump failed: {ex.Message}");
            return ex.Message;
        }
    }
}
