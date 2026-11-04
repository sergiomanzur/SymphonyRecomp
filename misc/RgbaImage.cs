using StbImageSharp;

namespace Recompiled;

public readonly record struct RgbaPixel(byte R, byte G, byte B, byte A);

public sealed class RgbaImage
{
    private RgbaImage(int width, int height, byte[] pixels)
    {
        Width = width;
        Height = height;
        Pixels = pixels;
    }

    public int Width { get; }
    public int Height { get; }
    public byte[] Pixels { get; }

    public RgbaPixel this[int x, int y]
    {
        get
        {
            int i = (y * Width + x) * 4;
            return new(Pixels[i], Pixels[i + 1], Pixels[i + 2], Pixels[i + 3]);
        }
    }

    public static RgbaImage Load(string path) => Load(File.ReadAllBytes(path));

    public static RgbaImage Load(byte[] data)
    {
        var image = ImageResult.FromMemory(data, ColorComponents.RedGreenBlueAlpha);
        return new(image.Width, image.Height, image.Data);
    }
}
