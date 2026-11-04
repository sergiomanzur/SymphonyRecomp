using System.Text.Json;

namespace Recompiled.Translation;

internal sealed record DialogueGlyph(int Width, int Height, int Advance, int X, int Y, byte[] Pixels);

internal sealed class DialogueFont
{
    private readonly Dictionary<string, Dictionary<int, DialogueGlyph>> _fonts = [];
    internal int LineSpacing { get; private set; } = 12;
    internal int VisibleLines { get; private set; } = 4;
    internal int TextLeft { get; private set; } = 12;
    internal int TextWidth { get; private set; } = 192;
    internal int TextTop { get; private set; } = 20;
    internal int TextHeight { get; private set; } = 48;
    internal static readonly int[] Levels = [0, 8, 16, 18, 20, 23, 25, 28, 30];

    internal DialogueGlyph? Find(int character, bool richter)
    {
        int alias = char.ConvertToUtf32(TextCodec.Cp932Aliases(char.ConvertFromUtf32(character)), 0);
        foreach (string name in new[] { richter ? "small-richter" : "small-alucard", "bios-fallback", "bios-font" })
        {
            if (!_fonts.TryGetValue(name, out var glyphs)) continue;
            if (glyphs.TryGetValue(character, out var glyph) || glyphs.TryGetValue(alias, out glyph)) return glyph;
        }
        return null;
    }

    internal static DialogueFont Load(string root)
    {
        var result = new DialogueFont();
        using var manifest = JsonDocument.Parse(File.ReadAllText(Path.Combine(root, "manifest.json")));
        
        if (manifest.RootElement.TryGetProperty("dialogue", out var layout))
        {
            if (layout.TryGetProperty("visibleLines", out var lines)) result.VisibleLines = lines.GetInt32();
            if (layout.TryGetProperty("textLeft", out var left)) result.TextLeft = left.GetInt32();
            if (layout.TryGetProperty("textWidth", out var width)) result.TextWidth = width.GetInt32();
            if (layout.TryGetProperty("textTop", out var top)) result.TextTop = top.GetInt32();
            if (layout.TryGetProperty("textHeight", out var height)) result.TextHeight = height.GetInt32();
            if (result.TextLeft < -64 || result.TextLeft > 64 || result.TextWidth < 1 || result.TextWidth > 192 || result.VisibleLines < 1 || result.VisibleLines > 4 || result.TextTop < 0 || result.TextHeight < 8 || result.TextTop + result.TextHeight > 72) throw new InvalidDataException("Invalid dialogue layout.");
        }
        
        if (!manifest.RootElement.TryGetProperty("fonts", out var fonts)) return result;
        
        foreach (string name in new[] { "small-alucard", "small-richter", "bios-font", "bios-fallback" })
        {
            if (!fonts.TryGetProperty(name, out var entry)) continue;
            string path = Path.Combine(root, entry.GetProperty("manifest").GetString()!);
            using var document = JsonDocument.Parse(File.ReadAllText(path));
            var definition = document.RootElement;
            
            if (name == "bios-font" && definition.TryGetProperty("lineSpacing", out var spacing))
            {
                result.LineSpacing = spacing.GetInt32();
                if (result.LineSpacing < 8 || result.LineSpacing > 16) throw new InvalidDataException("Invalid line spacing.");
            }
            
            var glyphs = new Dictionary<int, DialogueGlyph>();
            result._fonts.Add(name, glyphs);
            string type = definition.TryGetProperty("type", out var declared) ? declared.GetString()! : name.StartsWith("small-") ? "ascii" : "shift-jis";
            if (type is not ("ascii" or "shift-jis" or "utf8")) throw new InvalidDataException($"{name}: unknown font type {type}.");
            
            if (definition.TryGetProperty("fonts", out var atlases))
                foreach (var atlas in atlases.EnumerateArray()) ReadAtlas(Path.GetDirectoryName(path)!, atlas.GetProperty("image").GetString()!, definition, atlas.GetProperty("glyphs"), glyphs, type, false);
            else ReadAtlas(Path.GetDirectoryName(path)!, definition.TryGetProperty("image", out var image) ? image.GetString()! : "atlas.png", definition, definition.GetProperty("glyphs"), glyphs, type, name.StartsWith("small-"));
        }
        
        if (result.VisibleLines * result.LineSpacing > result.TextHeight) throw new InvalidDataException("Dialogue lines exceed the text area height.");
        
        return result;
    }

    private static IEnumerable<int> Characters(JsonElement entry, string type)
    {
        var text = new List<string>();
        if (entry.TryGetProperty("characters", out var many))
            foreach (var value in many.EnumerateArray()) if (value.GetString() is { Length: > 0 } item) text.Add(item);
        if (entry.TryGetProperty("character", out var one) && one.ValueKind == JsonValueKind.String && one.GetString() is { Length: > 0 } single) text.Add(single);

        foreach (string item in text)
            foreach (var rune in item.EnumerateRunes())
            {
                if (type == "ascii" && rune.Value is < 32 or > 126) continue;
                yield return rune.Value;
                if (type != "utf8") break;
            }
    }

    private static void ReadAtlas(string directory, string file, JsonElement font, JsonElement entries, Dictionary<int, DialogueGlyph> target, string type, bool ascii)
    {
        var image = RgbaImage.Load(Path.Combine(directory, file));
        
        foreach (var entry in entries.EnumerateArray())
        {
            var r = entry.GetProperty("rect").EnumerateArray().Select(v => v.GetInt32()).ToArray();
            var size = entry.TryGetProperty("renderSize", out var local) ? local : font.TryGetProperty("renderSize", out var shared) ? shared : default;
            int w = size.ValueKind == JsonValueKind.Array ? size[0].GetInt32() : ascii ? r[2] : 12;
            int h = size.ValueKind == JsonValueKind.Array ? size[1].GetInt32() : ascii ? r[3] : 12;
            int advance = entry.TryGetProperty("advance", out var a) ? a.GetInt32() : w;
            int x = entry.TryGetProperty("offset", out var offset) ? offset[0].GetInt32() : 0;
            int y = offset.ValueKind == JsonValueKind.Array ? offset[1].GetInt32() : 0;
            if (w < 1 || w > 32 || h < 1 || h > 16 || advance < 1 || advance > 32 || Math.Abs(x) > 16 || y < 0 || y + h > 16 || r.Length != 4 || r[0] < 0 || r[1] < 0 || r[2] < 1 || r[3] < 1 || r[0] + r[2] > image.Width || r[1] + r[3] > image.Height)
                throw new InvalidDataException($"Invalid dialogue glyph metrics in {file}.");
            byte[] pixels = new byte[w * h];
            if (font.TryGetProperty("sampling", out var sampling) && sampling.GetString() == "sotn" && r[2] == 16 && r[3] == 15 && w == 12 && h == 16) pixels = FontRaster.Sotn(image, r[0], r[1]);
            else for (int dy = 0; dy < h; dy++)
                for (int dx = 0; dx < w; dx++)
                {
                    long total = 0;
                    for (int sy = dy * r[3] / h; sy < ((dy + 1) * r[3] + h - 1) / h; sy++)
                        for (int sx = dx * r[2] / w; sx < ((dx + 1) * r[2] + w - 1) / w; sx++)
                        {
                            int weight = (Math.Min((sy + 1) * h, (dy + 1) * r[3]) - Math.Max(sy * h, dy * r[3])) * (Math.Min((sx + 1) * w, (dx + 1) * r[2]) - Math.Max(sx * w, dx * r[2]));
                            var pixel = image[r[0] + sx, r[1] + sy];
                            total += (long)Math.Max(pixel.R, Math.Max(pixel.G, pixel.B)) * pixel.A * weight;
                        }
                    long denominator = (long)r[2] * r[3] * 255 * 255;
                    int intensity = (int)((total * 30 + denominator / 2) / denominator), best = 0;
                    for (int i = 1; i < Levels.Length; i++) if (Math.Abs(Levels[i] - intensity) < Math.Abs(Levels[best] - intensity)) best = i;
                    pixels[dy * w + dx] = (byte)best;
                }
            var glyph = new DialogueGlyph(w, h, advance, x, y, pixels);

            foreach (int character in Characters(entry, type))
                target.TryAdd(character, glyph);
        }
    }
}
