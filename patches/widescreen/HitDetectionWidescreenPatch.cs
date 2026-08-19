using RecompOne.Runtime.Context;
using RecompOne.Runtime.Dispatch;
using RecompOne.Runtime.Memory;

namespace Recompiled;

//collision.h HitDetection reimplemented, basically copied and modified from the decomp
public static partial class WidescreenPatch
{
    const uint EntVelocityY = 0x0C;
    const uint EntHitboxOffX = 0x10;
    const uint EntHitboxOffY = 0x12;
    const uint EntFacingLeft = 0x14;
    const uint EntZPriority = 0x24;
    const uint EntParams = 0x30;
    const uint EntEnemyId = 0x3A;
    const uint EntHitboxState = 0x3C;
    const uint EntHitPoints = 0x3E;
    const uint EntAttack = 0x40;
    const uint EntAttackElement = 0x42;
    const uint EntHitboxWidth = 0x46;
    const uint EntHitboxHeight = 0x47;
    const uint EntParent = 0x5C;
    const uint EntNextPart = 0x60;
    const uint EntUnk6D = 0x6D;
    const uint EntCastleFlag = 0x94;
    const uint EntUnkB8 = 0xB8;
    const uint EntEntityId = 0x26;
    const uint RandomNext = 0x800978B8;

    const uint Spad = 0x1F800000;

    const uint StatusRelics = 0x80097964;
    const uint StatusKillCount = 0x80097BF4;
    const uint CastleFlags = 0x8003BDEC;
    const uint PlayableCharacter = 0x8003C9A0;
    const uint GameClearFlag = 0x8003BDE0;
    const uint GfxDamagePrimHead = 0x800973F8;
    const uint ApiEnemyDefs = 0x8003C808;
    const uint ApiPlaySfx = 0x8003C7DC;
    const uint ApiDealDamage = 0x8003C828;
    const uint ApiGrantExp = 0x8003C848;
    const uint ApiLuckRoll = 0x8003C878;
    const uint ApiDropRoll = 0x8003C87C;
    const uint RandAddr = 0x800160E4;

    const int EnemyDefSize = 0x28;
    const uint DefName = 0x00;
    const uint DefRareItemId = 0x1A;
    const uint DefUncommonItemId = 0x1C;
    const uint DefLevel = 0x16;
    const uint DefExp = 0x18;
    const uint DefHitPoints = 0x04;

    const int RelicSpiritOrb = 11;
    const int RelicFaerieScroll = 15;
    const int EnemyList190 = 400;

    const int EPrizeDrop = 0x03;
    const int ESoulStealOrb = 0x07;
    const int EEquipItemDrop = 0x0A;
    const int EEnemyBlood = 0x0D;

    const int SfxMetalClangE = 0x611;
    const int SfxWeaponStabB = 0x62E;
    const int SfxWeaponHitA = 0x678;
    const int SfxRicWhipHit = 0x705;

    const int PalUnk199 = 0x199;
    const int DrawUnk02 = 0x02;

    const uint FlagUnk10 = 0x10;
    const uint FlagUnk400 = 0x400;
    const uint FlagUnk800 = 0x800;
    const uint FlagUnk1000 = 0x1000;
    const uint FlagUnk4000 = 0x4000;
    const uint FlagUnk8000 = 0x8000;
    const uint FlagSuppressStun = 0x400000;
    const uint FlagNotAnEnemy = 0x01000000;
    const uint FlagKeepAliveOffCamera = 0x04000000;

    static readonly ushort[] TestCollElementLookup =
    [
        0x8000, 0x4000, 0x2000, 0x1000, 0x0800, 0x0200, 0x0100, 0x0080, 0x0400, 0x0040,
    ];

    static readonly ushort[] JewelSwordDropTable =
    [
        0xC00, 0x168, 0xF00, 0x169, 0xFD0, 0x16A, 0xFF0, 0x16B,
        0xFF8, 0x16C, 0xFFD, 0x16D, 0xFFF, 0x16E,
    ];

    static readonly ushort[] TestCollEnemyLookup =
    [
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1E, 0x00, 0x00, 0x2B, 0x00, 0x10,
        0x00, 0x0D, 0x68, 0x68, 0x16, 0x00, 0x00, 0x00, 0x3E, 0x00, 0x23, 0x50,
        0x00, 0x00, 0x00, 0x06, 0x00, 0x0A, 0x00, 0x7D, 0x00, 0x00, 0x2D, 0x00,
        0x00, 0x6D, 0x7B, 0x00, 0x17, 0x41, 0x00, 0x73, 0x00, 0x4C, 0x00, 0x00,
        0x38, 0x14, 0x5C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x46, 0x00, 0x00, 0x03, 0x58, 0x44, 0x24, 0x37, 0x00, 0x02, 0x59,
        0x00, 0x00, 0x00, 0x07, 0x00, 0x56, 0x00, 0x7C, 0x00, 0x0B, 0x00, 0x26,
        0x00, 0x1D, 0x00, 0x00, 0x2A, 0x00, 0x00, 0x00, 0x00, 0x27, 0x00, 0x00,
        0x00, 0x1C, 0x00, 0x31, 0x00, 0x00, 0x1A, 0x00, 0x8D, 0x09, 0x2C, 0x30,
        0x20, 0x00, 0x05, 0x47, 0x00, 0x5E, 0x35, 0x34, 0x6A, 0x00, 0x3A, 0x00,
        0x66, 0x00, 0x45, 0x00, 0x19, 0x00, 0x71, 0x00, 0x29, 0x39, 0x00, 0x51,
        0x00, 0x4D, 0x00, 0x00, 0x3F, 0x00, 0x77, 0x00, 0x00, 0x72, 0x00, 0x00,
        0x6F, 0x00, 0x2F, 0x00, 0x74, 0x00, 0x00, 0x79, 0x00, 0x7A, 0x00, 0x00,
        0x13, 0x11, 0x36, 0x36, 0x00, 0x5F, 0x5F, 0x00, 0x00, 0x67, 0x00, 0x75,
        0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x0E, 0x00,
        0x2E, 0x00, 0x69, 0x21, 0x00, 0x00, 0x55, 0x00, 0x54, 0x00, 0x53, 0x00,
        0x00, 0x0F, 0x00, 0x76, 0x00, 0x00, 0x8E, 0x00, 0x00, 0x00, 0x00, 0x4A,
        0x00, 0x00, 0x4B, 0x00, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x3D, 0x00,
        0x78, 0x8A, 0x00, 0x00, 0x00, 0x52, 0x00, 0x00, 0x89, 0x48, 0x00, 0x3C,
        0x40, 0x8B, 0x00, 0x00, 0x00, 0x1F, 0x00, 0x00, 0x7E, 0x00, 0x00, 0x49,
        0x00, 0x00, 0x00, 0x15, 0x00, 0x00, 0x0C, 0x28, 0x00, 0x00, 0x00, 0x32,
        0x00, 0x22, 0x12, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x33, 0x60, 0x00,
        0x64, 0x00, 0x00, 0x7F, 0x00, 0x00, 0x00, 0x4E, 0x00, 0x6E, 0x00, 0x00,
        0x00, 0x4F, 0x00, 0x00, 0x57, 0x00, 0x00, 0x00, 0x86, 0x65, 0x00, 0x3B,
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x25, 0x62, 0x62, 0x00, 0x00, 0x00,
        0x42, 0x00, 0x00, 0x18, 0x1B, 0x6B, 0x00, 0x8C, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x61, 0x63,
        0x88, 0x00, 0x00, 0x00, 0x85, 0x00, 0x00, 0x00, 0x00, 0x00, 0x84, 0x00,
        0x00, 0x87, 0x00, 0x00, 0x00, 0x00, 0x5D, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x5B, 0x91, 0x00, 0x00, 0x00, 0x00, 0x90, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x5A, 0x00, 0x00, 0x82, 0x00, 0x00, 0x00, 0x83, 0x00,
        0x81, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x92, 0x00, 0x00, 0x00, 0x00,
        0x04, 0x00, 0x70, 0x00, 0x00, 0x6C, 0x00, 0x00, 0x80, 0x80, 0x00, 0x00,
        0x8F, 0x00, 0x00, 0x00,
    ];

    static readonly byte[] TestCollLuckCutoff =
    [
        0x00, 0x40, 0x20, 0x10,
    ];

    static readonly byte[] TestColluCoords =
    [
        0x80, 0x80, 0xA0, 0xA0, 0xC0, 0xC0, 0x00, 0x00,
    ];

    static readonly byte[] TestCollvCoords =
    [
        0x60, 0x60, 0x60, 0x60, 0x60, 0x60, 0x00, 0x00,
    ];

    static readonly byte[] TestColliFrames =
    [
        2, 4, 3, 5, 6, 7, 8, 10, 2, 1,
    ];

    static readonly ushort[] TestCollPrizeTable =
    [
        0x0003, 0x0000, 0x0002, 0x0003, 0x0003, 0x0003, 0x0003, 0x0003,
        0x0003, 0x0004, 0x0004, 0x0004, 0x0004, 0x0005, 0x0005, 0x0000,
        0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000,
        0x0000, 0x0000, 0x0001, 0x0001, 0x0002, 0x0006, 0x0007, 0x00C6,
    ];

    static uint SpadState(int i) => Spad + (uint)(i * 4);
    static uint SpadBox(int i) => Spad + 0x30 * 4 + (uint)(i * 16);

    static int StageRandom(IMemory m)
    {
        uint next = m.ReadU32(RandomNext) * 0x01010101u + 1u;
        m.WriteU32(RandomNext, next);
        return (int)((next >> 24) & 0xFF);
    }

    static int LibRand(CpuContext c, IMemory m)
    {
        var snap = c.Snapshot();
        Dispatcher.Call(c, m, RandAddr);
        int v = (int)c.V0;
        c.Restore(snap);
        return v;
    }

    static void PlaySfx(CpuContext c, IMemory m, int id) => GameApiCall(c, m, ApiPlaySfx, (uint)id);

    static uint CastleLookup(IMemory m, uint entity)
    {
        uint id = m.ReadU16(entity + EntEnemyId);
        return id < TestCollEnemyLookup.Length ? TestCollEnemyLookup[id] : 0u;
    }

    static uint EnemyDefAt(IMemory m, uint entity)
        => m.ReadU32(ApiEnemyDefs) + (uint)(m.ReadU16(entity + EntEnemyId) * EnemyDefSize);

    static bool Overlap(IMemory m, uint box, short v, int half)
    {
        ushort d = (ushort)((ushort)m.ReadU32(box) - (ushort)v);
        uint span = (uint)(half + (int)m.ReadU32(box + 4));
        d = (ushort)(d + span);
        return d <= span * 2;
    }

    public static void HitDetection(CpuContext c, IMemory m)
    {
        int viewLeft = OutsetLeft(-32), viewRight = OutsetRight(288);

        for (int i = 0; i < 48; i++)
        {
            uint e = PedAt(i);
            uint state = m.ReadU16(e + EntHitboxState);
            m.WriteU32(SpadState(i), state);
            if (state == 0 || (state & 0x80) != 0) continue;

            int hbX = (short)m.ReadU16(e + PedPosXHi);
            short offX = (short)m.ReadU16(e + EntHitboxOffX);
            hbX = m.ReadU16(e + EntFacingLeft) != 0 ? hbX - offX : hbX + offX;
            int hbY = (short)m.ReadU16(e + PedPosYHi) + (short)m.ReadU16(e + EntHitboxOffY);

            byte w = m.ReadU8(e + EntHitboxWidth);
            byte h = m.ReadU8(e + EntHitboxHeight);
            if (hbX < viewLeft || hbX > viewRight || hbY < -32 || hbY > 256 || w == 0 || h == 0)
            {
                m.WriteU32(SpadState(i), 0);
                continue;
            }

            uint box = SpadBox(i);
            m.WriteU32(box + 0, (uint)hbX);
            m.WriteU32(box + 4, w);
            m.WriteU32(box + 8, (uint)hbY);
            m.WriteU32(box + 12, h);
        }

        for (int ei = 64; ei < 192; ei++)
        {
            uint entity = PedAt(ei);
            uint hitboxState = m.ReadU16(entity + EntHitboxState);
            byte ew = m.ReadU8(entity + EntHitboxWidth);
            byte eh = m.ReadU8(entity + EntHitboxHeight);
            if (hitboxState == 0 || ew == 0 || eh == 0 || (m.ReadU32(entity + EntFlags) & FlagDead) != 0) continue;

            for (int i = 0; i < 11; i++)
            {
                uint slot = entity + EntUnk6D + (uint)i;
                byte v = m.ReadU8(slot);
                if (v != 0) m.WriteU8(slot, (byte)(v - 1));
            }

            short offX = (short)m.ReadU16(entity + EntHitboxOffX);
            short x = (short)m.ReadU16(entity + PedPosXHi);
            x = (short)(m.ReadU16(entity + EntFacingLeft) != 0 ? x - offX : x + offX);
            short y = (short)((short)m.ReadU16(entity + PedPosYHi) + (short)m.ReadU16(entity + EntHitboxOffY));

            if (x <= viewLeft || x >= viewRight || y <= -32 || y >= 256) continue;

            uint iframes = 0;
            uint mask = hitboxState & 0x3E;
            int halfW = ew - 1;
            int halfH = eh - 1;

            uint iterEnt = 0;
            uint matchBox = 0;
            bool hit = false;

            if (mask != 0)
            {
                for (int k = 1; k < 48; k++)
                {
                    uint st = m.ReadU32(SpadState(k));
                    uint other = PedAt(k);
                    if ((st & mask) == 0) continue;
                    if (m.ReadU8(entity + EntUnk6D + m.ReadU16(other + EntEnemyId)) != 0) continue;

                    iterEnt = other;

                    if ((st & 0x80) != 0)
                    {
                        m.WriteU16(entity + EntHitParams, (ushort)(m.ReadU16(other + EntHitEffect) & 0x7F));
                        iframes = 0xFF;
                        hit = true;
                        matchBox = 0;
                        break;
                    }

                    uint box = SpadBox(k);
                    if (!Overlap(m, box, x, halfW)) continue;
                    if (!Overlap(m, box + 8, y, halfH)) continue;

                    int effect = m.ReadU16(other + EntHitEffect) & 0x7F;
                    uint eflags = m.ReadU32(entity + EntFlags);
                    if ((m.ReadU32(other + EntFlags) & eflags & FlagUnk100000) == 0)
                    {
                        m.WriteU32(other + EntUnkB8, entity);
                        m.WriteU8(other + EntHitFlags, (byte)((hitboxState & 8) != 0 ? 3 : 1));
                        if (effect == 3 && (eflags & FlagUnk8000) != 0)
                        {
                            PlaySfx(c, m, SfxMetalClangE);
                            m.WriteU8(other + EntHitFlags, 2);
                        }
                        if (effect == 4 && (eflags & FlagUnk4000) != 0)
                        {
                            PlaySfx(c, m, SfxMetalClangE);
                            m.WriteU8(other + EntHitFlags, 2);
                        }
                    }
                    m.WriteU16(entity + EntHitParams, (ushort)effect);
                    iframes = 0xFF;
                    hit = true;
                    matchBox = box;
                    break;
                }
            }

            if ((hitboxState & 1) != 0 && !hit)
            {
                iterEnt = PedAt(0);
                uint box = SpadBox(0);
                if (m.ReadU8(entity + EntUnk6D + m.ReadU16(iterEnt + EntEnemyId)) == 0 &&
                    (m.ReadU32(SpadState(0)) & 1) != 0 &&
                    Overlap(m, box, x, halfW) && Overlap(m, box + 8, y, halfH))
                {
                    short atk = (short)m.ReadU16(entity + EntAttack);
                    if (atk != 0 && (short)m.ReadU16(iterEnt + EntHitPoints) < atk)
                    {
                        m.WriteU32(iterEnt + EntUnkB8, entity);
                        m.WriteU8(iterEnt + EntHitFlags, (byte)((hitboxState & 8) != 0 ? 3 : 1));
                        m.WriteU16(iterEnt + EntHitParams, m.ReadU16(entity + EntAttackElement));
                        m.WriteU16(iterEnt + EntHitPoints, (ushort)atk);
                    }
                    m.WriteU16(entity + EntHitParams, (ushort)(m.ReadU16(iterEnt + EntHitEffect) & 0x7F));
                    iframes = 0xFF;
                    hit = true;
                    matchBox = box;
                    m.WriteU8(entity + EntHitFlags, 0x80);
                }
            }

            if (!hit) continue;

            uint entityHit = m.ReadU32(entity + EntParent);
            if (entityHit != 0)
            {
                m.WriteU16(entityHit + EntHitParams, m.ReadU16(entity + EntHitParams));
                m.WriteU8(entityHit + EntHitFlags, m.ReadU8(entity + EntHitFlags));
            }
            else entityHit = entity;

            if ((m.ReadU32(entityHit + EntFlags) & FlagDead) != 0) continue;

            int hitEffectKind = m.ReadU16(iterEnt + EntHitEffect) & 0x7F;
            if (hitEffectKind == 2 || (hitEffectKind == 6 && (hitboxState & 0x20) != 0))
            {
                uint orb = CallStageRet(c, m, "AllocEntity", PedAt(160), PedAt(192));
                if (orb != 0) CallStageRet(c, m, "CreateEntityFromEntity", ESoulStealOrb, entity, orb);
            }

            uint castleIdx = CastleLookup(m, entityHit);
            if (castleIdx != 0)
            {
                castleIdx--;
                uint flagAddr = CastleFlags + (castleIdx >> 3) + EnemyList190;
                m.WriteU8(flagAddr, (byte)(m.ReadU8(flagAddr) | (1 << (int)(castleIdx & 7))));
            }

            if ((m.ReadU8(StatusRelics + RelicFaerieScroll) & 2) != 0 &&
                (m.ReadU32(entityHit + EntFlags) & FlagNotAnEnemy) == 0)
            {
                if (m.ReadU32(GfxCornerTextTimer) != 0)
                {
                    GameApiCall(c, m, ApiFreePrimitives, m.ReadU32(GfxCornerTextPrims));
                    m.WriteU32(GfxCornerTextTimer, 0);
                }
                CallStageRet(c, m, "BottomCornerText", m.ReadU32(EnemyDefAt(m, entityHit) + DefName), 0);
                m.WriteU32(entityHit + EntFlags, m.ReadU32(entityHit + EntFlags) | FlagNotAnEnemy);
            }

            iframes = 0;
            uint damage = 0;

            bool skipDamage = (m.ReadU16(entity + EntHitboxState) & 8) != 0 &&
                              (m.ReadU16(iterEnt + EntHitboxState) & 4) != 0;

            if (!skipDamage && (short)m.ReadU16(entityHit + EntHitPoints) != 0)
            {
                short attackerAtk = (short)m.ReadU16(iterEnt + EntAttack);
                if (attackerAtk != 0)
                {
                    if ((m.ReadU16(iterEnt + EntHitboxState) & 0x80) == 0 && matchBox != 0)
                    {
                        x = (short)(x + (int)m.ReadU32(matchBox + 0));
                        y = (short)(y + (int)m.ReadU32(matchBox + 8));
                        x = (short)(x / 2);
                        y = (short)(y / 2);
                    }

                    uint prim = PrimBufAddr + m.ReadU32(GfxDamagePrimHead) * PrimStride;
                    for (int guard = 0; prim != 0 && guard < 1024; guard++)
                    {
                        if (m.ReadU16(prim + 0x32) == DrawHide)
                        {
                            m.WriteU16(prim + 0x0E, PalUnk199);
                            short px = (short)(x - 13 + (StageRandom(m) & 7) - 3);
                            short py = (short)(y - 10 + (StageRandom(m) & 7) - 3);
                            m.WriteU16(prim + 0x08, (ushort)px);
                            m.WriteU16(prim + 0x20, (ushort)px);
                            m.WriteU16(prim + 0x14, (ushort)(px + 0x20));
                            m.WriteU16(prim + 0x2C, (ushort)(px + 0x20));
                            m.WriteU16(prim + 0x0A, (ushort)py);
                            m.WriteU16(prim + 0x16, (ushort)py);
                            m.WriteU16(prim + 0x22, (ushort)(py + 0x20));
                            m.WriteU16(prim + 0x2E, (ushort)(py + 0x20));
                            m.WriteU8(prim + 0x13, 0);
                            int za = m.ReadU16(iterEnt + EntZPriority);
                            int zb = m.ReadU16(entity + EntZPriority);
                            m.WriteU16(prim + 0x26, (ushort)((za > zb ? za : zb) + 1));
                            m.WriteU16(prim + 0x32, DrawUnk02);
                            break;
                        }
                        prim = m.ReadU32(prim);
                    }
                }

                if (attackerAtk != 0 && (short)m.ReadU16(entityHit + EntHitPoints) != 0x7FFF)
                {
                    damage = GameApiCall2(c, m, ApiDealDamage, entity, iterEnt) & 0xFFFF;
                    if (m.ReadU16(iterEnt + EntHitboxState) == 4) damage = 0;

                    if ((m.ReadU8(StatusRelics + RelicSpiritOrb) & 2) != 0 &&
                        (m.ReadU32(entityHit + EntFlags) & FlagKeepAliveOffCamera) == 0 && damage != 0)
                    {
                        uint disp = CallStageRet(c, m, "AllocEntity", PedAt(224), PedAt(256));
                        uint dispFn = StageSym(m, "EntityDamageDisplay").Addr;
                        if (disp != 0 && dispFn != 0)
                        {
                            CallStageRet(c, m, "DestroyEntity", disp);
                            m.WriteU16(disp + EntEntityId, 4);
                            m.WriteU32(disp + EntPfnUpdate, dispFn);
                            m.WriteU16(disp + PedPosXHi, (ushort)x);
                            m.WriteU16(disp + PedPosYHi, (ushort)y);
                            m.WriteU16(disp + EntParams, (ushort)damage);
                        }
                    }
                }

                if (damage != 0xC000)
                {
                    if ((damage & 0x8000) != 0) iframes = 9;
                    else
                    {
                        uint element = m.ReadU16(iterEnt + EntAttackElement);
                        if ((element & 0xFFC0) != 0)
                            for (int i = 0; i < TestCollElementLookup.Length; i++)
                                if ((element & TestCollElementLookup[i]) != 0) { iframes = TestColliFrames[i]; break; }
                    }
                }
                else
                {
                    m.WriteU8(entityHit + EntHitFlags, (byte)(m.ReadU8(entityHit + EntHitFlags) | 0x20));
                    damage = 0;
                }

                if (damage == 0) goto unusual_spot;

                if ((damage & 0x8000) != 0)
                {
                    short hp = (short)((short)m.ReadU16(entityHit + EntHitPoints) + (int)(damage & 0x3FFF));
                    int cap = m.ReadU16(EnemyDefAt(m, entityHit) + DefHitPoints);
                    m.WriteU16(entityHit + EntHitPoints, (ushort)(hp > cap ? (short)cap : hp));
                }
                else
                {
                    damage &= 0x3FFF;
                    if ((m.ReadU32(entityHit + EntFlags) & FlagUnk10) != 0)
                    {
                        if (m.ReadU32(PlayableCharacter) != 0) PlaySfx(c, m, SfxRicWhipHit);
                        else if ((m.ReadU16(iterEnt + EntHitEffect) & 0x80) != 0) PlaySfx(c, m, SfxWeaponStabB);
                        else PlaySfx(c, m, SfxWeaponHitA);
                    }

                    short hp = (short)m.ReadU16(entityHit + EntHitPoints);
                    if (hp != 0x7FFE)
                    {
                        byte hf = m.ReadU8(entityHit + EntHitFlags);
                        if (hp < damage * 2) hf |= 3;
                        else if (hp < damage * 4) hf |= 2;
                        else hf |= 1;
                        m.WriteU8(entityHit + EntHitFlags, hf);
                        m.WriteU16(entityHit + EntHitPoints, (ushort)(short)(hp - (int)damage));
                    }

                    if ((m.ReadU16(iterEnt + EntAttackElement) & 0x40) != 0 &&
                        (m.ReadU16(entityHit + EntHitboxState) & 0x10) != 0)
                    {
                        uint blood = CallStageRet(c, m, "AllocEntity", PedAt(160), PedAt(192));
                        if (blood != 0)
                        {
                            CallStageRet(c, m, "CreateEntityFromEntity", EEnemyBlood, entity, blood);
                            if (x > (short)m.ReadU16(entity + PedPosXHi)) m.WriteU16(blood + EntParams, 1);
                            m.WriteU16(blood + PedPosXHi, (ushort)x);
                            m.WriteU16(blood + PedPosYHi, (ushort)y);
                            m.WriteU16(blood + EntZPriority, 192);
                        }
                    }
                }

                if ((short)m.ReadU16(entityHit + EntHitPoints) > 0)
                {
                    uint part = entityHit;
                    uint enemyId = m.ReadU16(iterEnt + EntEnemyId);
                    byte inv = m.ReadU8(iterEnt + EntNFramesInv);
                    ushort stun = m.ReadU16(iterEnt + EntStunFrames);
                    do
                    {
                        uint slot = part + EntUnk6D + enemyId;
                        m.WriteU8(slot, (byte)(entityHit < part ? inv + 1 : inv));
                        if ((m.ReadU32(entity + EntFlags) & FlagSuppressStun) == 0)
                            m.WriteU16(part + EntStunFrames, stun);
                        if (m.ReadU16(part + EntHitEffect) == 0 && (m.ReadU32(part + EntFlags) & 0xF) == 0)
                            m.WriteU16(part + EntHitEffect, m.ReadU16(part + EntPalette));
                        m.WriteU8(part + EntNFramesInv, (byte)iframes);
                        m.WriteU32(part + EntFlags, m.ReadU32(part + EntFlags) | 0xF);
                        part = m.ReadU32(part + EntNextPart);
                    } while (part != 0 && part != entityHit);
                    continue;
                }
            }

            CallStageRet(c, m, "PreventEntityFromRespawning", entityHit);
            uint def = EnemyDefAt(m, entityHit);

            if ((m.ReadU8(entityHit + EntHitFlags) & 0x80) == 0)
            {
                GameApiCall2(c, m, ApiGrantExp, m.ReadU16(def + DefExp), m.ReadU16(def + DefLevel));
                if ((m.ReadU32(entityHit + EntFlags) & FlagUnk1000) != 0)
                {
                    int kills = (int)m.ReadU32(StatusKillCount);
                    if (kills < 999999) m.WriteU32(StatusKillCount, (uint)(kills + 1));
                }
            }

            uint luck = m.ReadU32(entityHit + EntFlags) & (FlagUnk800 | FlagUnk400);
            if (luck != 0)
            {
                int cutoff = (int)GameApiCall(c, m, ApiLuckRoll, TestCollLuckCutoff[luck >> 10]);
                if ((LibRand(c, m) & 0xFF) < cutoff)
                {
                    uint drop = CallStageRet(c, m, "AllocEntity", PedAt(160), PedAt(192));
                    uint castleFlag = 0;
                    if (drop != 0)
                    {
                        uint itemId;
                        if (hitEffectKind == 5)
                        {
                            int roll = LibRand(c, m) & 0xFFF;
                            int t = 0;
                            while (JewelSwordDropTable[t] < roll) t += 2;
                            itemId = JewelSwordDropTable[t + 1];
                        }
                        else
                        {
                            uint roll = GameApiCall(c, m, ApiDropRoll, def);
                            if ((roll & 0x40) != 0)
                            {
                                itemId = m.ReadU16(def + DefRareItemId);
                                if (itemId == 0x173 && m.ReadU32(GameClearFlag) == 0) itemId = 0x16A;
                                else castleFlag = CastleLookup(m, entityHit);
                            }
                            else if ((roll & 0x20) != 0) itemId = m.ReadU16(def + DefUncommonItemId);
                            else itemId = TestCollPrizeTable[roll & 0x1F];
                        }

                        if (itemId >= 0x80)
                        {
                            itemId -= 0x80;
                            CallStageRet(c, m, "CreateEntityFromEntity", EEquipItemDrop, entity, drop);
                        }
                        else CallStageRet(c, m, "CreateEntityFromEntity", EPrizeDrop, entity, drop);

                        m.WriteU32(drop + EntCastleFlag, castleFlag);
                        m.WriteU16(drop + EntParams, (ushort)itemId);
                        m.WriteU32(drop + EntVelocityY, unchecked((uint)(-14336)));
                    }
                }
            }

            {
                uint part = entityHit;
                do
                {
                    uint f = m.ReadU32(part + EntFlags);
                    f |= FlagUnk100000 | FlagUnk8000 | FlagUnk4000 | FlagDead;
                    f &= ~FlagUnk20000000;
                    m.WriteU32(part + EntFlags, f);
                    if (m.ReadU16(part + EntHitEffect) == 0)
                        m.WriteU16(part + EntHitEffect, m.ReadU16(part + EntPalette));
                    m.WriteU8(part + EntNFramesInv, (byte)iframes);
                    m.WriteU32(part + EntFlags, m.ReadU32(part + EntFlags) | 0xF);
                    part = m.ReadU32(part + EntNextPart);
                } while (part != 0 && part != entityHit);
            }
            continue;

        unusual_spot:
            if ((m.ReadU8(entityHit + EntHitFlags) & 0xF) == 0)
                m.WriteU8(entityHit + EntHitFlags, (byte)(m.ReadU8(entityHit + EntHitFlags) | 0x10));

            if ((m.ReadU32(entityHit + EntFlags) & FlagUnk10) != 0 &&
                (short)m.ReadU16(iterEnt + EntAttack) != 0)
                PlaySfx(c, m, SfxMetalClangE);

            {
                uint part = entityHit;
                uint enemyId = m.ReadU16(iterEnt + EntEnemyId);
                byte inv = m.ReadU8(iterEnt + EntNFramesInv);
                bool immortal = (short)m.ReadU16(entity + EntHitPoints) == 0x7FFF;
                do
                {
                    if (!immortal || (short)m.ReadU16(part + EntHitPoints) == 0x7FFF)
                        m.WriteU8(part + EntUnk6D + enemyId, (byte)(entityHit < part ? inv + 1 : inv));
                    part = m.ReadU32(part + EntNextPart);
                } while (part != 0 && part != entityHit);
            }
        }

        uint tail = PrimBufAddr + m.ReadU32(GfxDamagePrimHead) * PrimStride;
        for (int guard = 0; tail != 0 && guard < 1024; guard++)
        {
            if (m.ReadU16(tail + 0x32) != DrawHide)
            {
                int step = m.ReadU8(tail + 0x13);
                byte u = TestColluCoords[step & 7];
                byte v = TestCollvCoords[step & 7];
                m.WriteU8(tail + 0x0C, u);
                m.WriteU8(tail + 0x24, u);
                m.WriteU8(tail + 0x18, (byte)(u + 0x20));
                m.WriteU8(tail + 0x30, (byte)(u + 0x20));
                m.WriteU8(tail + 0x0D, v);
                m.WriteU8(tail + 0x19, v);
                m.WriteU8(tail + 0x25, (byte)(v + 0x20));
                m.WriteU8(tail + 0x31, (byte)(v + 0x20));
                step++;
                if (step > 6) m.WriteU16(tail + 0x32, DrawHide);
                else m.WriteU8(tail + 0x13, (byte)step);
            }
            tail = m.ReadU32(tail);
        }
    }

    static uint GameApiCall2(CpuContext c, IMemory m, uint apiSlot, uint a0, uint a1)
    {
        var snap = c.Snapshot();
        c.A0 = a0;
        c.A1 = a1;
        Dispatcher.Call(c, m, m.ReadU32(apiSlot));
        uint ret = c.V0;
        c.Restore(snap);
        return ret;
    }//moving here doue difference
}
