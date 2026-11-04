using RecompOne.Runtime.Context;
using RecompOne.Runtime.Dispatch;
using RecompOne.Runtime.Memory;

namespace Recompiled.Translation;

public static class ScriptFunctions_st0
{
    public static bool CutsceneUnk1_st0(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("st0", m, true)) return true;
        CutsceneUnk1_st0_Body(c, m);
        return false;
    }
    private static void CutsceneUnk1_st0_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "st0", 0x801C24CCu);
        { c.V0 = 0u | 0x0002u;  }
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At + 0x24D8u), (ushort)c.V0); 
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At + 0x24D6u), (ushort)c.V0); 
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU16((c.V0 + 0x24D4u)); 
        { c.V1 = 0u | 0x0008u;  }
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At + 0x24DAu), (ushort)0u); 
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At + 0x24DEu), (ushort)0u); 
        c.At = 0x801C0000u; 
        mem.WriteU8((c.At + 0x24E2u), (byte)0u); 
        c.At = 0x801C0000u; 
        mem.WriteU8((c.At + 0x24E3u), (byte)c.V1); 
        { c.V0 = c.V0 + 0x14u;  }
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At + 0x24D2u), (ushort)c.V0); 
        return;
        }
    public static bool SetCutsceneScript_st0(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("st0", m, true)) return true;
        SetCutsceneScript_st0_Body(c, m);
        return false;
    }
    private static void SetCutsceneScript_st0_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "st0", 0x801C24CCu);
        c.A0 = DialogueScripts.ResolveStart("st0", c.A0, m);
        { c.SP = c.SP - 0x20u;  }
        mem.WriteU32((c.SP + 0x14u), c.S1); 
        c.S1 = c.A0; 
        { c.A0 = 0u | 0x0006u;  }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3848u)); 
        { c.A1 = 0u | 0x0008u;  }
        mem.WriteU32((c.SP + 0x18u), c.RA); 
        mem.WriteU32((c.SP + 0x10u), c.S0); 
        c.RA = 0x801A8A00u;
        Dispatcher.Call(c, m, c.V0);
        c.S0 = 0x801C0000u; 
        { c.S0 = c.S0 + 0x2504u;  }
        { c.V0 = c.V0 << 16;  }
        { c.V0 = (uint)((int)c.V0 >> 16);  }
        c.V1 = 0xFFFFFFFFu; 
        if (c.V0 != c.V1) {
            mem.WriteU32(c.S0, c.V0); 
            goto L801A8A28;
        }
        mem.WriteU32(c.S0, c.V0); 
        mem.WriteU32(c.S0, 0u); 
        c.V0 = 0u; 
        goto L801A8B84;
        L801A8A28: ;
        c.At = 0x801C0000u; 
        mem.WriteU32((c.At + 0x24CCu), c.S1); 
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At + 0x2508u), (ushort)0u); 
        c.At = 0x801C0000u; 
        mem.WriteU32((c.At + 0x2500u), c.V1); 
        c.At = 0x801C0000u; 
        mem.WriteU32((c.At + 0x24FCu), c.V1); 
        c.RA = 0x801A8A50u; 
        SoTN_st0.CutsceneUnk1_st0(c, m);
        c.V1 = mem.ReadU32(c.S0); 
        { c.V0 = c.V1 << 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.V1 = 0x80080000u; 
        { c.V1 = c.V1 + 0x6FECu;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        c.At = 0x801C0000u; 
        mem.WriteU32((c.At + 0x24E4u), c.V0); 
        c.V1 = mem.ReadU32(c.V0); 
        { c.A2 = 0u | 0x0008u;  }
        mem.WriteU16((c.V0 + 0x32u), (ushort)c.A2); 
        c.At = 0x801C0000u; 
        mem.WriteU32((c.At + 0x24E8u), c.V1); 
        c.V0 = mem.ReadU32(c.V1); 
        mem.WriteU16((c.V1 + 0x32u), (ushort)c.A2); 
        c.At = 0x801C0000u; 
        mem.WriteU32((c.At + 0x24ECu), c.V0); 
        c.V1 = mem.ReadU32(c.V0); 
        mem.WriteU16((c.V0 + 0x32u), (ushort)c.A2); 
        c.At = 0x801C0000u; 
        mem.WriteU32((c.At + 0x24F0u), c.V1); 
        c.A0 = mem.ReadU32(c.V1); 
        mem.WriteU16((c.V1 + 0x32u), (ushort)c.A2); 
        c.At = 0x801C0000u; 
        mem.WriteU32((c.At + 0x24F4u), c.A0); 
        c.A1 = mem.ReadU32(c.A0); 
        { c.V0 = 0u | 0x0001u;  }
        mem.WriteU16((c.A0 + 0x32u), (ushort)c.A2); 
        c.At = 0x801C0000u; 
        mem.WriteU32((c.At + 0x24F8u), c.A1); 
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
        L801A8B84: ;
        c.RA = mem.ReadU32((c.SP + 0x18u)); 
        c.S1 = mem.ReadU32((c.SP + 0x14u)); 
        c.S0 = mem.ReadU32((c.SP + 0x10u)); 
        { c.SP = c.SP + 0x20u;  }
        return;
        }
    public static bool CutsceneUnk3_st0(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("st0", m, false)) return true;
        CutsceneUnk3_st0_Body(c, m);
        return false;
    }
    private static void CutsceneUnk3_st0_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "st0", 0x801C24CCu);
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
        c.RA = 0x801A8BE8u; 
        DialogueGlyphs.Clear(c, mem);
        c.RA = mem.ReadU32((c.SP + 0x18u)); 
        { c.SP = c.SP + 0x20u;  }
        return;
        }
    public static bool CutsceneUnk4_st0(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("st0", m, true)) return true;
        CutsceneUnk4_st0_Body(c, m);
        return false;
    }
    private static void CutsceneUnk4_st0_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "st0", 0x801C24CCu);
        DialogueGlyphs.PrepareLine(c, mem);
        { c.SP = c.SP - 0x18u;  }
        mem.WriteU32((c.SP + 0x10u), c.S0); 
        c.S0 = 0x801C0000u; 
        { c.S0 = c.S0 + 0x24DAu;  }
        mem.WriteU32((c.SP + 0x14u), c.RA); 
        c.A0 = (uint)(short)mem.ReadU16(c.S0); 
        c.RA = 0x801A8C18u; 
        SoTN_st0.CutsceneUnk3_st0(c, m);
        c.V0 = (uint)(short)mem.ReadU16(c.S0); 
        { c.V0 = c.V0 << 2;  }
        { var _s = c.S0; var _t = c.V0; c.V0 = _s + _t;  }
        c.V1 = mem.ReadU32((c.V0 + 0xAu)); 
        { c.V0 = 0u | 0x0010u;  }
        mem.WriteU16((c.V1 + 0x1Au), (ushort)c.V0); 
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU16((c.V0 + 0x24E0u)); 
        mem.WriteU16((c.V1 + 0xEu), (ushort)c.V0); 
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU16((c.V0 + 0x24D2u)); 
        mem.WriteU8((c.V1 + 0xCu), (byte)0u); 
        mem.WriteU16((c.V1 + 0xAu), (ushort)c.V0); 
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU16((c.V0 + 0x24D0u)); 
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
    public static bool DrawCutsceneActorName_st0(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("st0", m, true)) return true;
        DrawCutsceneActorName_st0_Body(c, m);
        return false;
    }
    private static void DrawCutsceneActorName_st0_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "st0", 0x801C24CCu);
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
        c.A2 = mem.ReadU32((c.At + 0x828u)); 
        { c.V0 = 0u | 0x00FFu;  }
        L801A8CE4: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V1 = mem.ReadU8(c.A2); 
        if (c.V1 != c.V0) {
            { c.A2 = c.A2 + 0x1u;  }
            goto L801A8D04;
        }
        { c.A2 = c.A2 + 0x1u;  }
        c.V1 = mem.ReadU8(c.A2); 
        if (c.V1 == 0u) {
            { c.A2 = c.A2 + 0x1u;  }
            goto L801A8D14;
        }
        { c.A2 = c.A2 + 0x1u;  }
        L801A8D04: ;
        if (c.V1 == 0u) {
            goto L801A8CE4;
        }
        { c.A1 = c.A1 + 0x1u;  }
        goto L801A8CE4;
        L801A8D14: ;
        { c.A0 = 0u | 0x0006u;  }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3848u)); 
        { c.A1 = c.A1 & 0xFFFFu;  }
        c.RA = 0x801A8D2Cu;
        Dispatcher.Call(c, m, c.V0);
        { c.V0 = c.V0 << 16;  }
        { c.A1 = (uint)((int)c.V0 >> 16);  }
        c.V0 = 0xFFFFFFFFu; 
        if (c.A1 != c.V0) {
            { c.V0 = c.A1 << 1;  }
            goto L801A8D50;
        }
        { c.V0 = c.A1 << 1;  }
        c.A0 = c.S1; 
        c.RA = 0x801A8D48u; 
        SoTN_st0.DestroyEntity_st0(c, m);
        goto L801A8E1C;
        L801A8D50: ;
        { var _s = c.V0; var _t = c.A1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.A1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.V1 = 0x80080000u; 
        { c.V1 = c.V1 + 0x6FECu;  }
        { var _s = c.V0; var _t = c.V1; c.A0 = _s + _t;  }
        c.V1 = 0x801C0000u; 
        { c.V1 = c.V1 + 0x2500u;  }
        { c.V0 = c.S0 & 0xFFFFu;  }
        { c.V0 = c.V0 << 2;  }
        mem.WriteU32(c.V1, c.A1); 
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.A2 = mem.ReadU32((c.At + 0x828u)); 
        if (c.A0 == 0u) {
            { c.A3 = 0u | 0x0038u;  }
            goto L801A8E1C;
        }
        { c.A3 = 0u | 0x0038u;  }
        { c.T4 = 0u | 0x0006u;  }
        { c.T3 = 0u | 0x001Eu;  }
        { c.T2 = 0u | 0x0196u;  }
        { c.T1 = 0u | 0x01FFu;  }
        { c.A1 = 0u | 0x0008u;  }
        { c.T0 = c.V1 - 0x2Cu;  }
        L801A8DAC: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V1 = mem.ReadU8(c.A2); 
        if (c.V1 != 0u) {
            { c.A2 = c.A2 + 0x1u;  }
            goto L801A8DC4;
        }
        { c.A2 = c.A2 + 0x1u;  }
        { c.A3 = c.A3 + 0x4u;  }
        goto L801A8E10;
        L801A8DC4: ;
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
        L801A8E10: ;
        if (c.A0 != 0u) {
            goto L801A8DAC;
        }
        L801A8E1C: ;
        c.RA = mem.ReadU32((c.SP + 0x18u)); 
        c.S1 = mem.ReadU32((c.SP + 0x14u)); 
        c.S0 = mem.ReadU32((c.SP + 0x10u)); 
        { c.SP = c.SP + 0x20u;  }
        return;
        }
    public static bool SetCutsceneEnd_st0(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("st0", m, true)) return true;
        SetCutsceneEnd_st0_Body(c, m);
        return false;
    }
    private static void SetCutsceneEnd_st0_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "st0", 0x801C24CCu);
        c.V0 = 0x00100000u; 
        { var _s = c.A0; var _t = c.V0; c.A0 = _s + _t;  }
        { c.V0 = 0u | 0x0001u;  }
        c.At = 0x801C0000u; 
        mem.WriteU32((c.At + 0x250Cu), c.A0); 
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At + 0x250Au), (ushort)0u); 
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At + 0x2508u), (ushort)c.V0); 
        return;
        }
    public static bool CutsceneRun_st0(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("st0", m, true)) return true;
        CutsceneRun_st0_Body(c, m);
        return false;
    }
    private static void CutsceneRun_st0_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "st0", 0x801C24CCu);
        { c.SP = c.SP - 0x20u;  }
        c.A0 = 0x801C0000u; 
        { c.A0 = c.A0 + 0x250Au;  }
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
            goto L801A8EC0;
        }
        { c.S1 = c.A0 + 0x2u;  }
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At + 0x2508u), (ushort)0u); 
        goto L801A90F0;
        L801A8EB0: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        mem.WriteU32(c.S1, c.A1); 
        goto L801A90F0;
        L801A8EB8: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        mem.WriteU32(c.S1, c.A2); 
        goto L801A90F0;
        L801A8EC0: ;
        { c.S2 = 0u | 0x0001u;  }
        L801A8EC4: ;
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
            goto L801A8EB0;
        }
        { c.V0 = c.A1 + 0x3u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.V1 = mem.ReadU8((c.A1 + 0x2u)); 
        if (c.V1 == c.S2) {
            { c.V0 = (int)c.V1 < 2 ? 1u : 0u;  }
            goto L801A903C;
        }
        { c.V0 = (int)c.V1 < 2 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L801A8F24;
        }
        if (c.V1 == 0u) {
            { c.V0 = c.A1 + 0x4u;  }
            goto L801A8F40;
        }
        { c.V0 = c.A1 + 0x4u;  }
        goto L801A8EC4;
        L801A8F24: ;
        { c.V0 = 0u | 0x0002u;  }
        if (c.V1 == c.V0) {
            { c.V0 = 0u | 0x0003u;  }
            goto L801A9078;
        }
        { c.V0 = 0u | 0x0003u;  }
        if (c.V1 == c.V0) {
            { c.V0 = c.A1 + 0x4u;  }
            goto L801A90C8;
        }
        { c.V0 = c.A1 + 0x4u;  }
        goto L801A8EC4;
        L801A8F40: ;
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
        c.RA = 0x801A8F74u; 
        SoTN_st0.DestroyEntity_st0(c, m);
        c.V1 = mem.ReadU32(c.S1); 
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.V0 = mem.ReadU8(c.V1); 
        mem.WriteU16((c.S0 + 0x26u), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S0 + 0x26u)); 
        { c.V0 = c.V0 << 2;  }
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.V0 = mem.ReadU32((c.At + 0x4B8u)); 
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
        goto L801A8EC4;
        L801A903C: ;
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
        c.RA = 0x801A9070u; 
        SoTN_st0.DestroyEntity_st0(c, m);
        goto L801A8EC4;
        L801A9078: ;
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x250Cu)); 
        c.V1 = 0x801C0000u; 
        c.V1 = mem.ReadU32((c.V1 + 0x257Cu)); 
        c.V0 = mem.ReadU8(c.V0); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _t >> (int)(_s & 31u);  }
        { c.V0 = c.V0 & 0x0001u;  }
        if (c.V0 == 0u) {
            { c.V0 = c.A1 + 0x4u;  }
            goto L801A8EB8;
        }
        { c.V0 = c.A1 + 0x4u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.V0 = mem.ReadU8((c.A1 + 0x3u)); 
        { var _s = c.V0; var _t = c.S2; c.V0 = _t << (int)(_s & 31u);  }
        { var _s = 0u; var _t = c.V0; c.V0 = ~(_s | _t);  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s & _t;  }
        c.At = 0x801C0000u; 
        mem.WriteU32((c.At + 0x257Cu), c.V0); 
        goto L801A8EC4;
        L801A90C8: ;
        mem.WriteU32(c.S1, c.V0); 
        c.V0 = mem.ReadU8((c.A1 + 0x3u)); 
        c.V1 = 0x801C0000u; 
        c.V1 = mem.ReadU32((c.V1 + 0x257Cu)); 
        { var _s = c.V0; var _t = c.S2; c.V0 = _t << (int)(_s & 31u);  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s | _t;  }
        c.At = 0x801C0000u; 
        mem.WriteU32((c.At + 0x257Cu), c.V0); 
        goto L801A8EC4;
        L801A90F0: ;
        c.RA = mem.ReadU32((c.SP + 0x1Cu)); 
        c.S2 = mem.ReadU32((c.SP + 0x18u)); 
        c.S1 = mem.ReadU32((c.SP + 0x14u)); 
        c.S0 = mem.ReadU32((c.SP + 0x10u)); 
        { c.SP = c.SP + 0x20u;  }
        return;
        }
    public static bool ScaleCutsceneAvatar_st0(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("st0", m, true)) return true;
        ScaleCutsceneAvatar_st0_Body(c, m);
        return false;
    }
    private static void ScaleCutsceneAvatar_st0_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "st0", 0x801C24CCu);
        c.V0 = 0x801C0000u; 
        c.V0 = (uint)(short)mem.ReadU16((c.V0 + 0x24DAu)); 
        { c.A3 = c.V0 + (uint)(mem.LineCount - DialogueGlyphs.VisibleLines(mem));  }
        { c.V0 = (int)c.A3 < 5 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L801A913C;
        }
        { c.A3 = c.A3 - 0x5u;  }
        L801A912C: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        { c.V0 = (int)c.A3 < 5 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.A3 = c.A3 - 0x5u;  }
            goto L801A912C;
        }
        { c.A3 = c.A3 - 0x5u;  }
        { c.A3 = c.A3 + 0x5u;  }
        L801A913C: ;
        c.V0 = 0x80070000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3C48u)); 
        c.V0 = mem.ReadU16((c.V0 + 0x2Eu)); 
        if (c.V0 != 0u) {
            c.V1 = 0u; 
            goto L801A91B8;
        }
        c.V1 = 0u; 
        { c.V0 = c.A3 << 2;  }
        c.At = 0x801C0000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.A1 = mem.ReadU32((c.At + 0x24E4u)); 
        c.V0 = mem.ReadU8((c.A1 + 0x19u)); 
        { var _s = c.V0; var _t = c.A0; c.V0 = _s - _t;  }
        mem.WriteU8((c.A1 + 0x19u), (byte)c.V0); 
        c.V0 = mem.ReadU8((c.A1 + 0xDu)); 
        c.V1 = mem.ReadU8((c.A1 + 0x19u)); 
        { var _s = c.A0; var _t = c.V0; c.V0 = _s + _t;  }
        if (c.V1 != 0u) {
            mem.WriteU8((c.A1 + 0xDu), (byte)c.V0); 
            goto L801A91B4;
        }
        mem.WriteU8((c.A1 + 0xDu), (byte)c.V0); 
        c.V0 = 0x80070000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3C48u)); 
        c.V1 = mem.ReadU16((c.V0 + 0x2Eu)); 
        { c.V1 = c.V1 + 0x1u;  }
        mem.WriteU16((c.V0 + 0x2Eu), (ushort)c.V1); 
        { c.V0 = 0u | 0x0008u;  }
        mem.WriteU16((c.A1 + 0x32u), (ushort)c.V0); 
        L801A91B4: ;
        c.V1 = 0u; 
        L801A91B8: ;
        { c.A0 = c.A0 & 0x00FFu;  }
        c.A2 = 0x801C0000u; 
        { c.A2 = c.A2 + 0x24E4u;  }
        L801A91C4: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        if (c.V1 == c.A3) {
            goto L801A91E4;
        }
        c.A1 = mem.ReadU32(c.A2); 
        c.V0 = mem.ReadU16((c.A1 + 0xAu)); 
        { var _s = c.V0; var _t = c.A0; c.V0 = _s - _t;  }
        mem.WriteU16((c.A1 + 0xAu), (ushort)c.V0); 
        L801A91E4: ;
        { c.V1 = c.V1 + 0x1u;  }
        { c.V0 = (int)c.V1 < 5 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.A2 = c.A2 + 0x4u;  }
            goto L801A91C4;
        }
        { c.A2 = c.A2 + 0x4u;  }
        c.V1 = 0x801C0000u; 
        { c.V1 = c.V1 + 0x24DCu;  }
        c.V0 = mem.ReadU16(c.V1); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16(c.V1, (ushort)c.V0); 
        return;
        }
    public static bool ST0_EntityCutscene(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("st0", m, true)) return true;
        ST0_EntityCutscene_Body(c, m);
        return false;
    }
    private static void ST0_EntityCutscene_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "st0", 0x801C24CCu);
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x2580u)); 
        { c.SP = c.SP - 0x48u;  }
        mem.WriteU32((c.SP + 0x38u), c.S2); 
        c.S2 = c.A0; 
        mem.WriteU32((c.SP + 0x44u), c.RA); 
        mem.WriteU32((c.SP + 0x40u), c.S4); 
        mem.WriteU32((c.SP + 0x3Cu), c.S3); 
        mem.WriteU32((c.SP + 0x34u), c.S1); 
        if (c.V0 == 0u) {
            mem.WriteU32((c.SP + 0x30u), c.S0); 
            goto L801A932C;
        }
        mem.WriteU32((c.SP + 0x30u), c.S0); 
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x24C8u)); 
        if (c.V0 != 0u) {
            goto L801A932C;
        }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x34FCu)); 
        { c.V0 = c.V0 & 0x0001u;  }
        if (c.V0 != 0u) {
            goto L801A927C;
        }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x4220u)); 
        if (c.V0 == 0u) {
            goto L801A932C;
        }
        L801A927C: ;
        c.V1 = 0x80090000u; 
        c.V1 = mem.ReadU16((c.V1 + 0x7494u)); 
        { c.V0 = 0u | 0x0800u;  }
        if (c.V1 != c.V0) {
            { c.V0 = 0u | 0x0001u;  }
            goto L801A932C;
        }
        { c.V0 = 0u | 0x0001u;  }
        c.S1 = 0x80040000u; 
        { c.S1 = c.S1 - 0x384Cu;  }
        c.A0 = mem.ReadU32((c.S2 + 0x64u)); 
        c.V1 = mem.ReadU32(c.S1); 
        c.At = 0x801C0000u; 
        mem.WriteU32((c.At + 0x24C8u), c.V0); 
        c.S0 = 0xFFFFFFFFu; 
        c.RA = 0x801A92B0u;
        Dispatcher.Call(c, m, c.V1);
        c.V1 = 0xFF7F0000u; 
        c.V0 = mem.ReadU32((c.S2 + 0x34u)); 
        { c.V1 = c.V1 | 0xFFFFu;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s & _t;  }
        mem.WriteU32((c.S2 + 0x34u), c.V0); 
        c.A0 = 0x801C0000u; 
        c.A0 = mem.ReadU32((c.A0 + 0x2500u)); 
        if (c.A0 == c.S0) {
            goto L801A92E8;
        }
        c.V0 = mem.ReadU32(c.S1); 
        c.RA = 0x801A92E8u;
        Dispatcher.Call(c, m, c.V0);
        L801A92E8: ;
        c.A0 = 0x801C0000u; 
        c.A0 = mem.ReadU32((c.A0 + 0x24FCu)); 
        if (c.A0 == c.S0) {
            goto L801A930C;
        }
        c.V0 = mem.ReadU32(c.S1); 
        c.RA = 0x801A930Cu;
        Dispatcher.Call(c, m, c.V0);
        L801A930C: ;
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3824u)); 
        { c.A0 = 0u | 0x0080u;  }
        c.RA = 0x801A9320u;
        Dispatcher.Call(c, m, c.V0);
        { c.V0 = 0u | 0x0001u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        mem.WriteU16((c.S2 + 0x2Eu), (ushort)0u); 
        L801A932C: ;
        c.V0 = mem.ReadU16((c.S2 + 0x2Cu)); 
        if (c.V0 == 0u) {
            goto L801A9358;
        }
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU16((c.V0 + 0x2508u)); 
        if (c.V0 == 0u) {
            goto L801A9358;
        }
        c.RA = 0x801A9358u; 
        SoTN_st0.CutsceneRun_st0(c, m);
        L801A9358: ;
        c.V1 = mem.ReadU16((c.S2 + 0x2Cu)); 
        { c.V0 = c.V1 < 0x00000008u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.V0 = c.V1 << 2;  }
            goto L801AA1F4;
        }
        { c.V0 = c.V1 << 2;  }
        c.At = 0x801A0000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.V0 = mem.ReadU32((c.At + 0x7A00u)); 
        switch (c.V0)
        {
            case 0x801A9384u: goto L801A9384;
            case 0x801A9430u: goto L801A9430;
            case 0x801A9C80u: goto L801A9C80;
            case 0x801A9CB4u: goto L801A9CB4;
            case 0x801A9DA0u: goto L801A9DA0;
            case 0x801A9E0Cu: goto L801A9E0C;
            case 0x801AA0F4u: goto L801AA0F4;
            case 0x801AA1CCu: goto L801AA1CC;
            case 0x801A94A8u: goto L801A94A8;
            case 0x801A94B4u: goto L801A94B4;
            case 0x801A9560u: goto L801A9560;
            case 0x801A958Cu: goto L801A958C;
            case 0x801A95BCu: goto L801A95BC;
            case 0x801A95FCu: goto L801A95FC;
            case 0x801A9734u: goto L801A9734;
            case 0x801A97ACu: goto L801A97AC;
            case 0x801A9840u: goto L801A9840;
            case 0x801A9868u: goto L801A9868;
            case 0x801A9890u: goto L801A9890;
            case 0x801A98C8u: goto L801A98C8;
            case 0x801A9910u: goto L801A9910;
            case 0x801A9444u: goto L801A9444;
            case 0x801A996Cu: goto L801A996C;
            case 0x801A99D0u: goto L801A99D0;
            case 0x801A9A30u: goto L801A9A30;
            case 0x801A9A7Cu: goto L801A9A7C;
            case 0x801A9AB0u: goto L801A9AB0;
            case 0x801A9AC0u: goto L801A9AC0;
            case 0x801A9B80u: goto L801A9B80;
            case 0x801AA34Cu: goto L801AA34C;
            case 0x801AA370u: goto L801AA370;
            case 0x801AA458u: goto L801AA458;
            case 0x801AA50Cu: goto L801AA50C;
            case 0x801AA584u: goto L801AA584;
            case 0x801AA5D0u: goto L801AA5D0;
            case 0x801AA618u: goto L801AA618;
            case 0x801AA65Cu: goto L801AA65C;
            case 0x801AA6A0u: goto L801AA6A0;
            case 0x801AA6E4u: goto L801AA6E4;
            case 0x801AA728u: goto L801AA728;
            case 0x801AA76Cu: goto L801AA76C;
            case 0x801AA7B0u: goto L801AA7B0;
            case 0x801AA7F4u: goto L801AA7F4;
            case 0x801AA840u: goto L801AA840;
            case 0x801AA880u: goto L801AA880;
            case 0x801AA91Cu: goto L801AA91C;
            case 0x801AA9C0u: goto L801AA9C0;
            case 0x801AAA40u: goto L801AAA40;
            case 0x801AAB8Cu: goto L801AAB8C;
            case 0x801AAA90u: goto L801AAA90;
            default: Dispatcher.Call(c, m, c.V0); return;
        }
        L801A9384: ;
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x29D8u;  }
        c.RA = 0x801A9394u; 
        SoTN_st0.SetCutsceneScript_st0(c, m);
        { c.V0 = c.V0 & 0x00FFu;  }
        if (c.V0 == 0u) {
            { c.A1 = 0u | 0x0001u;  }
            goto L801AA1F4;
        }
        { c.A1 = 0u | 0x0001u;  }
        c.V0 = mem.ReadU32((c.S2 + 0x34u)); 
        c.V1 = 0x00800000u; 
        c.At = 0x801C0000u; 
        mem.WriteU32((c.At + 0x257Cu), 0u); 
        c.At = 0x801C0000u; 
        mem.WriteU32((c.At + 0x2580u), 0u); 
        c.At = 0x801C0000u; 
        mem.WriteU32((c.At + 0x24C8u), 0u); 
        c.At = 0x80040000u; 
        mem.WriteU32((c.At - 0x38FCu), c.A1); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s | _t;  }
        mem.WriteU32((c.S2 + 0x34u), c.V0); 
        c.A0 = 0x801C0000u; 
        c.A0 = mem.ReadU32((c.A0 + 0x2504u)); 
        c.V0 = mem.ReadU16((c.S2 + 0x2Cu)); 
        c.V1 = 0x80090000u; 
        c.V1 = mem.ReadU32((c.V1 + 0x7914u)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        if (c.V1 == 0u) {
            mem.WriteU32((c.S2 + 0x64u), c.A0); 
            goto L801AA1F4;
        }
        mem.WriteU32((c.S2 + 0x64u), c.A0); 
        c.A0 = mem.ReadU32((c.S2 + 0x64u)); 
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x384Cu)); 
        c.At = 0x801C0000u; 
        mem.WriteU32((c.At + 0x24C8u), c.A1); 
        c.At = 0x801C0000u; 
        mem.WriteU32((c.At + 0x2580u), c.A1); 
        c.RA = 0x801A9418u;
        Dispatcher.Call(c, m, c.V0);
        c.V1 = 0xFF7F0000u; 
        c.V0 = mem.ReadU32((c.S2 + 0x34u)); 
        { c.V1 = c.V1 | 0xFFFFu;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s & _t;  }
        mem.WriteU32((c.S2 + 0x34u), c.V0); 
        goto L801AA1F4;
        L801A9430: ;
        c.S4 = 0x801C0000u; 
        { c.S4 = c.S4 + 0x24E2u;  }
        { c.S1 = c.S4 - 0x16u;  }
        { c.S0 = c.S4 - 0xCu;  }
        { c.S3 = c.S4 - 0x12u;  }
        L801A9444: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V0 = mem.ReadU8(c.S4); 
        if (c.V0 == 0u) {
            goto L801A9468;
        }
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x24C8u)); 
        if (c.V0 == 0u) {
            goto L801AA19C;
        }
        L801A9468: ;
        c.V0 = mem.ReadU32(c.S1); 
        { c.V1 = c.V0 + 0x1u;  }
        mem.WriteU32(c.S1, c.V1); 
        c.A2 = mem.ReadU8(c.V0); 
        { c.V1 = c.A2 & 0xFFFFu;  }
        { c.V0 = c.V1 < 0x00000015u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.V0 = c.V1 << 2;  }
            goto L801A9BBC;
        }
        { c.V0 = c.V1 << 2;  }
        c.At = 0x801A0000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.V0 = mem.ReadU32((c.At + 0x7A20u)); 
        switch (c.V0)
        {
            case 0x801A94A8u: goto L801A94A8;
            case 0x801A94B4u: goto L801A94B4;
            case 0x801A9560u: goto L801A9560;
            case 0x801A958Cu: goto L801A958C;
            case 0x801A95BCu: goto L801A95BC;
            case 0x801A95FCu: goto L801A95FC;
            case 0x801A9734u: goto L801A9734;
            case 0x801A97ACu: goto L801A97AC;
            case 0x801A9840u: goto L801A9840;
            case 0x801A9868u: goto L801A9868;
            case 0x801A9890u: goto L801A9890;
            case 0x801A98C8u: goto L801A98C8;
            case 0x801A9910u: goto L801A9910;
            case 0x801A9444u: goto L801A9444;
            case 0x801A996Cu: goto L801A996C;
            case 0x801A99D0u: goto L801A99D0;
            case 0x801A9A30u: goto L801A9A30;
            case 0x801A9A7Cu: goto L801A9A7C;
            case 0x801A9AB0u: goto L801A9AB0;
            case 0x801A9AC0u: goto L801A9AC0;
            case 0x801A9B80u: goto L801A9B80;
            case 0x801AA34Cu: goto L801AA34C;
            case 0x801AA370u: goto L801AA370;
            case 0x801AA458u: goto L801AA458;
            case 0x801AA50Cu: goto L801AA50C;
            case 0x801AA584u: goto L801AA584;
            case 0x801AA5D0u: goto L801AA5D0;
            case 0x801AA618u: goto L801AA618;
            case 0x801AA65Cu: goto L801AA65C;
            case 0x801AA6A0u: goto L801AA6A0;
            case 0x801AA6E4u: goto L801AA6E4;
            case 0x801AA728u: goto L801AA728;
            case 0x801AA76Cu: goto L801AA76C;
            case 0x801AA7B0u: goto L801AA7B0;
            case 0x801AA7F4u: goto L801AA7F4;
            case 0x801AA840u: goto L801AA840;
            case 0x801AA880u: goto L801AA880;
            case 0x801AA91Cu: goto L801AA91C;
            case 0x801AA9C0u: goto L801AA9C0;
            case 0x801AAA40u: goto L801AAA40;
            case 0x801AAB8Cu: goto L801AAB8C;
            case 0x801AAA90u: goto L801AAA90;
            default: Dispatcher.Call(c, m, c.V0); return;
        }
        L801A94A8: ;
        { c.V0 = 0u | 0x0007u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        goto L801AA1F4;
        L801A94B4: ;
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x24C8u)); 
        if (c.V0 != 0u) {
            goto L801A9444;
        }
        c.V0 = mem.ReadU16((c.S0 + 0x8u)); 
        c.V1 = mem.ReadU16((c.S0 + 0x2u)); 
        { c.V0 = c.V0 & 0x0001u;  }
        if (c.V0 != 0u) {
            mem.WriteU16(c.S0, (ushort)c.V1); 
            goto L801A94EC;
        }
        mem.WriteU16(c.S0, (ushort)c.V1); 
        c.V0 = mem.ReadU16((c.S0 - 0x4u)); 
        { c.V0 = c.V0 + 0xCu;  }
        mem.WriteU16((c.S0 - 0x4u), (ushort)c.V0); 
        L801A94EC: ;
        c.V0 = mem.ReadU16((c.S0 + 0x4u)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S0 + 0x4u), (ushort)c.V0); 
        { c.V0 = c.V0 << 16;  }
        { c.V0 = (uint)((int)c.V0 >> 16);  }
        { c.V0 = (int)c.V0 < 5 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L801A9514;
        }
        mem.WriteU16((c.S0 + 0x4u), (ushort)0u); 
        L801A9514: ;
        c.RA = 0x801A951Cu; 
        SoTN_st0.CutsceneUnk4_st0(c, m);
        c.V1 = mem.ReadU16((c.S0 + 0x8u)); 
        { c.V0 = c.V1 & 0x0001u;  }
        if (c.V0 != 0u) {
            goto L801A9548;
        }
        c.V0 = (uint)(short)mem.ReadU16((c.S0 + 0x4u)); 
        { c.V0 = (int)c.V0 < 4 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.V0 = c.V1 | 0x0001u;  }
            goto L801A9444;
        }
        { c.V0 = c.V1 | 0x0001u;  }
        mem.WriteU16((c.S0 + 0x8u), (ushort)c.V0); 
        L801A9548: ;
        mem.WriteU16((c.S0 + 0x6u), (ushort)0u); 
        c.V0 = mem.ReadU16((c.S2 + 0x2Cu)); 
        mem.WriteU16((c.S2 + 0x2Eu), (ushort)0u); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        goto L801AA1F4;
        L801A9560: ;
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x24CCu)); 
        { c.V1 = c.V0 + 0x1u;  }
        c.At = 0x801C0000u; 
        mem.WriteU32((c.At + 0x24CCu), c.V1); 
        c.V0 = mem.ReadU8(c.V0); 
        c.At = 0x801C0000u; 
        mem.WriteU8((c.At + 0x24E3u), (byte)c.V0); 
        goto L801A9444;
        L801A958C: ;
        c.V1 = mem.ReadU32((c.S4 - 0x16u)); 
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU32((c.S4 - 0x16u), c.V0); 
        c.V0 = mem.ReadU8(c.V1); 
        c.V1 = 0x801C0000u; 
        c.V1 = mem.ReadU32((c.V1 + 0x24C8u)); 
        if (c.V1 != 0u) {
            mem.WriteU8(c.S4, (byte)c.V0); 
            goto L801A9444;
        }
        mem.WriteU8(c.S4, (byte)c.V0); 
        goto L801AA1F4;
        L801A95BC: ;
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x24C8u)); 
        if (c.V0 != 0u) {
            { c.V1 = 0u | 0x0008u;  }
            goto L801A9444;
        }
        { c.V1 = 0u | 0x0008u;  }
        c.S1 = 0x801C0000u; 
        c.S1 = mem.ReadU32((c.S1 + 0x24E4u)); 
        c.S0 = 0u; 
        { c.S0 = c.S0 + 0x1u;  }
        L801A95E0: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        { c.V0 = (int)c.S0 < 5 ? 1u : 0u;  }
        mem.WriteU16((c.S1 + 0x32u), (ushort)c.V1); 
        c.S1 = mem.ReadU32(c.S1); 
        if (c.V0 != 0u) {
            { c.S0 = c.S0 + 0x1u;  }
            goto L801A95E0;
        }
        { c.S0 = c.S0 + 0x1u;  }
        goto L801AA1F4;
        L801A95FC: ;
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x24C8u)); 
        if (c.V0 != 0u) {
            goto L801A987C;
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
        c.A0 = mem.ReadU8((c.At + 0x784u)); 
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.A1 = mem.ReadU8((c.At + 0x788u)); 
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.V1; c.At = _s + _t;  }
        c.V1 = mem.ReadU16((c.At + 0x78Cu)); 
        { c.V0 = 0u | 0x0090u;  }
        mem.WriteU16((c.S1 + 0x1Au), (ushort)c.V0); 
        { c.V0 = c.T2 & 0x0080u;  }
        if (c.V0 == 0u) {
            mem.WriteU16((c.S1 + 0xEu), (ushort)c.V1); 
            goto L801A9680;
        }
        mem.WriteU16((c.S1 + 0xEu), (ushort)c.V1); 
        c.V1 = c.A0; 
        { c.V0 = c.V1 + 0x2Fu;  }
        goto L801A9688;
        L801A9680: ;
        c.V0 = c.A0; 
        { c.V1 = c.V0 + 0x2Fu;  }
        L801A9688: ;
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
        c.V0 = mem.ReadU16((c.At + 0x794u)); 
        mem.WriteU16((c.S3 + 0x10u), (ushort)c.V0); 
        c.RA = 0x801A9700u; 
        SoTN_st0.CutsceneUnk1_st0(c, m);
        c.RA = 0x801A9708u; 
        SoTN_st0.CutsceneUnk4_st0(c, m);
        { c.A0 = c.S0 & 0xFFFFu;  }
        c.A1 = c.S2; 
        { c.V0 = 0u | 0x01FEu;  }
        mem.WriteU16((c.S1 + 0x26u), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x32u), (ushort)0u); 
        c.RA = 0x801A9720u; 
        SoTN_st0.DrawCutsceneActorName_st0(c, m);
        { c.V0 = 0u | 0x0006u;  }
        mem.WriteU16((c.S3 + 0xCu), (ushort)c.V0); 
        { c.V0 = 0u | 0x0003u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        goto L801AA1F4;
        L801A9734: ;
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x24C8u)); 
        if (c.V0 != 0u) {
            { c.V1 = 0u | 0x0008u;  }
            goto L801A9444;
        }
        { c.V1 = 0u | 0x0008u;  }
        c.S1 = 0x801C0000u; 
        c.S1 = mem.ReadU32((c.S1 + 0x24E4u)); 
        c.S0 = 0u; 
        { c.S0 = c.S0 + 0x1u;  }
        L801A9758: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        { c.V0 = (int)c.S0 < 5 ? 1u : 0u;  }
        mem.WriteU16((c.S1 + 0x32u), (ushort)c.V1); 
        c.S1 = mem.ReadU32(c.S1); 
        if (c.V0 != 0u) {
            { c.S0 = c.S0 + 0x1u;  }
            goto L801A9758;
        }
        { c.S0 = c.S0 + 0x1u;  }
        c.S0 = 0x801C0000u; 
        { c.S0 = c.S0 + 0x2500u;  }
        c.A0 = mem.ReadU32(c.S0); 
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x384Cu)); 
        c.RA = 0x801A978Cu;
        Dispatcher.Call(c, m, c.V0);
        c.V0 = 0xFFFFFFFFu; 
        mem.WriteU32(c.S0, c.V0); 
        { c.V0 = 0u | 0x0006u;  }
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At + 0x24DCu), (ushort)c.V0); 
        { c.V0 = 0u | 0x0004u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        goto L801AA1F4;
        L801A97AC: ;
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x24C8u)); 
        if (c.V0 != 0u) {
            goto L801A987C;
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
        goto L801AA1F4;
        L801A9840: ;
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x24C8u)); 
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x0018u;  }
            goto L801A9444;
        }
        { c.V0 = 0u | 0x0018u;  }
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At + 0x24DCu), (ushort)c.V0); 
        { c.V0 = 0u | 0x0006u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        goto L801AA1F4;
        L801A9868: ;
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x24C8u)); 
        if (c.V0 == 0u) {
            goto L801A9B80;
        }
        L801A987C: ;
        c.V0 = mem.ReadU32(c.S1); 
        { c.V0 = c.V0 + 0x2u;  }
        mem.WriteU32(c.S1, c.V0); 
        goto L801A9444;
        L801A9890: ;
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x24C8u)); 
        if (c.V0 != 0u) {
            goto L801A9444;
        }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3808u)); 
        c.RA = 0x801A98B8u;
        Dispatcher.Call(c, m, c.V0);
        if (c.V0 == 0u) {
            goto L801A98FC;
        }
        goto L801A9444;
        L801A98C8: ;
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x24C8u)); 
        if (c.V0 != 0u) {
            goto L801A9444;
        }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3808u)); 
        c.RA = 0x801A98F0u;
        Dispatcher.Call(c, m, c.V0);
        { c.V1 = 0u | 0x0001u;  }
        if (c.V0 != c.V1) {
            goto L801A9444;
        }
        L801A98FC: ;
        c.V0 = mem.ReadU32(c.S1); 
        { c.V0 = c.V0 - 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        goto L801AA1F4;
        L801A9910: ;
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
        c.RA = 0x801A9964u; 
        SoTN_st0.SetCutsceneEnd_st0(c, m);
        goto L801A9444;
        L801A996C: ;
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
        goto L801A99D4;
        L801A99D0: ;
        c.V1 = mem.ReadU32(c.S1); 
        L801A99D4: ;
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.T1 = mem.ReadU8(c.V1); 
        { c.V0 = c.V1 + 0x2u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.A0 = mem.ReadU8((c.V1 + 0x1u)); 
        { c.V0 = c.V1 + 0x3u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.V0 = mem.ReadU8((c.V1 + 0x2u)); 
        c.V1 = 0x801C0000u; 
        c.V1 = mem.ReadU32((c.V1 + 0x24CCu)); 
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
        goto L801A9444;
        L801A9A30: ;
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x24CCu)); 
        c.A0 = 0x801C0000u; 
        c.A0 = mem.ReadU32((c.A0 + 0x257Cu)); 
        c.V1 = mem.ReadU8(c.V0); 
        { var _s = c.V1; var _t = c.A0; c.V0 = _t >> (int)(_s & 31u);  }
        { c.V0 = c.V0 & 0x0001u;  }
        if (c.V0 == 0u) {
            { c.V0 = 0u | 0x0001u;  }
            goto L801AA1B0;
        }
        { c.V0 = 0u | 0x0001u;  }
        { var _s = c.V1; var _t = c.V0; c.V0 = _t << (int)(_s & 31u);  }
        { var _s = 0u; var _t = c.V0; c.V0 = ~(_s | _t);  }
        c.V1 = mem.ReadU32(c.S1); 
        { var _s = c.V0; var _t = c.A0; c.V0 = _s & _t;  }
        c.At = 0x801C0000u; 
        mem.WriteU32((c.At + 0x257Cu), c.V0); 
        { c.V1 = c.V1 + 0x1u;  }
        mem.WriteU32(c.S1, c.V1); 
        goto L801A9444;
        L801A9A7C: ;
        c.V1 = mem.ReadU32(c.S1); 
        c.A0 = 0x801C0000u; 
        c.A0 = mem.ReadU32((c.A0 + 0x257Cu)); 
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.V1 = mem.ReadU8(c.V1); 
        { c.V0 = 0u | 0x0001u;  }
        { var _s = c.V1; var _t = c.V0; c.V0 = _t << (int)(_s & 31u);  }
        { var _s = c.V0; var _t = c.A0; c.V0 = _s | _t;  }
        c.At = 0x801C0000u; 
        mem.WriteU32((c.At + 0x257Cu), c.V0); 
        goto L801A9444;
        L801A9AB0: ;
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At + 0x2508u), (ushort)0u); 
        goto L801A9444;
        L801A9AC0: ;
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x24C8u)); 
        if (c.V0 == 0u) {
            { c.A1 = 0u | 0x0001u;  }
            goto L801A9AE8;
        }
        { c.A1 = 0u | 0x0001u;  }
        c.V0 = mem.ReadU32(c.S1); 
        { c.V0 = c.V0 + 0x5u;  }
        mem.WriteU32(c.S1, c.V0); 
        goto L801A9444;
        L801A9AE8: ;
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
        c.A3 = mem.ReadU16((c.At + 0x790u)); 
        { c.V0 = 0u | 0x0100u;  }
        mem.WriteU32((c.SP + 0x10u), c.V0); 
        { c.V0 = 0u | 0x0030u;  }
        mem.WriteU32((c.SP + 0x14u), c.V0); 
        { c.V0 = 0u | 0x0048u;  }
        mem.WriteU32((c.SP + 0x18u), c.V0); 
        c.RA = 0x801A9B78u; 
        SoTN_main.LoadTPage(c, m);
        goto L801A9444;
        L801A9B80: ;
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
        c.RA = 0x801A9BB4u;
        Dispatcher.Call(c, m, c.V0);
        goto L801A9444;
        L801A9BBC: ;
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x24C8u)); 
        if (c.V0 != 0u) {
            goto L801A9444;
        }
        c.V0 = mem.ReadU8((c.S1 + 0x17u)); 
        mem.WriteU8((c.S1 + 0x16u), (byte)c.V0); 
        { c.V0 = 0u | 0x0020u;  }
        if (c.V1 != c.V0) {
            { c.A0 = c.SP + 0x20u;  }
            goto L801A9C04;
        }
        { c.A0 = c.SP + 0x20u;  }
        c.V1 = 0x801C0000u; 
        { c.V1 = c.V1 + 0x24D6u;  }
        c.V0 = mem.ReadU16(c.V1); 
        { c.V0 = c.V0 + 0x2u;  }
        mem.WriteU16(c.V1, (ushort)c.V0); 
        goto L801AA1F4;
        L801A9C04: ;
        { c.V0 = c.A2 & 0x000Fu;  }
        { c.V0 = c.V0 << 1;  }
        { c.V0 = c.V0 + 0x380u;  }
        mem.WriteU16((c.SP + 0x20u), (ushort)c.V0); 
        { c.V0 = c.A2 & 0x00F0u;  }
        { c.V0 = c.V0 >> 1;  }
        c.A1 = 0x801C0000u; 
        c.A1 = (uint)(short)mem.ReadU16((c.A1 + 0x24D6u)); 
        c.V1 = 0x801C0000u; 
        c.V1 = (uint)(short)mem.ReadU16((c.V1 + 0x24DAu)); 
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
        c.RA = 0x801A9C60u; 
        if (!DialogueGlyphs.Draw(c, mem)) SoTN_main.MoveImage(c, m);
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU16((c.V0 + 0x24D6u)); 
        { c.V0 = c.V0 + 0x2u;  }
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At + 0x24D6u), (ushort)c.V0); 
        goto L801AA1F4;
        L801A9C80: ;
        { c.A0 = 0u | 0x0002u;  }
        c.RA = 0x801A9C88u; 
        SoTN_st0.ScaleCutsceneAvatar_st0(c, m);
        c.V0 = 0x801C0000u; 
        c.V0 = (uint)(short)mem.ReadU16((c.V0 + 0x24DCu)); 
        { c.V0 = (int)c.V0 < 6 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L801AA1F4;
        }
        c.V0 = mem.ReadU16((c.S2 + 0x2Cu)); 
        { c.V0 = c.V0 - 0x1u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        goto L801AA1F4;
        L801A9CB4: ;
        c.S1 = 0x801C0000u; 
        c.S1 = mem.ReadU32((c.S1 + 0x24F8u)); 
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
        c.V1 = 0x801C0000u; 
        c.V1 = (uint)(short)mem.ReadU16((c.V1 + 0x24D0u)); 
        c.V0 = (uint)(short)mem.ReadU16((c.S1 + 0x14u)); 
        c.A0 = c.V1; 
        { c.V1 = c.V1 - 0x2u;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = (int)_s < (int)_t ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.V0 = c.A0 - 0x3u;  }
            goto L801A9D28;
        }
        { c.V0 = c.A0 - 0x3u;  }
        mem.WriteU16((c.S1 + 0x2Cu), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x14u), (ushort)c.V0); 
        L801A9D28: ;
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU16((c.V0 + 0x24DCu)); 
        { c.V0 = c.V0 - 0x1u;  }
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At + 0x24DCu), (ushort)c.V0); 
        { c.V0 = c.V0 << 16;  }
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x0001u;  }
            goto L801AA1F4;
        }
        { c.V0 = 0u | 0x0001u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        c.V1 = 0x801C0000u; 
        c.V1 = mem.ReadU32((c.V1 + 0x2500u)); 
        { c.V0 = c.V1 << 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.V1 = 0x80080000u; 
        { c.V1 = c.V1 + 0x6FECu;  }
        { var _s = c.V0; var _t = c.V1; c.S1 = _s + _t;  }
        if (c.S1 == 0u) {
            goto L801AA1F4;
        }
        mem.WriteU16((c.S1 + 0x32u), (ushort)0u); 
        L801A9D88: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.S1 = mem.ReadU32(c.S1); 
        if (c.S1 == 0u) {
            goto L801AA1F4;
        }
        mem.WriteU16((c.S1 + 0x32u), (ushort)0u); 
        goto L801A9D88;
        L801A9DA0: ;
        c.S1 = 0x801C0000u; 
        c.S1 = mem.ReadU32((c.S1 + 0x24F8u)); 
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
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU16((c.V0 + 0x24DCu)); 
        { c.V0 = c.V0 - 0x1u;  }
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At + 0x24DCu), (ushort)c.V0); 
        { c.V0 = c.V0 << 16;  }
        goto L801AA0E4;
        L801A9E0C: ;
        c.V1 = mem.ReadU16((c.S2 + 0x2Eu)); 
        { c.A2 = 0u | 0x0001u;  }
        if (c.V1 == c.A2) {
            { c.V0 = (int)c.V1 < 2 ? 1u : 0u;  }
            goto L801A9F30;
        }
        { c.V0 = (int)c.V1 < 2 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L801A9E34;
        }
        if (c.V1 == 0u) {
            { c.A0 = 0u | 0x0002u;  }
            goto L801A9E48;
        }
        { c.A0 = 0u | 0x0002u;  }
        goto L801AA1F4;
        L801A9E34: ;
        { c.V0 = 0u | 0x0002u;  }
        if (c.V1 == c.V0) {
            goto L801AA02C;
        }
        goto L801AA1F4;
        L801A9E48: ;
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3848u)); 
        c.At = 0x801C0000u; 
        mem.WriteU32((c.At + 0x2580u), c.A2); 
        { c.A1 = 0u | 0x0048u;  }
        c.RA = 0x801A9E60u;
        Dispatcher.Call(c, m, c.V0);
        { c.V0 = c.V0 << 16;  }
        { c.V1 = (uint)((int)c.V0 >> 16);  }
        c.V0 = 0xFFFFFFFFu; 
        if (c.V1 != c.V0) {
            { c.V0 = c.V1 << 1;  }
            goto L801A9E7C;
        }
        { c.V0 = c.V1 << 1;  }
        c.A0 = c.S2; 
        goto L801AA1EC;
        L801A9E7C: ;
        c.A2 = 0x801C0000u; 
        { c.A2 = c.A2 + 0x24FCu;  }
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
            goto L801AA018;
        }
        c.A0 = 0u; 
        { c.A1 = 0u | 0x007Fu;  }
        { c.V1 = 0u | 0x00F7u;  }
        { c.T1 = c.A2 - 0x28u;  }
        { c.T0 = 0u | 0x01FEu;  }
        c.A3 = 0x80180000u; 
        { c.A3 = c.A3 + 0x798u;  }
        { c.A2 = 0u | 0x0F70u;  }
        L801A9EC8: ;
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
            goto L801A9EC8;
        }
        { c.A0 = c.A0 + 0x1u;  }
        goto L801AA018;
        L801A9F30: ;
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x24FCu)); 
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
            goto L801A9FC4;
        }
        c.A0 = 0u; 
        { c.A1 = 0u | 0x0004u;  }
        L801A9F68: ;
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
            goto L801A9F94;
        }
        mem.WriteU16((c.S1 + 0x20u), (ushort)c.V0); 
        { c.V1 = c.V1 + 0xFu;  }
        L801A9F94: ;
        { c.V0 = (uint)((int)c.V1 >> 4);  }
        mem.WriteU16((c.S1 + 0x8u), (ushort)c.V0); 
        { c.V0 = (int)c.V0 < 5 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L801A9FB0;
        }
        mem.WriteU16((c.S1 + 0x8u), (ushort)c.A1); 
        goto L801A9FB4;
        L801A9FB0: ;
        { c.A0 = 0u | 0x0001u;  }
        L801A9FB4: ;
        c.S1 = mem.ReadU32(c.S1); 
        if (c.S1 != 0u) {
            goto L801A9F68;
        }
        L801A9FC4: ;
        { c.V0 = c.A0 << 16;  }
        if (c.V0 != 0u) {
            goto L801AA1F4;
        }
        c.S0 = 0x801C0000u; 
        { c.S0 = c.S0 + 0x24FCu;  }
        c.A0 = mem.ReadU32(c.S0); 
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x384Cu)); 
        c.RA = 0x801A9FF0u;
        Dispatcher.Call(c, m, c.V0);
        c.S1 = 0x801C0000u; 
        c.S1 = mem.ReadU32((c.S1 + 0x24F8u)); 
        c.V0 = 0xFFFFFFFFu; 
        mem.WriteU32(c.S0, c.V0); 
        c.S1 = mem.ReadU32(c.S1); 
        { c.V0 = 0u | 0x0011u;  }
        mem.WriteU16((c.S1 + 0x32u), (ushort)c.V0); 
        c.S1 = mem.ReadU32(c.S1); 
        { c.V0 = 0u | 0x0051u;  }
        mem.WriteU16((c.S1 + 0x32u), (ushort)c.V0); 
        L801AA018: ;
        c.V0 = mem.ReadU16((c.S2 + 0x2Eu)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S2 + 0x2Eu), (ushort)c.V0); 
        goto L801AA1F4;
        L801AA02C: ;
        c.S1 = 0x801C0000u; 
        c.S1 = mem.ReadU32((c.S1 + 0x24F8u)); 
        c.S1 = mem.ReadU32(c.S1); 
        c.V0 = mem.ReadU8((c.S1 + 0x4u)); 
        { c.V0 = c.V0 < 0x00000010u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            c.A0 = 0u; 
            goto L801AA068;
        }
        c.A0 = 0u; 
        mem.WriteU8((c.S1 + 0x28u), (byte)0u); 
        mem.WriteU8((c.S1 + 0x1Cu), (byte)0u); 
        mem.WriteU8((c.S1 + 0x10u), (byte)0u); 
        mem.WriteU8((c.S1 + 0x4u), (byte)0u); 
        goto L801AA084;
        L801AA068: ;
        c.V0 = mem.ReadU8((c.S1 + 0x28u)); 
        { c.A0 = 0u | 0x0001u;  }
        { c.V0 = c.V0 - 0x10u;  }
        mem.WriteU8((c.S1 + 0x28u), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0x1Cu), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0x10u), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0x4u), (byte)c.V0); 
        L801AA084: ;
        c.V0 = mem.ReadU8((c.S1 + 0x6u)); 
        { c.V0 = c.V0 < 0x0000007Fu ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.V0 = 0u | 0x007Fu;  }
            goto L801AA0A4;
        }
        { c.V0 = 0u | 0x007Fu;  }
        c.V0 = mem.ReadU8((c.S1 + 0x12u)); 
        { c.A0 = 0u | 0x0001u;  }
        { c.V0 = c.V0 + 0x8u;  }
        L801AA0A4: ;
        mem.WriteU8((c.S1 + 0x12u), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0x6u), (byte)c.V0); 
        c.S1 = mem.ReadU32(c.S1); 
        c.V0 = mem.ReadU8((c.S1 + 0x4u)); 
        { c.V0 = c.V0 < 0x00000010u ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x0010u;  }
            goto L801AA0D4;
        }
        { c.V0 = 0u | 0x0010u;  }
        c.V0 = mem.ReadU8((c.S1 + 0x6u)); 
        { c.A0 = 0u | 0x0001u;  }
        { c.V0 = c.V0 - 0xFu;  }
        L801AA0D4: ;
        mem.WriteU8((c.S1 + 0x6u), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0x5u), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0x4u), (byte)c.V0); 
        { c.V0 = c.A0 << 16;  }
        L801AA0E4: ;
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x0001u;  }
            goto L801AA1F4;
        }
        { c.V0 = 0u | 0x0001u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        goto L801AA1F4;
        L801AA0F4: ;
        c.S1 = 0x801C0000u; 
        c.S1 = mem.ReadU32((c.S1 + 0x24F8u)); 
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU16((c.V0 + 0x24DCu)); 
        c.S1 = mem.ReadU32(c.S1); 
        { c.V0 = c.V0 - 0x1u;  }
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At + 0x24DCu), (ushort)c.V0); 
        { c.V0 = c.V0 << 16;  }
        { c.V1 = (uint)((int)c.V0 >> 16);  }
        { c.V0 = (int)c.V1 < 12 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L801AA160;
        }
        c.S1 = mem.ReadU32(c.S1); 
        c.V1 = mem.ReadU8((c.S1 + 0xCu)); 
        { c.V0 = c.V1 + 0xECu;  }
        mem.WriteU8((c.S1 + 0xCu), (byte)c.V0); 
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU16((c.V0 + 0x24DCu)); 
        { c.V0 = c.V0 & 0x0001u;  }
        if (c.V0 == 0u) {
            { c.V0 = c.V1 - 0x15u;  }
            goto L801AA1F4;
        }
        { c.V0 = c.V1 - 0x15u;  }
        mem.WriteU8((c.S1 + 0xCu), (byte)c.V0); 
        goto L801AA1F4;
        L801AA160: ;
        if (c.V1 != 0u) {
            { c.V0 = 0u | 0x0001u;  }
            goto L801AA178;
        }
        { c.V0 = 0u | 0x0001u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        { c.V0 = 0u | 0x0008u;  }
        mem.WriteU16((c.S1 + 0x32u), (ushort)c.V0); 
        goto L801AA18C;
        L801AA178: ;
        c.V0 = mem.ReadU16((c.S1 + 0x2Eu)); 
        { c.V0 = c.V0 - 0x6u;  }
        mem.WriteU16((c.S1 + 0x2Eu), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x22u), (ushort)c.V0); 
        L801AA18C: ;
        c.S1 = mem.ReadU32(c.S1); 
        { c.V0 = 0u | 0x0008u;  }
        mem.WriteU16((c.S1 + 0x32u), (ushort)c.V0); 
        goto L801AA1F4;
        L801AA19C: ;
        c.V0 = mem.ReadU8(c.S4); 
        { c.V0 = c.V0 - 0x1u;  }
        mem.WriteU8(c.S4, (byte)c.V0); 
        goto L801AA1F4;
        L801AA1B0: ;
        c.V1 = 0x801C0000u; 
        { c.V1 = c.V1 + 0x24CCu;  }
        c.V0 = mem.ReadU32(c.V1); 
        { c.V0 = c.V0 - 0x1u;  }
        mem.WriteU32(c.V1, c.V0); 
        goto L801AA1F4;
        L801AA1CC: ;
        c.V1 = 0x80040000u; 
        { c.V1 = c.V1 - 0x34FCu;  }
        c.V0 = mem.ReadU32(c.V1); 
        c.A0 = c.S2; 
        c.At = 0x80040000u; 
        mem.WriteU32((c.At - 0x38FCu), 0u); 
        { c.V0 = c.V0 | 0x0001u;  }
        mem.WriteU32(c.V1, c.V0); 
        L801AA1EC: ;
        c.RA = 0x801AA1F4u; 
        SoTN_st0.DestroyEntity_st0(c, m);
        L801AA1F4: ;
        c.RA = mem.ReadU32((c.SP + 0x44u)); 
        c.S4 = mem.ReadU32((c.SP + 0x40u)); 
        c.S3 = mem.ReadU32((c.SP + 0x3Cu)); 
        c.S2 = mem.ReadU32((c.SP + 0x38u)); 
        c.S1 = mem.ReadU32((c.SP + 0x34u)); 
        c.S0 = mem.ReadU32((c.SP + 0x30u)); 
        { c.SP = c.SP + 0x48u;  }
        return;
        { c.A0 = c.A0 << 16;  }
        { c.A0 = (uint)((int)c.A0 >> 16);  }
        { c.V0 = 0u | 0x00E0u;  }
        { var _s = c.V0; var _t = c.A0; c.V0 = _s - _t;  }
        { c.V1 = c.V0 >> 31;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = (uint)((int)c.V0 >> 1);  }
        c.A0 = 0x80090000u; 
        { c.A0 = c.A0 + 0x740Cu;  }
        c.V1 = mem.ReadU16(c.A0); 
        { c.A1 = c.V0 + 0x80u;  }
        { var _s = c.A1; var _t = c.V1; c.V1 = _s - _t;  }
        { c.V1 = c.V1 << 16;  }
        { c.V1 = (uint)((int)c.V1 >> 16);  }
        { c.V0 = (int)c.V1 < 3 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L801AA268;
        }
        c.V0 = mem.ReadU32(c.A0); 
        { c.V0 = c.V0 + 0x2u;  }
        goto L801AA288;
        L801AA268: ;
        { c.V0 = (int)c.V1 < -2 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L801AA280;
        }
        c.V0 = mem.ReadU32(c.A0); 
        { c.V0 = c.V0 - 0x2u;  }
        goto L801AA288;
        L801AA280: ;
        { c.V0 = c.A1 << 16;  }
        { c.V0 = (uint)((int)c.V0 >> 16);  }
        L801AA288: ;
        mem.WriteU32(c.A0, c.V0); 
        return;
        { c.SP = c.SP - 0x20u;  }
        mem.WriteU32((c.SP + 0x10u), c.S0); 
        c.S0 = c.A0; 
        c.V0 = 0x80070000u; 
        c.V0 = mem.ReadU16((c.V0 + 0x33DAu)); 
        c.A0 = 0x80070000u; 
        { c.A0 = c.A0 + 0x3084u;  }
        mem.WriteU32((c.SP + 0x14u), c.S1); 
        c.S1 = 0x80070000u; 
        { c.S1 = c.S1 + 0x33D8u;  }
        mem.WriteU32((c.SP + 0x1Cu), c.RA); 
        mem.WriteU32((c.SP + 0x18u), c.S2); 
        mem.WriteU16((c.S0 + 0x2u), (ushort)c.V0); 
        c.V0 = 0x80070000u; 
        c.V0 = mem.ReadU16((c.V0 + 0x33DEu)); 
        c.V1 = mem.ReadU16((c.S0 + 0x2Cu)); 
        { c.V0 = c.V0 - 0x1u;  }
        mem.WriteU16((c.S0 + 0x6u), (ushort)c.V0); 
        { c.V0 = 0u | 0x000Eu;  }
        if (c.V1 == c.V0) {
            goto L801AA320;
        }
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x24C8u)); 
        if (c.V0 == 0u) {
            goto L801AA320;
        }
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x2580u)); 
        if (c.V0 == 0u) {
            { c.V0 = c.V1 < 0x00000005u ? 1u : 0u;  }
            goto L801AA320;
        }
        { c.V0 = c.V1 < 0x00000005u ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x000Fu;  }
            goto L801AA320;
        }
        { c.V0 = 0u | 0x000Fu;  }
        mem.WriteU16((c.S0 + 0x2Cu), (ushort)c.V0); 
        mem.WriteU16((c.S0 + 0x54u), (ushort)0u); 
        mem.WriteU16((c.S0 + 0x56u), (ushort)0u); 
        L801AA320: ;
        c.V1 = mem.ReadU16((c.S0 + 0x2Cu)); 
        { c.V0 = c.V1 < 0x00000010u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.V0 = c.V1 << 2;  }
            goto L801AA8C0;
        }
        { c.V0 = c.V1 << 2;  }
        c.At = 0x801A0000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.V0 = mem.ReadU32((c.At + 0x7A74u)); 
        switch (c.V0)
        {
            case 0x801AA34Cu: goto L801AA34C;
            case 0x801AA370u: goto L801AA370;
            case 0x801AA458u: goto L801AA458;
            case 0x801AA50Cu: goto L801AA50C;
            case 0x801AA584u: goto L801AA584;
            case 0x801AA5D0u: goto L801AA5D0;
            case 0x801AA618u: goto L801AA618;
            case 0x801AA65Cu: goto L801AA65C;
            case 0x801AA6A0u: goto L801AA6A0;
            case 0x801AA6E4u: goto L801AA6E4;
            case 0x801AA728u: goto L801AA728;
            case 0x801AA76Cu: goto L801AA76C;
            case 0x801AA7B0u: goto L801AA7B0;
            case 0x801AA7F4u: goto L801AA7F4;
            case 0x801AA840u: goto L801AA840;
            case 0x801AA880u: goto L801AA880;
            case 0x801AA91Cu: goto L801AA91C;
            case 0x801AA9C0u: goto L801AA9C0;
            case 0x801AAA40u: goto L801AAA40;
            case 0x801AAB8Cu: goto L801AAB8C;
            case 0x801AAA90u: goto L801AAA90;
            default: Dispatcher.Call(c, m, c.V0); return;
        }
        L801AA34C: ;
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x598u;  }
        c.RA = 0x801AA35Cu; 
        SoTN_st0.InitializeEntity_st0(c, m);
        { c.V0 = 0u | 0x0046u;  }
        mem.WriteU16((c.S0 + 0x5Au), (ushort)c.V0); 
        { c.V0 = 0u | 0x0120u;  }
        mem.WriteU16((c.S0 + 0x16u), (ushort)c.V0); 
        goto L801AA8C0;
        L801AA370: ;
        c.V0 = mem.ReadU16((c.S0 + 0x2Eu)); 
        if (c.V0 == 0u) {
            goto L801AA424;
        }
        c.V1 = mem.ReadU16((c.S1 + 0x2Cu)); 
        { c.V0 = c.V1 < 0x00000003u ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x0019u;  }
            goto L801AA39C;
        }
        { c.V0 = 0u | 0x0019u;  }
        if (c.V1 != c.V0) {
            goto L801AA8C0;
        }
        L801AA39C: ;
        c.V0 = mem.ReadU16((c.S1 + 0x2u)); 
        c.V1 = mem.ReadU16((c.A0 + 0xAu)); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        c.A0 = c.V0; 
        { c.V0 = c.A0 & 0xFFFFu;  }
        { c.V1 = 0u | 0x8000u;  }
        { var _s = c.V1; var _t = c.V0; c.V0 = _s < _t ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.V0 = c.A0 & 0xFFFFu;  }
            goto L801AA3CC;
        }
        { c.V0 = c.A0 & 0xFFFFu;  }
        c.A0 = 0u; 
        { c.V0 = c.A0 & 0xFFFFu;  }
        L801AA3CC: ;
        { c.V0 = c.V0 < 0x000000A1u ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x2000u;  }
            goto L801AA3E8;
        }
        { c.V0 = 0u | 0x2000u;  }
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x2EF4u), c.V1); 
        { c.A0 = c.A0 << 16;  }
        goto L801AA3F4;
        L801AA3E8: ;
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x2EF4u), c.V0); 
        { c.A0 = c.A0 << 16;  }
        L801AA3F4: ;
        { c.V0 = 0u | 0x0001u;  }
        c.At = 0x80070000u; 
        mem.WriteU8((c.At + 0x3510u), (byte)c.V0); 
        { c.V0 = 0u | 0x00FFu;  }
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x2EFCu), c.V0); 
        { c.A0 = (uint)((int)c.A0 >> 16);  }
        c.RA = 0x801AA414u; 
        SoTN_st0.func_801AA218(c, m);
        { c.A0 = 0u | 0x0002u;  }
        c.RA = 0x801AA41Cu; 
        SoTN_st0.SetStep_st0(c, m);
        goto L801AA8C0;
        L801AA424: ;
        c.V0 = (uint)(short)mem.ReadU16((c.S1 + 0x2u)); 
        c.V1 = (uint)(short)mem.ReadU16((c.A0 + 0xAu)); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = (int)c.V0 < 225 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L801AA8C0;
        }
        c.V0 = mem.ReadU16((c.S0 + 0x2Eu)); 
        c.At = 0x80040000u; 
        mem.WriteU32((c.At - 0x3748u), 0u); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S0 + 0x2Eu), (ushort)c.V0); 
        goto L801AA8C0;
        L801AA458: ;
        c.V0 = mem.ReadU16((c.S1 + 0x2u)); 
        c.V1 = mem.ReadU16((c.A0 + 0xAu)); 
        { c.A1 = 0u | 0x8000u;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        c.A0 = c.V0; 
        { c.V0 = c.A0 & 0xFFFFu;  }
        { var _s = c.A1; var _t = c.V0; c.V0 = _s < _t ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L801AA480;
        }
        c.A0 = 0u; 
        L801AA480: ;
        c.V1 = 0x80070000u; 
        c.V1 = mem.ReadU32((c.V1 + 0x2EF4u)); 
        if (c.V1 != c.A1) {
            { c.V0 = 0u | 0x2000u;  }
            goto L801AA4A8;
        }
        { c.V0 = 0u | 0x2000u;  }
        { c.V0 = c.A0 & 0xFFFFu;  }
        { c.V0 = c.V0 < 0x000000A1u ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x0001u;  }
            goto L801AA4BC;
        }
        { c.V0 = 0u | 0x0001u;  }
        { c.V0 = 0u | 0x2000u;  }
        L801AA4A8: ;
        if (c.V1 != c.V0) {
            { c.V0 = c.A0 & 0xFFFFu;  }
            goto L801AA4F8;
        }
        { c.V0 = c.A0 & 0xFFFFu;  }
        { c.V0 = c.V0 < 0x0000009Fu ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x0001u;  }
            goto L801AA4F8;
        }
        { c.V0 = 0u | 0x0001u;  }
        L801AA4BC: ;
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x2EFCu), c.V0); 
        { c.V0 = 0u | 0x8000u;  }
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x2EF4u), c.V0); 
        c.V1 = mem.ReadU16((c.S0 + 0x2Cu)); 
        { c.V0 = 0u | 0x0018u;  }
        mem.WriteU16((c.S0 + 0x7Cu), (ushort)c.V0); 
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x257Cu)); 
        { c.V1 = c.V1 + 0x1u;  }
        { c.V0 = c.V0 | 0x0001u;  }
        c.At = 0x801C0000u; 
        mem.WriteU32((c.At + 0x257Cu), c.V0); 
        mem.WriteU16((c.S0 + 0x2Cu), (ushort)c.V1); 
        L801AA4F8: ;
        { c.A0 = c.A0 << 16;  }
        { c.A0 = (uint)((int)c.A0 >> 16);  }
        c.RA = 0x801AA504u; 
        SoTN_st0.func_801AA218(c, m);
        goto L801AA8C0;
        L801AA50C: ;
        c.V0 = mem.ReadU16((c.S1 + 0x2u)); 
        c.V1 = mem.ReadU16((c.A0 + 0xAu)); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        c.A0 = c.V0; 
        { c.V1 = c.A0 & 0xFFFFu;  }
        { c.V0 = 0u | 0x8000u;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s < _t ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L801AA538;
        }
        c.A0 = 0u; 
        L801AA538: ;
        { c.A0 = c.A0 << 16;  }
        { c.A0 = (uint)((int)c.A0 >> 16);  }
        c.RA = 0x801AA544u; 
        SoTN_st0.func_801AA218(c, m);
        { c.V0 = 0u | 0x0001u;  }
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x2EFCu), c.V0); 
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x2EF4u), 0u); 
        c.V0 = mem.ReadU16((c.S0 + 0x7Cu)); 
        { c.V0 = c.V0 - 0x1u;  }
        mem.WriteU16((c.S0 + 0x7Cu), (ushort)c.V0); 
        { c.V0 = c.V0 & 0xFFFFu;  }
        if (c.V0 != 0u) {
            goto L801AA8C0;
        }
        { c.A0 = 0u | 0x0004u;  }
        c.RA = 0x801AA57Cu; 
        SoTN_st0.SetStep_st0(c, m);
        goto L801AA8C0;
        L801AA584: ;
        { c.V0 = 0u | 0x0001u;  }
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x2EFCu), c.V0); 
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x830u;  }
        c.A1 = c.S0; 
        c.RA = 0x801AA5A0u; 
        SoTN_st0.AnimateEntity_st0(c, m);
        if (c.V0 != 0u) {
            goto L801AA5C4;
        }
        c.V0 = mem.ReadU16((c.S0 + 0x2Cu)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S0 + 0x2Cu), (ushort)c.V0); 
        { c.V0 = 0u | 0x0100u;  }
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x30C8u), c.V0); 
        L801AA5C4: ;
        c.V0 = mem.ReadU16((c.S0 + 0x56u)); 
        mem.WriteU16((c.S1 + 0x56u), (ushort)c.V0); 
        goto L801AA8C0;
        L801AA5D0: ;
        { c.V0 = 0u | 0x0001u;  }
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x2EFCu), c.V0); 
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x257Cu)); 
        c.V1 = mem.ReadU16((c.S0 + 0x56u)); 
        { c.V0 = c.V0 & 0x0400u;  }
        if (c.V0 == 0u) {
            mem.WriteU16((c.S1 + 0x56u), (ushort)c.V1); 
            goto L801AA8C0;
        }
        mem.WriteU16((c.S1 + 0x56u), (ushort)c.V1); 
        { c.A0 = 0u | 0x0006u;  }
        c.V0 = 0xFFFF8005u; 
        mem.WriteU16((c.S1 + 0x56u), (ushort)0u); 
        mem.WriteU16((c.S0 + 0x54u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0001u;  }
        mem.WriteU16((c.S0 + 0x56u), (ushort)c.V0); 
        c.RA = 0x801AA610u; 
        SoTN_st0.SetStep_st0(c, m);
        goto L801AA8C0;
        L801AA618: ;
        { c.V0 = 0u | 0x0001u;  }
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x2EFCu), c.V0); 
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x83Cu;  }
        c.A1 = c.S0; 
        c.RA = 0x801AA634u; 
        SoTN_st0.AnimateEntity_st0(c, m);
        if (c.V0 != 0u) {
            goto L801AA838;
        }
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x257Cu)); 
        { c.V0 = c.V0 & 0x0800u;  }
        if (c.V0 == 0u) {
            { c.A0 = 0u | 0x0007u;  }
            goto L801AA838;
        }
        { c.A0 = 0u | 0x0007u;  }
        goto L801AA830;
        L801AA65C: ;
        { c.V0 = 0u | 0x0001u;  }
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x2EFCu), c.V0); 
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x84Cu;  }
        c.A1 = c.S0; 
        c.RA = 0x801AA678u; 
        SoTN_st0.AnimateEntity_st0(c, m);
        if (c.V0 != 0u) {
            goto L801AA838;
        }
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x257Cu)); 
        { c.V0 = c.V0 & 0x1000u;  }
        if (c.V0 == 0u) {
            { c.A0 = 0u | 0x0008u;  }
            goto L801AA838;
        }
        { c.A0 = 0u | 0x0008u;  }
        goto L801AA830;
        L801AA6A0: ;
        { c.V0 = 0u | 0x0001u;  }
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x2EFCu), c.V0); 
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x85Cu;  }
        c.A1 = c.S0; 
        c.RA = 0x801AA6BCu; 
        SoTN_st0.AnimateEntity_st0(c, m);
        if (c.V0 != 0u) {
            goto L801AA838;
        }
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x257Cu)); 
        { c.V0 = c.V0 & 0x2000u;  }
        if (c.V0 == 0u) {
            { c.A0 = 0u | 0x0009u;  }
            goto L801AA838;
        }
        { c.A0 = 0u | 0x0009u;  }
        goto L801AA830;
        L801AA6E4: ;
        { c.V0 = 0u | 0x0001u;  }
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x2EFCu), c.V0); 
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x864u;  }
        c.A1 = c.S0; 
        c.RA = 0x801AA700u; 
        SoTN_st0.AnimateEntity_st0(c, m);
        if (c.V0 != 0u) {
            goto L801AA838;
        }
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x257Cu)); 
        { c.V0 = c.V0 & 0x4000u;  }
        if (c.V0 == 0u) {
            { c.A0 = 0u | 0x000Au;  }
            goto L801AA838;
        }
        { c.A0 = 0u | 0x000Au;  }
        goto L801AA830;
        L801AA728: ;
        { c.V0 = 0u | 0x0001u;  }
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x2EFCu), c.V0); 
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x86Cu;  }
        c.A1 = c.S0; 
        c.RA = 0x801AA744u; 
        SoTN_st0.AnimateEntity_st0(c, m);
        if (c.V0 != 0u) {
            goto L801AA838;
        }
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x257Cu)); 
        { c.V0 = c.V0 & 0x8000u;  }
        if (c.V0 == 0u) {
            { c.A0 = 0u | 0x000Bu;  }
            goto L801AA838;
        }
        { c.A0 = 0u | 0x000Bu;  }
        goto L801AA830;
        L801AA76C: ;
        { c.V0 = 0u | 0x0001u;  }
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x2EFCu), c.V0); 
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x87Cu;  }
        c.A1 = c.S0; 
        c.RA = 0x801AA788u; 
        SoTN_st0.AnimateEntity_st0(c, m);
        if (c.V0 != 0u) {
            c.V1 = 0x00010000u; 
            goto L801AA838;
        }
        c.V1 = 0x00010000u; 
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x257Cu)); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s & _t;  }
        if (c.V0 == 0u) {
            { c.A0 = 0u | 0x000Cu;  }
            goto L801AA838;
        }
        { c.A0 = 0u | 0x000Cu;  }
        goto L801AA830;
        L801AA7B0: ;
        { c.V0 = 0u | 0x0001u;  }
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x2EFCu), c.V0); 
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x884u;  }
        c.A1 = c.S0; 
        c.RA = 0x801AA7CCu; 
        SoTN_st0.AnimateEntity_st0(c, m);
        if (c.V0 != 0u) {
            c.V1 = 0x00020000u; 
            goto L801AA838;
        }
        c.V1 = 0x00020000u; 
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x257Cu)); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s & _t;  }
        if (c.V0 == 0u) {
            { c.A0 = 0u | 0x000Du;  }
            goto L801AA838;
        }
        { c.A0 = 0u | 0x000Du;  }
        goto L801AA830;
        L801AA7F4: ;
        { c.V0 = 0u | 0x0001u;  }
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x2EFCu), c.V0); 
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x88Cu;  }
        c.A1 = c.S0; 
        c.RA = 0x801AA810u; 
        SoTN_st0.AnimateEntity_st0(c, m);
        if (c.V0 != 0u) {
            c.V1 = 0x00040000u; 
            goto L801AA838;
        }
        c.V1 = 0x00040000u; 
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x257Cu)); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s & _t;  }
        if (c.V0 == 0u) {
            { c.A0 = 0u | 0x000Eu;  }
            goto L801AA838;
        }
        { c.A0 = 0u | 0x000Eu;  }
        L801AA830: ;
        c.RA = 0x801AA838u; 
        SoTN_st0.SetStep_st0(c, m);
        L801AA838: ;
        mem.WriteU16((c.S1 + 0x56u), (ushort)0u); 
        goto L801AA8C0;
        L801AA840: ;
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x894u;  }
        c.A1 = c.S0; 
        { c.V0 = 0u | 0x0001u;  }
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x2EFCu), c.V0); 
        mem.WriteU16((c.S1 + 0x56u), (ushort)0u); 
        c.RA = 0x801AA860u; 
        SoTN_st0.AnimateEntity_st0(c, m);
        if (c.V0 != 0u) {
            { c.A0 = 0u | 0x000Fu;  }
            goto L801AA8C0;
        }
        { c.A0 = 0u | 0x000Fu;  }
        { c.V0 = 0u | 0x0007u;  }
        mem.WriteU16((c.S0 + 0x56u), (ushort)0u); 
        mem.WriteU16((c.S1 + 0x56u), (ushort)c.V0); 
        c.RA = 0x801AA878u; 
        SoTN_st0.SetStep_st0(c, m);
        goto L801AA8C0;
        L801AA880: ;
        { c.S2 = 0u | 0x0001u;  }
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x257Cu)); 
        { c.V1 = 0u | 0x0007u;  }
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x2EFCu), c.S2); 
        { c.V0 = c.V0 & 0x0004u;  }
        if (c.V0 == 0u) {
            mem.WriteU16((c.S1 + 0x56u), (ushort)c.V1); 
            goto L801AA8C0;
        }
        mem.WriteU16((c.S1 + 0x56u), (ushort)c.V1); 
        { c.V0 = 0u | 0x8000u;  }
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x2EF4u), c.V0); 
        c.A0 = c.S0; 
        c.RA = 0x801AA8B8u; 
        SoTN_st0.DestroyEntity_st0(c, m);
        c.At = 0x80040000u; 
        mem.WriteU32((c.At - 0x3748u), c.S2); 
        L801AA8C0: ;
        c.RA = mem.ReadU32((c.SP + 0x1Cu)); 
        c.S2 = mem.ReadU32((c.SP + 0x18u)); 
        c.S1 = mem.ReadU32((c.SP + 0x14u)); 
        c.S0 = mem.ReadU32((c.SP + 0x10u)); 
        { c.SP = c.SP + 0x20u;  }
        return;
        { c.SP = c.SP - 0x20u;  }
        mem.WriteU32((c.SP + 0x10u), c.S0); 
        c.S0 = c.A0; 
        mem.WriteU32((c.SP + 0x18u), c.RA); 
        mem.WriteU32((c.SP + 0x14u), c.S1); 
        c.V1 = mem.ReadU16((c.S0 + 0x2Cu)); 
        { c.V0 = c.V1 < 0x00000005u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.V0 = c.V1 << 2;  }
            goto L801AAB8C;
        }
        { c.V0 = c.V1 << 2;  }
        c.At = 0x801A0000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.V0 = mem.ReadU32((c.At + 0x7AB4u)); 
        switch (c.V0)
        {
            case 0x801AA91Cu: goto L801AA91C;
            case 0x801AA9C0u: goto L801AA9C0;
            case 0x801AAA40u: goto L801AAA40;
            case 0x801AAB8Cu: goto L801AAB8C;
            case 0x801AAA90u: goto L801AAA90;
            default: Dispatcher.Call(c, m, c.V0); return;
        }
        L801AA91C: ;
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x628u;  }
        c.RA = 0x801AA92Cu; 
        SoTN_st0.InitializeEntity_st0(c, m);
        c.V1 = mem.ReadU16((c.S0 + 0x30u)); 
        { c.V0 = 0u | 0x0005u;  }
        mem.WriteU16((c.S0 + 0x56u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0006u;  }
        mem.WriteU8((c.S0 + 0x46u), (byte)c.V0); 
        mem.WriteU8((c.S0 + 0x47u), (byte)c.V0); 
        { c.V0 = 0u | 0x0002u;  }
        if (c.V1 == 0u) {
            mem.WriteU16((c.S0 + 0x3Cu), (ushort)c.V0); 
            goto L801AA968;
        }
        mem.WriteU16((c.S0 + 0x3Cu), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S0 + 0x24u)); 
        { c.V1 = 0u | 0x0004u;  }
        mem.WriteU16((c.S0 + 0x2Cu), (ushort)c.V1); 
        { c.V0 = c.V0 + 0x2u;  }
        mem.WriteU16((c.S0 + 0x24u), (ushort)c.V0); 
        goto L801AAB8C;
        L801AA968: ;
        c.V0 = 0x80180000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x89Cu)); 
        if (c.V0 == 0u) {
            { c.V0 = 0u | 0x0004u;  }
            goto L801AA9AC;
        }
        { c.V0 = 0u | 0x0004u;  }
        c.V1 = mem.ReadU16((c.S0 + 0x16u)); 
        mem.WriteU16((c.S0 + 0x56u), (ushort)c.V0); 
        mem.WriteU16((c.S0 + 0x3Cu), (ushort)0u); 
        { c.V1 = c.V1 + 0x1u;  }
        mem.WriteU16((c.S0 + 0x16u), (ushort)c.V1); 
        c.V0 = 0x80070000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x3084u)); 
        mem.WriteU16((c.V0 + 0x388u), (ushort)0u); 
        { c.V0 = 0u | 0x0003u;  }
        mem.WriteU16((c.S0 + 0x2Cu), (ushort)c.V0); 
        goto L801AAB8C;
        L801AA9AC: ;
        c.V1 = 0x80070000u; 
        c.V1 = mem.ReadU32((c.V1 + 0x3084u)); 
        { c.V0 = 0u | 0x032Fu;  }
        mem.WriteU16((c.V1 + 0x388u), (ushort)c.V0); 
        goto L801AAB8C;
        L801AA9C0: ;
        c.V0 = mem.ReadU8((c.S0 + 0x48u)); 
        if (c.V0 == 0u) {
            goto L801AAB8C;
        }
        c.V0 = 0x80070000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x3084u)); 
        mem.WriteU16((c.V0 + 0x388u), (ushort)0u); 
        { c.V0 = 0u | 0x0004u;  }
        mem.WriteU16((c.S0 + 0x56u), (ushort)c.V0); 
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3824u)); 
        { c.A0 = 0u | 0x0644u;  }
        c.RA = 0x801AA9FCu;
        Dispatcher.Call(c, m, c.V0);
        c.A0 = 0x80080000u; 
        { c.A0 = c.A0 - 0x27A8u;  }
        { c.A1 = c.A0 + 0x1780u;  }
        c.RA = 0x801AAA0Cu; 
        SoTN_st0.AllocEntity_st0(c, m);
        c.S1 = c.V0; 
        if (c.S1 == 0u) {
            { c.A0 = 0u | 0x0028u;  }
            goto L801AAA2C;
        }
        { c.A0 = 0u | 0x0028u;  }
        c.A1 = c.S0; 
        c.A2 = c.S1; 
        c.RA = 0x801AAA24u; 
        SoTN_st0.CreateEntityFromEntity_st0(c, m);
        { c.V0 = 0u | 0x0001u;  }
        mem.WriteU16((c.S1 + 0x30u), (ushort)c.V0); 
        L801AAA2C: ;
        c.V0 = mem.ReadU16((c.S0 + 0x2Cu)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S0 + 0x2Cu), (ushort)c.V0); 
        goto L801AAB8C;
        L801AAA40: ;
        c.V0 = mem.ReadU8((c.S0 + 0x48u)); 
        if (c.V0 == 0u) {
            goto L801AAB8C;
        }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3824u)); 
        { c.A0 = 0u | 0x0640u;  }
        c.RA = 0x801AAA64u;
        Dispatcher.Call(c, m, c.V0);
        c.V1 = mem.ReadU16((c.S0 + 0x2Cu)); 
        { c.V0 = 0u | 0x0001u;  }
        c.At = 0x80180000u; 
        mem.WriteU32((c.At + 0x89Cu), c.V0); 
        c.V0 = mem.ReadU16((c.S0 + 0x16u)); 
        mem.WriteU16((c.S0 + 0x3Cu), (ushort)0u); 
        { c.V1 = c.V1 + 0x1u;  }
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S0 + 0x16u), (ushort)c.V0); 
        mem.WriteU16((c.S0 + 0x2Cu), (ushort)c.V1); 
        goto L801AAB8C;
        L801AAA90: ;
        c.V1 = mem.ReadU16((c.S0 + 0x2Eu)); 
        { c.V0 = 0u | 0x0001u;  }
        if (c.V1 == c.V0) {
            { c.V0 = (int)c.V1 < 2 ? 1u : 0u;  }
            goto L801AAAEC;
        }
        { c.V0 = (int)c.V1 < 2 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L801AAAB8;
        }
        if (c.V1 == 0u) {
            { c.V0 = 0u | 0x000Cu;  }
            goto L801AAACC;
        }
        { c.V0 = 0u | 0x000Cu;  }
        goto L801AAB8C;
        L801AAAB8: ;
        { c.V0 = 0u | 0x0002u;  }
        if (c.V1 == c.V0) {
            goto L801AAB40;
        }
        goto L801AAB8C;
        L801AAACC: ;
        c.V1 = mem.ReadU16((c.S0 + 0x2Eu)); 
        mem.WriteU8((c.S0 + 0x19u), (byte)c.V0); 
        { c.V0 = 0u | 0x0060u;  }
        mem.WriteU8((c.S0 + 0x6Cu), (byte)c.V0); 
        mem.WriteU32((c.S0 + 0x8u), 0u); 
        mem.WriteU32((c.S0 + 0xCu), 0u); 
        { c.V1 = c.V1 + 0x1u;  }
        mem.WriteU16((c.S0 + 0x2Eu), (ushort)c.V1); 
        L801AAAEC: ;
        c.RA = 0x801AAAF4u; 
        SoTN_st0.MoveEntity_st0(c, m);
        c.V0 = mem.ReadU16((c.S0 + 0x1Eu)); 
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x8F8u;  }
        { c.V0 = c.V0 + 0x40u;  }
        mem.WriteU16((c.S0 + 0x1Eu), (ushort)c.V0); 
        c.RA = 0x801AAB0Cu; 
        SoTN_st0.UnkCollisionFunc3_st0(c, m);
        { c.V0 = c.V0 & 0x0001u;  }
        if (c.V0 == 0u) {
            goto L801AAB2C;
        }
        c.V0 = mem.ReadU16((c.S0 + 0x2Eu)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S0 + 0x2Eu), (ushort)c.V0); 
        goto L801AAB8C;
        L801AAB2C: ;
        c.V0 = mem.ReadU32((c.S0 + 0xCu)); 
        { c.V0 = c.V0 - 0x2000u;  }
        mem.WriteU32((c.S0 + 0xCu), c.V0); 
        goto L801AAB8C;
        L801AAB40: ;
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3824u)); 
        { c.A0 = 0u | 0x0652u;  }
        c.RA = 0x801AAB54u;
        Dispatcher.Call(c, m, c.V0);
        c.A0 = 0x80080000u; 
        { c.A0 = c.A0 - 0x27A8u;  }
        { c.A1 = c.A0 + 0x1780u;  }
        c.RA = 0x801AAB64u; 
        SoTN_st0.AllocEntity_st0(c, m);
        c.S1 = c.V0; 
        if (c.S1 == 0u) {
            { c.A0 = 0u | 0x0002u;  }
            goto L801AAB84;
        }
        { c.A0 = 0u | 0x0002u;  }
        c.A1 = c.S0; 
        c.A2 = c.S1; 
        c.RA = 0x801AAB7Cu; 
        SoTN_st0.CreateEntityFromEntity_st0(c, m);
        { c.V0 = 0u | 0x0011u;  }
        mem.WriteU16((c.S1 + 0x30u), (ushort)c.V0); 
        L801AAB84: ;
        c.A0 = c.S0; 
        c.RA = 0x801AAB8Cu; 
        SoTN_st0.DestroyEntity_st0(c, m);
        L801AAB8C: ;
        c.RA = mem.ReadU32((c.SP + 0x18u)); 
        c.S1 = mem.ReadU32((c.SP + 0x14u)); 
        c.S0 = mem.ReadU32((c.SP + 0x10u)); 
        { c.SP = c.SP + 0x20u;  }
        return;
        }
    public static bool func_801AF774(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("st0", m, false)) return true;
        func_801AF774_Body(c, m);
        return false;
    }
    private static void func_801AF774_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "st0", 0x801C24CCu);
        { c.SP = c.SP - 0x98u;  }
        mem.WriteU32((c.SP + 0x80u), c.S2); 
        c.S2 = c.A0; 
        mem.WriteU32((c.SP + 0x90u), c.RA); 
        mem.WriteU32((c.SP + 0x8Cu), c.S5); 
        mem.WriteU32((c.SP + 0x88u), c.S4); 
        mem.WriteU32((c.SP + 0x84u), c.S3); 
        mem.WriteU32((c.SP + 0x7Cu), c.S1); 
        mem.WriteU32((c.SP + 0x78u), c.S0); 
        c.V1 = mem.ReadU16((c.S2 + 0x2Cu)); 
        { c.V0 = c.V1 < 0x00000008u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.V0 = c.V1 << 2;  }
            goto L801B0008;
        }
        { c.V0 = c.V1 << 2;  }
        c.At = 0x801A0000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.V0 = mem.ReadU32((c.At + 0x7BFCu)); 
        switch (c.V0)
        {
            case 0x801AF7C4u: goto L801AF7C4;
            case 0x801AFA20u: goto L801AFA20;
            case 0x801AFB04u: goto L801AFB04;
            case 0x801AFC00u: goto L801AFC00;
            case 0x801AFF70u: goto L801AFF70;
            case 0x801AFFB4u: goto L801AFFB4;
            case 0x801AFFD0u: goto L801AFFD0;
            case 0x801AFFE4u: goto L801AFFE4;
            case 0x801B04A4u: goto L801B04A4;
            case 0x801B1008u: goto L801B1008;
            case 0x801B07DCu: goto L801B07DC;
            case 0x801B08A4u: goto L801B08A4;
            case 0x801B091Cu: goto L801B091C;
            case 0x801B0948u: goto L801B0948;
            case 0x801B096Cu: goto L801B096C;
            case 0x801B0AE0u: goto L801B0AE0;
            case 0x801B0BA4u: goto L801B0BA4;
            case 0x801B0C9Cu: goto L801B0C9C;
            case 0x801B0D14u: goto L801B0D14;
            case 0x801B0E28u: goto L801B0E28;
            case 0x801B0F18u: goto L801B0F18;
            case 0x801B0F60u: goto L801B0F60;
            default: Dispatcher.Call(c, m, c.V0); return;
        }
        L801AF7C4: ;
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x5E0u;  }
        c.RA = 0x801AF7D4u; 
        SoTN_st0.InitializeEntity_st0(c, m);
        c.A1 = 0xF7FF0000u; 
        { c.A1 = c.A1 | 0xFFFFu;  }
        c.V0 = mem.ReadU8((c.S2 + 0x18u)); 
        c.V1 = mem.ReadU32((c.S2 + 0x34u)); 
        { c.A0 = 0u | 0x0004u;  }
        mem.WriteU16((c.S2 + 0x3Cu), (ushort)0u); 
        mem.WriteU16((c.S2 + 0x56u), (ushort)0u); 
        { c.V0 = c.V0 | 0x0030u;  }
        { var _s = c.V1; var _t = c.A1; c.V1 = _s & _t;  }
        mem.WriteU8((c.S2 + 0x18u), (byte)c.V0); 
        { c.V0 = 0u | 0x0001u;  }
        c.At = 0x801C0000u; 
        mem.WriteU32((c.At + 0x2578u), c.V0); 
        { c.V0 = 0u | 0x0001u;  }
        mem.WriteU32((c.S2 + 0x34u), c.V1); 
        mem.WriteU8((c.S2 + 0x90u), (byte)c.V0); 
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3848u)); 
        { c.A1 = 0u | 0x005Cu;  }
        c.RA = 0x801AF828u;
        Dispatcher.Call(c, m, c.V0);
        { c.V0 = c.V0 << 16;  }
        { c.S0 = (uint)((int)c.V0 >> 16);  }
        c.V0 = 0xFFFFFFFFu; 
        if (c.S0 == c.V0) {
            { c.V0 = c.S0 << 1;  }
            goto L801AFA08;
        }
        { c.V0 = c.S0 << 1;  }
        { var _s = c.V0; var _t = c.S0; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.S0; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.V1 = 0x80080000u; 
        { c.V1 = c.V1 + 0x6FECu;  }
        { var _s = c.V0; var _t = c.V1; c.S1 = _s + _t;  }
        c.V0 = mem.ReadU32((c.S2 + 0x34u)); 
        c.V1 = 0x00800000u; 
        mem.WriteU32((c.S2 + 0x64u), c.S0); 
        mem.WriteU32((c.S2 + 0x84u), c.S1); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s | _t;  }
        mem.WriteU32((c.S2 + 0x34u), c.V0); 
        { c.V0 = 0u | 0x0110u;  }
        mem.WriteU16((c.S1 + 0x1Au), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S2 + 0x14u)); 
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x007Fu;  }
            goto L801AF8A0;
        }
        { c.V0 = 0u | 0x007Fu;  }
        { c.V0 = 0u | 0x0080u;  }
        mem.WriteU8((c.S1 + 0x24u), (byte)0u); 
        mem.WriteU8((c.S1 + 0xCu), (byte)0u); 
        mem.WriteU8((c.S1 + 0x30u), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0x18u), (byte)c.V0); 
        goto L801AF8B4;
        L801AF8A0: ;
        mem.WriteU8((c.S1 + 0x30u), (byte)0u); 
        mem.WriteU8((c.S1 + 0x18u), (byte)0u); 
        mem.WriteU8((c.S1 + 0x24u), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0xCu), (byte)c.V0); 
        { c.V0 = 0u | 0x0080u;  }
        L801AF8B4: ;
        mem.WriteU8((c.S1 + 0x19u), (byte)0u); 
        mem.WriteU8((c.S1 + 0xDu), (byte)0u); 
        mem.WriteU8((c.S1 + 0x31u), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0x25u), (byte)c.V0); 
        c.V0 = mem.ReadU16((c.S2 + 0x2u)); 
        { c.V0 = c.V0 - 0x40u;  }
        mem.WriteU16((c.S1 + 0x20u), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x8u), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S2 + 0x2u)); 
        { c.V0 = c.V0 + 0x40u;  }
        mem.WriteU16((c.S1 + 0x2Cu), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x14u), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S2 + 0x6u)); 
        { c.V0 = c.V0 - 0x25u;  }
        mem.WriteU16((c.S1 + 0x16u), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0xAu), (ushort)c.V0); 
        c.V1 = mem.ReadU16((c.S2 + 0x6u)); 
        { c.V0 = 0u | 0x0080u;  }
        mem.WriteU8((c.S1 + 0x6u), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0x5u), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0x4u), (byte)c.V0); 
        { c.V0 = 0u | 0x000Au;  }
        mem.WriteU16((c.S1 + 0x32u), (ushort)c.V0); 
        { c.V0 = 0u | 0x00A8u;  }
        mem.WriteU16((c.S1 + 0x26u), (ushort)c.V0); 
        c.V0 = mem.ReadU32((c.S1 + 0x4u)); 
        c.A0 = mem.ReadU32((c.S1 + 0x4u)); 
        c.A1 = mem.ReadU32((c.S1 + 0x4u)); 
        { c.V1 = c.V1 + 0x5Bu;  }
        mem.WriteU16((c.S1 + 0x2Eu), (ushort)c.V1); 
        mem.WriteU16((c.S1 + 0x22u), (ushort)c.V1); 
        mem.WriteU32((c.S1 + 0x10u), c.V0); 
        mem.WriteU32((c.S1 + 0x1Cu), c.A0); 
        mem.WriteU32((c.S1 + 0x28u), c.A1); 
        c.S1 = mem.ReadU32(c.S1); 
        c.S5 = 0x80040000u; 
        { c.S5 = c.S5 - 0x3804u;  }
        mem.WriteU32((c.S2 + 0x88u), c.S1); 
        c.V0 = mem.ReadU32(c.S5); 
        c.A0 = c.S1; 
        c.RA = 0x801AF968u;
        Dispatcher.Call(c, m, c.V0);
        if (c.V0 == 0u) {
            { c.S4 = 0u | 0x0007u;  }
            goto L801AF998;
        }
        { c.S4 = 0u | 0x0007u;  }
        { c.S3 = 0u | 0x0008u;  }
        mem.WriteU8((c.S1 + 0x7u), (byte)c.S4); 
        mem.WriteU16((c.S1 + 0x32u), (ushort)c.S3); 
        c.S1 = mem.ReadU32(c.S1); 
        c.V0 = mem.ReadU32(c.S5); 
        c.A0 = c.S1; 
        c.RA = 0x801AF990u;
        Dispatcher.Call(c, m, c.V0);
        if (c.S1 != 0u) {
            goto L801AF9C8;
        }
        L801AF998: ;
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x384Cu)); 
        c.A0 = c.S0; 
        c.RA = 0x801AF9ACu;
        Dispatcher.Call(c, m, c.V0);
        c.V1 = 0xFF7F0000u; 
        c.V0 = mem.ReadU32((c.S2 + 0x34u)); 
        { c.V1 = c.V1 | 0xFFFFu;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)0u); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s & _t;  }
        mem.WriteU32((c.S2 + 0x34u), c.V0); 
        goto L801B0008;
        L801AF9C8: ;
        mem.WriteU8((c.S1 + 0x7u), (byte)c.S4); 
        mem.WriteU16((c.S1 + 0x32u), (ushort)c.S3); 
        c.S1 = mem.ReadU32(c.S1); 
        if (c.S1 == 0u) {
            mem.WriteU32((c.S2 + 0x7Cu), c.S1); 
            goto L801AFA20;
        }
        mem.WriteU32((c.S2 + 0x7Cu), c.S1); 
        { c.V1 = 0u | 0x00A0u;  }
        { c.V0 = 0u | 0x0008u;  }
        L801AF9E8: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        mem.WriteU16((c.S1 + 0x26u), (ushort)c.V1); 
        mem.WriteU16((c.S1 + 0x32u), (ushort)c.V0); 
        c.S1 = mem.ReadU32(c.S1); 
        if (c.S1 != 0u) {
            { c.A3 = c.SP + 0x18u;  }
            goto L801AF9E8;
        }
        { c.A3 = c.SP + 0x18u;  }
        goto L801AFA24;
        L801AFA08: ;
        c.A0 = 0x801A0000u; 
        { c.A0 = c.A0 + 0x7BDCu;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)0u); 
        c.RA = 0x801AFA18u; 
        SoTN_main.FntPrint(c, m);
        goto L801B0008;
        L801AFA20: ;
        { c.A3 = c.SP + 0x18u;  }
        L801AFA24: ;
        c.V0 = 0x80070000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3C84u)); 
        c.S1 = mem.ReadU32((c.S2 + 0x88u)); 
        { c.A2 = c.V0 + 0x4u;  }
        { c.T0 = c.V0 + 0x54u;  }
        L801AFA38: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V0 = mem.ReadU32(c.A2); 
        c.V1 = mem.ReadU32((c.A2 + 0x4u)); 
        c.A0 = mem.ReadU32((c.A2 + 0x8u)); 
        c.A1 = mem.ReadU32((c.A2 + 0xCu)); 
        mem.WriteU32(c.A3, c.V0); 
        mem.WriteU32((c.A3 + 0x4u), c.V1); 
        mem.WriteU32((c.A3 + 0x8u), c.A0); 
        mem.WriteU32((c.A3 + 0xCu), c.A1); 
        { c.A2 = c.A2 + 0x10u;  }
        if (c.A2 != c.T0) {
            { c.A3 = c.A3 + 0x10u;  }
            goto L801AFA38;
        }
        { c.A3 = c.A3 + 0x10u;  }
        c.V0 = mem.ReadU32(c.A2); 
        c.V1 = mem.ReadU32((c.A2 + 0x4u)); 
        c.A0 = mem.ReadU32((c.A2 + 0x8u)); 
        mem.WriteU32(c.A3, c.V0); 
        mem.WriteU32((c.A3 + 0x4u), c.V1); 
        mem.WriteU32((c.A3 + 0x8u), c.A0); 
        { c.V0 = 0u | 0x0001u;  }
        { c.V1 = 0u | 0x0100u;  }
        mem.WriteU8((c.SP + 0x30u), (byte)c.V0); 
        { c.V0 = 0u | 0x007Fu;  }
        mem.WriteU16((c.SP + 0x14u), (ushort)c.V0); 
        { c.V0 = 0u | 0x00FFu;  }
        mem.WriteU8((c.SP + 0x31u), (byte)0u); 
        mem.WriteU8((c.SP + 0x32u), (byte)0u); 
        mem.WriteU8((c.SP + 0x33u), (byte)0u); 
        mem.WriteU16((c.SP + 0x10u), (ushort)0u); 
        mem.WriteU16((c.SP + 0x12u), (ushort)c.V1); 
        mem.WriteU16((c.SP + 0x16u), (ushort)c.V0); 
        c.V0 = mem.ReadWordLeft(c.V0, (c.SP + 0x13u)); 
        c.V0 = mem.ReadWordRight(c.V0, (c.SP + 0x10u)); 
        c.A0 = mem.ReadWordLeft(c.A0, (c.SP + 0x17u)); 
        c.A0 = mem.ReadWordRight(c.A0, (c.SP + 0x14u)); 
        mem.WriteWordLeft((c.SP + 0x1Bu), c.V0); 
        mem.WriteWordRight((c.SP + 0x18u), c.V0); 
        mem.WriteWordLeft((c.SP + 0x1Fu), c.A0); 
        mem.WriteWordRight((c.SP + 0x1Cu), c.A0); 
        mem.WriteU16((c.SP + 0x20u), (ushort)0u); 
        mem.WriteU16((c.SP + 0x22u), (ushort)c.V1); 
        c.A0 = mem.ReadU32((c.S1 + 0x10u)); 
        { c.A1 = c.SP + 0x18u;  }
        c.RA = 0x801AFAE0u; 
        SoTN_main.SetDrawEnv(c, m);
        { c.V0 = 0u | 0x009Fu;  }
        mem.WriteU16((c.S1 + 0x26u), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x32u), (ushort)0u); 
        c.S1 = mem.ReadU32(c.S1); 
        { c.V0 = 0u | 0x00A1u;  }
        mem.WriteU16((c.S1 + 0x26u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0800u;  }
        mem.WriteU16((c.S1 + 0x32u), (ushort)c.V0); 
        goto L801AFFD0;
        L801AFB04: ;
        c.RA = 0x801AFB0Cu; 
        SoTN_st0.func_801AF380(c, m);
        { c.A3 = c.SP + 0x18u;  }
        c.V0 = 0x80070000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3C84u)); 
        c.S1 = mem.ReadU32((c.S2 + 0x88u)); 
        { c.A2 = c.V0 + 0x4u;  }
        { c.T1 = c.V0 + 0x54u;  }
        c.T0 = mem.ReadU32((c.S1 + 0x10u)); 
        L801AFB28: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V0 = mem.ReadU32(c.A2); 
        c.V1 = mem.ReadU32((c.A2 + 0x4u)); 
        c.A0 = mem.ReadU32((c.A2 + 0x8u)); 
        c.A1 = mem.ReadU32((c.A2 + 0xCu)); 
        mem.WriteU32(c.A3, c.V0); 
        mem.WriteU32((c.A3 + 0x4u), c.V1); 
        mem.WriteU32((c.A3 + 0x8u), c.A0); 
        mem.WriteU32((c.A3 + 0xCu), c.A1); 
        { c.A2 = c.A2 + 0x10u;  }
        if (c.A2 != c.T1) {
            { c.A3 = c.A3 + 0x10u;  }
            goto L801AFB28;
        }
        { c.A3 = c.A3 + 0x10u;  }
        c.V0 = mem.ReadU32(c.A2); 
        c.V1 = mem.ReadU32((c.A2 + 0x4u)); 
        c.A0 = mem.ReadU32((c.A2 + 0x8u)); 
        mem.WriteU32(c.A3, c.V0); 
        mem.WriteU32((c.A3 + 0x4u), c.V1); 
        mem.WriteU32((c.A3 + 0x8u), c.A0); 
        { c.V0 = 0u | 0x0100u;  }
        { c.S0 = 0u | 0x0080u;  }
        mem.WriteU8((c.SP + 0x30u), (byte)0u); 
        mem.WriteU8((c.SP + 0x2Eu), (byte)0u); 
        mem.WriteU16((c.SP + 0x10u), (ushort)0u); 
        mem.WriteU16((c.SP + 0x12u), (ushort)c.V0); 
        mem.WriteU16((c.SP + 0x14u), (ushort)c.S0); 
        mem.WriteU16((c.SP + 0x16u), (ushort)c.S0); 
        c.V1 = mem.ReadWordLeft(c.V1, (c.SP + 0x13u)); 
        c.V1 = mem.ReadWordRight(c.V1, (c.SP + 0x10u)); 
        c.A0 = mem.ReadWordLeft(c.A0, (c.SP + 0x17u)); 
        c.A0 = mem.ReadWordRight(c.A0, (c.SP + 0x14u)); 
        mem.WriteWordLeft((c.SP + 0x1Bu), c.V1); 
        mem.WriteWordRight((c.SP + 0x18u), c.V1); 
        mem.WriteWordLeft((c.SP + 0x1Fu), c.A0); 
        mem.WriteWordRight((c.SP + 0x1Cu), c.A0); 
        c.A0 = c.T0; 
        { c.A1 = c.SP + 0x18u;  }
        mem.WriteU16((c.SP + 0x20u), (ushort)0u); 
        mem.WriteU16((c.SP + 0x22u), (ushort)c.V0); 
        c.RA = 0x801AFBC0u; 
        SoTN_main.SetDrawEnv(c, m);
        { c.V0 = 0u | 0x009Fu;  }
        mem.WriteU16((c.S1 + 0x26u), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x32u), (ushort)0u); 
        c.S1 = mem.ReadU32(c.S1); 
        { c.V0 = 0u | 0x00A1u;  }
        mem.WriteU16((c.S1 + 0x26u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0800u;  }
        mem.WriteU16((c.S1 + 0x32u), (ushort)c.V0); 
        c.V1 = mem.ReadU16((c.S2 + 0x2Cu)); 
        c.V0 = 0xFFFF8000u; 
        mem.WriteU16((c.S2 + 0x8Eu), (ushort)c.S0); 
        mem.WriteU16((c.S2 + 0x8Cu), (ushort)c.V0); 
        mem.WriteU16((c.S2 + 0x2Eu), (ushort)0u); 
        { c.V1 = c.V1 + 0x1u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V1); 
        goto L801B0008;
        L801AFC00: ;
        c.S1 = mem.ReadU32((c.S2 + 0x84u)); 
        { c.V0 = 0u | 0x0037u;  }
        mem.WriteU16((c.S1 + 0x32u), (ushort)c.V0); 
        c.V0 = (uint)(short)mem.ReadU16((c.S2 + 0x8Eu)); 
        if ((int)c.V0 <= 0) {
            goto L801AFC24;
        }
        c.RA = 0x801AFC24u; 
        SoTN_st0.func_801AF6D0(c, m);
        L801AFC24: ;
        c.V0 = mem.ReadU16((c.S2 + 0x8Cu)); 
        { c.T0 = c.V0 >> 8;  }
        { c.V0 = c.T0 < 0x00000081u ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.T2 = 0u | 0x0040u;  }
            goto L801AFC40;
        }
        { c.T2 = 0u | 0x0040u;  }
        { c.T0 = 0u | 0x0080u;  }
        L801AFC40: ;
        { c.V0 = c.T0 & 0x00FFu;  }
        { c.T0 = c.V0 >> 3;  }
        c.S1 = mem.ReadU32((c.S2 + 0x7Cu)); 
        { c.T1 = 0u | 0x0070u;  }
        c.A3 = 0x801C0000u; 
        { c.A3 = c.A3 - 0x149Cu;  }
        c.A2 = 0x80180000u; 
        { c.A2 = c.A2 + 0x13E8u;  }
        c.T3 = 0u; 
        L801AFC64: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V0 = mem.ReadU8(c.A2); 
        { c.V0 = c.V0 << 3;  }
        { var _s = c.V0; var _t = c.A3; c.V0 = _s + _t;  }
        c.V0 = (uint)(short)mem.ReadU16((c.V0 + 0x2u)); 
        { var _s = c.T2; var _t = c.V0; c.V0 = _s + _t;  }
        mem.WriteU16((c.S1 + 0x8u), (ushort)c.V0); 
        c.V0 = mem.ReadU8(c.A2); 
        { c.V0 = c.V0 << 3;  }
        { var _s = c.V0; var _t = c.A3; c.V0 = _s + _t;  }
        c.V0 = (uint)(short)mem.ReadU16((c.V0 + 0x6u)); 
        { c.A2 = c.A2 + 0x1u;  }
        { var _s = c.T1; var _t = c.V0; c.V0 = _s + _t;  }
        mem.WriteU16((c.S1 + 0xAu), (ushort)c.V0); 
        c.V0 = mem.ReadU8(c.A2); 
        { c.V0 = c.V0 << 3;  }
        { var _s = c.V0; var _t = c.A3; c.V0 = _s + _t;  }
        c.V0 = (uint)(short)mem.ReadU16((c.V0 + 0x2u)); 
        { var _s = c.T2; var _t = c.V0; c.V0 = _s + _t;  }
        mem.WriteU16((c.S1 + 0x14u), (ushort)c.V0); 
        c.V0 = mem.ReadU8(c.A2); 
        { c.V0 = c.V0 << 3;  }
        { var _s = c.V0; var _t = c.A3; c.V0 = _s + _t;  }
        c.V0 = (uint)(short)mem.ReadU16((c.V0 + 0x6u)); 
        { c.A2 = c.A2 + 0x1u;  }
        { var _s = c.T1; var _t = c.V0; c.V0 = _s + _t;  }
        mem.WriteU16((c.S1 + 0x16u), (ushort)c.V0); 
        c.V0 = mem.ReadU8(c.A2); 
        { c.V0 = c.V0 << 3;  }
        { var _s = c.V0; var _t = c.A3; c.V0 = _s + _t;  }
        c.V0 = (uint)(short)mem.ReadU16((c.V0 + 0x2u)); 
        { var _s = c.T2; var _t = c.V0; c.V0 = _s + _t;  }
        mem.WriteU16((c.S1 + 0x20u), (ushort)c.V0); 
        c.V0 = mem.ReadU8(c.A2); 
        { c.V0 = c.V0 << 3;  }
        { var _s = c.V0; var _t = c.A3; c.V0 = _s + _t;  }
        c.V0 = (uint)(short)mem.ReadU16((c.V0 + 0x6u)); 
        { c.A2 = c.A2 + 0x1u;  }
        { var _s = c.T1; var _t = c.V0; c.V0 = _s + _t;  }
        mem.WriteU16((c.S1 + 0x22u), (ushort)c.V0); 
        c.V0 = mem.ReadU8(c.A2); 
        { c.V0 = c.V0 << 3;  }
        { var _s = c.V0; var _t = c.A3; c.V0 = _s + _t;  }
        c.V0 = (uint)(short)mem.ReadU16((c.V0 + 0x2u)); 
        { var _s = c.T2; var _t = c.V0; c.V0 = _s + _t;  }
        mem.WriteU16((c.S1 + 0x2Cu), (ushort)c.V0); 
        c.V0 = mem.ReadU8(c.A2); 
        { c.T3 = c.T3 + 0x1u;  }
        { c.V0 = c.V0 << 3;  }
        { var _s = c.V0; var _t = c.A3; c.V0 = _s + _t;  }
        c.V0 = (uint)(short)mem.ReadU16((c.V0 + 0x6u)); 
        mem.WriteU8((c.S1 + 0x6u), (byte)c.T0); 
        mem.WriteU8((c.S1 + 0x5u), (byte)c.T0); 
        mem.WriteU8((c.S1 + 0x4u), (byte)c.T0); 
        c.V1 = mem.ReadU32((c.S1 + 0x4u)); 
        c.A0 = mem.ReadU32((c.S1 + 0x4u)); 
        c.A1 = mem.ReadU32((c.S1 + 0x4u)); 
        { var _s = c.T1; var _t = c.V0; c.V0 = _s + _t;  }
        mem.WriteU16((c.S1 + 0x2Eu), (ushort)c.V0); 
        { c.V0 = (int)c.T3 < 47 ? 1u : 0u;  }
        mem.WriteU32((c.S1 + 0x10u), c.V1); 
        mem.WriteU32((c.S1 + 0x1Cu), c.A0); 
        mem.WriteU32((c.S1 + 0x28u), c.A1); 
        c.S1 = mem.ReadU32(c.S1); 
        if (c.V0 != 0u) {
            { c.A2 = c.A2 + 0x1u;  }
            goto L801AFC64;
        }
        { c.A2 = c.A2 + 0x1u;  }
        c.V0 = mem.ReadU16((c.S2 + 0x8Cu)); 
        { c.T0 = c.V0 >> 8;  }
        { c.V0 = c.T0 < 0x00000081u ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.T2 = 0u | 0x0040u;  }
            goto L801AFDB0;
        }
        { c.T2 = 0u | 0x0040u;  }
        { c.T0 = 0u | 0x0080u;  }
        L801AFDB0: ;
        { c.V0 = 0u | 0x0080u;  }
        { var _s = c.V0; var _t = c.T0; c.T0 = _s - _t;  }
        { c.V0 = c.T0 & 0x00FFu;  }
        { c.T0 = c.V0 >> 3;  }
        c.S1 = mem.ReadU32((c.S2 + 0x80u)); 
        c.A3 = 0x801C0000u; 
        { c.A3 = c.A3 - 0x149Cu;  }
        c.A2 = 0x80180000u; 
        { c.A2 = c.A2 + 0x14A8u;  }
        { c.T1 = 0u | 0x0070u;  }
        c.T3 = 0u; 
        L801AFDDC: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V0 = mem.ReadU8(c.A2); 
        { c.V0 = c.V0 << 3;  }
        { var _s = c.V0; var _t = c.A3; c.V0 = _s + _t;  }
        c.V0 = (uint)(short)mem.ReadU16((c.V0 + 0x2u)); 
        { var _s = c.T2; var _t = c.V0; c.V0 = _s + _t;  }
        mem.WriteU16((c.S1 + 0x8u), (ushort)c.V0); 
        c.V0 = mem.ReadU8(c.A2); 
        { c.V0 = c.V0 << 3;  }
        { var _s = c.V0; var _t = c.A3; c.V0 = _s + _t;  }
        c.V0 = (uint)(short)mem.ReadU16((c.V0 + 0x6u)); 
        { c.A2 = c.A2 + 0x1u;  }
        { var _s = c.T1; var _t = c.V0; c.V0 = _s + _t;  }
        mem.WriteU16((c.S1 + 0xAu), (ushort)c.V0); 
        c.V0 = mem.ReadU8(c.A2); 
        { c.V0 = c.V0 << 3;  }
        { var _s = c.V0; var _t = c.A3; c.V0 = _s + _t;  }
        c.V0 = (uint)(short)mem.ReadU16((c.V0 + 0x2u)); 
        { var _s = c.T2; var _t = c.V0; c.V0 = _s + _t;  }
        mem.WriteU16((c.S1 + 0x14u), (ushort)c.V0); 
        c.V0 = mem.ReadU8(c.A2); 
        { c.V0 = c.V0 << 3;  }
        { var _s = c.V0; var _t = c.A3; c.V0 = _s + _t;  }
        c.V0 = (uint)(short)mem.ReadU16((c.V0 + 0x6u)); 
        { c.A2 = c.A2 + 0x1u;  }
        { var _s = c.T1; var _t = c.V0; c.V0 = _s + _t;  }
        mem.WriteU16((c.S1 + 0x16u), (ushort)c.V0); 
        c.V0 = mem.ReadU8(c.A2); 
        { c.V0 = c.V0 << 3;  }
        { var _s = c.V0; var _t = c.A3; c.V0 = _s + _t;  }
        c.V0 = (uint)(short)mem.ReadU16((c.V0 + 0x2u)); 
        { var _s = c.T2; var _t = c.V0; c.V0 = _s + _t;  }
        mem.WriteU16((c.S1 + 0x20u), (ushort)c.V0); 
        c.V0 = mem.ReadU8(c.A2); 
        { c.V0 = c.V0 << 3;  }
        { var _s = c.V0; var _t = c.A3; c.V0 = _s + _t;  }
        c.V0 = (uint)(short)mem.ReadU16((c.V0 + 0x6u)); 
        { c.A2 = c.A2 + 0x1u;  }
        { var _s = c.T1; var _t = c.V0; c.V0 = _s + _t;  }
        mem.WriteU16((c.S1 + 0x22u), (ushort)c.V0); 
        c.V0 = mem.ReadU8(c.A2); 
        { c.V0 = c.V0 << 3;  }
        { var _s = c.V0; var _t = c.A3; c.V0 = _s + _t;  }
        c.V0 = (uint)(short)mem.ReadU16((c.V0 + 0x2u)); 
        { var _s = c.T2; var _t = c.V0; c.V0 = _s + _t;  }
        mem.WriteU16((c.S1 + 0x2Cu), (ushort)c.V0); 
        c.V0 = mem.ReadU8(c.A2); 
        { c.T3 = c.T3 + 0x1u;  }
        { c.V0 = c.V0 << 3;  }
        { var _s = c.V0; var _t = c.A3; c.V0 = _s + _t;  }
        c.V0 = (uint)(short)mem.ReadU16((c.V0 + 0x6u)); 
        mem.WriteU8((c.S1 + 0x6u), (byte)c.T0); 
        mem.WriteU8((c.S1 + 0x5u), (byte)c.T0); 
        mem.WriteU8((c.S1 + 0x4u), (byte)c.T0); 
        c.V1 = mem.ReadU32((c.S1 + 0x4u)); 
        c.A0 = mem.ReadU32((c.S1 + 0x4u)); 
        c.A1 = mem.ReadU32((c.S1 + 0x4u)); 
        { var _s = c.T1; var _t = c.V0; c.V0 = _s + _t;  }
        mem.WriteU16((c.S1 + 0x2Eu), (ushort)c.V0); 
        { c.V0 = (int)c.T3 < 42 ? 1u : 0u;  }
        mem.WriteU32((c.S1 + 0x10u), c.V1); 
        mem.WriteU32((c.S1 + 0x1Cu), c.A0); 
        mem.WriteU32((c.S1 + 0x28u), c.A1); 
        c.S1 = mem.ReadU32(c.S1); 
        if (c.V0 != 0u) {
            { c.A2 = c.A2 + 0x1u;  }
            goto L801AFDDC;
        }
        { c.A2 = c.A2 + 0x1u;  }
        c.V0 = mem.ReadU16((c.S2 + 0x8Eu)); 
        { c.V0 = c.V0 - 0x1u;  }
        mem.WriteU16((c.S2 + 0x8Eu), (ushort)c.V0); 
        { c.V0 = c.V0 << 16;  }
        c.V1 = (uint)(short)mem.ReadU16((c.S2 + 0x8Eu)); 
        { c.V0 = (uint)((int)c.V0 >> 8);  }
        if ((int)c.V1 >= 0) {
            mem.WriteU16((c.S2 + 0x8Cu), (ushort)c.V0); 
            goto L801AFF38;
        }
        mem.WriteU16((c.S2 + 0x8Cu), (ushort)c.V0); 
        { c.V0 = 0u | 0x0004u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        L801AFF38: ;
        c.V0 = mem.ReadU8((c.S2 + 0x90u)); 
        if (c.V0 == 0u) {
            goto L801B0008;
        }
        c.V0 = (uint)(short)mem.ReadU16((c.S2 + 0x8Eu)); 
        { c.V0 = (int)c.V0 < 16 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.A0 = 0u | 0x0023u;  }
            goto L801B0008;
        }
        { c.A0 = 0u | 0x0023u;  }
        mem.WriteU8((c.S2 + 0x90u), (byte)0u); 
        { c.A1 = c.S2 + 0xBCu;  }
        c.RA = 0x801AFF68u; 
        SoTN_st0.CreateEntityFromCurrentEntity_st0(c, m);
        goto L801B0008;
        L801AFF70: ;
        c.S1 = mem.ReadU32((c.S2 + 0x84u)); 
        { c.V0 = 0u | 0x0037u;  }
        mem.WriteU16((c.S1 + 0x32u), (ushort)c.V0); 
        c.S1 = mem.ReadU32(c.S1); 
        c.At = 0x801C0000u; 
        mem.WriteU32((c.At + 0x2578u), 0u); 
        if (c.S1 == 0u) {
            { c.V0 = 0u | 0x0008u;  }
            goto L801AFFA4;
        }
        { c.V0 = 0u | 0x0008u;  }
        L801AFF90: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        mem.WriteU16((c.S1 + 0x32u), (ushort)c.V0); 
        c.S1 = mem.ReadU32(c.S1); 
        if (c.S1 != 0u) {
            goto L801AFF90;
        }
        L801AFFA4: ;
        c.V0 = mem.ReadU16((c.S2 + 0x2Cu)); 
        { c.V1 = 0u | 0x0010u;  }
        mem.WriteU16((c.S2 + 0x8Eu), (ushort)c.V1); 
        goto L801AFFD4;
        L801AFFB4: ;
        c.V0 = mem.ReadU16((c.S2 + 0x8Eu)); 
        { c.V0 = c.V0 - 0x1u;  }
        mem.WriteU16((c.S2 + 0x8Eu), (ushort)c.V0); 
        { c.V0 = c.V0 << 16;  }
        if (c.V0 != 0u) {
            goto L801B0008;
        }
        L801AFFD0: ;
        c.V0 = mem.ReadU16((c.S2 + 0x2Cu)); 
        L801AFFD4: ;
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        goto L801B0008;
        L801AFFE4: ;
        c.A0 = mem.ReadU32((c.S2 + 0x84u)); 
        { c.A1 = 0u | 0x0007u;  }
        c.RA = 0x801AFFF0u; 
        SoTN_st0.PrimDecreaseBrightness_st0(c, m);
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x0001u;  }
            goto L801B0008;
        }
        { c.V0 = 0u | 0x0001u;  }
        c.At = 0x80180000u; 
        mem.WriteU32((c.At + 0x910u), c.V0); 
        c.A0 = c.S2; 
        c.RA = 0x801B0008u; 
        SoTN_st0.DestroyEntity_st0(c, m);
        L801B0008: ;
        c.RA = mem.ReadU32((c.SP + 0x90u)); 
        c.S5 = mem.ReadU32((c.SP + 0x8Cu)); 
        c.S4 = mem.ReadU32((c.SP + 0x88u)); 
        c.S3 = mem.ReadU32((c.SP + 0x84u)); 
        c.S2 = mem.ReadU32((c.SP + 0x80u)); 
        c.S1 = mem.ReadU32((c.SP + 0x7Cu)); 
        c.S0 = mem.ReadU32((c.SP + 0x78u)); 
        { c.SP = c.SP + 0x98u;  }
        return;
        c.At = 0x80040000u; 
        mem.WriteU32((c.At - 0x38CCu), c.A0); 
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x3060u), 0u); 
        c.At = 0x80070000u; 
        mem.WriteU32((c.At - 0x3C64u), 0u); 
        c.At = 0x80070000u; 
        mem.WriteU32((c.At - 0x3C60u), 0u); 
        return;
        { c.SP = c.SP - 0x28u;  }
        mem.WriteU32((c.SP + 0x1Cu), c.S3); 
        c.S3 = 0u; 
        mem.WriteU32((c.SP + 0x18u), c.S2); 
        { c.S2 = 0u | 0x00F0u;  }
        mem.WriteU32((c.SP + 0x20u), c.S4); 
        c.S4 = 0x80040000u; 
        { c.S4 = c.S4 - 0x3EFCu;  }
        mem.WriteU32((c.SP + 0x24u), c.RA); 
        mem.WriteU32((c.SP + 0x14u), c.S1); 
        mem.WriteU32((c.SP + 0x10u), c.S0); 
        { c.S0 = 0u | 0x0200u;  }
        L801B0088: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        { c.V0 = c.S3 << 1;  }
        { var _s = c.V0; var _t = c.S4; c.S1 = _s + _t;  }
        L801B0090: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.A0 = c.S0; 
        c.A1 = c.S2; 
        c.RA = 0x801B009Cu; 
        SoTN_main.GetClut(c, m);
        mem.WriteU16(c.S1, (ushort)c.V0); 
        { c.S1 = c.S1 + 0x2u;  }
        { c.S0 = c.S0 + 0x10u;  }
        { c.V0 = (int)c.S0 < 768 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.S3 = c.S3 + 0x1u;  }
            goto L801B0090;
        }
        { c.S3 = c.S3 + 0x1u;  }
        { c.S2 = c.S2 + 0x1u;  }
        { c.V0 = (int)c.S2 < 256 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.S0 = 0u | 0x0200u;  }
            goto L801B0088;
        }
        { c.S0 = 0u | 0x0200u;  }
        { c.S2 = 0u | 0x00F0u;  }
        c.S4 = 0x80040000u; 
        { c.S4 = c.S4 - 0x3EFCu;  }
        c.S0 = 0u; 
        L801B00D4: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        { c.V0 = c.S3 << 1;  }
        { var _s = c.V0; var _t = c.S4; c.S1 = _s + _t;  }
        L801B00DC: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.A0 = c.S0; 
        c.A1 = c.S2; 
        c.RA = 0x801B00E8u; 
        SoTN_main.GetClut(c, m);
        mem.WriteU16(c.S1, (ushort)c.V0); 
        { c.S1 = c.S1 + 0x2u;  }
        { c.S0 = c.S0 + 0x10u;  }
        { c.V0 = (int)c.S0 < 256 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.S3 = c.S3 + 0x1u;  }
            goto L801B00DC;
        }
        { c.S3 = c.S3 + 0x1u;  }
        { c.S2 = c.S2 + 0x1u;  }
        { c.V0 = (int)c.S2 < 256 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            c.S0 = 0u; 
            goto L801B00D4;
        }
        c.S0 = 0u; 
        { c.S2 = 0u | 0x00F0u;  }
        c.S4 = 0x80040000u; 
        { c.S4 = c.S4 - 0x3EFCu;  }
        { c.S0 = 0u | 0x0100u;  }
        L801B0120: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        { c.V0 = c.S3 << 1;  }
        { var _s = c.V0; var _t = c.S4; c.S1 = _s + _t;  }
        L801B0128: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.A0 = c.S0; 
        c.A1 = c.S2; 
        c.RA = 0x801B0134u; 
        SoTN_main.GetClut(c, m);
        mem.WriteU16(c.S1, (ushort)c.V0); 
        { c.S1 = c.S1 + 0x2u;  }
        { c.S0 = c.S0 + 0x10u;  }
        { c.V0 = (int)c.S0 < 512 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.S3 = c.S3 + 0x1u;  }
            goto L801B0128;
        }
        { c.S3 = c.S3 + 0x1u;  }
        { c.S2 = c.S2 + 0x1u;  }
        { c.V0 = (int)c.S2 < 256 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.S0 = 0u | 0x0100u;  }
            goto L801B0120;
        }
        { c.S0 = 0u | 0x0100u;  }
        c.RA = mem.ReadU32((c.SP + 0x24u)); 
        c.S4 = mem.ReadU32((c.SP + 0x20u)); 
        c.S3 = mem.ReadU32((c.SP + 0x1Cu)); 
        c.S2 = mem.ReadU32((c.SP + 0x18u)); 
        c.S1 = mem.ReadU32((c.SP + 0x14u)); 
        c.S0 = mem.ReadU32((c.SP + 0x10u)); 
        { c.SP = c.SP + 0x28u;  }
        return;
        { c.SP = c.SP - 0x20u;  }
        { c.V0 = 0u | 0x0200u;  }
        { c.A0 = c.SP + 0x10u;  }
        c.A1 = 0u; 
        c.A2 = 0u; 
        c.A3 = 0u; 
        mem.WriteU32((c.SP + 0x18u), c.RA); 
        mem.WriteU16((c.SP + 0x10u), (ushort)0u); 
        mem.WriteU16((c.SP + 0x12u), (ushort)0u); 
        mem.WriteU16((c.SP + 0x14u), (ushort)c.V0); 
        mem.WriteU16((c.SP + 0x16u), (ushort)c.V0); 
        c.RA = 0x801B01B0u; 
        DialogueGlyphs.Clear(c, mem);
        c.RA = mem.ReadU32((c.SP + 0x18u)); 
        { c.SP = c.SP + 0x20u;  }
        return;
        c.At = 0x80040000u; 
        mem.WriteU8((c.At - 0x34DBu), (byte)0u); 
        c.At = 0x80040000u; 
        mem.WriteU8((c.At - 0x34DAu), (byte)0u); 
        c.At = 0x80040000u; 
        mem.WriteU8((c.At - 0x34D9u), (byte)0u); 
        c.At = 0x80050000u; 
        mem.WriteU8((c.At + 0x4319u), (byte)0u); 
        c.At = 0x80050000u; 
        mem.WriteU8((c.At + 0x431Au), (byte)0u); 
        c.At = 0x80050000u; 
        mem.WriteU8((c.At + 0x431Bu), (byte)0u); 
        return;
        { c.SP = c.SP - 0x18u;  }
        { c.V1 = 0u | 0x0014u;  }
        { c.V0 = 0u | 0x00CFu;  }
        mem.WriteU32((c.SP + 0x10u), c.RA); 
        c.At = 0x80040000u; 
        mem.WriteU16((c.At - 0x34F2u), (ushort)c.V1); 
        c.At = 0x80040000u; 
        mem.WriteU16((c.At - 0x34EEu), (ushort)c.V0); 
        if (c.A0 != 0u) {
            { c.V0 = 0u | 0x0114u;  }
            goto L801B0230;
        }
        { c.V0 = 0u | 0x0114u;  }
        c.At = 0x80050000u; 
        mem.WriteU16((c.At + 0x4302u), (ushort)c.V1); 
        { c.V0 = 0u | 0x00CFu;  }
        goto L801B023C;
        L801B0230: ;
        c.At = 0x80050000u; 
        mem.WriteU16((c.At + 0x4302u), (ushort)c.V0); 
        { c.V0 = 0u | 0x00CFu;  }
        L801B023C: ;
        c.At = 0x80050000u; 
        mem.WriteU16((c.At + 0x4306u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0001u;  }
        c.At = 0x80050000u; 
        mem.WriteU8((c.At + 0x4318u), (byte)c.V0); 
        c.At = 0x80040000u; 
        mem.WriteU8((c.At - 0x34DCu), (byte)c.V0); 
        c.RA = 0x801B0260u; 
        SoTN_st0.SetDisplayBufferColorsToBlack_st0(c, m);
        c.At = 0x80050000u; 
        mem.WriteU8((c.At + 0x436Du), (byte)0u); 
        c.At = 0x80040000u; 
        mem.WriteU8((c.At - 0x3487u), (byte)0u); 
        c.RA = mem.ReadU32((c.SP + 0x10u)); 
        { c.SP = c.SP + 0x18u;  }
        return;
        { c.SP = c.SP - 0x28u;  }
        mem.WriteU32((c.SP + 0x1Cu), c.S1); 
        c.S1 = 0x80040000u; 
        { c.S1 = c.S1 - 0x34F4u;  }
        c.A0 = c.S1; 
        c.A1 = 0u; 
        c.A2 = 0u; 
        { c.A3 = 0u | 0x0100u;  }
        mem.WriteU32((c.SP + 0x18u), c.S0); 
        { c.S0 = 0u | 0x00F0u;  }
        mem.WriteU32((c.SP + 0x20u), c.RA); 
        mem.WriteU32((c.SP + 0x10u), c.S0); 
        c.RA = 0x801B02B4u; 
        SoTN_main.SetDefDrawEnv(c, m);
        c.A0 = 0x80050000u; 
        { c.A0 = c.A0 + 0x4300u;  }
        { c.A1 = 0u | 0x0100u;  }
        c.A2 = 0u; 
        { c.A3 = 0u | 0x0100u;  }
        mem.WriteU32((c.SP + 0x10u), c.S0); 
        c.RA = 0x801B02D0u; 
        SoTN_main.SetDefDrawEnv(c, m);
        { c.A0 = c.S1 + 0x5Cu;  }
        { c.A1 = 0u | 0x0100u;  }
        c.A2 = 0u; 
        { c.A3 = 0u | 0x0100u;  }
        mem.WriteU32((c.SP + 0x10u), c.S0); 
        c.RA = 0x801B02E8u; 
        SoTN_main.SetDefDispEnv(c, m);
        c.A0 = 0x80050000u; 
        { c.A0 = c.A0 + 0x435Cu;  }
        c.A1 = 0u; 
        c.A2 = 0u; 
        { c.A3 = 0u | 0x0100u;  }
        mem.WriteU32((c.SP + 0x10u), c.S0); 
        c.RA = 0x801B0304u; 
        SoTN_main.SetDefDispEnv(c, m);
        c.A0 = 0u; 
        c.RA = 0x801B030Cu; 
        SoTN_st0.SetStageCinematicBorders(c, m);
        c.RA = mem.ReadU32((c.SP + 0x20u)); 
        c.S1 = mem.ReadU32((c.SP + 0x1Cu)); 
        c.S0 = mem.ReadU32((c.SP + 0x18u)); 
        { c.SP = c.SP + 0x28u;  }
        return;
        { c.SP = c.SP - 0x28u;  }
        mem.WriteU32((c.SP + 0x1Cu), c.S1); 
        c.S1 = 0x80040000u; 
        { c.S1 = c.S1 - 0x34F4u;  }
        c.A0 = c.S1; 
        c.A1 = 0u; 
        c.A2 = 0u; 
        { c.A3 = 0u | 0x0200u;  }
        mem.WriteU32((c.SP + 0x18u), c.S0); 
        { c.S0 = 0u | 0x00F0u;  }
        mem.WriteU32((c.SP + 0x20u), c.RA); 
        mem.WriteU32((c.SP + 0x10u), c.S0); 
        c.RA = 0x801B0358u; 
        SoTN_main.SetDefDrawEnv(c, m);
        c.A0 = 0x80050000u; 
        { c.A0 = c.A0 + 0x4300u;  }
        c.A1 = 0u; 
        { c.A2 = 0u | 0x0100u;  }
        { c.A3 = 0u | 0x0200u;  }
        mem.WriteU32((c.SP + 0x10u), c.S0); 
        c.RA = 0x801B0374u; 
        SoTN_main.SetDefDrawEnv(c, m);
        { c.A0 = c.S1 + 0x5Cu;  }
        c.A1 = 0u; 
        { c.A2 = 0u | 0x0100u;  }
        { c.A3 = 0u | 0x0200u;  }
        mem.WriteU32((c.SP + 0x10u), c.S0); 
        c.RA = 0x801B038Cu; 
        SoTN_main.SetDefDispEnv(c, m);
        c.A0 = 0x80050000u; 
        { c.A0 = c.A0 + 0x435Cu;  }
        c.A1 = 0u; 
        c.A2 = 0u; 
        { c.A3 = 0u | 0x0200u;  }
        mem.WriteU32((c.SP + 0x10u), c.S0); 
        c.RA = 0x801B03A8u; 
        SoTN_main.SetDefDispEnv(c, m);
        { c.V0 = 0u | 0x0100u;  }
        c.At = 0x80050000u; 
        mem.WriteU16((c.At + 0x4302u), (ushort)c.V0); 
        { c.V0 = 0u | 0x00F0u;  }
        c.At = 0x80050000u; 
        mem.WriteU16((c.At + 0x4306u), (ushort)c.V0); 
        c.At = 0x80040000u; 
        mem.WriteU16((c.At - 0x34EEu), (ushort)c.V0); 
        { c.V0 = 0u | 0x0001u;  }
        c.At = 0x80040000u; 
        mem.WriteU16((c.At - 0x34F2u), (ushort)0u); 
        c.At = 0x80050000u; 
        mem.WriteU8((c.At + 0x4318u), (byte)c.V0); 
        c.At = 0x80040000u; 
        mem.WriteU8((c.At - 0x34DCu), (byte)c.V0); 
        c.RA = 0x801B03ECu; 
        SoTN_st0.SetDisplayBufferColorsToBlack_st0(c, m);
        c.At = 0x80050000u; 
        mem.WriteU8((c.At + 0x436Du), (byte)0u); 
        c.At = 0x80040000u; 
        mem.WriteU8((c.At - 0x3487u), (byte)0u); 
        c.RA = mem.ReadU32((c.SP + 0x20u)); 
        c.S1 = mem.ReadU32((c.SP + 0x1Cu)); 
        c.S0 = mem.ReadU32((c.SP + 0x18u)); 
        { c.SP = c.SP + 0x28u;  }
        return;
        c.V0 = 0x80090000u; 
        c.V0 = mem.ReadU16((c.V0 + 0x7494u)); 
        { c.V0 = c.V0 & 0x0800u;  }
        if (c.V0 == 0u) {
            c.V0 = 0u; 
            goto L801B045C;
        }
        c.V0 = 0u; 
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x34FCu)); 
        { c.V0 = c.V0 & 0x0002u;  }
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x0001u;  }
            goto L801B045C;
        }
        { c.V0 = 0u | 0x0001u;  }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x4220u)); 
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x0001u;  }
            goto L801B045C;
        }
        { c.V0 = 0u | 0x0001u;  }
        c.V0 = 0u; 
        L801B045C: ;
        return;
        c.V1 = 0x80070000u; 
        c.V1 = mem.ReadU32((c.V1 + 0x3060u)); 
        { c.SP = c.SP - 0x18u;  }
        mem.WriteU32((c.SP + 0x10u), c.S0); 
        c.S0 = 0x80070000u; 
        { c.S0 = c.S0 + 0x62D8u;  }
        { c.V0 = c.V1 < 0x00000014u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            mem.WriteU32((c.SP + 0x14u), c.RA); 
            goto L801B1008;
        }
        mem.WriteU32((c.SP + 0x14u), c.RA); 
        { c.V0 = c.V1 << 2;  }
        c.At = 0x801A0000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.V0 = mem.ReadU32((c.At + 0x7C1Cu)); 
        switch (c.V0)
        {
            case 0x801B04A4u: goto L801B04A4;
            case 0x801B1008u: goto L801B1008;
            case 0x801B07DCu: goto L801B07DC;
            case 0x801B08A4u: goto L801B08A4;
            case 0x801B091Cu: goto L801B091C;
            case 0x801B0948u: goto L801B0948;
            case 0x801B096Cu: goto L801B096C;
            case 0x801B0AE0u: goto L801B0AE0;
            case 0x801B0BA4u: goto L801B0BA4;
            case 0x801B0C9Cu: goto L801B0C9C;
            case 0x801B0D14u: goto L801B0D14;
            case 0x801B0E28u: goto L801B0E28;
            case 0x801B0F18u: goto L801B0F18;
            case 0x801B0F60u: goto L801B0F60;
            default: Dispatcher.Call(c, m, c.V0); return;
        }
        L801B04A4: ;
        c.V0 = 0x80090000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x78ACu)); 
        if (c.V0 == 0u) {
            { c.A0 = 0u | 0x0006u;  }
            goto L801B04E0;
        }
        { c.A0 = 0u | 0x0006u;  }
        c.V0 = 0x80070000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3C50u)); 
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x0001u;  }
            goto L801B1008;
        }
        { c.V0 = 0u | 0x0001u;  }
        c.At = 0x80070000u; 
        mem.WriteU32((c.At - 0x3C68u), c.V0); 
        { c.V0 = 0u | 0x0006u;  }
        c.At = 0x80070000u; 
        mem.WriteU32((c.At - 0x4504u), c.V0); 
        L801B04E0: ;
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3848u)); 
        { c.A1 = 0u | 0x0010u;  }
        c.RA = 0x801B04F4u;
        Dispatcher.Call(c, m, c.V0);
        { c.A0 = c.V0 << 16;  }
        { c.A0 = (uint)((int)c.A0 >> 16);  }
        { c.V1 = c.A0 << 1;  }
        { var _s = c.V1; var _t = c.A0; c.V1 = _s + _t;  }
        { c.V1 = c.V1 << 2;  }
        { var _s = c.V1; var _t = c.A0; c.V1 = _s + _t;  }
        { c.V1 = c.V1 << 2;  }
        c.A0 = 0x80080000u; 
        { c.A0 = c.A0 + 0x6FECu;  }
        { var _s = c.V1; var _t = c.A0; c.A1 = _s + _t;  }
        c.A0 = 0u; 
        { c.T3 = 0u | 0x0015u;  }
        { c.T2 = 0u | 0x0050u;  }
        { c.T1 = 0u | 0x0020u;  }
        { c.A2 = 0u | 0x00B0u;  }
        { c.T0 = 0u | 0x0210u;  }
        { c.A3 = 0u | 0x0008u;  }
        { c.V1 = 0u | 0x0050u;  }
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At - 0x11F8u), (ushort)c.V0); 
        L801B0544: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        mem.WriteU16((c.A1 + 0x8u), (ushort)c.V1); 
        if (c.A0 == 0u) {
            mem.WriteU16((c.A1 + 0xAu), (ushort)c.T3); 
            goto L801B0558;
        }
        mem.WriteU16((c.A1 + 0xAu), (ushort)c.T3); 
        mem.WriteU8((c.A1 + 0xCu), (byte)c.T2); 
        goto L801B055C;
        L801B0558: ;
        mem.WriteU8((c.A1 + 0xCu), (byte)c.T1); 
        L801B055C: ;
        { c.V0 = c.A0 + 0x8Du;  }
        { c.A0 = c.A0 + 0x1u;  }
        mem.WriteU16((c.A1 + 0x1Au), (ushort)c.V0); 
        { c.V0 = (int)c.A0 < 2 ? 1u : 0u;  }
        mem.WriteU8((c.A1 + 0xDu), (byte)0u); 
        mem.WriteU8((c.A1 + 0x18u), (byte)c.A2); 
        mem.WriteU8((c.A1 + 0x19u), (byte)c.A2); 
        mem.WriteU16((c.A1 + 0xEu), (ushort)c.T0); 
        mem.WriteU16((c.A1 + 0x26u), (ushort)0u); 
        mem.WriteU16((c.A1 + 0x32u), (ushort)c.A3); 
        c.A1 = mem.ReadU32(c.A1); 
        if (c.V0 != 0u) {
            { c.V1 = c.V1 + 0xB0u;  }
            goto L801B0544;
        }
        { c.V1 = c.V1 + 0xB0u;  }
        c.A2 = 0x80180000u; 
        { c.A2 = c.A2 + 0x1568u;  }
        c.A0 = 0u; 
        { c.T1 = 0u | 0x0200u;  }
        { c.T0 = 0u | 0x0001u;  }
        { c.A3 = 0u | 0x0008u;  }
        { c.V1 = c.A2 + 0x8u;  }
        L801B05AC: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V0 = mem.ReadU8(c.A2); 
        mem.WriteU8((c.A1 + 0xCu), (byte)c.V0); 
        c.V0 = mem.ReadU8((c.V1 - 0x7u)); 
        mem.WriteU8((c.A1 + 0xDu), (byte)c.V0); 
        c.V0 = mem.ReadU8((c.V1 - 0x6u)); 
        mem.WriteU8((c.A1 + 0x18u), (byte)c.V0); 
        c.V0 = mem.ReadU8((c.V1 - 0x5u)); 
        mem.WriteU8((c.A1 + 0x19u), (byte)c.V0); 
        c.V0 = mem.ReadU16((c.V1 - 0x4u)); 
        { c.A2 = c.A2 + 0xAu;  }
        mem.WriteU16((c.A1 + 0x8u), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.V1 - 0x2u)); 
        { c.A0 = c.A0 + 0x1u;  }
        mem.WriteU16((c.A1 + 0xAu), (ushort)c.V0); 
        c.V0 = mem.ReadU16(c.V1); 
        mem.WriteU16((c.A1 + 0xEu), (ushort)c.T1); 
        mem.WriteU16((c.A1 + 0x26u), (ushort)c.T0); 
        mem.WriteU16((c.A1 + 0x32u), (ushort)c.A3); 
        mem.WriteU16((c.A1 + 0x1Au), (ushort)c.V0); 
        { c.V0 = (int)c.A0 < 10 ? 1u : 0u;  }
        c.A1 = mem.ReadU32(c.A1); 
        if (c.V0 != 0u) {
            { c.V1 = c.V1 + 0xAu;  }
            goto L801B05AC;
        }
        { c.V1 = c.V1 + 0xAu;  }
        c.A0 = 0u; 
        { c.T4 = 0u | 0x0080u;  }
        { c.T3 = 0u | 0x0003u;  }
        { c.T2 = 0u | 0x0040u;  }
        { c.T1 = 0u | 0x0068u;  }
        { c.T0 = 0u | 0x0088u;  }
        { c.A3 = 0u | 0x00A0u;  }
        { c.A2 = 0u | 0x0020u;  }
        { c.V1 = 0u | 0x0020u;  }
        L801B063C: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        { c.V0 = 0u | 0x0004u;  }
        mem.WriteU8((c.A1 + 0x7u), (byte)c.V0); 
        mem.WriteU8((c.A1 + 0x24u), (byte)0u); 
        mem.WriteU8((c.A1 + 0xCu), (byte)0u); 
        mem.WriteU8((c.A1 + 0x30u), (byte)c.T4); 
        if (c.A0 != c.T3) {
            mem.WriteU8((c.A1 + 0x18u), (byte)c.T4); 
            goto L801B0660;
        }
        mem.WriteU8((c.A1 + 0x18u), (byte)c.T4); 
        mem.WriteU8((c.A1 + 0x30u), (byte)c.T2); 
        mem.WriteU8((c.A1 + 0x18u), (byte)c.T2); 
        L801B0660: ;
        { c.V0 = c.A0 << 5;  }
        mem.WriteU8((c.A1 + 0x19u), (byte)c.V0); 
        mem.WriteU8((c.A1 + 0xDu), (byte)c.V0); 
        c.V0 = c.V1; 
        mem.WriteU8((c.A1 + 0x31u), (byte)c.V0); 
        mem.WriteU8((c.A1 + 0x25u), (byte)c.V0); 
        c.V0 = c.A2; 
        mem.WriteU16((c.A1 + 0x20u), (ushort)c.V0); 
        mem.WriteU16((c.A1 + 0x8u), (ushort)c.V0); 
        c.V0 = c.A3; 
        mem.WriteU16((c.A1 + 0x2Cu), (ushort)c.V0); 
        if (c.A0 != c.T3) {
            mem.WriteU16((c.A1 + 0x14u), (ushort)c.V0); 
            goto L801B06A8;
        }
        mem.WriteU16((c.A1 + 0x14u), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.A1 + 0x8u)); 
        { c.V0 = c.V0 + 0x40u;  }
        mem.WriteU16((c.A1 + 0x2Cu), (ushort)c.V0); 
        mem.WriteU16((c.A1 + 0x14u), (ushort)c.V0); 
        L801B06A8: ;
        { c.A3 = c.A3 + 0x80u;  }
        { c.A2 = c.A2 + 0x80u;  }
        { c.A0 = c.A0 + 0x1u;  }
        { c.V0 = 0u | 0x000Bu;  }
        mem.WriteU16((c.A1 + 0x1Au), (ushort)c.V0); 
        { c.V0 = 0u | 0x0220u;  }
        mem.WriteU16((c.A1 + 0xEu), (ushort)c.V0); 
        { c.V0 = 0u | 0x0002u;  }
        mem.WriteU16((c.A1 + 0x26u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0008u;  }
        mem.WriteU16((c.A1 + 0x32u), (ushort)c.V0); 
        { c.V0 = (int)c.A0 < 4 ? 1u : 0u;  }
        mem.WriteU16((c.A1 + 0x16u), (ushort)c.T1); 
        mem.WriteU16((c.A1 + 0xAu), (ushort)c.T1); 
        mem.WriteU16((c.A1 + 0x2Eu), (ushort)c.T0); 
        mem.WriteU16((c.A1 + 0x22u), (ushort)c.T0); 
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
        c.A1 = mem.ReadU32(c.A1); 
        if (c.V0 != 0u) {
            { c.V1 = c.V1 + 0x20u;  }
            goto L801B063C;
        }
        { c.V1 = c.V1 + 0x20u;  }
        { c.A0 = 0u | 0x0001u;  }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3848u)); 
        { c.A1 = 0u | 0x0003u;  }
        c.RA = 0x801B073Cu;
        Dispatcher.Call(c, m, c.V0);
        { c.A0 = c.V0 << 16;  }
        { c.A0 = (uint)((int)c.A0 >> 16);  }
        { c.V1 = c.A0 << 1;  }
        { var _s = c.V1; var _t = c.A0; c.V1 = _s + _t;  }
        { c.V1 = c.V1 << 2;  }
        { var _s = c.V1; var _t = c.A0; c.V1 = _s + _t;  }
        { c.V1 = c.V1 << 2;  }
        c.A0 = 0x80080000u; 
        { c.A0 = c.A0 + 0x6FECu;  }
        { var _s = c.V1; var _t = c.A0; c.A1 = _s + _t;  }
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At - 0x11F4u), (ushort)c.V0); 
        if (c.A1 == 0u) {
            c.A0 = 0u; 
            goto L801B0FE0;
        }
        c.A0 = 0u; 
        { c.T3 = 0u | 0x00C0u;  }
        { c.T2 = 0u | 0x0002u;  }
        { c.T1 = 0u | 0x0080u;  }
        { c.T0 = 0u | 0x00FFu;  }
        { c.V1 = 0u | 0x00FCu;  }
        { c.A3 = 0u | 0x0004u;  }
        { c.A2 = 0u | 0x0035u;  }
        c.V0 = 0u; 
        L801B0794: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        mem.WriteU16((c.A1 + 0x8u), (ushort)c.V0); 
        mem.WriteU16((c.A1 + 0xAu), (ushort)0u); 
        if (c.A0 != c.T2) {
            mem.WriteU8((c.A1 + 0xCu), (byte)c.T3); 
            goto L801B07A8;
        }
        mem.WriteU8((c.A1 + 0xCu), (byte)c.T3); 
        mem.WriteU8((c.A1 + 0xCu), (byte)c.T1); 
        L801B07A8: ;
        { c.V0 = c.V0 + 0xC0u;  }
        mem.WriteU8((c.A1 + 0xDu), (byte)c.T0); 
        mem.WriteU8((c.A1 + 0x5u), (byte)c.V1); 
        mem.WriteU8((c.A1 + 0x6u), (byte)c.V1); 
        mem.WriteU8((c.A1 + 0x4u), (byte)c.V1); 
        mem.WriteU16((c.A1 + 0x26u), (ushort)c.A3); 
        mem.WriteU16((c.A1 + 0x32u), (ushort)c.A2); 
        c.A1 = mem.ReadU32(c.A1); 
        if (c.A1 != 0u) {
            { c.A0 = c.A0 + 0x1u;  }
            goto L801B0794;
        }
        { c.A0 = c.A0 + 0x1u;  }
        goto L801B0FE0;
        L801B07DC: ;
        c.RA = 0x801B07E4u; 
        Dispatcher.Call(c, m, 0x801B0324u);
        c.V0 = 0x801C0000u; 
        c.V0 = (uint)(short)mem.ReadU16((c.V0 - 0x11F8u)); 
        c.A0 = 0u; 
        { c.V1 = c.V0 << 1;  }
        { var _s = c.V1; var _t = c.V0; c.V1 = _s + _t;  }
        { c.V1 = c.V1 << 2;  }
        { var _s = c.V1; var _t = c.V0; c.V1 = _s + _t;  }
        { c.V1 = c.V1 << 2;  }
        c.V0 = 0x80080000u; 
        { c.V0 = c.V0 + 0x6FECu;  }
        { var _s = c.V1; var _t = c.V0; c.A1 = _s + _t;  }
        L801B0810: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V0 = mem.ReadU16((c.A1 + 0xAu)); 
        { c.V0 = c.V0 + 0x10u;  }
        { c.V0 = c.V0 & 0xFFFFu;  }
        { c.V0 = c.V0 < 0x00000100u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.A0 = c.A0 + 0x1u;  }
            goto L801B0830;
        }
        { c.A0 = c.A0 + 0x1u;  }
        mem.WriteU16((c.A1 + 0x32u), (ushort)0u); 
        L801B0830: ;
        c.A1 = mem.ReadU32(c.A1); 
        { c.V0 = (int)c.A0 < 12 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L801B0810;
        }
        c.A0 = c.S0; 
        c.RA = 0x801B0848u; 
        SoTN_st0.DestroyEntity_st0(c, m);
        c.V0 = 0x80070000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x3060u)); 
        { c.V1 = 0u | 0x0018u;  }
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At - 0x11FCu), (ushort)0u); 
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At - 0x1200u), (ushort)0u); 
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At - 0x1204u), (ushort)0u); 
        c.At = 0x80040000u; 
        mem.WriteU8((c.At - 0x34DBu), (byte)0u); 
        c.At = 0x80040000u; 
        mem.WriteU8((c.At - 0x34DAu), (byte)0u); 
        c.At = 0x80040000u; 
        mem.WriteU8((c.At - 0x34D9u), (byte)c.V1); 
        c.At = 0x80050000u; 
        mem.WriteU8((c.At + 0x4319u), (byte)0u); 
        c.At = 0x80050000u; 
        mem.WriteU8((c.At + 0x431Au), (byte)0u); 
        c.At = 0x80050000u; 
        mem.WriteU8((c.At + 0x431Bu), (byte)c.V1); 
        { c.V0 = c.V0 + 0x1u;  }
        goto L801B0FF0;
        L801B08A4: ;
        c.V0 = 0x801C0000u; 
        c.V0 = (uint)(short)mem.ReadU16((c.V0 - 0x11F4u)); 
        { c.V1 = c.V0 << 1;  }
        { var _s = c.V1; var _t = c.V0; c.V1 = _s + _t;  }
        { c.V1 = c.V1 << 2;  }
        { var _s = c.V1; var _t = c.V0; c.V1 = _s + _t;  }
        { c.V1 = c.V1 << 2;  }
        c.V0 = 0x80080000u; 
        { c.V0 = c.V0 + 0x6FECu;  }
        { var _s = c.V1; var _t = c.V0; c.A1 = _s + _t;  }
        if (c.A1 == 0u) {
            c.A0 = 0u; 
            goto L801B1008;
        }
        c.A0 = 0u; 
        L801B08D8: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V0 = mem.ReadU8((c.A1 + 0x5u)); 
        { c.V0 = c.V0 - 0x4u;  }
        mem.WriteU8((c.A1 + 0x5u), (byte)c.V0); 
        mem.WriteU8((c.A1 + 0x6u), (byte)c.V0); 
        if (c.A0 != 0u) {
            mem.WriteU8((c.A1 + 0x4u), (byte)c.V0); 
            goto L801B0904;
        }
        mem.WriteU8((c.A1 + 0x4u), (byte)c.V0); 
        c.V0 = mem.ReadU8((c.A1 + 0x4u)); 
        if (c.V0 == 0u) {
            goto L801B0FC4;
        }
        L801B0904: ;
        c.A1 = mem.ReadU32(c.A1); 
        if (c.A1 != 0u) {
            { c.A0 = c.A0 + 0x1u;  }
            goto L801B08D8;
        }
        { c.A0 = c.A0 + 0x1u;  }
        goto L801B1008;
        L801B091C: ;
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3808u)); 
        c.RA = 0x801B0930u;
        Dispatcher.Call(c, m, c.V0);
        if (c.V0 != 0u) {
            { c.A0 = 0u | 0x0340u;  }
            goto L801B1008;
        }
        { c.A0 = 0u | 0x0340u;  }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3824u)); 
        goto L801B0FD4;
        L801B0948: ;
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3808u)); 
        c.RA = 0x801B095Cu;
        Dispatcher.Call(c, m, c.V0);
        if (c.V0 == 0u) {
            goto L801B1008;
        }
        goto L801B0FE0;
        L801B096C: ;
        c.A0 = c.S0; 
        c.RA = 0x801B0974u; 
        Dispatcher.Call(c, m, 0x801B1298u);
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU16((c.V0 - 0x1204u)); 
        c.V1 = 0x801C0000u; 
        c.V1 = mem.ReadU16((c.V1 - 0x11FCu)); 
        { c.V0 = c.V0 + 0x1u;  }
        { c.V1 = c.V1 + 0x1u;  }
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At - 0x1204u), (ushort)c.V0); 
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At - 0x11FCu), (ushort)c.V1); 
        c.V1 = 0x801C0000u; 
        c.V1 = mem.ReadU16((c.V1 - 0x1204u)); 
        { c.V0 = 0u | 0x000Bu;  }
        if (c.V1 != c.V0) {
            goto L801B0A60;
        }
        c.V1 = 0x801C0000u; 
        c.V1 = mem.ReadU16((c.V1 - 0x1200u)); 
        { c.V0 = c.V1 < 0x000001C0u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.V0 = c.V1 + 0x1u;  }
            goto L801B0A60;
        }
        { c.V0 = c.V1 + 0x1u;  }
        c.A0 = 0u; 
        c.V1 = 0x801C0000u; 
        c.V1 = (uint)(short)mem.ReadU16((c.V1 - 0x11F8u)); 
        { c.A2 = 0u | 0x0008u;  }
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At - 0x1204u), (ushort)0u); 
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At - 0x1200u), (ushort)c.V0); 
        { c.V0 = c.V1 << 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.V1 = 0x80080000u; 
        { c.V1 = c.V1 + 0x6FECu;  }
        { var _s = c.V0; var _t = c.V1; c.A1 = _s + _t;  }
        { c.V0 = (int)c.A0 < 2 ? 1u : 0u;  }
        L801B0A0C: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        if (c.V0 != 0u) {
            goto L801B0A24;
        }
        c.V0 = mem.ReadU16((c.A1 + 0xAu)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.A1 + 0xAu), (ushort)c.V0); 
        L801B0A24: ;
        c.V0 = mem.ReadU16((c.A1 + 0xAu)); 
        { c.V0 = c.V0 + 0x90u;  }
        { c.V0 = c.V0 & 0xFFFFu;  }
        { c.V0 = c.V0 < 0x00000181u ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L801B0A48;
        }
        mem.WriteU16((c.A1 + 0x32u), (ushort)c.A2); 
        goto L801B0A4C;
        L801B0A48: ;
        mem.WriteU16((c.A1 + 0x32u), (ushort)0u); 
        L801B0A4C: ;
        c.A1 = mem.ReadU32(c.A1); 
        { c.A0 = c.A0 + 0x1u;  }
        { c.V0 = (int)c.A0 < 12 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.V0 = (int)c.A0 < 2 ? 1u : 0u;  }
            goto L801B0A0C;
        }
        { c.V0 = (int)c.A0 < 2 ? 1u : 0u;  }
        L801B0A60: ;
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU16((c.V0 - 0x11FCu)); 
        { c.V0 = c.V0 < 0x000014B1u ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.A0 = 0u | 0x000Bu;  }
            goto L801B0CCC;
        }
        { c.A0 = 0u | 0x000Bu;  }
        c.V0 = 0x801C0000u; 
        c.V0 = (uint)(short)mem.ReadU16((c.V0 - 0x11F8u)); 
        { c.V1 = c.V0 << 1;  }
        { var _s = c.V1; var _t = c.V0; c.V1 = _s + _t;  }
        { c.V1 = c.V1 << 2;  }
        { var _s = c.V1; var _t = c.V0; c.V1 = _s + _t;  }
        { c.V1 = c.V1 << 2;  }
        c.V0 = 0x80080000u; 
        { c.V0 = c.V0 + 0x6FECu;  }
        { var _s = c.V1; var _t = c.V0; c.A1 = _s + _t;  }
        L801B0AA4: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.A1 = mem.ReadU32(c.A1); 
        { c.A0 = c.A0 - 0x1u;  }
        if ((int)c.A0 >= 0) {
            goto L801B0AA4;
        }
        if (c.A1 == 0u) {
            { c.V0 = 0u | 0x0035u;  }
            goto L801B0AD0;
        }
        { c.V0 = 0u | 0x0035u;  }
        L801B0ABC: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        mem.WriteU16((c.A1 + 0x32u), (ushort)c.V0); 
        c.A1 = mem.ReadU32(c.A1); 
        if (c.A1 != 0u) {
            goto L801B0ABC;
        }
        L801B0AD0: ;
        c.A0 = c.S0; 
        c.RA = 0x801B0AD8u; 
        SoTN_st0.DestroyEntity_st0(c, m);
        goto L801B0C78;
        L801B0AE0: ;
        c.V0 = 0x801C0000u; 
        c.V0 = (uint)(short)mem.ReadU16((c.V0 - 0x11F8u)); 
        { c.A0 = 0u | 0x000Bu;  }
        { c.V1 = c.V0 << 1;  }
        { var _s = c.V1; var _t = c.V0; c.V1 = _s + _t;  }
        { c.V1 = c.V1 << 2;  }
        { var _s = c.V1; var _t = c.V0; c.V1 = _s + _t;  }
        { c.V1 = c.V1 << 2;  }
        c.V0 = 0x80080000u; 
        { c.V0 = c.V0 + 0x6FECu;  }
        { var _s = c.V1; var _t = c.V0; c.A1 = _s + _t;  }
        L801B0B0C: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.A1 = mem.ReadU32(c.A1); 
        { c.A0 = c.A0 - 0x1u;  }
        if ((int)c.A0 >= 0) {
            goto L801B0B0C;
        }
        if (c.A1 == 0u) {
            goto L801B0B7C;
        }
        L801B0B24: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V1 = mem.ReadU8((c.A1 + 0x28u)); 
        c.A0 = mem.ReadU8((c.A1 + 0x2Au)); 
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU8((c.A1 + 0x1Cu), (byte)c.V1); 
        mem.WriteU8((c.A1 + 0x10u), (byte)c.V1); 
        mem.WriteU8((c.A1 + 0x4u), (byte)c.V1); 
        c.V1 = mem.ReadU8((c.A1 + 0x29u)); 
        mem.WriteU8((c.A1 + 0x28u), (byte)c.V0); 
        mem.WriteU8((c.A1 + 0x1Eu), (byte)c.A0); 
        mem.WriteU8((c.A1 + 0x12u), (byte)c.A0); 
        mem.WriteU8((c.A1 + 0x6u), (byte)c.A0); 
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU8((c.A1 + 0x29u), (byte)c.V0); 
        { c.V0 = c.A0 + 0x1u;  }
        mem.WriteU8((c.A1 + 0x1Du), (byte)c.V1); 
        mem.WriteU8((c.A1 + 0x11u), (byte)c.V1); 
        mem.WriteU8((c.A1 + 0x5u), (byte)c.V1); 
        mem.WriteU8((c.A1 + 0x2Au), (byte)c.V0); 
        c.A1 = mem.ReadU32(c.A1); 
        if (c.A1 != 0u) {
            goto L801B0B24;
        }
        L801B0B7C: ;
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU16((c.V0 - 0x1200u)); 
        { c.V0 = c.V0 + 0x1u;  }
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At - 0x1200u), (ushort)c.V0); 
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU16((c.V0 - 0x1200u)); 
        { c.V0 = c.V0 < 0x000000C1u ? 1u : 0u;  }
        goto L801B0C70;
        L801B0BA4: ;
        c.V0 = 0x801C0000u; 
        c.V0 = (uint)(short)mem.ReadU16((c.V0 - 0x11F8u)); 
        { c.A0 = 0u | 0x000Bu;  }
        { c.V1 = c.V0 << 1;  }
        { var _s = c.V1; var _t = c.V0; c.V1 = _s + _t;  }
        { c.V1 = c.V1 << 2;  }
        { var _s = c.V1; var _t = c.V0; c.V1 = _s + _t;  }
        { c.V1 = c.V1 << 2;  }
        c.V0 = 0x80080000u; 
        { c.V0 = c.V0 + 0x6FECu;  }
        { var _s = c.V1; var _t = c.V0; c.A1 = _s + _t;  }
        L801B0BD0: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.A1 = mem.ReadU32(c.A1); 
        { c.A0 = c.A0 - 0x1u;  }
        if ((int)c.A0 >= 0) {
            goto L801B0BD0;
        }
        if (c.A1 == 0u) {
            goto L801B0C48;
        }
        { c.A2 = 0u | 0x0004u;  }
        L801B0BEC: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V1 = mem.ReadU8((c.A1 + 0x28u)); 
        c.A0 = mem.ReadU8((c.A1 + 0x2Au)); 
        { c.V0 = c.V1 + 0xFFu;  }
        mem.WriteU8((c.A1 + 0x1Cu), (byte)c.V1); 
        mem.WriteU8((c.A1 + 0x10u), (byte)c.V1); 
        mem.WriteU8((c.A1 + 0x4u), (byte)c.V1); 
        c.V1 = mem.ReadU8((c.A1 + 0x29u)); 
        mem.WriteU16((c.A1 + 0x32u), (ushort)c.A2); 
        mem.WriteU8((c.A1 + 0x28u), (byte)c.V0); 
        mem.WriteU8((c.A1 + 0x1Eu), (byte)c.A0); 
        mem.WriteU8((c.A1 + 0x12u), (byte)c.A0); 
        mem.WriteU8((c.A1 + 0x6u), (byte)c.A0); 
        { c.V0 = c.V1 + 0xFFu;  }
        mem.WriteU8((c.A1 + 0x29u), (byte)c.V0); 
        { c.V0 = c.A0 + 0xFFu;  }
        mem.WriteU8((c.A1 + 0x1Du), (byte)c.V1); 
        mem.WriteU8((c.A1 + 0x11u), (byte)c.V1); 
        mem.WriteU8((c.A1 + 0x5u), (byte)c.V1); 
        mem.WriteU8((c.A1 + 0x2Au), (byte)c.V0); 
        c.A1 = mem.ReadU32(c.A1); 
        if (c.A1 != 0u) {
            goto L801B0BEC;
        }
        L801B0C48: ;
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU16((c.V0 - 0x1200u)); 
        { c.V0 = c.V0 + 0x1u;  }
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At - 0x1200u), (ushort)c.V0); 
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU16((c.V0 - 0x1200u)); 
        { c.V0 = c.V0 < 0x00000041u ? 1u : 0u;  }
        L801B0C70: ;
        if (c.V0 != 0u) {
            goto L801B0CCC;
        }
        L801B0C78: ;
        c.V0 = 0x80070000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x3060u)); 
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At - 0x1200u), (ushort)0u); 
        { c.V0 = c.V0 + 0x1u;  }
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x3060u), c.V0); 
        goto L801B0CCC;
        L801B0C9C: ;
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU16((c.V0 - 0x1200u)); 
        { c.V0 = c.V0 + 0x1u;  }
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At - 0x1200u), (ushort)c.V0); 
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU16((c.V0 - 0x1200u)); 
        { c.V0 = c.V0 < 0x00000231u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.V0 = 0u | 0x0010u;  }
            goto L801B0CDC;
        }
        { c.V0 = 0u | 0x0010u;  }
        L801B0CCC: ;
        c.RA = 0x801B0CD4u; 
        SoTN_st0.IsSkipRequested(c, m);
        if (c.V0 == 0u) {
            { c.V0 = 0u | 0x0010u;  }
            goto L801B1008;
        }
        { c.V0 = 0u | 0x0010u;  }
        L801B0CDC: ;
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x3060u), c.V0); 
        goto L801B1008;
        L801B0CEC: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        { c.V0 = c.A0 << 1;  }
        { var _s = c.V0; var _t = c.A0; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.A0; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.V1 = 0x80080000u; 
        { c.V1 = c.V1 + 0x6FECu;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        mem.WriteU32(c.A1, c.V0); 
        goto L801B0D8C;
        L801B0D14: ;
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3824u)); 
        { c.A0 = 0u | 0x0082u;  }
        c.RA = 0x801B0D28u;
        Dispatcher.Call(c, m, c.V0);
        { c.A0 = 0u | 0x0001u;  }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3848u)); 
        { c.A1 = 0u | 0x0003u;  }
        c.RA = 0x801B0D40u;
        Dispatcher.Call(c, m, c.V0);
        c.A0 = 0x801C0000u; 
        c.A0 = (uint)(short)mem.ReadU16((c.A0 - 0x11F8u)); 
        { c.V0 = c.V0 << 16;  }
        { c.V1 = c.A0 << 1;  }
        { var _s = c.V1; var _t = c.A0; c.V1 = _s + _t;  }
        { c.V1 = c.V1 << 2;  }
        { var _s = c.V1; var _t = c.A0; c.V1 = _s + _t;  }
        { c.V1 = c.V1 << 2;  }
        c.A0 = 0x80080000u; 
        { c.A0 = c.A0 + 0x6FECu;  }
        { var _s = c.V1; var _t = c.A0; c.A1 = _s + _t;  }
        if (c.A1 == 0u) {
            { c.A0 = (uint)((int)c.V0 >> 16);  }
            goto L801B0D8C;
        }
        { c.A0 = (uint)((int)c.V0 >> 16);  }
        L801B0D74: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V0 = mem.ReadU32(c.A1); 
        if (c.V0 == 0u) {
            goto L801B0CEC;
        }
        c.A1 = c.V0; 
        goto L801B0D74;
        L801B0D8C: ;
        { c.V0 = c.A0 << 1;  }
        { var _s = c.V0; var _t = c.A0; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.A0; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.V1 = 0x80080000u; 
        { c.V1 = c.V1 + 0x6FECu;  }
        { var _s = c.V0; var _t = c.V1; c.A1 = _s + _t;  }
        if (c.A1 == 0u) {
            c.A0 = 0u; 
            goto L801B0E10;
        }
        c.A0 = 0u; 
        { c.T2 = 0u | 0x00C0u;  }
        { c.T1 = 0u | 0x0002u;  }
        { c.T0 = 0u | 0x0080u;  }
        { c.A3 = 0u | 0x00FFu;  }
        { c.A2 = 0u | 0x0004u;  }
        { c.V1 = 0u | 0x0055u;  }
        c.V0 = 0u; 
        L801B0DD0: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        mem.WriteU16((c.A1 + 0x8u), (ushort)c.V0); 
        mem.WriteU16((c.A1 + 0xAu), (ushort)0u); 
        if (c.A0 != c.T1) {
            mem.WriteU8((c.A1 + 0xCu), (byte)c.T2); 
            goto L801B0DE4;
        }
        mem.WriteU8((c.A1 + 0xCu), (byte)c.T2); 
        mem.WriteU8((c.A1 + 0xCu), (byte)c.T0); 
        L801B0DE4: ;
        { c.V0 = c.V0 + 0xC0u;  }
        mem.WriteU8((c.A1 + 0xDu), (byte)c.A3); 
        mem.WriteU8((c.A1 + 0x5u), (byte)0u); 
        mem.WriteU8((c.A1 + 0x6u), (byte)0u); 
        mem.WriteU8((c.A1 + 0x4u), (byte)0u); 
        mem.WriteU16((c.A1 + 0x26u), (ushort)c.A2); 
        mem.WriteU16((c.A1 + 0x32u), (ushort)c.V1); 
        c.A1 = mem.ReadU32(c.A1); 
        if (c.A1 != 0u) {
            { c.A0 = c.A0 + 0x1u;  }
            goto L801B0DD0;
        }
        { c.A0 = c.A0 + 0x1u;  }
        L801B0E10: ;
        c.V0 = 0x80070000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x3060u)); 
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At - 0x1200u), (ushort)0u); 
        { c.V0 = c.V0 + 0x1u;  }
        goto L801B0FF0;
        L801B0E28: ;
        c.V0 = 0x801C0000u; 
        c.V0 = (uint)(short)mem.ReadU16((c.V0 - 0x11F8u)); 
        { c.A0 = 0u | 0x000Fu;  }
        { c.V1 = c.V0 << 1;  }
        { var _s = c.V1; var _t = c.V0; c.V1 = _s + _t;  }
        { c.V1 = c.V1 << 2;  }
        { var _s = c.V1; var _t = c.V0; c.V1 = _s + _t;  }
        { c.V1 = c.V1 << 2;  }
        c.V0 = 0x80080000u; 
        { c.V0 = c.V0 + 0x6FECu;  }
        { var _s = c.V1; var _t = c.V0; c.A1 = _s + _t;  }
        L801B0E54: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.A1 = mem.ReadU32(c.A1); 
        { c.A0 = c.A0 - 0x1u;  }
        if ((int)c.A0 >= 0) {
            goto L801B0E54;
        }
        if (c.A1 == 0u) {
            goto L801B0EA8;
        }
        L801B0E6C: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V0 = mem.ReadU8((c.A1 + 0x4u)); 
        { c.V0 = c.V0 < 0x000000F8u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L801B0E98;
        }
        c.V0 = mem.ReadU8((c.A1 + 0x5u)); 
        { c.V0 = c.V0 + 0x8u;  }
        mem.WriteU8((c.A1 + 0x5u), (byte)c.V0); 
        mem.WriteU8((c.A1 + 0x6u), (byte)c.V0); 
        mem.WriteU8((c.A1 + 0x4u), (byte)c.V0); 
        L801B0E98: ;
        c.A1 = mem.ReadU32(c.A1); 
        if (c.A1 != 0u) {
            goto L801B0E6C;
        }
        L801B0EA8: ;
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU16((c.V0 - 0x1200u)); 
        { c.V0 = c.V0 + 0x1u;  }
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At - 0x1200u), (ushort)c.V0); 
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU16((c.V0 - 0x1200u)); 
        { c.V0 = c.V0 < 0x00000021u ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L801B1008;
        }
        c.V0 = 0x80070000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x3060u)); 
        c.At = 0x80040000u; 
        mem.WriteU8((c.At - 0x34DBu), (byte)0u); 
        c.At = 0x80040000u; 
        mem.WriteU8((c.At - 0x34DAu), (byte)0u); 
        c.At = 0x80040000u; 
        mem.WriteU8((c.At - 0x34D9u), (byte)0u); 
        c.At = 0x80050000u; 
        mem.WriteU8((c.At + 0x4319u), (byte)0u); 
        c.At = 0x80050000u; 
        mem.WriteU8((c.At + 0x431Au), (byte)0u); 
        c.At = 0x80050000u; 
        mem.WriteU8((c.At + 0x431Bu), (byte)0u); 
        { c.V0 = c.V0 + 0x1u;  }
        goto L801B0FF0;
        L801B0F18: ;
        c.V1 = 0x80040000u; 
        { c.V1 = c.V1 - 0x34FCu;  }
        c.V0 = mem.ReadU32(c.V1); 
        { c.V0 = c.V0 | 0x0002u;  }
        mem.WriteU32(c.V1, c.V0); 
        c.RA = 0x801B0F34u; 
        SoTN_st0.InitClutIndices(c, m);
        c.A0 = 0x801C0000u; 
        c.A0 = (uint)(short)mem.ReadU16((c.A0 - 0x11F8u)); 
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x384Cu)); 
        c.RA = 0x801B0F50u;
        Dispatcher.Call(c, m, c.V0);
        c.A0 = 0u; 
        c.RA = 0x801B0F58u; 
        SoTN_st0.DestroyEntitiesFromIndex_st0(c, m);
        goto L801B0FE0;
        L801B0F60: ;
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3808u)); 
        c.RA = 0x801B0F74u;
        Dispatcher.Call(c, m, c.V0);
        if (c.V0 != 0u) {
            goto L801B1008;
        }
        c.RA = 0x801B0F84u; 
        SoTN_st0.SetStageDisplayBuffer_st0(c, m);
        c.RA = 0x801B0F8Cu; 
        SoTN_st0.ClearScreen(c, m);
        c.V1 = 0x80090000u; 
        c.V1 = mem.ReadU32((c.V1 + 0x74A0u)); 
        { c.V0 = 0u | 0x001Fu;  }
        if (c.V1 != c.V0) {
            { c.V0 = 0u | 0x0041u;  }
            goto L801B1000;
        }
        { c.V0 = 0u | 0x0041u;  }
        c.At = 0x80090000u; 
        mem.WriteU32((c.At + 0x74A0u), c.V0); 
        { c.A0 = 0u | 0x0004u;  }
        c.RA = 0x801B0FB0u; 
        SoTN_st0.SetGameState_st0(c, m);
        { c.V0 = 0u | 0x0002u;  }
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x3060u), c.V0); 
        goto L801B1008;
        L801B0FC4: ;
        c.A0 = 0x801C0000u; 
        c.A0 = (uint)(short)mem.ReadU16((c.A0 - 0x11F4u)); 
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x384Cu)); 
        L801B0FD4: ;
        c.RA = 0x801B0FE0u;
        Dispatcher.Call(c, m, c.V0);
        L801B0FE0: ;
        c.V0 = 0x80070000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x3060u)); 
        { c.V0 = c.V0 + 0x1u;  }
        L801B0FF0: ;
        c.At = 0x80070000u; 
        mem.WriteU32((c.At + 0x3060u), c.V0); 
        goto L801B1008;
        L801B1000: ;
        { c.A0 = 0u | 0x0001u;  }
        c.RA = 0x801B1008u; 
        SoTN_st0.SetGameState_st0(c, m);
        L801B1008: ;
        c.RA = mem.ReadU32((c.SP + 0x14u)); 
        c.S0 = mem.ReadU32((c.SP + 0x10u)); 
        { c.SP = c.SP + 0x18u;  }
        return;
        }
    public static bool ClearScreen(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("st0", m, false)) return true;
        ClearScreen_Body(c, m);
        return false;
    }
    private static void ClearScreen_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "st0", 0x801C24CCu);
        { c.SP = c.SP - 0x20u;  }
        { c.V0 = 0u | 0x0200u;  }
        { c.A0 = c.SP + 0x10u;  }
        c.A1 = 0u; 
        c.A2 = 0u; 
        c.A3 = 0u; 
        mem.WriteU32((c.SP + 0x18u), c.RA); 
        mem.WriteU16((c.SP + 0x10u), (ushort)0u); 
        mem.WriteU16((c.SP + 0x12u), (ushort)0u); 
        mem.WriteU16((c.SP + 0x14u), (ushort)c.V0); 
        mem.WriteU16((c.SP + 0x16u), (ushort)c.V0); 
        c.RA = 0x801B01B0u; 
        DialogueGlyphs.Clear(c, mem);
        c.RA = mem.ReadU32((c.SP + 0x18u)); 
        { c.SP = c.SP + 0x20u;  }
        return;
        }
    public static bool func_801B101C(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("st0", m, true)) return true;
        func_801B101C_Body(c, m);
        return false;
    }
    private static void func_801B101C_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "st0", 0x801C24CCu);
        { c.SP = c.SP - 0x18u;  }
        mem.WriteU32((c.SP + 0x10u), c.S0); 
        c.S0 = c.A0; 
        { c.A0 = 0u | 0x0006u;  }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3848u)); 
        mem.WriteU32((c.SP + 0x14u), c.RA); 
        { c.A1 = 0u | 0x0020u;  }
        c.RA = 0x801B1040u;
        Dispatcher.Call(c, m, c.V0);
        c.A0 = 0x801C0000u; 
        { c.A0 = c.A0 + 0x24E4u;  }
        { c.V0 = c.V0 << 16;  }
        { c.V1 = (uint)((int)c.V0 >> 16);  }
        c.V0 = 0xFFFFFFFFu; 
        if (c.V1 == c.V0) {
            mem.WriteU32(c.A0, c.V1); 
            goto L801B117C;
        }
        mem.WriteU32(c.A0, c.V1); 
        { c.V0 = c.V1 << 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.V1 = 0x80080000u; 
        { c.V1 = c.V1 + 0x6FECu;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        c.A1 = c.V0; 
        c.A2 = 0u; 
        { c.T1 = 0u | 0x0009u;  }
        { c.T0 = 0u | 0x0100u;  }
        { c.A3 = 0u | 0x0008u;  }
        { c.V0 = 0u | 0x0200u;  }
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At + 0x24D6u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0216u;  }
        c.At = 0x801C0000u; 
        mem.WriteU32((c.At + 0x24CCu), c.S0); 
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At + 0x24D4u), (ushort)c.V0); 
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At + 0x24D8u), (ushort)0u); 
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At + 0x24DAu), (ushort)0u); 
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At + 0x24DCu), (ushort)0u); 
        c.At = 0x801C0000u; 
        mem.WriteU8((c.At + 0x24DEu), (byte)0u); 
        c.At = 0x801C0000u; 
        mem.WriteU8((c.At + 0x24DFu), (byte)0u); 
        c.At = 0x801C0000u; 
        mem.WriteU32((c.At + 0x24E0u), c.A1); 
        { c.V0 = c.A2 & 0x0001u;  }
        L801B10E4: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        if (c.V0 == 0u) {
            { c.V0 = 0u | 0x0020u;  }
            goto L801B10F8;
        }
        { c.V0 = 0u | 0x0020u;  }
        mem.WriteU16((c.A1 + 0x1Au), (ushort)c.T1); 
        mem.WriteU16((c.A1 + 0x8u), (ushort)c.T0); 
        goto L801B1100;
        L801B10F8: ;
        mem.WriteU16((c.A1 + 0x1Au), (ushort)c.A3); 
        mem.WriteU16((c.A1 + 0x8u), (ushort)c.V0); 
        L801B1100: ;
        { c.V1 = c.A2 << 16;  }
        { c.A0 = c.A2 + 0x1u;  }
        c.A2 = c.A0; 
        { c.V1 = (uint)((int)c.V1 >> 17);  }
        { c.V0 = c.V1 << 4;  }
        mem.WriteU8((c.A1 + 0xDu), (byte)c.V0); 
        { c.V0 = 0u | 0x00F0u;  }
        mem.WriteU8((c.A1 + 0x18u), (byte)c.V0); 
        { c.V0 = 0u | 0x0010u;  }
        mem.WriteU8((c.A1 + 0x19u), (byte)c.V0); 
        { c.V0 = c.V1 << 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s - _t;  }
        { c.V0 = c.V0 << 1;  }
        { c.V0 = c.V0 + 0xF0u;  }
        mem.WriteU16((c.A1 + 0xAu), (ushort)c.V0); 
        { c.V0 = 0u | 0x0221u;  }
        mem.WriteU16((c.A1 + 0xEu), (ushort)c.V0); 
        { c.V0 = 0u | 0x0003u;  }
        { c.A0 = c.A0 << 16;  }
        { c.A0 = (uint)((int)c.A0 >> 16);  }
        { c.A0 = (int)c.A0 < 32 ? 1u : 0u;  }
        mem.WriteU8((c.A1 + 0xCu), (byte)0u); 
        mem.WriteU16((c.A1 + 0x26u), (ushort)c.V0); 
        mem.WriteU16((c.A1 + 0x32u), (ushort)0u); 
        c.A1 = mem.ReadU32(c.A1); 
        if (c.A0 != 0u) {
            { c.V0 = c.A2 & 0x0001u;  }
            goto L801B10E4;
        }
        { c.V0 = c.A2 & 0x0001u;  }
        { c.V0 = 0u | 0x0001u;  }
        goto L801B1184;
        L801B117C: ;
        mem.WriteU32(c.A0, 0u); 
        c.V0 = 0u; 
        L801B1184: ;
        c.RA = mem.ReadU32((c.SP + 0x14u)); 
        c.S0 = mem.ReadU32((c.SP + 0x10u)); 
        { c.SP = c.SP + 0x18u;  }
        return;
        }
    public static bool func_801B1198(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("st0", m, false)) return true;
        func_801B1198_Body(c, m);
        return false;
    }
    private static void func_801B1198_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "st0", 0x801C24CCu);
        { c.SP = c.SP - 0x20u;  }
        { c.V0 = 0u | 0x0200u;  }
        { c.A0 = c.A0 << 16;  }
        { c.A0 = (uint)((int)c.A0 >> 12);  }
        mem.WriteU16((c.SP + 0x10u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0080u;  }
        mem.WriteU16((c.SP + 0x14u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0010u;  }
        mem.WriteU16((c.SP + 0x12u), (ushort)c.A0); 
        { c.A0 = c.SP + 0x10u;  }
        c.A1 = 0u; 
        c.A2 = 0u; 
        c.A3 = 0u; 
        mem.WriteU32((c.SP + 0x18u), c.RA); 
        mem.WriteU16((c.SP + 0x16u), (ushort)c.V0); 
        c.RA = 0x801B11D8u; 
        DialogueGlyphs.Clear(c, mem);
        c.RA = mem.ReadU32((c.SP + 0x18u)); 
        { c.SP = c.SP + 0x20u;  }
        return;
        }
    public static bool func_801B1298_st0(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("st0", m, true)) return true;
        func_801B1298_st0_Body(c, m);
        return false;
    }
    private static void func_801B1298_st0_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "st0", 0x801C24CCu);
        { c.SP = c.SP - 0x48u;  }
        mem.WriteU32((c.SP + 0x30u), c.S0); 
        c.S0 = c.A0; 
        mem.WriteU32((c.SP + 0x44u), c.RA); 
        mem.WriteU32((c.SP + 0x40u), c.S4); 
        mem.WriteU32((c.SP + 0x3Cu), c.S3); 
        mem.WriteU32((c.SP + 0x38u), c.S2); 
        mem.WriteU32((c.SP + 0x34u), c.S1); 
        c.V1 = mem.ReadU16((c.S0 + 0x2Cu)); 
        { c.V0 = 0u | 0x0001u;  }
        if (c.V1 == c.V0) {
            { c.V0 = (int)c.V1 < 2 ? 1u : 0u;  }
            goto L801B146C;
        }
        { c.V0 = (int)c.V1 < 2 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L801B12E0;
        }
        if (c.V1 == 0u) {
            goto L801B12FC;
        }
        goto L801B176C;
        L801B12E0: ;
        { c.V0 = 0u | 0x0002u;  }
        if (c.V1 == c.V0) {
            { c.V0 = 0u | 0x0007u;  }
            goto L801B176C;
        }
        { c.V0 = 0u | 0x0007u;  }
        if (c.V1 == c.V0) {
            goto L801B171C;
        }
        goto L801B176C;
        L801B12FC: ;
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x2C58u;  }
        c.RA = 0x801B130Cu; 
        SoTN_st0.func_801B101C(c, m);
        { c.V0 = c.V0 & 0x00FFu;  }
        if (c.V0 == 0u) {
            c.A0 = 0u; 
            goto L801B176C;
        }
        c.A0 = 0u; 
        c.S2 = 0u; 
        c.A1 = 0x801C0000u; 
        { c.A1 = c.A1 + 0x24E4u;  }
        { c.S1 = c.A1 - 0x18u;  }
        c.S4 = 0x801C0000u; 
        { c.S4 = c.S4 - 0x1170u;  }
        { c.S3 = c.A1 - 0xCu;  }
        c.V0 = mem.ReadU32((c.S0 + 0x34u)); 
        c.V1 = 0x00800000u; 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s | _t;  }
        mem.WriteU32((c.S0 + 0x34u), c.V0); 
        c.V0 = mem.ReadU16((c.S0 + 0x2Cu)); 
        c.V1 = mem.ReadU32(c.A1); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S0 + 0x2Cu), (ushort)c.V0); 
        mem.WriteU32((c.S0 + 0x64u), c.V1); 
        c.RA = 0x801B135Cu; 
        Dispatcher.Call(c, m, 0x801B1198u);
        L801B135C: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.A0 = mem.ReadU32(c.S1); 
        { c.V0 = c.A0 + 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.A2 = mem.ReadU8(c.A0); 
        { c.V0 = 0u | 0x0001u;  }
        { c.V1 = c.A2 & 0xFFFFu;  }
        if (c.V1 == c.V0) {
            { c.V0 = c.A0 + 0x2u;  }
            goto L801B16F8;
        }
        { c.V0 = c.A0 + 0x2u;  }
        c.A0 = c.A2; 
        c.RA = 0x801B1388u; 
        SoTN_st0.func_801B11E8(c, m);
        c.A0 = c.V0; 
        if (c.A0 == 0u) {
            { c.V1 = c.S2 & 0xFFFFu;  }
            goto L801B143C;
        }
        { c.V1 = c.S2 & 0xFFFFu;  }
        { c.V0 = c.V1 << 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 5;  }
        { var _s = c.V0; var _t = c.S4; c.V1 = _s + _t;  }
        c.A1 = 0u; 
        L801B13A8: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V0 = mem.ReadU16(c.A0); 
        { c.A0 = c.A0 + 0x2u;  }
        { c.A1 = c.A1 + 0x1u;  }
        mem.WriteU16(c.V1, (ushort)c.V0); 
        { c.V0 = (int)c.A1 < 48 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.V1 = c.V1 + 0x2u;  }
            goto L801B13A8;
        }
        { c.V1 = c.V1 + 0x2u;  }
        { c.V0 = c.S2 & 0xFFFFu;  }
        { c.A0 = c.V0 << 1;  }
        { var _s = c.A0; var _t = c.V0; c.A0 = _s + _t;  }
        { c.A0 = c.A0 << 5;  }
        { var _s = c.A0; var _t = c.S4; c.A0 = _s + _t;  }
        c.A1 = 0u; 
        c.A2 = 0u; 
        { c.V0 = 0u | 0x000Cu;  }
        mem.WriteU32((c.SP + 0x14u), c.V0); 
        { c.V0 = 0u | 0x0010u;  }
        mem.WriteU32((c.SP + 0x18u), c.V0); 
        c.V0 = (uint)(short)mem.ReadU16(c.S3); 
        c.A3 = (uint)(short)mem.ReadU16((c.S3 - 0x4u)); 
        { c.V0 = c.V0 << 4;  }
        { c.V0 = c.V0 & 0xFFFFu;  }
        mem.WriteU32((c.SP + 0x10u), c.V0); 
        c.RA = 0x801B1408u; 
        SoTN_main.LoadTPage(c, m);
        c.A0 = mem.ReadU16((c.S3 - 0x4u)); 
        c.V0 = mem.ReadU16((c.S3 - 0x2u)); 
        { c.V1 = c.A0 + 0x3u;  }
        { var _s = c.V1; var _t = c.V0; c.V0 = _s - _t;  }
        { c.V0 = c.V0 - 0x38u;  }
        { c.V0 = c.V0 & 0xFFFFu;  }
        { c.V0 = c.V0 < 0x00000008u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            mem.WriteU16((c.S3 - 0x4u), (ushort)c.V1); 
            goto L801B1434;
        }
        mem.WriteU16((c.S3 - 0x4u), (ushort)c.V1); 
        { c.V0 = c.A0 + 0xBu;  }
        mem.WriteU16((c.S3 - 0x4u), (ushort)c.V0); 
        L801B1434: ;
        { c.S2 = c.S2 + 0x1u;  }
        goto L801B135C;
        L801B143C: ;
        c.A0 = mem.ReadU16((c.S1 + 0x8u)); 
        c.V0 = mem.ReadU16((c.S1 + 0xAu)); 
        { c.V1 = c.A0 + 0x2u;  }
        { var _s = c.V1; var _t = c.V0; c.V0 = _s - _t;  }
        { c.V0 = c.V0 - 0x38u;  }
        { c.V0 = c.V0 & 0xFFFFu;  }
        { c.V0 = c.V0 < 0x00000008u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            mem.WriteU16((c.S1 + 0x8u), (ushort)c.V1); 
            goto L801B135C;
        }
        mem.WriteU16((c.S1 + 0x8u), (ushort)c.V1); 
        { c.V0 = c.A0 + 0xAu;  }
        mem.WriteU16((c.S1 + 0x8u), (ushort)c.V0); 
        goto L801B135C;
        L801B146C: ;
        c.A3 = 0x801C0000u; 
        { c.A3 = c.A3 + 0x24DAu;  }
        c.V0 = mem.ReadU16(c.A3); 
        if (c.V0 == 0u) {
            goto L801B176C;
        }
        c.A1 = mem.ReadU32((c.A3 - 0xEu)); 
        { c.V0 = c.A1 + 0x1u;  }
        mem.WriteU32((c.A3 - 0xEu), c.V0); 
        c.A2 = mem.ReadU8(c.A1); 
        { c.V0 = 0u | 0x0001u;  }
        { c.V1 = c.A2 & 0xFFFFu;  }
        if (c.V1 == c.V0) {
            { c.V0 = (int)c.V1 < 2 ? 1u : 0u;  }
            goto L801B14DC;
        }
        { c.V0 = (int)c.V1 < 2 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L801B14C0;
        }
        if (c.V1 == 0u) {
            { c.V0 = 0u | 0x0007u;  }
            goto L801B14D4;
        }
        { c.V0 = 0u | 0x0007u;  }
        goto L801B1640;
        L801B14C0: ;
        { c.V0 = 0u | 0x0002u;  }
        if (c.V1 == c.V0) {
            { c.V0 = c.A1 + 0x2u;  }
            goto L801B1534;
        }
        { c.V0 = c.A1 + 0x2u;  }
        goto L801B1640;
        L801B14D4: ;
        mem.WriteU16((c.S0 + 0x2Cu), (ushort)c.V0); 
        goto L801B1848;
        L801B14DC: ;
        { c.V0 = c.A1 + 0x2u;  }
        mem.WriteU32((c.A3 - 0xEu), c.V0); 
        c.V1 = mem.ReadU8((c.A1 + 0x1u)); 
        c.A0 = 0x801C0000u; 
        c.A0 = mem.ReadU16((c.A0 + 0x24D6u)); 
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU16((c.V0 + 0x24D8u)); 
        { var _s = c.V1; var _t = c.A0; c.V1 = _s + _t;  }
        { c.V0 = c.V0 + 0x1u;  }
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At + 0x24D8u), (ushort)c.V0); 
        { c.V0 = c.V0 << 16;  }
        { c.V0 = (uint)((int)c.V0 >> 16);  }
        { c.V0 = (int)c.V0 < 16 ? 1u : 0u;  }
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At + 0x24D4u), (ushort)c.V1); 
        if (c.V0 != 0u) {
            goto L801B152C;
        }
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At + 0x24D8u), (ushort)0u); 
        L801B152C: ;
        mem.WriteU16(c.A3, (ushort)0u); 
        goto L801B1848;
        L801B1534: ;
        mem.WriteU32((c.A3 - 0xEu), c.V0); 
        c.V1 = mem.ReadU8((c.A1 + 0x1u)); 
        c.A0 = 0x801C0000u; 
        c.A0 = mem.ReadU16((c.A0 + 0x24D6u)); 
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU16((c.V0 + 0x24D8u)); 
        { var _s = c.V1; var _t = c.A0; c.V1 = _s + _t;  }
        { c.V0 = c.V0 + 0x1u;  }
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At + 0x24D8u), (ushort)c.V0); 
        { c.V0 = c.V0 << 16;  }
        { c.V0 = (uint)((int)c.V0 >> 16);  }
        { c.V0 = (int)c.V0 < 16 ? 1u : 0u;  }
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At + 0x24D4u), (ushort)c.V1); 
        if (c.V0 != 0u) {
            c.A1 = 0u; 
            goto L801B1580;
        }
        c.A1 = 0u; 
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At + 0x24D8u), (ushort)0u); 
        L801B1580: ;
        c.V0 = 0x801C0000u; 
        c.V0 = (uint)(short)mem.ReadU16((c.V0 + 0x24D8u)); 
        c.A0 = mem.ReadU32((c.A3 + 0x6u)); 
        if ((int)c.V0 <= 0) {
            goto L801B15B4;
        }
        c.V1 = c.V0; 
        { c.A1 = c.A1 + 0x1u;  }
        L801B159C: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.A0 = mem.ReadU32(c.A0); 
        { var _s = c.A1; var _t = c.V1; c.V0 = (int)_s < (int)_t ? 1u : 0u;  }
        c.A0 = mem.ReadU32(c.A0); 
        if (c.V0 != 0u) {
            { c.A1 = c.A1 + 0x1u;  }
            goto L801B159C;
        }
        { c.A1 = c.A1 + 0x1u;  }
        { c.A1 = c.A1 - 0x1u;  }
        L801B15B4: ;
        c.V0 = mem.ReadU16((c.A0 + 0xAu)); 
        c.A0 = 0x801C0000u; 
        c.A0 = mem.ReadU32((c.A0 + 0x24E0u)); 
        if (c.A0 == 0u) {
            { c.V0 = c.V0 << 16;  }
            goto L801B1608;
        }
        { c.V0 = c.V0 << 16;  }
        { c.A2 = (uint)((int)c.V0 >> 16);  }
        L801B15D0: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V0 = (uint)(short)mem.ReadU16((c.A0 + 0xAu)); 
        c.A1 = c.V0; 
        { var _s = c.V0; var _t = c.A2; c.V0 = (int)_s < (int)_t ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.V0 = c.A1 + 0x16u;  }
            goto L801B15F8;
        }
        { c.V0 = c.A1 + 0x16u;  }
        c.V1 = mem.ReadU8((c.A0 + 0x13u)); 
        mem.WriteU16((c.A0 + 0xAu), (ushort)c.V0); 
        { c.V1 = c.V1 + 0x16u;  }
        mem.WriteU8((c.A0 + 0x13u), (byte)c.V1); 
        L801B15F8: ;
        c.A0 = mem.ReadU32(c.A0); 
        if (c.A0 != 0u) {
            goto L801B15D0;
        }
        L801B1608: ;
        c.V0 = 0x801C0000u; 
        { c.V0 = c.V0 + 0x24DEu;  }
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At + 0x24DAu), (ushort)0u); 
        c.V1 = mem.ReadU8(c.V0); 
        c.A0 = 0x801C0000u; 
        c.A0 = mem.ReadU16((c.A0 + 0x24DCu)); 
        { c.V1 = c.V1 + 0x58u;  }
        { c.A0 = c.A0 + 0x16u;  }
        mem.WriteU8(c.V0, (byte)c.V1); 
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At + 0x24DCu), (ushort)c.A0); 
        goto L801B1848;
        L801B1640: ;
        c.A0 = c.A2; 
        c.RA = 0x801B1648u; 
        SoTN_st0.func_801B11E8(c, m);
        c.A0 = c.V0; 
        if (c.A0 == 0u) {
            c.A1 = 0u; 
            goto L801B16A8;
        }
        c.A1 = 0u; 
        c.A2 = 0u; 
        { c.V0 = 0u | 0x000Cu;  }
        mem.WriteU32((c.SP + 0x14u), c.V0); 
        { c.V0 = 0u | 0x0010u;  }
        mem.WriteU32((c.SP + 0x18u), c.V0); 
        c.V0 = 0x801C0000u; 
        c.V0 = (uint)(short)mem.ReadU16((c.V0 + 0x24D8u)); 
        c.A3 = 0x801C0000u; 
        c.A3 = (uint)(short)mem.ReadU16((c.A3 + 0x24D4u)); 
        { c.V0 = c.V0 << 4;  }
        { c.V0 = c.V0 & 0xFFFFu;  }
        mem.WriteU32((c.SP + 0x10u), c.V0); 
        c.RA = 0x801B1688u; 
        SoTN_main.LoadTPage(c, m);
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU16((c.V0 + 0x24D4u)); 
        { c.V0 = c.V0 + 0x3u;  }
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At + 0x24D4u), (ushort)c.V0); 
        goto L801B16C0;
        L801B16A8: ;
        c.V1 = 0x801C0000u; 
        { c.V1 = c.V1 + 0x24D4u;  }
        c.V0 = mem.ReadU16(c.V1); 
        { c.V0 = c.V0 + 0x2u;  }
        mem.WriteU16(c.V1, (ushort)c.V0); 
        L801B16C0: ;
        c.A0 = 0x801C0000u; 
        { c.A0 = c.A0 + 0x24D4u;  }
        c.V1 = mem.ReadU16(c.A0); 
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU16((c.V0 + 0x24D6u)); 
        { var _s = c.V1; var _t = c.V0; c.V0 = _s - _t;  }
        { c.V0 = c.V0 - 0x38u;  }
        { c.V0 = c.V0 & 0xFFFFu;  }
        { c.V0 = c.V0 < 0x00000008u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.V0 = c.V1 + 0x8u;  }
            goto L801B176C;
        }
        { c.V0 = c.V1 + 0x8u;  }
        mem.WriteU16(c.A0, (ushort)c.V0); 
        goto L801B176C;
        L801B16F8: ;
        mem.WriteU32(c.S1, c.V0); 
        c.V0 = mem.ReadU8((c.A0 + 0x1u)); 
        c.V1 = mem.ReadU16((c.S1 + 0xCu)); 
        c.A0 = mem.ReadU16((c.S1 + 0xAu)); 
        { c.V1 = c.V1 + 0x1u;  }
        { var _s = c.V0; var _t = c.A0; c.V0 = _s + _t;  }
        mem.WriteU16((c.S1 + 0x8u), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0xCu), (ushort)c.V1); 
        goto L801B176C;
        L801B171C: ;
        c.V1 = 0x801C0000u; 
        { c.V1 = c.V1 + 0x24DAu;  }
        c.V0 = mem.ReadU16(c.V1); 
        if (c.V0 == 0u) {
            goto L801B176C;
        }
        c.V0 = 0x801C0000u; 
        c.V0 = mem.ReadU16((c.V0 + 0x24D8u)); 
        { c.V0 = c.V0 + 0x1u;  }
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At + 0x24D8u), (ushort)c.V0); 
        { c.V0 = c.V0 << 16;  }
        { c.V0 = (uint)((int)c.V0 >> 16);  }
        { c.V0 = (int)c.V0 < 16 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L801B1768;
        }
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At + 0x24D8u), (ushort)0u); 
        L801B1768: ;
        mem.WriteU16(c.V1, (ushort)0u); 
        L801B176C: ;
        c.S0 = 0x801C0000u; 
        { c.S0 = c.S0 + 0x24DEu;  }
        c.V0 = mem.ReadU8(c.S0); 
        if (c.V0 != 0u) {
            goto L801B17A8;
        }
        c.A0 = 0x801C0000u; 
        c.A0 = (uint)(short)mem.ReadU16((c.A0 + 0x24D8u)); 
        c.RA = 0x801B1794u; 
        Dispatcher.Call(c, m, 0x801B1198u);
        { c.V0 = 0u | 0x0001u;  }
        c.At = 0x801C0000u; 
        mem.WriteU16((c.At + 0x24DAu), (ushort)c.V0); 
        { c.V0 = 0u | 0x0058u;  }
        mem.WriteU8(c.S0, (byte)c.V0); 
        L801B17A8: ;
        c.V0 = mem.ReadU8(c.S0); 
        c.V1 = 0x801C0000u; 
        c.V1 = mem.ReadU8((c.V1 + 0x24DFu)); 
        { c.V0 = c.V0 - 0x1u;  }
        if (c.V1 != 0u) {
            mem.WriteU8(c.S0, (byte)c.V0); 
            goto L801B1830;
        }
        mem.WriteU8(c.S0, (byte)c.V0); 
        c.A0 = 0x801C0000u; 
        c.A0 = mem.ReadU32((c.A0 + 0x24E0u)); 
        c.A1 = 0u; 
        c.A3 = 0xFFFFFFEAu; 
        { c.A2 = c.S0 - 0x2u;  }
        L801B17D4: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V0 = mem.ReadU16((c.A0 + 0xAu)); 
        { c.V0 = c.V0 - 0x1u;  }
        mem.WriteU16((c.A0 + 0xAu), (ushort)c.V0); 
        { c.V0 = c.V0 << 16;  }
        { c.V0 = (uint)((int)c.V0 >> 16);  }
        if (c.V0 != c.A3) {
            { c.A1 = c.A1 + 0x1u;  }
            goto L801B1818;
        }
        { c.A1 = c.A1 + 0x1u;  }
        c.V0 = mem.ReadU8((c.A0 + 0x13u)); 
        c.V1 = mem.ReadU16(c.A2); 
        { var _s = c.V1; var _t = c.V0; c.V1 = _s - _t;  }
        { c.V1 = c.V1 + 0x14Au;  }
        mem.WriteU16((c.A0 + 0xAu), (ushort)c.V1); 
        c.V0 = mem.ReadU8(c.A2); 
        mem.WriteU8((c.A0 + 0x13u), (byte)c.V0); 
        L801B1818: ;
        c.A0 = mem.ReadU32(c.A0); 
        { c.V0 = (int)c.A1 < 32 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x0004u;  }
            goto L801B17D4;
        }
        { c.V0 = 0u | 0x0004u;  }
        c.At = 0x801C0000u; 
        mem.WriteU8((c.At + 0x24DFu), (byte)c.V0); 
        L801B1830: ;
        c.V1 = 0x801C0000u; 
        { c.V1 = c.V1 + 0x24DFu;  }
        c.V0 = mem.ReadU8(c.V1); 
        { c.V0 = c.V0 - 0x1u;  }
        mem.WriteU8(c.V1, (byte)c.V0); 
        L801B1848: ;
        c.RA = mem.ReadU32((c.SP + 0x44u)); 
        c.S4 = mem.ReadU32((c.SP + 0x40u)); 
        c.S3 = mem.ReadU32((c.SP + 0x3Cu)); 
        c.S2 = mem.ReadU32((c.SP + 0x38u)); 
        c.S1 = mem.ReadU32((c.SP + 0x34u)); 
        c.S0 = mem.ReadU32((c.SP + 0x30u)); 
        { c.SP = c.SP + 0x48u;  }
        return;
        }
    public static bool EntityRelicOrb_st0(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("st0", m, false)) return true;
        EntityRelicOrb_st0_Body(c, m);
        return false;
    }
    private static void EntityRelicOrb_st0_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "st0", 0x801C24CCu);
        { c.SP = c.SP - 0x48u;  }
        mem.WriteU32((c.SP + 0x30u), c.S2); 
        c.S2 = c.A0; 
        mem.WriteU32((c.SP + 0x44u), c.RA); 
        mem.WriteU32((c.SP + 0x40u), c.S6); 
        mem.WriteU32((c.SP + 0x3Cu), c.S5); 
        mem.WriteU32((c.SP + 0x38u), c.S4); 
        mem.WriteU32((c.SP + 0x34u), c.S3); 
        mem.WriteU32((c.SP + 0x2Cu), c.S1); 
        mem.WriteU32((c.SP + 0x28u), c.S0); 
        c.V0 = mem.ReadU16((c.S2 + 0x30u)); 
        c.V1 = mem.ReadU16((c.S2 + 0x2Cu)); 
        if (c.V1 == 0u) {
            { c.S5 = c.V0 & 0x7FFFu;  }
            goto L801B7368;
        }
        { c.S5 = c.V0 & 0x7FFFu;  }
        { c.V0 = c.V1 < 0x00000005u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.V0 = c.V1 < 0x0000000Au ? 1u : 0u;  }
            goto L801B7370;
        }
        { c.V0 = c.V1 < 0x0000000Au ? 1u : 0u;  }
        c.V0 = mem.ReadU8((c.S2 + 0x48u)); 
        if (c.V0 == 0u) {
            { c.V0 = 0u | 0x0005u;  }
            goto L801B7368;
        }
        { c.V0 = 0u | 0x0005u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        c.V1 = mem.ReadU16((c.S2 + 0x2Cu)); 
        L801B7368: ;
        { c.V0 = c.V1 < 0x0000000Au ? 1u : 0u;  }
        L801B7370: ;
        if (c.V0 == 0u) {
            { c.V0 = c.V1 << 2;  }
            goto L801B7A6C;
        }
        { c.V0 = c.V1 << 2;  }
        c.At = 0x801A0000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.V0 = mem.ReadU32((c.At + 0x7CD4u)); 
        switch (c.V0)
        {
            case 0x801B7390u: goto L801B7390;
            case 0x801B7A6Cu: goto L801B7A6C;
            case 0x801B752Cu: goto L801B752C;
            case 0x801B76B0u: goto L801B76B0;
            case 0x801B77BCu: goto L801B77BC;
            case 0x801B7874u: goto L801B7874;
            case 0x801B79F4u: goto L801B79F4;
            default: Dispatcher.Call(c, m, c.V0); return;
        }
        L801B7390: ;
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x580u;  }
        c.S0 = 0u; 
        c.RA = 0x801B73A0u; 
        SoTN_st0.InitializeEntity_st0(c, m);
        c.V1 = 0x801C0000u; 
        { c.V1 = c.V1 + 0x2584u;  }
        { c.V0 = c.S0 << 16;  }
        L801B73AC: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        { c.V0 = (uint)((int)c.V0 >> 15);  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        c.V0 = mem.ReadU16(c.V0); 
        if (c.V0 == 0u) {
            { c.V0 = c.S0 + 0x1u;  }
            goto L801B73DC;
        }
        { c.V0 = c.S0 + 0x1u;  }
        c.S0 = c.V0; 
        { c.V0 = c.V0 << 16;  }
        { c.V0 = (uint)((int)c.V0 >> 16);  }
        { c.V0 = (int)c.V0 < 32 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.V0 = c.S0 << 16;  }
            goto L801B73AC;
        }
        { c.V0 = c.S0 << 16;  }
        L801B73DC: ;
        { c.V0 = c.S0 << 16;  }
        { c.S3 = (uint)((int)c.V0 >> 16);  }
        { c.V0 = (int)c.S3 < 32 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.A0 = 0u | 0x0004u;  }
            goto L801B7418;
        }
        { c.A0 = 0u | 0x0004u;  }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3848u)); 
        { c.A1 = 0u | 0x0003u;  }
        c.RA = 0x801B7404u;
        Dispatcher.Call(c, m, c.V0);
        { c.V0 = c.V0 << 16;  }
        { c.S1 = (uint)((int)c.V0 >> 16);  }
        c.V0 = 0xFFFFFFFFu; 
        if (c.S1 != c.V0) {
            c.V1 = 0x00800000u; 
            goto L801B7420;
        }
        c.V1 = 0x00800000u; 
        L801B7418: ;
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)0u); 
        goto L801B7AE0;
        L801B7420: ;
        c.V0 = mem.ReadU32((c.S2 + 0x34u)); 
        mem.WriteU32((c.S2 + 0x64u), c.S1); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s | _t;  }
        { c.V1 = c.S5 & 0xFFFFu;  }
        mem.WriteU32((c.S2 + 0x34u), c.V0); 
        { c.V0 = c.V1 << 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        c.V1 = 0x80040000u; 
        c.V1 = mem.ReadU32((c.V1 - 0x37D0u)); 
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        c.A0 = mem.ReadU16((c.V0 + 0x2Cu)); 
        c.A1 = mem.ReadU16((c.V0 + 0x2Eu)); 
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x37D4u)); 
        c.A2 = c.S3; 
        c.RA = 0x801B7470u;
        Dispatcher.Call(c, m, c.V0);
        { c.V0 = c.S1 << 1;  }
        { var _s = c.V0; var _t = c.S1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.S1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.V1 = 0x80080000u; 
        { c.V1 = c.V1 + 0x6FECu;  }
        { var _s = c.V0; var _t = c.V1; c.A2 = _s + _t;  }
        if (c.A2 == 0u) {
            c.A3 = 0u; 
            goto L801B7A6C;
        }
        c.A3 = 0u; 
        { c.T4 = 0u | 0x0003u;  }
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
        L801B74CC: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        if (c.A3 == 0u) {
            { c.V0 = 0u | 0x0002u;  }
            goto L801B74E0;
        }
        { c.V0 = 0u | 0x0002u;  }
        mem.WriteU8((c.A2 + 0x7u), (byte)c.T4); 
        mem.WriteU16((c.A2 + 0x32u), (ushort)c.T3); 
        goto L801B750C;
        L801B74E0: ;
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
        L801B750C: ;
        { c.V0 = 0u | 0x00C0u;  }
        mem.WriteU16((c.A2 + 0x26u), (ushort)c.V0); 
        c.A2 = mem.ReadU32(c.A2); 
        if (c.A2 != 0u) {
            { c.A3 = c.A3 + 0x1u;  }
            goto L801B74CC;
        }
        { c.A3 = c.A3 + 0x1u;  }
        goto L801B7A6C;
        L801B752C: ;
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3824u)); 
        { c.A0 = 0u | 0x0618u;  }
        c.RA = 0x801B7540u;
        Dispatcher.Call(c, m, c.V0);
        { c.A0 = c.SP + 0x20u;  }
        c.A1 = 0u; 
        c.A2 = 0u; 
        c.A3 = 0u; 
        { c.V1 = c.S5 & 0xFFFFu;  }
        { c.V0 = 0u | 0x0003u;  }
        c.At = 0x80090000u; 
        { var _s = c.At; var _t = c.V1; c.At = _s + _t;  }
        mem.WriteU8((c.At + 0x7964u), (byte)c.V0); 
        { c.V0 = 0u | 0x0100u;  }
        mem.WriteU16((c.SP + 0x22u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0040u;  }
        mem.WriteU16((c.SP + 0x24u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0010u;  }
        mem.WriteU16((c.SP + 0x20u), (ushort)0u); 
        mem.WriteU16((c.SP + 0x26u), (ushort)c.V0); 
        c.RA = 0x801B7584u; 
        DialogueGlyphs.Clear(c, mem);
        c.V1 = mem.ReadU32((c.S2 + 0x64u)); 
        { c.V0 = c.V1 << 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.V1 = 0x80080000u; 
        { c.V1 = c.V1 + 0x6FECu;  }
        { var _s = c.V0; var _t = c.V1; c.A2 = _s + _t;  }
        if (c.A2 == 0u) {
            c.A3 = 0u; 
            goto L801B76A4;
        }
        c.A3 = 0u; 
        { c.A1 = 0u | 0x0010u;  }
        { c.V1 = 0u | 0x0080u;  }
        { c.A0 = 0u | 0x00A7u;  }
        L801B75C0: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        if (c.A3 != 0u) {
            { c.V0 = 0u | 0x0001u;  }
            goto L801B760C;
        }
        { c.V0 = 0u | 0x0001u;  }
        { c.V0 = 0u | 0x0006u;  }
        mem.WriteU8((c.A2 + 0x7u), (byte)c.V0); 
        { c.V0 = 0u | 0x00A0u;  }
        mem.WriteU16((c.A2 + 0xAu), (ushort)c.V0); 
        { c.V0 = 0u | 0x00F0u;  }
        mem.WriteU8((c.A2 + 0x18u), (byte)c.V0); 
        { c.V0 = 0u | 0x01F8u;  }
        mem.WriteU16((c.A2 + 0xEu), (ushort)c.V0); 
        { c.V0 = 0u | 0x01FEu;  }
        mem.WriteU16((c.A2 + 0x26u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0008u;  }
        mem.WriteU16((c.A2 + 0x1Au), (ushort)c.A1); 
        mem.WriteU16((c.A2 + 0x8u), (ushort)c.A1); 
        mem.WriteU8((c.A2 + 0xCu), (byte)0u); 
        mem.WriteU8((c.A2 + 0xDu), (byte)0u); 
        mem.WriteU8((c.A2 + 0x19u), (byte)c.A1); 
        goto L801B7690;
        L801B760C: ;
        mem.WriteU16((c.A2 + 0x2Cu), (ushort)c.V1); 
        mem.WriteU16((c.A2 + 0x20u), (ushort)c.V1); 
        mem.WriteU16((c.A2 + 0x14u), (ushort)c.V1); 
        mem.WriteU16((c.A2 + 0x8u), (ushort)c.V1); 
        mem.WriteU16((c.A2 + 0x2Eu), (ushort)c.A0); 
        mem.WriteU16((c.A2 + 0x22u), (ushort)c.A0); 
        mem.WriteU16((c.A2 + 0x16u), (ushort)c.A0); 
        mem.WriteU16((c.A2 + 0xAu), (ushort)c.A0); 
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
            goto L801B7674;
        }
        mem.WriteU8((c.A2 + 0x6u), (byte)0u); 
        mem.WriteU8((c.A2 + 0x2Au), (byte)c.V1); 
        mem.WriteU8((c.A2 + 0x1Eu), (byte)c.V1); 
        mem.WriteU8((c.A2 + 0x12u), (byte)c.V1); 
        mem.WriteU8((c.A2 + 0x6u), (byte)c.V1); 
        goto L801B7684;
        L801B7674: ;
        mem.WriteU8((c.A2 + 0x29u), (byte)c.V1); 
        mem.WriteU8((c.A2 + 0x1Du), (byte)c.V1); 
        mem.WriteU8((c.A2 + 0x11u), (byte)c.V1); 
        mem.WriteU8((c.A2 + 0x5u), (byte)c.V1); 
        L801B7684: ;
        { c.V0 = 0u | 0x01FDu;  }
        mem.WriteU16((c.A2 + 0x26u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0011u;  }
        L801B7690: ;
        mem.WriteU16((c.A2 + 0x32u), (ushort)c.V0); 
        c.A2 = mem.ReadU32(c.A2); 
        if (c.A2 != 0u) {
            { c.A3 = c.A3 + 0x1u;  }
            goto L801B75C0;
        }
        { c.A3 = c.A3 + 0x1u;  }
        L801B76A4: ;
        c.V0 = mem.ReadU16((c.S2 + 0x2Cu)); 
        { c.V0 = c.V0 + 0x1u;  }
        goto L801B79EC;
        L801B76B0: ;
        c.S1 = 0u; 
        c.S4 = 0u; 
        c.S3 = 0u; 
        c.S6 = 0x801C0000u; 
        { c.S6 = c.S6 + 0xB0u;  }
        c.V1 = 0x80040000u; 
        c.V1 = mem.ReadU32((c.V1 - 0x37B0u)); 
        { c.V0 = c.S5 << 4;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        c.S0 = mem.ReadU32(c.V0); 
        L801B76D8: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V1 = mem.ReadU8(c.S0); 
        if (c.V1 != 0u) {
            { c.S0 = c.S0 + 0x1u;  }
            goto L801B7704;
        }
        { c.S0 = c.S0 + 0x1u;  }
        if (c.S4 != 0u) {
            { c.S4 = 0u | 0x0001u;  }
            goto L801B77B0;
        }
        { c.S4 = 0u | 0x0001u;  }
        c.S0 = 0x80180000u; 
        c.S0 = mem.ReadU32((c.S0 + 0x1E5Cu)); 
        goto L801B76D8;
        L801B7704: ;
        c.V0 = mem.ReadU8(c.S0); 
        { c.S0 = c.S0 + 0x1u;  }
        { c.A1 = 0u | 0x0001u;  }
        { c.V1 = c.V1 << 8;  }
        { var _s = c.V0; var _t = c.V1; c.V1 = _s | _t;  }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3800u)); 
        { c.A0 = c.V1 & 0xFFFFu;  }
        c.RA = 0x801B772Cu;
        Dispatcher.Call(c, m, c.V0);
        c.A0 = c.V0; 
        if (c.A0 == 0u) {
            { c.V1 = c.S1 & 0xFFFFu;  }
            goto L801B76D8;
        }
        { c.V1 = c.S1 & 0xFFFFu;  }
        { c.V0 = c.V1 << 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 5;  }
        { var _s = c.V0; var _t = c.S6; c.V1 = _s + _t;  }
        c.A3 = 0u; 
        L801B774C: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V0 = mem.ReadU16(c.A0); 
        { c.A0 = c.A0 + 0x2u;  }
        { c.A3 = c.A3 + 0x1u;  }
        mem.WriteU16(c.V1, (ushort)c.V0); 
        { c.V0 = (int)c.A3 < 48 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.V1 = c.V1 + 0x2u;  }
            goto L801B774C;
        }
        { c.V1 = c.V1 + 0x2u;  }
        { c.V0 = c.S1 & 0xFFFFu;  }
        { c.A0 = c.V0 << 1;  }
        { var _s = c.A0; var _t = c.V0; c.A0 = _s + _t;  }
        { c.A0 = c.A0 << 5;  }
        { var _s = c.A0; var _t = c.S6; c.A0 = _s + _t;  }
        c.A1 = 0u; 
        c.A2 = 0u; 
        { c.A3 = c.S3 & 0xFFFFu;  }
        { c.V0 = 0u | 0x0100u;  }
        mem.WriteU32((c.SP + 0x10u), c.V0); 
        { c.V0 = 0u | 0x000Cu;  }
        mem.WriteU32((c.SP + 0x14u), c.V0); 
        { c.V0 = 0u | 0x0010u;  }
        mem.WriteU32((c.SP + 0x18u), c.V0); 
        c.RA = 0x801B77A4u; 
        SoTN_main.LoadTPage(c, m);
        { c.S3 = c.S3 + 0x3u;  }
        { c.S1 = c.S1 + 0x1u;  }
        goto L801B76D8;
        L801B77B0: ;
        c.V0 = mem.ReadU16((c.S2 + 0x2Cu)); 
        mem.WriteU16((c.S2 + 0x7Eu), (ushort)c.S1); 
        goto L801B79E4;
        L801B77BC: ;
        c.V1 = mem.ReadU32((c.S2 + 0x64u)); 
        { c.V0 = c.V1 << 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.At = 0x80080000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.A2 = mem.ReadU32((c.At + 0x6FECu)); 
        if (c.A2 == 0u) {
            c.A3 = 0u; 
            goto L801B79C4;
        }
        c.A3 = 0u; 
        L801B77F0: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        if (c.A3 != 0u) {
            goto L801B7824;
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
        goto L801B784C;
        L801B7824: ;
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
        L801B784C: ;
        mem.WriteU16((c.A2 + 0x16u), (ushort)c.A0); 
        mem.WriteU16((c.A2 + 0xAu), (ushort)c.A0); 
        mem.WriteU16((c.A2 + 0x2Eu), (ushort)c.A1); 
        mem.WriteU16((c.A2 + 0x22u), (ushort)c.A1); 
        c.A2 = mem.ReadU32(c.A2); 
        if (c.A2 != 0u) {
            { c.A3 = c.A3 + 0x1u;  }
            goto L801B77F0;
        }
        { c.A3 = c.A3 + 0x1u;  }
        goto L801B79C4;
        L801B7874: ;
        c.V1 = mem.ReadU32((c.S2 + 0x64u)); 
        { c.V0 = c.V1 << 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.At = 0x80080000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.A2 = mem.ReadU32((c.At + 0x6FECu)); 
        c.S4 = mem.ReadU16((c.S2 + 0x7Cu)); 
        if (c.A2 == 0u) {
            c.A3 = 0u; 
            goto L801B79C4;
        }
        c.A3 = 0u; 
        c.V0 = 0x92490000u; 
        { c.V0 = c.V0 | 0x2493u;  }
        { c.A1 = c.S4 & 0xFFFFu;  }
        { c.A0 = c.A1 << 4;  }
        { var _s = c.A0; var _t = c.A1; c.A0 = _s - _t;  }
        { c.A0 = c.A0 << 3;  }
        { var _s = c.A0; var _t = c.V0; var _r = (long)(int)_s * (int)_t; c.LO = (uint)_r; c.HI = (uint)(_r >> 32);  }
        { c.V1 = c.A1 + 0x1u;  }
        { c.V0 = c.V1 << 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { c.V1 = 0u | 0x0080u;  }
        { var _s = c.V1; var _t = c.V0; c.T1 = _s - _t;  }
        { c.T0 = c.V0 + 0x80u;  }
        { c.A1 = c.A1 << 1;  }
        c.V0 = c.HI; 
        { var _s = c.V0; var _t = c.A0; c.V0 = _s + _t;  }
        { c.V0 = (uint)((int)c.V0 >> 2);  }
        { c.A0 = (uint)((int)c.A0 >> 31);  }
        { var _s = c.V0; var _t = c.A0; c.A0 = _s - _t;  }
        L801B78F8: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        if (c.A3 != 0u) {
            { c.V0 = c.A0 + 0x68u;  }
            goto L801B7958;
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
        c.V0 = mem.ReadU16((c.At + 0x1E70u)); 
        { c.V0 = c.V0 + 0xA7u;  }
        mem.WriteU16((c.A2 + 0x16u), (ushort)c.V0); 
        mem.WriteU16((c.A2 + 0xAu), (ushort)c.V0); 
        c.V0 = mem.ReadU8((c.A2 + 0x2Au)); 
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.A1; c.At = _s + _t;  }
        c.V1 = mem.ReadU16((c.At + 0x1E60u)); 
        { c.V0 = c.V0 - 0x10u;  }
        { c.V1 = c.V1 + 0xA7u;  }
        mem.WriteU8((c.A2 + 0x2Au), (byte)c.V0); 
        mem.WriteU8((c.A2 + 0x1Eu), (byte)c.V0); 
        goto L801B79AC;
        L801B7958: ;
        mem.WriteU16((c.A2 + 0x8u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0098u;  }
        { var _s = c.V0; var _t = c.A0; c.V0 = _s - _t;  }
        mem.WriteU16((c.A2 + 0x14u), (ushort)c.V0); 
        mem.WriteU16((c.A2 + 0x2Cu), (ushort)c.T1); 
        mem.WriteU16((c.A2 + 0x20u), (ushort)c.T0); 
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.A1; c.At = _s + _t;  }
        c.V0 = mem.ReadU16((c.At + 0x1E80u)); 
        { c.V0 = c.V0 + 0xA7u;  }
        mem.WriteU16((c.A2 + 0x16u), (ushort)c.V0); 
        mem.WriteU16((c.A2 + 0xAu), (ushort)c.V0); 
        c.V0 = mem.ReadU8((c.A2 + 0x11u)); 
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.A1; c.At = _s + _t;  }
        c.V1 = mem.ReadU16((c.At + 0x1E90u)); 
        { c.V0 = c.V0 - 0x10u;  }
        { c.V1 = c.V1 + 0xA7u;  }
        mem.WriteU8((c.A2 + 0x11u), (byte)c.V0); 
        mem.WriteU8((c.A2 + 0x5u), (byte)c.V0); 
        L801B79AC: ;
        mem.WriteU16((c.A2 + 0x2Eu), (ushort)c.V1); 
        mem.WriteU16((c.A2 + 0x22u), (ushort)c.V1); 
        c.A2 = mem.ReadU32(c.A2); 
        if (c.A2 != 0u) {
            { c.A3 = c.A3 + 0x1u;  }
            goto L801B78F8;
        }
        { c.A3 = c.A3 + 0x1u;  }
        L801B79C4: ;
        c.V0 = mem.ReadU16((c.S2 + 0x7Cu)); 
        { c.V1 = 0u | 0x0008u;  }
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S2 + 0x7Cu), (ushort)c.V0); 
        { c.V0 = c.V0 & 0xFFFFu;  }
        if (c.V0 != c.V1) {
            goto L801B7A6C;
        }
        c.V0 = mem.ReadU16((c.S2 + 0x2Cu)); 
        L801B79E4: ;
        mem.WriteU16((c.S2 + 0x7Cu), (ushort)0u); 
        { c.V0 = c.V0 + 0x1u;  }
        L801B79EC: ;
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        goto L801B7A6C;
        L801B79F4: ;
        c.V1 = mem.ReadU32((c.S2 + 0x64u)); 
        c.A0 = mem.ReadU16((c.S2 + 0x7Eu)); 
        { c.V0 = c.V1 << 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.V1 = 0x80080000u; 
        { c.V1 = c.V1 + 0x6FECu;  }
        { var _s = c.V0; var _t = c.V1; c.A2 = _s + _t;  }
        { c.V1 = c.A0 << 1;  }
        { var _s = c.V1; var _t = c.A0; c.V1 = _s + _t;  }
        { c.V1 = c.V1 << 1;  }
        { c.V0 = 0u | 0x0080u;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s - _t;  }
        mem.WriteU16((c.A2 + 0x8u), (ushort)c.V0); 
        mem.WriteU16((c.A2 + 0x32u), (ushort)0u); 
        c.V0 = mem.ReadU16((c.S2 + 0x7Cu)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S2 + 0x7Cu), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S2 + 0x7Cu)); 
        { c.V0 = c.V0 < 0x00000101u ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L801B7A6C;
        }
        c.A0 = c.S2; 
        c.RA = 0x801B7A64u; 
        SoTN_st0.DestroyEntity_st0(c, m);
        goto L801B7AE0;
        L801B7A6C: ;
        c.V0 = mem.ReadU16((c.S2 + 0x2Cu)); 
        { c.V0 = c.V0 < 0x00000002u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L801B7AE0;
        }
        c.V1 = mem.ReadU32((c.S2 + 0x64u)); 
        c.A0 = 0x80080000u; 
        { c.A0 = c.A0 + 0x6FECu;  }
        { c.V0 = c.V1 << 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.V1 = mem.ReadU16((c.S2 + 0x2u)); 
        { var _s = c.V0; var _t = c.A0; c.A2 = _s + _t;  }
        { c.V0 = c.V1 - 0x7u;  }
        { c.V1 = c.V1 + 0x7u;  }
        mem.WriteU16((c.A2 + 0x20u), (ushort)c.V0); 
        mem.WriteU16((c.A2 + 0x8u), (ushort)c.V0); 
        mem.WriteU16((c.A2 + 0x2Cu), (ushort)c.V1); 
        mem.WriteU16((c.A2 + 0x14u), (ushort)c.V1); 
        c.V0 = mem.ReadU16((c.S2 + 0x6u)); 
        { c.V1 = c.V0 - 0x7u;  }
        { c.V0 = c.V0 + 0x7u;  }
        mem.WriteU16((c.A2 + 0x16u), (ushort)c.V1); 
        mem.WriteU16((c.A2 + 0xAu), (ushort)c.V1); 
        mem.WriteU16((c.A2 + 0x2Eu), (ushort)c.V0); 
        mem.WriteU16((c.A2 + 0x22u), (ushort)c.V0); 
        L801B7AE0: ;
        c.RA = mem.ReadU32((c.SP + 0x44u)); 
        c.S6 = mem.ReadU32((c.SP + 0x40u)); 
        c.S5 = mem.ReadU32((c.SP + 0x3Cu)); 
        c.S4 = mem.ReadU32((c.SP + 0x38u)); 
        c.S3 = mem.ReadU32((c.SP + 0x34u)); 
        c.S2 = mem.ReadU32((c.SP + 0x30u)); 
        c.S1 = mem.ReadU32((c.SP + 0x2Cu)); 
        c.S0 = mem.ReadU32((c.SP + 0x28u)); 
        { c.SP = c.SP + 0x48u;  }
        return;
        }
}
