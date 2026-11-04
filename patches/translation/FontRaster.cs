
namespace Recompiled.Translation;

internal static class FontRaster
{
    internal static byte[] Sotn(RgbaImage atlas, int left, int top)
    {
        var rows = new int[16, 12];
        Span<int> bits = stackalloc int[4];
        for (int y = 0; y < 15; y++) {
            for (int block = 0; block < 4; block++)
            {
                for (int i = 0; i < 4; i++) { var p = atlas[left + block * 4 + i, top + y]; bits[i] = p.A >= 128 && p.B >= 128 ? 1 : 0; }
                rows[y, block * 3] = bits[0] * 3 + bits[1];
                rows[y, block * 3 + 1] = bits[1] * 2 + bits[2] * 2;
                rows[y, block * 3 + 2] = bits[2] + bits[3] * 3;
            }
        }

        var pixels = new byte[12 * 16];
        
        for (int group = 0; group < 2; group++) {
            for (int k = 7; k > 0; k--) {
                for (int x = 0; x < 12; x++)
                {
                    int row = group * 8 + 7 - k;
                    int index = (rows[row, x] * k + rows[row + 1, x] * (8 - k)) / 2;
                    pixels[(group * 7 + 7 - k) * 12 + x] = (byte)((index + 1) / 2);
                }
            }
        }
        return pixels;
    }
}
