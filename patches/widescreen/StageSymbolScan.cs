using RecompOne.Runtime.Memory;

namespace Recompiled;

//bss searching, its stupid but work, TODO: revisit in future to find a better method of doing this
public static partial class WidescreenPatch
{
    static uint _symKey;
    static uint _itemIconSlots, _invincibility;

    static bool StageUpdateSymbols(IMemory m, out uint iconSlots, out uint invincibility)
    {
        var (fn, addr) = StageSym(m, "Update");
        if (fn == null || addr == 0)
        {
            iconSlots = invincibility = 0;
            return false;
        }

        if (addr != _symKey)
        {
            _symKey = addr;
            _itemIconSlots = ReadHiLoPair(m, addr + 0x08);
            _invincibility = ScanIndexedHalfword(m, addr, 0x300);
        }

        iconSlots = _itemIconSlots;
        invincibility = _invincibility;
        return iconSlots != 0 && invincibility != 0;
    }

    static uint ReadHiLoPair(IMemory m, uint at)
    {
        uint lui = m.ReadU32(at);
        uint lo = m.ReadU32(at + 4);
        if (lui >> 26 != 0x0F) return 0;
        if (lo >> 26 != 0x09) return 0;
        if ((int)((lui >> 16) & 0x1F) != (int)((lo >> 16) & 0x1F)) return 0;
        return ((lui & 0xFFFF) << 16) + (uint)(int)(short)(lo & 0xFFFF);
    }

    static uint ScanIndexedHalfword(IMemory m, uint start, uint span)
    {
        for (uint off = 0; off + 8 < span; off += 4)
        {
            uint lui = m.ReadU32(start + off);
            if (lui >> 26 != 0x0F) continue;
            if (((lui >> 16) & 0x1F) != 1) continue;

            uint add = m.ReadU32(start + off + 4);
            if (add >> 26 != 0 || (add & 0x3F) != 0x21) continue;
            if (((add >> 21) & 0x1F) != 1 || ((add >> 11) & 0x1F) != 1) continue;

            uint lhu = m.ReadU32(start + off + 8);
            if (lhu >> 26 != 0x25) continue;
            if (((lhu >> 21) & 0x1F) != 1) continue;

            return ((lui & 0xFFFF) << 16) + (uint)(int)(short)(lhu & 0xFFFF);
        }
        return 0;
    }
}
