using System.Buffers.Binary;
using System.IO.Compression;

namespace Recompiled.Translation;

internal sealed record FontBitmap(int Width, int Height, byte[] Pixels, byte[] Palette)
{
    public static FontBitmap Load(string directory, int width, int height)
    {
        var palette = File.ReadAllBytes(Path.Combine(directory, "palette.bgr555"));
        if (palette.Length != 32) throw new InvalidDataException("A font palette must contain 16 colors.");
        var path = Path.Combine(directory, "atlas.png");
        var image = RgbaImage.Load(path);
        if (image.Width != width || image.Height != height || width % 2 != 0)
            throw new InvalidDataException($"Invalid font dimensions: {path}");
        var indices = ReadIndices(path, width, height);
        if (indices == null)
        {
            indices = new byte[width * height];
            for (int y = 0; y < height; y++)
            for (int x = 0; x < width; x++)
            {
                var pixel = image[x, y];
                int best = -1, distance = int.MaxValue;
                for (int i = 0; i < 16; i++)
                {
                    ushort color = BinaryPrimitives.ReadUInt16LittleEndian(palette.AsSpan(i * 2));
                    if ((pixel.A < 128) != (color == 0)) continue;
                    int r = pixel.R - (color & 31) * 255 / 31;
                    int g = pixel.G - (color >> 5 & 31) * 255 / 31;
                    int b = pixel.B - (color >> 10 & 31) * 255 / 31;
                    int score = r * r + g * g + b * b;
                    if (score < distance) { distance = score; best = i; }
                }
                if (best < 0) throw new InvalidDataException($"No compatible palette color: {path}");
                indices[y * width + x] = (byte)best;
            }
        }
        var packed = new byte[indices.Length / 2];
        for (int i = 0; i < packed.Length; i++)
        {
            if (indices[i * 2] > 15 || indices[i * 2 + 1] > 15)
                throw new InvalidDataException($"Font uses more than 16 palette indices: {path}");
            packed[i] = (byte)(indices[i * 2] | indices[i * 2 + 1] << 4);
        }
        return new(width, height, packed, palette);
    }

    public static byte[] Monochrome(string path, IReadOnlyList<int[]> rectangles, int width = 16, int height = 15, IReadOnlyList<int[]>? offsets = null)
    {
        var image = RgbaImage.Load(path);
        if (width < 1 || width > 16 || height < 1 || height > 15)
            throw new InvalidDataException("KROM glyph dimensions must fit a 16x15 cell.");

        var data = new byte[rectangles.Count * 30];
        for (int i = 0; i < rectangles.Count; i++)
        {
            var r = rectangles[i];
            int[] offset = offsets == null ? new[] { 0, 0 } : offsets[i];
            if (r.Length != 4 || r[0] < 0 || r[1] < 0 || r[2] < 1 || r[3] < 1 ||
                r[0] + r[2] > image.Width || r[1] + r[3] > image.Height ||
                offset.Length != 2 || offset[0] < 0 || offset[1] < 0 || offset[0] >= 16 || offset[1] >= 15)
                throw new InvalidDataException($"Invalid BIOS glyph rectangle: {path}");

            double scale = Math.Min((double)width / r[2], (double)height / r[3]);
            int drawWidth = Math.Max(1, (int)(r[2] * scale));
            int drawHeight = Math.Max(1, (int)(r[3] * scale));
            if (offset[0] + drawWidth > 16 || offset[1] + drawHeight > 15)
                throw new InvalidDataException($"BIOS glyph does not fit its KROM cell: {path}");

            for (int y = 0; y < drawHeight; y++)
            for (int x = 0; x < drawWidth; x++)
            {
                var pixel = image[r[0] + x * r[2] / drawWidth, r[1] + y * r[3] / drawHeight];
                if (pixel.A < 128 || pixel.R * 299 + pixel.G * 587 + pixel.B * 114 < 128000) continue;
                int cellX = offset[0] + x;
                int cellY = offset[1] + y;
                data[i * 30 + cellY * 2 + cellX / 8] |= (byte)(1 << (7 - cellX % 8));
            }
        }
        return data;
    }

    private static byte[]? ReadIndices(string path, int width, int height)
    {
        byte[] png = File.ReadAllBytes(path);
        if (png[25] != 3) return null;
        int bits = png[24];
        if (bits is not (1 or 2 or 4 or 8) || png[28] != 0)
            throw new InvalidDataException("Indexed font PNGs must be non-interlaced.");
        using var compressed = new MemoryStream();
        for (int p = 8; p + 12 <= png.Length;)
        {
            int length = checked((int)BinaryPrimitives.ReadUInt32BigEndian(png.AsSpan(p)));
            if (length > png.Length - p - 12) throw new InvalidDataException("Invalid PNG chunk.");
            if (png.AsSpan(p + 4, 4).SequenceEqual("IDAT"u8)) compressed.Write(png, p + 8, length);
            p += length + 12;
        }
        compressed.Position = 0;
        using var zlib = new ZLibStream(compressed, CompressionMode.Decompress);
        int stride = (width * bits + 7) / 8;
        var filtered = new byte[(stride + 1) * height];
        zlib.ReadExactly(filtered);
        var previous = new byte[stride];
        var row = new byte[stride];
        var result = new byte[width * height];
        for (int y = 0; y < height; y++)
        {
            int filter = filtered[y * (stride + 1)];
            for (int x = 0; x < stride; x++)
            {
                int a = x == 0 ? 0 : row[x - 1], b = previous[x], c = x == 0 ? 0 : previous[x - 1];
                int predictor = filter switch
                {
                    0 => 0, 1 => a, 2 => b, 3 => (a + b) / 2,
                    4 => Paeth(a, b, c), _ => throw new InvalidDataException("Invalid PNG filter.")
                };
                row[x] = unchecked((byte)(filtered[y * (stride + 1) + x + 1] + predictor));
            }
            for (int x = 0; x < width; x++)
                result[y * width + x] = (byte)(row[x * bits / 8] >> (8 - bits - x * bits % 8) & ((1 << bits) - 1));
            (row, previous) = (previous, row);
        }
        return result;
    }

    private static int Paeth(int a, int b, int c)
    {
        int p = a + b - c, pa = Math.Abs(p - a), pb = Math.Abs(p - b), pc = Math.Abs(p - c);
        return pa <= pb && pa <= pc ? a : pb <= pc ? b : c;
    }
}
