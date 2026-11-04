using RecompOne.Runtime.Context;
using RecompOne.Runtime.Memory;

namespace Recompiled;

//reimplementation of the transition code to fix the problems, this also will also freeze the camera so the camera jump doesnt happen, since it was one of the causes of the offset being wrong
public static partial class WidescreenPatch
{
    const uint TmScrollYHi = 0x80073092;
    const uint TmHSize = 0x800730A4;
    const uint TmLeft = 0x800730B0;
    const uint TmTop = 0x800730B4;
    const uint TmRight = 0x800730B8;
    const uint TmBottom = 0x800730BC;
    const uint TmX = 0x800730C0;
    const uint TmY = 0x800730C4;
    const uint TmWidth = 0x800730C8;
    const uint TmHeight = 0x800730CC;

    const uint GfxUnkC = 0x8009740C;
    const uint GfxUnk1C = 0x8009741C;

    const uint PlayerVramFlag = 0x80072F20;
    const uint PlayerStatus = 0x80072F2C;
    const uint PlayerUnk78 = 0x80072F98;

    const uint DrawModeFlag = 0x80097C98;
    const uint CamSlack = 0x801375A4;
    const uint RoomLoadDef = 0x801375BC;

    const uint PlPosXHi = 0x800733DA;
    const uint PlPosYHi = 0x800733DE;

    const uint PlayerYWorld = 0x800973F4;
    const uint GfxUnk18 = 0x80097418;
    const uint GfxUnk24 = 0x80097424;
    const uint LoadCellX = 0x8009791C;

    static bool CamPanActive(IMemory m)
    {
        if (!_camColDisabled) return false;
        if (m.ReadU16(StageId) == _disabledStage) return true;
        _camColDisabled = false;
        return false;
    }

    static int _roomX = int.MinValue, _roomW;

    static bool _roomJustLoaded;

    public static void MarkRoomLoaded(CpuContext c, IMemory m) => _roomJustLoaded = true;

    static short S16(IMemory m, uint a) => (short)m.ReadU16(a);
    static int S32(IMemory m, uint a) => (int)m.ReadU32(a);
    static void W16(IMemory m, uint a, int v) => m.WriteU16(a, (ushort)(short)v);

    static int NextRoom(CpuContext c, IMemory m, int x, int y)
    {
        var snap = c.Snapshot();
        c.A0 = (uint)x;
        c.A1 = (uint)y;
        SoTN_dra.SetNextRoomToLoad(c, m);
        int v0 = (int)c.V0;
        c.Restore(snap);
        return v0;
    }

    public static void CamCol(CpuContext c, IMemory m)
    {
        int arg0 = (int)c.A0;
        int ret;

        int left = S32(m, TmLeft), top = S32(m, TmTop);
        int tmX = S32(m, TmX), tmY = S32(m, TmY);
        int tmW = S32(m, TmWidth), tmH = S32(m, TmHeight);
        int anchor = S32(m, GfxUnkC);
        int px = S32(m, PlayerXWorld), py = S32(m, PlayerYWorld);

        int vScroll = px < tmX + anchor ? tmX
            : tmW + anchor - 256 < px ? tmW - 256
            : px - anchor;
        int posXv = px - vScroll;

        bool staleBounds = _roomX != int.MinValue && (tmX != _roomX || tmW != _roomW);
        int handoffX = S16(m, PlPosXHi);

        if (_roomJustLoaded && staleBounds && !OriginalAspect)
        {
            _roomJustLoaded = false;
            int scrNow = S16(m, TilemapScrollXHi);
            int scrHi = Math.Max(tmX, tmW - 256);
            if (scrNow < tmX || scrNow > scrHi)
            {
                int rebased = Math.Clamp(scrNow, tmX, scrHi);
                int keptPlX = S16(m, PlPosXHi);
                W16(m, TilemapScrollXHi, rebased);
                px = keptPlX + rebased;
                m.WriteU32(PlayerXWorld, (uint)px);
            }
        }

        bool skipToCamera = false;

        if (S32(m, GfxUnk18) == 0)
        {
            if (S32(m, DrawModeFlag) == 2)
            {
                ret = NextRoom(c, m, left + (posXv >> 8), top + (S16(m, PlPosYHi) >> 8));
                m.WriteU32(RoomLoadDef + 4, (uint)((px - S16(m, TilemapScrollXHi)) & 0xFF));
                m.WriteU32(RoomLoadDef + 8, (uint)(S16(m, PlPosYHi) & 0xFF));
                c.V0 = (uint)ret;
                return;
            }

            if (arg0 != 0)
            {
                if (px < tmX)
                {
                    ret = NextRoom(c, m, left - 1, top + (py >> 8));
                    if (ret != 0)
                    {
                        m.WriteU32(RoomLoadDef + 4, (uint)(px - S16(m, TilemapScrollXHi) + 256));
                        m.WriteU32(RoomLoadDef + 8, (uint)(int)S16(m, PlPosYHi));
                        m.WriteU16(PlayerUnk78, 1);
                        c.V0 = (uint)ret;
                        return;
                    }
                    m.WriteU32(PlayerXWorld, (uint)tmX);
                    px = tmX;
                    W16(m, PlPosXHi, 0);
                }

                if (px >= tmW)
                {
                    ret = NextRoom(c, m, S32(m, TmRight) + 1, top + (py >> 8));
                    if (ret != 0)
                    {
                        m.WriteU32(RoomLoadDef + 4, (uint)(px - S16(m, TilemapScrollXHi) - 256));
                        m.WriteU32(RoomLoadDef + 8, (uint)(int)S16(m, PlPosYHi));
                        m.WriteU16(PlayerUnk78, 1);
                        c.V0 = (uint)ret;
                        return;
                    }
                    m.WriteU32(PlayerXWorld, (uint)(tmW - 1));
                    px = tmW - 1;
                    W16(m, PlPosXHi, 255);
                }
            }
            else skipToCamera = true;
        }

        if (!skipToCamera && S32(m, GfxUnk24) == 0)
        {
            if (py < tmY + 4)
            {
                ret = NextRoom(c, m, left + (px >> 8), top - 1);
                if (ret != 0)
                {
                    m.WriteU32(RoomLoadDef + 4, (uint)(int)S16(m, PlPosXHi));
                    m.WriteU32(RoomLoadDef + 8, (uint)(S16(m, PlPosYHi) + 208));
                    m.WriteU32(PlayerYWorld, (uint)(py - 128));
                    m.WriteU16(PlayerUnk78, 2);
                    c.V0 = (uint)ret;
                    return;
                }
                m.WriteU32(PlayerYWorld, (uint)(tmY + 4));
                py = tmY + 4;
                W16(m, PlPosYHi, 0);
            }

            int slack = 48;
            if ((S32(m, PlayerVramFlag) & 1) == 0 && (S32(m, PlayerStatus) & 3) == 0) slack = 24;

            if (py >= tmH - slack + 20)
            {
                ret = NextRoom(c, m, left + (px >> 8), S32(m, TmBottom) + 1);
                if (ret != 0)
                {
                    m.WriteU32(RoomLoadDef + 4, (uint)(int)S16(m, PlPosXHi));
                    m.WriteU32(RoomLoadDef + 8, (uint)(S16(m, PlPosYHi) - (256 - slack)));
                    m.WriteU32(PlayerYWorld, (uint)(py + 0x80));
                    m.WriteU16(PlayerUnk78, 2);
                    c.V0 = (uint)ret;
                    return;
                }
                m.WriteU32(PlayerYWorld, (uint)(tmH - slack + 0x13));
                py = tmH - slack + 0x13;
                W16(m, PlPosYHi, 271 - slack);
            }
        }

        int vanillaScroll;
        int nudge = 0;

        if (px < tmX + anchor)
        {
            if (arg0 != 0 && S32(m, TmHSize) != 1 && tmX + anchor < px + S32(m, CamSlack))
                nudge = px + S32(m, CamSlack) - (tmX + anchor);
            vanillaScroll = tmX;
        }
        else if (tmW + anchor - 256 < px)
        {
            if (arg0 != 0 && S32(m, TmHSize) != 1 && px + S32(m, CamSlack) < tmW + anchor - 256)
                nudge = px + S32(m, CamSlack) - (tmW + anchor - 256);
            vanillaScroll = tmW - 256;
        }
        else vanillaScroll = px - anchor;

        if (arg0 == 0)
        {
            _roomX = tmX; _roomW = tmW;
        }
        bool locked = _roomX != int.MinValue && (tmX != _roomX || tmW != _roomW);

        int margin = CamPanActive(m) || locked ? 0 : StageMargin();
        if (margin > 0) margin = Math.Min(margin, Math.Max(0, ((tmW - tmX) - 256) / 2));

        int scroll = margin > 0
            ? Math.Clamp(vanillaScroll, tmX + margin, tmW - 256 - margin)
            : vanillaScroll;

        int posX = px - scroll + nudge;

        W16(m, TilemapScrollXHi, scroll);
        W16(m, PlPosXHi, posX);

        if (S32(m, GfxUnk1C) != 0)
        {
            if (py < tmY + 140)
            {
                W16(m, TmScrollYHi, tmY + 4);
                W16(m, PlPosYHi, py - S16(m, TmScrollYHi));
            }
            else if (tmH - 116 < py)
            {
                W16(m, TmScrollYHi, tmH - 252);
                W16(m, PlPosYHi, py - S16(m, TmScrollYHi));
            }
            else
            {
                W16(m, TmScrollYHi, py - 136);
                W16(m, PlPosYHi, 136);
            }
        }
        else if (py < tmY + 140)
        {
            if (S16(m, TmScrollYHi) - (py - 136) >= 4 && tmY + 8 < S16(m, TmScrollYHi))
            {
                W16(m, TmScrollYHi, S16(m, TmScrollYHi) - 4);
                W16(m, PlPosYHi, S16(m, PlPosYHi) + 4);
            }
            else if (S16(m, TmScrollYHi) < tmY && tmY != 0)
            {
                W16(m, TmScrollYHi, S16(m, TmScrollYHi) + 4);
                W16(m, PlPosYHi, S16(m, PlPosYHi) - 4);
            }
            else
            {
                W16(m, TmScrollYHi, tmY + 4);
                W16(m, PlPosYHi, py - S16(m, TmScrollYHi));
            }
        }
        else if (tmH - 116 < py)
        {
            W16(m, TmScrollYHi, tmH - 252);
            W16(m, PlPosYHi, py - S16(m, TmScrollYHi));
        }
        else if (S16(m, TmScrollYHi) - (py - 136) >= 4)
        {
            W16(m, TmScrollYHi, S16(m, TmScrollYHi) - 4);
            W16(m, PlPosYHi, S16(m, PlPosYHi) + 4);
        }
        else
        {
            W16(m, TmScrollYHi, py - 136);
            W16(m, PlPosYHi, 136);
        }

        c.V0 = 0;
    }
}
