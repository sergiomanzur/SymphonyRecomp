using RecompOne.Runtime.Context;
using RecompOne.Runtime.Dispatch;
using RecompOne.Runtime.Memory;

namespace Recompiled;

public static partial class WidescreenPatch //for both underground cave, reverse, and scyla boss
{
    const uint WaterAllocPrimitives = 0x8003C7B8;
    const uint WaterPrimBase = 0x80086FEC;
    const uint WaterPrimStride = 0x34;
    const uint WaterScrollXHi = 0x8007308E;
    const uint WaterScrollYHi = 0x80073092;

    //this is a "generic" method that draws it wide, have to reroute draing to here!!
    static void WaterBodyWide(CpuContext c, IMemory m, uint animSet, uint table, uint r, uint g, uint b, uint priority, bool ySwapped, Action<CpuContext, IMemory> init, Action<CpuContext, IMemory> destroy)
    {
        int adj = System.Math.Max(0, StageMargin() - 0x10);
        uint self = c.A0;

        if (m.ReadU16(self + 0x2Cu) == 0)
        {
            var snap = c.Snapshot();
            c.A0 = animSet;
            init(c, m);
            c.Restore(snap);

            m.WriteU16(self + 0x54u, 0);
            m.WriteU16(self + 0x80u, 4);

            snap = c.Snapshot();
            c.A0 = 1u;
            c.A1 = 0x10u;
            Dispatcher.Call(c, m, m.ReadU32(WaterAllocPrimitives));
            int index = (short)c.V0;
            c.Restore(snap);

            if (index == -1)
            {
                snap = c.Snapshot();
                c.A0 = self;
                destroy(c, m);
                c.Restore(snap);
                return;
            }

            uint head = WaterPrimBase + (uint)index * WaterPrimStride;
            m.WriteU32(self + 0x64u, (uint)index);
            m.WriteU32(self + 0x7Cu, head);
            m.WriteU32(self + 0x34u, m.ReadU32(self + 0x34u) | 0x00800000u);

            for (uint q = head; q != 0; q = m.ReadU32(q))
            {
                m.WriteU8(q + 0x4u, (byte)r);
                m.WriteU8(q + 0x5u, (byte)g);
                m.WriteU8(q + 0x6u, (byte)b);
                m.WriteU16(q + 0x26u, (ushort)priority);
            }
        }

        uint ptr = table + (uint)(m.ReadU8(self + 0x30u) * 8);
        uint p = m.ReadU32(self + 0x7Cu);
        int count = m.ReadU16(self + 0x30u) >> 8;

        int scrollX = (short)m.ReadU16(WaterScrollXHi);
        int scrollY = (short)m.ReadU16(WaterScrollYHi);
        int left = scrollX - 0x10;
        int top = scrollY - 0x10;
        int right = scrollX + 0x110;
        int bottom = scrollY + 0xF0;
        int wideLeft = left - adj;
        int wideRight = right + adj;

        for (; count > 0; count--)
        {
            int x0 = (short)m.ReadU16(ptr); ptr += 2;
            int x1 = x0 + (short)m.ReadU16(ptr); ptr += 2;
            int ya = (short)m.ReadU16(ptr); ptr += 2;
            int yb = (short)m.ReadU16(ptr); ptr += 2;
            int y0 = ySwapped ? yb : ya;
            int y1 = ySwapped ? ya : yb;

            if (wideLeft >= x1 || wideRight < x0) continue;
            if (top >= y1 || bottom < y0) continue;

            if (x0 < wideLeft) x0 = wideLeft;
            if (x1 > wideRight) x1 = wideRight;
            int w = x1 - x0;
            int px = x0 - 0x10 - left;

            if (y0 < top) y0 = top;
            if (y1 > bottom) y1 = bottom;
            int h = y1 - y0;
            int py = y0 - 0x10 - top;
            if (h >= 0x100) h = 0xFF;

            while (w != 0)
            {
                if (p == 0) return;
                int seg = w >= 0x100 ? 0xFF : w;
                m.WriteU16(p + 0x8u, (ushort)px);
                m.WriteU16(p + 0xAu, (ushort)py);
                m.WriteU8(p + 0xCu, (byte)seg);
                m.WriteU8(p + 0xDu, (byte)h);
                m.WriteU16(p + 0x32u, 0x13);
                px += seg;
                w -= seg;
                p = m.ReadU32(p);
            }
        }

        for (; p != 0; p = m.ReadU32(p))
            m.WriteU16(p + 0x32u, 8);
    }

    public static void WaterBody801C15F8Wide_no4(CpuContext c, IMemory m)
        => WaterBodyWide(c, m, 0x80180BBCu, 0x8018124Cu, 0x00, 0x10, 0x20, 0x9D, false,
            SoTN_no4.InitializeEntity_no4, SoTN_no4.DestroyEntity_no4);

    public static void WaterBody801C5118Wide_rno4(CpuContext c, IMemory m)
        => WaterBodyWide(c, m, 0x80180B0Cu, 0x80181190u, 0x10, 0x08, 0x18, 0x9D, true,
            SoTN_rno4.RNO4_InitializeEntity, SoTN_rno4.DestroyEntity_rno4);

    public static void WaterBody8019D51CWide_bo3(CpuContext c, IMemory m)
        => WaterBodyWide(c, m, 0x80180564u, 0x8018092Cu, 0x00, 0x10, 0x20, 0x9B, false,SoTN_bo3.BO3_InitializeEntity, SoTN_bo3.DestroyEntity_bo3);

    public static void WaterSurface801C4DD0Wide_rno4(CpuContext c, IMemory m)
    {
        int adj = System.Math.Max(0, StageMargin() - 0x10);
        c.SP = c.SP - 0x20u;
        m.WriteU32((c.SP + 0x14u), c.S1);
        c.S1 = c.A0 + 0u;
        m.WriteU32((c.SP + 0x1Cu), c.RA);
        m.WriteU32((c.SP + 0x18u), c.S2);
        m.WriteU32((c.SP + 0x10u), c.S0);
        c.V0 = m.ReadU16((c.S1 + 0x2Cu));
        if (c.V0 != 0u) {
            goto L801C4EBC;
        }
        c.A0 = 0x80180000u;
        c.A0 = c.A0 + 0xB0Cu;
        c.RA = 0x801C4E08u;
        SoTN_rno4.RNO4_InitializeEntity(c, m);
        c.A0 = 0u | 0x0004u;
        c.V0 = 0u | 0x0004u;
        m.WriteU16((c.S1 + 0x54u), (ushort)0u);
        m.WriteU16((c.S1 + 0x80u), (ushort)c.V0);
        c.V0 = 0x80040000u;
        c.V0 = m.ReadU32((c.V0 - 0x3848u));
        c.A1 = 0u | 0x0010u;
        c.RA = 0x801C4E2Cu;
        Dispatcher.Call(c, m, c.V0);
        c.V0 = c.V0 << 16;
        c.A0 = (uint)((int)c.V0 >> 16);
        c.V0 = 0xFFFFFFFFu;
        if (c.A0 != c.V0) {
            c.V0 = c.A0 << 1;
            goto L801C4E50;
        }
        c.V0 = c.A0 << 1;
        c.A0 = c.S1 + 0u;
        c.RA = 0x801C4E48u;
        SoTN_rno4.DestroyEntity_rno4(c, m);
        goto L801C50FC;
        L801C4E50: ;
        c.V0 = c.V0 + c.A0;
        c.V0 = c.V0 << 2;
        c.V0 = c.V0 + c.A0;
        c.V0 = c.V0 << 2;
        c.V1 = 0x80080000u;
        c.V1 = c.V1 + 0x6FECu;
        c.S0 = c.V0 + c.V1;
        c.V0 = m.ReadU32((c.S1 + 0x34u));
        c.V1 = 0x00800000u;
        m.WriteU32((c.S1 + 0x64u), c.A0);
        m.WriteU32((c.S1 + 0x7Cu), c.S0);
        m.WriteU16((c.S1 + 0x82u), (ushort)0u);
        c.V0 = c.V0 | c.V1;
        if (c.S0 == 0u) {
            m.WriteU32((c.S1 + 0x34u), c.V0);
            goto L801C4EBC;
        }
        m.WriteU32((c.S1 + 0x34u), c.V0);
        c.A1 = 0u | 0x000Fu;
        c.A0 = 0u | 0x005Eu;
        c.V1 = 0u | 0x009Eu;
        c.V0 = 0u | 0x0008u;
        L801C4E9C: ;
        m.WriteU16((c.S0 + 0x1Au), (ushort)c.A1);
        m.WriteU16((c.S0 + 0xEu), (ushort)c.A0);
        m.WriteU16((c.S0 + 0x26u), (ushort)c.V1);
        m.WriteU16((c.S0 + 0x32u), (ushort)c.V0);
        c.S0 = m.ReadU32(c.S0);
        if (c.S0 != 0u) {
            goto L801C4E9C;
        }
        L801C4EBC: ;
        c.A0 = 0x80180000u;
        c.A0 = c.A0 + 0x1088u;
        c.S0 = m.ReadU32((c.S1 + 0x7Cu));
        c.A1 = c.S1 + 0u;
        c.RA = 0x801C4ED0u;
        SoTN_rno4.RNO4_AnimateEntity(c, m);
        c.V0 = m.ReadU16((c.S1 + 0x30u));
        c.V1 = m.ReadU8((c.S1 + 0x30u));
        c.A0 = 0x80070000u;
        c.A0 = (uint)(short)m.ReadU16((c.A0 + 0x308Eu));
        c.T7 = 0x80070000u;
        c.T7 = (uint)(short)m.ReadU16((c.T7 + 0x3092u));
        c.T4 = c.V0 >> 8;
        c.V0 = c.V1 << 2;
        c.V0 = c.V0 + c.V1;
        c.V0 = c.V0 << 1;
        c.V1 = 0x80180000u;
        c.V1 = c.V1 + 0x1094u;
        c.A2 = c.V0 + c.V1;
        c.T3 = c.A0 - 0x10u;
        c.V0 = (uint)(short)m.ReadU16((c.S1 + 0x56u));
        c.V1 = 0x80180000u;
        c.V1 = c.V1 + 0x1070u;
        c.V0 = c.V0 << 2;
        c.T2 = c.V0 + c.V1;
        c.V0 = m.ReadU8((c.T2 + 0x1u));
        if ((int)c.T4 <= 0) {
            c.T8 = (uint)((int)c.A0 + 0x110 + adj);
            goto L801C50E0;
        }
        c.T8 = (uint)((int)c.A0 + 0x110 + adj);
        c.T9 = 0x82080000u;
        c.T9 = c.T9 | 0x2083u;
        c.S2 = 0u | 0x007Eu;
        c.T6 = c.V0 + 0u;
        c.T5 = c.V0 + 0x1u;
        L801C4F3C: ;
        c.A1 = (uint)(short)m.ReadU16(c.A2);
        c.A2 = c.A2 + 0x2u;
        c.V0 = (uint)(short)m.ReadU16(c.A2);
        c.A3 = c.A1 + c.V0;
        c.V0 = (int)c.T3 < (int)c.A3 ? 1u : 0u;
        if (c.V0 == 0u) {
            c.A2 = c.A2 + 0x2u;
            goto L801C4F68;
        }
        c.A2 = c.A2 + 0x2u;
        c.V0 = (int)c.T8 < (int)c.A1 ? 1u : 0u;
        if (c.V0 == 0u) {
            c.V0 = c.T7 - 0x4u;
            goto L801C4F70;
        }
        c.V0 = c.T7 - 0x4u;
        L801C4F68: ;
        c.A2 = c.A2 + 0x6u;
        goto L801C50D4;
        L801C4F70: ;
        c.T0 = (uint)(short)m.ReadU16(c.A2);
        c.V0 = (int)c.T0 < (int)c.V0 ? 1u : 0u;
        if (c.V0 != 0u) {
            c.A2 = c.A2 + 0x2u;
            goto L801C4F94;
        }
        c.A2 = c.A2 + 0x2u;
        c.V0 = c.T7 + 0xE0u;
        c.V0 = (int)c.V0 < (int)c.T0 ? 1u : 0u;
        if (c.V0 == 0u) {
            c.V0 = (int)c.A1 < ((int)c.T3 - adj) ? 1u : 0u;
            goto L801C4F9C;
        }
        c.V0 = (int)c.A1 < ((int)c.T3 - adj) ? 1u : 0u;
        L801C4F94: ;
        c.A2 = c.A2 + 0x4u;
        goto L801C50D4;
        L801C4F9C: ;
        c.A2 = c.A2 + 0x2u;
        c.A0 = (uint)(short)m.ReadU16(c.A2);
        c.A2 = c.A2 + 0x2u;
        if (c.V0 == 0u) {
            c.T0 = c.T0 - c.T7;
            goto L801C4FB4;
        }
        c.T0 = c.T0 - c.T7;
        c.A1 = (uint)((int)c.T3 - adj);
        L801C4FB4: ;
        c.V0 = (int)c.T8 < (int)c.A3 ? 1u : 0u;
        if (c.V0 == 0u) {
            goto L801C4FC4;
        }
        c.A3 = c.T8 + 0u;
        L801C4FC4: ;
        if (c.A0 == 0u) {
            c.V0 = c.A1 >> 1;
            goto L801C500C;
        }
        c.V0 = c.A1 >> 1;
        c.V1 = m.ReadU16((c.S1 + 0x82u));
        c.V1 = c.V1 + c.A0;
        c.A0 = c.V1 << 16;
        c.A0 = (uint)((int)c.A0 >> 16);
        c.A0 = c.A1 - c.A0;
        c.V0 = c.A0 >> 1;
        { var _r = (ulong)c.V0 * c.T9; c.LO = (uint)_r; c.HI = (uint)(_r >> 32); }
        m.WriteU16((c.S1 + 0x82u), (ushort)c.V1);
        c.V0 = c.HI;
        c.V1 = c.V0 >> 5;
        c.V0 = c.V1 << 6;
        c.V0 = c.V0 - c.V1;
        c.V0 = c.V0 << 1;
        c.V1 = c.A0 - c.V0;
        goto L801C5028;
        L801C500C: ;
        { var _r = (ulong)c.V0 * c.T9; c.LO = (uint)_r; c.HI = (uint)(_r >> 32); }
        c.V0 = c.HI;
        c.V1 = c.V0 >> 5;
        c.V0 = c.V1 << 6;
        c.V0 = c.V0 - c.V1;
        c.V0 = c.V0 << 1;
        c.V1 = c.A1 - c.V0;
        L801C5028: ;
        c.A3 = c.A3 - c.A1;
        c.V0 = c.A1 - 0x10u;
        c.A1 = c.V0 - c.T3;
        c.T1 = c.T0 + 0u;
        c.V0 = m.ReadU8(c.T2);
        c.T0 = c.T0 + 0x1u;
        c.V1 = c.V1 + c.V0;
        c.V0 = c.V1 + 0u;
        L801C5048: ;
        m.WriteU8((c.S0 + 0x24u), (byte)c.V0);
        m.WriteU8((c.S0 + 0xCu), (byte)c.V0);
        c.V0 = m.ReadU8(c.T2);
        c.V0 = c.V1 - c.V0;
        c.A0 = c.S2 - c.V0;
        c.V0 = (int)c.A3 < (int)c.A0 ? 1u : 0u;
        if (c.V0 == 0u) {
            c.V0 = c.V1 + c.A0;
            goto L801C5074;
        }
        c.V0 = c.V1 + c.A0;
        c.A0 = c.A3 + 0u;
        c.V0 = c.V1 + c.A0;
        L801C5074: ;
        c.V1 = c.A1 + 0u;
        c.A1 = c.A1 + c.A0;
        m.WriteU8((c.S0 + 0x30u), (byte)c.V0);
        m.WriteU8((c.S0 + 0x18u), (byte)c.V0);
        c.V0 = c.A1 + 0u;
        c.A3 = c.A3 - c.A0;
        m.WriteU8((c.S0 + 0x19u), (byte)c.T6);
        m.WriteU8((c.S0 + 0xDu), (byte)c.T6);
        m.WriteU8((c.S0 + 0x31u), (byte)c.T5);
        m.WriteU8((c.S0 + 0x25u), (byte)c.T5);
        m.WriteU16((c.S0 + 0x20u), (ushort)c.V1);
        m.WriteU16((c.S0 + 0x8u), (ushort)c.V1);
        m.WriteU16((c.S0 + 0x2Cu), (ushort)c.V0);
        m.WriteU16((c.S0 + 0x14u), (ushort)c.V0);
        c.V1 = m.ReadU8(c.T2);
        c.V0 = 0u | 0x0013u;
        m.WriteU16((c.S0 + 0x16u), (ushort)c.T1);
        m.WriteU16((c.S0 + 0xAu), (ushort)c.T1);
        m.WriteU16((c.S0 + 0x2Eu), (ushort)c.T0);
        m.WriteU16((c.S0 + 0x22u), (ushort)c.T0);
        m.WriteU16((c.S0 + 0x32u), (ushort)c.V0);
        c.S0 = m.ReadU32(c.S0);
        if (c.A3 != 0u) {
            c.V0 = c.V1 + 0u;
            goto L801C5048;
        }
        c.V0 = c.V1 + 0u;
        L801C50D4: ;
        c.T4 = c.T4 - 0x1u;
        if ((int)c.T4 > 0) {
            goto L801C4F3C;
        }
        L801C50E0: ;
        if (c.S0 == 0u) {
            c.V0 = 0u | 0x0008u;
            goto L801C50FC;
        }
        c.V0 = 0u | 0x0008u;
        L801C50E8: ;
        m.WriteU16((c.S0 + 0x32u), (ushort)c.V0);
        c.S0 = m.ReadU32(c.S0);
        if (c.S0 != 0u) {
            goto L801C50E8;
        }
        L801C50FC: ;
        c.RA = m.ReadU32((c.SP + 0x1Cu));
        c.S2 = m.ReadU32((c.SP + 0x18u));
        c.S1 = m.ReadU32((c.SP + 0x14u));
        c.S0 = m.ReadU32((c.SP + 0x10u));
        c.SP = c.SP + 0x20u;
        return;
    }

    public static void WaterSurface8019D1D4Wide_bo3(CpuContext c, IMemory m)
    {
        int adj = System.Math.Max(0, StageMargin() - 0x10);
        c.SP = c.SP - 0x20u;
        m.WriteU32((c.SP + 0x14u), c.S1);
        c.S1 = c.A0 + 0u;
        m.WriteU32((c.SP + 0x1Cu), c.RA);
        m.WriteU32((c.SP + 0x18u), c.S2);
        m.WriteU32((c.SP + 0x10u), c.S0);
        c.V0 = m.ReadU16((c.S1 + 0x2Cu));
        if (c.V0 != 0u) {
            goto L8019D2C0;
        }
        c.A0 = 0x80180000u;
        c.A0 = c.A0 + 0x564u;
        c.RA = 0x8019D20Cu;
        SoTN_bo3.BO3_InitializeEntity(c, m);
        c.A0 = 0u | 0x0004u;
        c.V0 = 0u | 0x0004u;
        m.WriteU16((c.S1 + 0x54u), (ushort)0u);
        m.WriteU16((c.S1 + 0x80u), (ushort)c.V0);
        c.V0 = 0x80040000u;
        c.V0 = m.ReadU32((c.V0 - 0x3848u));
        c.A1 = 0u | 0x0010u;
        c.RA = 0x8019D230u;
        Dispatcher.Call(c, m, c.V0);
        c.V0 = c.V0 << 16;
        c.A0 = (uint)((int)c.V0 >> 16);
        c.V0 = 0xFFFFFFFFu;
        if (c.A0 != c.V0) {
            c.V0 = c.A0 << 1;
            goto L8019D254;
        }
        c.V0 = c.A0 << 1;
        c.A0 = c.S1 + 0u;
        c.RA = 0x8019D24Cu;
        SoTN_bo3.DestroyEntity_bo3(c, m);
        goto L8019D500;
        L8019D254: ;
        c.V0 = c.V0 + c.A0;
        c.V0 = c.V0 << 2;
        c.V0 = c.V0 + c.A0;
        c.V0 = c.V0 << 2;
        c.V1 = 0x80080000u;
        c.V1 = c.V1 + 0x6FECu;
        c.S0 = c.V0 + c.V1;
        c.V0 = m.ReadU32((c.S1 + 0x34u));
        c.V1 = 0x00800000u;
        m.WriteU32((c.S1 + 0x64u), c.A0);
        m.WriteU32((c.S1 + 0x7Cu), c.S0);
        m.WriteU16((c.S1 + 0x82u), (ushort)0u);
        c.V0 = c.V0 | c.V1;
        if (c.S0 == 0u) {
            m.WriteU32((c.S1 + 0x34u), c.V0);
            goto L8019D2C0;
        }
        m.WriteU32((c.S1 + 0x34u), c.V0);
        c.A1 = 0u | 0x000Fu;
        c.A0 = 0u | 0x005Eu;
        c.V1 = 0u | 0x009Cu;
        c.V0 = 0u | 0x0008u;
        L8019D2A0: ;
        m.WriteU16((c.S0 + 0x1Au), (ushort)c.A1);
        m.WriteU16((c.S0 + 0xEu), (ushort)c.A0);
        m.WriteU16((c.S0 + 0x26u), (ushort)c.V1);
        m.WriteU16((c.S0 + 0x32u), (ushort)c.V0);
        c.S0 = m.ReadU32(c.S0);
        if (c.S0 != 0u) {
            goto L8019D2A0;
        }
        L8019D2C0: ;
        c.A0 = 0x80180000u;
        c.A0 = c.A0 + 0x824u;
        c.S0 = m.ReadU32((c.S1 + 0x7Cu));
        c.A1 = c.S1 + 0u;
        c.RA = 0x8019D2D4u;
        SoTN_bo3.BO3_AnimateEntity(c, m);
        c.V0 = m.ReadU16((c.S1 + 0x30u));
        c.V1 = m.ReadU8((c.S1 + 0x30u));
        c.A0 = 0x80070000u;
        c.A0 = (uint)(short)m.ReadU16((c.A0 + 0x308Eu));
        c.T7 = 0x80070000u;
        c.T7 = (uint)(short)m.ReadU16((c.T7 + 0x3092u));
        c.T4 = c.V0 >> 8;
        c.V0 = c.V1 << 2;
        c.V0 = c.V0 + c.V1;
        c.V0 = c.V0 << 1;
        c.V1 = 0x80180000u;
        c.V1 = c.V1 + 0x830u;
        c.A2 = c.V0 + c.V1;
        c.T3 = c.A0 - 0x10u;
        c.V0 = (uint)(short)m.ReadU16((c.S1 + 0x56u));
        c.V1 = 0x80180000u;
        c.V1 = c.V1 + 0x80Cu;
        c.V0 = c.V0 << 2;
        c.T2 = c.V0 + c.V1;
        c.V0 = m.ReadU8((c.T2 + 0x1u));
        if ((int)c.T4 <= 0) {
            c.T8 = (uint)((int)c.A0 + 0x110 + adj);
            goto L8019D4E4;
        }
        c.T8 = (uint)((int)c.A0 + 0x110 + adj);
        c.T9 = 0x82080000u;
        c.T9 = c.T9 | 0x2083u;
        c.S2 = 0u | 0x007Eu;
        c.T6 = c.V0 + 0u;
        c.T5 = c.V0 + 0x1u;
        L8019D340: ;
        c.A1 = (uint)(short)m.ReadU16(c.A2);
        c.A2 = c.A2 + 0x2u;
        c.V0 = (uint)(short)m.ReadU16(c.A2);
        c.A3 = c.A1 + c.V0;
        c.V0 = (int)c.T3 < (int)c.A3 ? 1u : 0u;
        if (c.V0 == 0u) {
            c.A2 = c.A2 + 0x2u;
            goto L8019D36C;
        }
        c.A2 = c.A2 + 0x2u;
        c.V0 = (int)c.T8 < (int)c.A1 ? 1u : 0u;
        if (c.V0 == 0u) {
            c.V0 = c.T7 - 0x4u;
            goto L8019D374;
        }
        c.V0 = c.T7 - 0x4u;
        L8019D36C: ;
        c.A2 = c.A2 + 0x6u;
        goto L8019D4D8;
        L8019D374: ;
        c.T0 = (uint)(short)m.ReadU16(c.A2);
        c.V0 = (int)c.T0 < (int)c.V0 ? 1u : 0u;
        if (c.V0 != 0u) {
            c.A2 = c.A2 + 0x2u;
            goto L8019D398;
        }
        c.A2 = c.A2 + 0x2u;
        c.V0 = c.T7 + 0xE0u;
        c.V0 = (int)c.V0 < (int)c.T0 ? 1u : 0u;
        if (c.V0 == 0u) {
            c.V0 = (int)c.A1 < ((int)c.T3 - adj) ? 1u : 0u;
            goto L8019D3A0;
        }
        c.V0 = (int)c.A1 < ((int)c.T3 - adj) ? 1u : 0u;
        L8019D398: ;
        c.A2 = c.A2 + 0x4u;
        goto L8019D4D8;
        L8019D3A0: ;
        c.A2 = c.A2 + 0x2u;
        c.A0 = (uint)(short)m.ReadU16(c.A2);
        c.A2 = c.A2 + 0x2u;
        if (c.V0 == 0u) {
            c.T0 = c.T0 - c.T7;
            goto L8019D3B8;
        }
        c.T0 = c.T0 - c.T7;
        c.A1 = (uint)((int)c.T3 - adj);
        L8019D3B8: ;
        c.V0 = (int)c.T8 < (int)c.A3 ? 1u : 0u;
        if (c.V0 == 0u) {
            goto L8019D3C8;
        }
        c.A3 = c.T8 + 0u;
        L8019D3C8: ;
        if (c.A0 == 0u) {
            c.V0 = c.A1 >> 1;
            goto L8019D410;
        }
        c.V0 = c.A1 >> 1;
        c.V1 = m.ReadU16((c.S1 + 0x82u));
        c.V1 = c.V1 + c.A0;
        c.A0 = c.V1 << 16;
        c.A0 = (uint)((int)c.A0 >> 16);
        c.A0 = c.A1 - c.A0;
        c.V0 = c.A0 >> 1;
        { var _r = (ulong)c.V0 * c.T9; c.LO = (uint)_r; c.HI = (uint)(_r >> 32); }
        m.WriteU16((c.S1 + 0x82u), (ushort)c.V1);
        c.V0 = c.HI;
        c.V1 = c.V0 >> 5;
        c.V0 = c.V1 << 6;
        c.V0 = c.V0 - c.V1;
        c.V0 = c.V0 << 1;
        c.V1 = c.A0 - c.V0;
        goto L8019D42C;
        L8019D410: ;
        { var _r = (ulong)c.V0 * c.T9; c.LO = (uint)_r; c.HI = (uint)(_r >> 32); }
        c.V0 = c.HI;
        c.V1 = c.V0 >> 5;
        c.V0 = c.V1 << 6;
        c.V0 = c.V0 - c.V1;
        c.V0 = c.V0 << 1;
        c.V1 = c.A1 - c.V0;
        L8019D42C: ;
        c.A3 = c.A3 - c.A1;
        c.V0 = c.A1 - 0x10u;
        c.A1 = c.V0 - c.T3;
        c.T1 = c.T0 + 0u;
        c.V0 = m.ReadU8(c.T2);
        c.T0 = c.T0 + 0x1u;
        c.V1 = c.V1 + c.V0;
        c.V0 = c.V1 + 0u;
        L8019D44C: ;
        m.WriteU8((c.S0 + 0x24u), (byte)c.V0);
        m.WriteU8((c.S0 + 0xCu), (byte)c.V0);
        c.V0 = m.ReadU8(c.T2);
        c.V0 = c.V1 - c.V0;
        c.A0 = c.S2 - c.V0;
        c.V0 = (int)c.A3 < (int)c.A0 ? 1u : 0u;
        if (c.V0 == 0u) {
            c.V0 = c.V1 + c.A0;
            goto L8019D478;
        }
        c.V0 = c.V1 + c.A0;
        c.A0 = c.A3 + 0u;
        c.V0 = c.V1 + c.A0;
        L8019D478: ;
        c.V1 = c.A1 + 0u;
        c.A1 = c.A1 + c.A0;
        m.WriteU8((c.S0 + 0x30u), (byte)c.V0);
        m.WriteU8((c.S0 + 0x18u), (byte)c.V0);
        c.V0 = c.A1 + 0u;
        c.A3 = c.A3 - c.A0;
        m.WriteU8((c.S0 + 0x19u), (byte)c.T6);
        m.WriteU8((c.S0 + 0xDu), (byte)c.T6);
        m.WriteU8((c.S0 + 0x31u), (byte)c.T5);
        m.WriteU8((c.S0 + 0x25u), (byte)c.T5);
        m.WriteU16((c.S0 + 0x20u), (ushort)c.V1);
        m.WriteU16((c.S0 + 0x8u), (ushort)c.V1);
        m.WriteU16((c.S0 + 0x2Cu), (ushort)c.V0);
        m.WriteU16((c.S0 + 0x14u), (ushort)c.V0);
        c.V1 = m.ReadU8(c.T2);
        c.V0 = 0u | 0x0013u;
        m.WriteU16((c.S0 + 0x16u), (ushort)c.T1);
        m.WriteU16((c.S0 + 0xAu), (ushort)c.T1);
        m.WriteU16((c.S0 + 0x2Eu), (ushort)c.T0);
        m.WriteU16((c.S0 + 0x22u), (ushort)c.T0);
        m.WriteU16((c.S0 + 0x32u), (ushort)c.V0);
        c.S0 = m.ReadU32(c.S0);
        if (c.A3 != 0u) {
            c.V0 = c.V1 + 0u;
            goto L8019D44C;
        }
        c.V0 = c.V1 + 0u;
        L8019D4D8: ;
        c.T4 = c.T4 - 0x1u;
        if ((int)c.T4 > 0) {
            goto L8019D340;
        }
        L8019D4E4: ;
        if (c.S0 == 0u) {
            c.V0 = 0u | 0x0008u;
            goto L8019D500;
        }
        c.V0 = 0u | 0x0008u;
        L8019D4EC: ;
        m.WriteU16((c.S0 + 0x32u), (ushort)c.V0);
        c.S0 = m.ReadU32(c.S0);
        if (c.S0 != 0u) {
            goto L8019D4EC;
        }
        L8019D500: ;
        c.RA = m.ReadU32((c.SP + 0x1Cu));
        c.S2 = m.ReadU32((c.SP + 0x18u));
        c.S1 = m.ReadU32((c.SP + 0x14u));
        c.S0 = m.ReadU32((c.SP + 0x10u));
        c.SP = c.SP + 0x20u;
        return;
    }
}
