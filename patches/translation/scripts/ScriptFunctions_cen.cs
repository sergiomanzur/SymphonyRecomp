using RecompOne.Runtime.Context;
using RecompOne.Runtime.Dispatch;
using RecompOne.Runtime.Memory;

namespace Recompiled.Translation;

public static class ScriptFunctions_cen
{
    public static bool CutsceneUnk1_cen(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("cen", m, true)) return true;
        CutsceneUnk1_cen_Body(c, m);
        return false;
    }
    private static void CutsceneUnk1_cen_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "cen", 0x8019D378u);
        { c.V0 = 0u | 0x0002u;  }
        c.At = 0x801A0000u; 
        mem.WriteU16((c.At - 0x2C7Cu), (ushort)c.V0); 
        c.At = 0x801A0000u; 
        mem.WriteU16((c.At - 0x2C7Eu), (ushort)c.V0); 
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU16((c.V0 - 0x2C80u)); 
        { c.V1 = 0u | 0x0008u;  }
        c.At = 0x801A0000u; 
        mem.WriteU16((c.At - 0x2C7Au), (ushort)0u); 
        c.At = 0x801A0000u; 
        mem.WriteU16((c.At - 0x2C76u), (ushort)0u); 
        c.At = 0x801A0000u; 
        mem.WriteU8((c.At - 0x2C72u), (byte)0u); 
        c.At = 0x801A0000u; 
        mem.WriteU8((c.At - 0x2C71u), (byte)c.V1); 
        { c.V0 = c.V0 + 0x14u;  }
        c.At = 0x801A0000u; 
        mem.WriteU16((c.At - 0x2C82u), (ushort)c.V0); 
        return;
        }
    public static bool SetCutsceneScript_cen(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("cen", m, true)) return true;
        SetCutsceneScript_cen_Body(c, m);
        return false;
    }
    private static void SetCutsceneScript_cen_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "cen", 0x8019D378u);
        c.A0 = DialogueScripts.ResolveStart("cen", c.A0, m);
        { c.SP = c.SP - 0x20u;  }
        mem.WriteU32((c.SP + 0x14u), c.S1); 
        c.S1 = c.A0; 
        { c.A0 = 0u | 0x0006u;  }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3848u)); 
        { c.A1 = 0u | 0x0007u;  }
        mem.WriteU32((c.SP + 0x18u), c.RA); 
        mem.WriteU32((c.SP + 0x10u), c.S0); 
        c.RA = 0x8018DF88u;
        Dispatcher.Call(c, m, c.V0);
        c.S0 = 0x801A0000u; 
        { c.S0 = c.S0 - 0x2C50u;  }
        { c.V0 = c.V0 << 16;  }
        { c.V0 = (uint)((int)c.V0 >> 16);  }
        c.V1 = 0xFFFFFFFFu; 
        if (c.V0 != c.V1) {
            mem.WriteU32(c.S0, c.V0); 
            goto L8018DFB0;
        }
        mem.WriteU32(c.S0, c.V0); 
        mem.WriteU32(c.S0, 0u); 
        c.V0 = 0u; 
        goto L8018E10C;
        L8018DFB0: ;
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2C88u), c.S1); 
        c.At = 0x801A0000u; 
        mem.WriteU16((c.At - 0x2C4Cu), (ushort)0u); 
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2C54u), c.V1); 
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2C58u), c.V1); 
        c.RA = 0x8018DFD8u; 
        Dispatcher.Call(c, m, 0x8018DF0Cu);
        c.V1 = mem.ReadU32(c.S0); 
        { c.V0 = c.V1 << 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.V1 = 0x80080000u; 
        { c.V1 = c.V1 + 0x6FECu;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2C70u), c.V0); 
        c.V1 = mem.ReadU32(c.V0); 
        { c.A2 = 0u | 0x0008u;  }
        mem.WriteU16((c.V0 + 0x32u), (ushort)c.A2); 
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2C6Cu), c.V1); 
        c.V0 = mem.ReadU32(c.V1); 
        mem.WriteU16((c.V1 + 0x32u), (ushort)c.A2); 
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2C68u), c.V0); 
        c.V1 = mem.ReadU32(c.V0); 
        mem.WriteU16((c.V0 + 0x32u), (ushort)c.A2); 
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2C64u), c.V1); 
        c.A0 = mem.ReadU32(c.V1); 
        mem.WriteU16((c.V1 + 0x32u), (ushort)c.A2); 
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2C60u), c.A0); 
        c.A1 = mem.ReadU32(c.A0); 
        { c.V0 = 0u | 0x0001u;  }
        mem.WriteU16((c.A0 + 0x32u), (ushort)c.A2); 
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2C5Cu), c.A1); 
        c.V1 = mem.ReadU32(c.A1); 
        { c.A0 = 0u | 0x0004u;  }
        mem.WriteU8((c.A1 + 0x7u), (byte)c.A0); 
        { c.A0 = 0u | 0x0003u;  }
        mem.WriteU16((c.A1 + 0x32u), (ushort)c.A2); 
        { c.A1 = 0u | 0x00FFu;  }
        mem.WriteU8((c.V1 + 0x7u), (byte)c.A0); 
        { c.A0 = 0u | 0x0004u;  }
        mem.WriteU8((c.V1 + 0x28u), (byte)c.A1); 
        mem.WriteU8((c.V1 + 0x1Cu), (byte)c.A1); 
        mem.WriteU8((c.V1 + 0x10u), (byte)c.A1); 
        mem.WriteU8((c.V1 + 0x4u), (byte)c.A1); 
        mem.WriteU8((c.V1 + 0x29u), (byte)0u); 
        mem.WriteU8((c.V1 + 0x1Du), (byte)0u); 
        mem.WriteU8((c.V1 + 0x11u), (byte)0u); 
        mem.WriteU8((c.V1 + 0x5u), (byte)0u); 
        mem.WriteU8((c.V1 + 0x2Au), (byte)0u); 
        mem.WriteU8((c.V1 + 0x1Eu), (byte)0u); 
        mem.WriteU8((c.V1 + 0x12u), (byte)0u); 
        mem.WriteU8((c.V1 + 0x6u), (byte)0u); 
        mem.WriteU16((c.V1 + 0x20u), (ushort)c.A0); 
        mem.WriteU16((c.V1 + 0x8u), (ushort)c.A0); 
        { c.A0 = 0u | 0x00F8u;  }
        mem.WriteU16((c.V1 + 0x2Cu), (ushort)c.A0); 
        mem.WriteU16((c.V1 + 0x14u), (ushort)c.A0); 
        { c.A0 = 0u | 0x01FDu;  }
        mem.WriteU16((c.V1 + 0x26u), (ushort)c.A0); 
        mem.WriteU16((c.V1 + 0x32u), (ushort)c.A2); 
        c.V1 = mem.ReadU32(c.V1); 
        { c.A0 = 0u | 0x0001u;  }
        mem.WriteU8((c.V1 + 0x7u), (byte)c.A0); 
        { c.A0 = 0u | 0x0003u;  }
        mem.WriteU16((c.V1 + 0x8u), (ushort)c.A0); 
        { c.A0 = 0u | 0x002Fu;  }
        mem.WriteU16((c.V1 + 0xAu), (ushort)c.A0); 
        { c.A0 = 0u | 0x004Au;  }
        mem.WriteU8((c.V1 + 0xDu), (byte)c.A0); 
        { c.A0 = 0u | 0x01FCu;  }
        mem.WriteU8((c.V1 + 0x6u), (byte)c.A1); 
        mem.WriteU8((c.V1 + 0x5u), (byte)c.A1); 
        mem.WriteU8((c.V1 + 0x4u), (byte)c.A1); 
        mem.WriteU16((c.V1 + 0x26u), (ushort)c.A0); 
        mem.WriteU16((c.V1 + 0x32u), (ushort)c.A2); 
        L8018E10C: ;
        c.RA = mem.ReadU32((c.SP + 0x18u)); 
        c.S1 = mem.ReadU32((c.SP + 0x14u)); 
        c.S0 = mem.ReadU32((c.SP + 0x10u)); 
        { c.SP = c.SP + 0x20u;  }
        return;
        }
    public static bool CutsceneUnk3_cen(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("cen", m, false)) return true;
        CutsceneUnk3_cen_Body(c, m);
        return false;
    }
    private static void CutsceneUnk3_cen_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "cen", 0x8019D378u);
        { c.SP = c.SP - 0x20u;  }
        { c.A0 = c.A0 << 16;  }
        { c.A0 = (uint)((int)c.A0 >> 16);  }
        { c.V0 = c.A0 << 1;  }
        { var _s = c.V0; var _t = c.A0; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { c.V0 = c.V0 + 0x180u;  }
        mem.WriteU16((c.SP + 0x12u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0040u;  }
        mem.WriteU16((c.SP + 0x14u), (ushort)c.V0); 
        { c.V0 = 0u | 0x000Cu;  }
        { c.A0 = c.SP + 0x10u;  }
        c.A1 = 0u; 
        c.A2 = 0u; 
        c.A3 = 0u; 
        mem.WriteU32((c.SP + 0x18u), c.RA); 
        mem.WriteU16((c.SP + 0x10u), (ushort)0u); 
        mem.WriteU16((c.SP + 0x16u), (ushort)c.V0); 
        c.RA = 0x8018E170u; 
        DialogueGlyphs.Clear(c, mem);
        c.RA = mem.ReadU32((c.SP + 0x18u)); 
        { c.SP = c.SP + 0x20u;  }
        return;
        }
    public static bool CutsceneUnk4_cen(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("cen", m, true)) return true;
        CutsceneUnk4_cen_Body(c, m);
        return false;
    }
    private static void CutsceneUnk4_cen_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "cen", 0x8019D378u);
        DialogueGlyphs.PrepareLine(c, mem);
        { c.SP = c.SP - 0x18u;  }
        mem.WriteU32((c.SP + 0x10u), c.S0); 
        c.S0 = 0x801A0000u; 
        { c.S0 = c.S0 - 0x2C7Au;  }
        mem.WriteU32((c.SP + 0x14u), c.RA); 
        c.A0 = (uint)(short)mem.ReadU16(c.S0); 
        c.RA = 0x8018E1A0u; 
        SoTN_cen.CutsceneUnk3_cen(c, m);
        c.V0 = (uint)(short)mem.ReadU16(c.S0); 
        { c.V0 = c.V0 << 2;  }
        { var _s = c.S0; var _t = c.V0; c.V0 = _s + _t;  }
        c.V1 = mem.ReadU32((c.V0 + 0xAu)); 
        { c.V0 = 0u | 0x0010u;  }
        mem.WriteU16((c.V1 + 0x1Au), (ushort)c.V0); 
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU16((c.V0 - 0x2C74u)); 
        mem.WriteU16((c.V1 + 0xEu), (ushort)c.V0); 
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU16((c.V0 - 0x2C82u)); 
        mem.WriteU8((c.V1 + 0xCu), (byte)0u); 
        mem.WriteU16((c.V1 + 0xAu), (ushort)c.V0); 
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU16((c.V0 - 0x2C84u)); 
        { c.V0 = c.V0 + 0x4u;  }
        mem.WriteU16((c.V1 + 0x8u), (ushort)c.V0); 
        c.A0 = (uint)(short)mem.ReadU16(c.S0); 
        { c.V0 = 0u | 0x00C0u;  }
        mem.WriteU8((c.V1 + 0x18u), (byte)c.V0); 
        { c.V0 = 0u | 0x000Cu;  }
        mem.WriteU8((c.V1 + 0x19u), (byte)c.V0); 
        { c.V0 = 0u | 0x01FFu;  }
        mem.WriteU16((c.V1 + 0x26u), (ushort)c.V0); 
        mem.WriteU16((c.V1 + 0x32u), (ushort)0u); 
        { c.V0 = c.A0 << 1;  }
        { var _s = c.V0; var _t = c.A0; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { c.V0 = c.V0 - 0x80u;  }
        mem.WriteU8((c.V1 + 0xDu), (byte)c.V0); 
        c.RA = mem.ReadU32((c.SP + 0x14u)); 
        c.S0 = mem.ReadU32((c.SP + 0x10u)); 
        { c.SP = c.SP + 0x18u;  }
        DialogueGlyphs.BeginLine(mem);
        return;
        }
    public static bool DrawCutsceneActorName_cen(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("cen", m, true)) return true;
        DrawCutsceneActorName_cen_Body(c, m);
        return false;
    }
    private static void DrawCutsceneActorName_cen_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "cen", 0x8019D378u);
        { c.SP = c.SP - 0x20u;  }
        mem.WriteU32((c.SP + 0x14u), c.S1); 
        c.S1 = c.A1; 
        mem.WriteU32((c.SP + 0x10u), c.S0); 
        c.S0 = c.A0; 
        { c.V0 = c.S0 & 0xFFFFu;  }
        { c.V0 = c.V0 << 2;  }
        c.A1 = 0u; 
        mem.WriteU32((c.SP + 0x18u), c.RA); 
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.A2 = mem.ReadU32((c.At + 0x684u)); 
        { c.V0 = 0u | 0x00FFu;  }
        L8018E26C: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V1 = mem.ReadU8(c.A2); 
        if (c.V1 != c.V0) {
            { c.A2 = c.A2 + 0x1u;  }
            goto L8018E28C;
        }
        { c.A2 = c.A2 + 0x1u;  }
        c.V1 = mem.ReadU8(c.A2); 
        if (c.V1 == 0u) {
            { c.A2 = c.A2 + 0x1u;  }
            goto L8018E29C;
        }
        { c.A2 = c.A2 + 0x1u;  }
        L8018E28C: ;
        if (c.V1 == 0u) {
            goto L8018E26C;
        }
        { c.A1 = c.A1 + 0x1u;  }
        goto L8018E26C;
        L8018E29C: ;
        { c.A0 = 0u | 0x0006u;  }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3848u)); 
        { c.A1 = c.A1 & 0xFFFFu;  }
        c.RA = 0x8018E2B4u;
        Dispatcher.Call(c, m, c.V0);
        { c.V0 = c.V0 << 16;  }
        { c.A1 = (uint)((int)c.V0 >> 16);  }
        c.V0 = 0xFFFFFFFFu; 
        if (c.A1 != c.V0) {
            { c.V0 = c.A1 << 1;  }
            goto L8018E2D8;
        }
        { c.V0 = c.A1 << 1;  }
        c.A0 = c.S1; 
        c.RA = 0x8018E2D0u; 
        SoTN_cen.DestroyEntity_cen(c, m);
        goto L8018E3A4;
        L8018E2D8: ;
        { var _s = c.V0; var _t = c.A1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.A1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.V1 = 0x80080000u; 
        { c.V1 = c.V1 + 0x6FECu;  }
        { var _s = c.V0; var _t = c.V1; c.A0 = _s + _t;  }
        c.V1 = 0x801A0000u; 
        { c.V1 = c.V1 - 0x2C54u;  }
        { c.V0 = c.S0 & 0xFFFFu;  }
        { c.V0 = c.V0 << 2;  }
        mem.WriteU32(c.V1, c.A1); 
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.A2 = mem.ReadU32((c.At + 0x684u)); 
        if (c.A0 == 0u) {
            { c.A3 = 0u | 0x0038u;  }
            goto L8018E3A4;
        }
        { c.A3 = 0u | 0x0038u;  }
        { c.T4 = 0u | 0x0006u;  }
        { c.T3 = 0u | 0x001Eu;  }
        { c.T2 = 0u | 0x0196u;  }
        { c.T1 = 0u | 0x01FFu;  }
        { c.A1 = 0u | 0x0008u;  }
        { c.T0 = c.V1 - 0x2Cu;  }
        L8018E334: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V1 = mem.ReadU8(c.A2); 
        if (c.V1 != 0u) {
            { c.A2 = c.A2 + 0x1u;  }
            goto L8018E34C;
        }
        { c.A2 = c.A2 + 0x1u;  }
        { c.A3 = c.A3 + 0x4u;  }
        goto L8018E398;
        L8018E34C: ;
        { c.V0 = c.V1 & 0x000Fu;  }
        { c.V0 = c.V0 << 3;  }
        mem.WriteU8((c.A0 + 0xCu), (byte)c.V0); 
        { c.V0 = c.V1 & 0x00F0u;  }
        { c.V0 = c.V0 >> 1;  }
        mem.WriteU8((c.A0 + 0x7u), (byte)c.T4); 
        mem.WriteU16((c.A0 + 0x1Au), (ushort)c.T3); 
        mem.WriteU16((c.A0 + 0xEu), (ushort)c.T2); 
        mem.WriteU8((c.A0 + 0xDu), (byte)c.V0); 
        mem.WriteU8((c.A0 + 0x19u), (byte)c.A1); 
        mem.WriteU8((c.A0 + 0x18u), (byte)c.A1); 
        mem.WriteU16((c.A0 + 0x26u), (ushort)c.T1); 
        mem.WriteU16((c.A0 + 0x32u), (ushort)c.A1); 
        mem.WriteU16((c.A0 + 0x8u), (ushort)c.A3); 
        c.V0 = mem.ReadU16(c.T0); 
        { c.A3 = c.A3 + 0x8u;  }
        { c.V0 = c.V0 + 0x6u;  }
        mem.WriteU16((c.A0 + 0xAu), (ushort)c.V0); 
        c.A0 = mem.ReadU32(c.A0); 
        L8018E398: ;
        if (c.A0 != 0u) {
            goto L8018E334;
        }
        L8018E3A4: ;
        c.RA = mem.ReadU32((c.SP + 0x18u)); 
        c.S1 = mem.ReadU32((c.SP + 0x14u)); 
        c.S0 = mem.ReadU32((c.SP + 0x10u)); 
        { c.SP = c.SP + 0x20u;  }
        return;
        }
    public static bool SetCutsceneEnd_cen(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("cen", m, true)) return true;
        SetCutsceneEnd_cen_Body(c, m);
        return false;
    }
    private static void SetCutsceneEnd_cen_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "cen", 0x8019D378u);
        c.V0 = 0x00100000u; 
        { var _s = c.A0; var _t = c.V0; c.A0 = _s + _t;  }
        { c.V0 = 0u | 0x0001u;  }
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2C48u), c.A0); 
        c.At = 0x801A0000u; 
        mem.WriteU16((c.At - 0x2C4Au), (ushort)0u); 
        c.At = 0x801A0000u; 
        mem.WriteU16((c.At - 0x2C4Cu), (ushort)c.V0); 
        return;
        }
    public static bool CutsceneRun_cen(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("cen", m, true)) return true;
        CutsceneRun_cen_Body(c, m);
        return false;
    }
    private static void CutsceneRun_cen_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "cen", 0x8019D378u);
        { c.SP = c.SP - 0x20u;  }
        c.A0 = 0x801A0000u; 
        { c.A0 = c.A0 - 0x2C4Au;  }
        mem.WriteU32((c.SP + 0x1Cu), c.RA); 
        mem.WriteU32((c.SP + 0x18u), c.S2); 
        mem.WriteU32((c.SP + 0x14u), c.S1); 
        mem.WriteU32((c.SP + 0x10u), c.S0); 
        c.V0 = mem.ReadU16(c.A0); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16(c.A0, (ushort)c.V0); 
        c.V1 = mem.ReadU16(c.A0); 
        { c.V0 = 0u | 0xFFFEu;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s < _t ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.S1 = c.A0 + 0x2u;  }
            goto L8018E448;
        }
        { c.S1 = c.A0 + 0x2u;  }
        c.At = 0x801A0000u; 
        mem.WriteU16((c.At - 0x2C4Cu), (ushort)0u); 
        goto L8018E6A8;
        L8018E438: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        mem.WriteU32(c.S1, c.A1); 
        goto L8018E6A8;
        L8018E440: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        mem.WriteU32(c.S1, c.A2); 
        goto L8018E6A8;
        L8018E448: ;
        { c.S2 = 0u | 0x0001u;  }
        L8018E44C: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.A1 = mem.ReadU32(c.S1); 
        c.V1 = mem.ReadU16((c.S1 - 0x2u)); 
        { c.V0 = c.A1 + 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.A0 = mem.ReadU8(c.A1); 
        { c.A2 = c.A1 + 0x2u;  }
        mem.WriteU32(c.S1, c.A2); 
        c.V0 = mem.ReadU8((c.A1 + 0x1u)); 
        { c.A0 = c.A0 << 8;  }
        { var _s = c.V0; var _t = c.A0; c.V0 = _s | _t;  }
        { var _s = c.V1; var _t = c.V0; c.V1 = _s < _t ? 1u : 0u;  }
        if (c.V1 != 0u) {
            { c.V0 = c.A1 + 0x3u;  }
            goto L8018E438;
        }
        { c.V0 = c.A1 + 0x3u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.V1 = mem.ReadU8((c.A1 + 0x2u)); 
        if (c.V1 == c.S2) {
            { c.V0 = (int)c.V1 < 2 ? 1u : 0u;  }
            goto L8018E5F4;
        }
        { c.V0 = (int)c.V1 < 2 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L8018E4AC;
        }
        if (c.V1 == 0u) {
            { c.V0 = c.A1 + 0x4u;  }
            goto L8018E4C8;
        }
        { c.V0 = c.A1 + 0x4u;  }
        goto L8018E44C;
        L8018E4AC: ;
        { c.V0 = 0u | 0x0002u;  }
        if (c.V1 == c.V0) {
            { c.V0 = 0u | 0x0003u;  }
            goto L8018E630;
        }
        { c.V0 = 0u | 0x0003u;  }
        if (c.V1 == c.V0) {
            { c.V0 = c.A1 + 0x4u;  }
            goto L8018E680;
        }
        { c.V0 = c.A1 + 0x4u;  }
        goto L8018E44C;
        L8018E4C8: ;
        mem.WriteU32(c.S1, c.V0); 
        c.V1 = mem.ReadU8((c.A1 + 0x3u)); 
        { c.V0 = c.V1 << 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 4;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s - _t;  }
        { c.V0 = c.V0 << 2;  }
        c.V1 = 0x80070000u; 
        { c.V1 = c.V1 + 0x62D8u;  }
        { var _s = c.V0; var _t = c.V1; c.S0 = _s + _t;  }
        c.A0 = c.S0; 
        c.RA = 0x8018E4FCu; 
        SoTN_cen.DestroyEntity_cen(c, m);
        c.V1 = mem.ReadU32(c.S1); 
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.V0 = mem.ReadU8(c.V1); 
        mem.WriteU16((c.S0 + 0x26u), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S0 + 0x26u)); 
        { c.V0 = c.V0 << 2;  }
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.V0 = mem.ReadU32((c.At + 0x390u)); 
        mem.WriteU32((c.S0 + 0x28u), c.V0); 
        c.V1 = mem.ReadU32(c.S1); 
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.V0 = mem.ReadU8(c.V1); 
        { c.V0 = c.V0 << 4;  }
        mem.WriteU16((c.S0 + 0x2u), (ushort)c.V0); 
        c.V1 = mem.ReadU32(c.S1); 
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.V0 = mem.ReadU8(c.V1); 
        c.V1 = mem.ReadU16((c.S0 + 0x2u)); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s | _t;  }
        mem.WriteU16((c.S0 + 0x2u), (ushort)c.V0); 
        c.V1 = mem.ReadU32(c.S1); 
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.V0 = mem.ReadU8(c.V1); 
        { c.V0 = c.V0 << 4;  }
        mem.WriteU16((c.S0 + 0x6u), (ushort)c.V0); 
        c.V1 = mem.ReadU32(c.S1); 
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.V0 = mem.ReadU8(c.V1); 
        c.V1 = mem.ReadU16((c.S0 + 0x6u)); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s | _t;  }
        mem.WriteU16((c.S0 + 0x6u), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S0 + 0x2u)); 
        c.V1 = 0x80070000u; 
        c.V1 = mem.ReadU16((c.V1 + 0x308Eu)); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s - _t;  }
        mem.WriteU16((c.S0 + 0x2u), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S0 + 0x6u)); 
        c.V1 = 0x80070000u; 
        c.V1 = mem.ReadU16((c.V1 + 0x3092u)); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s - _t;  }
        mem.WriteU16((c.S0 + 0x6u), (ushort)c.V0); 
        goto L8018E44C;
        L8018E5F4: ;
        { c.V0 = c.A1 + 0x4u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.V0 = mem.ReadU8((c.A1 + 0x3u)); 
        { c.A0 = c.V0 << 1;  }
        { var _s = c.A0; var _t = c.V0; c.A0 = _s + _t;  }
        { c.A0 = c.A0 << 4;  }
        { var _s = c.A0; var _t = c.V0; c.A0 = _s - _t;  }
        { c.A0 = c.A0 << 2;  }
        c.V0 = 0x80070000u; 
        { c.V0 = c.V0 + 0x62D8u;  }
        { var _s = c.A0; var _t = c.V0; c.A0 = _s + _t;  }
        c.RA = 0x8018E628u; 
        SoTN_cen.DestroyEntity_cen(c, m);
        goto L8018E44C;
        L8018E630: ;
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2C48u)); 
        c.V1 = 0x801A0000u; 
        c.V1 = mem.ReadU32((c.V1 - 0x2BDCu)); 
        c.V0 = mem.ReadU8(c.V0); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _t >> (int)(_s & 31u);  }
        { c.V0 = c.V0 & 0x0001u;  }
        if (c.V0 == 0u) {
            { c.V0 = c.A1 + 0x4u;  }
            goto L8018E440;
        }
        { c.V0 = c.A1 + 0x4u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.V0 = mem.ReadU8((c.A1 + 0x3u)); 
        { var _s = c.V0; var _t = c.S2; c.V0 = _t << (int)(_s & 31u);  }
        { var _s = 0u; var _t = c.V0; c.V0 = ~(_s | _t);  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s & _t;  }
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2BDCu), c.V0); 
        goto L8018E44C;
        L8018E680: ;
        mem.WriteU32(c.S1, c.V0); 
        c.V0 = mem.ReadU8((c.A1 + 0x3u)); 
        c.V1 = 0x801A0000u; 
        c.V1 = mem.ReadU32((c.V1 - 0x2BDCu)); 
        { var _s = c.V0; var _t = c.S2; c.V0 = _t << (int)(_s & 31u);  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s | _t;  }
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2BDCu), c.V0); 
        goto L8018E44C;
        L8018E6A8: ;
        c.RA = mem.ReadU32((c.SP + 0x1Cu)); 
        c.S2 = mem.ReadU32((c.SP + 0x18u)); 
        c.S1 = mem.ReadU32((c.SP + 0x14u)); 
        c.S0 = mem.ReadU32((c.SP + 0x10u)); 
        { c.SP = c.SP + 0x20u;  }
        return;
        }
    public static bool ScaleCutsceneAvatar_cen(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("cen", m, true)) return true;
        ScaleCutsceneAvatar_cen_Body(c, m);
        return false;
    }
    private static void ScaleCutsceneAvatar_cen_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "cen", 0x8019D378u);
        c.V0 = 0x801A0000u; 
        c.V0 = (uint)(short)mem.ReadU16((c.V0 - 0x2C7Au)); 
        { c.A3 = c.V0 + (uint)(mem.LineCount - DialogueGlyphs.VisibleLines(mem));  }
        { c.V0 = (int)c.A3 < 5 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L8018E6F4;
        }
        { c.A3 = c.A3 - 0x5u;  }
        L8018E6E4: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        { c.V0 = (int)c.A3 < 5 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.A3 = c.A3 - 0x5u;  }
            goto L8018E6E4;
        }
        { c.A3 = c.A3 - 0x5u;  }
        { c.A3 = c.A3 + 0x5u;  }
        L8018E6F4: ;
        c.V0 = 0x80070000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3C48u)); 
        c.V0 = mem.ReadU16((c.V0 + 0x2Eu)); 
        if (c.V0 != 0u) {
            c.V1 = 0u; 
            goto L8018E770;
        }
        c.V1 = 0u; 
        { c.V0 = c.A3 << 2;  }
        c.At = 0x801A0000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.A1 = mem.ReadU32((c.At - 0x2C70u)); 
        c.V0 = mem.ReadU8((c.A1 + 0x19u)); 
        { var _s = c.V0; var _t = c.A0; c.V0 = _s - _t;  }
        mem.WriteU8((c.A1 + 0x19u), (byte)c.V0); 
        c.V0 = mem.ReadU8((c.A1 + 0xDu)); 
        c.V1 = mem.ReadU8((c.A1 + 0x19u)); 
        { var _s = c.A0; var _t = c.V0; c.V0 = _s + _t;  }
        if (c.V1 != 0u) {
            mem.WriteU8((c.A1 + 0xDu), (byte)c.V0); 
            goto L8018E76C;
        }
        mem.WriteU8((c.A1 + 0xDu), (byte)c.V0); 
        c.V0 = 0x80070000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3C48u)); 
        c.V1 = mem.ReadU16((c.V0 + 0x2Eu)); 
        { c.V1 = c.V1 + 0x1u;  }
        mem.WriteU16((c.V0 + 0x2Eu), (ushort)c.V1); 
        { c.V0 = 0u | 0x0008u;  }
        mem.WriteU16((c.A1 + 0x32u), (ushort)c.V0); 
        L8018E76C: ;
        c.V1 = 0u; 
        L8018E770: ;
        { c.A0 = c.A0 & 0x00FFu;  }
        c.A2 = 0x801A0000u; 
        { c.A2 = c.A2 - 0x2C70u;  }
        L8018E77C: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        if (c.V1 == c.A3) {
            goto L8018E79C;
        }
        c.A1 = mem.ReadU32(c.A2); 
        c.V0 = mem.ReadU16((c.A1 + 0xAu)); 
        { var _s = c.V0; var _t = c.A0; c.V0 = _s - _t;  }
        mem.WriteU16((c.A1 + 0xAu), (ushort)c.V0); 
        L8018E79C: ;
        { c.V1 = c.V1 + 0x1u;  }
        { c.V0 = (int)c.V1 < 5 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.A2 = c.A2 + 0x4u;  }
            goto L8018E77C;
        }
        { c.A2 = c.A2 + 0x4u;  }
        c.V1 = 0x801A0000u; 
        { c.V1 = c.V1 - 0x2C78u;  }
        c.V0 = mem.ReadU16(c.V1); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16(c.V1, (ushort)c.V0); 
        return;
        }
    public static bool CEN_EntityCutscene(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("cen", m, true)) return true;
        CEN_EntityCutscene_Body(c, m);
        return false;
    }
    private static void CEN_EntityCutscene_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "cen", 0x8019D378u);
        { c.SP = c.SP - 0x48u;  }
        mem.WriteU32((c.SP + 0x38u), c.S2); 
        c.S2 = c.A0; 
        mem.WriteU32((c.SP + 0x44u), c.RA); 
        mem.WriteU32((c.SP + 0x40u), c.S4); 
        mem.WriteU32((c.SP + 0x3Cu), c.S3); 
        mem.WriteU32((c.SP + 0x34u), c.S1); 
        mem.WriteU32((c.SP + 0x30u), c.S0); 
        c.V0 = mem.ReadU16((c.S2 + 0x2Cu)); 
        if (c.V0 == 0u) {
            goto L8018E928;
        }
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2BD8u)); 
        if (c.V0 == 0u) {
            goto L8018E8FC;
        }
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2C8Cu)); 
        if (c.V0 != 0u) {
            goto L8018E8FC;
        }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x34FCu)); 
        { c.V0 = c.V0 & 0x0800u;  }
        if (c.V0 != 0u) {
            goto L8018E84C;
        }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x4220u)); 
        if (c.V0 == 0u) {
            goto L8018E8FC;
        }
        L8018E84C: ;
        c.V0 = 0x80090000u; 
        c.V0 = mem.ReadU16((c.V0 + 0x7494u)); 
        { c.V0 = c.V0 & 0x0800u;  }
        if (c.V0 == 0u) {
            { c.V0 = 0u | 0x0001u;  }
            goto L8018E8FC;
        }
        { c.V0 = 0u | 0x0001u;  }
        c.S0 = 0x80040000u; 
        { c.S0 = c.S0 - 0x384Cu;  }
        c.A0 = mem.ReadU32((c.S2 + 0x64u)); 
        c.V1 = mem.ReadU32(c.S0); 
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2C8Cu), c.V0); 
        c.S1 = 0xFFFFFFFFu; 
        c.RA = 0x8018E884u;
        Dispatcher.Call(c, m, c.V1);
        c.V0 = mem.ReadU32((c.S2 + 0x34u)); 
        c.V1 = 0x00800000u; 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s ^ _t;  }
        mem.WriteU32((c.S2 + 0x34u), c.V0); 
        c.A0 = 0x801A0000u; 
        c.A0 = mem.ReadU32((c.A0 - 0x2C54u)); 
        if (c.A0 == c.S1) {
            goto L8018E8B8;
        }
        c.V0 = mem.ReadU32(c.S0); 
        c.RA = 0x8018E8B8u;
        Dispatcher.Call(c, m, c.V0);
        L8018E8B8: ;
        c.A0 = 0x801A0000u; 
        c.A0 = mem.ReadU32((c.A0 - 0x2C58u)); 
        if (c.A0 == c.S1) {
            goto L8018E8DC;
        }
        c.V0 = mem.ReadU32(c.S0); 
        c.RA = 0x8018E8DCu;
        Dispatcher.Call(c, m, c.V0);
        L8018E8DC: ;
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3824u)); 
        { c.A0 = 0u | 0x000Au;  }
        c.RA = 0x8018E8F0u;
        Dispatcher.Call(c, m, c.V0);
        { c.V0 = 0u | 0x0001u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        mem.WriteU16((c.S2 + 0x2Eu), (ushort)0u); 
        L8018E8FC: ;
        c.V0 = mem.ReadU16((c.S2 + 0x2Cu)); 
        if (c.V0 == 0u) {
            goto L8018E928;
        }
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU16((c.V0 - 0x2C4Cu)); 
        if (c.V0 == 0u) {
            goto L8018E928;
        }
        c.RA = 0x8018E928u; 
        SoTN_cen.CutsceneRun_cen(c, m);
        L8018E928: ;
        c.V1 = mem.ReadU16((c.S2 + 0x2Cu)); 
        { c.V0 = c.V1 < 0x00000008u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.V0 = c.V1 << 2;  }
            goto L8018F86C;
        }
        { c.V0 = c.V1 << 2;  }
        c.At = 0x80190000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.V0 = mem.ReadU32((c.At - 0x2BD4u)); 
        switch (c.V0)
        {
            case 0x8018E954u: goto L8018E954;
            case 0x8018E9D4u: goto L8018E9D4;
            case 0x8018F2C4u: goto L8018F2C4;
            case 0x8018F2F8u: goto L8018F2F8;
            case 0x8018F3BCu: goto L8018F3BC;
            case 0x8018F454u: goto L8018F454;
            case 0x8018F744u: goto L8018F744;
            case 0x8018F828u: goto L8018F828;
            case 0x8018EA4Cu: goto L8018EA4C;
            case 0x8018EA58u: goto L8018EA58;
            case 0x8018EB04u: goto L8018EB04;
            case 0x8018EB30u: goto L8018EB30;
            case 0x8018EB60u: goto L8018EB60;
            case 0x8018EBA0u: goto L8018EBA0;
            case 0x8018ECD8u: goto L8018ECD8;
            case 0x8018ED50u: goto L8018ED50;
            case 0x8018EDE4u: goto L8018EDE4;
            case 0x8018EE0Cu: goto L8018EE0C;
            case 0x8018EE34u: goto L8018EE34;
            case 0x8018EE6Cu: goto L8018EE6C;
            case 0x8018EEB4u: goto L8018EEB4;
            case 0x8018E9E8u: goto L8018E9E8;
            case 0x8018EF10u: goto L8018EF10;
            case 0x8018EF74u: goto L8018EF74;
            case 0x8018EFD4u: goto L8018EFD4;
            case 0x8018F024u: goto L8018F024;
            case 0x8018F058u: goto L8018F058;
            case 0x8018F068u: goto L8018F068;
            case 0x8018F128u: goto L8018F128;
            case 0x8018F164u: goto L8018F164;
            case 0x8018F184u: goto L8018F184;
            case 0x8018F86Cu: goto L8018F86C;
            case 0x8018F1C0u: goto L8018F1C0;
            case 0x8018F9FCu: goto L8018F9FC;
            case 0x8018FAF4u: goto L8018FAF4;
            case 0x8018FBF4u: goto L8018FBF4;
            case 0x8018FCBCu: goto L8018FCBC;
            case 0x8018FD9Cu: goto L8018FD9C;
            case 0x8018FE60u: goto L8018FE60;
            case 0x8018FEC8u: goto L8018FEC8;
            case 0x8018FF0Cu: goto L8018FF0C;
            case 0x8018FFC0u: goto L8018FFC0;
            case 0x8018FFE8u: goto L8018FFE8;
            default: Dispatcher.Call(c, m, c.V0); return;
        }
        L8018E954: ;
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU8((c.V0 - 0x413Cu)); 
        if (c.V0 != 0u) {
            goto L8018F4BC;
        }
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x13F0u;  }
        c.RA = 0x8018E978u; 
        SoTN_cen.SetCutsceneScript_cen(c, m);
        { c.V0 = c.V0 & 0x00FFu;  }
        if (c.V0 == 0u) {
            c.A0 = 0x00800000u; 
            goto L8018F86C;
        }
        c.A0 = 0x00800000u; 
        c.V1 = mem.ReadU32((c.S2 + 0x34u)); 
        { c.V0 = 0u | 0x0001u;  }
        c.At = 0x80040000u; 
        mem.WriteU32((c.At - 0x38FCu), c.V0); 
        c.V0 = mem.ReadU16((c.S2 + 0x2Cu)); 
        { c.A0 = c.A0 | 0x2000u;  }
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2BDCu), 0u); 
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2BD8u), 0u); 
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2C8Cu), 0u); 
        { var _s = c.V1; var _t = c.A0; c.V1 = _s | _t;  }
        mem.WriteU32((c.S2 + 0x34u), c.V1); 
        c.V1 = 0x801A0000u; 
        c.V1 = mem.ReadU32((c.V1 - 0x2C50u)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        mem.WriteU32((c.S2 + 0x64u), c.V1); 
        goto L8018F86C;
        L8018E9D4: ;
        c.S4 = 0x801A0000u; 
        { c.S4 = c.S4 - 0x2C72u;  }
        { c.S1 = c.S4 - 0x16u;  }
        { c.S0 = c.S4 - 0xCu;  }
        { c.S3 = c.S4 - 0x12u;  }
        L8018E9E8: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V0 = mem.ReadU8(c.S4); 
        if (c.V0 == 0u) {
            goto L8018EA0C;
        }
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2C8Cu)); 
        if (c.V0 == 0u) {
            goto L8018F7EC;
        }
        L8018EA0C: ;
        c.V0 = mem.ReadU32(c.S1); 
        { c.V1 = c.V0 + 0x1u;  }
        mem.WriteU32(c.S1, c.V1); 
        c.A2 = mem.ReadU8(c.V0); 
        { c.V1 = c.A2 & 0xFFFFu;  }
        { c.V0 = c.V1 < 0x00000019u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.V0 = c.V1 << 2;  }
            goto L8018F200;
        }
        { c.V0 = c.V1 << 2;  }
        c.At = 0x80190000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.V0 = mem.ReadU32((c.At - 0x2BB4u)); 
        switch (c.V0)
        {
            case 0x8018EA4Cu: goto L8018EA4C;
            case 0x8018EA58u: goto L8018EA58;
            case 0x8018EB04u: goto L8018EB04;
            case 0x8018EB30u: goto L8018EB30;
            case 0x8018EB60u: goto L8018EB60;
            case 0x8018EBA0u: goto L8018EBA0;
            case 0x8018ECD8u: goto L8018ECD8;
            case 0x8018ED50u: goto L8018ED50;
            case 0x8018EDE4u: goto L8018EDE4;
            case 0x8018EE0Cu: goto L8018EE0C;
            case 0x8018EE34u: goto L8018EE34;
            case 0x8018EE6Cu: goto L8018EE6C;
            case 0x8018EEB4u: goto L8018EEB4;
            case 0x8018E9E8u: goto L8018E9E8;
            case 0x8018EF10u: goto L8018EF10;
            case 0x8018EF74u: goto L8018EF74;
            case 0x8018EFD4u: goto L8018EFD4;
            case 0x8018F024u: goto L8018F024;
            case 0x8018F058u: goto L8018F058;
            case 0x8018F068u: goto L8018F068;
            case 0x8018F128u: goto L8018F128;
            case 0x8018F164u: goto L8018F164;
            case 0x8018F184u: goto L8018F184;
            case 0x8018F86Cu: goto L8018F86C;
            case 0x8018F1C0u: goto L8018F1C0;
            case 0x8018F9FCu: goto L8018F9FC;
            case 0x8018FAF4u: goto L8018FAF4;
            case 0x8018FBF4u: goto L8018FBF4;
            case 0x8018FCBCu: goto L8018FCBC;
            case 0x8018FD9Cu: goto L8018FD9C;
            case 0x8018FE60u: goto L8018FE60;
            case 0x8018FEC8u: goto L8018FEC8;
            case 0x8018FF0Cu: goto L8018FF0C;
            case 0x8018FFC0u: goto L8018FFC0;
            case 0x8018FFE8u: goto L8018FFE8;
            default: Dispatcher.Call(c, m, c.V0); return;
        }
        L8018EA4C: ;
        { c.V0 = 0u | 0x0007u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        goto L8018F86C;
        L8018EA58: ;
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2C8Cu)); 
        if (c.V0 != 0u) {
            goto L8018E9E8;
        }
        c.V0 = mem.ReadU16((c.S0 + 0x8u)); 
        c.V1 = mem.ReadU16((c.S0 + 0x2u)); 
        { c.V0 = c.V0 & 0x0001u;  }
        if (c.V0 != 0u) {
            mem.WriteU16(c.S0, (ushort)c.V1); 
            goto L8018EA90;
        }
        mem.WriteU16(c.S0, (ushort)c.V1); 
        c.V0 = mem.ReadU16((c.S0 - 0x4u)); 
        { c.V0 = c.V0 + 0xCu;  }
        mem.WriteU16((c.S0 - 0x4u), (ushort)c.V0); 
        L8018EA90: ;
        c.V0 = mem.ReadU16((c.S0 + 0x4u)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S0 + 0x4u), (ushort)c.V0); 
        { c.V0 = c.V0 << 16;  }
        { c.V0 = (uint)((int)c.V0 >> 16);  }
        { c.V0 = (int)c.V0 < 5 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L8018EAB8;
        }
        mem.WriteU16((c.S0 + 0x4u), (ushort)0u); 
        L8018EAB8: ;
        c.RA = 0x8018EAC0u; 
        SoTN_cen.CutsceneUnk4_cen(c, m);
        c.V1 = mem.ReadU16((c.S0 + 0x8u)); 
        { c.V0 = c.V1 & 0x0001u;  }
        if (c.V0 != 0u) {
            goto L8018EAEC;
        }
        c.V0 = (uint)(short)mem.ReadU16((c.S0 + 0x4u)); 
        { c.V0 = (int)c.V0 < 4 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.V0 = c.V1 | 0x0001u;  }
            goto L8018E9E8;
        }
        { c.V0 = c.V1 | 0x0001u;  }
        mem.WriteU16((c.S0 + 0x8u), (ushort)c.V0); 
        L8018EAEC: ;
        mem.WriteU16((c.S0 + 0x6u), (ushort)0u); 
        c.V0 = mem.ReadU16((c.S2 + 0x2Cu)); 
        mem.WriteU16((c.S2 + 0x2Eu), (ushort)0u); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        goto L8018F86C;
        L8018EB04: ;
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2C88u)); 
        { c.V1 = c.V0 + 0x1u;  }
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2C88u), c.V1); 
        c.V0 = mem.ReadU8(c.V0); 
        c.At = 0x801A0000u; 
        mem.WriteU8((c.At - 0x2C71u), (byte)c.V0); 
        goto L8018E9E8;
        L8018EB30: ;
        c.V1 = mem.ReadU32((c.S4 - 0x16u)); 
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU32((c.S4 - 0x16u), c.V0); 
        c.V0 = mem.ReadU8(c.V1); 
        c.V1 = 0x801A0000u; 
        c.V1 = mem.ReadU32((c.V1 - 0x2C8Cu)); 
        if (c.V1 != 0u) {
            mem.WriteU8(c.S4, (byte)c.V0); 
            goto L8018E9E8;
        }
        mem.WriteU8(c.S4, (byte)c.V0); 
        goto L8018F86C;
        L8018EB60: ;
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2C8Cu)); 
        if (c.V0 != 0u) {
            { c.V1 = 0u | 0x0008u;  }
            goto L8018E9E8;
        }
        { c.V1 = 0u | 0x0008u;  }
        c.S1 = 0x801A0000u; 
        c.S1 = mem.ReadU32((c.S1 - 0x2C70u)); 
        c.S0 = 0u; 
        { c.S0 = c.S0 + 0x1u;  }
        L8018EB84: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        { c.V0 = (int)c.S0 < 5 ? 1u : 0u;  }
        mem.WriteU16((c.S1 + 0x32u), (ushort)c.V1); 
        c.S1 = mem.ReadU32(c.S1); 
        if (c.V0 != 0u) {
            { c.S0 = c.S0 + 0x1u;  }
            goto L8018EB84;
        }
        { c.S0 = c.S0 + 0x1u;  }
        goto L8018F86C;
        L8018EBA0: ;
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2C8Cu)); 
        if (c.V0 != 0u) {
            goto L8018EE20;
        }
        c.V1 = mem.ReadU32(c.S1); 
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.S0 = mem.ReadU8(c.V1); 
        { c.V0 = c.V1 + 0x2u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.T2 = mem.ReadU8((c.V1 + 0x1u)); 
        c.S1 = mem.ReadU32((c.S1 + 0x2Cu)); 
        { c.V0 = c.T2 & 0x0001u;  }
        { c.V1 = c.S0 << 1;  }
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.A0 = mem.ReadU8((c.At + 0x5D8u)); 
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.A1 = mem.ReadU8((c.At + 0x5DCu)); 
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.V1; c.At = _s + _t;  }
        c.V1 = mem.ReadU16((c.At + 0x5E0u)); 
        { c.V0 = 0u | 0x0090u;  }
        mem.WriteU16((c.S1 + 0x1Au), (ushort)c.V0); 
        { c.V0 = c.T2 & 0x0080u;  }
        if (c.V0 == 0u) {
            mem.WriteU16((c.S1 + 0xEu), (ushort)c.V1); 
            goto L8018EC24;
        }
        mem.WriteU16((c.S1 + 0xEu), (ushort)c.V1); 
        c.V1 = c.A0; 
        { c.V0 = c.V1 + 0x2Fu;  }
        goto L8018EC2C;
        L8018EC24: ;
        c.V0 = c.A0; 
        { c.V1 = c.V0 + 0x2Fu;  }
        L8018EC2C: ;
        mem.WriteU8((c.S1 + 0x24u), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0xCu), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0x30u), (byte)c.V1); 
        mem.WriteU8((c.S1 + 0x18u), (byte)c.V1); 
        c.V0 = c.A1; 
        { c.V1 = c.V0 + 0x48u;  }
        mem.WriteU8((c.S1 + 0x19u), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0xDu), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0x31u), (byte)c.V1); 
        mem.WriteU8((c.S1 + 0x25u), (byte)c.V1); 
        c.V0 = mem.ReadU16(c.S3); 
        { c.V0 = c.V0 - 0x1Eu;  }
        mem.WriteU16((c.S1 + 0x2Cu), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x20u), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x14u), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x8u), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S3 + 0x4u)); 
        { c.V0 = c.V0 + 0x24u;  }
        mem.WriteU16((c.S1 + 0x2Eu), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x22u), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x16u), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0xAu), (ushort)c.V0); 
        { c.V0 = c.S0 << 1;  }
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.V0 = mem.ReadU16((c.At + 0x5ECu)); 
        mem.WriteU16((c.S3 + 0x10u), (ushort)c.V0); 
        c.RA = 0x8018ECA4u; 
        Dispatcher.Call(c, m, 0x8018DF0Cu);
        c.RA = 0x8018ECACu; 
        SoTN_cen.CutsceneUnk4_cen(c, m);
        { c.A0 = c.S0 & 0xFFFFu;  }
        c.A1 = c.S2; 
        { c.V0 = 0u | 0x01FEu;  }
        mem.WriteU16((c.S1 + 0x26u), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x32u), (ushort)0u); 
        c.RA = 0x8018ECC4u; 
        SoTN_cen.DrawCutsceneActorName_cen(c, m);
        { c.V0 = 0u | 0x0006u;  }
        mem.WriteU16((c.S3 + 0xCu), (ushort)c.V0); 
        { c.V0 = 0u | 0x0003u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        goto L8018F86C;
        L8018ECD8: ;
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2C8Cu)); 
        if (c.V0 != 0u) {
            { c.V1 = 0u | 0x0008u;  }
            goto L8018E9E8;
        }
        { c.V1 = 0u | 0x0008u;  }
        c.S1 = 0x801A0000u; 
        c.S1 = mem.ReadU32((c.S1 - 0x2C70u)); 
        c.S0 = 0u; 
        { c.S0 = c.S0 + 0x1u;  }
        L8018ECFC: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        { c.V0 = (int)c.S0 < 5 ? 1u : 0u;  }
        mem.WriteU16((c.S1 + 0x32u), (ushort)c.V1); 
        c.S1 = mem.ReadU32(c.S1); 
        if (c.V0 != 0u) {
            { c.S0 = c.S0 + 0x1u;  }
            goto L8018ECFC;
        }
        { c.S0 = c.S0 + 0x1u;  }
        c.S0 = 0x801A0000u; 
        { c.S0 = c.S0 - 0x2C54u;  }
        c.A0 = mem.ReadU32(c.S0); 
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x384Cu)); 
        c.RA = 0x8018ED30u;
        Dispatcher.Call(c, m, c.V0);
        c.V0 = 0xFFFFFFFFu; 
        mem.WriteU32(c.S0, c.V0); 
        { c.V0 = 0u | 0x0006u;  }
        c.At = 0x801A0000u; 
        mem.WriteU16((c.At - 0x2C78u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0004u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        goto L8018F86C;
        L8018ED50: ;
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2C8Cu)); 
        if (c.V0 != 0u) {
            goto L8018EE20;
        }
        c.V1 = mem.ReadU32((c.S3 - 0x4u)); 
        c.S1 = mem.ReadU32((c.S3 + 0x28u)); 
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU32((c.S3 - 0x4u), c.V0); 
        c.A0 = mem.ReadU8(c.V1); 
        { c.V0 = c.V1 + 0x2u;  }
        mem.WriteU32((c.S3 - 0x4u), c.V0); 
        mem.WriteU16(c.S3, (ushort)c.A0); 
        c.V0 = mem.ReadU8((c.V1 + 0x1u)); 
        mem.WriteU16((c.S3 + 0x4u), (ushort)c.V0); 
        c.S1 = mem.ReadU32(c.S1); 
        mem.WriteU16((c.S1 + 0x16u), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0xAu), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S3 + 0x4u)); 
        { c.V0 = c.V0 + 0x48u;  }
        mem.WriteU16((c.S1 + 0x2Eu), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x22u), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S3 + 0x4u)); 
        c.S1 = mem.ReadU32(c.S1); 
        { c.V0 = c.V0 - 0x1u;  }
        mem.WriteU16((c.S1 + 0xAu), (ushort)c.V0); 
        { c.V0 = 0u | 0x00F6u;  }
        mem.WriteU8((c.S1 + 0xCu), (byte)c.V0); 
        { c.V0 = 0u | 0x0018u;  }
        mem.WriteU16((c.S3 + 0xCu), (ushort)c.V0); 
        { c.V0 = 0u | 0x0005u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        mem.WriteU16((c.S2 + 0x2Eu), (ushort)0u); 
        goto L8018F86C;
        L8018EDE4: ;
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2C8Cu)); 
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x0018u;  }
            goto L8018E9E8;
        }
        { c.V0 = 0u | 0x0018u;  }
        c.At = 0x801A0000u; 
        mem.WriteU16((c.At - 0x2C78u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0006u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        goto L8018F86C;
        L8018EE0C: ;
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2C8Cu)); 
        if (c.V0 == 0u) {
            goto L8018F128;
        }
        L8018EE20: ;
        c.V0 = mem.ReadU32(c.S1); 
        { c.V0 = c.V0 + 0x2u;  }
        mem.WriteU32(c.S1, c.V0); 
        goto L8018E9E8;
        L8018EE34: ;
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2C8Cu)); 
        if (c.V0 != 0u) {
            goto L8018E9E8;
        }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3808u)); 
        c.RA = 0x8018EE5Cu;
        Dispatcher.Call(c, m, c.V0);
        if (c.V0 == 0u) {
            goto L8018EEA0;
        }
        goto L8018E9E8;
        L8018EE6C: ;
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2C8Cu)); 
        if (c.V0 != 0u) {
            goto L8018E9E8;
        }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3808u)); 
        c.RA = 0x8018EE94u;
        Dispatcher.Call(c, m, c.V0);
        { c.V1 = 0u | 0x0001u;  }
        if (c.V0 != c.V1) {
            goto L8018E9E8;
        }
        L8018EEA0: ;
        c.V0 = mem.ReadU32(c.S1); 
        { c.V0 = c.V0 - 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        goto L8018F86C;
        L8018EEB4: ;
        c.V1 = mem.ReadU32(c.S1); 
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.T1 = mem.ReadU8(c.V1); 
        { c.V0 = c.V1 + 0x2u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.A1 = mem.ReadU8((c.V1 + 0x1u)); 
        { c.V0 = c.V1 + 0x3u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.A0 = mem.ReadU8((c.V1 + 0x2u)); 
        { c.V0 = c.V1 + 0x4u;  }
        mem.WriteU32(c.S1, c.V0); 
        { c.T1 = c.T1 << 4;  }
        { var _s = c.T1; var _t = c.A1; c.T1 = _s | _t;  }
        { c.T1 = c.T1 << 4;  }
        { var _s = c.T1; var _t = c.A0; c.T1 = _s | _t;  }
        c.A0 = mem.ReadU8((c.V1 + 0x3u)); 
        { c.T1 = c.T1 << 4;  }
        { var _s = c.T1; var _t = c.A0; c.A0 = _s | _t;  }
        c.RA = 0x8018EF08u; 
        SoTN_cen.SetCutsceneEnd_cen(c, m);
        goto L8018E9E8;
        L8018EF10: ;
        c.V1 = mem.ReadU32(c.S1); 
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.T1 = mem.ReadU8(c.V1); 
        { c.V0 = c.V1 + 0x2u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.A0 = mem.ReadU8((c.V1 + 0x1u)); 
        { c.V0 = c.V1 + 0x3u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.V0 = mem.ReadU8((c.V1 + 0x2u)); 
        { c.A1 = c.V1 + 0x4u;  }
        mem.WriteU32(c.S1, c.A1); 
        { c.T1 = c.T1 << 4;  }
        { var _s = c.T1; var _t = c.A0; c.T1 = _s | _t;  }
        { c.T1 = c.T1 << 4;  }
        { var _s = c.T1; var _t = c.V0; c.T1 = _s | _t;  }
        c.V0 = mem.ReadU8((c.V1 + 0x3u)); 
        { c.T1 = c.T1 << 4;  }
        { var _s = c.T1; var _t = c.V0; c.T1 = _s | _t;  }
        c.V1 = mem.ReadU16(c.T1); 
        { c.V1 = c.V1 << 2;  }
        { var _s = c.V1; var _t = c.A1; c.V1 = _s + _t;  }
        goto L8018EF78;
        L8018EF74: ;
        c.V1 = mem.ReadU32(c.S1); 
        L8018EF78: ;
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.T1 = mem.ReadU8(c.V1); 
        { c.V0 = c.V1 + 0x2u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.A0 = mem.ReadU8((c.V1 + 0x1u)); 
        { c.V0 = c.V1 + 0x3u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.V0 = mem.ReadU8((c.V1 + 0x2u)); 
        c.V1 = 0x801A0000u; 
        c.V1 = mem.ReadU32((c.V1 - 0x2C88u)); 
        { c.T1 = c.T1 << 4;  }
        { var _s = c.T1; var _t = c.A0; c.T1 = _s | _t;  }
        { c.T1 = c.T1 << 4;  }
        { var _s = c.T1; var _t = c.V0; c.T1 = _s | _t;  }
        c.V0 = mem.ReadU8(c.V1); 
        { c.T1 = c.T1 << 4;  }
        { var _s = c.T1; var _t = c.V0; c.T1 = _s | _t;  }
        c.V0 = 0x00100000u; 
        { var _s = c.T1; var _t = c.V0; c.V0 = _s + _t;  }
        mem.WriteU32(c.S1, c.V0); 
        goto L8018E9E8;
        L8018EFD4: ;
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2C88u)); 
        c.A0 = 0x801A0000u; 
        c.A0 = mem.ReadU32((c.A0 - 0x2BDCu)); 
        c.V1 = mem.ReadU8(c.V0); 
        { var _s = c.V1; var _t = c.A0; c.V0 = _t >> (int)(_s & 31u);  }
        { c.V0 = c.V0 & 0x0001u;  }
        if (c.V0 == 0u) {
            goto L8018F800;
        }
        { c.V0 = 0u | 0x0001u;  }
        { var _s = c.V1; var _t = c.V0; c.V0 = _t << (int)(_s & 31u);  }
        { var _s = 0u; var _t = c.V0; c.V0 = ~(_s | _t);  }
        c.V1 = mem.ReadU32(c.S1); 
        { var _s = c.V0; var _t = c.A0; c.V0 = _s & _t;  }
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2BDCu), c.V0); 
        { c.V1 = c.V1 + 0x1u;  }
        mem.WriteU32(c.S1, c.V1); 
        goto L8018E9E8;
        L8018F024: ;
        c.V1 = mem.ReadU32(c.S1); 
        c.A0 = 0x801A0000u; 
        c.A0 = mem.ReadU32((c.A0 - 0x2BDCu)); 
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.V1 = mem.ReadU8(c.V1); 
        { c.V0 = 0u | 0x0001u;  }
        { var _s = c.V1; var _t = c.V0; c.V0 = _t << (int)(_s & 31u);  }
        { var _s = c.V0; var _t = c.A0; c.V0 = _s | _t;  }
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2BDCu), c.V0); 
        goto L8018E9E8;
        L8018F058: ;
        c.At = 0x801A0000u; 
        mem.WriteU16((c.At - 0x2C4Cu), (ushort)0u); 
        goto L8018E9E8;
        L8018F068: ;
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2C8Cu)); 
        if (c.V0 == 0u) {
            { c.A1 = 0u | 0x0001u;  }
            goto L8018F090;
        }
        { c.A1 = 0u | 0x0001u;  }
        c.V0 = mem.ReadU32(c.S1); 
        { c.V0 = c.V0 + 0x5u;  }
        mem.WriteU32(c.S1, c.V0); 
        goto L8018E9E8;
        L8018F090: ;
        c.V1 = mem.ReadU32(c.S1); 
        c.A2 = 0u; 
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.T1 = mem.ReadU8(c.V1); 
        { c.V0 = c.V1 + 0x2u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.T0 = mem.ReadU8((c.V1 + 0x1u)); 
        { c.V0 = c.V1 + 0x3u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.A3 = mem.ReadU8((c.V1 + 0x2u)); 
        { c.V0 = c.V1 + 0x4u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.A0 = mem.ReadU8((c.V1 + 0x3u)); 
        { c.V0 = c.V1 + 0x5u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.T2 = mem.ReadU8((c.V1 + 0x4u)); 
        { c.T1 = c.T1 << 4;  }
        { var _s = c.T1; var _t = c.T0; c.T1 = _s | _t;  }
        { c.T1 = c.T1 << 4;  }
        { var _s = c.T1; var _t = c.A3; c.T1 = _s | _t;  }
        { c.T1 = c.T1 << 4;  }
        { var _s = c.T1; var _t = c.A0; c.T1 = _s | _t;  }
        c.A0 = 0x00100000u; 
        { var _s = c.T1; var _t = c.A0; c.A0 = _s + _t;  }
        { c.V0 = c.T2 << 1;  }
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.A3 = mem.ReadU16((c.At + 0x5E8u)); 
        { c.V0 = 0u | 0x0100u;  }
        mem.WriteU32((c.SP + 0x10u), c.V0); 
        { c.V0 = 0u | 0x0030u;  }
        mem.WriteU32((c.SP + 0x14u), c.V0); 
        { c.V0 = 0u | 0x0048u;  }
        mem.WriteU32((c.SP + 0x18u), c.V0); 
        c.RA = 0x8018F120u; 
        SoTN_main.LoadTPage(c, m);
        goto L8018E9E8;
        L8018F128: ;
        c.V1 = mem.ReadU32(c.S1); 
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.A2 = mem.ReadU8(c.V1); 
        { c.V0 = c.V1 + 0x2u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.A0 = mem.ReadU8((c.V1 + 0x1u)); 
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3824u)); 
        { c.A1 = c.A2 << 4;  }
        { var _s = c.A0; var _t = c.A1; c.A0 = _s | _t;  }
        c.RA = 0x8018F15Cu;
        Dispatcher.Call(c, m, c.V0);
        goto L8018E9E8;
        L8018F164: ;
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2BDCu), 0u); 
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2C8Cu), 0u); 
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2BD8u), 0u); 
        goto L8018E9E8;
        L8018F184: ;
        c.V1 = mem.ReadU32(c.S1); 
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.V1 = mem.ReadU8(c.V1); 
        { c.V0 = 0u | 0x0001u;  }
        { var _s = c.V1; var _t = c.V0; c.V0 = _t << (int)(_s & 31u);  }
        c.V1 = 0x801A0000u; 
        c.V1 = mem.ReadU32((c.V1 - 0x2BDCu)); 
        { var _s = 0u; var _t = c.V0; c.V0 = ~(_s | _t);  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s & _t;  }
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2BDCu), c.V0); 
        goto L8018E9E8;
        L8018F1C0: ;
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2C88u)); 
        c.V1 = mem.ReadU8(c.V0); 
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2BDCu)); 
        { var _s = c.V1; var _t = c.V0; c.V0 = _t >> (int)(_s & 31u);  }
        { c.V0 = c.V0 & 0x0001u;  }
        if (c.V0 == 0u) {
            goto L8018F814;
        }
        c.V0 = mem.ReadU32(c.S1); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        goto L8018E9E8;
        L8018F200: ;
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2C8Cu)); 
        if (c.V0 != 0u) {
            goto L8018E9E8;
        }
        c.V0 = mem.ReadU8((c.S1 + 0x17u)); 
        mem.WriteU8((c.S1 + 0x16u), (byte)c.V0); 
        { c.V0 = 0u | 0x0020u;  }
        if (c.V1 != c.V0) {
            { c.A0 = c.SP + 0x20u;  }
            goto L8018F248;
        }
        { c.A0 = c.SP + 0x20u;  }
        c.V1 = 0x801A0000u; 
        { c.V1 = c.V1 - 0x2C7Eu;  }
        c.V0 = mem.ReadU16(c.V1); 
        { c.V0 = c.V0 + 0x2u;  }
        mem.WriteU16(c.V1, (ushort)c.V0); 
        goto L8018F86C;
        L8018F248: ;
        { c.V0 = c.A2 & 0x000Fu;  }
        { c.V0 = c.V0 << 1;  }
        { c.V0 = c.V0 + 0x380u;  }
        mem.WriteU16((c.SP + 0x20u), (ushort)c.V0); 
        { c.V0 = c.A2 & 0x00F0u;  }
        { c.V0 = c.V0 >> 1;  }
        c.A1 = 0x801A0000u; 
        c.A1 = (uint)(short)mem.ReadU16((c.A1 - 0x2C7Eu)); 
        c.V1 = 0x801A0000u; 
        c.V1 = (uint)(short)mem.ReadU16((c.V1 - 0x2C7Au)); 
        { c.V0 = c.V0 + 0xF0u;  }
        mem.WriteU16((c.SP + 0x22u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0002u;  }
        mem.WriteU16((c.SP + 0x24u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0008u;  }
        mem.WriteU16((c.SP + 0x26u), (ushort)c.V0); 
        { c.A2 = c.V1 << 1;  }
        { var _s = c.A2; var _t = c.V1; c.A2 = _s + _t;  }
        { c.A2 = c.A2 << 2;  }
        { c.A2 = c.A2 + 0x180u;  }
        { c.A2 = c.A2 << 16;  }
        { c.A2 = (uint)((int)c.A2 >> 16);  }
        c.RA = 0x8018F2A4u; 
        if (!DialogueGlyphs.Draw(c, mem)) SoTN_main.MoveImage(c, m);
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU16((c.V0 - 0x2C7Eu)); 
        { c.V0 = c.V0 + 0x2u;  }
        c.At = 0x801A0000u; 
        mem.WriteU16((c.At - 0x2C7Eu), (ushort)c.V0); 
        goto L8018F86C;
        L8018F2C4: ;
        { c.A0 = 0u | 0x0002u;  }
        c.RA = 0x8018F2CCu; 
        SoTN_cen.ScaleCutsceneAvatar_cen(c, m);
        c.V0 = 0x801A0000u; 
        c.V0 = (uint)(short)mem.ReadU16((c.V0 - 0x2C78u)); 
        { c.V0 = (int)c.V0 < 6 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L8018F86C;
        }
        c.V0 = mem.ReadU16((c.S2 + 0x2Cu)); 
        { c.V0 = c.V0 - 0x1u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        goto L8018F86C;
        L8018F2F8: ;
        c.S1 = 0x801A0000u; 
        c.S1 = mem.ReadU32((c.S1 - 0x2C5Cu)); 
        c.V0 = mem.ReadU16((c.S1 + 0x20u)); 
        c.A0 = mem.ReadU16((c.S1 + 0x2Cu)); 
        c.V1 = mem.ReadU16((c.S1 + 0x16u)); 
        c.A1 = mem.ReadU16((c.S1 + 0x2Eu)); 
        { c.V0 = c.V0 - 0x4u;  }
        { c.A0 = c.A0 + 0x4u;  }
        { c.V1 = c.V1 - 0x6u;  }
        { c.A1 = c.A1 + 0x6u;  }
        mem.WriteU16((c.S1 + 0x20u), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x8u), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x2Cu), (ushort)c.A0); 
        mem.WriteU16((c.S1 + 0x14u), (ushort)c.A0); 
        mem.WriteU16((c.S1 + 0x16u), (ushort)c.V1); 
        mem.WriteU16((c.S1 + 0xAu), (ushort)c.V1); 
        mem.WriteU16((c.S1 + 0x2Eu), (ushort)c.A1); 
        mem.WriteU16((c.S1 + 0x22u), (ushort)c.A1); 
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU16((c.V0 - 0x2C78u)); 
        { c.V0 = c.V0 - 0x1u;  }
        c.At = 0x801A0000u; 
        mem.WriteU16((c.At - 0x2C78u), (ushort)c.V0); 
        { c.V0 = c.V0 << 16;  }
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x0001u;  }
            goto L8018F86C;
        }
        { c.V0 = 0u | 0x0001u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        c.V1 = 0x801A0000u; 
        c.V1 = mem.ReadU32((c.V1 - 0x2C54u)); 
        { c.V0 = c.V1 << 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.V1 = 0x80080000u; 
        { c.V1 = c.V1 + 0x6FECu;  }
        { var _s = c.V0; var _t = c.V1; c.S1 = _s + _t;  }
        if (c.S1 == 0u) {
            goto L8018F86C;
        }
        mem.WriteU16((c.S1 + 0x32u), (ushort)0u); 
        L8018F3A4: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.S1 = mem.ReadU32(c.S1); 
        if (c.S1 == 0u) {
            goto L8018F86C;
        }
        mem.WriteU16((c.S1 + 0x32u), (ushort)0u); 
        goto L8018F3A4;
        L8018F3BC: ;
        c.S1 = 0x801A0000u; 
        c.S1 = mem.ReadU32((c.S1 - 0x2C5Cu)); 
        c.V0 = mem.ReadU16((c.S1 + 0x20u)); 
        c.A0 = mem.ReadU16((c.S1 + 0x2Cu)); 
        c.V1 = mem.ReadU16((c.S1 + 0x16u)); 
        c.A1 = mem.ReadU16((c.S1 + 0x2Eu)); 
        { c.V0 = c.V0 + 0x4u;  }
        { c.A0 = c.A0 - 0x4u;  }
        { c.V1 = c.V1 + 0x6u;  }
        { c.A1 = c.A1 - 0x6u;  }
        mem.WriteU16((c.S1 + 0x20u), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x8u), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x2Cu), (ushort)c.A0); 
        mem.WriteU16((c.S1 + 0x14u), (ushort)c.A0); 
        mem.WriteU16((c.S1 + 0x16u), (ushort)c.V1); 
        mem.WriteU16((c.S1 + 0xAu), (ushort)c.V1); 
        mem.WriteU16((c.S1 + 0x2Eu), (ushort)c.A1); 
        mem.WriteU16((c.S1 + 0x22u), (ushort)c.A1); 
        c.V1 = 0x801A0000u; 
        c.V1 = (uint)(short)mem.ReadU16((c.V1 - 0x2C84u)); 
        c.V0 = (uint)(short)mem.ReadU16((c.S1 + 0x14u)); 
        c.A0 = c.V1; 
        { c.V1 = c.V1 - 0x2u;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = (int)_s < (int)_t ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L8018F434;
        }
        { c.V0 = c.A0 - 0x3u;  }
        mem.WriteU16((c.S1 + 0x2Cu), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x14u), (ushort)c.V0); 
        L8018F434: ;
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU16((c.V0 - 0x2C78u)); 
        { c.V0 = c.V0 - 0x1u;  }
        c.At = 0x801A0000u; 
        mem.WriteU16((c.At - 0x2C78u), (ushort)c.V0); 
        { c.V0 = c.V0 << 16;  }
        goto L8018F734;
        L8018F454: ;
        c.V1 = mem.ReadU16((c.S2 + 0x2Eu)); 
        { c.A2 = 0u | 0x0001u;  }
        if (c.V1 == c.A2) {
            { c.V0 = (int)c.V1 < 2 ? 1u : 0u;  }
            goto L8018F580;
        }
        { c.V0 = (int)c.V1 < 2 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L8018F47C;
        }
        if (c.V1 == 0u) {
            { c.A0 = 0u | 0x0002u;  }
            goto L8018F490;
        }
        { c.A0 = 0u | 0x0002u;  }
        goto L8018F86C;
        L8018F47C: ;
        { c.V0 = 0u | 0x0002u;  }
        if (c.V1 == c.V0) {
            goto L8018F67C;
        }
        goto L8018F86C;
        L8018F490: ;
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3848u)); 
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2BD8u), c.A2); 
        { c.A1 = 0u | 0x0048u;  }
        c.RA = 0x8018F4A8u;
        Dispatcher.Call(c, m, c.V0);
        { c.V0 = c.V0 << 16;  }
        { c.V1 = (uint)((int)c.V0 >> 16);  }
        c.V0 = 0xFFFFFFFFu; 
        if (c.V1 != c.V0) {
            { c.V0 = c.V1 << 1;  }
            goto L8018F4CC;
        }
        { c.V0 = c.V1 << 1;  }
        L8018F4BC: ;
        c.A0 = c.S2; 
        c.RA = 0x8018F4C4u; 
        SoTN_cen.DestroyEntity_cen(c, m);
        goto L8018F86C;
        L8018F4CC: ;
        c.A2 = 0x801A0000u; 
        { c.A2 = c.A2 - 0x2C58u;  }
        mem.WriteU32(c.A2, c.V1); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.V1 = 0x80080000u; 
        { c.V1 = c.V1 + 0x6FECu;  }
        { var _s = c.V0; var _t = c.V1; c.S1 = _s + _t;  }
        if (c.S1 == 0u) {
            c.A0 = 0u; 
            goto L8018F668;
        }
        c.A0 = 0u; 
        { c.A1 = 0u | 0x007Fu;  }
        { c.V1 = 0u | 0x00F7u;  }
        { c.T1 = c.A2 - 0x28u;  }
        { c.T0 = 0u | 0x01FEu;  }
        c.A3 = 0x80180000u; 
        { c.A3 = c.A3 + 0x5F4u;  }
        { c.A2 = 0u | 0x0F70u;  }
        L8018F518: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        mem.WriteU8((c.S1 + 0x10u), (byte)c.A1); 
        mem.WriteU8((c.S1 + 0x4u), (byte)c.A1); 
        mem.WriteU8((c.S1 + 0x11u), (byte)0u); 
        mem.WriteU8((c.S1 + 0x5u), (byte)0u); 
        mem.WriteU8((c.S1 + 0x12u), (byte)0u); 
        mem.WriteU8((c.S1 + 0x6u), (byte)0u); 
        mem.WriteU16((c.S1 + 0x14u), (ushort)c.V1); 
        mem.WriteU16((c.S1 + 0x8u), (ushort)c.V1); 
        c.V0 = mem.ReadU16(c.T1); 
        mem.WriteU16((c.S1 + 0x26u), (ushort)c.T0); 
        mem.WriteU16((c.S1 + 0x32u), (ushort)0u); 
        { var _s = c.A0; var _t = c.V0; c.V0 = _s + _t;  }
        mem.WriteU16((c.S1 + 0x16u), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0xAu), (ushort)c.V0); 
        { c.V0 = c.A0 << 16;  }
        { c.V0 = (uint)((int)c.V0 >> 15);  }
        { var _s = c.V0; var _t = c.A3; c.V0 = _s + _t;  }
        c.V0 = mem.ReadU16(c.V0); 
        mem.WriteU16((c.S1 + 0x2Cu), (ushort)c.A2); 
        mem.WriteU16((c.S1 + 0x20u), (ushort)c.V0); 
        c.S1 = mem.ReadU32(c.S1); 
        if (c.S1 != 0u) {
            { c.A0 = c.A0 + 0x1u;  }
            goto L8018F518;
        }
        { c.A0 = c.A0 + 0x1u;  }
        goto L8018F668;
        L8018F580: ;
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2C58u)); 
        { c.V1 = c.V0 << 1;  }
        { var _s = c.V1; var _t = c.V0; c.V1 = _s + _t;  }
        { c.V1 = c.V1 << 2;  }
        { var _s = c.V1; var _t = c.V0; c.V1 = _s + _t;  }
        { c.V1 = c.V1 << 2;  }
        c.V0 = 0x80080000u; 
        { c.V0 = c.V0 + 0x6FECu;  }
        { var _s = c.V1; var _t = c.V0; c.S1 = _s + _t;  }
        if (c.S1 == 0u) {
            c.A0 = 0u; 
            goto L8018F614;
        }
        c.A0 = 0u; 
        { c.A1 = 0u | 0x0004u;  }
        L8018F5B8: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V0 = mem.ReadU16((c.S1 + 0x2Cu)); 
        c.V1 = mem.ReadU16((c.S1 + 0x20u)); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s - _t;  }
        mem.WriteU16((c.S1 + 0x2Cu), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S1 + 0x20u)); 
        c.V1 = (uint)(short)mem.ReadU16((c.S1 + 0x2Cu)); 
        { c.V0 = c.V0 + 0x2u;  }
        if ((int)c.V1 >= 0) {
            mem.WriteU16((c.S1 + 0x20u), (ushort)c.V0); 
            goto L8018F5E4;
        }
        mem.WriteU16((c.S1 + 0x20u), (ushort)c.V0); 
        { c.V1 = c.V1 + 0xFu;  }
        L8018F5E4: ;
        { c.V0 = (uint)((int)c.V1 >> 4);  }
        mem.WriteU16((c.S1 + 0x8u), (ushort)c.V0); 
        { c.V0 = (int)c.V0 < 5 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L8018F600;
        }
        mem.WriteU16((c.S1 + 0x8u), (ushort)c.A1); 
        goto L8018F604;
        L8018F600: ;
        { c.A0 = 0u | 0x0001u;  }
        L8018F604: ;
        c.S1 = mem.ReadU32(c.S1); 
        if (c.S1 != 0u) {
            goto L8018F5B8;
        }
        L8018F614: ;
        { c.V0 = c.A0 << 16;  }
        if (c.V0 != 0u) {
            goto L8018F86C;
        }
        c.S0 = 0x801A0000u; 
        { c.S0 = c.S0 - 0x2C58u;  }
        c.A0 = mem.ReadU32(c.S0); 
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x384Cu)); 
        c.RA = 0x8018F640u;
        Dispatcher.Call(c, m, c.V0);
        c.S1 = 0x801A0000u; 
        c.S1 = mem.ReadU32((c.S1 - 0x2C5Cu)); 
        c.V0 = 0xFFFFFFFFu; 
        mem.WriteU32(c.S0, c.V0); 
        c.S1 = mem.ReadU32(c.S1); 
        { c.V0 = 0u | 0x0011u;  }
        mem.WriteU16((c.S1 + 0x32u), (ushort)c.V0); 
        c.S1 = mem.ReadU32(c.S1); 
        { c.V0 = 0u | 0x0051u;  }
        mem.WriteU16((c.S1 + 0x32u), (ushort)c.V0); 
        L8018F668: ;
        c.V0 = mem.ReadU16((c.S2 + 0x2Eu)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S2 + 0x2Eu), (ushort)c.V0); 
        goto L8018F86C;
        L8018F67C: ;
        c.S1 = 0x801A0000u; 
        c.S1 = mem.ReadU32((c.S1 - 0x2C5Cu)); 
        c.S1 = mem.ReadU32(c.S1); 
        c.V0 = mem.ReadU8((c.S1 + 0x4u)); 
        { c.V0 = c.V0 < 0x00000010u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            c.A0 = 0u; 
            goto L8018F6B8;
        }
        c.A0 = 0u; 
        mem.WriteU8((c.S1 + 0x28u), (byte)0u); 
        mem.WriteU8((c.S1 + 0x1Cu), (byte)0u); 
        mem.WriteU8((c.S1 + 0x10u), (byte)0u); 
        mem.WriteU8((c.S1 + 0x4u), (byte)0u); 
        goto L8018F6D4;
        L8018F6B8: ;
        c.V0 = mem.ReadU8((c.S1 + 0x28u)); 
        { c.A0 = 0u | 0x0001u;  }
        { c.V0 = c.V0 - 0x10u;  }
        mem.WriteU8((c.S1 + 0x28u), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0x1Cu), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0x10u), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0x4u), (byte)c.V0); 
        L8018F6D4: ;
        c.V0 = mem.ReadU8((c.S1 + 0x6u)); 
        { c.V0 = c.V0 < 0x0000007Fu ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.V0 = 0u | 0x007Fu;  }
            goto L8018F6F4;
        }
        { c.V0 = 0u | 0x007Fu;  }
        c.V0 = mem.ReadU8((c.S1 + 0x12u)); 
        { c.A0 = 0u | 0x0001u;  }
        { c.V0 = c.V0 + 0x8u;  }
        L8018F6F4: ;
        mem.WriteU8((c.S1 + 0x12u), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0x6u), (byte)c.V0); 
        c.S1 = mem.ReadU32(c.S1); 
        c.V0 = mem.ReadU8((c.S1 + 0x4u)); 
        { c.V0 = c.V0 < 0x00000010u ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x0010u;  }
            goto L8018F724;
        }
        { c.V0 = 0u | 0x0010u;  }
        c.V0 = mem.ReadU8((c.S1 + 0x6u)); 
        { c.A0 = 0u | 0x0001u;  }
        { c.V0 = c.V0 - 0xFu;  }
        L8018F724: ;
        mem.WriteU8((c.S1 + 0x6u), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0x5u), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0x4u), (byte)c.V0); 
        { c.V0 = c.A0 << 16;  }
        L8018F734: ;
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x0001u;  }
            goto L8018F86C;
        }
        { c.V0 = 0u | 0x0001u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        goto L8018F86C;
        L8018F744: ;
        c.S1 = 0x801A0000u; 
        c.S1 = mem.ReadU32((c.S1 - 0x2C5Cu)); 
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU16((c.V0 - 0x2C78u)); 
        c.S1 = mem.ReadU32(c.S1); 
        { c.V0 = c.V0 - 0x1u;  }
        c.At = 0x801A0000u; 
        mem.WriteU16((c.At - 0x2C78u), (ushort)c.V0); 
        { c.V0 = c.V0 << 16;  }
        { c.V1 = (uint)((int)c.V0 >> 16);  }
        { c.V0 = (int)c.V1 < 12 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L8018F7B0;
        }
        c.S1 = mem.ReadU32(c.S1); 
        c.V1 = mem.ReadU8((c.S1 + 0xCu)); 
        { c.V0 = c.V1 + 0xECu;  }
        mem.WriteU8((c.S1 + 0xCu), (byte)c.V0); 
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU16((c.V0 - 0x2C78u)); 
        { c.V0 = c.V0 & 0x0001u;  }
        if (c.V0 == 0u) {
            { c.V0 = c.V1 - 0x15u;  }
            goto L8018F86C;
        }
        { c.V0 = c.V1 - 0x15u;  }
        mem.WriteU8((c.S1 + 0xCu), (byte)c.V0); 
        goto L8018F86C;
        L8018F7B0: ;
        if (c.V1 != 0u) {
            { c.V0 = 0u | 0x0001u;  }
            goto L8018F7C8;
        }
        { c.V0 = 0u | 0x0001u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        { c.V0 = 0u | 0x0008u;  }
        mem.WriteU16((c.S1 + 0x32u), (ushort)c.V0); 
        goto L8018F7DC;
        L8018F7C8: ;
        c.V0 = mem.ReadU16((c.S1 + 0x2Eu)); 
        { c.V0 = c.V0 - 0x6u;  }
        mem.WriteU16((c.S1 + 0x2Eu), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x22u), (ushort)c.V0); 
        L8018F7DC: ;
        c.S1 = mem.ReadU32(c.S1); 
        { c.V0 = 0u | 0x0008u;  }
        mem.WriteU16((c.S1 + 0x32u), (ushort)c.V0); 
        goto L8018F86C;
        L8018F7EC: ;
        c.V0 = mem.ReadU8(c.S4); 
        { c.V0 = c.V0 - 0x1u;  }
        mem.WriteU8(c.S4, (byte)c.V0); 
        goto L8018F86C;
        L8018F800: ;
        c.V1 = 0x801A0000u; 
        { c.V1 = c.V1 - 0x2C88u;  }
        c.V0 = mem.ReadU32(c.V1); 
        { c.V0 = c.V0 - 0x1u;  }
        goto L8018F868;
        L8018F814: ;
        c.V1 = 0x801A0000u; 
        { c.V1 = c.V1 - 0x2C88u;  }
        c.V0 = mem.ReadU32(c.V1); 
        { c.V0 = c.V0 - 0x1u;  }
        goto L8018F868;
        L8018F828: ;
        c.A0 = c.S2; 
        c.RA = 0x8018F830u; 
        SoTN_cen.DestroyEntity_cen(c, m);
        { c.A0 = 0u | 0x0018u;  }
        c.V1 = 0x80040000u; 
        c.V1 = mem.ReadU32((c.V1 - 0x37C0u)); 
        { c.V0 = 0u | 0x0001u;  }
        c.At = 0x80040000u; 
        mem.WriteU8((c.At - 0x413Cu), (byte)c.V0); 
        { c.A1 = 0u | 0x0001u;  }
        c.RA = 0x8018F850u;
        Dispatcher.Call(c, m, c.V1);
        c.V1 = 0x80040000u; 
        { c.V1 = c.V1 - 0x34FCu;  }
        c.V0 = mem.ReadU32(c.V1); 
        c.At = 0x80040000u; 
        mem.WriteU32((c.At - 0x38FCu), 0u); 
        { c.V0 = c.V0 | 0x0800u;  }
        L8018F868: ;
        mem.WriteU32(c.V1, c.V0); 
        L8018F86C: ;
        c.RA = mem.ReadU32((c.SP + 0x44u)); 
        c.S4 = mem.ReadU32((c.SP + 0x40u)); 
        c.S3 = mem.ReadU32((c.SP + 0x3Cu)); 
        c.S2 = mem.ReadU32((c.SP + 0x38u)); 
        c.S1 = mem.ReadU32((c.SP + 0x34u)); 
        c.S0 = mem.ReadU32((c.SP + 0x30u)); 
        { c.SP = c.SP + 0x48u;  }
        return;
        c.A1 = 0x80070000u; 
        { c.A1 = c.A1 + 0x30CCu;  }
        c.V0 = mem.ReadU16(c.A1); 
        { var _s = c.A0; var _t = c.V0; c.V0 = _s - _t;  }
        { c.V0 = c.V0 << 16;  }
        { c.V1 = (uint)((int)c.V0 >> 16);  }
        { c.V0 = (int)c.V1 < 2 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L8018F8C4;
        }
        c.V0 = mem.ReadU32(c.A1); 
        { c.V0 = c.V0 + 0x1u;  }
        goto L8018F8E4;
        L8018F8C4: ;
        { c.V0 = (int)c.V1 < -1 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L8018F8DC;
        }
        c.V0 = mem.ReadU32(c.A1); 
        { c.V0 = c.V0 - 0x1u;  }
        goto L8018F8E4;
        L8018F8DC: ;
        { c.V0 = c.A0 << 16;  }
        { c.V0 = (uint)((int)c.V0 >> 16);  }
        L8018F8E4: ;
        mem.WriteU32(c.A1, c.V0); 
        return;
        c.T2 = 0x80070000u; 
        { c.T2 = c.T2 + 0x3084u;  }
        { c.T0 = 0u | 0x05B6u;  }
        { c.A0 = c.A0 & 0xFFFFu;  }
        { c.A0 = c.A0 << 4;  }
        c.V0 = 0x80180000u; 
        { c.V0 = c.V0 + 0x68Cu;  }
        { var _s = c.A0; var _t = c.V0; c.A3 = _s + _t;  }
        c.T1 = 0u; 
        L8018F910: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.A1 = 0u; 
        L8018F914: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.A0 = mem.ReadU16(c.A3); 
        { c.A3 = c.A3 + 0x2u;  }
        { c.V0 = c.T0 & 0xFFFFu;  }
        { c.A2 = c.T0 + 0x1u;  }
        { c.A1 = c.A1 + 0x1u;  }
        c.V1 = mem.ReadU32(c.T2); 
        { c.V0 = c.V0 << 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        mem.WriteU16(c.V0, (ushort)c.A0); 
        { c.V0 = (int)c.A1 < 4 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            c.T0 = c.A2; 
            goto L8018F914;
        }
        c.T0 = c.A2; 
        { c.T1 = c.T1 + 0x1u;  }
        { c.V0 = (int)c.T1 < 2 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.T0 = c.A2 + 0x2Cu;  }
            goto L8018F910;
        }
        { c.T0 = c.A2 + 0x2Cu;  }
        return;
        { c.SP = c.SP - 0x28u;  }
        mem.WriteU32((c.SP + 0x10u), c.S0); 
        c.S0 = c.A0; 
        { c.A1 = 0u | 0x0020u;  }
        { c.A2 = 0u | 0x0011u;  }
        mem.WriteU32((c.SP + 0x20u), c.RA); 
        mem.WriteU32((c.SP + 0x1Cu), c.S3); 
        mem.WriteU32((c.SP + 0x18u), c.S2); 
        mem.WriteU32((c.SP + 0x14u), c.S1); 
        c.V0 = mem.ReadU16((c.S0 + 0x6u)); 
        { c.A3 = 0u | 0x0004u;  }
        { c.V0 = c.V0 - 0x8u;  }
        mem.WriteU16((c.S0 + 0x6u), (ushort)c.V0); 
        c.RA = 0x8018F994u; 
        SoTN_cen.GetPlayerCollisionWith_cen(c, m);
        c.S3 = 0x80070000u; 
        { c.S3 = c.S3 + 0x3084u;  }
        c.S2 = 0x80070000u; 
        { c.S2 = c.S2 + 0x33D8u;  }
        c.A1 = c.V0; 
        c.V1 = 0x80070000u; 
        c.V1 = mem.ReadU16((c.V1 + 0x33DAu)); 
        c.A0 = 0x80070000u; 
        c.A0 = mem.ReadU16((c.A0 + 0x308Eu)); 
        c.V0 = mem.ReadU16((c.S0 + 0x6u)); 
        { var _s = c.V1; var _t = c.A0; c.V1 = _s + _t;  }
        c.S1 = c.V1; 
        c.A0 = 0x80070000u; 
        c.A0 = mem.ReadU16((c.A0 + 0x3092u)); 
        c.V1 = mem.ReadU16((c.S0 + 0x2Cu)); 
        { var _s = c.V0; var _t = c.A0; c.V0 = _s + _t;  }
        c.A0 = c.V0; 
        { c.V0 = c.V1 < 0x0000000Au ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.V0 = c.V1 << 2;  }
            goto L8018FFE8;
        }
        { c.V0 = c.V1 << 2;  }
        c.At = 0x80190000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.V0 = mem.ReadU32((c.At - 0x2B50u)); 
        switch (c.V0)
        {
            case 0x8018F9FCu: goto L8018F9FC;
            case 0x8018FAF4u: goto L8018FAF4;
            case 0x8018FBF4u: goto L8018FBF4;
            case 0x8018FCBCu: goto L8018FCBC;
            case 0x8018FD9Cu: goto L8018FD9C;
            case 0x8018FE60u: goto L8018FE60;
            case 0x8018FEC8u: goto L8018FEC8;
            case 0x8018FF0Cu: goto L8018FF0C;
            case 0x8018FFC0u: goto L8018FFC0;
            case 0x8018FFE8u: goto L8018FFE8;
            default: Dispatcher.Call(c, m, c.V0); return;
        }
        L8018F9FC: ;
        { c.A0 = 0u | 0x0004u;  }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3848u)); 
        { c.A1 = 0u | 0x0001u;  }
        c.RA = 0x8018FA14u;
        Dispatcher.Call(c, m, c.V0);
        { c.V0 = c.V0 << 16;  }
        { c.S1 = (uint)((int)c.V0 >> 16);  }
        c.V0 = 0xFFFFFFFFu; 
        if (c.S1 == c.V0) {
            goto L8018FFE8;
        }
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x434u;  }
        c.RA = 0x8018FA38u; 
        SoTN_cen.InitializeEntity_cen(c, m);
        c.V0 = 0xFFFF8002u; 
        { c.V1 = 0u | 0x0009u;  }
        mem.WriteU16((c.S0 + 0x54u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0080u;  }
        mem.WriteU16((c.S0 + 0x56u), (ushort)c.V1); 
        mem.WriteU16((c.S0 + 0x24u), (ushort)c.V0); 
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU8((c.V0 - 0x413Cu)); 
        if (c.V0 == 0u) {
            goto L8018FA68;
        }
        mem.WriteU16((c.S0 + 0x2Cu), (ushort)c.V1); 
        L8018FA68: ;
        c.A0 = 0u; 
        c.RA = 0x8018FA70u; 
        SoTN_cen.func_8018F8EC(c, m);
        { c.V0 = c.S1 << 1;  }
        { var _s = c.V0; var _t = c.S1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.S1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.V1 = 0x80080000u; 
        { c.V1 = c.V1 + 0x6FECu;  }
        { var _s = c.V0; var _t = c.V1; c.A1 = _s + _t;  }
        c.V0 = mem.ReadU32((c.S0 + 0x34u)); 
        c.V1 = 0x00800000u; 
        mem.WriteU32((c.S0 + 0x64u), c.S1); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s | _t;  }
        mem.WriteU32((c.S0 + 0x34u), c.V0); 
        { c.V0 = 0u | 0x000Fu;  }
        { c.V1 = 0u | 0x0002u;  }
        mem.WriteU16((c.A1 + 0x1Au), (ushort)c.V0); 
        { c.V0 = 0u | 0x00A0u;  }
        mem.WriteU8((c.A1 + 0x24u), (byte)c.V0); 
        mem.WriteU8((c.A1 + 0xCu), (byte)c.V0); 
        { c.V0 = 0u | 0x00B0u;  }
        mem.WriteU8((c.A1 + 0x30u), (byte)c.V0); 
        mem.WriteU8((c.A1 + 0x18u), (byte)c.V0); 
        { c.V0 = 0u | 0x00A1u;  }
        mem.WriteU8((c.A1 + 0x19u), (byte)c.V0); 
        mem.WriteU8((c.A1 + 0xDu), (byte)c.V0); 
        { c.V0 = 0u | 0x00A7u;  }
        mem.WriteU8((c.A1 + 0x31u), (byte)c.V0); 
        mem.WriteU8((c.A1 + 0x25u), (byte)c.V0); 
        { c.V0 = 0u | 0x007Fu;  }
        mem.WriteU16((c.A1 + 0xEu), (ushort)c.V1); 
        mem.WriteU16((c.A1 + 0x26u), (ushort)c.V0); 
        mem.WriteU16((c.A1 + 0x32u), (ushort)c.V1); 
        goto L8018FFE8;
        L8018FAF4: ;
        c.RA = 0x8018FAFCu; 
        SoTN_cen.GetDistanceToPlayerX_cen(c, m);
        { c.V0 = (int)c.V0 < 32 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L8018FFE8;
        }
        c.V0 = (uint)(short)mem.ReadU16((c.S0 + 0x6u)); 
        c.V1 = (uint)(short)mem.ReadU16((c.S2 + 0x6u)); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s - _t;  }
        { c.V0 = (int)c.V0 < 80 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.V0 = 0u | 0x0001u;  }
            goto L8018FFE8;
        }
        { c.V0 = 0u | 0x0001u;  }
        c.V1 = 0x80070000u; 
        c.V1 = mem.ReadU32((c.V1 + 0x2F2Cu)); 
        c.At = 0x80040000u; 
        mem.WriteU32((c.At - 0x3748u), 0u); 
        c.At = 0x80090000u; 
        mem.WriteU32((c.At + 0x7400u), c.V0); 
        { c.V0 = c.V1 & 0x0001u;  }
        if (c.V0 == 0u) {
            { c.V0 = 0u | 0x0008u;  }
            goto L8018FB58;
        }
        { c.V0 = 0u | 0x0008u;  }
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x2EF4u), c.V0); 
        { c.V0 = 0u | 0x0001u;  }
        goto L8018FBDC;
        L8018FB58: ;
        { c.V0 = c.V1 & 0x0002u;  }
        if (c.V0 == 0u) {
            { c.V0 = 0u | 0x0004u;  }
            goto L8018FB74;
        }
        { c.V0 = 0u | 0x0004u;  }
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x2EF4u), c.V0); 
        { c.V0 = 0u | 0x0001u;  }
        goto L8018FBDC;
        L8018FB74: ;
        { c.V0 = c.V1 & 0x0004u;  }
        if (c.V0 == 0u) {
            { c.V0 = 0u | 0x0002u;  }
            goto L8018FB90;
        }
        { c.V0 = 0u | 0x0002u;  }
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x2EF4u), c.V0); 
        { c.V0 = 0u | 0x0001u;  }
        goto L8018FBDC;
        L8018FB90: ;
        { c.V0 = c.S1 << 16;  }
        { c.V1 = (uint)((int)c.V0 >> 16);  }
        { c.V0 = (int)c.V1 < 385 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.V0 = (int)c.V1 < 384 ? 1u : 0u;  }
            goto L8018FBB8;
        }
        { c.V0 = (int)c.V1 < 384 ? 1u : 0u;  }
        { c.V0 = 0u | 0x8000u;  }
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x2EF4u), c.V0); 
        { c.V0 = 0u | 0x0001u;  }
        goto L8018FBDC;
        L8018FBB8: ;
        if (c.V0 == 0u) {
            { c.V0 = 0u | 0x2000u;  }
            goto L8018FBD0;
        }
        { c.V0 = 0u | 0x2000u;  }
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x2EF4u), c.V0); 
        { c.V0 = 0u | 0x0001u;  }
        goto L8018FBDC;
        L8018FBD0: ;
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x2EF4u), 0u); 
        { c.V0 = 0u | 0x0001u;  }
        L8018FBDC: ;
        c.At = 0x80070000u; 
        mem.WriteU8((c.At + 0x3510u), (byte)0u); 
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x2EFCu), c.V0); 
        goto L8018FFD8;
        L8018FBF4: ;
        c.V1 = 0x80070000u; 
        c.V1 = mem.ReadU32((c.V1 + 0x2F2Cu)); 
        c.A0 = 0x80070000u; 
        { c.A0 = c.A0 + 0x2EF4u;  }
        { c.V0 = c.V1 & 0x0007u;  }
        if (c.V0 == 0u) {
            mem.WriteU32(c.A0, 0u); 
            goto L8018FC60;
        }
        mem.WriteU32(c.A0, 0u); 
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3668u)); 
        { c.V0 = c.V0 & 0x0001u;  }
        if (c.V0 == 0u) {
            { c.V0 = c.V1 & 0x0001u;  }
            goto L8018FD88;
        }
        { c.V0 = c.V1 & 0x0001u;  }
        if (c.V0 == 0u) {
            { c.V0 = 0u | 0x0008u;  }
            goto L8018FC38;
        }
        { c.V0 = 0u | 0x0008u;  }
        mem.WriteU32(c.A0, c.V0); 
        goto L8018FD88;
        L8018FC38: ;
        { c.V0 = c.V1 & 0x0002u;  }
        if (c.V0 == 0u) {
            { c.V0 = 0u | 0x0004u;  }
            goto L8018FC4C;
        }
        { c.V0 = 0u | 0x0004u;  }
        mem.WriteU32(c.A0, c.V0); 
        goto L8018FD88;
        L8018FC4C: ;
        { c.V0 = c.V1 & 0x0004u;  }
        if (c.V0 == 0u) {
            { c.V0 = 0u | 0x0002u;  }
            goto L8018FD88;
        }
        { c.V0 = 0u | 0x0002u;  }
        mem.WriteU32(c.A0, c.V0); 
        goto L8018FD88;
        L8018FC60: ;
        { c.V0 = c.A1 & 0xFFFFu;  }
        if (c.V0 != 0u) {
            { c.V0 = c.S1 << 16;  }
            goto L8018FC84;
        }
        { c.V0 = c.S1 << 16;  }
        c.V0 = 0x80070000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x2F20u)); 
        { c.V0 = c.V0 & 0x0001u;  }
        if (c.V0 == 0u) {
            { c.V0 = c.S1 << 16;  }
            goto L8018FD88;
        }
        { c.V0 = c.S1 << 16;  }
        L8018FC84: ;
        { c.V1 = (uint)((int)c.V0 >> 16);  }
        { c.V0 = (int)c.V1 < 385 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.V0 = (int)c.V1 < 384 ? 1u : 0u;  }
            goto L8018FC9C;
        }
        { c.V0 = (int)c.V1 < 384 ? 1u : 0u;  }
        { c.V0 = 0u | 0x8000u;  }
        goto L8018FCA4;
        L8018FC9C: ;
        if (c.V0 == 0u) {
            { c.V0 = 0u | 0x2000u;  }
            goto L8018FCA8;
        }
        { c.V0 = 0u | 0x2000u;  }
        L8018FCA4: ;
        mem.WriteU32(c.A0, c.V0); 
        L8018FCA8: ;
        c.V0 = mem.ReadU16((c.S0 + 0x2Cu)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S0 + 0x2Cu), (ushort)c.V0); 
        goto L8018FD88;
        L8018FCBC: ;
        c.A0 = 0x80070000u; 
        { c.A0 = c.A0 + 0x2EF4u;  }
        c.V1 = mem.ReadU32(c.A0); 
        { c.V0 = 0u | 0x8000u;  }
        if (c.V1 != c.V0) {
            { c.V0 = 0u | 0x2000u;  }
            goto L8018FCF0;
        }
        { c.V0 = 0u | 0x2000u;  }
        { c.V0 = c.S1 << 16;  }
        { c.V0 = (uint)((int)c.V0 >> 16);  }
        { c.V0 = (int)c.V0 < 385 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L8018FD0C;
        }
        mem.WriteU32(c.A0, 0u); 
        goto L8018FD0C;
        L8018FCF0: ;
        if (c.V1 != c.V0) {
            { c.V0 = c.S1 << 16;  }
            goto L8018FD0C;
        }
        { c.V0 = c.S1 << 16;  }
        { c.V0 = (uint)((int)c.V0 >> 16);  }
        { c.V0 = (int)c.V0 < 384 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L8018FD0C;
        }
        mem.WriteU32(c.A0, 0u); 
        L8018FD0C: ;
        c.V1 = 0x80070000u; 
        { c.V1 = c.V1 + 0x2EF4u;  }
        c.V0 = mem.ReadU32(c.V1); 
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x0001u;  }
            goto L8018FD8C;
        }
        { c.V0 = 0u | 0x0001u;  }
        { c.V0 = 0u | 0x8000u;  }
        mem.WriteU32(c.V1, c.V0); 
        c.V1 = mem.ReadU16((c.S3 + 0xAu)); 
        { c.V0 = 0u | 0x0180u;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s - _t;  }
        mem.WriteU16((c.S2 + 0x2u), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S0 + 0x2Cu)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S0 + 0x2Cu), (ushort)c.V0); 
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3824u)); 
        { c.A0 = 0u | 0x060Du;  }
        c.RA = 0x8018FD60u;
        Dispatcher.Call(c, m, c.V0);
        c.A0 = 0u; 
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2BDCu)); 
        c.V1 = (uint)(short)mem.ReadU16((c.S3 + 0xEu)); 
        { c.V0 = c.V0 | 0x0001u;  }
        { c.V1 = c.V1 + 0x100u;  }
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2BDCu), c.V0); 
        mem.WriteU32((c.S3 + 0x48u), c.V1); 
        c.RA = 0x8018FD88u; 
        SoTN_cen.func_8018F8EC(c, m);
        L8018FD88: ;
        { c.V0 = 0u | 0x0001u;  }
        L8018FD8C: ;
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x2EFCu), c.V0); 
        goto L8018FFE8;
        L8018FD9C: ;
        c.S1 = 0x80070000u; 
        { c.S1 = c.S1 + 0x2EF4u;  }
        { c.V0 = 0u | 0x0001u;  }
        mem.WriteU32(c.S1, 0u); 
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x2EFCu), c.V0); 
        c.V1 = mem.ReadU16((c.S3 + 0xAu)); 
        { c.V0 = 0u | 0x0180u;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s - _t;  }
        mem.WriteU16((c.S2 + 0x2u), (ushort)c.V0); 
        { c.V0 = c.A0 << 16;  }
        { c.V0 = (uint)((int)c.V0 >> 16);  }
        { c.V0 = (int)c.V0 < 497 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L8018FE08;
        }
        c.V0 = mem.ReadU16((c.S0 + 0x6u)); 
        c.A0 = 0x80090000u; 
        { c.A0 = c.A0 + 0x748Eu;  }
        { c.V0 = c.V0 - 0x1u;  }
        mem.WriteU16((c.S0 + 0x6u), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S2 + 0x6u)); 
        c.V1 = mem.ReadU16(c.A0); 
        { c.V0 = c.V0 - 0x1u;  }
        { c.V1 = c.V1 - 0x1u;  }
        mem.WriteU16((c.S2 + 0x6u), (ushort)c.V0); 
        mem.WriteU16(c.A0, (ushort)c.V1); 
        goto L8018FE50;
        L8018FE08: ;
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3824u)); 
        { c.A0 = 0u | 0x064Fu;  }
        c.RA = 0x8018FE1Cu;
        Dispatcher.Call(c, m, c.V0);
        c.V0 = mem.ReadU16((c.S2 + 0x14u)); 
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x8000u;  }
            goto L8018FE30;
        }
        { c.V0 = 0u | 0x8000u;  }
        mem.WriteU32(c.S1, c.V0); 
        L8018FE30: ;
        c.V1 = mem.ReadU16((c.S0 + 0x2Cu)); 
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2BDCu)); 
        { c.V1 = c.V1 + 0x1u;  }
        { c.V0 = c.V0 | 0x0004u;  }
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2BDCu), c.V0); 
        mem.WriteU16((c.S0 + 0x2Cu), (ushort)c.V1); 
        L8018FE50: ;
        { c.A0 = 0u | 0x0200u;  }
        c.RA = 0x8018FE58u; 
        SoTN_cen.CEN_CutsceneCameraPan(c, m);
        goto L8018FFE8;
        L8018FE60: ;
        { c.A0 = 0u | 0x0200u;  }
        c.RA = 0x8018FE68u; 
        SoTN_cen.CEN_CutsceneCameraPan(c, m);
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2BDCu)); 
        { c.V1 = 0u | 0x0001u;  }
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x2EF4u), 0u); 
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x2EFCu), c.V1); 
        { c.V0 = c.V0 & 0x0008u;  }
        if (c.V0 == 0u) {
            goto L8018FFE8;
        }
        c.A1 = 0x80080000u; 
        { c.A1 = c.A1 - 0x3658u;  }
        { c.A0 = 0u | 0x000Au;  }
        c.RA = 0x8018FEA0u; 
        Dispatcher.Call(c, m, 0x801934C4u);
        { c.V0 = 0u | 0x00CBu;  }
        c.At = 0x80080000u; 
        mem.WriteU16((c.At - 0x3628u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0005u;  }
        c.At = 0x80080000u; 
        mem.WriteU16((c.At - 0x362Cu), (ushort)c.V0); 
        c.At = 0x80080000u; 
        mem.WriteU32((c.At - 0x3624u), 0u); 
        goto L8018FFD8;
        L8018FEC8: ;
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2BDCu)); 
        { c.V0 = c.V0 & 0x0002u;  }
        if (c.V0 == 0u) {
            { c.V0 = 0u | 0x0001u;  }
            goto L8018FFA8;
        }
        { c.V0 = 0u | 0x0001u;  }
        c.V0 = mem.ReadU16((c.S0 + 0x2Cu)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S0 + 0x2Cu), (ushort)c.V0); 
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3824u)); 
        { c.A0 = 0u | 0x060Du;  }
        c.RA = 0x8018FF04u;
        Dispatcher.Call(c, m, c.V0);
        { c.V0 = 0u | 0x0001u;  }
        goto L8018FFA8;
        L8018FF0C: ;
        { c.V0 = c.A0 << 16;  }
        { c.V0 = (uint)((int)c.V0 >> 16);  }
        { c.V0 = (int)c.V0 < 592 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.V0 = 0u | 0x0001u;  }
            goto L8018FF50;
        }
        { c.V0 = 0u | 0x0001u;  }
        c.V0 = mem.ReadU16((c.S0 + 0x6u)); 
        c.A0 = 0x80090000u; 
        { c.A0 = c.A0 + 0x748Au;  }
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S0 + 0x6u), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S2 + 0x6u)); 
        c.V1 = mem.ReadU16(c.A0); 
        { c.V0 = c.V0 + 0x1u;  }
        { c.V1 = c.V1 + 0x1u;  }
        mem.WriteU16((c.S2 + 0x6u), (ushort)c.V0); 
        mem.WriteU16(c.A0, (ushort)c.V1); 
        goto L8018FF9C;
        L8018FF50: ;
        c.A0 = 0x80090000u; 
        { c.A0 = c.A0 + 0x7400u;  }
        c.V1 = mem.ReadU32(c.A0); 
        c.At = 0x80040000u; 
        mem.WriteU32((c.At - 0x3748u), c.V0); 
        if (c.V1 == 0u) {
            { c.V0 = 0u | 0x0001u;  }
            goto L8018FF70;
        }
        { c.V0 = 0u | 0x0001u;  }
        mem.WriteU32(c.A0, 0u); 
        L8018FF70: ;
        c.At = 0x80070000u; 
        mem.WriteU8((c.At + 0x3510u), (byte)c.V0); 
        c.V0 = mem.ReadU16((c.S0 + 0x2Cu)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S0 + 0x2Cu), (ushort)c.V0); 
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3824u)); 
        { c.A0 = 0u | 0x064Fu;  }
        c.RA = 0x8018FF9Cu;
        Dispatcher.Call(c, m, c.V0);
        L8018FF9C: ;
        { c.A0 = 0u | 0x0300u;  }
        c.RA = 0x8018FFA4u; 
        SoTN_cen.CEN_CutsceneCameraPan(c, m);
        { c.V0 = 0u | 0x0001u;  }
        L8018FFA8: ;
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x2EF4u), 0u); 
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x2EFCu), c.V0); 
        goto L8018FFE8;
        L8018FFC0: ;
        { c.A0 = 0u | 0x0300u;  }
        c.RA = 0x8018FFC8u; 
        SoTN_cen.CEN_CutsceneCameraPan(c, m);
        c.V1 = mem.ReadU32((c.S3 + 0x48u)); 
        { c.V0 = 0u | 0x0300u;  }
        if (c.V1 != c.V0) {
            goto L8018FFE8;
        }
        L8018FFD8: ;
        c.V0 = mem.ReadU16((c.S0 + 0x2Cu)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S0 + 0x2Cu), (ushort)c.V0); 
        L8018FFE8: ;
        c.V1 = mem.ReadU32((c.S0 + 0x64u)); 
        c.A0 = 0x80080000u; 
        { c.A0 = c.A0 + 0x6FECu;  }
        { c.V0 = c.V1 << 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.A0; c.A1 = _s + _t;  }
        c.V1 = mem.ReadU16((c.S0 + 0x2u)); 
        c.V0 = mem.ReadU16((c.S0 + 0x6u)); 
        { c.A0 = c.V1 - 0x8u;  }
        { c.V1 = c.V1 + 0x8u;  }
        { c.V0 = c.V0 + 0x8u;  }
        mem.WriteU16((c.S0 + 0x6u), (ushort)c.V0); 
        mem.WriteU16((c.A1 + 0x20u), (ushort)c.A0); 
        mem.WriteU16((c.A1 + 0x8u), (ushort)c.A0); 
        mem.WriteU16((c.A1 + 0x2Cu), (ushort)c.V1); 
        mem.WriteU16((c.A1 + 0x14u), (ushort)c.V1); 
        c.V0 = mem.ReadU16((c.S0 + 0x6u)); 
        { c.V0 = c.V0 + 0xFu;  }
        mem.WriteU16((c.A1 + 0x16u), (ushort)c.V0); 
        mem.WriteU16((c.A1 + 0xAu), (ushort)c.V0); 
        c.V1 = mem.ReadU16((c.S3 + 0xEu)); 
        { c.V0 = 0u | 0x0268u;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s - _t;  }
        mem.WriteU16((c.A1 + 0x2Eu), (ushort)c.V0); 
        mem.WriteU16((c.A1 + 0x22u), (ushort)c.V0); 
        c.RA = mem.ReadU32((c.SP + 0x20u)); 
        c.S3 = mem.ReadU32((c.SP + 0x1Cu)); 
        c.S2 = mem.ReadU32((c.SP + 0x18u)); 
        c.S1 = mem.ReadU32((c.SP + 0x14u)); 
        c.S0 = mem.ReadU32((c.SP + 0x10u)); 
        { c.SP = c.SP + 0x28u;  }
        return;
        }
    public static bool func_8018E810_cen(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("cen", m, true)) return true;
        func_8018E810_cen_Body(c, m);
        return false;
    }
    private static void func_8018E810_cen_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "cen", 0x8019D378u);
        c.V0 = mem.ReadU32((c.V0 - 0x2C8Cu)); 
        if (c.V0 != 0u) {
            goto L8018E8FC;
        }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x34FCu)); 
        { c.V0 = c.V0 & 0x0800u;  }
        if (c.V0 != 0u) {
            goto L8018E84C;
        }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x4220u)); 
        if (c.V0 == 0u) {
            goto L8018E8FC;
        }
        L8018E84C: ;
        c.V0 = 0x80090000u; 
        c.V0 = mem.ReadU16((c.V0 + 0x7494u)); 
        { c.V0 = c.V0 & 0x0800u;  }
        if (c.V0 == 0u) {
            { c.V0 = 0u | 0x0001u;  }
            goto L8018E8FC;
        }
        { c.V0 = 0u | 0x0001u;  }
        c.S0 = 0x80040000u; 
        { c.S0 = c.S0 - 0x384Cu;  }
        c.A0 = mem.ReadU32((c.S2 + 0x64u)); 
        c.V1 = mem.ReadU32(c.S0); 
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2C8Cu), c.V0); 
        c.S1 = 0xFFFFFFFFu; 
        c.RA = 0x8018E884u;
        Dispatcher.Call(c, m, c.V1);
        c.V0 = mem.ReadU32((c.S2 + 0x34u)); 
        c.V1 = 0x00800000u; 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s ^ _t;  }
        mem.WriteU32((c.S2 + 0x34u), c.V0); 
        c.A0 = 0x801A0000u; 
        c.A0 = mem.ReadU32((c.A0 - 0x2C54u)); 
        if (c.A0 == c.S1) {
            goto L8018E8B8;
        }
        c.V0 = mem.ReadU32(c.S0); 
        c.RA = 0x8018E8B8u;
        Dispatcher.Call(c, m, c.V0);
        L8018E8B8: ;
        c.A0 = 0x801A0000u; 
        c.A0 = mem.ReadU32((c.A0 - 0x2C58u)); 
        if (c.A0 == c.S1) {
            goto L8018E8DC;
        }
        c.V0 = mem.ReadU32(c.S0); 
        c.RA = 0x8018E8DCu;
        Dispatcher.Call(c, m, c.V0);
        L8018E8DC: ;
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3824u)); 
        { c.A0 = 0u | 0x000Au;  }
        c.RA = 0x8018E8F0u;
        Dispatcher.Call(c, m, c.V0);
        { c.V0 = 0u | 0x0001u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        mem.WriteU16((c.S2 + 0x2Eu), (ushort)0u); 
        L8018E8FC: ;
        c.V0 = mem.ReadU16((c.S2 + 0x2Cu)); 
        if (c.V0 == 0u) {
            goto L8018E928;
        }
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU16((c.V0 - 0x2C4Cu)); 
        if (c.V0 == 0u) {
            goto L8018E928;
        }
        c.RA = 0x8018E928u; 
        SoTN_cen.CutsceneRun_cen(c, m);
        L8018E928: ;
        c.V1 = mem.ReadU16((c.S2 + 0x2Cu)); 
        { c.V0 = c.V1 < 0x00000008u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.V0 = c.V1 << 2;  }
            goto L8018F86C;
        }
        { c.V0 = c.V1 << 2;  }
        c.At = 0x80190000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.V0 = mem.ReadU32((c.At - 0x2BD4u)); 
        Dispatcher.Call(c, m, c.V0);
        return;
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU8((c.V0 - 0x413Cu)); 
        if (c.V0 != 0u) {
            goto L8018F4BC;
        }
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x13F0u;  }
        c.RA = 0x8018E978u; 
        SoTN_cen.SetCutsceneScript_cen(c, m);
        { c.V0 = c.V0 & 0x00FFu;  }
        if (c.V0 == 0u) {
            c.A0 = 0x00800000u; 
            goto L8018F86C;
        }
        c.A0 = 0x00800000u; 
        c.V1 = mem.ReadU32((c.S2 + 0x34u)); 
        { c.V0 = 0u | 0x0001u;  }
        c.At = 0x80040000u; 
        mem.WriteU32((c.At - 0x38FCu), c.V0); 
        c.V0 = mem.ReadU16((c.S2 + 0x2Cu)); 
        { c.A0 = c.A0 | 0x2000u;  }
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2BDCu), 0u); 
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2BD8u), 0u); 
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2C8Cu), 0u); 
        { var _s = c.V1; var _t = c.A0; c.V1 = _s | _t;  }
        mem.WriteU32((c.S2 + 0x34u), c.V1); 
        c.V1 = 0x801A0000u; 
        c.V1 = mem.ReadU32((c.V1 - 0x2C50u)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        mem.WriteU32((c.S2 + 0x64u), c.V1); 
        goto L8018F86C;
        c.S4 = 0x801A0000u; 
        { c.S4 = c.S4 - 0x2C72u;  }
        { c.S1 = c.S4 - 0x16u;  }
        { c.S0 = c.S4 - 0xCu;  }
        { c.S3 = c.S4 - 0x12u;  }
        L8018E9E8: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V0 = mem.ReadU8(c.S4); 
        if (c.V0 == 0u) {
            goto L8018EA0C;
        }
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2C8Cu)); 
        if (c.V0 == 0u) {
            goto L8018F7EC;
        }
        L8018EA0C: ;
        c.V0 = mem.ReadU32(c.S1); 
        { c.V1 = c.V0 + 0x1u;  }
        mem.WriteU32(c.S1, c.V1); 
        c.A2 = mem.ReadU8(c.V0); 
        { c.V1 = c.A2 & 0xFFFFu;  }
        { c.V0 = c.V1 < 0x00000019u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.V0 = c.V1 << 2;  }
            goto L8018F200;
        }
        { c.V0 = c.V1 << 2;  }
        c.At = 0x80190000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.V0 = mem.ReadU32((c.At - 0x2BB4u)); 
        Dispatcher.Call(c, m, c.V0);
        return;
        { c.V0 = 0u | 0x0007u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        goto L8018F86C;
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2C8Cu)); 
        if (c.V0 != 0u) {
            goto L8018E9E8;
        }
        c.V0 = mem.ReadU16((c.S0 + 0x8u)); 
        c.V1 = mem.ReadU16((c.S0 + 0x2u)); 
        { c.V0 = c.V0 & 0x0001u;  }
        if (c.V0 != 0u) {
            mem.WriteU16(c.S0, (ushort)c.V1); 
            goto L8018EA90;
        }
        mem.WriteU16(c.S0, (ushort)c.V1); 
        c.V0 = mem.ReadU16((c.S0 - 0x4u)); 
        { c.V0 = c.V0 + 0xCu;  }
        mem.WriteU16((c.S0 - 0x4u), (ushort)c.V0); 
        L8018EA90: ;
        c.V0 = mem.ReadU16((c.S0 + 0x4u)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S0 + 0x4u), (ushort)c.V0); 
        { c.V0 = c.V0 << 16;  }
        { c.V0 = (uint)((int)c.V0 >> 16);  }
        { c.V0 = (int)c.V0 < 5 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L8018EAB8;
        }
        mem.WriteU16((c.S0 + 0x4u), (ushort)0u); 
        L8018EAB8: ;
        c.RA = 0x8018EAC0u; 
        SoTN_cen.CutsceneUnk4_cen(c, m);
        c.V1 = mem.ReadU16((c.S0 + 0x8u)); 
        { c.V0 = c.V1 & 0x0001u;  }
        if (c.V0 != 0u) {
            goto L8018EAEC;
        }
        c.V0 = (uint)(short)mem.ReadU16((c.S0 + 0x4u)); 
        { c.V0 = (int)c.V0 < 4 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.V0 = c.V1 | 0x0001u;  }
            goto L8018E9E8;
        }
        { c.V0 = c.V1 | 0x0001u;  }
        mem.WriteU16((c.S0 + 0x8u), (ushort)c.V0); 
        L8018EAEC: ;
        mem.WriteU16((c.S0 + 0x6u), (ushort)0u); 
        c.V0 = mem.ReadU16((c.S2 + 0x2Cu)); 
        mem.WriteU16((c.S2 + 0x2Eu), (ushort)0u); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        goto L8018F86C;
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2C88u)); 
        { c.V1 = c.V0 + 0x1u;  }
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2C88u), c.V1); 
        c.V0 = mem.ReadU8(c.V0); 
        c.At = 0x801A0000u; 
        mem.WriteU8((c.At - 0x2C71u), (byte)c.V0); 
        goto L8018E9E8;
        c.V1 = mem.ReadU32((c.S4 - 0x16u)); 
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU32((c.S4 - 0x16u), c.V0); 
        c.V0 = mem.ReadU8(c.V1); 
        c.V1 = 0x801A0000u; 
        c.V1 = mem.ReadU32((c.V1 - 0x2C8Cu)); 
        if (c.V1 != 0u) {
            mem.WriteU8(c.S4, (byte)c.V0); 
            goto L8018E9E8;
        }
        mem.WriteU8(c.S4, (byte)c.V0); 
        goto L8018F86C;
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2C8Cu)); 
        if (c.V0 != 0u) {
            { c.V1 = 0u | 0x0008u;  }
            goto L8018E9E8;
        }
        { c.V1 = 0u | 0x0008u;  }
        c.S1 = 0x801A0000u; 
        c.S1 = mem.ReadU32((c.S1 - 0x2C70u)); 
        c.S0 = 0u; 
        { c.S0 = c.S0 + 0x1u;  }
        L8018EB84: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        { c.V0 = (int)c.S0 < 5 ? 1u : 0u;  }
        mem.WriteU16((c.S1 + 0x32u), (ushort)c.V1); 
        c.S1 = mem.ReadU32(c.S1); 
        if (c.V0 != 0u) {
            { c.S0 = c.S0 + 0x1u;  }
            goto L8018EB84;
        }
        { c.S0 = c.S0 + 0x1u;  }
        goto L8018F86C;
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2C8Cu)); 
        if (c.V0 != 0u) {
            goto L8018EE20;
        }
        c.V1 = mem.ReadU32(c.S1); 
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.S0 = mem.ReadU8(c.V1); 
        { c.V0 = c.V1 + 0x2u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.T2 = mem.ReadU8((c.V1 + 0x1u)); 
        c.S1 = mem.ReadU32((c.S1 + 0x2Cu)); 
        { c.V0 = c.T2 & 0x0001u;  }
        { c.V1 = c.S0 << 1;  }
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.A0 = mem.ReadU8((c.At + 0x5D8u)); 
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.A1 = mem.ReadU8((c.At + 0x5DCu)); 
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.V1; c.At = _s + _t;  }
        c.V1 = mem.ReadU16((c.At + 0x5E0u)); 
        { c.V0 = 0u | 0x0090u;  }
        mem.WriteU16((c.S1 + 0x1Au), (ushort)c.V0); 
        { c.V0 = c.T2 & 0x0080u;  }
        if (c.V0 == 0u) {
            mem.WriteU16((c.S1 + 0xEu), (ushort)c.V1); 
            goto L8018EC24;
        }
        mem.WriteU16((c.S1 + 0xEu), (ushort)c.V1); 
        c.V1 = c.A0; 
        { c.V0 = c.V1 + 0x2Fu;  }
        goto L8018EC2C;
        L8018EC24: ;
        c.V0 = c.A0; 
        { c.V1 = c.V0 + 0x2Fu;  }
        L8018EC2C: ;
        mem.WriteU8((c.S1 + 0x24u), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0xCu), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0x30u), (byte)c.V1); 
        mem.WriteU8((c.S1 + 0x18u), (byte)c.V1); 
        c.V0 = c.A1; 
        { c.V1 = c.V0 + 0x48u;  }
        mem.WriteU8((c.S1 + 0x19u), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0xDu), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0x31u), (byte)c.V1); 
        mem.WriteU8((c.S1 + 0x25u), (byte)c.V1); 
        c.V0 = mem.ReadU16(c.S3); 
        { c.V0 = c.V0 - 0x1Eu;  }
        mem.WriteU16((c.S1 + 0x2Cu), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x20u), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x14u), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x8u), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S3 + 0x4u)); 
        { c.V0 = c.V0 + 0x24u;  }
        mem.WriteU16((c.S1 + 0x2Eu), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x22u), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x16u), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0xAu), (ushort)c.V0); 
        { c.V0 = c.S0 << 1;  }
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.V0 = mem.ReadU16((c.At + 0x5ECu)); 
        mem.WriteU16((c.S3 + 0x10u), (ushort)c.V0); 
        c.RA = 0x8018ECA4u; 
        Dispatcher.Call(c, m, 0x8018DF0Cu);
        c.RA = 0x8018ECACu; 
        SoTN_cen.CutsceneUnk4_cen(c, m);
        { c.A0 = c.S0 & 0xFFFFu;  }
        c.A1 = c.S2; 
        { c.V0 = 0u | 0x01FEu;  }
        mem.WriteU16((c.S1 + 0x26u), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x32u), (ushort)0u); 
        c.RA = 0x8018ECC4u; 
        SoTN_cen.DrawCutsceneActorName_cen(c, m);
        { c.V0 = 0u | 0x0006u;  }
        mem.WriteU16((c.S3 + 0xCu), (ushort)c.V0); 
        { c.V0 = 0u | 0x0003u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        goto L8018F86C;
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2C8Cu)); 
        if (c.V0 != 0u) {
            { c.V1 = 0u | 0x0008u;  }
            goto L8018E9E8;
        }
        { c.V1 = 0u | 0x0008u;  }
        c.S1 = 0x801A0000u; 
        c.S1 = mem.ReadU32((c.S1 - 0x2C70u)); 
        c.S0 = 0u; 
        { c.S0 = c.S0 + 0x1u;  }
        L8018ECFC: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        { c.V0 = (int)c.S0 < 5 ? 1u : 0u;  }
        mem.WriteU16((c.S1 + 0x32u), (ushort)c.V1); 
        c.S1 = mem.ReadU32(c.S1); 
        if (c.V0 != 0u) {
            { c.S0 = c.S0 + 0x1u;  }
            goto L8018ECFC;
        }
        { c.S0 = c.S0 + 0x1u;  }
        c.S0 = 0x801A0000u; 
        { c.S0 = c.S0 - 0x2C54u;  }
        c.A0 = mem.ReadU32(c.S0); 
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x384Cu)); 
        c.RA = 0x8018ED30u;
        Dispatcher.Call(c, m, c.V0);
        c.V0 = 0xFFFFFFFFu; 
        mem.WriteU32(c.S0, c.V0); 
        { c.V0 = 0u | 0x0006u;  }
        c.At = 0x801A0000u; 
        mem.WriteU16((c.At - 0x2C78u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0004u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        goto L8018F86C;
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2C8Cu)); 
        if (c.V0 != 0u) {
            goto L8018EE20;
        }
        c.V1 = mem.ReadU32((c.S3 - 0x4u)); 
        c.S1 = mem.ReadU32((c.S3 + 0x28u)); 
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU32((c.S3 - 0x4u), c.V0); 
        c.A0 = mem.ReadU8(c.V1); 
        { c.V0 = c.V1 + 0x2u;  }
        mem.WriteU32((c.S3 - 0x4u), c.V0); 
        mem.WriteU16(c.S3, (ushort)c.A0); 
        c.V0 = mem.ReadU8((c.V1 + 0x1u)); 
        mem.WriteU16((c.S3 + 0x4u), (ushort)c.V0); 
        c.S1 = mem.ReadU32(c.S1); 
        mem.WriteU16((c.S1 + 0x16u), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0xAu), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S3 + 0x4u)); 
        { c.V0 = c.V0 + 0x48u;  }
        mem.WriteU16((c.S1 + 0x2Eu), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x22u), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S3 + 0x4u)); 
        c.S1 = mem.ReadU32(c.S1); 
        { c.V0 = c.V0 - 0x1u;  }
        mem.WriteU16((c.S1 + 0xAu), (ushort)c.V0); 
        { c.V0 = 0u | 0x00F6u;  }
        mem.WriteU8((c.S1 + 0xCu), (byte)c.V0); 
        { c.V0 = 0u | 0x0018u;  }
        mem.WriteU16((c.S3 + 0xCu), (ushort)c.V0); 
        { c.V0 = 0u | 0x0005u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        mem.WriteU16((c.S2 + 0x2Eu), (ushort)0u); 
        goto L8018F86C;
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2C8Cu)); 
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x0018u;  }
            goto L8018E9E8;
        }
        { c.V0 = 0u | 0x0018u;  }
        c.At = 0x801A0000u; 
        mem.WriteU16((c.At - 0x2C78u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0006u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        goto L8018F86C;
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2C8Cu)); 
        if (c.V0 == 0u) {
            goto L8018F128;
        }
        L8018EE20: ;
        c.V0 = mem.ReadU32(c.S1); 
        { c.V0 = c.V0 + 0x2u;  }
        mem.WriteU32(c.S1, c.V0); 
        goto L8018E9E8;
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2C8Cu)); 
        if (c.V0 != 0u) {
            goto L8018E9E8;
        }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3808u)); 
        c.RA = 0x8018EE5Cu;
        Dispatcher.Call(c, m, c.V0);
        if (c.V0 == 0u) {
            goto L8018EEA0;
        }
        goto L8018E9E8;
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2C8Cu)); 
        if (c.V0 != 0u) {
            goto L8018E9E8;
        }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3808u)); 
        c.RA = 0x8018EE94u;
        Dispatcher.Call(c, m, c.V0);
        { c.V1 = 0u | 0x0001u;  }
        if (c.V0 != c.V1) {
            goto L8018E9E8;
        }
        L8018EEA0: ;
        c.V0 = mem.ReadU32(c.S1); 
        { c.V0 = c.V0 - 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        goto L8018F86C;
        c.V1 = mem.ReadU32(c.S1); 
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.T1 = mem.ReadU8(c.V1); 
        { c.V0 = c.V1 + 0x2u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.A1 = mem.ReadU8((c.V1 + 0x1u)); 
        { c.V0 = c.V1 + 0x3u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.A0 = mem.ReadU8((c.V1 + 0x2u)); 
        { c.V0 = c.V1 + 0x4u;  }
        mem.WriteU32(c.S1, c.V0); 
        { c.T1 = c.T1 << 4;  }
        { var _s = c.T1; var _t = c.A1; c.T1 = _s | _t;  }
        { c.T1 = c.T1 << 4;  }
        { var _s = c.T1; var _t = c.A0; c.T1 = _s | _t;  }
        c.A0 = mem.ReadU8((c.V1 + 0x3u)); 
        { c.T1 = c.T1 << 4;  }
        { var _s = c.T1; var _t = c.A0; c.A0 = _s | _t;  }
        c.RA = 0x8018EF08u; 
        SoTN_cen.SetCutsceneEnd_cen(c, m);
        goto L8018E9E8;
        c.V1 = mem.ReadU32(c.S1); 
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.T1 = mem.ReadU8(c.V1); 
        { c.V0 = c.V1 + 0x2u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.A0 = mem.ReadU8((c.V1 + 0x1u)); 
        { c.V0 = c.V1 + 0x3u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.V0 = mem.ReadU8((c.V1 + 0x2u)); 
        { c.A1 = c.V1 + 0x4u;  }
        mem.WriteU32(c.S1, c.A1); 
        { c.T1 = c.T1 << 4;  }
        { var _s = c.T1; var _t = c.A0; c.T1 = _s | _t;  }
        { c.T1 = c.T1 << 4;  }
        { var _s = c.T1; var _t = c.V0; c.T1 = _s | _t;  }
        c.V0 = mem.ReadU8((c.V1 + 0x3u)); 
        { c.T1 = c.T1 << 4;  }
        { var _s = c.T1; var _t = c.V0; c.T1 = _s | _t;  }
        c.V1 = mem.ReadU16(c.T1); 
        { c.V1 = c.V1 << 2;  }
        { var _s = c.V1; var _t = c.A1; c.V1 = _s + _t;  }
        goto L8018EF78;
        c.V1 = mem.ReadU32(c.S1); 
        L8018EF78: ;
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.T1 = mem.ReadU8(c.V1); 
        { c.V0 = c.V1 + 0x2u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.A0 = mem.ReadU8((c.V1 + 0x1u)); 
        { c.V0 = c.V1 + 0x3u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.V0 = mem.ReadU8((c.V1 + 0x2u)); 
        c.V1 = 0x801A0000u; 
        c.V1 = mem.ReadU32((c.V1 - 0x2C88u)); 
        { c.T1 = c.T1 << 4;  }
        { var _s = c.T1; var _t = c.A0; c.T1 = _s | _t;  }
        { c.T1 = c.T1 << 4;  }
        { var _s = c.T1; var _t = c.V0; c.T1 = _s | _t;  }
        c.V0 = mem.ReadU8(c.V1); 
        { c.T1 = c.T1 << 4;  }
        { var _s = c.T1; var _t = c.V0; c.T1 = _s | _t;  }
        c.V0 = 0x00100000u; 
        { var _s = c.T1; var _t = c.V0; c.V0 = _s + _t;  }
        mem.WriteU32(c.S1, c.V0); 
        goto L8018E9E8;
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2C88u)); 
        c.A0 = 0x801A0000u; 
        c.A0 = mem.ReadU32((c.A0 - 0x2BDCu)); 
        c.V1 = mem.ReadU8(c.V0); 
        { var _s = c.V1; var _t = c.A0; c.V0 = _t >> (int)(_s & 31u);  }
        { c.V0 = c.V0 & 0x0001u;  }
        if (c.V0 == 0u) {
            goto L8018F800;
        }
        { c.V0 = 0u | 0x0001u;  }
        { var _s = c.V1; var _t = c.V0; c.V0 = _t << (int)(_s & 31u);  }
        { var _s = 0u; var _t = c.V0; c.V0 = ~(_s | _t);  }
        c.V1 = mem.ReadU32(c.S1); 
        { var _s = c.V0; var _t = c.A0; c.V0 = _s & _t;  }
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2BDCu), c.V0); 
        { c.V1 = c.V1 + 0x1u;  }
        mem.WriteU32(c.S1, c.V1); 
        goto L8018E9E8;
        c.V1 = mem.ReadU32(c.S1); 
        c.A0 = 0x801A0000u; 
        c.A0 = mem.ReadU32((c.A0 - 0x2BDCu)); 
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.V1 = mem.ReadU8(c.V1); 
        { c.V0 = 0u | 0x0001u;  }
        { var _s = c.V1; var _t = c.V0; c.V0 = _t << (int)(_s & 31u);  }
        { var _s = c.V0; var _t = c.A0; c.V0 = _s | _t;  }
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2BDCu), c.V0); 
        goto L8018E9E8;
        c.At = 0x801A0000u; 
        mem.WriteU16((c.At - 0x2C4Cu), (ushort)0u); 
        goto L8018E9E8;
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2C8Cu)); 
        if (c.V0 == 0u) {
            { c.A1 = 0u | 0x0001u;  }
            goto L8018F090;
        }
        { c.A1 = 0u | 0x0001u;  }
        c.V0 = mem.ReadU32(c.S1); 
        { c.V0 = c.V0 + 0x5u;  }
        mem.WriteU32(c.S1, c.V0); 
        goto L8018E9E8;
        L8018F090: ;
        c.V1 = mem.ReadU32(c.S1); 
        c.A2 = 0u; 
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.T1 = mem.ReadU8(c.V1); 
        { c.V0 = c.V1 + 0x2u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.T0 = mem.ReadU8((c.V1 + 0x1u)); 
        { c.V0 = c.V1 + 0x3u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.A3 = mem.ReadU8((c.V1 + 0x2u)); 
        { c.V0 = c.V1 + 0x4u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.A0 = mem.ReadU8((c.V1 + 0x3u)); 
        { c.V0 = c.V1 + 0x5u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.T2 = mem.ReadU8((c.V1 + 0x4u)); 
        { c.T1 = c.T1 << 4;  }
        { var _s = c.T1; var _t = c.T0; c.T1 = _s | _t;  }
        { c.T1 = c.T1 << 4;  }
        { var _s = c.T1; var _t = c.A3; c.T1 = _s | _t;  }
        { c.T1 = c.T1 << 4;  }
        { var _s = c.T1; var _t = c.A0; c.T1 = _s | _t;  }
        c.A0 = 0x00100000u; 
        { var _s = c.T1; var _t = c.A0; c.A0 = _s + _t;  }
        { c.V0 = c.T2 << 1;  }
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.A3 = mem.ReadU16((c.At + 0x5E8u)); 
        { c.V0 = 0u | 0x0100u;  }
        mem.WriteU32((c.SP + 0x10u), c.V0); 
        { c.V0 = 0u | 0x0030u;  }
        mem.WriteU32((c.SP + 0x14u), c.V0); 
        { c.V0 = 0u | 0x0048u;  }
        mem.WriteU32((c.SP + 0x18u), c.V0); 
        c.RA = 0x8018F120u; 
        SoTN_main.LoadTPage(c, m);
        goto L8018E9E8;
        L8018F128: ;
        c.V1 = mem.ReadU32(c.S1); 
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.A2 = mem.ReadU8(c.V1); 
        { c.V0 = c.V1 + 0x2u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.A0 = mem.ReadU8((c.V1 + 0x1u)); 
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3824u)); 
        { c.A1 = c.A2 << 4;  }
        { var _s = c.A0; var _t = c.A1; c.A0 = _s | _t;  }
        c.RA = 0x8018F15Cu;
        Dispatcher.Call(c, m, c.V0);
        goto L8018E9E8;
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2BDCu), 0u); 
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2C8Cu), 0u); 
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2BD8u), 0u); 
        goto L8018E9E8;
        c.V1 = mem.ReadU32(c.S1); 
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.V1 = mem.ReadU8(c.V1); 
        { c.V0 = 0u | 0x0001u;  }
        { var _s = c.V1; var _t = c.V0; c.V0 = _t << (int)(_s & 31u);  }
        c.V1 = 0x801A0000u; 
        c.V1 = mem.ReadU32((c.V1 - 0x2BDCu)); 
        { var _s = 0u; var _t = c.V0; c.V0 = ~(_s | _t);  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s & _t;  }
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2BDCu), c.V0); 
        goto L8018E9E8;
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2C88u)); 
        c.V1 = mem.ReadU8(c.V0); 
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2BDCu)); 
        { var _s = c.V1; var _t = c.V0; c.V0 = _t >> (int)(_s & 31u);  }
        { c.V0 = c.V0 & 0x0001u;  }
        if (c.V0 == 0u) {
            goto L8018F814;
        }
        c.V0 = mem.ReadU32(c.S1); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        goto L8018E9E8;
        L8018F200: ;
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2C8Cu)); 
        if (c.V0 != 0u) {
            goto L8018E9E8;
        }
        c.V0 = mem.ReadU8((c.S1 + 0x17u)); 
        mem.WriteU8((c.S1 + 0x16u), (byte)c.V0); 
        { c.V0 = 0u | 0x0020u;  }
        if (c.V1 != c.V0) {
            { c.A0 = c.SP + 0x20u;  }
            goto L8018F248;
        }
        { c.A0 = c.SP + 0x20u;  }
        c.V1 = 0x801A0000u; 
        { c.V1 = c.V1 - 0x2C7Eu;  }
        c.V0 = mem.ReadU16(c.V1); 
        { c.V0 = c.V0 + 0x2u;  }
        mem.WriteU16(c.V1, (ushort)c.V0); 
        goto L8018F86C;
        L8018F248: ;
        { c.V0 = c.A2 & 0x000Fu;  }
        { c.V0 = c.V0 << 1;  }
        { c.V0 = c.V0 + 0x380u;  }
        mem.WriteU16((c.SP + 0x20u), (ushort)c.V0); 
        { c.V0 = c.A2 & 0x00F0u;  }
        { c.V0 = c.V0 >> 1;  }
        c.A1 = 0x801A0000u; 
        c.A1 = (uint)(short)mem.ReadU16((c.A1 - 0x2C7Eu)); 
        c.V1 = 0x801A0000u; 
        c.V1 = (uint)(short)mem.ReadU16((c.V1 - 0x2C7Au)); 
        { c.V0 = c.V0 + 0xF0u;  }
        mem.WriteU16((c.SP + 0x22u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0002u;  }
        mem.WriteU16((c.SP + 0x24u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0008u;  }
        mem.WriteU16((c.SP + 0x26u), (ushort)c.V0); 
        { c.A2 = c.V1 << 1;  }
        { var _s = c.A2; var _t = c.V1; c.A2 = _s + _t;  }
        { c.A2 = c.A2 << 2;  }
        { c.A2 = c.A2 + 0x180u;  }
        { c.A2 = c.A2 << 16;  }
        { c.A2 = (uint)((int)c.A2 >> 16);  }
        c.RA = 0x8018F2A4u; 
        if (!DialogueGlyphs.Draw(c, mem)) SoTN_main.MoveImage(c, m);
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU16((c.V0 - 0x2C7Eu)); 
        { c.V0 = c.V0 + 0x2u;  }
        c.At = 0x801A0000u; 
        mem.WriteU16((c.At - 0x2C7Eu), (ushort)c.V0); 
        goto L8018F86C;
        { c.A0 = 0u | 0x0002u;  }
        c.RA = 0x8018F2CCu; 
        SoTN_cen.ScaleCutsceneAvatar_cen(c, m);
        c.V0 = 0x801A0000u; 
        c.V0 = (uint)(short)mem.ReadU16((c.V0 - 0x2C78u)); 
        { c.V0 = (int)c.V0 < 6 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L8018F86C;
        }
        c.V0 = mem.ReadU16((c.S2 + 0x2Cu)); 
        { c.V0 = c.V0 - 0x1u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        goto L8018F86C;
        c.S1 = 0x801A0000u; 
        c.S1 = mem.ReadU32((c.S1 - 0x2C5Cu)); 
        c.V0 = mem.ReadU16((c.S1 + 0x20u)); 
        c.A0 = mem.ReadU16((c.S1 + 0x2Cu)); 
        c.V1 = mem.ReadU16((c.S1 + 0x16u)); 
        c.A1 = mem.ReadU16((c.S1 + 0x2Eu)); 
        { c.V0 = c.V0 - 0x4u;  }
        { c.A0 = c.A0 + 0x4u;  }
        { c.V1 = c.V1 - 0x6u;  }
        { c.A1 = c.A1 + 0x6u;  }
        mem.WriteU16((c.S1 + 0x20u), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x8u), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x2Cu), (ushort)c.A0); 
        mem.WriteU16((c.S1 + 0x14u), (ushort)c.A0); 
        mem.WriteU16((c.S1 + 0x16u), (ushort)c.V1); 
        mem.WriteU16((c.S1 + 0xAu), (ushort)c.V1); 
        mem.WriteU16((c.S1 + 0x2Eu), (ushort)c.A1); 
        mem.WriteU16((c.S1 + 0x22u), (ushort)c.A1); 
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU16((c.V0 - 0x2C78u)); 
        { c.V0 = c.V0 - 0x1u;  }
        c.At = 0x801A0000u; 
        mem.WriteU16((c.At - 0x2C78u), (ushort)c.V0); 
        { c.V0 = c.V0 << 16;  }
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x0001u;  }
            goto L8018F86C;
        }
        { c.V0 = 0u | 0x0001u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        c.V1 = 0x801A0000u; 
        c.V1 = mem.ReadU32((c.V1 - 0x2C54u)); 
        { c.V0 = c.V1 << 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.V1 = 0x80080000u; 
        { c.V1 = c.V1 + 0x6FECu;  }
        { var _s = c.V0; var _t = c.V1; c.S1 = _s + _t;  }
        if (c.S1 == 0u) {
            goto L8018F86C;
        }
        mem.WriteU16((c.S1 + 0x32u), (ushort)0u); 
        L8018F3A4: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.S1 = mem.ReadU32(c.S1); 
        if (c.S1 == 0u) {
            goto L8018F86C;
        }
        mem.WriteU16((c.S1 + 0x32u), (ushort)0u); 
        goto L8018F3A4;
        c.S1 = 0x801A0000u; 
        c.S1 = mem.ReadU32((c.S1 - 0x2C5Cu)); 
        c.V0 = mem.ReadU16((c.S1 + 0x20u)); 
        c.A0 = mem.ReadU16((c.S1 + 0x2Cu)); 
        c.V1 = mem.ReadU16((c.S1 + 0x16u)); 
        c.A1 = mem.ReadU16((c.S1 + 0x2Eu)); 
        { c.V0 = c.V0 + 0x4u;  }
        { c.A0 = c.A0 - 0x4u;  }
        { c.V1 = c.V1 + 0x6u;  }
        { c.A1 = c.A1 - 0x6u;  }
        mem.WriteU16((c.S1 + 0x20u), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x8u), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x2Cu), (ushort)c.A0); 
        mem.WriteU16((c.S1 + 0x14u), (ushort)c.A0); 
        mem.WriteU16((c.S1 + 0x16u), (ushort)c.V1); 
        mem.WriteU16((c.S1 + 0xAu), (ushort)c.V1); 
        mem.WriteU16((c.S1 + 0x2Eu), (ushort)c.A1); 
        mem.WriteU16((c.S1 + 0x22u), (ushort)c.A1); 
        c.V1 = 0x801A0000u; 
        c.V1 = (uint)(short)mem.ReadU16((c.V1 - 0x2C84u)); 
        c.V0 = (uint)(short)mem.ReadU16((c.S1 + 0x14u)); 
        c.A0 = c.V1; 
        { c.V1 = c.V1 - 0x2u;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = (int)_s < (int)_t ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L8018F434;
        }
        { c.V0 = c.A0 - 0x3u;  }
        mem.WriteU16((c.S1 + 0x2Cu), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x14u), (ushort)c.V0); 
        L8018F434: ;
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU16((c.V0 - 0x2C78u)); 
        { c.V0 = c.V0 - 0x1u;  }
        c.At = 0x801A0000u; 
        mem.WriteU16((c.At - 0x2C78u), (ushort)c.V0); 
        { c.V0 = c.V0 << 16;  }
        goto L8018F734;
        c.V1 = mem.ReadU16((c.S2 + 0x2Eu)); 
        { c.A2 = 0u | 0x0001u;  }
        if (c.V1 == c.A2) {
            { c.V0 = (int)c.V1 < 2 ? 1u : 0u;  }
            goto L8018F580;
        }
        { c.V0 = (int)c.V1 < 2 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L8018F47C;
        }
        if (c.V1 == 0u) {
            { c.A0 = 0u | 0x0002u;  }
            goto L8018F490;
        }
        { c.A0 = 0u | 0x0002u;  }
        goto L8018F86C;
        L8018F47C: ;
        { c.V0 = 0u | 0x0002u;  }
        if (c.V1 == c.V0) {
            goto L8018F67C;
        }
        goto L8018F86C;
        L8018F490: ;
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3848u)); 
        c.At = 0x801A0000u; 
        mem.WriteU32((c.At - 0x2BD8u), c.A2); 
        { c.A1 = 0u | 0x0048u;  }
        c.RA = 0x8018F4A8u;
        Dispatcher.Call(c, m, c.V0);
        { c.V0 = c.V0 << 16;  }
        { c.V1 = (uint)((int)c.V0 >> 16);  }
        c.V0 = 0xFFFFFFFFu; 
        if (c.V1 != c.V0) {
            { c.V0 = c.V1 << 1;  }
            goto L8018F4CC;
        }
        { c.V0 = c.V1 << 1;  }
        L8018F4BC: ;
        c.A0 = c.S2; 
        c.RA = 0x8018F4C4u; 
        SoTN_cen.DestroyEntity_cen(c, m);
        goto L8018F86C;
        L8018F4CC: ;
        c.A2 = 0x801A0000u; 
        { c.A2 = c.A2 - 0x2C58u;  }
        mem.WriteU32(c.A2, c.V1); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.V1 = 0x80080000u; 
        { c.V1 = c.V1 + 0x6FECu;  }
        { var _s = c.V0; var _t = c.V1; c.S1 = _s + _t;  }
        if (c.S1 == 0u) {
            c.A0 = 0u; 
            goto L8018F668;
        }
        c.A0 = 0u; 
        { c.A1 = 0u | 0x007Fu;  }
        { c.V1 = 0u | 0x00F7u;  }
        { c.T1 = c.A2 - 0x28u;  }
        { c.T0 = 0u | 0x01FEu;  }
        c.A3 = 0x80180000u; 
        { c.A3 = c.A3 + 0x5F4u;  }
        { c.A2 = 0u | 0x0F70u;  }
        L8018F518: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        mem.WriteU8((c.S1 + 0x10u), (byte)c.A1); 
        mem.WriteU8((c.S1 + 0x4u), (byte)c.A1); 
        mem.WriteU8((c.S1 + 0x11u), (byte)0u); 
        mem.WriteU8((c.S1 + 0x5u), (byte)0u); 
        mem.WriteU8((c.S1 + 0x12u), (byte)0u); 
        mem.WriteU8((c.S1 + 0x6u), (byte)0u); 
        mem.WriteU16((c.S1 + 0x14u), (ushort)c.V1); 
        mem.WriteU16((c.S1 + 0x8u), (ushort)c.V1); 
        c.V0 = mem.ReadU16(c.T1); 
        mem.WriteU16((c.S1 + 0x26u), (ushort)c.T0); 
        mem.WriteU16((c.S1 + 0x32u), (ushort)0u); 
        { var _s = c.A0; var _t = c.V0; c.V0 = _s + _t;  }
        mem.WriteU16((c.S1 + 0x16u), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0xAu), (ushort)c.V0); 
        { c.V0 = c.A0 << 16;  }
        { c.V0 = (uint)((int)c.V0 >> 15);  }
        { var _s = c.V0; var _t = c.A3; c.V0 = _s + _t;  }
        c.V0 = mem.ReadU16(c.V0); 
        mem.WriteU16((c.S1 + 0x2Cu), (ushort)c.A2); 
        mem.WriteU16((c.S1 + 0x20u), (ushort)c.V0); 
        c.S1 = mem.ReadU32(c.S1); 
        if (c.S1 != 0u) {
            { c.A0 = c.A0 + 0x1u;  }
            goto L8018F518;
        }
        { c.A0 = c.A0 + 0x1u;  }
        goto L8018F668;
        L8018F580: ;
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x2C58u)); 
        { c.V1 = c.V0 << 1;  }
        { var _s = c.V1; var _t = c.V0; c.V1 = _s + _t;  }
        { c.V1 = c.V1 << 2;  }
        { var _s = c.V1; var _t = c.V0; c.V1 = _s + _t;  }
        { c.V1 = c.V1 << 2;  }
        c.V0 = 0x80080000u; 
        { c.V0 = c.V0 + 0x6FECu;  }
        { var _s = c.V1; var _t = c.V0; c.S1 = _s + _t;  }
        if (c.S1 == 0u) {
            c.A0 = 0u; 
            goto L8018F614;
        }
        c.A0 = 0u; 
        { c.A1 = 0u | 0x0004u;  }
        L8018F5B8: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V0 = mem.ReadU16((c.S1 + 0x2Cu)); 
        c.V1 = mem.ReadU16((c.S1 + 0x20u)); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s - _t;  }
        mem.WriteU16((c.S1 + 0x2Cu), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S1 + 0x20u)); 
        c.V1 = (uint)(short)mem.ReadU16((c.S1 + 0x2Cu)); 
        { c.V0 = c.V0 + 0x2u;  }
        if ((int)c.V1 >= 0) {
            mem.WriteU16((c.S1 + 0x20u), (ushort)c.V0); 
            goto L8018F5E4;
        }
        mem.WriteU16((c.S1 + 0x20u), (ushort)c.V0); 
        { c.V1 = c.V1 + 0xFu;  }
        L8018F5E4: ;
        { c.V0 = (uint)((int)c.V1 >> 4);  }
        mem.WriteU16((c.S1 + 0x8u), (ushort)c.V0); 
        { c.V0 = (int)c.V0 < 5 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L8018F600;
        }
        mem.WriteU16((c.S1 + 0x8u), (ushort)c.A1); 
        goto L8018F604;
        L8018F600: ;
        { c.A0 = 0u | 0x0001u;  }
        L8018F604: ;
        c.S1 = mem.ReadU32(c.S1); 
        if (c.S1 != 0u) {
            goto L8018F5B8;
        }
        L8018F614: ;
        { c.V0 = c.A0 << 16;  }
        if (c.V0 != 0u) {
            goto L8018F86C;
        }
        c.S0 = 0x801A0000u; 
        { c.S0 = c.S0 - 0x2C58u;  }
        c.A0 = mem.ReadU32(c.S0); 
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x384Cu)); 
        c.RA = 0x8018F640u;
        Dispatcher.Call(c, m, c.V0);
        c.S1 = 0x801A0000u; 
        c.S1 = mem.ReadU32((c.S1 - 0x2C5Cu)); 
        c.V0 = 0xFFFFFFFFu; 
        mem.WriteU32(c.S0, c.V0); 
        c.S1 = mem.ReadU32(c.S1); 
        { c.V0 = 0u | 0x0011u;  }
        mem.WriteU16((c.S1 + 0x32u), (ushort)c.V0); 
        c.S1 = mem.ReadU32(c.S1); 
        { c.V0 = 0u | 0x0051u;  }
        mem.WriteU16((c.S1 + 0x32u), (ushort)c.V0); 
        L8018F668: ;
        c.V0 = mem.ReadU16((c.S2 + 0x2Eu)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S2 + 0x2Eu), (ushort)c.V0); 
        goto L8018F86C;
        L8018F67C: ;
        c.S1 = 0x801A0000u; 
        c.S1 = mem.ReadU32((c.S1 - 0x2C5Cu)); 
        c.S1 = mem.ReadU32(c.S1); 
        c.V0 = mem.ReadU8((c.S1 + 0x4u)); 
        { c.V0 = c.V0 < 0x00000010u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            c.A0 = 0u; 
            goto L8018F6B8;
        }
        c.A0 = 0u; 
        mem.WriteU8((c.S1 + 0x28u), (byte)0u); 
        mem.WriteU8((c.S1 + 0x1Cu), (byte)0u); 
        mem.WriteU8((c.S1 + 0x10u), (byte)0u); 
        mem.WriteU8((c.S1 + 0x4u), (byte)0u); 
        goto L8018F6D4;
        L8018F6B8: ;
        c.V0 = mem.ReadU8((c.S1 + 0x28u)); 
        { c.A0 = 0u | 0x0001u;  }
        { c.V0 = c.V0 - 0x10u;  }
        mem.WriteU8((c.S1 + 0x28u), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0x1Cu), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0x10u), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0x4u), (byte)c.V0); 
        L8018F6D4: ;
        c.V0 = mem.ReadU8((c.S1 + 0x6u)); 
        { c.V0 = c.V0 < 0x0000007Fu ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.V0 = 0u | 0x007Fu;  }
            goto L8018F6F4;
        }
        { c.V0 = 0u | 0x007Fu;  }
        c.V0 = mem.ReadU8((c.S1 + 0x12u)); 
        { c.A0 = 0u | 0x0001u;  }
        { c.V0 = c.V0 + 0x8u;  }
        L8018F6F4: ;
        mem.WriteU8((c.S1 + 0x12u), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0x6u), (byte)c.V0); 
        c.S1 = mem.ReadU32(c.S1); 
        c.V0 = mem.ReadU8((c.S1 + 0x4u)); 
        { c.V0 = c.V0 < 0x00000010u ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x0010u;  }
            goto L8018F724;
        }
        { c.V0 = 0u | 0x0010u;  }
        c.V0 = mem.ReadU8((c.S1 + 0x6u)); 
        { c.A0 = 0u | 0x0001u;  }
        { c.V0 = c.V0 - 0xFu;  }
        L8018F724: ;
        mem.WriteU8((c.S1 + 0x6u), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0x5u), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0x4u), (byte)c.V0); 
        { c.V0 = c.A0 << 16;  }
        L8018F734: ;
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x0001u;  }
            goto L8018F86C;
        }
        { c.V0 = 0u | 0x0001u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        goto L8018F86C;
        c.S1 = 0x801A0000u; 
        c.S1 = mem.ReadU32((c.S1 - 0x2C5Cu)); 
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU16((c.V0 - 0x2C78u)); 
        c.S1 = mem.ReadU32(c.S1); 
        { c.V0 = c.V0 - 0x1u;  }
        c.At = 0x801A0000u; 
        mem.WriteU16((c.At - 0x2C78u), (ushort)c.V0); 
        { c.V0 = c.V0 << 16;  }
        { c.V1 = (uint)((int)c.V0 >> 16);  }
        { c.V0 = (int)c.V1 < 12 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L8018F7B0;
        }
        c.S1 = mem.ReadU32(c.S1); 
        c.V1 = mem.ReadU8((c.S1 + 0xCu)); 
        { c.V0 = c.V1 + 0xECu;  }
        mem.WriteU8((c.S1 + 0xCu), (byte)c.V0); 
        c.V0 = 0x801A0000u; 
        c.V0 = mem.ReadU16((c.V0 - 0x2C78u)); 
        { c.V0 = c.V0 & 0x0001u;  }
        if (c.V0 == 0u) {
            { c.V0 = c.V1 - 0x15u;  }
            goto L8018F86C;
        }
        { c.V0 = c.V1 - 0x15u;  }
        mem.WriteU8((c.S1 + 0xCu), (byte)c.V0); 
        goto L8018F86C;
        L8018F7B0: ;
        if (c.V1 != 0u) {
            { c.V0 = 0u | 0x0001u;  }
            goto L8018F7C8;
        }
        { c.V0 = 0u | 0x0001u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        { c.V0 = 0u | 0x0008u;  }
        mem.WriteU16((c.S1 + 0x32u), (ushort)c.V0); 
        goto L8018F7DC;
        L8018F7C8: ;
        c.V0 = mem.ReadU16((c.S1 + 0x2Eu)); 
        { c.V0 = c.V0 - 0x6u;  }
        mem.WriteU16((c.S1 + 0x2Eu), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x22u), (ushort)c.V0); 
        L8018F7DC: ;
        c.S1 = mem.ReadU32(c.S1); 
        { c.V0 = 0u | 0x0008u;  }
        mem.WriteU16((c.S1 + 0x32u), (ushort)c.V0); 
        goto L8018F86C;
        L8018F7EC: ;
        c.V0 = mem.ReadU8(c.S4); 
        { c.V0 = c.V0 - 0x1u;  }
        mem.WriteU8(c.S4, (byte)c.V0); 
        goto L8018F86C;
        L8018F800: ;
        c.V1 = 0x801A0000u; 
        { c.V1 = c.V1 - 0x2C88u;  }
        c.V0 = mem.ReadU32(c.V1); 
        { c.V0 = c.V0 - 0x1u;  }
        goto L8018F868;
        L8018F814: ;
        c.V1 = 0x801A0000u; 
        { c.V1 = c.V1 - 0x2C88u;  }
        c.V0 = mem.ReadU32(c.V1); 
        { c.V0 = c.V0 - 0x1u;  }
        goto L8018F868;
        c.A0 = c.S2; 
        c.RA = 0x8018F830u; 
        SoTN_cen.DestroyEntity_cen(c, m);
        { c.A0 = 0u | 0x0018u;  }
        c.V1 = 0x80040000u; 
        c.V1 = mem.ReadU32((c.V1 - 0x37C0u)); 
        { c.V0 = 0u | 0x0001u;  }
        c.At = 0x80040000u; 
        mem.WriteU8((c.At - 0x413Cu), (byte)c.V0); 
        { c.A1 = 0u | 0x0001u;  }
        c.RA = 0x8018F850u;
        Dispatcher.Call(c, m, c.V1);
        c.V1 = 0x80040000u; 
        { c.V1 = c.V1 - 0x34FCu;  }
        c.V0 = mem.ReadU32(c.V1); 
        c.At = 0x80040000u; 
        mem.WriteU32((c.At - 0x38FCu), 0u); 
        { c.V0 = c.V0 | 0x0800u;  }
        L8018F868: ;
        mem.WriteU32(c.V1, c.V0); 
        L8018F86C: ;
        c.RA = mem.ReadU32((c.SP + 0x44u)); 
        c.S4 = mem.ReadU32((c.SP + 0x40u)); 
        c.S3 = mem.ReadU32((c.SP + 0x3Cu)); 
        c.S2 = mem.ReadU32((c.SP + 0x38u)); 
        c.S1 = mem.ReadU32((c.SP + 0x34u)); 
        c.S0 = mem.ReadU32((c.SP + 0x30u)); 
        { c.SP = c.SP + 0x48u;  }
        return;
        }
    public static bool EntityRelicOrb_cen(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("cen", m, false)) return true;
        EntityRelicOrb_cen_Body(c, m);
        return false;
    }
    private static void EntityRelicOrb_cen_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "cen", 0x8019D378u);
        { c.SP = c.SP - 0x50u;  }
        mem.WriteU32((c.SP + 0x34u), c.S1); 
        c.S1 = c.A0; 
        mem.WriteU32((c.SP + 0x48u), c.RA); 
        mem.WriteU32((c.SP + 0x44u), c.S5); 
        mem.WriteU32((c.SP + 0x40u), c.S4); 
        mem.WriteU32((c.SP + 0x3Cu), c.S3); 
        mem.WriteU32((c.SP + 0x38u), c.S2); 
        mem.WriteU32((c.SP + 0x30u), c.S0); 
        c.V0 = mem.ReadU16((c.S1 + 0x30u)); 
        c.V1 = mem.ReadU16((c.S1 + 0x2Cu)); 
        if (c.V1 == 0u) {
            { c.S4 = c.V0 & 0x7FFFu;  }
            goto L80196F8C;
        }
        { c.S4 = c.V0 & 0x7FFFu;  }
        { c.V0 = c.V1 < 0x00000005u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.V0 = c.V1 < 0x0000000Au ? 1u : 0u;  }
            goto L80196F94;
        }
        { c.V0 = c.V1 < 0x0000000Au ? 1u : 0u;  }
        c.V0 = mem.ReadU8((c.S1 + 0x48u)); 
        if (c.V0 == 0u) {
            { c.V0 = 0u | 0x0005u;  }
            goto L80196F8C;
        }
        { c.V0 = 0u | 0x0005u;  }
        mem.WriteU16((c.S1 + 0x2Cu), (ushort)c.V0); 
        c.V1 = mem.ReadU16((c.S1 + 0x2Cu)); 
        L80196F8C: ;
        { c.V0 = c.V1 < 0x0000000Au ? 1u : 0u;  }
        L80196F94: ;
        if (c.V0 == 0u) {
            { c.V0 = c.V1 << 2;  }
            goto L801977F4;
        }
        { c.V0 = c.V1 << 2;  }
        c.At = 0x80190000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.V0 = mem.ReadU32((c.At - 0x2A78u)); 
        switch (c.V0)
        {
            case 0x80196FB4u: goto L80196FB4;
            case 0x80197184u: goto L80197184;
            case 0x801977F4u: goto L801977F4;
            case 0x801971E4u: goto L801971E4;
            case 0x801973A4u: goto L801973A4;
            case 0x8019746Cu: goto L8019746C;
            case 0x8019751Cu: goto L8019751C;
            case 0x80197694u: goto L80197694;
            case 0x80197B70u: goto L80197B70;
            case 0x80197C54u: goto L80197C54;
            case 0x80197E30u: goto L80197E30;
            case 0x80197F08u: goto L80197F08;
            case 0x8019800Cu: goto L8019800C;
            default: Dispatcher.Call(c, m, c.V0); return;
        }
        L80196FB4: ;
        { c.V0 = c.S4 & 0xFFFFu;  }
        c.At = 0x80090000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.V0 = mem.ReadU8((c.At + 0x7964u)); 
        { c.V0 = c.V0 & 0x0001u;  }
        if (c.V0 != 0u) {
            goto L801976F4;
        }
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x410u;  }
        c.S0 = 0u; 
        c.RA = 0x80196FE4u; 
        SoTN_cen.InitializeEntity_cen(c, m);
        c.S5 = 0x801A0000u; 
        { c.S5 = c.S5 - 0x2BD4u;  }
        { c.V0 = c.S0 << 16;  }
        L80196FF0: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        { c.V0 = (uint)((int)c.V0 >> 15);  }
        { var _s = c.V0; var _t = c.S5; c.V0 = _s + _t;  }
        c.V0 = mem.ReadU16(c.V0); 
        if (c.V0 == 0u) {
            { c.V0 = c.S0 + 0x1u;  }
            goto L80197020;
        }
        { c.V0 = c.S0 + 0x1u;  }
        c.S0 = c.V0; 
        { c.V0 = c.V0 << 16;  }
        { c.V0 = (uint)((int)c.V0 >> 16);  }
        { c.V0 = (int)c.V0 < 31 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.V0 = c.S0 << 16;  }
            goto L80196FF0;
        }
        { c.V0 = c.S0 << 16;  }
        L80197020: ;
        { c.V0 = c.S0 << 16;  }
        { c.S3 = (uint)((int)c.V0 >> 16);  }
        { c.V0 = (int)c.S3 < 31 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.A0 = 0u | 0x0004u;  }
            goto L8019705C;
        }
        { c.A0 = 0u | 0x0004u;  }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3848u)); 
        { c.A1 = 0u | 0x0007u;  }
        c.RA = 0x80197048u;
        Dispatcher.Call(c, m, c.V0);
        { c.V0 = c.V0 << 16;  }
        { c.S2 = (uint)((int)c.V0 >> 16);  }
        c.V0 = 0xFFFFFFFFu; 
        if (c.S2 != c.V0) {
            c.V1 = 0x00800000u; 
            goto L80197064;
        }
        c.V1 = 0x00800000u; 
        L8019705C: ;
        mem.WriteU16((c.S1 + 0x2Cu), (ushort)0u); 
        goto L801979D8;
        L80197064: ;
        c.V0 = mem.ReadU32((c.S1 + 0x34u)); 
        mem.WriteU32((c.S1 + 0x64u), c.S2); 
        mem.WriteU16((c.S1 + 0x8Cu), (ushort)c.S0); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s | _t;  }
        mem.WriteU32((c.S1 + 0x34u), c.V0); 
        { c.V0 = c.S3 << 1;  }
        { var _s = c.V0; var _t = c.S5; c.V0 = _s + _t;  }
        { c.V1 = 0u | 0x0010u;  }
        mem.WriteU16(c.V0, (ushort)c.V1); 
        c.V1 = 0x80040000u; 
        c.V1 = mem.ReadU32((c.V1 - 0x37B0u)); 
        { c.V0 = c.S4 << 4;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        c.A0 = mem.ReadU16((c.V0 + 0x8u)); 
        c.A1 = mem.ReadU16((c.V0 + 0xAu)); 
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x37D4u)); 
        c.A2 = c.S3; 
        c.RA = 0x801970B4u;
        Dispatcher.Call(c, m, c.V0);
        { c.V0 = c.S2 << 1;  }
        { var _s = c.V0; var _t = c.S2; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.S2; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.V1 = 0x80080000u; 
        { c.V1 = c.V1 + 0x6FECu;  }
        { var _s = c.V0; var _t = c.V1; c.A2 = _s + _t;  }
        if (c.A2 == 0u) {
            c.A3 = 0u; 
            goto L80197160;
        }
        c.A3 = 0u; 
        { c.T3 = 0u | 0x0008u;  }
        { c.T2 = 0u | 0x001Au;  }
        { c.T1 = c.S0 + 0x1D0u;  }
        c.V1 = c.S0; 
        { c.V0 = c.V1 & 0x0007u;  }
        { c.V0 = c.V0 << 4;  }
        { c.T0 = c.V0 | 0x0001u;  }
        { c.A1 = c.V0 | 0x000Fu;  }
        { c.V1 = c.V1 & 0x0018u;  }
        { c.V1 = c.V1 << 1;  }
        { c.A0 = c.V1 | 0x0081u;  }
        { c.V1 = c.V1 | 0x008Fu;  }
        L8019710C: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        if (c.A3 == 0u) {
            { c.V0 = 0u | 0x0006u;  }
            goto L8019711C;
        }
        { c.V0 = 0u | 0x0006u;  }
        mem.WriteU16((c.A2 + 0x32u), (ushort)c.T3); 
        goto L80197148;
        L8019711C: ;
        mem.WriteU16((c.A2 + 0x1Au), (ushort)c.T2); 
        mem.WriteU16((c.A2 + 0xEu), (ushort)c.T1); 
        mem.WriteU8((c.A2 + 0x24u), (byte)c.T0); 
        mem.WriteU8((c.A2 + 0xCu), (byte)c.T0); 
        mem.WriteU8((c.A2 + 0x30u), (byte)c.A1); 
        mem.WriteU8((c.A2 + 0x18u), (byte)c.A1); 
        mem.WriteU8((c.A2 + 0x19u), (byte)c.A0); 
        mem.WriteU8((c.A2 + 0xDu), (byte)c.A0); 
        mem.WriteU8((c.A2 + 0x31u), (byte)c.V1); 
        mem.WriteU8((c.A2 + 0x25u), (byte)c.V1); 
        mem.WriteU16((c.A2 + 0x32u), (ushort)c.V0); 
        L80197148: ;
        { c.V0 = 0u | 0x007Eu;  }
        mem.WriteU16((c.A2 + 0x26u), (ushort)c.V0); 
        c.A2 = mem.ReadU32(c.A2); 
        if (c.A2 != 0u) {
            { c.A3 = c.A3 + 0x1u;  }
            goto L8019710C;
        }
        { c.A3 = c.A3 + 0x1u;  }
        L80197160: ;
        c.V0 = 0xFFFF8000u; 
        mem.WriteU16((c.S1 + 0x4u), (ushort)c.V0); 
        { c.V0 = 0u | 0x4000u;  }
        mem.WriteU32((c.S1 + 0xCu), c.V0); 
        { c.V0 = 0u | 0x0040u;  }
        mem.WriteU16((c.S1 + 0x90u), (ushort)c.V0); 
        c.V0 = 0xFFFFFE00u; 
        mem.WriteU32((c.S1 + 0x94u), c.V0); 
        goto L801977F4;
        L80197184: ;
        c.V0 = mem.ReadU32((c.S1 + 0xCu)); 
        c.V1 = mem.ReadU16((c.S1 + 0x90u)); 
        c.A0 = mem.ReadU32((c.S1 + 0x94u)); 
        { c.V1 = c.V1 - 0x1u;  }
        { var _s = c.V0; var _t = c.A0; c.V0 = _s + _t;  }
        mem.WriteU16((c.S1 + 0x90u), (ushort)c.V1); 
        { c.V1 = c.V1 & 0xFFFFu;  }
        if (c.V1 != 0u) {
            mem.WriteU32((c.S1 + 0xCu), c.V0); 
            goto L801971BC;
        }
        mem.WriteU32((c.S1 + 0xCu), c.V0); 
        c.V0 = mem.ReadU32((c.S1 + 0x94u)); 
        { c.V1 = 0u | 0x0040u;  }
        mem.WriteU16((c.S1 + 0x90u), (ushort)c.V1); 
        { var _s = 0u; var _t = c.V0; c.V0 = _s - _t;  }
        mem.WriteU32((c.S1 + 0x94u), c.V0); 
        L801971BC: ;
        c.RA = 0x801971C4u; 
        SoTN_cen.MoveEntity_cen(c, m);
        c.V0 = (uint)(short)mem.ReadU16((c.S1 + 0x8Cu)); 
        { c.V1 = 0u | 0x0010u;  }
        { c.V0 = c.V0 << 1;  }
        c.At = 0x801A0000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        mem.WriteU16((c.At - 0x2BD4u), (ushort)c.V1); 
        goto L801977F4;
        L801971E4: ;
        { c.S0 = c.S4 & 0xFFFFu;  }
        c.A0 = c.S0; 
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x37B8u)); 
        { c.A1 = 0u | 0x2000u;  }
        c.RA = 0x80197200u;
        Dispatcher.Call(c, m, c.V0);
        { c.V0 = c.S0 < 0x00000016u ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.A0 = c.SP + 0x20u;  }
            goto L80197238;
        }
        { c.A0 = c.SP + 0x20u;  }
        { c.V0 = c.S0 < 0x00000014u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            c.A1 = 0u; 
            goto L8019723C;
        }
        c.A1 = 0u; 
        c.At = 0x80090000u; 
        { var _s = c.At; var _t = c.S0; c.At = _s + _t;  }
        c.V0 = mem.ReadU8((c.At + 0x7964u)); 
        { c.V0 = c.V0 ^ 0x0002u;  }
        c.At = 0x80090000u; 
        { var _s = c.At; var _t = c.S0; c.At = _s + _t;  }
        mem.WriteU8((c.At + 0x7964u), (byte)c.V0); 
        L80197238: ;
        c.A1 = 0u; 
        L8019723C: ;
        c.A2 = 0u; 
        c.A3 = 0u; 
        c.V0 = mem.ReadU32((c.S1 + 0x34u)); 
        c.V1 = 0x00010000u; 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s | _t;  }
        mem.WriteU32((c.S1 + 0x34u), c.V0); 
        { c.V0 = 0u | 0x0100u;  }
        mem.WriteU16((c.SP + 0x22u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0040u;  }
        mem.WriteU16((c.SP + 0x24u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0010u;  }
        mem.WriteU16((c.SP + 0x20u), (ushort)0u); 
        mem.WriteU16((c.SP + 0x26u), (ushort)c.V0); 
        c.RA = 0x80197274u; 
        DialogueGlyphs.Clear(c, mem);
        c.A3 = 0u; 
        { c.T0 = 0u | 0x0010u;  }
        { c.A0 = 0u | 0x0080u;  }
        c.V1 = mem.ReadU32((c.S1 + 0x64u)); 
        { c.A1 = 0u | 0x00A7u;  }
        { c.V0 = c.V1 << 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.V1 = 0x80080000u; 
        { c.V1 = c.V1 + 0x6FECu;  }
        { var _s = c.V0; var _t = c.V1; c.A2 = _s + _t;  }
        L801972A8: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        if (c.A3 != 0u) {
            { c.V0 = 0u | 0x0003u;  }
            goto L801972F4;
        }
        { c.V0 = 0u | 0x0003u;  }
        { c.V0 = 0u | 0x0006u;  }
        mem.WriteU8((c.A2 + 0x7u), (byte)c.V0); 
        { c.V0 = 0u | 0x00A0u;  }
        mem.WriteU16((c.A2 + 0xAu), (ushort)c.V0); 
        { c.V0 = 0u | 0x00F0u;  }
        mem.WriteU8((c.A2 + 0x18u), (byte)c.V0); 
        { c.V0 = 0u | 0x01A1u;  }
        mem.WriteU16((c.A2 + 0xEu), (ushort)c.V0); 
        { c.V0 = 0u | 0x01FEu;  }
        mem.WriteU16((c.A2 + 0x26u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0008u;  }
        mem.WriteU16((c.A2 + 0x1Au), (ushort)c.T0); 
        mem.WriteU16((c.A2 + 0x8u), (ushort)c.T0); 
        mem.WriteU8((c.A2 + 0xCu), (byte)0u); 
        mem.WriteU8((c.A2 + 0xDu), (byte)0u); 
        mem.WriteU8((c.A2 + 0x19u), (byte)c.T0); 
        goto L80197380;
        L801972F4: ;
        mem.WriteU8((c.A2 + 0x7u), (byte)c.V0); 
        { c.V0 = 0u | 0x0001u;  }
        mem.WriteU16((c.A2 + 0x2Cu), (ushort)c.A0); 
        mem.WriteU16((c.A2 + 0x20u), (ushort)c.A0); 
        mem.WriteU16((c.A2 + 0x14u), (ushort)c.A0); 
        mem.WriteU16((c.A2 + 0x8u), (ushort)c.A0); 
        mem.WriteU16((c.A2 + 0x2Eu), (ushort)c.A1); 
        mem.WriteU16((c.A2 + 0x22u), (ushort)c.A1); 
        mem.WriteU16((c.A2 + 0x16u), (ushort)c.A1); 
        mem.WriteU16((c.A2 + 0xAu), (ushort)c.A1); 
        mem.WriteU8((c.A2 + 0x28u), (byte)0u); 
        mem.WriteU8((c.A2 + 0x1Cu), (byte)0u); 
        mem.WriteU8((c.A2 + 0x10u), (byte)0u); 
        mem.WriteU8((c.A2 + 0x4u), (byte)0u); 
        mem.WriteU8((c.A2 + 0x29u), (byte)0u); 
        mem.WriteU8((c.A2 + 0x1Du), (byte)0u); 
        mem.WriteU8((c.A2 + 0x11u), (byte)0u); 
        mem.WriteU8((c.A2 + 0x5u), (byte)0u); 
        mem.WriteU8((c.A2 + 0x2Au), (byte)0u); 
        mem.WriteU8((c.A2 + 0x1Eu), (byte)0u); 
        mem.WriteU8((c.A2 + 0x12u), (byte)0u); 
        if (c.A3 != c.V0) {
            mem.WriteU8((c.A2 + 0x6u), (byte)0u); 
            goto L80197364;
        }
        mem.WriteU8((c.A2 + 0x6u), (byte)0u); 
        mem.WriteU8((c.A2 + 0x2Au), (byte)c.A0); 
        mem.WriteU8((c.A2 + 0x1Eu), (byte)c.A0); 
        mem.WriteU8((c.A2 + 0x12u), (byte)c.A0); 
        mem.WriteU8((c.A2 + 0x6u), (byte)c.A0); 
        goto L80197374;
        L80197364: ;
        mem.WriteU8((c.A2 + 0x29u), (byte)c.A0); 
        mem.WriteU8((c.A2 + 0x1Du), (byte)c.A0); 
        mem.WriteU8((c.A2 + 0x11u), (byte)c.A0); 
        mem.WriteU8((c.A2 + 0x5u), (byte)c.A0); 
        L80197374: ;
        { c.V0 = 0u | 0x01FDu;  }
        mem.WriteU16((c.A2 + 0x26u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0011u;  }
        L80197380: ;
        mem.WriteU16((c.A2 + 0x32u), (ushort)c.V0); 
        c.A2 = mem.ReadU32(c.A2); 
        { c.A3 = c.A3 + 0x1u;  }
        { c.V0 = (int)c.A3 < 3 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L801972A8;
        }
        c.V0 = mem.ReadU16((c.S1 + 0x2Cu)); 
        { c.V0 = c.V0 + 0x1u;  }
        goto L8019768C;
        L801973A4: ;
        c.S0 = 0u; 
        c.S3 = 0x80080000u; 
        { c.S3 = c.S3 - 0x101Cu;  }
        c.V0 = c.S3; 
        c.A0 = 0x80180000u; 
        c.A0 = mem.ReadU32((c.A0 + 0x10ACu)); 
        { c.A3 = 0u | 0x0BFFu;  }
        mem.WriteU16((c.SP + 0x28u), (ushort)0u); 
        L801973C4: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        mem.WriteU8(c.V0, (byte)0u); 
        { c.A3 = c.A3 - 0x1u;  }
        if ((int)c.A3 >= 0) {
            { c.V0 = c.V0 + 0x1u;  }
            goto L801973C4;
        }
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.SP + 0x28u), (ushort)0u); 
        { c.S2 = c.S4 << 4;  }
        L801973DC: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V0 = mem.ReadU8(c.A0); 
        if (c.V0 != 0u) {
            { c.A1 = c.SP + 0x28u;  }
            goto L80197410;
        }
        { c.A1 = c.SP + 0x28u;  }
        if (c.S0 != 0u) {
            { c.S0 = 0u | 0x0001u;  }
            goto L80197424;
        }
        { c.S0 = 0u | 0x0001u;  }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x37B0u)); 
        { var _s = c.S2; var _t = c.V0; c.V0 = _s + _t;  }
        c.A0 = mem.ReadU32(c.V0); 
        goto L801973DC;
        L80197410: ;
        c.A2 = c.S3; 
        { c.A3 = 0u | 0x00C0u;  }
        c.RA = 0x8019741Cu; 
        SoTN_cen.BlitChar_cen(c, m);
        c.A0 = c.V0; 
        goto L801973DC;
        L80197424: ;
        c.A0 = c.S3; 
        c.A1 = 0u; 
        c.A2 = 0u; 
        c.A3 = 0u; 
        { c.V0 = 0u | 0x0100u;  }
        mem.WriteU32((c.SP + 0x10u), c.V0); 
        { c.V0 = 0u | 0x0180u;  }
        mem.WriteU32((c.SP + 0x14u), c.V0); 
        { c.V0 = 0u | 0x0010u;  }
        mem.WriteU32((c.SP + 0x18u), c.V0); 
        c.RA = 0x80197450u; 
        SoTN_main.LoadTPage(c, m);
        c.V0 = mem.ReadU16((c.S1 + 0x2Cu)); 
        mem.WriteU16((c.S1 + 0x7Cu), (ushort)0u); 
        c.V1 = mem.ReadU16((c.SP + 0x28u)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S1 + 0x7Eu), (ushort)c.V1); 
        mem.WriteU16((c.S1 + 0x2Cu), (ushort)c.V0); 
        goto L801977F4;
        L8019746C: ;
        c.V1 = mem.ReadU32((c.S1 + 0x64u)); 
        c.A3 = 0u; 
        { c.V0 = c.V1 << 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.At = 0x80080000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.A2 = mem.ReadU32((c.At + 0x6FECu)); 
        L80197494: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        if (c.A3 != 0u) {
            goto L801974C8;
        }
        c.A0 = mem.ReadU16((c.A2 + 0x16u)); 
        c.A1 = mem.ReadU16((c.A2 + 0x2Eu)); 
        c.V0 = mem.ReadU16((c.A2 + 0x20u)); 
        c.V1 = mem.ReadU16((c.A2 + 0x2Cu)); 
        { c.A0 = c.A0 - 0x4u;  }
        { c.A1 = c.A1 + 0x2u;  }
        { c.V0 = c.V0 - 0x3u;  }
        { c.V1 = c.V1 + 0x3u;  }
        mem.WriteU16((c.A2 + 0x20u), (ushort)c.V0); 
        mem.WriteU16((c.A2 + 0x2Cu), (ushort)c.V1); 
        goto L801974F0;
        L801974C8: ;
        c.A0 = mem.ReadU16((c.A2 + 0x16u)); 
        c.A1 = mem.ReadU16((c.A2 + 0x2Eu)); 
        c.V0 = mem.ReadU16((c.A2 + 0x8u)); 
        c.V1 = mem.ReadU16((c.A2 + 0x14u)); 
        { c.A0 = c.A0 - 0x2u;  }
        { c.A1 = c.A1 + 0x4u;  }
        { c.V0 = c.V0 - 0x3u;  }
        { c.V1 = c.V1 + 0x3u;  }
        mem.WriteU16((c.A2 + 0x8u), (ushort)c.V0); 
        mem.WriteU16((c.A2 + 0x14u), (ushort)c.V1); 
        L801974F0: ;
        mem.WriteU16((c.A2 + 0x16u), (ushort)c.A0); 
        mem.WriteU16((c.A2 + 0xAu), (ushort)c.A0); 
        mem.WriteU16((c.A2 + 0x2Eu), (ushort)c.A1); 
        mem.WriteU16((c.A2 + 0x22u), (ushort)c.A1); 
        c.A2 = mem.ReadU32(c.A2); 
        { c.A3 = c.A3 + 0x1u;  }
        { c.V0 = (int)c.A3 < 2 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L80197664;
        }
        goto L80197494;
        L8019751C: ;
        c.A3 = 0u; 
        c.A2 = 0x92490000u; 
        c.A1 = mem.ReadU16((c.S1 + 0x7Cu)); 
        { c.A2 = c.A2 | 0x2493u;  }
        { c.V0 = c.A1 + 0x1u;  }
        { c.V1 = c.V0 << 1;  }
        { var _s = c.V1; var _t = c.V0; c.V1 = _s + _t;  }
        { c.V1 = c.V1 << 2;  }
        { c.A0 = c.A1 << 4;  }
        { var _s = c.A0; var _t = c.A1; c.A0 = _s - _t;  }
        { c.A0 = c.A0 << 3;  }
        { var _s = c.A0; var _t = c.A2; var _r = (long)(int)_s * (int)_t; c.LO = (uint)_r; c.HI = (uint)(_r >> 32);  }
        { c.V0 = 0u | 0x0080u;  }
        { var _s = c.V0; var _t = c.V1; c.T1 = _s - _t;  }
        { c.T0 = c.V1 + 0x80u;  }
        c.V1 = mem.ReadU32((c.S1 + 0x64u)); 
        { c.A1 = c.A1 << 1;  }
        { c.V0 = c.V1 << 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.At = 0x80080000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.A2 = mem.ReadU32((c.At + 0x6FECu)); 
        c.V0 = c.HI; 
        { var _s = c.V0; var _t = c.A0; c.V0 = _s + _t;  }
        { c.V0 = (uint)((int)c.V0 >> 2);  }
        { c.A0 = (uint)((int)c.A0 >> 31);  }
        { var _s = c.V0; var _t = c.A0; c.A0 = _s - _t;  }
        L80197594: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        if (c.A3 != 0u) {
            { c.V0 = c.A0 + 0x68u;  }
            goto L801975F4;
        }
        { c.V0 = c.A0 + 0x68u;  }
        mem.WriteU16((c.A2 + 0x20u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0098u;  }
        { var _s = c.V0; var _t = c.A0; c.V0 = _s - _t;  }
        mem.WriteU16((c.A2 + 0x14u), (ushort)c.T1); 
        mem.WriteU16((c.A2 + 0x8u), (ushort)c.T0); 
        mem.WriteU16((c.A2 + 0x2Cu), (ushort)c.V0); 
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.A1; c.At = _s + _t;  }
        c.V0 = mem.ReadU16((c.At + 0x10C0u)); 
        { c.V0 = c.V0 + 0xA7u;  }
        mem.WriteU16((c.A2 + 0x16u), (ushort)c.V0); 
        mem.WriteU16((c.A2 + 0xAu), (ushort)c.V0); 
        c.V0 = mem.ReadU8((c.A2 + 0x2Au)); 
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.A1; c.At = _s + _t;  }
        c.V1 = mem.ReadU16((c.At + 0x10B0u)); 
        { c.V0 = c.V0 - 0x10u;  }
        { c.V1 = c.V1 + 0xA7u;  }
        mem.WriteU8((c.A2 + 0x2Au), (byte)c.V0); 
        mem.WriteU8((c.A2 + 0x1Eu), (byte)c.V0); 
        goto L80197648;
        L801975F4: ;
        mem.WriteU16((c.A2 + 0x8u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0098u;  }
        { var _s = c.V0; var _t = c.A0; c.V0 = _s - _t;  }
        mem.WriteU16((c.A2 + 0x14u), (ushort)c.V0); 
        mem.WriteU16((c.A2 + 0x2Cu), (ushort)c.T1); 
        mem.WriteU16((c.A2 + 0x20u), (ushort)c.T0); 
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.A1; c.At = _s + _t;  }
        c.V0 = mem.ReadU16((c.At + 0x10D0u)); 
        { c.V0 = c.V0 + 0xA7u;  }
        mem.WriteU16((c.A2 + 0x16u), (ushort)c.V0); 
        mem.WriteU16((c.A2 + 0xAu), (ushort)c.V0); 
        c.V0 = mem.ReadU8((c.A2 + 0x11u)); 
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.A1; c.At = _s + _t;  }
        c.V1 = mem.ReadU16((c.At + 0x10E0u)); 
        { c.V0 = c.V0 - 0x10u;  }
        { c.V1 = c.V1 + 0xA7u;  }
        mem.WriteU8((c.A2 + 0x11u), (byte)c.V0); 
        mem.WriteU8((c.A2 + 0x5u), (byte)c.V0); 
        L80197648: ;
        mem.WriteU16((c.A2 + 0x2Eu), (ushort)c.V1); 
        mem.WriteU16((c.A2 + 0x22u), (ushort)c.V1); 
        c.A2 = mem.ReadU32(c.A2); 
        { c.A3 = c.A3 + 0x1u;  }
        { c.V0 = (int)c.A3 < 3 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L80197594;
        }
        L80197664: ;
        c.V0 = mem.ReadU16((c.S1 + 0x7Cu)); 
        { c.V1 = 0u | 0x0008u;  }
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S1 + 0x7Cu), (ushort)c.V0); 
        { c.V0 = c.V0 & 0xFFFFu;  }
        if (c.V0 != c.V1) {
            goto L801977F4;
        }
        c.V0 = mem.ReadU16((c.S1 + 0x2Cu)); 
        mem.WriteU16((c.S1 + 0x7Cu), (ushort)0u); 
        { c.V0 = c.V0 + 0x1u;  }
        L8019768C: ;
        mem.WriteU16((c.S1 + 0x2Cu), (ushort)c.V0); 
        goto L801977F4;
        L80197694: ;
        c.V1 = mem.ReadU32((c.S1 + 0x64u)); 
        { c.V0 = c.V1 << 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.V1 = 0x80080000u; 
        { c.V1 = c.V1 + 0x6FECu;  }
        { var _s = c.V0; var _t = c.V1; c.A2 = _s + _t;  }
        c.V1 = mem.ReadU16((c.S1 + 0x7Eu)); 
        { c.V0 = 0u | 0x0080u;  }
        mem.WriteU16((c.A2 + 0x32u), (ushort)0u); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s - _t;  }
        mem.WriteU16((c.A2 + 0x8u), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S1 + 0x7Cu)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S1 + 0x7Cu), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S1 + 0x7Cu)); 
        { c.V0 = c.V0 < 0x00000061u ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L801977F4;
        }
        L801976F4: ;
        c.A0 = c.S1; 
        c.RA = 0x801976FCu; 
        SoTN_cen.DestroyEntity_cen(c, m);
        goto L801979D8;
        L80197704: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        { c.V0 = 0u | 0x001Au;  }
        mem.WriteU16((c.A2 + 0x1Au), (ushort)c.V0); 
        { c.V0 = 0u | 0x01B1u;  }
        mem.WriteU16((c.A2 + 0xEu), (ushort)c.V0); 
        { c.V0 = 0u | 0x0010u;  }
        mem.WriteU8((c.A2 + 0x30u), (byte)c.V0); 
        mem.WriteU8((c.A2 + 0x18u), (byte)c.V0); 
        { c.V0 = 0u | 0x0050u;  }
        mem.WriteU8((c.A2 + 0x19u), (byte)c.V0); 
        mem.WriteU8((c.A2 + 0xDu), (byte)c.V0); 
        { c.V0 = 0u | 0x0060u;  }
        mem.WriteU8((c.A2 + 0x24u), (byte)0u); 
        mem.WriteU8((c.A2 + 0xCu), (byte)0u); 
        mem.WriteU8((c.A2 + 0x31u), (byte)c.V0); 
        mem.WriteU8((c.A2 + 0x25u), (byte)c.V0); 
        c.V1 = mem.ReadU16((c.S1 + 0x82u)); 
        c.S0 = mem.ReadU16((c.S1 + 0x2u)); 
        { c.V1 = c.V1 & 0x0007u;  }
        { c.V1 = c.V1 << 1;  }
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.V1; c.At = _s + _t;  }
        c.V0 = mem.ReadU16((c.At + 0x10F0u)); 
        { var _s = c.S0; var _t = c.V0; c.V0 = _s + _t;  }
        { c.A0 = c.V0 - 0x6u;  }
        { c.V0 = c.V0 + 0x6u;  }
        mem.WriteU16((c.A2 + 0x20u), (ushort)c.A0); 
        mem.WriteU16((c.A2 + 0x8u), (ushort)c.A0); 
        mem.WriteU16((c.A2 + 0x2Cu), (ushort)c.V0); 
        mem.WriteU16((c.A2 + 0x14u), (ushort)c.V0); 
        c.S0 = mem.ReadU16((c.S1 + 0x6u)); 
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.V1; c.At = _s + _t;  }
        c.V1 = mem.ReadU16((c.At + 0x1100u)); 
        { c.V0 = 0u | 0x0080u;  }
        mem.WriteU8((c.A2 + 0x28u), (byte)c.V0); 
        mem.WriteU8((c.A2 + 0x1Cu), (byte)c.V0); 
        mem.WriteU8((c.A2 + 0x10u), (byte)c.V0); 
        mem.WriteU8((c.A2 + 0x4u), (byte)c.V0); 
        mem.WriteU8((c.A2 + 0x29u), (byte)c.V0); 
        mem.WriteU8((c.A2 + 0x1Du), (byte)c.V0); 
        mem.WriteU8((c.A2 + 0x11u), (byte)c.V0); 
        mem.WriteU8((c.A2 + 0x5u), (byte)c.V0); 
        mem.WriteU8((c.A2 + 0x2Au), (byte)c.V0); 
        mem.WriteU8((c.A2 + 0x1Eu), (byte)c.V0); 
        { var _s = c.S0; var _t = c.V1; c.V1 = _s + _t;  }
        { c.A0 = c.V1 - 0x6u;  }
        { c.V1 = c.V1 + 0x6u;  }
        mem.WriteU16((c.A2 + 0x16u), (ushort)c.A0); 
        mem.WriteU16((c.A2 + 0xAu), (ushort)c.A0); 
        mem.WriteU16((c.A2 + 0x2Eu), (ushort)c.V1); 
        mem.WriteU16((c.A2 + 0x22u), (ushort)c.V1); 
        mem.WriteU8((c.A2 + 0x12u), (byte)c.V0); 
        mem.WriteU8((c.A2 + 0x6u), (byte)c.V0); 
        { c.V0 = 0u | 0x007Fu;  }
        mem.WriteU16((c.A2 + 0x26u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0037u;  }
        mem.WriteU8((c.A2 + 0x13u), (byte)0u); 
        mem.WriteU16((c.A2 + 0x32u), (ushort)c.V0); 
        goto L80197884;
        L801977F4: ;
        c.V0 = mem.ReadU16((c.S1 + 0x2Cu)); 
        { c.V0 = c.V0 < 0x00000002u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L801978AC;
        }
        c.A1 = 0x80040000u; 
        c.A1 = mem.ReadU16((c.A1 - 0x3668u)); 
        c.A0 = c.S1; 
        c.RA = 0x80197818u; 
        SoTN_cen.BlinkItem_cen(c, m);
        c.V0 = mem.ReadU32((c.S1 + 0x64u)); 
        { c.A3 = 0u | 0x0002u;  }
        { c.V1 = c.V0 << 1;  }
        { var _s = c.V1; var _t = c.V0; c.V1 = _s + _t;  }
        { c.V1 = c.V1 << 2;  }
        { var _s = c.V1; var _t = c.V0; c.V1 = _s + _t;  }
        { c.V1 = c.V1 << 2;  }
        c.V0 = 0x80080000u; 
        { c.V0 = c.V0 + 0x6FECu;  }
        { var _s = c.V1; var _t = c.V0; c.A2 = _s + _t;  }
        L80197840: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.A2 = mem.ReadU32(c.A2); 
        { c.A3 = c.A3 - 0x1u;  }
        if ((int)c.A3 >= 0) {
            goto L80197840;
        }
        c.V0 = mem.ReadU16((c.S1 + 0x80u)); 
        if (c.V0 != 0u) {
            c.A3 = 0u; 
            goto L8019789C;
        }
        c.A3 = 0u; 
        { c.V1 = 0u | 0x0008u;  }
        L80197864: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V0 = mem.ReadU16((c.A2 + 0x32u)); 
        if (c.V0 == c.V1) {
            { c.A3 = c.A3 + 0x1u;  }
            goto L80197704;
        }
        { c.A3 = c.A3 + 0x1u;  }
        c.A2 = mem.ReadU32(c.A2); 
        { c.V0 = (int)c.A3 < 4 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L80197864;
        }
        L80197884: ;
        c.V0 = mem.ReadU16((c.S1 + 0x82u)); 
        { c.V1 = 0u | 0x0004u;  }
        mem.WriteU16((c.S1 + 0x80u), (ushort)c.V1); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S1 + 0x82u), (ushort)c.V0); 
        goto L801978AC;
        L8019789C: ;
        c.V0 = mem.ReadU16((c.S1 + 0x80u)); 
        { c.V0 = c.V0 - 0x1u;  }
        mem.WriteU16((c.S1 + 0x80u), (ushort)c.V0); 
        L801978AC: ;
        c.V0 = mem.ReadU32((c.S1 + 0x64u)); 
        { c.A3 = 0u | 0x0002u;  }
        { c.V1 = c.V0 << 1;  }
        { var _s = c.V1; var _t = c.V0; c.V1 = _s + _t;  }
        { c.V1 = c.V1 << 2;  }
        { var _s = c.V1; var _t = c.V0; c.V1 = _s + _t;  }
        { c.V1 = c.V1 << 2;  }
        c.V0 = 0x80080000u; 
        { c.V0 = c.V0 + 0x6FECu;  }
        { var _s = c.V1; var _t = c.V0; c.A2 = _s + _t;  }
        L801978D4: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.A2 = mem.ReadU32(c.A2); 
        { c.A3 = c.A3 - 0x1u;  }
        if ((int)c.A3 >= 0) {
            goto L801978D4;
        }
        if (c.A2 == 0u) {
            { c.A3 = 0u | 0x0008u;  }
            goto L801979D8;
        }
        { c.A3 = 0u | 0x0008u;  }
        L801978EC: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V0 = mem.ReadU16((c.A2 + 0x32u)); 
        if (c.V0 == c.A3) {
            goto L801979C8;
        }
        c.V0 = mem.ReadU8((c.A2 + 0x13u)); 
        { c.V0 = c.V0 & 0x0003u;  }
        if (c.V0 == 0u) {
            goto L80197934;
        }
        c.V1 = mem.ReadU16((c.A2 + 0x16u)); 
        c.A0 = mem.ReadU16((c.A2 + 0x2Eu)); 
        { c.V0 = c.V1 - 0x1u;  }
        mem.WriteU16((c.A2 + 0x16u), (ushort)c.V0); 
        { c.V0 = c.A0 - 0x1u;  }
        mem.WriteU16((c.A2 + 0xAu), (ushort)c.V1); 
        mem.WriteU16((c.A2 + 0x2Eu), (ushort)c.V0); 
        mem.WriteU16((c.A2 + 0x22u), (ushort)c.A0); 
        goto L80197964;
        L80197934: ;
        c.V0 = mem.ReadU16((c.A2 + 0x2Eu)); 
        c.V1 = mem.ReadU16((c.A2 + 0x20u)); 
        c.A0 = mem.ReadU16((c.A2 + 0x2Cu)); 
        { c.V0 = c.V0 - 0x2u;  }
        mem.WriteU16((c.A2 + 0x2Eu), (ushort)c.V0); 
        mem.WriteU16((c.A2 + 0x22u), (ushort)c.V0); 
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU16((c.A2 + 0x20u), (ushort)c.V0); 
        { c.V0 = c.A0 - 0x1u;  }
        mem.WriteU16((c.A2 + 0x8u), (ushort)c.V1); 
        mem.WriteU16((c.A2 + 0x2Cu), (ushort)c.V0); 
        mem.WriteU16((c.A2 + 0x14u), (ushort)c.A0); 
        L80197964: ;
        c.V1 = mem.ReadU8((c.A2 + 0x28u)); 
        c.A0 = mem.ReadU8((c.A2 + 0x29u)); 
        c.V0 = mem.ReadU8((c.A2 + 0x13u)); 
        { c.V1 = c.V1 - 0x6u;  }
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU8((c.A2 + 0x13u), (byte)c.V0); 
        c.V0 = mem.ReadU8((c.A2 + 0x2Au)); 
        c.A1 = mem.ReadU8((c.A2 + 0x13u)); 
        { c.A0 = c.A0 - 0x6u;  }
        mem.WriteU8((c.A2 + 0x28u), (byte)c.V1); 
        mem.WriteU8((c.A2 + 0x1Cu), (byte)c.V1); 
        mem.WriteU8((c.A2 + 0x10u), (byte)c.V1); 
        mem.WriteU8((c.A2 + 0x4u), (byte)c.V1); 
        mem.WriteU8((c.A2 + 0x29u), (byte)c.A0); 
        mem.WriteU8((c.A2 + 0x1Du), (byte)c.A0); 
        mem.WriteU8((c.A2 + 0x11u), (byte)c.A0); 
        mem.WriteU8((c.A2 + 0x5u), (byte)c.A0); 
        { c.V0 = c.V0 - 0x6u;  }
        { c.A1 = c.A1 < 0x00000011u ? 1u : 0u;  }
        mem.WriteU8((c.A2 + 0x2Au), (byte)c.V0); 
        mem.WriteU8((c.A2 + 0x1Eu), (byte)c.V0); 
        mem.WriteU8((c.A2 + 0x12u), (byte)c.V0); 
        if (c.A1 != 0u) {
            mem.WriteU8((c.A2 + 0x6u), (byte)c.V0); 
            goto L801979C8;
        }
        mem.WriteU8((c.A2 + 0x6u), (byte)c.V0); 
        mem.WriteU16((c.A2 + 0x32u), (ushort)c.A3); 
        L801979C8: ;
        c.A2 = mem.ReadU32(c.A2); 
        if (c.A2 != 0u) {
            goto L801978EC;
        }
        L801979D8: ;
        c.RA = mem.ReadU32((c.SP + 0x48u)); 
        c.S5 = mem.ReadU32((c.SP + 0x44u)); 
        c.S4 = mem.ReadU32((c.SP + 0x40u)); 
        c.S3 = mem.ReadU32((c.SP + 0x3Cu)); 
        c.S2 = mem.ReadU32((c.SP + 0x38u)); 
        c.S1 = mem.ReadU32((c.SP + 0x34u)); 
        c.S0 = mem.ReadU32((c.SP + 0x30u)); 
        { c.SP = c.SP + 0x50u;  }
        return;
        { c.SP = c.SP - 0x18u;  }
        c.A2 = c.A0; 
        mem.WriteU32((c.SP + 0x10u), c.RA); 
        c.V0 = mem.ReadU16((c.A2 + 0x2Cu)); 
        if (c.V0 != 0u) {
            { c.V0 = c.V0 < 0x00000005u ? 1u : 0u;  }
            goto L80197ABC;
        }
        { c.V0 = c.V0 < 0x00000005u ? 1u : 0u;  }
        c.V0 = mem.ReadU16((c.A2 + 0x30u)); 
        { c.A0 = c.V0 + 0xC0u;  }
        c.V0 = c.A0; 
        mem.WriteU16((c.A2 + 0xB4u), (ushort)c.V0); 
        { c.V0 = c.V0 & 0xFFFFu;  }
        { c.V0 = c.V0 >> 3;  }
        c.At = 0x80040000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.V0 = mem.ReadU8((c.At - 0x4114u)); 
        { c.V1 = c.A0 & 0x0007u;  }
        { var _s = c.V1; var _t = c.V0; c.V0 = (uint)((int)_t >> (int)(_s & 31u));  }
        { c.V0 = c.V0 & 0x0001u;  }
        if (c.V0 == 0u) {
            { c.A0 = c.A0 - 0xC0u;  }
            goto L80197A68;
        }
        { c.A0 = c.A0 - 0xC0u;  }
        c.A0 = c.A2; 
        c.RA = 0x80197A60u; 
        SoTN_cen.DestroyEntity_cen(c, m);
        goto L80197B18;
        L80197A68: ;
        { c.V0 = c.A0 & 0xFFFFu;  }
        { c.V0 = c.V0 << 1;  }
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.A0 = mem.ReadU16((c.At + 0x5D8u)); 
        { c.V0 = c.A0 < 0x00000080u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L80197A9C;
        }
        c.V0 = 0x80190000u; 
        { c.V0 = c.V0 + 0x5C84u;  }
        mem.WriteU32((c.A2 + 0xB8u), c.V0); 
        goto L80197AAC;
        L80197A9C: ;
        c.V0 = 0x80190000u; 
        { c.V0 = c.V0 + 0x6698u;  }
        mem.WriteU32((c.A2 + 0xB8u), c.V0); 
        { c.A0 = c.A0 - 0x80u;  }
        L80197AAC: ;
        { c.V0 = 0u | 0x8000u;  }
        { var _s = c.A0; var _t = c.V0; c.V0 = _s + _t;  }
        mem.WriteU16((c.A2 + 0x30u), (ushort)c.V0); 
        goto L80197B08;
        L80197ABC: ;
        c.A0 = mem.ReadU16((c.A2 + 0xB4u)); 
        if (c.V0 == 0u) {
            goto L80197B08;
        }
        c.V0 = mem.ReadU8((c.A2 + 0x48u)); 
        if (c.V0 == 0u) {
            { c.A1 = c.A0 >> 3;  }
            goto L80197B08;
        }
        { c.A1 = c.A0 >> 3;  }
        { c.A0 = c.A0 & 0x0007u;  }
        { c.V0 = 0u | 0x0001u;  }
        c.At = 0x80040000u; 
        { var _s = c.At; var _t = c.A1; c.At = _s + _t;  }
        c.V1 = mem.ReadU8((c.At - 0x4114u)); 
        { var _s = c.A0; var _t = c.V0; c.V0 = _t << (int)(_s & 31u);  }
        { var _s = c.V1; var _t = c.V0; c.V1 = _s | _t;  }
        { c.V0 = 0u | 0x0005u;  }
        c.At = 0x80040000u; 
        { var _s = c.At; var _t = c.A1; c.At = _s + _t;  }
        mem.WriteU8((c.At - 0x4114u), (byte)c.V1); 
        mem.WriteU16((c.A2 + 0x2Cu), (ushort)c.V0); 
        L80197B08: ;
        c.V0 = mem.ReadU32((c.A2 + 0xB8u)); 
        c.A0 = c.A2; 
        c.RA = 0x80197B18u;
        Dispatcher.Call(c, m, c.V0);
        L80197B18: ;
        c.RA = mem.ReadU32((c.SP + 0x10u)); 
        { c.SP = c.SP + 0x18u;  }
        return;
        { c.SP = c.SP - 0x50u;  }
        mem.WriteU32((c.SP + 0x38u), c.S0); 
        c.S0 = c.A0; 
        mem.WriteU32((c.SP + 0x48u), c.RA); 
        mem.WriteU32((c.SP + 0x44u), c.S3); 
        mem.WriteU32((c.SP + 0x40u), c.S2); 
        mem.WriteU32((c.SP + 0x3Cu), c.S1); 
        c.V1 = mem.ReadU16((c.S0 + 0x2Cu)); 
        { c.V0 = c.V1 < 0x00000005u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.V0 = c.V1 << 2;  }
            goto L80198064;
        }
        { c.V0 = c.V1 << 2;  }
        c.At = 0x80190000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.V0 = mem.ReadU32((c.At - 0x2A50u)); 
        switch (c.V0)
        {
            case 0x80197B70u: goto L80197B70;
            case 0x80197C54u: goto L80197C54;
            case 0x80197E30u: goto L80197E30;
            case 0x80197F08u: goto L80197F08;
            case 0x8019800Cu: goto L8019800C;
            default: Dispatcher.Call(c, m, c.V0); return;
        }
        L80197B70: ;
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x410u;  }
        c.RA = 0x80197B80u; 
        SoTN_cen.InitializeEntity_cen(c, m);
        c.V1 = 0x00010000u; 
        c.V0 = mem.ReadU32((c.S0 + 0x34u)); 
        c.A0 = mem.ReadU16((c.S0 + 0x30u)); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s | _t;  }
        c.V1 = 0x08000000u; 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s ^ _t;  }
        if (c.A0 != 0u) {
            mem.WriteU32((c.S0 + 0x34u), c.V0); 
            goto L80197BA8;
        }
        mem.WriteU32((c.S0 + 0x34u), c.V0); 
        { c.V0 = 0u | 0x0060u;  }
        mem.WriteU16((c.S0 + 0x30u), (ushort)c.V0); 
        L80197BA8: ;
        { c.A0 = 0u | 0x0004u;  }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3848u)); 
        { c.A1 = 0u | 0x0003u;  }
        c.RA = 0x80197BC0u;
        Dispatcher.Call(c, m, c.V0);
        { c.V0 = c.V0 << 16;  }
        { c.A0 = (uint)((int)c.V0 >> 16);  }
        c.V0 = 0xFFFFFFFFu; 
        if (c.A0 != c.V0) {
            { c.V0 = c.A0 << 1;  }
            goto L80197BDC;
        }
        { c.V0 = c.A0 << 1;  }
        mem.WriteU16((c.S0 + 0x2Cu), (ushort)0u); 
        goto L80198064;
        L80197BDC: ;
        { var _s = c.V0; var _t = c.A0; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.A0; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.V1 = 0x80080000u; 
        { c.V1 = c.V1 + 0x6FECu;  }
        { var _s = c.V0; var _t = c.V1; c.A1 = _s + _t;  }
        c.V0 = mem.ReadU32((c.S0 + 0x34u)); 
        c.V1 = 0x00800000u; 
        mem.WriteU32((c.S0 + 0x64u), c.A0); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s | _t;  }
        if (c.A1 == 0u) {
            mem.WriteU32((c.S0 + 0x34u), c.V0); 
            goto L80197C28;
        }
        mem.WriteU32((c.S0 + 0x34u), c.V0); 
        { c.V0 = 0u | 0x0008u;  }
        L80197C14: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        mem.WriteU16((c.A1 + 0x32u), (ushort)c.V0); 
        c.A1 = mem.ReadU32(c.A1); 
        if (c.A1 != 0u) {
            goto L80197C14;
        }
        L80197C28: ;
        c.A0 = mem.ReadU32((c.S0 + 0x7Cu)); 
        c.V0 = mem.ReadU8(c.A0); 
        mem.WriteU16((c.S0 + 0x80u), (ushort)c.V0); 
        c.V0 = mem.ReadU32((c.S0 + 0x7Cu)); 
        c.V1 = mem.ReadU8((c.A0 + 0x1u)); 
        { c.V0 = c.V0 + 0x2u;  }
        mem.WriteU32((c.S0 + 0x7Cu), c.V0); 
        mem.WriteU16((c.S0 + 0x82u), (ushort)c.V1); 
        goto L80198064;
        L80197C54: ;
        { c.A0 = c.SP + 0x20u;  }
        c.A1 = 0u; 
        c.A2 = 0u; 
        { c.V0 = 0u | 0x0180u;  }
        mem.WriteU16((c.SP + 0x22u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0040u;  }
        mem.WriteU16((c.SP + 0x20u), (ushort)0u); 
        mem.WriteU16((c.SP + 0x24u), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S0 + 0x82u)); 
        c.A3 = 0u; 
        mem.WriteU16((c.SP + 0x26u), (ushort)c.V0); 
        c.RA = 0x80197C84u; 
        DialogueGlyphs.Clear(c, mem);
        c.V1 = mem.ReadU32((c.S0 + 0x64u)); 
        { c.V0 = c.V1 << 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.V1 = 0x80080000u; 
        { c.V1 = c.V1 + 0x6FECu;  }
        { var _s = c.V0; var _t = c.V1; c.A1 = _s + _t;  }
        if (c.A1 == 0u) {
            c.A2 = 0u; 
            goto L80197E24;
        }
        c.A2 = 0u; 
        { c.A0 = 0u | 0x0080u;  }
        L80197CB8: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        if (c.A2 != 0u) {
            { c.V0 = 0u | 0x0003u;  }
            goto L80197D30;
        }
        { c.V0 = 0u | 0x0003u;  }
        { c.V0 = 0u | 0x0006u;  }
        mem.WriteU8((c.A1 + 0x7u), (byte)c.V0); 
        { c.V0 = 0u | 0x0010u;  }
        mem.WriteU16((c.A1 + 0x1Au), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S0 + 0x80u)); 
        c.V1 = mem.ReadU16((c.S0 + 0x2u)); 
        { c.V0 = c.V0 >> 1;  }
        { var _s = c.V1; var _t = c.V0; c.V1 = _s - _t;  }
        mem.WriteU16((c.A1 + 0x8u), (ushort)c.V1); 
        c.V0 = mem.ReadU16((c.S0 + 0x82u)); 
        c.V1 = mem.ReadU16((c.S0 + 0x6u)); 
        mem.WriteU8((c.A1 + 0xCu), (byte)0u); 
        mem.WriteU8((c.A1 + 0xDu), (byte)c.A0); 
        { c.V0 = c.V0 >> 1;  }
        { var _s = c.V1; var _t = c.V0; c.V1 = _s - _t;  }
        mem.WriteU16((c.A1 + 0xAu), (ushort)c.V1); 
        c.V0 = mem.ReadU8((c.S0 + 0x80u)); 
        mem.WriteU8((c.A1 + 0x18u), (byte)c.V0); 
        c.V1 = mem.ReadU8((c.S0 + 0x82u)); 
        { c.V0 = 0u | 0x01A1u;  }
        mem.WriteU16((c.A1 + 0xEu), (ushort)c.V0); 
        { c.V0 = 0u | 0x01FDu;  }
        mem.WriteU16((c.A1 + 0x26u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0008u;  }
        mem.WriteU16((c.A1 + 0x32u), (ushort)c.V0); 
        mem.WriteU8((c.A1 + 0x19u), (byte)c.V1); 
        goto L80197E14;
        L80197D30: ;
        mem.WriteU8((c.A1 + 0x7u), (byte)c.V0); 
        c.V1 = mem.ReadU16((c.S0 + 0x80u)); 
        c.V0 = mem.ReadU16((c.S0 + 0x2u)); 
        { c.V1 = c.V1 >> 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s - _t;  }
        { c.V0 = c.V0 - 0x4u;  }
        mem.WriteU16((c.A1 + 0x20u), (ushort)c.V0); 
        mem.WriteU16((c.A1 + 0x8u), (ushort)c.V0); 
        c.V1 = mem.ReadU16((c.S0 + 0x80u)); 
        c.V0 = mem.ReadU16((c.S0 + 0x2u)); 
        mem.WriteU8((c.A1 + 0x28u), (byte)0u); 
        mem.WriteU8((c.A1 + 0x1Cu), (byte)0u); 
        mem.WriteU8((c.A1 + 0x10u), (byte)0u); 
        mem.WriteU8((c.A1 + 0x4u), (byte)0u); 
        mem.WriteU8((c.A1 + 0x29u), (byte)0u); 
        mem.WriteU8((c.A1 + 0x1Du), (byte)0u); 
        mem.WriteU8((c.A1 + 0x11u), (byte)0u); 
        mem.WriteU8((c.A1 + 0x5u), (byte)0u); 
        mem.WriteU8((c.A1 + 0x2Au), (byte)0u); 
        mem.WriteU8((c.A1 + 0x1Eu), (byte)0u); 
        mem.WriteU8((c.A1 + 0x12u), (byte)0u); 
        mem.WriteU8((c.A1 + 0x6u), (byte)0u); 
        { c.V1 = c.V1 >> 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 + 0x4u;  }
        mem.WriteU16((c.A1 + 0x2Cu), (ushort)c.V0); 
        mem.WriteU16((c.A1 + 0x14u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0001u;  }
        if (c.A2 != c.V0) {
            goto L80197DD0;
        }
        c.V1 = mem.ReadU16((c.S0 + 0x82u)); 
        c.V0 = mem.ReadU16((c.S0 + 0x6u)); 
        mem.WriteU8((c.A1 + 0x2Au), (byte)c.A0); 
        mem.WriteU8((c.A1 + 0x1Eu), (byte)c.A0); 
        mem.WriteU8((c.A1 + 0x12u), (byte)c.A0); 
        mem.WriteU8((c.A1 + 0x6u), (byte)c.A0); 
        { c.V1 = c.V1 >> 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s - _t;  }
        { c.V0 = c.V0 - 0x4u;  }
        goto L80197DF4;
        L80197DD0: ;
        c.V1 = mem.ReadU16((c.S0 + 0x82u)); 
        c.V0 = mem.ReadU16((c.S0 + 0x6u)); 
        mem.WriteU8((c.A1 + 0x29u), (byte)c.A0); 
        mem.WriteU8((c.A1 + 0x1Du), (byte)c.A0); 
        mem.WriteU8((c.A1 + 0x11u), (byte)c.A0); 
        mem.WriteU8((c.A1 + 0x5u), (byte)c.A0); 
        { c.V1 = c.V1 >> 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 + 0x4u;  }
        L80197DF4: ;
        mem.WriteU16((c.A1 + 0x2Eu), (ushort)c.V0); 
        mem.WriteU16((c.A1 + 0x22u), (ushort)c.V0); 
        mem.WriteU16((c.A1 + 0x16u), (ushort)c.V0); 
        mem.WriteU16((c.A1 + 0xAu), (ushort)c.V0); 
        { c.V0 = 0u | 0x01FCu;  }
        mem.WriteU16((c.A1 + 0x26u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0011u;  }
        mem.WriteU16((c.A1 + 0x32u), (ushort)c.V0); 
        L80197E14: ;
        c.A1 = mem.ReadU32(c.A1); 
        if (c.A1 != 0u) {
            { c.A2 = c.A2 + 0x1u;  }
            goto L80197CB8;
        }
        { c.A2 = c.A2 + 0x1u;  }
        L80197E24: ;
        c.V0 = mem.ReadU16((c.S0 + 0x2Cu)); 
        { c.V0 = c.V0 + 0x1u;  }
        goto L80198004;
        L80197E30: ;
        c.V0 = mem.ReadU16((c.S0 + 0x80u)); 
        c.V1 = mem.ReadU16((c.S0 + 0x82u)); 
        { c.V0 = c.V0 >> 1;  }
        { var _s = c.V0; var _t = c.V1; var _r = (long)(int)_s * (int)_t; c.LO = (uint)_r; c.HI = (uint)(_r >> 32);  }
        c.S2 = 0x80080000u; 
        { c.S2 = c.S2 - 0x101Cu;  }
        c.S1 = c.S2; 
        c.A0 = mem.ReadU32((c.S0 + 0x7Cu)); 
        c.A2 = 0u; 
        c.V0 = c.LO; 
        if ((int)c.V0 <= 0) {
            mem.WriteU16((c.SP + 0x28u), (ushort)0u); 
            goto L80197E8C;
        }
        mem.WriteU16((c.SP + 0x28u), (ushort)0u); 
        L80197E60: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        mem.WriteU8(c.S1, (byte)0u); 
        c.V0 = mem.ReadU16((c.S0 + 0x80u)); 
        c.V1 = mem.ReadU16((c.S0 + 0x82u)); 
        { c.V0 = c.V0 >> 1;  }
        { var _s = c.V0; var _t = c.V1; var _r = (long)(int)_s * (int)_t; c.LO = (uint)_r; c.HI = (uint)(_r >> 32);  }
        { c.A2 = c.A2 + 0x1u;  }
        c.V0 = c.LO; 
        { var _s = c.A2; var _t = c.V0; c.V0 = (int)_s < (int)_t ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.S1 = c.S1 + 0x1u;  }
            goto L80197E60;
        }
        { c.S1 = c.S1 + 0x1u;  }
        c.S1 = c.S2; 
        L80197E8C: ;
        { c.S3 = 0u | 0x0001u;  }
        L80197E90: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V0 = mem.ReadU8(c.A0); 
        if (c.V0 == 0u) {
            c.A1 = 0u; 
            goto L80197ED8;
        }
        c.A1 = 0u; 
        if (c.V0 != c.S3) {
            { c.A1 = c.SP + 0x28u;  }
            goto L80197EC0;
        }
        { c.A1 = c.SP + 0x28u;  }
        c.V0 = mem.ReadU16((c.S0 + 0x80u)); 
        { c.A0 = c.A0 + 0x1u;  }
        mem.WriteU16((c.SP + 0x28u), (ushort)0u); 
        { c.V0 = c.V0 << 3;  }
        { var _s = c.S2; var _t = c.V0; c.S1 = _s + _t;  }
        goto L80197E90;
        L80197EC0: ;
        c.A3 = mem.ReadU16((c.S0 + 0x80u)); 
        c.A2 = c.S1; 
        { c.A3 = c.A3 >> 1;  }
        c.RA = 0x80197ED0u; 
        SoTN_cen.BlitChar_cen(c, m);
        c.A0 = c.V0; 
        goto L80197E90;
        L80197ED8: ;
        c.A0 = c.S2; 
        { c.V0 = 0u | 0x0180u;  }
        mem.WriteU32((c.SP + 0x10u), c.V0); 
        c.V0 = mem.ReadU16((c.S0 + 0x80u)); 
        c.A2 = 0u; 
        mem.WriteU32((c.SP + 0x14u), c.V0); 
        c.V0 = mem.ReadU16((c.S0 + 0x82u)); 
        c.A3 = 0u; 
        mem.WriteU32((c.SP + 0x18u), c.V0); 
        c.RA = 0x80197F00u; 
        SoTN_main.LoadTPage(c, m);
        goto L80197FF8;
        L80197F08: ;
        c.V0 = mem.ReadU16((c.S0 + 0x86u)); 
        c.V1 = mem.ReadU32((c.S0 + 0x64u)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S0 + 0x86u), (ushort)c.V0); 
        { c.V0 = c.V1 << 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.At = 0x80080000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.A1 = mem.ReadU32((c.At + 0x6FECu)); 
        if (c.A1 == 0u) {
            c.A2 = 0u; 
            goto L80197FE8;
        }
        c.A2 = 0u; 
        L80197F44: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        if (c.A2 != 0u) {
            goto L80197F94;
        }
        c.V0 = mem.ReadU16((c.S0 + 0x82u)); 
        c.V1 = mem.ReadU16((c.S0 + 0x86u)); 
        { c.V0 = c.V0 + 0x8u;  }
        { var _s = c.V0; var _t = c.V1; var _r = (long)(int)_s * (int)_t; c.LO = (uint)_r; c.HI = (uint)(_r >> 32);  }
        c.V0 = c.LO; 
        if ((int)c.V0 >= 0) {
            goto L80197F6C;
        }
        { c.V0 = c.V0 + 0x7u;  }
        L80197F6C: ;
        { c.V0 = (uint)((int)c.V0 >> 3);  }
        c.V1 = mem.ReadU16((c.A1 + 0xAu)); 
        c.A0 = mem.ReadU8((c.A1 + 0x12u)); 
        { var _s = c.V1; var _t = c.V0; c.V1 = _s + _t;  }
        { c.A0 = c.A0 - 0x10u;  }
        mem.WriteU16((c.A1 + 0x2Eu), (ushort)c.V1); 
        mem.WriteU16((c.A1 + 0x22u), (ushort)c.V1); 
        mem.WriteU8((c.A1 + 0x12u), (byte)c.A0); 
        mem.WriteU8((c.A1 + 0x6u), (byte)c.A0); 
        goto L80197FD8;
        L80197F94: ;
        c.V0 = mem.ReadU16((c.S0 + 0x82u)); 
        c.V1 = mem.ReadU16((c.S0 + 0x86u)); 
        { c.V0 = c.V0 + 0x8u;  }
        { var _s = c.V0; var _t = c.V1; var _r = (long)(int)_s * (int)_t; c.LO = (uint)_r; c.HI = (uint)(_r >> 32);  }
        c.V0 = c.LO; 
        if ((int)c.V0 >= 0) {
            goto L80197FB4;
        }
        { c.V0 = c.V0 + 0x7u;  }
        L80197FB4: ;
        { c.V0 = (uint)((int)c.V0 >> 3);  }
        c.V1 = mem.ReadU16((c.A1 + 0x22u)); 
        c.A0 = mem.ReadU8((c.A1 + 0x29u)); 
        { var _s = c.V1; var _t = c.V0; c.V1 = _s - _t;  }
        { c.A0 = c.A0 - 0x10u;  }
        mem.WriteU16((c.A1 + 0x16u), (ushort)c.V1); 
        mem.WriteU16((c.A1 + 0xAu), (ushort)c.V1); 
        mem.WriteU8((c.A1 + 0x29u), (byte)c.A0); 
        mem.WriteU8((c.A1 + 0x1Du), (byte)c.A0); 
        L80197FD8: ;
        c.A1 = mem.ReadU32(c.A1); 
        if (c.A1 != 0u) {
            { c.A2 = c.A2 + 0x1u;  }
            goto L80197F44;
        }
        { c.A2 = c.A2 + 0x1u;  }
        L80197FE8: ;
        c.V1 = mem.ReadU16((c.S0 + 0x86u)); 
        { c.V0 = 0u | 0x0008u;  }
        if (c.V1 != c.V0) {
            goto L80198064;
        }
        L80197FF8: ;
        c.V0 = mem.ReadU16((c.S0 + 0x2Cu)); 
        mem.WriteU16((c.S0 + 0x86u), (ushort)0u); 
        { c.V0 = c.V0 + 0x1u;  }
        L80198004: ;
        mem.WriteU16((c.S0 + 0x2Cu), (ushort)c.V0); 
        goto L80198064;
        L8019800C: ;
        c.V1 = mem.ReadU32((c.S0 + 0x64u)); 
        { c.V0 = c.V1 << 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.At = 0x80080000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        mem.WriteU16((c.At + 0x701Eu), (ushort)0u); 
        c.V0 = mem.ReadU16((c.S0 + 0x86u)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S0 + 0x86u), (ushort)c.V0); 
        c.V1 = mem.ReadU16((c.S0 + 0x86u)); 
        c.V0 = mem.ReadU16((c.S0 + 0x30u)); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s < _t ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L80198064;
        }
        c.A0 = c.S0; 
        c.RA = 0x80198064u; 
        SoTN_cen.DestroyEntity_cen(c, m);
        L80198064: ;
        c.RA = mem.ReadU32((c.SP + 0x48u)); 
        c.S3 = mem.ReadU32((c.SP + 0x44u)); 
        c.S2 = mem.ReadU32((c.SP + 0x40u)); 
        c.S1 = mem.ReadU32((c.SP + 0x3Cu)); 
        c.S0 = mem.ReadU32((c.SP + 0x38u)); 
        { c.SP = c.SP + 0x50u;  }
        return;
        }
    public static bool EntityMessageBox_cen(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("cen", m, false)) return true;
        EntityMessageBox_cen_Body(c, m);
        return false;
    }
    private static void EntityMessageBox_cen_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "cen", 0x8019D378u);
        { c.SP = c.SP - 0x50u;  }
        mem.WriteU32((c.SP + 0x38u), c.S0); 
        c.S0 = c.A0; 
        mem.WriteU32((c.SP + 0x48u), c.RA); 
        mem.WriteU32((c.SP + 0x44u), c.S3); 
        mem.WriteU32((c.SP + 0x40u), c.S2); 
        mem.WriteU32((c.SP + 0x3Cu), c.S1); 
        c.V1 = mem.ReadU16((c.S0 + 0x2Cu)); 
        { c.V0 = c.V1 < 0x00000005u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.V0 = c.V1 << 2;  }
            goto L80198064;
        }
        { c.V0 = c.V1 << 2;  }
        c.At = 0x80190000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.V0 = mem.ReadU32((c.At - 0x2A50u)); 
        switch (c.V0)
        {
            case 0x80197B70u: goto L80197B70;
            case 0x80197C54u: goto L80197C54;
            case 0x80197E30u: goto L80197E30;
            case 0x80197F08u: goto L80197F08;
            case 0x8019800Cu: goto L8019800C;
            default: Dispatcher.Call(c, m, c.V0); return;
        }
        L80197B70: ;
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x410u;  }
        c.RA = 0x80197B80u; 
        SoTN_cen.InitializeEntity_cen(c, m);
        c.V1 = 0x00010000u; 
        c.V0 = mem.ReadU32((c.S0 + 0x34u)); 
        c.A0 = mem.ReadU16((c.S0 + 0x30u)); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s | _t;  }
        c.V1 = 0x08000000u; 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s ^ _t;  }
        if (c.A0 != 0u) {
            mem.WriteU32((c.S0 + 0x34u), c.V0); 
            goto L80197BA8;
        }
        mem.WriteU32((c.S0 + 0x34u), c.V0); 
        { c.V0 = 0u | 0x0060u;  }
        mem.WriteU16((c.S0 + 0x30u), (ushort)c.V0); 
        L80197BA8: ;
        { c.A0 = 0u | 0x0004u;  }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3848u)); 
        { c.A1 = 0u | 0x0003u;  }
        c.RA = 0x80197BC0u;
        Dispatcher.Call(c, m, c.V0);
        { c.V0 = c.V0 << 16;  }
        { c.A0 = (uint)((int)c.V0 >> 16);  }
        c.V0 = 0xFFFFFFFFu; 
        if (c.A0 != c.V0) {
            { c.V0 = c.A0 << 1;  }
            goto L80197BDC;
        }
        { c.V0 = c.A0 << 1;  }
        mem.WriteU16((c.S0 + 0x2Cu), (ushort)0u); 
        goto L80198064;
        L80197BDC: ;
        { var _s = c.V0; var _t = c.A0; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.A0; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.V1 = 0x80080000u; 
        { c.V1 = c.V1 + 0x6FECu;  }
        { var _s = c.V0; var _t = c.V1; c.A1 = _s + _t;  }
        c.V0 = mem.ReadU32((c.S0 + 0x34u)); 
        c.V1 = 0x00800000u; 
        mem.WriteU32((c.S0 + 0x64u), c.A0); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s | _t;  }
        if (c.A1 == 0u) {
            mem.WriteU32((c.S0 + 0x34u), c.V0); 
            goto L80197C28;
        }
        mem.WriteU32((c.S0 + 0x34u), c.V0); 
        { c.V0 = 0u | 0x0008u;  }
        L80197C14: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        mem.WriteU16((c.A1 + 0x32u), (ushort)c.V0); 
        c.A1 = mem.ReadU32(c.A1); 
        if (c.A1 != 0u) {
            goto L80197C14;
        }
        L80197C28: ;
        c.A0 = mem.ReadU32((c.S0 + 0x7Cu)); 
        c.V0 = mem.ReadU8(c.A0); 
        mem.WriteU16((c.S0 + 0x80u), (ushort)c.V0); 
        c.V0 = mem.ReadU32((c.S0 + 0x7Cu)); 
        c.V1 = mem.ReadU8((c.A0 + 0x1u)); 
        { c.V0 = c.V0 + 0x2u;  }
        mem.WriteU32((c.S0 + 0x7Cu), c.V0); 
        mem.WriteU16((c.S0 + 0x82u), (ushort)c.V1); 
        goto L80198064;
        L80197C54: ;
        { c.A0 = c.SP + 0x20u;  }
        c.A1 = 0u; 
        c.A2 = 0u; 
        { c.V0 = 0u | 0x0180u;  }
        mem.WriteU16((c.SP + 0x22u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0040u;  }
        mem.WriteU16((c.SP + 0x20u), (ushort)0u); 
        mem.WriteU16((c.SP + 0x24u), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S0 + 0x82u)); 
        c.A3 = 0u; 
        mem.WriteU16((c.SP + 0x26u), (ushort)c.V0); 
        c.RA = 0x80197C84u; 
        DialogueGlyphs.Clear(c, mem);
        c.V1 = mem.ReadU32((c.S0 + 0x64u)); 
        { c.V0 = c.V1 << 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.V1 = 0x80080000u; 
        { c.V1 = c.V1 + 0x6FECu;  }
        { var _s = c.V0; var _t = c.V1; c.A1 = _s + _t;  }
        if (c.A1 == 0u) {
            c.A2 = 0u; 
            goto L80197E24;
        }
        c.A2 = 0u; 
        { c.A0 = 0u | 0x0080u;  }
        L80197CB8: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        if (c.A2 != 0u) {
            { c.V0 = 0u | 0x0003u;  }
            goto L80197D30;
        }
        { c.V0 = 0u | 0x0003u;  }
        { c.V0 = 0u | 0x0006u;  }
        mem.WriteU8((c.A1 + 0x7u), (byte)c.V0); 
        { c.V0 = 0u | 0x0010u;  }
        mem.WriteU16((c.A1 + 0x1Au), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S0 + 0x80u)); 
        c.V1 = mem.ReadU16((c.S0 + 0x2u)); 
        { c.V0 = c.V0 >> 1;  }
        { var _s = c.V1; var _t = c.V0; c.V1 = _s - _t;  }
        mem.WriteU16((c.A1 + 0x8u), (ushort)c.V1); 
        c.V0 = mem.ReadU16((c.S0 + 0x82u)); 
        c.V1 = mem.ReadU16((c.S0 + 0x6u)); 
        mem.WriteU8((c.A1 + 0xCu), (byte)0u); 
        mem.WriteU8((c.A1 + 0xDu), (byte)c.A0); 
        { c.V0 = c.V0 >> 1;  }
        { var _s = c.V1; var _t = c.V0; c.V1 = _s - _t;  }
        mem.WriteU16((c.A1 + 0xAu), (ushort)c.V1); 
        c.V0 = mem.ReadU8((c.S0 + 0x80u)); 
        mem.WriteU8((c.A1 + 0x18u), (byte)c.V0); 
        c.V1 = mem.ReadU8((c.S0 + 0x82u)); 
        { c.V0 = 0u | 0x01A1u;  }
        mem.WriteU16((c.A1 + 0xEu), (ushort)c.V0); 
        { c.V0 = 0u | 0x01FDu;  }
        mem.WriteU16((c.A1 + 0x26u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0008u;  }
        mem.WriteU16((c.A1 + 0x32u), (ushort)c.V0); 
        mem.WriteU8((c.A1 + 0x19u), (byte)c.V1); 
        goto L80197E14;
        L80197D30: ;
        mem.WriteU8((c.A1 + 0x7u), (byte)c.V0); 
        c.V1 = mem.ReadU16((c.S0 + 0x80u)); 
        c.V0 = mem.ReadU16((c.S0 + 0x2u)); 
        { c.V1 = c.V1 >> 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s - _t;  }
        { c.V0 = c.V0 - 0x4u;  }
        mem.WriteU16((c.A1 + 0x20u), (ushort)c.V0); 
        mem.WriteU16((c.A1 + 0x8u), (ushort)c.V0); 
        c.V1 = mem.ReadU16((c.S0 + 0x80u)); 
        c.V0 = mem.ReadU16((c.S0 + 0x2u)); 
        mem.WriteU8((c.A1 + 0x28u), (byte)0u); 
        mem.WriteU8((c.A1 + 0x1Cu), (byte)0u); 
        mem.WriteU8((c.A1 + 0x10u), (byte)0u); 
        mem.WriteU8((c.A1 + 0x4u), (byte)0u); 
        mem.WriteU8((c.A1 + 0x29u), (byte)0u); 
        mem.WriteU8((c.A1 + 0x1Du), (byte)0u); 
        mem.WriteU8((c.A1 + 0x11u), (byte)0u); 
        mem.WriteU8((c.A1 + 0x5u), (byte)0u); 
        mem.WriteU8((c.A1 + 0x2Au), (byte)0u); 
        mem.WriteU8((c.A1 + 0x1Eu), (byte)0u); 
        mem.WriteU8((c.A1 + 0x12u), (byte)0u); 
        mem.WriteU8((c.A1 + 0x6u), (byte)0u); 
        { c.V1 = c.V1 >> 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 + 0x4u;  }
        mem.WriteU16((c.A1 + 0x2Cu), (ushort)c.V0); 
        mem.WriteU16((c.A1 + 0x14u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0001u;  }
        if (c.A2 != c.V0) {
            goto L80197DD0;
        }
        c.V1 = mem.ReadU16((c.S0 + 0x82u)); 
        c.V0 = mem.ReadU16((c.S0 + 0x6u)); 
        mem.WriteU8((c.A1 + 0x2Au), (byte)c.A0); 
        mem.WriteU8((c.A1 + 0x1Eu), (byte)c.A0); 
        mem.WriteU8((c.A1 + 0x12u), (byte)c.A0); 
        mem.WriteU8((c.A1 + 0x6u), (byte)c.A0); 
        { c.V1 = c.V1 >> 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s - _t;  }
        { c.V0 = c.V0 - 0x4u;  }
        goto L80197DF4;
        L80197DD0: ;
        c.V1 = mem.ReadU16((c.S0 + 0x82u)); 
        c.V0 = mem.ReadU16((c.S0 + 0x6u)); 
        mem.WriteU8((c.A1 + 0x29u), (byte)c.A0); 
        mem.WriteU8((c.A1 + 0x1Du), (byte)c.A0); 
        mem.WriteU8((c.A1 + 0x11u), (byte)c.A0); 
        mem.WriteU8((c.A1 + 0x5u), (byte)c.A0); 
        { c.V1 = c.V1 >> 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 + 0x4u;  }
        L80197DF4: ;
        mem.WriteU16((c.A1 + 0x2Eu), (ushort)c.V0); 
        mem.WriteU16((c.A1 + 0x22u), (ushort)c.V0); 
        mem.WriteU16((c.A1 + 0x16u), (ushort)c.V0); 
        mem.WriteU16((c.A1 + 0xAu), (ushort)c.V0); 
        { c.V0 = 0u | 0x01FCu;  }
        mem.WriteU16((c.A1 + 0x26u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0011u;  }
        mem.WriteU16((c.A1 + 0x32u), (ushort)c.V0); 
        L80197E14: ;
        c.A1 = mem.ReadU32(c.A1); 
        if (c.A1 != 0u) {
            { c.A2 = c.A2 + 0x1u;  }
            goto L80197CB8;
        }
        { c.A2 = c.A2 + 0x1u;  }
        L80197E24: ;
        c.V0 = mem.ReadU16((c.S0 + 0x2Cu)); 
        { c.V0 = c.V0 + 0x1u;  }
        goto L80198004;
        L80197E30: ;
        c.V0 = mem.ReadU16((c.S0 + 0x80u)); 
        c.V1 = mem.ReadU16((c.S0 + 0x82u)); 
        { c.V0 = c.V0 >> 1;  }
        { var _s = c.V0; var _t = c.V1; var _r = (long)(int)_s * (int)_t; c.LO = (uint)_r; c.HI = (uint)(_r >> 32);  }
        c.S2 = 0x80080000u; 
        { c.S2 = c.S2 - 0x101Cu;  }
        c.S1 = c.S2; 
        c.A0 = mem.ReadU32((c.S0 + 0x7Cu)); 
        c.A2 = 0u; 
        c.V0 = c.LO; 
        if ((int)c.V0 <= 0) {
            mem.WriteU16((c.SP + 0x28u), (ushort)0u); 
            goto L80197E8C;
        }
        mem.WriteU16((c.SP + 0x28u), (ushort)0u); 
        L80197E60: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        mem.WriteU8(c.S1, (byte)0u); 
        c.V0 = mem.ReadU16((c.S0 + 0x80u)); 
        c.V1 = mem.ReadU16((c.S0 + 0x82u)); 
        { c.V0 = c.V0 >> 1;  }
        { var _s = c.V0; var _t = c.V1; var _r = (long)(int)_s * (int)_t; c.LO = (uint)_r; c.HI = (uint)(_r >> 32);  }
        { c.A2 = c.A2 + 0x1u;  }
        c.V0 = c.LO; 
        { var _s = c.A2; var _t = c.V0; c.V0 = (int)_s < (int)_t ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.S1 = c.S1 + 0x1u;  }
            goto L80197E60;
        }
        { c.S1 = c.S1 + 0x1u;  }
        c.S1 = c.S2; 
        L80197E8C: ;
        { c.S3 = 0u | 0x0001u;  }
        L80197E90: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V0 = mem.ReadU8(c.A0); 
        if (c.V0 == 0u) {
            c.A1 = 0u; 
            goto L80197ED8;
        }
        c.A1 = 0u; 
        if (c.V0 != c.S3) {
            { c.A1 = c.SP + 0x28u;  }
            goto L80197EC0;
        }
        { c.A1 = c.SP + 0x28u;  }
        c.V0 = mem.ReadU16((c.S0 + 0x80u)); 
        { c.A0 = c.A0 + 0x1u;  }
        mem.WriteU16((c.SP + 0x28u), (ushort)0u); 
        { c.V0 = c.V0 << 3;  }
        { var _s = c.S2; var _t = c.V0; c.S1 = _s + _t;  }
        goto L80197E90;
        L80197EC0: ;
        c.A3 = mem.ReadU16((c.S0 + 0x80u)); 
        c.A2 = c.S1; 
        { c.A3 = c.A3 >> 1;  }
        c.RA = 0x80197ED0u; 
        SoTN_cen.BlitChar_cen(c, m);
        c.A0 = c.V0; 
        goto L80197E90;
        L80197ED8: ;
        c.A0 = c.S2; 
        { c.V0 = 0u | 0x0180u;  }
        mem.WriteU32((c.SP + 0x10u), c.V0); 
        c.V0 = mem.ReadU16((c.S0 + 0x80u)); 
        c.A2 = 0u; 
        mem.WriteU32((c.SP + 0x14u), c.V0); 
        c.V0 = mem.ReadU16((c.S0 + 0x82u)); 
        c.A3 = 0u; 
        mem.WriteU32((c.SP + 0x18u), c.V0); 
        c.RA = 0x80197F00u; 
        SoTN_main.LoadTPage(c, m);
        goto L80197FF8;
        L80197F08: ;
        c.V0 = mem.ReadU16((c.S0 + 0x86u)); 
        c.V1 = mem.ReadU32((c.S0 + 0x64u)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S0 + 0x86u), (ushort)c.V0); 
        { c.V0 = c.V1 << 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.At = 0x80080000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.A1 = mem.ReadU32((c.At + 0x6FECu)); 
        if (c.A1 == 0u) {
            c.A2 = 0u; 
            goto L80197FE8;
        }
        c.A2 = 0u; 
        L80197F44: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        if (c.A2 != 0u) {
            goto L80197F94;
        }
        c.V0 = mem.ReadU16((c.S0 + 0x82u)); 
        c.V1 = mem.ReadU16((c.S0 + 0x86u)); 
        { c.V0 = c.V0 + 0x8u;  }
        { var _s = c.V0; var _t = c.V1; var _r = (long)(int)_s * (int)_t; c.LO = (uint)_r; c.HI = (uint)(_r >> 32);  }
        c.V0 = c.LO; 
        if ((int)c.V0 >= 0) {
            goto L80197F6C;
        }
        { c.V0 = c.V0 + 0x7u;  }
        L80197F6C: ;
        { c.V0 = (uint)((int)c.V0 >> 3);  }
        c.V1 = mem.ReadU16((c.A1 + 0xAu)); 
        c.A0 = mem.ReadU8((c.A1 + 0x12u)); 
        { var _s = c.V1; var _t = c.V0; c.V1 = _s + _t;  }
        { c.A0 = c.A0 - 0x10u;  }
        mem.WriteU16((c.A1 + 0x2Eu), (ushort)c.V1); 
        mem.WriteU16((c.A1 + 0x22u), (ushort)c.V1); 
        mem.WriteU8((c.A1 + 0x12u), (byte)c.A0); 
        mem.WriteU8((c.A1 + 0x6u), (byte)c.A0); 
        goto L80197FD8;
        L80197F94: ;
        c.V0 = mem.ReadU16((c.S0 + 0x82u)); 
        c.V1 = mem.ReadU16((c.S0 + 0x86u)); 
        { c.V0 = c.V0 + 0x8u;  }
        { var _s = c.V0; var _t = c.V1; var _r = (long)(int)_s * (int)_t; c.LO = (uint)_r; c.HI = (uint)(_r >> 32);  }
        c.V0 = c.LO; 
        if ((int)c.V0 >= 0) {
            goto L80197FB4;
        }
        { c.V0 = c.V0 + 0x7u;  }
        L80197FB4: ;
        { c.V0 = (uint)((int)c.V0 >> 3);  }
        c.V1 = mem.ReadU16((c.A1 + 0x22u)); 
        c.A0 = mem.ReadU8((c.A1 + 0x29u)); 
        { var _s = c.V1; var _t = c.V0; c.V1 = _s - _t;  }
        { c.A0 = c.A0 - 0x10u;  }
        mem.WriteU16((c.A1 + 0x16u), (ushort)c.V1); 
        mem.WriteU16((c.A1 + 0xAu), (ushort)c.V1); 
        mem.WriteU8((c.A1 + 0x29u), (byte)c.A0); 
        mem.WriteU8((c.A1 + 0x1Du), (byte)c.A0); 
        L80197FD8: ;
        c.A1 = mem.ReadU32(c.A1); 
        if (c.A1 != 0u) {
            { c.A2 = c.A2 + 0x1u;  }
            goto L80197F44;
        }
        { c.A2 = c.A2 + 0x1u;  }
        L80197FE8: ;
        c.V1 = mem.ReadU16((c.S0 + 0x86u)); 
        { c.V0 = 0u | 0x0008u;  }
        if (c.V1 != c.V0) {
            goto L80198064;
        }
        L80197FF8: ;
        c.V0 = mem.ReadU16((c.S0 + 0x2Cu)); 
        mem.WriteU16((c.S0 + 0x86u), (ushort)0u); 
        { c.V0 = c.V0 + 0x1u;  }
        L80198004: ;
        mem.WriteU16((c.S0 + 0x2Cu), (ushort)c.V0); 
        goto L80198064;
        L8019800C: ;
        c.V1 = mem.ReadU32((c.S0 + 0x64u)); 
        { c.V0 = c.V1 << 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.At = 0x80080000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        mem.WriteU16((c.At + 0x701Eu), (ushort)0u); 
        c.V0 = mem.ReadU16((c.S0 + 0x86u)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S0 + 0x86u), (ushort)c.V0); 
        c.V1 = mem.ReadU16((c.S0 + 0x86u)); 
        c.V0 = mem.ReadU16((c.S0 + 0x30u)); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s < _t ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L80198064;
        }
        c.A0 = c.S0; 
        c.RA = 0x80198064u; 
        SoTN_cen.DestroyEntity_cen(c, m);
        L80198064: ;
        c.RA = mem.ReadU32((c.SP + 0x48u)); 
        c.S3 = mem.ReadU32((c.SP + 0x44u)); 
        c.S2 = mem.ReadU32((c.SP + 0x40u)); 
        c.S1 = mem.ReadU32((c.SP + 0x3Cu)); 
        c.S0 = mem.ReadU32((c.SP + 0x38u)); 
        { c.SP = c.SP + 0x50u;  }
        return;
        }
}
