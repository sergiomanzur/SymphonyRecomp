using RecompOne.Runtime.Memory;

namespace Recompiled;

public static partial class WidescreenPatch
{
    const uint MirrorPolyBase = 0x80380000;
    const int MirrorPolyCapacity = 1024;
    const uint MirrorPolyStride = 40;

    static readonly HashSet<string> MirroredBackgrounds = new(StringComparer.OrdinalIgnoreCase) { "no3", "np3", "rno3" };

    static uint _mirrorPool;
    static int _mirrorCount;

    static void BeginMirror(uint buf)
    {
        _mirrorPool = MirrorPolyBase + (buf == Buf(1) ? MirrorPolyCapacity * MirrorPolyStride : 0u);
        _mirrorCount = 0;
    }

    static bool MirrorBackground(IMemory m, uint addr)
    {
        if (OriginalAspect) return false;
        uint kind = m.ReadU32(addr + 0x2C);
        if (kind is >= 1 and <= 7) return false;
        return StageOverlay(m) is { } overlay && MirroredBackgrounds.Contains(overlay.Name);
    }

    static void DrawMirroredTile(IMemory m, in Layer L, uint ot, int row, int tx, int x0, int y0)
    {
        if (_mirrorCount >= MirrorPolyCapacity || L.RoomW <= 0) return;
        int period = L.RoomW * 2;
        int k = ((tx % period) + period) % period;
        bool flipped = k >= L.RoomW;
        int source = flipped ? period - 1 - k : k;

        ushort tile = m.ReadU16(L.Layout + (uint)(row + source) * 2);
        if (tile == 0) return;

        byte g = m.ReadU8(L.GfxIndex + tile);
        int u = (g & 0xF) << 4;
        int v = g & 0xF0;
        byte page = m.ReadU8(L.GfxPage + tile);
        byte clutIdx = m.ReadU8(L.Clut + tile);
        ushort clut = m.ReadU16(ClutIdsAddr + (uint)((L.ClutAlt ? 0x100 : 0) + clutIdx) * 2);
        int tpage = page + 8 + L.TpageBase;
        if ((L.Flags & LayerTpageAlt) != 0) tpage += 0x80;

        int uLeft, uRight;
        if (!flipped) { uLeft = u; uRight = Math.Min(u + 16, 255); }
        else if (u > 0) { uLeft = u + 15; uRight = u - 1; }
        else { uLeft = 15; uRight = 0; }
        int vTop = v, vBottom = Math.Min(v + 16, 255);

        uint prim = _mirrorPool + (uint)_mirrorCount++ * MirrorPolyStride;
        uint code = L.SemiTrans ? 0x2Fu : 0x2Du;
        AddPrim(m, ot, L.Order + page, prim, 9);
        m.WriteU32(prim + 4, code << 24 | 0x808080);
        m.WriteU32(prim + 8, Xy(x0, y0));
        m.WriteU32(prim + 12, (uint)clut << 16 | (uint)vTop << 8 | (uint)uLeft);
        m.WriteU32(prim + 16, Xy(x0 + 16, y0));
        m.WriteU32(prim + 20, ((uint)tpage & 0x9FF) << 16 | (uint)vTop << 8 | (uint)uRight);
        m.WriteU32(prim + 24, Xy(x0, y0 + 16));
        m.WriteU32(prim + 28, (uint)vBottom << 8 | (uint)uLeft);
        m.WriteU32(prim + 32, Xy(x0 + 16, y0 + 16));
        m.WriteU32(prim + 36, (uint)vBottom << 8 | (uint)uRight);
    }

    static uint Xy(int x, int y) => (uint)(ushort)y << 16 | (ushort)x;
}
