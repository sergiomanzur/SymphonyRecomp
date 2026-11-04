using System.Globalization;
using System.Text.Json;
using RecompOne.Runtime.Bios;
using RecompOne.Runtime.Memory;

namespace Recompiled.Translation;

internal sealed record FontSegment(int Offset, byte[] Data);

internal sealed class FontPack
{
    public Dictionary<string, FontBitmap> Atlases { get; } = new(StringComparer.Ordinal);
    public Dictionary<string, List<FontSegment>> Segments { get; } = new(StringComparer.Ordinal);
    public Dictionary<string, byte[]> Bios { get; } = new(StringComparer.Ordinal);
    public KromFont.Lookup[]? Table { get; private set; }
    public Dictionary<ushort, byte[]> FallbackGlyphs { get; } = [];
    public byte[]? Fallback { get; private set; }
    public ushort FallbackCode { get; private set; }

    internal void SetTable(KromFont.Lookup[] table) => Table = table;

    public static FontPack FromBios()
    {
        var bios = new byte[0x80000];
        KromFont.InstallInto(bios);
        var pack = new FontPack();
        pack.Bios.Add("font1", bios.AsSpan(0x66000, 0x3D68).ToArray());
        pack.Bios.Add("font2", bios.AsSpan(0x69D68, (0x80000 - 0x69D68) / 30 * 30).ToArray());
        var table = new List<KromFont.Lookup>();
        int previous = -2;
        for (int code = 0x8140; code <= 0x9872; code++)
        {
            ushort offset = KromFont.Krom2Offset((uint)code);
            if (offset != previous + 1) table.Add(new((ushort)code, offset));
            previous = offset;
        }
        table.Add(new(0xFFFF, 0));
        pack.SetTable(table.ToArray());
        return pack;
    }

    public static FontPack Load(string root)
    {
        var pack = new FontPack();
        using var manifest = JsonDocument.Parse(File.ReadAllText(Path.Combine(root, "manifest.json")));
        if (!manifest.RootElement.TryGetProperty("fonts", out var fonts)) return pack;
        foreach (var entry in fonts.EnumerateObject())
        {
            if (!entry.Value.TryGetProperty("manifest", out var relative)) continue;

            string path = Resolve(root, relative.GetString()!);
            string directory = Path.GetDirectoryName(path)!;

            using var document = JsonDocument.Parse(File.ReadAllText(path));
            var font = document.RootElement;

            switch (entry.Name)
            {
                case "bios-font": pack.LoadBios(directory, font); break;
                case "bios-fallback":
                    var glyphs = font.GetProperty("glyphs").EnumerateArray().Where(g => !Custom(g)).ToArray();
                    if (glyphs.Length == 0) throw new InvalidDataException("The fallback font requires glyphs.");
                    byte[] raw = FontBitmap.Monochrome(Path.Combine(directory, "atlas.png"), glyphs.Select(Rect).ToArray());
                    for (int i = 0; i < glyphs.Length; i++)
                    {
                        ushort code = checked((ushort)glyphs[i].GetProperty("code").GetInt32());
                        if (!pack.FallbackGlyphs.TryAdd(code, raw.AsSpan(i * 30, 30).ToArray()))
                            throw new InvalidDataException("Duplicated fallback glyph.");
                    }
                    if (pack.FallbackGlyphs.TryGetValue(0x9F54, out var copyright))
                    {
                        pack.Fallback = copyright;
                        pack.FallbackCode = 0x9F54;
                    }
                    break;
                case "small-alucard":
                case "small-richter":
                case "menu-alphabet":
                case "menu-digits":
                case "sdk-debug": pack.LoadAtlas(entry.Name, directory, font); break;
            }
        }

        if (pack.Atlases.TryGetValue("menu-alphabet", out var letters) &&
            pack.Atlases.TryGetValue("menu-digits", out var digits) && !letters.Palette.SequenceEqual(digits.Palette))
            throw new InvalidDataException("menu letters and digits share a palette and should have identical palettes");

        return pack;
    }

    public void ApplyChunk(string id, IMemory memory, uint destination, int offset, int length)
    {
        if (!Segments.TryGetValue(id, out var segments)) return;
        foreach (var segment in segments)
        {
            int first = Math.Max(offset, segment.Offset);
            int last = Math.Min(offset + length, segment.Offset + segment.Data.Length);
            for (int i = first; i < last; i++)
                memory.WriteU8(destination + (uint)(i - offset), segment.Data[i - segment.Offset]);
        }
    }

    private static bool Custom(JsonElement glyph) => glyph.TryGetProperty("custom", out var custom) && custom.ValueKind == JsonValueKind.True;

    private void LoadAtlas(string id, string directory, JsonElement font)
    {
        int width = font.GetProperty("width").GetInt32(), height = font.GetProperty("height").GetInt32();
        var expected = id switch
        {
            "small-alucard" or "small-richter" => (128, 128), "menu-alphabet" => (128, 80),
            "menu-digits" => (80, 8), _ => (128, 32)
        };
        if ((width, height) != expected) throw new InvalidDataException($"unsupported atlas size: {id}");
        var atlas = FontBitmap.Load(directory, width, height);
        Atlases.Add(id, atlas);
        var segments = new List<FontSegment>();
        Segments.Add(id, segments);
        if (id is "small-alucard" or "small-richter")
        {
            segments.Add(new(0x30000, atlas.Pixels));
            segments.Add(new(0x412C0, atlas.Palette));
        }
        else if (id == "menu-digits")
        {
            for (int y = 0; y < 8; y++) segments.Add(new(0x23E18 + y * 64, atlas.Pixels.AsSpan(y * 40, 40).ToArray()));
        }
        else if (id == "menu-alphabet")
        {
            var glyphs = font.GetProperty("glyphs").EnumerateArray().ToArray();
            if (glyphs.Length != 33) throw new InvalidDataException("The menu atlas requires 33 glyphs.");
            var codes = new HashSet<int>();
            foreach (var glyph in glyphs)
            {
                int code = glyph.GetProperty("code").GetInt32();
                int offset = Hex(glyph.GetProperty("sourceOffset").GetString()!);
                var r = Rect(glyph);
                if (code < 0 || code >= 33 || !codes.Add(code) || r[0] < 0 || r[1] < 0 || r[0] % 2 != 0 || r[2] != 16 || r[3] != 16 || r[0] + 16 > width || r[1] + 16 > height ||offset < 0x26000 || offset + 15 * 64 + 8 > 0x28000 || offset % 64 > 56)
                    throw new InvalidDataException("Invalid menu glyph mapping.");

                for (int y = 0; y < 16; y++)
                    segments.Add(new(offset + y * 64, atlas.Pixels.AsSpan((r[1] + y) * width / 2 + r[0] / 2, 8).ToArray()));
            }
        }
    }

    private void LoadBios(string directory, JsonElement manifest)
    {
        var glyphSize = manifest.TryGetProperty("glyphSize", out var size)
            ? size.EnumerateArray().Select(value => value.GetInt32()).ToArray()
            : [16, 15];
        if (glyphSize.Length != 2 || glyphSize[0] < 1 || glyphSize[0] > 16 || glyphSize[1] < 1 || glyphSize[1] > 15)
            throw new InvalidDataException("Invalid BIOS glyph size.");

        var mappings = new SortedDictionary<ushort, (string Font, int Index)>();
        foreach (var font in manifest.GetProperty("fonts").EnumerateArray())
        {
            string id = font.GetProperty("id").GetString()!;
            int capacity = id switch { "font1" => 0x3D68 / 30, "font2" => (0x80000 - 0x69D68) / 30, _ => throw new InvalidDataException("Unknown BIOS font.") };
            ushort firstCode = id == "font1" ? (ushort)0x8140 : (ushort)0x889F;
            ushort lastCode = id == "font1" ? (ushort)0x84BE : (ushort)0x9872;
            var glyphs = font.GetProperty("glyphs").EnumerateArray().Where(g => !Custom(g)).OrderBy(g => g.GetProperty("index").GetInt32()).ToArray();
            if (glyphs.Length == 0 || glyphs.Length > capacity)
                throw new InvalidDataException("BIOS font exceeds its ROM region.");

            var rectangles = new int[glyphs.Length][];
            var offsets = new int[glyphs.Length][];
            for (int i = 0; i < glyphs.Length; i++)
            {
                var glyph = glyphs[i];
                if (glyph.GetProperty("index").GetInt32() != i)
                    throw new InvalidDataException("BIOS glyph indices must be contiguous.");
                rectangles[i] = Rect(glyph);
                offsets[i] = glyph.TryGetProperty("offset", out var offset)
                    ? offset.EnumerateArray().Select(value => value.GetInt32()).ToArray()
                    : [0, 0];
                foreach (ushort code in glyph.GetProperty("codes").EnumerateArray().Select(value => checked((ushort)value.GetInt32())))
                {
                    if (code < firstCode || code > lastCode || !mappings.TryAdd(code, (id, i)))
                        throw new InvalidDataException("Invalid or duplicated BIOS glyph code.");
                }
            }

            Bios.Add(id, FontBitmap.Monochrome(
                Resolve(directory, font.GetProperty("image").GetString()!), rectangles,
                glyphSize[0], glyphSize[1], offsets));
        }

        Table = BuildTable(mappings);
    }

    private static KromFont.Lookup[] BuildTable(SortedDictionary<ushort, (string Font, int Index)> mappings)
    {
        var table = new List<KromFont.Lookup>();
        AddRange(0x8140, 0x84BE, "font1");
        AddRange(0x889F, 0x9872, "font2");
        table.Add(new(0xFFFF, 0));
        return table.ToArray();

        void AddRange(int first, int last, string font)
        {
            int previousCode = -2;
            int previousIndex = -2;
            for (int code = first; code <= last; code++)
            {
                int index = mappings.TryGetValue((ushort)code, out var mapping) && mapping.Font == font
                    ? mapping.Index : 0;
                if (code != previousCode + 1 || index != previousIndex + 1)
                    table.Add(new((ushort)code, checked((ushort)index)));
                previousCode = code;
                previousIndex = index;
            }
        }
    }

    private static int[] Rect(JsonElement glyph) => glyph.GetProperty("rect").EnumerateArray().Select(v => v.GetInt32()).ToArray();
    private static int Hex(string value) => int.Parse(value.AsSpan(2), NumberStyles.HexNumber, CultureInfo.InvariantCulture);
    private static string Resolve(string root, string path)
    {
        string directory = Path.GetFullPath(root) + Path.DirectorySeparatorChar;
        string full = Path.GetFullPath(Path.Combine(root, path));
        if (!full.StartsWith(directory, StringComparison.Ordinal)) throw new InvalidDataException("Font path is outside the pack.");
        return full;
    }
}
