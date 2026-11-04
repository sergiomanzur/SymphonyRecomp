using RecompOne.Runtime.Context;
using RecompOne.Runtime.Memory;

namespace Recompiled;

public static partial class WidescreenPatch
{
    const uint EntUnk68 = 0x68;
    const uint EntOpacity = 0x6C;
    const uint EntExtTimer = 0x7C;
    const uint FlagHasPrims = 0x800000;
    const uint FlagPosCameraLocked = 0x08000000;

    const uint PrimClut = 0x0E;
    const uint PrimTpage = 0x1A;
    const uint PrimPriority = 0x26;
    const ushort DrawColors = 4;
    const uint PrimGt4 = 4;

    const uint IntroEInitSpawner = 0x80180AD0;
    const uint IntroForegroundTrees = 0x801813DC;
    const uint IntroForegroundTreesFaded = 0x80181468;
    const uint IntroFoliage = 0x801814EC;
    const uint IntroPineUnk68 = 0x801817D4;
    const uint IntroPineWidths = 0x801817DC;
    const uint IntroPineColors = 0x801817E4;
    const uint IntroPineCluts = 0x801817E8;
    const uint IntroPineSets = 0x801817EC;
    const uint IntroDistantTrees = 0x801817F8;
    const uint IntroEntitiesStart = 0x8007C0D8;
    const uint IntroEntitiesEnd = IntroEntitiesStart + 0x2F00;
    const uint BackgroundBlock = 0x11;
    const ushort TableEnd = 0xFFFF;
    const int IntroLeftLead = 64;
    const int PineMinPrims = 32;
    const int PineMinSpacing = 0x18;

    static readonly string[] IntroNeeds =
        ["AllocEntity", "CreateEntityFromCurrentEntity", "CreateEntityFromEntity", "InitializeEntity", "DestroyEntity"];

    public static bool ForegroundTreeWideHook(CpuContext c, IMemory m) => WideExt(ForegroundTreeWide, c, m, IntroNeeds);
    public static bool FoliageMakerWideHook(CpuContext c, IMemory m) => WideExt(FoliageMakerWide, c, m, IntroNeeds);
    public static bool BackgroundPineTreesWideHook(CpuContext c, IMemory m) => WideExt(BackgroundPineTreesWide, c, m, IntroNeeds);
    public static bool DistantTreeMakerWideHook(CpuContext c, IMemory m) => WideExt(DistantTreeMakerWide, c, m, IntroNeeds);

    static int IntroScroll(IMemory m, int unk68) => (short)m.ReadU16(TilemapScrollXHi) * unk68 / 256;

    static uint SpawnBackgroundBlock(CpuContext c, IMemory m)
    {
        uint entity = CallStageRet(c, m, "AllocEntity", IntroEntitiesStart, IntroEntitiesEnd);
        if (entity != 0) CallStage(c, m, "CreateEntityFromCurrentEntity", BackgroundBlock, entity);
        return entity;
    }

    static void InitSpawner(CpuContext c, IMemory m, uint self)
    {
        CallStage(c, m, "InitializeEntity", IntroEInitSpawner);
        m.WriteU32(self + EntFlags, m.ReadU32(self + EntFlags) | FlagPosCameraLocked);
    }

    static int LeftShift(IMemory m, uint table, uint stride)
    {
        int first = m.ReadU16(table);
        for (uint i = 1;; i++)
        {
            int x = m.ReadU16(table + i * stride);
            if (x == TableEnd) return 0;
            if (x - first >= Margin + IntroLeftLead) return x - first;
        }
    }

    static void ForegroundTreeWide(CpuContext c, IMemory m)
    {
        uint self = c.A0;
        int faded = m.ReadU16(self + EntParams);
        int unk68 = faded != 0 ? 320 : 448;
        uint table = faded != 0 ? IntroForegroundTreesFaded : IntroForegroundTrees;
        int timer = m.ReadU16(self + EntExtTimer);
        uint entry = table + (uint)timer * 4;
        int extra = Margin;

        void Place(uint entity, int x, ushort packed)
        {
            m.WriteU16(entity + PedPosXHi, (ushort)x);
            m.WriteU16(entity + EntParams, (ushort)(((packed >> 8) & 0xFF) + faded));
            m.WriteU16(entity + PedPosYHi, (ushort)(packed & 0xFF));
            m.WriteU16(entity + EntUnk68, (ushort)unk68);
            if (faded != 0) m.WriteU8(entity + EntOpacity, 0x60);
        }

        switch (m.ReadU16(self + EntStep))
        {
            case 0:
                InitSpawner(c, m, self);
                m.WriteU16(self + EntUnk68, (ushort)unk68);

                int shift = LeftShift(m, table, 4);
                for (uint p = table; shift > 0 && m.ReadU16(p) - m.ReadU16(table) < shift; p += 4)
                    if (SpawnBackgroundBlock(c, m) is var copy and not 0)
                        Place(copy, m.ReadU16(p) - shift, m.ReadU16(p + 2));

                while (m.ReadU16(entry) <= 352 + extra)
                {
                    if (SpawnBackgroundBlock(c, m) is var entity and not 0)
                    {
                        Place(entity, m.ReadU16(entry), m.ReadU16(entry + 2));
                        if (faded == 0) SpawnForegroundExtra(c, m, entity, timer, unk68);
                    }
                    entry += 4;
                    timer++;
                }

                m.WriteU16(self + EntExtTimer, (ushort)timer);
                break;

            case 1:
                m.WriteU16(self + PedPosXHi, 128);
                ushort edge = (ushort)(IntroScroll(m, unk68) + 352 + extra);
                if (edge < m.ReadU16(entry)) break;

                uint spawned = SpawnBackgroundBlock(c, m);
                if (spawned != 0)
                {
                    Place(spawned, edge - m.ReadU16(entry) + 368 + extra, m.ReadU16(entry + 2));
                    if (faded == 0) SpawnForegroundExtra(c, m, spawned, timer, unk68);
                }

                m.WriteU16(self + EntExtTimer, (ushort)(timer + 1));
                break;
        }
    }

    static void SpawnForegroundExtra(CpuContext c, IMemory m, uint parent, int timer, int unk68)
    {
        (ushort Params, int Y) extra = timer switch
        {
            7 => (0x12, -16),
            10 => (0x13, 48),
            15 => (0x14, 4),
            _ => (0, 0)
        };
        if (extra.Params == 0) return;

        uint entity = CallStageRet(c, m, "AllocEntity", IntroEntitiesStart, IntroEntitiesEnd);
        if (entity == 0) return;
        CallStageRet(c, m, "CreateEntityFromEntity", BackgroundBlock, parent, entity);
        m.WriteU16(entity + EntParams, extra.Params);
        m.WriteU16(entity + PedPosYHi, (ushort)((short)m.ReadU16(entity + PedPosYHi) + extra.Y));
        m.WriteU16(entity + EntUnk68, (ushort)unk68);
        m.WriteU8(entity + EntOpacity, 0x40);
    }

    static void FoliageMakerWide(CpuContext c, IMemory m)
    {
        const int unk68 = 0xC0;
        uint self = c.A0;
        int timer = m.ReadU16(self + EntExtTimer);
        uint entry = IntroFoliage + (uint)timer * 4;
        int extra = Margin;

        void Place(uint entity, int x, ushort param)
        {
            m.WriteU16(entity + PedPosXHi, (ushort)x);
            m.WriteU16(entity + EntParams, param);
            m.WriteU16(entity + EntUnk68, unk68);
        }

        switch (m.ReadU16(self + EntStep))
        {
            case 0:
                InitSpawner(c, m, self);
                m.WriteU16(self + EntUnk68, unk68);
                timer = 0;
                entry = IntroFoliage;

                int shift = LeftShift(m, IntroFoliage, 4);
                for (uint p = IntroFoliage; shift > 0 && m.ReadU16(p) - m.ReadU16(IntroFoliage) < shift; p += 4)
                    if (SpawnBackgroundBlock(c, m) is var copy and not 0)
                        Place(copy, m.ReadU16(p) - shift, m.ReadU16(p + 2));

                while (m.ReadU16(entry) <= 288 + extra)
                {
                    if (SpawnBackgroundBlock(c, m) is var entity and not 0)
                        Place(entity, m.ReadU16(entry), m.ReadU16(entry + 2));
                    entry += 4;
                    timer++;
                }

                m.WriteU16(self + EntExtTimer, (ushort)timer);
                break;

            case 1:
                m.WriteU16(self + PedPosXHi, 128);
                ushort edge = (ushort)(IntroScroll(m, unk68) + 288 + extra);
                if (edge < m.ReadU16(entry)) break;

                uint spawned = SpawnBackgroundBlock(c, m);
                if (spawned != 0)
                {
                    Place(spawned, edge - m.ReadU16(entry) + 288 + extra, m.ReadU16(entry + 2));
                    m.WriteU16(spawned, m.ReadU16(self));
                }

                m.WriteU16(self + EntExtTimer, (ushort)(timer + 1));
                break;
        }
    }

    static void DistantTreeMakerWide(CpuContext c, IMemory m)
    {
        const int unk68 = 0x18;
        const ushort treeParams = 0x10;
        const int lastTree = 5;
        uint self = c.A0;
        int timer = m.ReadU16(self + EntExtTimer);
        uint entry = IntroDistantTrees + (uint)timer * 2;
        int extra = Margin;

        void Place(uint entity, int x, ushort param)
        {
            m.WriteU16(entity + PedPosXHi, (ushort)x);
            m.WriteU16(entity + EntParams, param);
            m.WriteU16(entity + EntUnk68, unk68);
        }

        switch (m.ReadU16(self + EntStep))
        {
            case 0:
                InitSpawner(c, m, self);
                timer = 0;
                entry = IntroDistantTrees;

                int shift = LeftShift(m, IntroDistantTrees, 2);
                for (uint p = IntroDistantTrees; shift > 0 && m.ReadU16(p) - m.ReadU16(IntroDistantTrees) < shift; p += 2)
                    if (SpawnBackgroundBlock(c, m) is var copy and not 0)
                        Place(copy, m.ReadU16(p) - shift, treeParams);

                while (m.ReadU16(entry) <= 288 + extra)
                {
                    if (SpawnBackgroundBlock(c, m) is var entity and not 0)
                        Place(entity, m.ReadU16(entry), (ushort)(timer == lastTree ? treeParams + 1 : treeParams));
                    entry += 2;
                    timer++;
                }

                m.WriteU16(self + EntExtTimer, (ushort)timer);
                break;

            case 1:
                m.WriteU16(self + PedPosXHi, 0x80);
                ushort edge = (ushort)(IntroScroll(m, unk68) + 288 + extra);
                if (edge < m.ReadU16(entry)) break;

                uint spawned = SpawnBackgroundBlock(c, m);
                if (spawned != 0)
                {
                    Place(spawned, edge - m.ReadU16(entry) + 288 + extra,
                        (ushort)(timer == lastTree ? treeParams + 1 : treeParams));
                    m.WriteU16(spawned, m.ReadU16(self));
                }

                m.WriteU16(self + EntExtTimer, (ushort)(timer + 1));
                break;
        }
    }

    static void BackgroundPineTreesWide(CpuContext c, IMemory m)
    {
        uint self = c.A0;
        int set = m.ReadU16(self + EntParams);
        int unk68 = m.ReadU16(IntroPineUnk68 + (uint)set * 2);
        int width = m.ReadU16(IntroPineWidths + (uint)set * 2);
        uint table = m.ReadU32(IntroPineSets + (uint)set * 4);
        int timer = m.ReadU16(self + EntExtTimer);
        uint entry = table + (uint)timer * 4;
        int extra = Margin;

        switch (m.ReadU16(self + EntStep))
        {
            case 0:
            {
                InitSpawner(c, m, self);
                m.WriteU16(self + EntUnk68, (ushort)unk68);

                int index = AllocPinePrims(c, m, PinePrimCount());
                if (index <= 0) index = AllocPinePrims(c, m, PineMinPrims);
                if (index <= 0)
                {
                    CallStage(c, m, "DestroyEntity", self);
                    return;
                }

                m.WriteU32(self + EntFlags, m.ReadU32(self + EntFlags) | FlagHasPrims);
                m.WriteU32(self + EntPrimIndex, (uint)index);
                uint first = PrimBufAddr + (uint)index * PrimStride;
                for (uint p = first; p != 0; p = m.ReadU32(p))
                    m.WriteU16(p + PrimDrawMode, DrawHide);

                int shift = LeftShift(m, table, 4);
                for (uint p = table; shift > 0 && m.ReadU16(p) - m.ReadU16(table) < shift; p += 4)
                    if (!PlacePine(m, first, set, width, m.ReadU16(p) - shift, m.ReadU16(p + 2)))
                        break;

                while (m.ReadU16(entry) < 0x121 + extra)
                {
                    timer++;
                    m.WriteU16(self + EntExtTimer, (ushort)timer);
                    if (!PlacePine(m, first, set, width, m.ReadU16(entry), m.ReadU16(entry + 2))) return;
                    entry += 4;
                }
                return;
            }

            case 1:
            {
                int delta = (short)(0x80 - m.ReadU16(self + PedPosXHi));
                m.WriteU16(self + PedPosXHi, 0x80);

                uint first = PrimBufAddr + m.ReadU32(self + EntPrimIndex) * PrimStride;
                for (uint p = first; p != 0; p = m.ReadU32(p))
                {
                    if (m.ReadU16(p + PrimDrawMode) == DrawHide) continue;
                    short x0 = (short)(m.ReadU16(p + 0x20) - delta);
                    short x1 = (short)(m.ReadU16(p + 0x2C) - delta);
                    m.WriteU16(p + 0x08, (ushort)x0);
                    m.WriteU16(p + 0x20, (ushort)x0);
                    m.WriteU16(p + 0x14, (ushort)x1);
                    m.WriteU16(p + 0x2C, (ushort)x1);
                    if (x1 <= ViewLeft) m.WriteU16(p + PrimDrawMode, DrawHide);
                }

                ushort edge = (ushort)(IntroScroll(m, unk68) + 0x120 + extra);
                if (edge < m.ReadU16(entry)) return;

                m.WriteU16(self + EntExtTimer, (ushort)(timer + 1));
                PlacePine(m, first, set, width, 0x120 + extra - (edge - m.ReadU16(entry)), m.ReadU16(entry + 2));
                return;
            }
        }
    }

    static int PinePrimCount()
    {
        int span = 0x120 + Margin * 2 + IntroLeftLead * 2;
        return Math.Max(PineMinPrims, (span / PineMinSpacing + 2) * 2);
    }

    static int AllocPinePrims(CpuContext c, IMemory m, int count)
    {
        var snap = c.Snapshot();
        c.A0 = PrimGt4;
        c.A1 = (uint)count;
        SoTN_dra.AllocPrimitives(c, m);
        int index = (int)c.V0;
        c.Restore(snap);
        return index;
    }

    static uint NextHidden(IMemory m, uint prim)
    {
        for (; prim != 0; prim = m.ReadU32(prim))
            if (m.ReadU16(prim + PrimDrawMode) == DrawHide)
                return prim;
        return 0;
    }

    static bool PlacePine(IMemory m, uint first, int set, int width, int x, ushort packed)
    {
        uint trunk = NextHidden(m, first);
        if (trunk == 0) return false;
        uint stem = NextHidden(m, m.ReadU32(trunk));
        if (stem == 0) return false;

        int crown = width * 20 / 256;
        Quad(m, trunk, 0xE, 0x80, 0xA8, 0x80, 0xD0, x - crown, x + crown);
        int stemWidth = width * 4 / 256;
        Quad(m, stem, 0xF, 0xB0, 0xB8, 0xC8, 0xF8, x - stemWidth + 1, x + stemWidth + 1);

        ushort clut = m.ReadU16(IntroPineCluts + (uint)((packed >> 8) & 0xFF) * 2);
        int bottom = 0x9C - (0x2C - (packed & 0xFF)) * width / 256;
        Rows(m, trunk, bottom - width * 80 / 256, bottom);
        Rows(m, stem, 0x9C - 0x30, 0x9C);

        byte color = m.ReadU8(IntroPineColors + (uint)set);
        ushort priority = (ushort)(0x3F - set * 2);
        foreach (var (prim, order) in new[] { (trunk, priority), (stem, (ushort)(priority - 1)) })
        {
            m.WriteU16(prim + PrimClut, clut);
            foreach (uint corner in new uint[] { 0x04, 0x10, 0x1C, 0x28 })
            {
                m.WriteU8(prim + corner, color);
                m.WriteU8(prim + corner + 1, color);
                m.WriteU8(prim + corner + 2, color);
            }
            m.WriteU16(prim + PrimPriority, order);
            m.WriteU16(prim + PrimDrawMode, DrawColors);
        }
        return true;
    }

    static void Quad(IMemory m, uint prim, ushort tpage, byte u0, byte u1, byte v0, byte v1, int x0, int x1)
    {
        m.WriteU16(prim + PrimTpage, tpage);
        m.WriteU8(prim + 0x0C, u0);
        m.WriteU8(prim + 0x24, u0);
        m.WriteU8(prim + 0x18, u1);
        m.WriteU8(prim + 0x30, u1);
        m.WriteU8(prim + 0x0D, v0);
        m.WriteU8(prim + 0x19, v0);
        m.WriteU8(prim + 0x25, v1);
        m.WriteU8(prim + 0x31, v1);
        m.WriteU16(prim + 0x08, (ushort)x0);
        m.WriteU16(prim + 0x20, (ushort)x0);
        m.WriteU16(prim + 0x14, (ushort)x1);
        m.WriteU16(prim + 0x2C, (ushort)x1);
    }

    static void Rows(IMemory m, uint prim, int top, int bottom)
    {
        m.WriteU16(prim + 0x0A, (ushort)top);
        m.WriteU16(prim + 0x16, (ushort)top);
        m.WriteU16(prim + 0x22, (ushort)bottom);
        m.WriteU16(prim + 0x2E, (ushort)bottom);
    }
}
