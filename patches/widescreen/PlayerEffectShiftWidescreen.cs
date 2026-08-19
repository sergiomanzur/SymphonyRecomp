using RecompOne.Runtime.Context;
using RecompOne.Runtime.Memory;

namespace Recompiled;

public static partial class WidescreenPatch
{
    const uint PlayerFxPrimIndex = 0x64;
    const uint PlayerFxUpdate = 0x28;
    const int PlayerFxPolyPrims = 4;
    const int PlayerFxTilePrims = 16;

    static void ShiftX(IMemory m, uint addr, int by) => m.WriteU16(addr, (ushort)(short)((short)m.ReadU16(addr) + by)); //shift it to the thing

    static int _playerFxShift;
    static uint _playerFxEntity;

    public static void PrePlayerEffectShift(CpuContext c, IMemory m)
    {
        _playerFxShift = 0;
        if (OriginalAspect) return;

        int margin = StageMargin();
        if (margin == 0) return;

        _playerFxShift = margin;
        _playerFxEntity = c.A0;
        ShiftX(m, c.A0 + PedPosXHi, margin);
    }

    public static void PostPlayerEffectShift(CpuContext c, IMemory m)
    {
        int margin = _playerFxShift;
        if (margin == 0) return;
        _playerFxShift = 0;

        uint entity = _playerFxEntity;
        if (entity == 0 || m.ReadU32(entity + PlayerFxUpdate) == 0) return;

        ShiftX(m, entity + PedPosXHi, -margin);
        ShiftPlayerFxPrims(m, entity, -margin);
    }

    static void ShiftPlayerFxPrims(IMemory m, uint entity, int dx)
    {
        uint index = m.ReadU32(entity + PlayerFxPrimIndex);
        if (index == 0xFFFFFFFFu) return;

        uint prim = PrimBufAddr + index * PrimStride;

        for (int i = 0; i < PlayerFxPolyPrims && prim != 0; i++)
        {
            ShiftX(m, prim + 0x08, dx);
            ShiftX(m, prim + 0x14, dx);
            ShiftX(m, prim + 0x20, dx);
            ShiftX(m, prim + 0x2C, dx);
            prim = m.ReadU32(prim);
        }

        for (int i = 0; i < PlayerFxTilePrims && prim != 0; i++)
        {
            ShiftX(m, prim + 0x08, dx);
            prim = m.ReadU32(prim);
        }
    }
}
