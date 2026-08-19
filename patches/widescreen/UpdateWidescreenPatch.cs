using RecompOne.Runtime.Context;
using RecompOne.Runtime.Dispatch;
using RecompOne.Runtime.Memory;

namespace Recompiled;

//st_update.h Update reimplementation
public static partial class WidescreenPatch
{
    const int StageEntityStart = 64;
    const int TotalEntityCount = 256;

    const uint EntPalette = 0x16;
    const uint EntPfnUpdate = 0x28;
    const uint EntStep = 0x2C;
    const uint EntFlags = 0x34;
    const uint EntHitParams = 0x44;
    const uint EntHitFlags = 0x48;
    const uint EntNFramesInv = 0x49;
    const uint EntStunFrames = 0x58;
    const uint EntHitEffect = 0x6A;

    const uint FlagDead = 0x100;
    const uint FlagUnk200 = 0x200;
    const uint FlagUnk2000 = 0x2000;
    const uint FlagUnk100000 = 0x100000;
    const uint FlagUnk02000000 = 0x02000000;
    const uint FlagUnk10000000 = 0x10000000;
    const uint FlagUnk20000000 = 0x20000000;
    const uint FlagDestroyIfBarelyOut = 0x40000000;
    const uint FlagDestroyIfOut = 0x80000000;

    const uint TmVSize = 0x800730A8;
    const uint GfxPauseFlag = 0x800973FC;
    const uint GfxCornerTextTimer = 0x80097410;
    const uint GfxCornerTextPrims = 0x80097414;
    const uint ApiFreePrimitives = 0x8003C7B4;
    const uint GameTimer = 0x8003C8C4;
    const uint CurrentEntity = 0x8006C3B8;

    const int IconSlotNum = 32;

    public static void Update(CpuContext c, IMemory m)
    {
        if (!StageUpdateSymbols(m, out uint iconSlots, out uint invincibility)) return;

        var destroy = StageFn(m, "DestroyEntity");
        if (destroy == null) return;

        for (int i = 0; i < IconSlotNum; i++)
        {
            uint slot = iconSlots + (uint)(i * 2);
            ushort v = m.ReadU16(slot);
            if (v != 0) m.WriteU16(slot, (ushort)(v - 1));
        }

        int cornerTimer = (int)m.ReadU32(GfxCornerTextTimer);
        if (cornerTimer != 0)
        {
            cornerTimer--;
            m.WriteU32(GfxCornerTextTimer, (uint)cornerTimer);
            if (cornerTimer == 0)
                GameApiCall(c, m, ApiFreePrimitives, m.ReadU32(GfxCornerTextPrims));
        }

        int left = OutsetLeft(-64), right = OutsetRight(320);
        int farLeft = OutsetLeft(-128), farRight = OutsetRight(384);

        for (int i = StageEntityStart; i < TotalEntityCount; i++)
        {
            uint e = PedAt(i);
            if (m.ReadU32(e + EntPfnUpdate) == 0) continue;

            if (m.ReadU16(e + EntStep) != 0)
            {
                uint flags = m.ReadU32(e + EntFlags);

                if ((flags & FlagDestroyIfOut) != 0)
                {
                    int x = (short)m.ReadU16(e + PedPosXHi);
                    int y = (short)m.ReadU16(e + PedPosYHi);
                    if ((flags & FlagDestroyIfBarelyOut) != 0)
                    {
                        if (x < left || x > right || y < -64 || y > 288)
                        {
                            CallEntity(c, m, destroy, e); //td
                            continue;
                        }
                    }
                    else
                    {
                        if (x < farLeft || x > farRight || y < -128 || y > 352)
                        {
                            CallEntity(c, m, destroy, e); //td
                            continue;
                        }
                    }
                }

                if ((flags & FlagUnk02000000) != 0)
                {
                    int below = (short)m.ReadU16(e + PedPosYHi) + (short)m.ReadU16(TmScrollYHi);
                    int limit = ((short)m.ReadU16(TmVSize) << 8) + 128;
                    if (below > limit)
                    {
                        CallEntity(c, m, destroy, e);
                        continue;
                    }
                }

                if ((flags & 0xF) != 0)
                {
                    int idx = (m.ReadU8(e + EntNFramesInv) << 1) | (int)(flags & 1);
                    ushort pal = m.ReadU16(invincibility + (uint)(idx * 2));
                    uint next = flags - 1;
                    m.WriteU32(e + EntFlags, next);
                    m.WriteU16(e + EntPalette, pal);
                    if ((next & 0xF) == 0)
                    {
                        m.WriteU16(e + EntPalette, m.ReadU16(e + EntHitEffect));
                        m.WriteU16(e + EntHitEffect, 0);
                    }
                }

                if ((flags & FlagUnk20000000) != 0 && (flags & FlagUnk10000000) == 0)
                {
                    int x = (short)m.ReadU16(e + PedPosXHi);
                    int y = (short)m.ReadU16(e + PedPosYHi);
                    if (x < left || x > right || y < -64 || y > 288) continue;
                }

                short stun = (short)m.ReadU16(e + EntStunFrames);
                if (stun != 0)
                {
                    m.WriteU16(e + EntStunFrames, (ushort)(stun - 1));
                    if ((flags & FlagUnk100000) == 0) continue;
                }

                if (m.ReadU32(GfxPauseFlag) != 0)
                {
                    bool alive = (flags & (FlagUnk2000 | FlagDead)) != 0;
                    bool ticked = (flags & FlagUnk200) != 0 && (m.ReadU32(GameTimer) & 3) == 0;
                    if (!alive && !ticked) continue;
                }
            }

            m.WriteU32(CurrentEntity, e);
            CallEntity(c, m, null, e, m.ReadU32(e + EntPfnUpdate));
            m.WriteU16(e + EntHitParams, 0);
            m.WriteU8(e + EntHitFlags, 0);
        }
    }

    static void CallEntity(CpuContext c, IMemory m, Action<CpuContext, IMemory>? fn, uint entity, uint addr = 0)
    {
        var snap = c.Snapshot();
        c.A0 = entity;
        if (fn != null) fn(c, m);
        else Dispatcher.Call(c, m, addr);
        c.Restore(snap);
    }

    static uint GameApiCall(CpuContext c, IMemory m, uint apiSlot, uint a0)
    {
        var snap = c.Snapshot();
        c.A0 = a0;
        Dispatcher.Call(c, m, m.ReadU32(apiSlot));
        uint ret = c.V0;
        c.Restore(snap);
        return ret;
    }
}
