using RecompOne.Runtime.Context;
using RecompOne.Runtime.Memory;

namespace Recompiled;

//spawning reimplementation. indstead of old hacky way, doing the proper reimplementation, so no more popping ;3
public static partial class WidescreenPatch
{
    const uint ScrollDeltaX = 0x80097908; //from dec ref
    const uint ScrollDeltaY = 0x8009790C;

    const uint StageEntities = 0x800762D8;
    const int EntitySize = 0xBC;
    const int EntityIdOffset = 0x26;

    const int LayoutPosX = 0;
    const int LayoutPosY = 2;
    const int LayoutEntityId = 4;
    const int LayoutRoomIndex = 6;

    const int SpawnSlackLeft = 0x40;
    const int SpawnSlackRight = 0x140;
    const int SpawnSlackDown = 0x40;
    const int SpawnSlackUp = 0x120;

    static bool _dedupActive;
    static int _dedupLo, _dedupHi;

    static int ScrollX(IMemory m) => (short)m.ReadU16(TilemapScrollXHi);
    static int ScrollY(IMemory m) => (short)m.ReadU16(TmScrollYHi);

    static void SpawnFromLayout(CpuContext c, IMemory m, uint obj, int posX)
    {
        if (_dedupActive && posX >= _dedupLo && posX <= _dedupHi) return;

        ushort entityId = m.ReadU16(obj + LayoutEntityId);
        int kind = entityId & 0xE000;
        if (kind == 0x8000) return;
        if (kind != 0x0000 && kind != 0xA000) return;

        uint entity = StageEntities + (uint)((m.ReadU16(obj + LayoutRoomIndex) & 0xFF) * EntitySize);
        if (kind == 0x0000 && m.ReadU16(entity + EntityIdOffset) != 0) return;

        var fn = StageFn(m, "CreateEntityFromLayout");
        if (fn == null) return;

        var snap = c.Snapshot();
        c.A0 = entity;
        c.A1 = obj;
        fn(c, m);
        c.Restore(snap);
    }

    public static void CreateEntityWhenInHorizontalRange(CpuContext c, IMemory m)
    {
        uint obj = c.A0;
        int scroll = ScrollX(m);

        short close = (short)(scroll - SpawnSlackLeft - Margin);
        short far = (short)(scroll + SpawnSlackRight + Margin);
        if (close < 0) close = 0;

        short posX = (short)m.ReadU16(obj + LayoutPosX);
        if (posX < close || posX > far) return;

        SpawnFromLayout(c, m, obj, posX);
    }

    public static void CreateEntityWhenInVerticalRange(CpuContext c, IMemory m)
    {
        uint obj = c.A0;
        int scroll = ScrollY(m);

        short close = (short)(scroll - SpawnSlackDown);
        short far = (short)(scroll + SpawnSlackUp);
        if (close < 0) close = 0;

        short posY = (short)m.ReadU16(obj + LayoutPosY);
        if (posY < close || posY > far) return;

        SpawnFromLayout(c, m, obj, (short)m.ReadU16(obj + LayoutPosX));
    }

    public static void UpdateRoomPosition(CpuContext c, IMemory m)
    {
        int deltaX = (int)m.ReadU32(ScrollDeltaX);
        if (deltaX != 0)
        {
            int scroll = ScrollX(m);
            if (deltaX > 0)
                CallStage(c, m, "CreateEntitiesToTheRight", (uint)(short)(scroll + SpawnSlackRight + Margin));
            else
                CallStage(c, m, "CreateEntitiesToTheLeft", (uint)(short)(scroll - SpawnSlackLeft - Margin));
        }

        int deltaY = (int)m.ReadU32(ScrollDeltaY);
        if (deltaY != 0)
        {
            int scroll = ScrollY(m);
            if (deltaY > 0)
                CallStage(c, m, "CreateEntitiesAbove", (uint)(short)(scroll + 288));
            else
                CallStage(c, m, "CreateEntitiesBelow", (uint)(short)(scroll - 64));
        }
    }

    public static void PostInitRoomEntities(CpuContext c, IMemory m)
    {
        if (!Extended) return;
        if (!StageHas(m, "FindFirstEntityToTheLeft", "FindFirstEntityToTheRight", "CreateEntitiesToTheRight")) return;

        int scroll = ScrollX(m);
        int target = scroll - SpawnSlackLeft - Margin;
        if (target < 0) target = 0;

        CallStage(c, m, "FindFirstEntityToTheLeft", (uint)(short)target);
        CallStage(c, m, "FindFirstEntityToTheRight", (uint)(short)target);

        _dedupLo = Math.Max(0, scroll - SpawnSlackLeft);
        _dedupHi = scroll + SpawnSlackRight;
        _dedupActive = true;
        CallStage(c, m, "CreateEntitiesToTheRight", (uint)(short)(scroll + SpawnSlackRight + Margin));
        _dedupActive = false;
    }
}
