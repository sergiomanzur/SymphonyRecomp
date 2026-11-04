using RecompOne.Runtime.Context;
using RecompOne.Runtime.Dispatch;
using RecompOne.Runtime.Memory;

namespace Recompiled.Translation;

public static class ScriptFunctions_lib
{
    public static bool func_us_801B11A0(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("lib", m, false)) return true;
        func_us_801B11A0_Body(c, m);
        return false;
    }
    private static void func_us_801B11A0_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "lib", 0x801D51D8u);
        { c.SP = c.SP - 0x20u;  }
        { c.A0 = c.A0 << 16;  }
        { c.V0 = (uint)((int)c.A0 >> 16);  }
        if ((int)c.V0 >= 0) {
            mem.WriteU32((c.SP + 0x18u), c.RA); 
            goto L801B11B8;
        }
        mem.WriteU32((c.SP + 0x18u), c.RA); 
        { c.V0 = c.V0 + 0x3u;  }
        L801B11B8: ;
        { c.V0 = (uint)((int)c.V0 >> 2);  }
        mem.WriteU16((c.SP + 0x10u), (ushort)c.V0); 
        { c.V0 = c.A2 & 0xFFFFu;  }
        { c.V0 = c.V0 >> 2;  }
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.SP + 0x14u), (ushort)c.V0); 
        { c.V0 = c.A3 + 0x1u;  }
        { c.A0 = c.SP + 0x10u;  }
        mem.WriteU16((c.SP + 0x12u), (ushort)c.A1); 
        c.A1 = 0u; 
        c.A2 = 0u; 
        c.A3 = 0u; 
        mem.WriteU16((c.SP + 0x16u), (ushort)c.V0); 
        c.RA = 0x801B11F0u; 
        DialogueGlyphs.Clear(c, mem);
        c.RA = mem.ReadU32((c.SP + 0x18u)); 
        { c.SP = c.SP + 0x20u;  }
        return;
        }
    public static bool CutsceneUnk1_lib(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("lib", m, true)) return true;
        CutsceneUnk1_lib_Body(c, m);
        return false;
    }
    private static void CutsceneUnk1_lib_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "lib", 0x801D51D8u);
        { c.V0 = 0u | 0x0042u;  }
        c.At = 0x801D0000u; 
        mem.WriteU16((c.At + 0x51E4u), (ushort)c.V0); 
        c.At = 0x801D0000u; 
        mem.WriteU16((c.At + 0x51E2u), (ushort)c.V0); 
        c.V0 = 0x801D0000u; 
        c.V0 = mem.ReadU16((c.V0 + 0x51E0u)); 
        { c.V1 = 0u | 0x0008u;  }
        c.At = 0x801D0000u; 
        mem.WriteU16((c.At + 0x51E6u), (ushort)0u); 
        c.At = 0x801D0000u; 
        mem.WriteU16((c.At + 0x51EAu), (ushort)0u); 
        c.At = 0x801D0000u; 
        mem.WriteU8((c.At + 0x51EEu), (byte)0u); 
        c.At = 0x801D0000u; 
        mem.WriteU8((c.At + 0x51EFu), (byte)c.V1); 
        { c.V0 = c.V0 + 0x14u;  }
        c.At = 0x801D0000u; 
        mem.WriteU16((c.At + 0x51DEu), (ushort)c.V0); 
        return;
        }
    public static bool SetCutsceneScript_lib(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("lib", m, true)) return true;
        SetCutsceneScript_lib_Body(c, m);
        return false;
    }
    private static void SetCutsceneScript_lib_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "lib", 0x801D51D8u);
        c.A0 = DialogueScripts.ResolveStart("lib", c.A0, m);
        { c.SP = c.SP - 0x20u;  }
        mem.WriteU32((c.SP + 0x14u), c.S1); 
        c.S1 = c.A0; 
        { c.A0 = 0u | 0x0006u;  }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3848u)); 
        { c.A1 = 0u | 0x0007u;  }
        mem.WriteU32((c.SP + 0x18u), c.RA); 
        mem.WriteU32((c.SP + 0x10u), c.S0); 
        c.RA = 0x801B9668u;
        Dispatcher.Call(c, m, c.V0);
        c.S0 = 0x801D0000u; 
        { c.S0 = c.S0 + 0x5210u;  }
        { c.V0 = c.V0 << 16;  }
        { c.V0 = (uint)((int)c.V0 >> 16);  }
        c.V1 = 0xFFFFFFFFu; 
        if (c.V0 != c.V1) {
            mem.WriteU32(c.S0, c.V0); 
            goto L801B9690;
        }
        mem.WriteU32(c.S0, c.V0); 
        mem.WriteU32(c.S0, 0u); 
        c.V0 = 0u; 
        goto L801B97EC;
        L801B9690: ;
        c.At = 0x801D0000u; 
        mem.WriteU32((c.At + 0x51D8u), c.S1); 
        c.At = 0x801D0000u; 
        mem.WriteU16((c.At + 0x5214u), (ushort)0u); 
        c.At = 0x801D0000u; 
        mem.WriteU32((c.At + 0x520Cu), c.V1); 
        c.At = 0x801D0000u; 
        mem.WriteU32((c.At + 0x5208u), c.V1); 
        c.RA = 0x801B96B8u; 
        SoTN_lib.CutsceneUnk1_lib(c, m);
        c.V1 = mem.ReadU32(c.S0); 
        { c.V0 = c.V1 << 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.V1 = 0x80080000u; 
        { c.V1 = c.V1 + 0x6FECu;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        c.At = 0x801D0000u; 
        mem.WriteU32((c.At + 0x51F0u), c.V0); 
        c.V1 = mem.ReadU32(c.V0); 
        { c.A2 = 0u | 0x0008u;  }
        mem.WriteU16((c.V0 + 0x32u), (ushort)c.A2); 
        c.At = 0x801D0000u; 
        mem.WriteU32((c.At + 0x51F4u), c.V1); 
        c.V0 = mem.ReadU32(c.V1); 
        mem.WriteU16((c.V1 + 0x32u), (ushort)c.A2); 
        c.At = 0x801D0000u; 
        mem.WriteU32((c.At + 0x51F8u), c.V0); 
        c.V1 = mem.ReadU32(c.V0); 
        mem.WriteU16((c.V0 + 0x32u), (ushort)c.A2); 
        c.At = 0x801D0000u; 
        mem.WriteU32((c.At + 0x51FCu), c.V1); 
        c.A0 = mem.ReadU32(c.V1); 
        mem.WriteU16((c.V1 + 0x32u), (ushort)c.A2); 
        c.At = 0x801D0000u; 
        mem.WriteU32((c.At + 0x5200u), c.A0); 
        c.A1 = mem.ReadU32(c.A0); 
        { c.V0 = 0u | 0x0001u;  }
        mem.WriteU16((c.A0 + 0x32u), (ushort)c.A2); 
        c.At = 0x801D0000u; 
        mem.WriteU32((c.At + 0x5204u), c.A1); 
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
        L801B97EC: ;
        c.RA = mem.ReadU32((c.SP + 0x18u)); 
        c.S1 = mem.ReadU32((c.SP + 0x14u)); 
        c.S0 = mem.ReadU32((c.SP + 0x10u)); 
        { c.SP = c.SP + 0x20u;  }
        return;
        }
    public static bool CutsceneUnk3_lib(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("lib", m, false)) return true;
        CutsceneUnk3_lib_Body(c, m);
        return false;
    }
    private static void CutsceneUnk3_lib_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "lib", 0x801D51D8u);
        { c.SP = c.SP - 0x20u;  }
        { c.V1 = 0u | 0x0040u;  }
        { c.A0 = c.A0 << 16;  }
        { c.A0 = (uint)((int)c.A0 >> 16);  }
        { c.V0 = c.A0 << 1;  }
        { var _s = c.V0; var _t = c.A0; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { c.V0 = c.V0 + 0x180u;  }
        mem.WriteU16((c.SP + 0x12u), (ushort)c.V0); 
        { c.V0 = 0u | 0x000Cu;  }
        { c.A0 = c.SP + 0x10u;  }
        c.A1 = 0u; 
        c.A2 = 0u; 
        c.A3 = 0u; 
        mem.WriteU32((c.SP + 0x18u), c.RA); 
        mem.WriteU16((c.SP + 0x10u), (ushort)c.V1); 
        mem.WriteU16((c.SP + 0x14u), (ushort)c.V1); 
        mem.WriteU16((c.SP + 0x16u), (ushort)c.V0); 
        c.RA = 0x801B9850u; 
        DialogueGlyphs.Clear(c, mem);
        c.RA = mem.ReadU32((c.SP + 0x18u)); 
        { c.SP = c.SP + 0x20u;  }
        return;
        }
    public static bool CutsceneUnk4_lib(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("lib", m, true)) return true;
        CutsceneUnk4_lib_Body(c, m);
        return false;
    }
    private static void CutsceneUnk4_lib_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "lib", 0x801D51D8u);
        DialogueGlyphs.PrepareLine(c, mem);
        { c.SP = c.SP - 0x18u;  }
        mem.WriteU32((c.SP + 0x10u), c.S0); 
        c.S0 = 0x801D0000u; 
        { c.S0 = c.S0 + 0x51E6u;  }
        mem.WriteU32((c.SP + 0x14u), c.RA); 
        c.A0 = (uint)(short)mem.ReadU16(c.S0); 
        c.RA = 0x801B9880u; 
        SoTN_lib.CutsceneUnk3_lib(c, m);
        c.V0 = (uint)(short)mem.ReadU16(c.S0); 
        { c.V0 = c.V0 << 2;  }
        { var _s = c.S0; var _t = c.V0; c.V0 = _s + _t;  }
        c.V1 = mem.ReadU32((c.V0 + 0xAu)); 
        { c.V0 = 0u | 0x0011u;  }
        mem.WriteU16((c.V1 + 0x1Au), (ushort)c.V0); 
        c.V0 = 0x801D0000u; 
        c.V0 = mem.ReadU16((c.V0 + 0x51ECu)); 
        mem.WriteU16((c.V1 + 0xEu), (ushort)c.V0); 
        c.V0 = 0x801D0000u; 
        c.V0 = mem.ReadU16((c.V0 + 0x51DEu)); 
        mem.WriteU8((c.V1 + 0xCu), (byte)0u); 
        mem.WriteU16((c.V1 + 0xAu), (ushort)c.V0); 
        c.V0 = 0x801D0000u; 
        c.V0 = mem.ReadU16((c.V0 + 0x51DCu)); 
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
    public static bool DrawCutsceneActorName_lib(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("lib", m, true)) return true;
        DrawCutsceneActorName_lib_Body(c, m);
        return false;
    }
    private static void DrawCutsceneActorName_lib_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "lib", 0x801D51D8u);
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
        c.A2 = mem.ReadU32((c.At + 0x1A60u)); 
        { c.V0 = 0u | 0x00FFu;  }
        L801B994C: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V1 = mem.ReadU8(c.A2); 
        if (c.V1 != c.V0) {
            { c.A2 = c.A2 + 0x1u;  }
            goto L801B996C;
        }
        { c.A2 = c.A2 + 0x1u;  }
        c.V1 = mem.ReadU8(c.A2); 
        if (c.V1 == 0u) {
            { c.A2 = c.A2 + 0x1u;  }
            goto L801B997C;
        }
        { c.A2 = c.A2 + 0x1u;  }
        L801B996C: ;
        if (c.V1 == 0u) {
            goto L801B994C;
        }
        { c.A1 = c.A1 + 0x1u;  }
        goto L801B994C;
        L801B997C: ;
        { c.A0 = 0u | 0x0006u;  }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3848u)); 
        { c.A1 = c.A1 & 0xFFFFu;  }
        c.RA = 0x801B9994u;
        Dispatcher.Call(c, m, c.V0);
        { c.V0 = c.V0 << 16;  }
        { c.A1 = (uint)((int)c.V0 >> 16);  }
        c.V0 = 0xFFFFFFFFu; 
        if (c.A1 != c.V0) {
            { c.V0 = c.A1 << 1;  }
            goto L801B99B8;
        }
        { c.V0 = c.A1 << 1;  }
        c.A0 = c.S1; 
        c.RA = 0x801B99B0u; 
        SoTN_lib.DestroyEntity_lib(c, m);
        goto L801B9A84;
        L801B99B8: ;
        { var _s = c.V0; var _t = c.A1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.A1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.V1 = 0x80080000u; 
        { c.V1 = c.V1 + 0x6FECu;  }
        { var _s = c.V0; var _t = c.V1; c.A0 = _s + _t;  }
        c.V1 = 0x801D0000u; 
        { c.V1 = c.V1 + 0x520Cu;  }
        { c.V0 = c.S0 & 0xFFFFu;  }
        { c.V0 = c.V0 << 2;  }
        mem.WriteU32(c.V1, c.A1); 
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.A2 = mem.ReadU32((c.At + 0x1A60u)); 
        if (c.A0 == 0u) {
            { c.A3 = 0u | 0x0038u;  }
            goto L801B9A84;
        }
        { c.A3 = 0u | 0x0038u;  }
        { c.T4 = 0u | 0x0006u;  }
        { c.T3 = 0u | 0x001Eu;  }
        { c.T2 = 0u | 0x0196u;  }
        { c.T1 = 0u | 0x01FFu;  }
        { c.A1 = 0u | 0x0008u;  }
        { c.T0 = c.V1 - 0x2Cu;  }
        L801B9A14: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V1 = mem.ReadU8(c.A2); 
        if (c.V1 != 0u) {
            { c.A2 = c.A2 + 0x1u;  }
            goto L801B9A2C;
        }
        { c.A2 = c.A2 + 0x1u;  }
        { c.A3 = c.A3 + 0x4u;  }
        goto L801B9A78;
        L801B9A2C: ;
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
        L801B9A78: ;
        if (c.A0 != 0u) {
            goto L801B9A14;
        }
        L801B9A84: ;
        c.RA = mem.ReadU32((c.SP + 0x18u)); 
        c.S1 = mem.ReadU32((c.SP + 0x14u)); 
        c.S0 = mem.ReadU32((c.SP + 0x10u)); 
        { c.SP = c.SP + 0x20u;  }
        return;
        }
    public static bool SetCutsceneEnd_lib(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("lib", m, true)) return true;
        SetCutsceneEnd_lib_Body(c, m);
        return false;
    }
    private static void SetCutsceneEnd_lib_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "lib", 0x801D51D8u);
        c.V0 = 0x00100000u; 
        { var _s = c.A0; var _t = c.V0; c.A0 = _s + _t;  }
        { c.V0 = 0u | 0x0001u;  }
        c.At = 0x801D0000u; 
        mem.WriteU32((c.At + 0x5218u), c.A0); 
        c.At = 0x801D0000u; 
        mem.WriteU16((c.At + 0x5216u), (ushort)0u); 
        c.At = 0x801D0000u; 
        mem.WriteU16((c.At + 0x5214u), (ushort)c.V0); 
        return;
        }
    public static bool CutsceneRun_lib(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("lib", m, true)) return true;
        CutsceneRun_lib_Body(c, m);
        return false;
    }
    private static void CutsceneRun_lib_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "lib", 0x801D51D8u);
        { c.SP = c.SP - 0x20u;  }
        c.A0 = 0x801D0000u; 
        { c.A0 = c.A0 + 0x5216u;  }
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
            goto L801B9B28;
        }
        { c.S1 = c.A0 + 0x2u;  }
        c.At = 0x801D0000u; 
        mem.WriteU16((c.At + 0x5214u), (ushort)0u); 
        goto L801B9D58;
        L801B9B18: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        mem.WriteU32(c.S1, c.A1); 
        goto L801B9D58;
        L801B9B20: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        mem.WriteU32(c.S1, c.A2); 
        goto L801B9D58;
        L801B9B28: ;
        { c.S2 = 0u | 0x0001u;  }
        L801B9B2C: ;
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
            goto L801B9B18;
        }
        { c.V0 = c.A1 + 0x3u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.V1 = mem.ReadU8((c.A1 + 0x2u)); 
        if (c.V1 == c.S2) {
            { c.V0 = (int)c.V1 < 2 ? 1u : 0u;  }
            goto L801B9CA4;
        }
        { c.V0 = (int)c.V1 < 2 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L801B9B8C;
        }
        if (c.V1 == 0u) {
            { c.V0 = c.A1 + 0x4u;  }
            goto L801B9BA8;
        }
        { c.V0 = c.A1 + 0x4u;  }
        goto L801B9B2C;
        L801B9B8C: ;
        { c.V0 = 0u | 0x0002u;  }
        if (c.V1 == c.V0) {
            { c.V0 = 0u | 0x0003u;  }
            goto L801B9CE0;
        }
        { c.V0 = 0u | 0x0003u;  }
        if (c.V1 == c.V0) {
            { c.V0 = c.A1 + 0x4u;  }
            goto L801B9D30;
        }
        { c.V0 = c.A1 + 0x4u;  }
        goto L801B9B2C;
        L801B9BA8: ;
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
        c.RA = 0x801B9BDCu; 
        SoTN_lib.DestroyEntity_lib(c, m);
        c.V1 = mem.ReadU32(c.S1); 
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.V0 = mem.ReadU8(c.V1); 
        mem.WriteU16((c.S0 + 0x26u), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S0 + 0x26u)); 
        { c.V0 = c.V0 << 2;  }
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.V0 = mem.ReadU32((c.At + 0x6C4u)); 
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
        goto L801B9B2C;
        L801B9CA4: ;
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
        c.RA = 0x801B9CD8u; 
        SoTN_lib.DestroyEntity_lib(c, m);
        goto L801B9B2C;
        L801B9CE0: ;
        c.V0 = 0x801D0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x5218u)); 
        c.V1 = 0x801D0000u; 
        c.V1 = mem.ReadU32((c.V1 + 0x5284u)); 
        c.V0 = mem.ReadU8(c.V0); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _t >> (int)(_s & 31u);  }
        { c.V0 = c.V0 & 0x0001u;  }
        if (c.V0 == 0u) {
            { c.V0 = c.A1 + 0x4u;  }
            goto L801B9B20;
        }
        { c.V0 = c.A1 + 0x4u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.V0 = mem.ReadU8((c.A1 + 0x3u)); 
        { var _s = c.V0; var _t = c.S2; c.V0 = _t << (int)(_s & 31u);  }
        { var _s = 0u; var _t = c.V0; c.V0 = ~(_s | _t);  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s & _t;  }
        c.At = 0x801D0000u; 
        mem.WriteU32((c.At + 0x5284u), c.V0); 
        goto L801B9B2C;
        L801B9D30: ;
        mem.WriteU32(c.S1, c.V0); 
        c.V0 = mem.ReadU8((c.A1 + 0x3u)); 
        c.V1 = 0x801D0000u; 
        c.V1 = mem.ReadU32((c.V1 + 0x5284u)); 
        { var _s = c.V0; var _t = c.S2; c.V0 = _t << (int)(_s & 31u);  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s | _t;  }
        c.At = 0x801D0000u; 
        mem.WriteU32((c.At + 0x5284u), c.V0); 
        goto L801B9B2C;
        L801B9D58: ;
        c.RA = mem.ReadU32((c.SP + 0x1Cu)); 
        c.S2 = mem.ReadU32((c.SP + 0x18u)); 
        c.S1 = mem.ReadU32((c.SP + 0x14u)); 
        c.S0 = mem.ReadU32((c.SP + 0x10u)); 
        { c.SP = c.SP + 0x20u;  }
        return;
        }
    public static bool CutsceneSkip_lib(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("lib", m, true)) return true;
        CutsceneSkip_lib_Body(c, m);
        return false;
    }
    private static void CutsceneSkip_lib_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "lib", 0x801D51D8u);
        { c.SP = c.SP - 0x20u;  }
        mem.WriteU32((c.SP + 0x10u), c.S0); 
        c.S0 = c.A0; 
        c.V1 = 0x80090000u; 
        c.V1 = mem.ReadU16((c.V1 + 0x7494u)); 
        { c.V0 = 0u | 0x0800u;  }
        mem.WriteU32((c.SP + 0x1Cu), c.RA); 
        mem.WriteU32((c.SP + 0x18u), c.S2); 
        if (c.V1 != c.V0) {
            mem.WriteU32((c.SP + 0x14u), c.S1); 
            goto L801B9E38;
        }
        mem.WriteU32((c.SP + 0x14u), c.S1); 
        c.S1 = 0x80040000u; 
        { c.S1 = c.S1 - 0x384Cu;  }
        c.A0 = mem.ReadU32((c.S0 + 0x64u)); 
        c.V1 = mem.ReadU32(c.S1); 
        { c.V0 = 0u | 0x0001u;  }
        c.At = 0x801D0000u; 
        mem.WriteU32((c.At + 0x51D4u), c.V0); 
        c.S2 = 0xFFFFFFFFu; 
        c.RA = 0x801B9DC0u;
        Dispatcher.Call(c, m, c.V1);
        c.V0 = mem.ReadU32((c.S0 + 0x34u)); 
        c.V1 = 0x00800000u; 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s ^ _t;  }
        mem.WriteU32((c.S0 + 0x34u), c.V0); 
        c.A0 = 0x801D0000u; 
        c.A0 = mem.ReadU32((c.A0 + 0x520Cu)); 
        if (c.A0 == c.S2) {
            goto L801B9DF4;
        }
        c.V0 = mem.ReadU32(c.S1); 
        c.RA = 0x801B9DF4u;
        Dispatcher.Call(c, m, c.V0);
        L801B9DF4: ;
        c.A0 = 0x801D0000u; 
        c.A0 = mem.ReadU32((c.A0 + 0x5208u)); 
        if (c.A0 == c.S2) {
            goto L801B9E18;
        }
        c.V0 = mem.ReadU32(c.S1); 
        c.RA = 0x801B9E18u;
        Dispatcher.Call(c, m, c.V0);
        L801B9E18: ;
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3824u)); 
        { c.A0 = 0u | 0x000Au;  }
        c.RA = 0x801B9E2Cu;
        Dispatcher.Call(c, m, c.V0);
        { c.V0 = 0u | 0x0001u;  }
        mem.WriteU16((c.S0 + 0x2Cu), (ushort)c.V0); 
        mem.WriteU16((c.S0 + 0x2Eu), (ushort)0u); 
        L801B9E38: ;
        c.RA = mem.ReadU32((c.SP + 0x1Cu)); 
        c.S2 = mem.ReadU32((c.SP + 0x18u)); 
        c.S1 = mem.ReadU32((c.SP + 0x14u)); 
        c.S0 = mem.ReadU32((c.SP + 0x10u)); 
        { c.SP = c.SP + 0x20u;  }
        return;
        }
    public static bool ScaleCutsceneAvatar_lib(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("lib", m, true)) return true;
        ScaleCutsceneAvatar_lib_Body(c, m);
        return false;
    }
    private static void ScaleCutsceneAvatar_lib_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "lib", 0x801D51D8u);
        c.V0 = 0x801D0000u; 
        c.V0 = (uint)(short)mem.ReadU16((c.V0 + 0x51E6u)); 
        { c.A3 = c.V0 + (uint)(mem.LineCount - DialogueGlyphs.VisibleLines(mem));  }
        { c.V0 = (int)c.A3 < 5 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L801B9E84;
        }
        { c.A3 = c.A3 - 0x5u;  }
        L801B9E74: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        { c.V0 = (int)c.A3 < 5 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.A3 = c.A3 - 0x5u;  }
            goto L801B9E74;
        }
        { c.A3 = c.A3 - 0x5u;  }
        { c.A3 = c.A3 + 0x5u;  }
        L801B9E84: ;
        c.V0 = 0x80070000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3C48u)); 
        c.V0 = mem.ReadU16((c.V0 + 0x2Eu)); 
        if (c.V0 != 0u) {
            c.V1 = 0u; 
            goto L801B9F00;
        }
        c.V1 = 0u; 
        { c.V0 = c.A3 << 2;  }
        c.At = 0x801D0000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.A1 = mem.ReadU32((c.At + 0x51F0u)); 
        c.V0 = mem.ReadU8((c.A1 + 0x19u)); 
        { var _s = c.V0; var _t = c.A0; c.V0 = _s - _t;  }
        mem.WriteU8((c.A1 + 0x19u), (byte)c.V0); 
        c.V0 = mem.ReadU8((c.A1 + 0xDu)); 
        c.V1 = mem.ReadU8((c.A1 + 0x19u)); 
        { var _s = c.A0; var _t = c.V0; c.V0 = _s + _t;  }
        if (c.V1 != 0u) {
            mem.WriteU8((c.A1 + 0xDu), (byte)c.V0); 
            goto L801B9EFC;
        }
        mem.WriteU8((c.A1 + 0xDu), (byte)c.V0); 
        c.V0 = 0x80070000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3C48u)); 
        c.V1 = mem.ReadU16((c.V0 + 0x2Eu)); 
        { c.V1 = c.V1 + 0x1u;  }
        mem.WriteU16((c.V0 + 0x2Eu), (ushort)c.V1); 
        { c.V0 = 0u | 0x0008u;  }
        mem.WriteU16((c.A1 + 0x32u), (ushort)c.V0); 
        L801B9EFC: ;
        c.V1 = 0u; 
        L801B9F00: ;
        { c.A0 = c.A0 & 0x00FFu;  }
        c.A2 = 0x801D0000u; 
        { c.A2 = c.A2 + 0x51F0u;  }
        L801B9F0C: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        if (c.V1 == c.A3) {
            goto L801B9F2C;
        }
        c.A1 = mem.ReadU32(c.A2); 
        c.V0 = mem.ReadU16((c.A1 + 0xAu)); 
        { var _s = c.V0; var _t = c.A0; c.V0 = _s - _t;  }
        mem.WriteU16((c.A1 + 0xAu), (ushort)c.V0); 
        L801B9F2C: ;
        { c.V1 = c.V1 + 0x1u;  }
        { c.V0 = (int)c.V1 < 5 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.A2 = c.A2 + 0x4u;  }
            goto L801B9F0C;
        }
        { c.A2 = c.A2 + 0x4u;  }
        c.V1 = 0x801D0000u; 
        { c.V1 = c.V1 + 0x51E8u;  }
        c.V0 = mem.ReadU16(c.V1); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16(c.V1, (ushort)c.V0); 
        return;
        }
    public static bool LIB_EntityCutscene(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("lib", m, true)) return true;
        LIB_EntityCutscene_Body(c, m);
        return false;
    }
    private static void LIB_EntityCutscene_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "lib", 0x801D51D8u);
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
            goto L801BA010;
        }
        c.V0 = 0x801D0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x5288u)); 
        if (c.V0 == 0u) {
            goto L801B9FE4;
        }
        c.V0 = 0x801D0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x51D4u)); 
        if (c.V0 != 0u) {
            goto L801B9FE4;
        }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x4220u)); 
        if (c.V0 != 0u) {
            goto L801B9FDC;
        }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x34FCu)); 
        { c.V0 = c.V0 & 0x0008u;  }
        if (c.V0 == 0u) {
            goto L801B9FE4;
        }
        L801B9FDC: ;
        c.A0 = c.S2; 
        c.RA = 0x801B9FE4u; 
        Dispatcher.Call(c, m, 0x801B9D74u);
        L801B9FE4: ;
        c.V0 = mem.ReadU16((c.S2 + 0x2Cu)); 
        if (c.V0 == 0u) {
            goto L801BA010;
        }
        c.V0 = 0x801D0000u; 
        c.V0 = mem.ReadU16((c.V0 + 0x5214u)); 
        if (c.V0 == 0u) {
            goto L801BA010;
        }
        c.RA = 0x801BA010u; 
        SoTN_lib.CutsceneRun_lib(c, m);
        L801BA010: ;
        c.V1 = mem.ReadU16((c.S2 + 0x2Cu)); 
        { c.V0 = c.V1 < 0x00000008u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.V0 = c.V1 << 2;  }
            goto L801BAF3C;
        }
        { c.V0 = c.V1 << 2;  }
        c.At = 0x801B0000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.V0 = mem.ReadU32((c.At - 0x2880u)); 
        switch (c.V0)
        {
            case 0x801BA03Cu: goto L801BA03C;
            case 0x801BA0D4u: goto L801BA0D4;
            case 0x801BA9C8u: goto L801BA9C8;
            case 0x801BA9FCu: goto L801BA9FC;
            case 0x801BAAE8u: goto L801BAAE8;
            case 0x801BAB54u: goto L801BAB54;
            case 0x801BAE3Cu: goto L801BAE3C;
            case 0x801BAF14u: goto L801BAF14;
            case 0x801BA14Cu: goto L801BA14C;
            case 0x801BA158u: goto L801BA158;
            case 0x801BA204u: goto L801BA204;
            case 0x801BA230u: goto L801BA230;
            case 0x801BA260u: goto L801BA260;
            case 0x801BA2A0u: goto L801BA2A0;
            case 0x801BA3D8u: goto L801BA3D8;
            case 0x801BA450u: goto L801BA450;
            case 0x801BA4E4u: goto L801BA4E4;
            case 0x801BA50Cu: goto L801BA50C;
            case 0x801BA534u: goto L801BA534;
            case 0x801BA56Cu: goto L801BA56C;
            case 0x801BA5B4u: goto L801BA5B4;
            case 0x801BA0E8u: goto L801BA0E8;
            case 0x801BA610u: goto L801BA610;
            case 0x801BA67Cu: goto L801BA67C;
            case 0x801BA6DCu: goto L801BA6DC;
            case 0x801BA728u: goto L801BA728;
            case 0x801BA75Cu: goto L801BA75C;
            case 0x801BA76Cu: goto L801BA76C;
            case 0x801BA82Cu: goto L801BA82C;
            case 0x801BA868u: goto L801BA868;
            case 0x801BA888u: goto L801BA888;
            case 0x801BAF3Cu: goto L801BAF3C;
            case 0x801BA8C4u: goto L801BA8C4;
            default: Dispatcher.Call(c, m, c.V0); return;
        }
        L801BA03C: ;
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU8((c.V0 - 0x41A2u)); 
        if (c.V0 == 0u) {
            { c.V0 = 0u | 0x0001u;  }
            goto L801BA060;
        }
        { c.V0 = 0u | 0x0001u;  }
        c.At = 0x80180000u; 
        mem.WriteU8((c.At + 0x3F60u), (byte)c.V0); 
        goto L801BA068;
        L801BA060: ;
        c.At = 0x80180000u; 
        mem.WriteU8((c.At + 0x3F60u), (byte)0u); 
        L801BA068: ;
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x3F68u;  }
        c.RA = 0x801BA078u; 
        SoTN_lib.SetCutsceneScript_lib(c, m);
        { c.V0 = c.V0 & 0x00FFu;  }
        if (c.V0 == 0u) {
            c.A0 = 0x00800000u; 
            goto L801BAF3C;
        }
        c.A0 = 0x00800000u; 
        { c.A0 = c.A0 | 0x2000u;  }
        c.V0 = mem.ReadU32((c.S2 + 0x34u)); 
        { c.V1 = 0u | 0x0001u;  }
        c.At = 0x801D0000u; 
        mem.WriteU32((c.At + 0x5284u), 0u); 
        c.At = 0x801D0000u; 
        mem.WriteU32((c.At + 0x5288u), 0u); 
        c.At = 0x801D0000u; 
        mem.WriteU32((c.At + 0x51D4u), 0u); 
        c.At = 0x80040000u; 
        mem.WriteU32((c.At - 0x38FCu), c.V1); 
        { var _s = c.V0; var _t = c.A0; c.V0 = _s | _t;  }
        mem.WriteU32((c.S2 + 0x34u), c.V0); 
        c.V0 = mem.ReadU16((c.S2 + 0x2Cu)); 
        c.V1 = 0x801D0000u; 
        c.V1 = mem.ReadU32((c.V1 + 0x5210u)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        mem.WriteU32((c.S2 + 0x64u), c.V1); 
        goto L801BAF3C;
        L801BA0D4: ;
        c.S4 = 0x801D0000u; 
        { c.S4 = c.S4 + 0x51EEu;  }
        { c.S1 = c.S4 - 0x16u;  }
        { c.S0 = c.S4 - 0xCu;  }
        { c.S3 = c.S4 - 0x12u;  }
        L801BA0E8: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V0 = mem.ReadU8(c.S4); 
        if (c.V0 == 0u) {
            goto L801BA10C;
        }
        c.V0 = 0x801D0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x51D4u)); 
        if (c.V0 == 0u) {
            goto L801BAEE4;
        }
        L801BA10C: ;
        c.V0 = mem.ReadU32(c.S1); 
        { c.V1 = c.V0 + 0x1u;  }
        mem.WriteU32(c.S1, c.V1); 
        c.A2 = mem.ReadU8(c.V0); 
        { c.V1 = c.A2 & 0xFFFFu;  }
        { c.V0 = c.V1 < 0x00000019u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.V0 = c.V1 << 2;  }
            goto L801BA904;
        }
        { c.V0 = c.V1 << 2;  }
        c.At = 0x801B0000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.V0 = mem.ReadU32((c.At - 0x2860u)); 
        switch (c.V0)
        {
            case 0x801BA14Cu: goto L801BA14C;
            case 0x801BA158u: goto L801BA158;
            case 0x801BA204u: goto L801BA204;
            case 0x801BA230u: goto L801BA230;
            case 0x801BA260u: goto L801BA260;
            case 0x801BA2A0u: goto L801BA2A0;
            case 0x801BA3D8u: goto L801BA3D8;
            case 0x801BA450u: goto L801BA450;
            case 0x801BA4E4u: goto L801BA4E4;
            case 0x801BA50Cu: goto L801BA50C;
            case 0x801BA534u: goto L801BA534;
            case 0x801BA56Cu: goto L801BA56C;
            case 0x801BA5B4u: goto L801BA5B4;
            case 0x801BA0E8u: goto L801BA0E8;
            case 0x801BA610u: goto L801BA610;
            case 0x801BA67Cu: goto L801BA67C;
            case 0x801BA6DCu: goto L801BA6DC;
            case 0x801BA728u: goto L801BA728;
            case 0x801BA75Cu: goto L801BA75C;
            case 0x801BA76Cu: goto L801BA76C;
            case 0x801BA82Cu: goto L801BA82C;
            case 0x801BA868u: goto L801BA868;
            case 0x801BA888u: goto L801BA888;
            case 0x801BAF3Cu: goto L801BAF3C;
            case 0x801BA8C4u: goto L801BA8C4;
            default: Dispatcher.Call(c, m, c.V0); return;
        }
        L801BA14C: ;
        { c.V0 = 0u | 0x0007u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        goto L801BAF3C;
        L801BA158: ;
        c.V0 = 0x801D0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x51D4u)); 
        if (c.V0 != 0u) {
            goto L801BA0E8;
        }
        c.V0 = mem.ReadU16((c.S0 + 0x8u)); 
        c.V1 = mem.ReadU16((c.S0 + 0x2u)); 
        { c.V0 = c.V0 & 0x0001u;  }
        if (c.V0 != 0u) {
            mem.WriteU16(c.S0, (ushort)c.V1); 
            goto L801BA190;
        }
        mem.WriteU16(c.S0, (ushort)c.V1); 
        c.V0 = mem.ReadU16((c.S0 - 0x4u)); 
        { c.V0 = c.V0 + 0xCu;  }
        mem.WriteU16((c.S0 - 0x4u), (ushort)c.V0); 
        L801BA190: ;
        c.V0 = mem.ReadU16((c.S0 + 0x4u)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S0 + 0x4u), (ushort)c.V0); 
        { c.V0 = c.V0 << 16;  }
        { c.V0 = (uint)((int)c.V0 >> 16);  }
        { c.V0 = (int)c.V0 < 5 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L801BA1B8;
        }
        mem.WriteU16((c.S0 + 0x4u), (ushort)0u); 
        L801BA1B8: ;
        c.RA = 0x801BA1C0u; 
        SoTN_lib.CutsceneUnk4_lib(c, m);
        c.V1 = mem.ReadU16((c.S0 + 0x8u)); 
        { c.V0 = c.V1 & 0x0001u;  }
        if (c.V0 != 0u) {
            goto L801BA1EC;
        }
        c.V0 = (uint)(short)mem.ReadU16((c.S0 + 0x4u)); 
        { c.V0 = (int)c.V0 < 4 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.V0 = c.V1 | 0x0001u;  }
            goto L801BA0E8;
        }
        { c.V0 = c.V1 | 0x0001u;  }
        mem.WriteU16((c.S0 + 0x8u), (ushort)c.V0); 
        L801BA1EC: ;
        mem.WriteU16((c.S0 + 0x6u), (ushort)0u); 
        c.V0 = mem.ReadU16((c.S2 + 0x2Cu)); 
        mem.WriteU16((c.S2 + 0x2Eu), (ushort)0u); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        goto L801BAF3C;
        L801BA204: ;
        c.V0 = 0x801D0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x51D8u)); 
        { c.V1 = c.V0 + 0x1u;  }
        c.At = 0x801D0000u; 
        mem.WriteU32((c.At + 0x51D8u), c.V1); 
        c.V0 = mem.ReadU8(c.V0); 
        c.At = 0x801D0000u; 
        mem.WriteU8((c.At + 0x51EFu), (byte)c.V0); 
        goto L801BA0E8;
        L801BA230: ;
        c.V1 = mem.ReadU32((c.S4 - 0x16u)); 
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU32((c.S4 - 0x16u), c.V0); 
        c.V0 = mem.ReadU8(c.V1); 
        c.V1 = 0x801D0000u; 
        c.V1 = mem.ReadU32((c.V1 + 0x51D4u)); 
        if (c.V1 != 0u) {
            mem.WriteU8(c.S4, (byte)c.V0); 
            goto L801BA0E8;
        }
        mem.WriteU8(c.S4, (byte)c.V0); 
        goto L801BAF3C;
        L801BA260: ;
        c.V0 = 0x801D0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x51D4u)); 
        if (c.V0 != 0u) {
            { c.V1 = 0u | 0x0008u;  }
            goto L801BA0E8;
        }
        { c.V1 = 0u | 0x0008u;  }
        c.S1 = 0x801D0000u; 
        c.S1 = mem.ReadU32((c.S1 + 0x51F0u)); 
        c.S0 = 0u; 
        { c.S0 = c.S0 + 0x1u;  }
        L801BA284: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        { c.V0 = (int)c.S0 < 5 ? 1u : 0u;  }
        mem.WriteU16((c.S1 + 0x32u), (ushort)c.V1); 
        c.S1 = mem.ReadU32(c.S1); 
        if (c.V0 != 0u) {
            { c.S0 = c.S0 + 0x1u;  }
            goto L801BA284;
        }
        { c.S0 = c.S0 + 0x1u;  }
        goto L801BAF3C;
        L801BA2A0: ;
        c.V0 = 0x801D0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x51D4u)); 
        if (c.V0 != 0u) {
            goto L801BA520;
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
        c.A0 = mem.ReadU8((c.At + 0x19BCu)); 
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.A1 = mem.ReadU8((c.At + 0x19C0u)); 
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.V1; c.At = _s + _t;  }
        c.V1 = mem.ReadU16((c.At + 0x19C4u)); 
        { c.V0 = 0u | 0x0091u;  }
        mem.WriteU16((c.S1 + 0x1Au), (ushort)c.V0); 
        { c.V0 = c.T2 & 0x0080u;  }
        if (c.V0 == 0u) {
            mem.WriteU16((c.S1 + 0xEu), (ushort)c.V1); 
            goto L801BA324;
        }
        mem.WriteU16((c.S1 + 0xEu), (ushort)c.V1); 
        c.V1 = c.A0; 
        { c.V0 = c.V1 + 0x2Fu;  }
        goto L801BA32C;
        L801BA324: ;
        c.V0 = c.A0; 
        { c.V1 = c.V0 + 0x2Fu;  }
        L801BA32C: ;
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
        c.V0 = mem.ReadU16((c.At + 0x19CCu)); 
        mem.WriteU16((c.S3 + 0x10u), (ushort)c.V0); 
        c.RA = 0x801BA3A4u; 
        SoTN_lib.CutsceneUnk1_lib(c, m);
        c.RA = 0x801BA3ACu; 
        SoTN_lib.CutsceneUnk4_lib(c, m);
        { c.A0 = c.S0 & 0xFFFFu;  }
        c.A1 = c.S2; 
        { c.V0 = 0u | 0x01FEu;  }
        mem.WriteU16((c.S1 + 0x26u), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x32u), (ushort)0u); 
        c.RA = 0x801BA3C4u; 
        SoTN_lib.DrawCutsceneActorName_lib(c, m);
        { c.V0 = 0u | 0x0006u;  }
        mem.WriteU16((c.S3 + 0xCu), (ushort)c.V0); 
        { c.V0 = 0u | 0x0003u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        goto L801BAF3C;
        L801BA3D8: ;
        c.V0 = 0x801D0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x51D4u)); 
        if (c.V0 != 0u) {
            { c.V1 = 0u | 0x0008u;  }
            goto L801BA0E8;
        }
        { c.V1 = 0u | 0x0008u;  }
        c.S1 = 0x801D0000u; 
        c.S1 = mem.ReadU32((c.S1 + 0x51F0u)); 
        c.S0 = 0u; 
        { c.S0 = c.S0 + 0x1u;  }
        L801BA3FC: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        { c.V0 = (int)c.S0 < 5 ? 1u : 0u;  }
        mem.WriteU16((c.S1 + 0x32u), (ushort)c.V1); 
        c.S1 = mem.ReadU32(c.S1); 
        if (c.V0 != 0u) {
            { c.S0 = c.S0 + 0x1u;  }
            goto L801BA3FC;
        }
        { c.S0 = c.S0 + 0x1u;  }
        c.S0 = 0x801D0000u; 
        { c.S0 = c.S0 + 0x520Cu;  }
        c.A0 = mem.ReadU32(c.S0); 
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x384Cu)); 
        c.RA = 0x801BA430u;
        Dispatcher.Call(c, m, c.V0);
        c.V0 = 0xFFFFFFFFu; 
        mem.WriteU32(c.S0, c.V0); 
        { c.V0 = 0u | 0x0006u;  }
        c.At = 0x801D0000u; 
        mem.WriteU16((c.At + 0x51E8u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0004u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        goto L801BAF3C;
        L801BA450: ;
        c.V0 = 0x801D0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x51D4u)); 
        if (c.V0 != 0u) {
            goto L801BA520;
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
        goto L801BAF3C;
        L801BA4E4: ;
        c.V0 = 0x801D0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x51D4u)); 
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x0018u;  }
            goto L801BA0E8;
        }
        { c.V0 = 0u | 0x0018u;  }
        c.At = 0x801D0000u; 
        mem.WriteU16((c.At + 0x51E8u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0006u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        goto L801BAF3C;
        L801BA50C: ;
        c.V0 = 0x801D0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x51D4u)); 
        if (c.V0 == 0u) {
            goto L801BA82C;
        }
        L801BA520: ;
        c.V0 = mem.ReadU32(c.S1); 
        { c.V0 = c.V0 + 0x2u;  }
        mem.WriteU32(c.S1, c.V0); 
        goto L801BA0E8;
        L801BA534: ;
        c.V0 = 0x801D0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x51D4u)); 
        if (c.V0 != 0u) {
            goto L801BA0E8;
        }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3808u)); 
        c.RA = 0x801BA55Cu;
        Dispatcher.Call(c, m, c.V0);
        if (c.V0 == 0u) {
            goto L801BA5A0;
        }
        goto L801BA0E8;
        L801BA56C: ;
        c.V0 = 0x801D0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x51D4u)); 
        if (c.V0 != 0u) {
            goto L801BA0E8;
        }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3808u)); 
        c.RA = 0x801BA594u;
        Dispatcher.Call(c, m, c.V0);
        { c.V1 = 0u | 0x0001u;  }
        if (c.V0 != c.V1) {
            goto L801BA0E8;
        }
        L801BA5A0: ;
        c.V0 = mem.ReadU32(c.S1); 
        { c.V0 = c.V0 - 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        goto L801BAF3C;
        L801BA5B4: ;
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
        c.RA = 0x801BA608u; 
        SoTN_lib.SetCutsceneEnd_lib(c, m);
        goto L801BA0E8;
        L801BA610: ;
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
        c.At = 0x00100000u; 
        { var _s = c.T1; var _t = c.At; c.At = _s + _t;  }
        c.V1 = mem.ReadU8(c.At); 
        { c.V1 = c.V1 << 2;  }
        { var _s = c.V1; var _t = c.A1; c.V1 = _s + _t;  }
        goto L801BA680;
        L801BA67C: ;
        c.V1 = mem.ReadU32(c.S1); 
        L801BA680: ;
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.T1 = mem.ReadU8(c.V1); 
        { c.V0 = c.V1 + 0x2u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.A0 = mem.ReadU8((c.V1 + 0x1u)); 
        { c.V0 = c.V1 + 0x3u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.V0 = mem.ReadU8((c.V1 + 0x2u)); 
        c.V1 = 0x801D0000u; 
        c.V1 = mem.ReadU32((c.V1 + 0x51D8u)); 
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
        goto L801BA0E8;
        L801BA6DC: ;
        c.V0 = 0x801D0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x51D8u)); 
        c.A0 = 0x801D0000u; 
        c.A0 = mem.ReadU32((c.A0 + 0x5284u)); 
        c.V1 = mem.ReadU8(c.V0); 
        { var _s = c.V1; var _t = c.A0; c.V0 = _t >> (int)(_s & 31u);  }
        { c.V0 = c.V0 & 0x0001u;  }
        if (c.V0 == 0u) {
            { c.V0 = 0u | 0x0001u;  }
            goto L801BAEF8;
        }
        { c.V0 = 0u | 0x0001u;  }
        { var _s = c.V1; var _t = c.V0; c.V0 = _t << (int)(_s & 31u);  }
        { var _s = 0u; var _t = c.V0; c.V0 = ~(_s | _t);  }
        c.V1 = mem.ReadU32(c.S1); 
        { var _s = c.V0; var _t = c.A0; c.V0 = _s & _t;  }
        c.At = 0x801D0000u; 
        mem.WriteU32((c.At + 0x5284u), c.V0); 
        { c.V1 = c.V1 + 0x1u;  }
        mem.WriteU32(c.S1, c.V1); 
        goto L801BA0E8;
        L801BA728: ;
        c.V1 = mem.ReadU32(c.S1); 
        c.A0 = 0x801D0000u; 
        c.A0 = mem.ReadU32((c.A0 + 0x5284u)); 
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.V1 = mem.ReadU8(c.V1); 
        { c.V0 = 0u | 0x0001u;  }
        { var _s = c.V1; var _t = c.V0; c.V0 = _t << (int)(_s & 31u);  }
        { var _s = c.V0; var _t = c.A0; c.V0 = _s | _t;  }
        c.At = 0x801D0000u; 
        mem.WriteU32((c.At + 0x5284u), c.V0); 
        goto L801BA0E8;
        L801BA75C: ;
        c.At = 0x801D0000u; 
        mem.WriteU16((c.At + 0x5214u), (ushort)0u); 
        goto L801BA0E8;
        L801BA76C: ;
        c.V0 = 0x801D0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x51D4u)); 
        if (c.V0 == 0u) {
            { c.A1 = 0u | 0x0001u;  }
            goto L801BA794;
        }
        { c.A1 = 0u | 0x0001u;  }
        c.V0 = mem.ReadU32(c.S1); 
        { c.V0 = c.V0 + 0x5u;  }
        mem.WriteU32(c.S1, c.V0); 
        goto L801BA0E8;
        L801BA794: ;
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
        c.A3 = mem.ReadU16((c.At + 0x19C8u)); 
        { c.V0 = 0u | 0x0100u;  }
        mem.WriteU32((c.SP + 0x10u), c.V0); 
        { c.V0 = 0u | 0x0030u;  }
        mem.WriteU32((c.SP + 0x14u), c.V0); 
        { c.V0 = 0u | 0x0048u;  }
        mem.WriteU32((c.SP + 0x18u), c.V0); 
        c.RA = 0x801BA824u; 
        SoTN_main.LoadTPage(c, m);
        goto L801BA0E8;
        L801BA82C: ;
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
        c.RA = 0x801BA860u;
        Dispatcher.Call(c, m, c.V0);
        goto L801BA0E8;
        L801BA868: ;
        c.At = 0x801D0000u; 
        mem.WriteU32((c.At + 0x5284u), 0u); 
        c.At = 0x801D0000u; 
        mem.WriteU32((c.At + 0x51D4u), 0u); 
        c.At = 0x801D0000u; 
        mem.WriteU32((c.At + 0x5288u), 0u); 
        goto L801BA0E8;
        L801BA888: ;
        c.V1 = mem.ReadU32(c.S1); 
        { c.V0 = c.V1 + 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        c.V1 = mem.ReadU8(c.V1); 
        { c.V0 = 0u | 0x0001u;  }
        { var _s = c.V1; var _t = c.V0; c.V0 = _t << (int)(_s & 31u);  }
        c.V1 = 0x801D0000u; 
        c.V1 = mem.ReadU32((c.V1 + 0x5284u)); 
        { var _s = 0u; var _t = c.V0; c.V0 = ~(_s | _t);  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s & _t;  }
        c.At = 0x801D0000u; 
        mem.WriteU32((c.At + 0x5284u), c.V0); 
        goto L801BA0E8;
        L801BA8C4: ;
        c.V0 = 0x801D0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x51D8u)); 
        c.V1 = mem.ReadU8(c.V0); 
        c.V0 = 0x801D0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x5284u)); 
        { var _s = c.V1; var _t = c.V0; c.V0 = _t >> (int)(_s & 31u);  }
        { c.V0 = c.V0 & 0x0001u;  }
        if (c.V0 == 0u) {
            goto L801BAEF8;
        }
        c.V0 = mem.ReadU32(c.S1); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU32(c.S1, c.V0); 
        goto L801BA0E8;
        L801BA904: ;
        c.V0 = 0x801D0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x51D4u)); 
        if (c.V0 != 0u) {
            goto L801BA0E8;
        }
        c.V0 = mem.ReadU8((c.S1 + 0x17u)); 
        mem.WriteU8((c.S1 + 0x16u), (byte)c.V0); 
        { c.V0 = 0u | 0x0020u;  }
        if (c.V1 != c.V0) {
            { c.A0 = c.SP + 0x20u;  }
            goto L801BA94C;
        }
        { c.A0 = c.SP + 0x20u;  }
        c.V1 = 0x801D0000u; 
        { c.V1 = c.V1 + 0x51E2u;  }
        c.V0 = mem.ReadU16(c.V1); 
        { c.V0 = c.V0 + 0x2u;  }
        mem.WriteU16(c.V1, (ushort)c.V0); 
        goto L801BAF3C;
        L801BA94C: ;
        { c.V0 = c.A2 & 0x000Fu;  }
        { c.V0 = c.V0 << 1;  }
        { c.V0 = c.V0 + 0x380u;  }
        mem.WriteU16((c.SP + 0x20u), (ushort)c.V0); 
        { c.V0 = c.A2 & 0x00F0u;  }
        { c.V0 = c.V0 >> 1;  }
        c.A1 = 0x801D0000u; 
        c.A1 = (uint)(short)mem.ReadU16((c.A1 + 0x51E2u)); 
        c.V1 = 0x801D0000u; 
        c.V1 = (uint)(short)mem.ReadU16((c.V1 + 0x51E6u)); 
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
        c.RA = 0x801BA9A8u; 
        if (!DialogueGlyphs.Draw(c, mem)) SoTN_main.MoveImage(c, m);
        c.V0 = 0x801D0000u; 
        c.V0 = mem.ReadU16((c.V0 + 0x51E2u)); 
        { c.V0 = c.V0 + 0x2u;  }
        c.At = 0x801D0000u; 
        mem.WriteU16((c.At + 0x51E2u), (ushort)c.V0); 
        goto L801BAF3C;
        L801BA9C8: ;
        { c.A0 = 0u | 0x0002u;  }
        c.RA = 0x801BA9D0u; 
        SoTN_lib.ScaleCutsceneAvatar_lib(c, m);
        c.V0 = 0x801D0000u; 
        c.V0 = (uint)(short)mem.ReadU16((c.V0 + 0x51E8u)); 
        { c.V0 = (int)c.V0 < 6 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L801BAF3C;
        }
        c.V0 = mem.ReadU16((c.S2 + 0x2Cu)); 
        { c.V0 = c.V0 - 0x1u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        goto L801BAF3C;
        L801BA9FC: ;
        c.S1 = 0x801D0000u; 
        c.S1 = mem.ReadU32((c.S1 + 0x5204u)); 
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
        c.V1 = 0x801D0000u; 
        c.V1 = (uint)(short)mem.ReadU16((c.V1 + 0x51DCu)); 
        c.V0 = (uint)(short)mem.ReadU16((c.S1 + 0x14u)); 
        c.A0 = c.V1; 
        { c.V1 = c.V1 - 0x2u;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = (int)_s < (int)_t ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.V0 = c.A0 - 0x3u;  }
            goto L801BAA70;
        }
        { c.V0 = c.A0 - 0x3u;  }
        mem.WriteU16((c.S1 + 0x2Cu), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x14u), (ushort)c.V0); 
        L801BAA70: ;
        c.V0 = 0x801D0000u; 
        c.V0 = mem.ReadU16((c.V0 + 0x51E8u)); 
        { c.V0 = c.V0 - 0x1u;  }
        c.At = 0x801D0000u; 
        mem.WriteU16((c.At + 0x51E8u), (ushort)c.V0); 
        { c.V0 = c.V0 << 16;  }
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x0001u;  }
            goto L801BAF3C;
        }
        { c.V0 = 0u | 0x0001u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        c.V1 = 0x801D0000u; 
        c.V1 = mem.ReadU32((c.V1 + 0x520Cu)); 
        { c.V0 = c.V1 << 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.V1 = 0x80080000u; 
        { c.V1 = c.V1 + 0x6FECu;  }
        { var _s = c.V0; var _t = c.V1; c.S1 = _s + _t;  }
        if (c.S1 == 0u) {
            goto L801BAF3C;
        }
        mem.WriteU16((c.S1 + 0x32u), (ushort)0u); 
        L801BAAD0: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.S1 = mem.ReadU32(c.S1); 
        if (c.S1 == 0u) {
            goto L801BAF3C;
        }
        mem.WriteU16((c.S1 + 0x32u), (ushort)0u); 
        goto L801BAAD0;
        L801BAAE8: ;
        c.S1 = 0x801D0000u; 
        c.S1 = mem.ReadU32((c.S1 + 0x5204u)); 
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
        c.V0 = 0x801D0000u; 
        c.V0 = mem.ReadU16((c.V0 + 0x51E8u)); 
        { c.V0 = c.V0 - 0x1u;  }
        c.At = 0x801D0000u; 
        mem.WriteU16((c.At + 0x51E8u), (ushort)c.V0); 
        { c.V0 = c.V0 << 16;  }
        goto L801BAE2C;
        L801BAB54: ;
        c.V1 = mem.ReadU16((c.S2 + 0x2Eu)); 
        { c.A2 = 0u | 0x0001u;  }
        if (c.V1 == c.A2) {
            { c.V0 = (int)c.V1 < 2 ? 1u : 0u;  }
            goto L801BAC78;
        }
        { c.V0 = (int)c.V1 < 2 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L801BAB7C;
        }
        if (c.V1 == 0u) {
            { c.A0 = 0u | 0x0002u;  }
            goto L801BAB90;
        }
        { c.A0 = 0u | 0x0002u;  }
        goto L801BAF3C;
        L801BAB7C: ;
        { c.V0 = 0u | 0x0002u;  }
        if (c.V1 == c.V0) {
            goto L801BAD74;
        }
        goto L801BAF3C;
        L801BAB90: ;
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3848u)); 
        c.At = 0x801D0000u; 
        mem.WriteU32((c.At + 0x5288u), c.A2); 
        { c.A1 = 0u | 0x0048u;  }
        c.RA = 0x801BABA8u;
        Dispatcher.Call(c, m, c.V0);
        { c.V0 = c.V0 << 16;  }
        { c.V1 = (uint)((int)c.V0 >> 16);  }
        c.V0 = 0xFFFFFFFFu; 
        if (c.V1 != c.V0) {
            { c.V0 = c.V1 << 1;  }
            goto L801BABC4;
        }
        { c.V0 = c.V1 << 1;  }
        c.A0 = c.S2; 
        goto L801BAF34;
        L801BABC4: ;
        c.A2 = 0x801D0000u; 
        { c.A2 = c.A2 + 0x5208u;  }
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
            goto L801BAD60;
        }
        c.A0 = 0u; 
        { c.A1 = 0u | 0x007Fu;  }
        { c.V1 = 0u | 0x00F7u;  }
        { c.T1 = c.A2 - 0x28u;  }
        { c.T0 = 0u | 0x01FEu;  }
        c.A3 = 0x80180000u; 
        { c.A3 = c.A3 + 0x19D0u;  }
        { c.A2 = 0u | 0x0F70u;  }
        L801BAC10: ;
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
            goto L801BAC10;
        }
        { c.A0 = c.A0 + 0x1u;  }
        goto L801BAD60;
        L801BAC78: ;
        c.V0 = 0x801D0000u; 
        c.V0 = mem.ReadU32((c.V0 + 0x5208u)); 
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
            goto L801BAD0C;
        }
        c.A0 = 0u; 
        { c.A1 = 0u | 0x0004u;  }
        L801BACB0: ;
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
            goto L801BACDC;
        }
        mem.WriteU16((c.S1 + 0x20u), (ushort)c.V0); 
        { c.V1 = c.V1 + 0xFu;  }
        L801BACDC: ;
        { c.V0 = (uint)((int)c.V1 >> 4);  }
        mem.WriteU16((c.S1 + 0x8u), (ushort)c.V0); 
        { c.V0 = (int)c.V0 < 5 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L801BACF8;
        }
        mem.WriteU16((c.S1 + 0x8u), (ushort)c.A1); 
        goto L801BACFC;
        L801BACF8: ;
        { c.A0 = 0u | 0x0001u;  }
        L801BACFC: ;
        c.S1 = mem.ReadU32(c.S1); 
        if (c.S1 != 0u) {
            goto L801BACB0;
        }
        L801BAD0C: ;
        { c.V0 = c.A0 << 16;  }
        if (c.V0 != 0u) {
            goto L801BAF3C;
        }
        c.S0 = 0x801D0000u; 
        { c.S0 = c.S0 + 0x5208u;  }
        c.A0 = mem.ReadU32(c.S0); 
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x384Cu)); 
        c.RA = 0x801BAD38u;
        Dispatcher.Call(c, m, c.V0);
        c.S1 = 0x801D0000u; 
        c.S1 = mem.ReadU32((c.S1 + 0x5204u)); 
        c.V0 = 0xFFFFFFFFu; 
        mem.WriteU32(c.S0, c.V0); 
        c.S1 = mem.ReadU32(c.S1); 
        { c.V0 = 0u | 0x0411u;  }
        mem.WriteU16((c.S1 + 0x32u), (ushort)c.V0); 
        c.S1 = mem.ReadU32(c.S1); 
        { c.V0 = 0u | 0x0451u;  }
        mem.WriteU16((c.S1 + 0x32u), (ushort)c.V0); 
        L801BAD60: ;
        c.V0 = mem.ReadU16((c.S2 + 0x2Eu)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S2 + 0x2Eu), (ushort)c.V0); 
        goto L801BAF3C;
        L801BAD74: ;
        c.S1 = 0x801D0000u; 
        c.S1 = mem.ReadU32((c.S1 + 0x5204u)); 
        c.S1 = mem.ReadU32(c.S1); 
        c.V0 = mem.ReadU8((c.S1 + 0x4u)); 
        { c.V0 = c.V0 < 0x00000010u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            c.A0 = 0u; 
            goto L801BADB0;
        }
        c.A0 = 0u; 
        mem.WriteU8((c.S1 + 0x28u), (byte)0u); 
        mem.WriteU8((c.S1 + 0x1Cu), (byte)0u); 
        mem.WriteU8((c.S1 + 0x10u), (byte)0u); 
        mem.WriteU8((c.S1 + 0x4u), (byte)0u); 
        goto L801BADCC;
        L801BADB0: ;
        c.V0 = mem.ReadU8((c.S1 + 0x28u)); 
        { c.A0 = 0u | 0x0001u;  }
        { c.V0 = c.V0 - 0x10u;  }
        mem.WriteU8((c.S1 + 0x28u), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0x1Cu), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0x10u), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0x4u), (byte)c.V0); 
        L801BADCC: ;
        c.V0 = mem.ReadU8((c.S1 + 0x6u)); 
        { c.V0 = c.V0 < 0x0000007Fu ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.V0 = 0u | 0x007Fu;  }
            goto L801BADEC;
        }
        { c.V0 = 0u | 0x007Fu;  }
        c.V0 = mem.ReadU8((c.S1 + 0x12u)); 
        { c.A0 = 0u | 0x0001u;  }
        { c.V0 = c.V0 + 0x8u;  }
        L801BADEC: ;
        mem.WriteU8((c.S1 + 0x12u), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0x6u), (byte)c.V0); 
        c.S1 = mem.ReadU32(c.S1); 
        c.V0 = mem.ReadU8((c.S1 + 0x4u)); 
        { c.V0 = c.V0 < 0x00000010u ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x0010u;  }
            goto L801BAE1C;
        }
        { c.V0 = 0u | 0x0010u;  }
        c.V0 = mem.ReadU8((c.S1 + 0x6u)); 
        { c.A0 = 0u | 0x0001u;  }
        { c.V0 = c.V0 - 0xFu;  }
        L801BAE1C: ;
        mem.WriteU8((c.S1 + 0x6u), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0x5u), (byte)c.V0); 
        mem.WriteU8((c.S1 + 0x4u), (byte)c.V0); 
        { c.V0 = c.A0 << 16;  }
        L801BAE2C: ;
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x0001u;  }
            goto L801BAF3C;
        }
        { c.V0 = 0u | 0x0001u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        goto L801BAF3C;
        L801BAE3C: ;
        c.S1 = 0x801D0000u; 
        c.S1 = mem.ReadU32((c.S1 + 0x5204u)); 
        c.V0 = 0x801D0000u; 
        c.V0 = mem.ReadU16((c.V0 + 0x51E8u)); 
        c.S1 = mem.ReadU32(c.S1); 
        { c.V0 = c.V0 - 0x1u;  }
        c.At = 0x801D0000u; 
        mem.WriteU16((c.At + 0x51E8u), (ushort)c.V0); 
        { c.V0 = c.V0 << 16;  }
        { c.V1 = (uint)((int)c.V0 >> 16);  }
        { c.V0 = (int)c.V1 < 12 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L801BAEA8;
        }
        c.S1 = mem.ReadU32(c.S1); 
        c.V1 = mem.ReadU8((c.S1 + 0xCu)); 
        { c.V0 = c.V1 + 0xECu;  }
        mem.WriteU8((c.S1 + 0xCu), (byte)c.V0); 
        c.V0 = 0x801D0000u; 
        c.V0 = mem.ReadU16((c.V0 + 0x51E8u)); 
        { c.V0 = c.V0 & 0x0001u;  }
        if (c.V0 == 0u) {
            { c.V0 = c.V1 - 0x15u;  }
            goto L801BAF3C;
        }
        { c.V0 = c.V1 - 0x15u;  }
        mem.WriteU8((c.S1 + 0xCu), (byte)c.V0); 
        goto L801BAF3C;
        L801BAEA8: ;
        if (c.V1 != 0u) {
            { c.V0 = 0u | 0x0001u;  }
            goto L801BAEC0;
        }
        { c.V0 = 0u | 0x0001u;  }
        mem.WriteU16((c.S2 + 0x2Cu), (ushort)c.V0); 
        { c.V0 = 0u | 0x0008u;  }
        mem.WriteU16((c.S1 + 0x32u), (ushort)c.V0); 
        goto L801BAED4;
        L801BAEC0: ;
        c.V0 = mem.ReadU16((c.S1 + 0x2Eu)); 
        { c.V0 = c.V0 - 0x6u;  }
        mem.WriteU16((c.S1 + 0x2Eu), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x22u), (ushort)c.V0); 
        L801BAED4: ;
        c.S1 = mem.ReadU32(c.S1); 
        { c.V0 = 0u | 0x0008u;  }
        mem.WriteU16((c.S1 + 0x32u), (ushort)c.V0); 
        goto L801BAF3C;
        L801BAEE4: ;
        c.V0 = mem.ReadU8(c.S4); 
        { c.V0 = c.V0 - 0x1u;  }
        mem.WriteU8(c.S4, (byte)c.V0); 
        goto L801BAF3C;
        L801BAEF8: ;
        c.V1 = 0x801D0000u; 
        { c.V1 = c.V1 + 0x51D8u;  }
        c.V0 = mem.ReadU32(c.V1); 
        { c.V0 = c.V0 - 0x1u;  }
        mem.WriteU32(c.V1, c.V0); 
        goto L801BAF3C;
        L801BAF14: ;
        c.V1 = 0x80040000u; 
        { c.V1 = c.V1 - 0x34FCu;  }
        c.V0 = mem.ReadU32(c.V1); 
        c.A0 = c.S2; 
        c.At = 0x80040000u; 
        mem.WriteU32((c.At - 0x38FCu), 0u); 
        { c.V0 = c.V0 | 0x0008u;  }
        mem.WriteU32(c.V1, c.V0); 
        L801BAF34: ;
        c.RA = 0x801BAF3Cu; 
        SoTN_lib.DestroyEntity_lib(c, m);
        L801BAF3C: ;
        c.RA = mem.ReadU32((c.SP + 0x44u)); 
        c.S4 = mem.ReadU32((c.SP + 0x40u)); 
        c.S3 = mem.ReadU32((c.SP + 0x3Cu)); 
        c.S2 = mem.ReadU32((c.SP + 0x38u)); 
        c.S1 = mem.ReadU32((c.SP + 0x34u)); 
        c.S0 = mem.ReadU32((c.SP + 0x30u)); 
        { c.SP = c.SP + 0x48u;  }
        return;
        }
    public static bool EntityRelicOrb_lib(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("lib", m, false)) return true;
        EntityRelicOrb_lib_Body(c, m);
        return false;
    }
    private static void EntityRelicOrb_lib_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "lib", 0x801D51D8u);
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
            goto L801C76F8;
        }
        { c.S4 = c.V0 & 0x7FFFu;  }
        { c.V0 = c.V1 < 0x00000005u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.V0 = c.V1 < 0x0000000Au ? 1u : 0u;  }
            goto L801C7700;
        }
        { c.V0 = c.V1 < 0x0000000Au ? 1u : 0u;  }
        c.V0 = mem.ReadU8((c.S1 + 0x48u)); 
        if (c.V0 == 0u) {
            { c.V0 = 0u | 0x0005u;  }
            goto L801C76F8;
        }
        { c.V0 = 0u | 0x0005u;  }
        mem.WriteU16((c.S1 + 0x2Cu), (ushort)c.V0); 
        c.V1 = mem.ReadU16((c.S1 + 0x2Cu)); 
        L801C76F8: ;
        { c.V0 = c.V1 < 0x0000000Au ? 1u : 0u;  }
        L801C7700: ;
        if (c.V0 == 0u) {
            { c.V0 = c.V1 << 2;  }
            goto L801C7F60;
        }
        { c.V0 = c.V1 << 2;  }
        c.At = 0x801B0000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.V0 = mem.ReadU32((c.At - 0x258Cu)); 
        switch (c.V0)
        {
            case 0x801C7720u: goto L801C7720;
            case 0x801C78F0u: goto L801C78F0;
            case 0x801C7F60u: goto L801C7F60;
            case 0x801C7950u: goto L801C7950;
            case 0x801C7B10u: goto L801C7B10;
            case 0x801C7BD8u: goto L801C7BD8;
            case 0x801C7C88u: goto L801C7C88;
            case 0x801C7E00u: goto L801C7E00;
            case 0x801C82DCu: goto L801C82DC;
            case 0x801C83C0u: goto L801C83C0;
            case 0x801C859Cu: goto L801C859C;
            case 0x801C8674u: goto L801C8674;
            case 0x801C8778u: goto L801C8778;
            case 0x801C8F78u: goto L801C8F78;
            case 0x801C8FCCu: goto L801C8FCC;
            case 0x801C8FA8u: goto L801C8FA8;
            case 0x801C910Cu: goto L801C910C;
            default: Dispatcher.Call(c, m, c.V0); return;
        }
        L801C7720: ;
        { c.V0 = c.S4 & 0xFFFFu;  }
        c.At = 0x80090000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.V0 = mem.ReadU8((c.At + 0x7964u)); 
        { c.V0 = c.V0 & 0x0001u;  }
        if (c.V0 != 0u) {
            goto L801C7E60;
        }
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x80Cu;  }
        c.S0 = 0u; 
        c.RA = 0x801C7750u; 
        SoTN_lib.InitializeEntity_lib(c, m);
        c.S5 = 0x801D0000u; 
        { c.S5 = c.S5 + 0x528Cu;  }
        { c.V0 = c.S0 << 16;  }
        L801C775C: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        { c.V0 = (uint)((int)c.V0 >> 15);  }
        { var _s = c.V0; var _t = c.S5; c.V0 = _s + _t;  }
        c.V0 = mem.ReadU16(c.V0); 
        if (c.V0 == 0u) {
            { c.V0 = c.S0 + 0x1u;  }
            goto L801C778C;
        }
        { c.V0 = c.S0 + 0x1u;  }
        c.S0 = c.V0; 
        { c.V0 = c.V0 << 16;  }
        { c.V0 = (uint)((int)c.V0 >> 16);  }
        { c.V0 = (int)c.V0 < 31 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.V0 = c.S0 << 16;  }
            goto L801C775C;
        }
        { c.V0 = c.S0 << 16;  }
        L801C778C: ;
        { c.V0 = c.S0 << 16;  }
        { c.S3 = (uint)((int)c.V0 >> 16);  }
        { c.V0 = (int)c.S3 < 31 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.A0 = 0u | 0x0004u;  }
            goto L801C77C8;
        }
        { c.A0 = 0u | 0x0004u;  }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3848u)); 
        { c.A1 = 0u | 0x0007u;  }
        c.RA = 0x801C77B4u;
        Dispatcher.Call(c, m, c.V0);
        { c.V0 = c.V0 << 16;  }
        { c.S2 = (uint)((int)c.V0 >> 16);  }
        c.V0 = 0xFFFFFFFFu; 
        if (c.S2 != c.V0) {
            c.V1 = 0x00800000u; 
            goto L801C77D0;
        }
        c.V1 = 0x00800000u; 
        L801C77C8: ;
        mem.WriteU16((c.S1 + 0x2Cu), (ushort)0u); 
        goto L801C8144;
        L801C77D0: ;
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
        c.RA = 0x801C7820u;
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
            goto L801C78CC;
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
        L801C7878: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        if (c.A3 == 0u) {
            { c.V0 = 0u | 0x0006u;  }
            goto L801C7888;
        }
        { c.V0 = 0u | 0x0006u;  }
        mem.WriteU16((c.A2 + 0x32u), (ushort)c.T3); 
        goto L801C78B4;
        L801C7888: ;
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
        L801C78B4: ;
        { c.V0 = 0u | 0x007Eu;  }
        mem.WriteU16((c.A2 + 0x26u), (ushort)c.V0); 
        c.A2 = mem.ReadU32(c.A2); 
        if (c.A2 != 0u) {
            { c.A3 = c.A3 + 0x1u;  }
            goto L801C7878;
        }
        { c.A3 = c.A3 + 0x1u;  }
        L801C78CC: ;
        c.V0 = 0xFFFF8000u; 
        mem.WriteU16((c.S1 + 0x4u), (ushort)c.V0); 
        { c.V0 = 0u | 0x4000u;  }
        mem.WriteU32((c.S1 + 0xCu), c.V0); 
        { c.V0 = 0u | 0x0040u;  }
        mem.WriteU16((c.S1 + 0x90u), (ushort)c.V0); 
        c.V0 = 0xFFFFFE00u; 
        mem.WriteU32((c.S1 + 0x94u), c.V0); 
        goto L801C7F60;
        L801C78F0: ;
        c.V0 = mem.ReadU32((c.S1 + 0xCu)); 
        c.V1 = mem.ReadU16((c.S1 + 0x90u)); 
        c.A0 = mem.ReadU32((c.S1 + 0x94u)); 
        { c.V1 = c.V1 - 0x1u;  }
        { var _s = c.V0; var _t = c.A0; c.V0 = _s + _t;  }
        mem.WriteU16((c.S1 + 0x90u), (ushort)c.V1); 
        { c.V1 = c.V1 & 0xFFFFu;  }
        if (c.V1 != 0u) {
            mem.WriteU32((c.S1 + 0xCu), c.V0); 
            goto L801C7928;
        }
        mem.WriteU32((c.S1 + 0xCu), c.V0); 
        c.V0 = mem.ReadU32((c.S1 + 0x94u)); 
        { c.V1 = 0u | 0x0040u;  }
        mem.WriteU16((c.S1 + 0x90u), (ushort)c.V1); 
        { var _s = 0u; var _t = c.V0; c.V0 = _s - _t;  }
        mem.WriteU32((c.S1 + 0x94u), c.V0); 
        L801C7928: ;
        c.RA = 0x801C7930u; 
        SoTN_lib.MoveEntity_lib(c, m);
        c.V0 = (uint)(short)mem.ReadU16((c.S1 + 0x8Cu)); 
        { c.V1 = 0u | 0x0010u;  }
        { c.V0 = c.V0 << 1;  }
        c.At = 0x801D0000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        mem.WriteU16((c.At + 0x528Cu), (ushort)c.V1); 
        goto L801C7F60;
        L801C7950: ;
        { c.S0 = c.S4 & 0xFFFFu;  }
        c.A0 = c.S0; 
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x37B8u)); 
        { c.A1 = 0u | 0x2000u;  }
        c.RA = 0x801C796Cu;
        Dispatcher.Call(c, m, c.V0);
        { c.V0 = c.S0 < 0x00000016u ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.A0 = c.SP + 0x20u;  }
            goto L801C79A4;
        }
        { c.A0 = c.SP + 0x20u;  }
        { c.V0 = c.S0 < 0x00000014u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            c.A1 = 0u; 
            goto L801C79A8;
        }
        c.A1 = 0u; 
        c.At = 0x80090000u; 
        { var _s = c.At; var _t = c.S0; c.At = _s + _t;  }
        c.V0 = mem.ReadU8((c.At + 0x7964u)); 
        { c.V0 = c.V0 ^ 0x0002u;  }
        c.At = 0x80090000u; 
        { var _s = c.At; var _t = c.S0; c.At = _s + _t;  }
        mem.WriteU8((c.At + 0x7964u), (byte)c.V0); 
        L801C79A4: ;
        c.A1 = 0u; 
        L801C79A8: ;
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
        c.RA = 0x801C79E0u; 
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
        L801C7A14: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        if (c.A3 != 0u) {
            { c.V0 = 0u | 0x0003u;  }
            goto L801C7A60;
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
        goto L801C7AEC;
        L801C7A60: ;
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
            goto L801C7AD0;
        }
        mem.WriteU8((c.A2 + 0x6u), (byte)0u); 
        mem.WriteU8((c.A2 + 0x2Au), (byte)c.A0); 
        mem.WriteU8((c.A2 + 0x1Eu), (byte)c.A0); 
        mem.WriteU8((c.A2 + 0x12u), (byte)c.A0); 
        mem.WriteU8((c.A2 + 0x6u), (byte)c.A0); 
        goto L801C7AE0;
        L801C7AD0: ;
        mem.WriteU8((c.A2 + 0x29u), (byte)c.A0); 
        mem.WriteU8((c.A2 + 0x1Du), (byte)c.A0); 
        mem.WriteU8((c.A2 + 0x11u), (byte)c.A0); 
        mem.WriteU8((c.A2 + 0x5u), (byte)c.A0); 
        L801C7AE0: ;
        { c.V0 = 0u | 0x01FDu;  }
        mem.WriteU16((c.A2 + 0x26u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0011u;  }
        L801C7AEC: ;
        mem.WriteU16((c.A2 + 0x32u), (ushort)c.V0); 
        c.A2 = mem.ReadU32(c.A2); 
        { c.A3 = c.A3 + 0x1u;  }
        { c.V0 = (int)c.A3 < 3 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L801C7A14;
        }
        c.V0 = mem.ReadU16((c.S1 + 0x2Cu)); 
        { c.V0 = c.V0 + 0x1u;  }
        goto L801C7DF8;
        L801C7B10: ;
        c.S0 = 0u; 
        c.S3 = 0x80080000u; 
        { c.S3 = c.S3 - 0x101Cu;  }
        c.V0 = c.S3; 
        c.A0 = 0x80180000u; 
        c.A0 = mem.ReadU32((c.A0 + 0x26B0u)); 
        { c.A3 = 0u | 0x0BFFu;  }
        mem.WriteU16((c.SP + 0x28u), (ushort)0u); 
        L801C7B30: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        mem.WriteU8(c.V0, (byte)0u); 
        { c.A3 = c.A3 - 0x1u;  }
        if ((int)c.A3 >= 0) {
            { c.V0 = c.V0 + 0x1u;  }
            goto L801C7B30;
        }
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.SP + 0x28u), (ushort)0u); 
        { c.S2 = c.S4 << 4;  }
        L801C7B48: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V0 = mem.ReadU8(c.A0); 
        if (c.V0 != 0u) {
            { c.A1 = c.SP + 0x28u;  }
            goto L801C7B7C;
        }
        { c.A1 = c.SP + 0x28u;  }
        if (c.S0 != 0u) {
            { c.S0 = 0u | 0x0001u;  }
            goto L801C7B90;
        }
        { c.S0 = 0u | 0x0001u;  }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x37B0u)); 
        { var _s = c.S2; var _t = c.V0; c.V0 = _s + _t;  }
        c.A0 = mem.ReadU32(c.V0); 
        goto L801C7B48;
        L801C7B7C: ;
        c.A2 = c.S3; 
        { c.A3 = 0u | 0x00C0u;  }
        c.RA = 0x801C7B88u; 
        SoTN_lib.BlitChar_lib(c, m);
        c.A0 = c.V0; 
        goto L801C7B48;
        L801C7B90: ;
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
        c.RA = 0x801C7BBCu; 
        SoTN_main.LoadTPage(c, m);
        c.V0 = mem.ReadU16((c.S1 + 0x2Cu)); 
        mem.WriteU16((c.S1 + 0x7Cu), (ushort)0u); 
        c.V1 = mem.ReadU16((c.SP + 0x28u)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S1 + 0x7Eu), (ushort)c.V1); 
        mem.WriteU16((c.S1 + 0x2Cu), (ushort)c.V0); 
        goto L801C7F60;
        L801C7BD8: ;
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
        L801C7C00: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        if (c.A3 != 0u) {
            goto L801C7C34;
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
        goto L801C7C5C;
        L801C7C34: ;
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
        L801C7C5C: ;
        mem.WriteU16((c.A2 + 0x16u), (ushort)c.A0); 
        mem.WriteU16((c.A2 + 0xAu), (ushort)c.A0); 
        mem.WriteU16((c.A2 + 0x2Eu), (ushort)c.A1); 
        mem.WriteU16((c.A2 + 0x22u), (ushort)c.A1); 
        c.A2 = mem.ReadU32(c.A2); 
        { c.A3 = c.A3 + 0x1u;  }
        { c.V0 = (int)c.A3 < 2 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L801C7DD0;
        }
        goto L801C7C00;
        L801C7C88: ;
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
        L801C7D00: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        if (c.A3 != 0u) {
            { c.V0 = c.A0 + 0x68u;  }
            goto L801C7D60;
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
        c.V0 = mem.ReadU16((c.At + 0x26C4u)); 
        { c.V0 = c.V0 + 0xA7u;  }
        mem.WriteU16((c.A2 + 0x16u), (ushort)c.V0); 
        mem.WriteU16((c.A2 + 0xAu), (ushort)c.V0); 
        c.V0 = mem.ReadU8((c.A2 + 0x2Au)); 
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.A1; c.At = _s + _t;  }
        c.V1 = mem.ReadU16((c.At + 0x26B4u)); 
        { c.V0 = c.V0 - 0x10u;  }
        { c.V1 = c.V1 + 0xA7u;  }
        mem.WriteU8((c.A2 + 0x2Au), (byte)c.V0); 
        mem.WriteU8((c.A2 + 0x1Eu), (byte)c.V0); 
        goto L801C7DB4;
        L801C7D60: ;
        mem.WriteU16((c.A2 + 0x8u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0098u;  }
        { var _s = c.V0; var _t = c.A0; c.V0 = _s - _t;  }
        mem.WriteU16((c.A2 + 0x14u), (ushort)c.V0); 
        mem.WriteU16((c.A2 + 0x2Cu), (ushort)c.T1); 
        mem.WriteU16((c.A2 + 0x20u), (ushort)c.T0); 
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.A1; c.At = _s + _t;  }
        c.V0 = mem.ReadU16((c.At + 0x26D4u)); 
        { c.V0 = c.V0 + 0xA7u;  }
        mem.WriteU16((c.A2 + 0x16u), (ushort)c.V0); 
        mem.WriteU16((c.A2 + 0xAu), (ushort)c.V0); 
        c.V0 = mem.ReadU8((c.A2 + 0x11u)); 
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.A1; c.At = _s + _t;  }
        c.V1 = mem.ReadU16((c.At + 0x26E4u)); 
        { c.V0 = c.V0 - 0x10u;  }
        { c.V1 = c.V1 + 0xA7u;  }
        mem.WriteU8((c.A2 + 0x11u), (byte)c.V0); 
        mem.WriteU8((c.A2 + 0x5u), (byte)c.V0); 
        L801C7DB4: ;
        mem.WriteU16((c.A2 + 0x2Eu), (ushort)c.V1); 
        mem.WriteU16((c.A2 + 0x22u), (ushort)c.V1); 
        c.A2 = mem.ReadU32(c.A2); 
        { c.A3 = c.A3 + 0x1u;  }
        { c.V0 = (int)c.A3 < 3 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L801C7D00;
        }
        L801C7DD0: ;
        c.V0 = mem.ReadU16((c.S1 + 0x7Cu)); 
        { c.V1 = 0u | 0x0008u;  }
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S1 + 0x7Cu), (ushort)c.V0); 
        { c.V0 = c.V0 & 0xFFFFu;  }
        if (c.V0 != c.V1) {
            goto L801C7F60;
        }
        c.V0 = mem.ReadU16((c.S1 + 0x2Cu)); 
        mem.WriteU16((c.S1 + 0x7Cu), (ushort)0u); 
        { c.V0 = c.V0 + 0x1u;  }
        L801C7DF8: ;
        mem.WriteU16((c.S1 + 0x2Cu), (ushort)c.V0); 
        goto L801C7F60;
        L801C7E00: ;
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
            goto L801C7F60;
        }
        L801C7E60: ;
        c.A0 = c.S1; 
        c.RA = 0x801C7E68u; 
        SoTN_lib.DestroyEntity_lib(c, m);
        goto L801C8144;
        L801C7E70: ;
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
        c.V0 = mem.ReadU16((c.At + 0x26F4u)); 
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
        c.V1 = mem.ReadU16((c.At + 0x2704u)); 
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
        goto L801C7FF0;
        L801C7F60: ;
        c.V0 = mem.ReadU16((c.S1 + 0x2Cu)); 
        { c.V0 = c.V0 < 0x00000002u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L801C8018;
        }
        c.A1 = 0x80040000u; 
        c.A1 = mem.ReadU16((c.A1 - 0x3668u)); 
        c.A0 = c.S1; 
        c.RA = 0x801C7F84u; 
        SoTN_lib.BlinkItem_lib(c, m);
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
        L801C7FAC: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.A2 = mem.ReadU32(c.A2); 
        { c.A3 = c.A3 - 0x1u;  }
        if ((int)c.A3 >= 0) {
            goto L801C7FAC;
        }
        c.V0 = mem.ReadU16((c.S1 + 0x80u)); 
        if (c.V0 != 0u) {
            c.A3 = 0u; 
            goto L801C8008;
        }
        c.A3 = 0u; 
        { c.V1 = 0u | 0x0008u;  }
        L801C7FD0: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V0 = mem.ReadU16((c.A2 + 0x32u)); 
        if (c.V0 == c.V1) {
            { c.A3 = c.A3 + 0x1u;  }
            goto L801C7E70;
        }
        { c.A3 = c.A3 + 0x1u;  }
        c.A2 = mem.ReadU32(c.A2); 
        { c.V0 = (int)c.A3 < 4 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L801C7FD0;
        }
        L801C7FF0: ;
        c.V0 = mem.ReadU16((c.S1 + 0x82u)); 
        { c.V1 = 0u | 0x0004u;  }
        mem.WriteU16((c.S1 + 0x80u), (ushort)c.V1); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S1 + 0x82u), (ushort)c.V0); 
        goto L801C8018;
        L801C8008: ;
        c.V0 = mem.ReadU16((c.S1 + 0x80u)); 
        { c.V0 = c.V0 - 0x1u;  }
        mem.WriteU16((c.S1 + 0x80u), (ushort)c.V0); 
        L801C8018: ;
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
        L801C8040: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.A2 = mem.ReadU32(c.A2); 
        { c.A3 = c.A3 - 0x1u;  }
        if ((int)c.A3 >= 0) {
            goto L801C8040;
        }
        if (c.A2 == 0u) {
            { c.A3 = 0u | 0x0008u;  }
            goto L801C8144;
        }
        { c.A3 = 0u | 0x0008u;  }
        L801C8058: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V0 = mem.ReadU16((c.A2 + 0x32u)); 
        if (c.V0 == c.A3) {
            goto L801C8134;
        }
        c.V0 = mem.ReadU8((c.A2 + 0x13u)); 
        { c.V0 = c.V0 & 0x0003u;  }
        if (c.V0 == 0u) {
            goto L801C80A0;
        }
        c.V1 = mem.ReadU16((c.A2 + 0x16u)); 
        c.A0 = mem.ReadU16((c.A2 + 0x2Eu)); 
        { c.V0 = c.V1 - 0x1u;  }
        mem.WriteU16((c.A2 + 0x16u), (ushort)c.V0); 
        { c.V0 = c.A0 - 0x1u;  }
        mem.WriteU16((c.A2 + 0xAu), (ushort)c.V1); 
        mem.WriteU16((c.A2 + 0x2Eu), (ushort)c.V0); 
        mem.WriteU16((c.A2 + 0x22u), (ushort)c.A0); 
        goto L801C80D0;
        L801C80A0: ;
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
        L801C80D0: ;
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
            goto L801C8134;
        }
        mem.WriteU8((c.A2 + 0x6u), (byte)c.V0); 
        mem.WriteU16((c.A2 + 0x32u), (ushort)c.A3); 
        L801C8134: ;
        c.A2 = mem.ReadU32(c.A2); 
        if (c.A2 != 0u) {
            goto L801C8058;
        }
        L801C8144: ;
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
            goto L801C8228;
        }
        { c.V0 = c.V0 < 0x00000005u ? 1u : 0u;  }
        c.V0 = mem.ReadU16((c.A2 + 0x30u)); 
        { c.A0 = c.V0 + 0x70u;  }
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
            { c.A0 = c.A0 - 0x70u;  }
            goto L801C81D4;
        }
        { c.A0 = c.A0 - 0x70u;  }
        c.A0 = c.A2; 
        c.RA = 0x801C81CCu; 
        SoTN_lib.DestroyEntity_lib(c, m);
        goto L801C8284;
        L801C81D4: ;
        { c.V0 = c.A0 & 0xFFFFu;  }
        { c.V0 = c.V0 << 1;  }
        c.At = 0x80180000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.A0 = mem.ReadU16((c.At + 0x1A90u)); 
        { c.V0 = c.A0 < 0x00000080u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L801C8208;
        }
        c.V0 = 0x801C0000u; 
        { c.V0 = c.V0 + 0x63F0u;  }
        mem.WriteU32((c.A2 + 0xB8u), c.V0); 
        goto L801C8218;
        L801C8208: ;
        c.V0 = 0x801C0000u; 
        { c.V0 = c.V0 + 0x6E04u;  }
        mem.WriteU32((c.A2 + 0xB8u), c.V0); 
        { c.A0 = c.A0 - 0x80u;  }
        L801C8218: ;
        { c.V0 = 0u | 0x8000u;  }
        { var _s = c.A0; var _t = c.V0; c.V0 = _s + _t;  }
        mem.WriteU16((c.A2 + 0x30u), (ushort)c.V0); 
        goto L801C8274;
        L801C8228: ;
        c.A0 = mem.ReadU16((c.A2 + 0xB4u)); 
        if (c.V0 == 0u) {
            goto L801C8274;
        }
        c.V0 = mem.ReadU8((c.A2 + 0x48u)); 
        if (c.V0 == 0u) {
            { c.A1 = c.A0 >> 3;  }
            goto L801C8274;
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
        L801C8274: ;
        c.V0 = mem.ReadU32((c.A2 + 0xB8u)); 
        c.A0 = c.A2; 
        c.RA = 0x801C8284u;
        Dispatcher.Call(c, m, c.V0);
        L801C8284: ;
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
            goto L801C87D0;
        }
        { c.V0 = c.V1 << 2;  }
        c.At = 0x801B0000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.V0 = mem.ReadU32((c.At - 0x2564u)); 
        switch (c.V0)
        {
            case 0x801C82DCu: goto L801C82DC;
            case 0x801C83C0u: goto L801C83C0;
            case 0x801C859Cu: goto L801C859C;
            case 0x801C8674u: goto L801C8674;
            case 0x801C8778u: goto L801C8778;
            case 0x801C8F78u: goto L801C8F78;
            case 0x801C8FCCu: goto L801C8FCC;
            case 0x801C8FA8u: goto L801C8FA8;
            case 0x801C910Cu: goto L801C910C;
            default: Dispatcher.Call(c, m, c.V0); return;
        }
        L801C82DC: ;
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x80Cu;  }
        c.RA = 0x801C82ECu; 
        SoTN_lib.InitializeEntity_lib(c, m);
        c.V1 = 0x00010000u; 
        c.V0 = mem.ReadU32((c.S0 + 0x34u)); 
        c.A0 = mem.ReadU16((c.S0 + 0x30u)); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s | _t;  }
        c.V1 = 0x08000000u; 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s ^ _t;  }
        if (c.A0 != 0u) {
            mem.WriteU32((c.S0 + 0x34u), c.V0); 
            goto L801C8314;
        }
        mem.WriteU32((c.S0 + 0x34u), c.V0); 
        { c.V0 = 0u | 0x0060u;  }
        mem.WriteU16((c.S0 + 0x30u), (ushort)c.V0); 
        L801C8314: ;
        { c.A0 = 0u | 0x0004u;  }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3848u)); 
        { c.A1 = 0u | 0x0003u;  }
        c.RA = 0x801C832Cu;
        Dispatcher.Call(c, m, c.V0);
        { c.V0 = c.V0 << 16;  }
        { c.A0 = (uint)((int)c.V0 >> 16);  }
        c.V0 = 0xFFFFFFFFu; 
        if (c.A0 != c.V0) {
            { c.V0 = c.A0 << 1;  }
            goto L801C8348;
        }
        { c.V0 = c.A0 << 1;  }
        mem.WriteU16((c.S0 + 0x2Cu), (ushort)0u); 
        goto L801C87D0;
        L801C8348: ;
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
            goto L801C8394;
        }
        mem.WriteU32((c.S0 + 0x34u), c.V0); 
        { c.V0 = 0u | 0x0008u;  }
        L801C8380: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        mem.WriteU16((c.A1 + 0x32u), (ushort)c.V0); 
        c.A1 = mem.ReadU32(c.A1); 
        if (c.A1 != 0u) {
            goto L801C8380;
        }
        L801C8394: ;
        c.A0 = mem.ReadU32((c.S0 + 0x7Cu)); 
        c.V0 = mem.ReadU8(c.A0); 
        mem.WriteU16((c.S0 + 0x80u), (ushort)c.V0); 
        c.V0 = mem.ReadU32((c.S0 + 0x7Cu)); 
        c.V1 = mem.ReadU8((c.A0 + 0x1u)); 
        { c.V0 = c.V0 + 0x2u;  }
        mem.WriteU32((c.S0 + 0x7Cu), c.V0); 
        mem.WriteU16((c.S0 + 0x82u), (ushort)c.V1); 
        goto L801C87D0;
        L801C83C0: ;
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
        c.RA = 0x801C83F0u; 
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
            goto L801C8590;
        }
        c.A2 = 0u; 
        { c.A0 = 0u | 0x0080u;  }
        L801C8424: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        if (c.A2 != 0u) {
            { c.V0 = 0u | 0x0003u;  }
            goto L801C849C;
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
        goto L801C8580;
        L801C849C: ;
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
            goto L801C853C;
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
        goto L801C8560;
        L801C853C: ;
        c.V1 = mem.ReadU16((c.S0 + 0x82u)); 
        c.V0 = mem.ReadU16((c.S0 + 0x6u)); 
        mem.WriteU8((c.A1 + 0x29u), (byte)c.A0); 
        mem.WriteU8((c.A1 + 0x1Du), (byte)c.A0); 
        mem.WriteU8((c.A1 + 0x11u), (byte)c.A0); 
        mem.WriteU8((c.A1 + 0x5u), (byte)c.A0); 
        { c.V1 = c.V1 >> 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 + 0x4u;  }
        L801C8560: ;
        mem.WriteU16((c.A1 + 0x2Eu), (ushort)c.V0); 
        mem.WriteU16((c.A1 + 0x22u), (ushort)c.V0); 
        mem.WriteU16((c.A1 + 0x16u), (ushort)c.V0); 
        mem.WriteU16((c.A1 + 0xAu), (ushort)c.V0); 
        { c.V0 = 0u | 0x01FCu;  }
        mem.WriteU16((c.A1 + 0x26u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0011u;  }
        mem.WriteU16((c.A1 + 0x32u), (ushort)c.V0); 
        L801C8580: ;
        c.A1 = mem.ReadU32(c.A1); 
        if (c.A1 != 0u) {
            { c.A2 = c.A2 + 0x1u;  }
            goto L801C8424;
        }
        { c.A2 = c.A2 + 0x1u;  }
        L801C8590: ;
        c.V0 = mem.ReadU16((c.S0 + 0x2Cu)); 
        { c.V0 = c.V0 + 0x1u;  }
        goto L801C8770;
        L801C859C: ;
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
            goto L801C85F8;
        }
        mem.WriteU16((c.SP + 0x28u), (ushort)0u); 
        L801C85CC: ;
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
            goto L801C85CC;
        }
        { c.S1 = c.S1 + 0x1u;  }
        c.S1 = c.S2; 
        L801C85F8: ;
        { c.S3 = 0u | 0x0001u;  }
        L801C85FC: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V0 = mem.ReadU8(c.A0); 
        if (c.V0 == 0u) {
            c.A1 = 0u; 
            goto L801C8644;
        }
        c.A1 = 0u; 
        if (c.V0 != c.S3) {
            { c.A1 = c.SP + 0x28u;  }
            goto L801C862C;
        }
        { c.A1 = c.SP + 0x28u;  }
        c.V0 = mem.ReadU16((c.S0 + 0x80u)); 
        { c.A0 = c.A0 + 0x1u;  }
        mem.WriteU16((c.SP + 0x28u), (ushort)0u); 
        { c.V0 = c.V0 << 3;  }
        { var _s = c.S2; var _t = c.V0; c.S1 = _s + _t;  }
        goto L801C85FC;
        L801C862C: ;
        c.A3 = mem.ReadU16((c.S0 + 0x80u)); 
        c.A2 = c.S1; 
        { c.A3 = c.A3 >> 1;  }
        c.RA = 0x801C863Cu; 
        SoTN_lib.BlitChar_lib(c, m);
        c.A0 = c.V0; 
        goto L801C85FC;
        L801C8644: ;
        c.A0 = c.S2; 
        { c.V0 = 0u | 0x0180u;  }
        mem.WriteU32((c.SP + 0x10u), c.V0); 
        c.V0 = mem.ReadU16((c.S0 + 0x80u)); 
        c.A2 = 0u; 
        mem.WriteU32((c.SP + 0x14u), c.V0); 
        c.V0 = mem.ReadU16((c.S0 + 0x82u)); 
        c.A3 = 0u; 
        mem.WriteU32((c.SP + 0x18u), c.V0); 
        c.RA = 0x801C866Cu; 
        SoTN_main.LoadTPage(c, m);
        goto L801C8764;
        L801C8674: ;
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
            goto L801C8754;
        }
        c.A2 = 0u; 
        L801C86B0: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        if (c.A2 != 0u) {
            goto L801C8700;
        }
        c.V0 = mem.ReadU16((c.S0 + 0x82u)); 
        c.V1 = mem.ReadU16((c.S0 + 0x86u)); 
        { c.V0 = c.V0 + 0x8u;  }
        { var _s = c.V0; var _t = c.V1; var _r = (long)(int)_s * (int)_t; c.LO = (uint)_r; c.HI = (uint)(_r >> 32);  }
        c.V0 = c.LO; 
        if ((int)c.V0 >= 0) {
            goto L801C86D8;
        }
        { c.V0 = c.V0 + 0x7u;  }
        L801C86D8: ;
        { c.V0 = (uint)((int)c.V0 >> 3);  }
        c.V1 = mem.ReadU16((c.A1 + 0xAu)); 
        c.A0 = mem.ReadU8((c.A1 + 0x12u)); 
        { var _s = c.V1; var _t = c.V0; c.V1 = _s + _t;  }
        { c.A0 = c.A0 - 0x10u;  }
        mem.WriteU16((c.A1 + 0x2Eu), (ushort)c.V1); 
        mem.WriteU16((c.A1 + 0x22u), (ushort)c.V1); 
        mem.WriteU8((c.A1 + 0x12u), (byte)c.A0); 
        mem.WriteU8((c.A1 + 0x6u), (byte)c.A0); 
        goto L801C8744;
        L801C8700: ;
        c.V0 = mem.ReadU16((c.S0 + 0x82u)); 
        c.V1 = mem.ReadU16((c.S0 + 0x86u)); 
        { c.V0 = c.V0 + 0x8u;  }
        { var _s = c.V0; var _t = c.V1; var _r = (long)(int)_s * (int)_t; c.LO = (uint)_r; c.HI = (uint)(_r >> 32);  }
        c.V0 = c.LO; 
        if ((int)c.V0 >= 0) {
            goto L801C8720;
        }
        { c.V0 = c.V0 + 0x7u;  }
        L801C8720: ;
        { c.V0 = (uint)((int)c.V0 >> 3);  }
        c.V1 = mem.ReadU16((c.A1 + 0x22u)); 
        c.A0 = mem.ReadU8((c.A1 + 0x29u)); 
        { var _s = c.V1; var _t = c.V0; c.V1 = _s - _t;  }
        { c.A0 = c.A0 - 0x10u;  }
        mem.WriteU16((c.A1 + 0x16u), (ushort)c.V1); 
        mem.WriteU16((c.A1 + 0xAu), (ushort)c.V1); 
        mem.WriteU8((c.A1 + 0x29u), (byte)c.A0); 
        mem.WriteU8((c.A1 + 0x1Du), (byte)c.A0); 
        L801C8744: ;
        c.A1 = mem.ReadU32(c.A1); 
        if (c.A1 != 0u) {
            { c.A2 = c.A2 + 0x1u;  }
            goto L801C86B0;
        }
        { c.A2 = c.A2 + 0x1u;  }
        L801C8754: ;
        c.V1 = mem.ReadU16((c.S0 + 0x86u)); 
        { c.V0 = 0u | 0x0008u;  }
        if (c.V1 != c.V0) {
            goto L801C87D0;
        }
        L801C8764: ;
        c.V0 = mem.ReadU16((c.S0 + 0x2Cu)); 
        mem.WriteU16((c.S0 + 0x86u), (ushort)0u); 
        { c.V0 = c.V0 + 0x1u;  }
        L801C8770: ;
        mem.WriteU16((c.S0 + 0x2Cu), (ushort)c.V0); 
        goto L801C87D0;
        L801C8778: ;
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
            goto L801C87D0;
        }
        c.A0 = c.S0; 
        c.RA = 0x801C87D0u; 
        SoTN_lib.DestroyEntity_lib(c, m);
        L801C87D0: ;
        c.RA = mem.ReadU32((c.SP + 0x48u)); 
        c.S3 = mem.ReadU32((c.SP + 0x44u)); 
        c.S2 = mem.ReadU32((c.SP + 0x40u)); 
        c.S1 = mem.ReadU32((c.SP + 0x3Cu)); 
        c.S0 = mem.ReadU32((c.SP + 0x38u)); 
        { c.SP = c.SP + 0x50u;  }
        return;
        { c.SP = c.SP - 0x20u;  }
        mem.WriteU32((c.SP + 0x14u), c.S1); 
        c.S1 = c.A0; 
        mem.WriteU32((c.SP + 0x18u), c.RA); 
        mem.WriteU32((c.SP + 0x10u), c.S0); 
        c.V1 = mem.ReadU16((c.S1 + 0x2Cu)); 
        { c.V0 = 0u | 0x0001u;  }
        if (c.V1 == c.V0) {
            { c.V0 = (int)c.V1 < 2 ? 1u : 0u;  }
            goto L801C8860;
        }
        { c.V0 = (int)c.V1 < 2 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L801C882C;
        }
        if (c.V1 == 0u) {
            goto L801C8848;
        }
        goto L801C8CD8;
        L801C882C: ;
        { c.V0 = 0u | 0x0002u;  }
        if (c.V1 == c.V0) {
            { c.V0 = 0u | 0x0003u;  }
            goto L801C88D0;
        }
        { c.V0 = 0u | 0x0003u;  }
        if (c.V1 == c.V0) {
            goto L801C8B14;
        }
        goto L801C8CD8;
        L801C8848: ;
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x818u;  }
        c.RA = 0x801C8858u; 
        SoTN_lib.InitializeEntity_lib(c, m);
        goto L801C8CD8;
        L801C8860: ;
        { c.A0 = 0u | 0x0004u;  }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3848u)); 
        { c.A1 = 0u | 0x0008u;  }
        c.RA = 0x801C8878u;
        Dispatcher.Call(c, m, c.V0);
        { c.V0 = c.V0 << 16;  }
        { c.A1 = (uint)((int)c.V0 >> 16);  }
        c.V0 = 0xFFFFFFFFu; 
        if (c.A1 == c.V0) {
            { c.V0 = c.A1 << 1;  }
            goto L801C8CD0;
        }
        { c.V0 = c.A1 << 1;  }
        { var _s = c.V0; var _t = c.A1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.A1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.V1 = 0x80080000u; 
        { c.V1 = c.V1 + 0x6FECu;  }
        { var _s = c.V0; var _t = c.V1; c.S0 = _s + _t;  }
        c.A0 = mem.ReadU16((c.S1 + 0x2Cu)); 
        c.V0 = mem.ReadU32((c.S1 + 0x34u)); 
        c.V1 = 0x00800000u; 
        mem.WriteU32((c.S1 + 0x64u), c.A1); 
        mem.WriteU32((c.S1 + 0x7Cu), c.S0); 
        { c.A0 = c.A0 + 0x1u;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s | _t;  }
        mem.WriteU32((c.S1 + 0x34u), c.V0); 
        mem.WriteU16((c.S1 + 0x2Cu), (ushort)c.A0); 
        goto L801C8CD8;
        L801C88D0: ;
        c.A0 = mem.ReadU32((c.S1 + 0x7Cu)); 
        { c.A1 = 0u | 0x0002u;  }
        c.RA = 0x801C88DCu; 
        SoTN_lib.FindFirstUnkPrim2_lib(c, m);
        c.S0 = c.V0; 
        if (c.S0 == 0u) {
            c.A0 = c.S0; 
            goto L801C8A00;
        }
        c.A0 = c.S0; 
        mem.WriteU32((c.S1 + 0x8Cu), c.S0); 
        c.RA = 0x801C88F0u; 
        SoTN_lib.UnkPolyFunc2_lib(c, m);
        { c.V1 = 0u | 0x0030u;  }
        mem.WriteU8((c.S0 + 0xDu), (byte)c.V1); 
        mem.WriteU8((c.S0 + 0x25u), (byte)c.V1); 
        c.V1 = mem.ReadU32(c.S0); 
        { c.V0 = 0u | 0x001Au;  }
        mem.WriteU16((c.S0 + 0x1Au), (ushort)c.V0); 
        { c.V0 = 0u | 0x01B7u;  }
        mem.WriteU16((c.S0 + 0xEu), (ushort)c.V0); 
        { c.V0 = 0u | 0x0050u;  }
        mem.WriteU8((c.S0 + 0xCu), (byte)c.V0); 
        mem.WriteU8((c.S0 + 0x18u), (byte)c.V0); 
        { c.V0 = 0u | 0x0040u;  }
        mem.WriteU8((c.S0 + 0x24u), (byte)c.V0); 
        mem.WriteU8((c.S0 + 0x30u), (byte)c.V0); 
        mem.WriteU8((c.S0 + 0x19u), (byte)c.V0); 
        mem.WriteU8((c.S0 + 0x31u), (byte)c.V0); 
        { c.V0 = 0u | 0x0060u;  }
        mem.WriteU8((c.V1 + 0x2Au), (byte)c.V0); 
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU16((c.S1 + 0x2u)); 
        mem.WriteU16((c.V1 + 0x14u), (ushort)c.V0); 
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU16((c.S1 + 0x6u)); 
        mem.WriteU16((c.V1 + 0xAu), (ushort)c.V0); 
        c.V0 = mem.ReadU32(c.S0); 
        { c.V1 = 0u | 0x0010u;  }
        mem.WriteU16((c.V0 + 0x1Cu), (ushort)c.V1); 
        c.V0 = mem.ReadU32(c.S0); 
        mem.WriteU16((c.V0 + 0x1Eu), (ushort)c.V1); 
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = 0xFFFFA000u; 
        mem.WriteU32((c.V1 + 0x10u), c.V0); 
        c.V0 = mem.ReadU16((c.S1 + 0x14u)); 
        if (c.V0 == 0u) {
            { c.V0 = 0u | 0xA000u;  }
            goto L801C89B8;
        }
        { c.V0 = 0u | 0xA000u;  }
        c.V1 = mem.ReadU32(c.S0); 
        mem.WriteU32((c.V1 + 0xCu), c.V0); 
        c.V1 = mem.ReadU32(c.S0); 
        { c.V0 = 0u | 0x0200u;  }
        mem.WriteU16((c.V1 + 0x1Au), (ushort)c.V0); 
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU16((c.V1 + 0x14u)); 
        { c.V0 = c.V0 + 0x4u;  }
        goto L801C89E8;
        L801C89B8: ;
        c.V1 = 0xFFFF0000u; 
        c.V0 = mem.ReadU32(c.S0); 
        { c.V1 = c.V1 | 0x6000u;  }
        mem.WriteU32((c.V0 + 0xCu), c.V1); 
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = 0xFFFFFE00u; 
        mem.WriteU16((c.V1 + 0x1Au), (ushort)c.V0); 
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU16((c.V1 + 0x14u)); 
        { c.V0 = c.V0 - 0x4u;  }
        L801C89E8: ;
        mem.WriteU16((c.V1 + 0x14u), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S1 + 0x24u)); 
        { c.V1 = 0u | 0x0006u;  }
        mem.WriteU16((c.S0 + 0x32u), (ushort)c.V1); 
        { c.V0 = c.V0 + 0x2u;  }
        mem.WriteU16((c.S0 + 0x26u), (ushort)c.V0); 
        L801C8A00: ;
        c.A0 = mem.ReadU32((c.S1 + 0x7Cu)); 
        { c.A1 = 0u | 0x0002u;  }
        c.RA = 0x801C8A0Cu; 
        SoTN_lib.FindFirstUnkPrim2_lib(c, m);
        c.S0 = c.V0; 
        if (c.S0 == 0u) {
            c.A0 = c.S0; 
            goto L801C8B00;
        }
        c.A0 = c.S0; 
        mem.WriteU32((c.S1 + 0x90u), c.S0); 
        c.RA = 0x801C8A20u; 
        SoTN_lib.UnkPolyFunc2_lib(c, m);
        { c.V1 = 0u | 0x0040u;  }
        mem.WriteU8((c.S0 + 0x19u), (byte)c.V1); 
        mem.WriteU8((c.S0 + 0x31u), (byte)c.V1); 
        c.V1 = mem.ReadU32(c.S0); 
        { c.V0 = 0u | 0x001Au;  }
        mem.WriteU16((c.S0 + 0x1Au), (ushort)c.V0); 
        { c.V0 = 0u | 0x01B7u;  }
        mem.WriteU16((c.S0 + 0xEu), (ushort)c.V0); 
        { c.V0 = 0u | 0x0020u;  }
        mem.WriteU8((c.S0 + 0xCu), (byte)c.V0); 
        mem.WriteU8((c.S0 + 0x18u), (byte)c.V0); 
        mem.WriteU8((c.S0 + 0x24u), (byte)0u); 
        mem.WriteU8((c.S0 + 0x30u), (byte)0u); 
        mem.WriteU8((c.S0 + 0xDu), (byte)c.V0); 
        mem.WriteU8((c.S0 + 0x25u), (byte)c.V0); 
        c.V0 = mem.ReadU16((c.S1 + 0x2u)); 
        mem.WriteU16((c.V1 + 0x14u), (ushort)c.V0); 
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU16((c.S1 + 0x6u)); 
        mem.WriteU16((c.V1 + 0xAu), (ushort)c.V0); 
        c.V1 = mem.ReadU32(c.S0); 
        { c.V0 = 0u | 0x0008u;  }
        mem.WriteU16((c.V1 + 0x1Cu), (ushort)c.V0); 
        c.V1 = mem.ReadU32(c.S0); 
        { c.V0 = 0u | 0x0010u;  }
        mem.WriteU16((c.V1 + 0x1Eu), (ushort)c.V0); 
        c.V1 = mem.ReadU32(c.S0); 
        { c.V0 = 0u | 0x0080u;  }
        mem.WriteU8((c.V1 + 0x2Au), (byte)c.V0); 
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = 0xFFFF8000u; 
        mem.WriteU32((c.V1 + 0x10u), c.V0); 
        c.V0 = mem.ReadU16((c.S1 + 0x14u)); 
        if (c.V0 == 0u) {
            { c.V0 = 0u | 0xC000u;  }
            goto L801C8AD0;
        }
        { c.V0 = 0u | 0xC000u;  }
        c.V1 = mem.ReadU32(c.S0); 
        mem.WriteU32((c.V1 + 0xCu), c.V0); 
        c.V1 = mem.ReadU32(c.S0); 
        { c.V0 = 0u | 0x0200u;  }
        goto L801C8AE8;
        L801C8AD0: ;
        c.V1 = 0xFFFF0000u; 
        c.V0 = mem.ReadU32(c.S0); 
        { c.V1 = c.V1 | 0x4000u;  }
        mem.WriteU32((c.V0 + 0xCu), c.V1); 
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = 0xFFFFFE00u; 
        L801C8AE8: ;
        mem.WriteU16((c.V1 + 0x1Au), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S1 + 0x24u)); 
        { c.V1 = 0u | 0x0006u;  }
        mem.WriteU16((c.S0 + 0x32u), (ushort)c.V1); 
        { c.V0 = c.V0 + 0x2u;  }
        mem.WriteU16((c.S0 + 0x26u), (ushort)c.V0); 
        L801C8B00: ;
        c.V0 = mem.ReadU16((c.S1 + 0x2Cu)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S1 + 0x2Cu), (ushort)c.V0); 
        goto L801C8CD8;
        L801C8B14: ;
        c.S0 = mem.ReadU32((c.S1 + 0x8Cu)); 
        c.A0 = c.S0; 
        c.RA = 0x801C8B20u; 
        SoTN_lib.UnkPrimHelper_lib(c, m);
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3668u)); 
        { c.V0 = c.V0 & 0x0001u;  }
        if (c.V0 == 0u) {
            goto L801C8B70;
        }
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU16((c.V1 + 0x1Cu)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.V1 + 0x1Cu), (ushort)c.V0); 
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU16((c.V1 + 0x1Eu)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.V1 + 0x1Eu), (ushort)c.V0); 
        { c.V0 = 0u | 0x01B7u;  }
        goto L801C8B74;
        L801C8B70: ;
        { c.V0 = 0u | 0x016Du;  }
        L801C8B74: ;
        mem.WriteU16((c.S0 + 0xEu), (ushort)c.V0); 
        c.V0 = mem.ReadU32(c.S0); 
        c.V1 = mem.ReadU32((c.V0 + 0x10u)); 
        { c.V1 = c.V1 + 0xC00u;  }
        mem.WriteU32((c.V0 + 0x10u), c.V1); 
        c.V0 = mem.ReadU16((c.S1 + 0x14u)); 
        if (c.V0 == 0u) {
            goto L801C8BB4;
        }
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU16((c.V1 + 0x1Au)); 
        { c.V0 = c.V0 + 0x18u;  }
        goto L801C8BC8;
        L801C8BB4: ;
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU16((c.V1 + 0x1Au)); 
        { c.V0 = c.V0 - 0x18u;  }
        L801C8BC8: ;
        mem.WriteU16((c.V1 + 0x1Au), (ushort)c.V0); 
        c.V1 = mem.ReadU32(c.S0); 
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x27CCu;  }
        c.V0 = mem.ReadU8((c.V1 + 0x2Au)); 
        c.A1 = c.S0; 
        { c.V0 = c.V0 + 0xFEu;  }
        mem.WriteU8((c.V1 + 0x2Au), (byte)c.V0); 
        c.RA = 0x801C8BECu; 
        SoTN_lib.UpdateAnimation_lib(c, m);
        if (c.V0 != 0u) {
            goto L801C8BFC;
        }
        c.A0 = c.S0; 
        c.RA = 0x801C8BFCu; 
        SoTN_lib.UnkPolyFunc0_lib(c, m);
        L801C8BFC: ;
        c.S0 = mem.ReadU32((c.S1 + 0x90u)); 
        c.A0 = c.S0; 
        c.RA = 0x801C8C08u; 
        SoTN_lib.UnkPrimHelper_lib(c, m);
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU16((c.V1 + 0x1Cu)); 
        { c.V0 = c.V0 + 0x2u;  }
        mem.WriteU16((c.V1 + 0x1Cu), (ushort)c.V0); 
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU16((c.V1 + 0x1Eu)); 
        { c.V0 = c.V0 + 0x2u;  }
        mem.WriteU16((c.V1 + 0x1Eu), (ushort)c.V0); 
        c.V0 = mem.ReadU8((c.S0 + 0x13u)); 
        { c.V0 = c.V0 < 0x00000004u ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x0010u;  }
            goto L801C8C58;
        }
        { c.V0 = 0u | 0x0010u;  }
        c.V1 = mem.ReadU32(c.S0); 
        mem.WriteU16((c.V1 + 0x1Eu), (ushort)c.V0); 
        L801C8C58: ;
        c.V0 = mem.ReadU32(c.S0); 
        c.V1 = mem.ReadU8((c.V0 + 0x2Au)); 
        { c.V1 = c.V1 + 0xFDu;  }
        mem.WriteU8((c.V0 + 0x2Au), (byte)c.V1); 
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU8((c.V1 + 0x2Au)); 
        { c.V0 = c.V0 < 0x000000F1u ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L801C8C90;
        }
        mem.WriteU8((c.V1 + 0x2Au), (byte)0u); 
        L801C8C90: ;
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x27E4u;  }
        c.A1 = c.S0; 
        c.RA = 0x801C8CA0u; 
        SoTN_lib.UpdateAnimation_lib(c, m);
        if (c.V0 != 0u) {
            goto L801C8CB0;
        }
        c.A0 = c.S0; 
        c.RA = 0x801C8CB0u; 
        SoTN_lib.UnkPolyFunc0_lib(c, m);
        L801C8CB0: ;
        c.V0 = mem.ReadU16((c.S1 + 0x80u)); 
        { c.V1 = c.V0 + 0x1u;  }
        { c.V0 = c.V0 << 16;  }
        { c.V0 = (uint)((int)c.V0 >> 16);  }
        { c.V0 = (int)c.V0 < 129 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            mem.WriteU16((c.S1 + 0x80u), (ushort)c.V1); 
            goto L801C8CD8;
        }
        mem.WriteU16((c.S1 + 0x80u), (ushort)c.V1); 
        L801C8CD0: ;
        c.A0 = c.S1; 
        c.RA = 0x801C8CD8u; 
        SoTN_lib.DestroyEntity_lib(c, m);
        L801C8CD8: ;
        c.RA = mem.ReadU32((c.SP + 0x18u)); 
        c.S1 = mem.ReadU32((c.SP + 0x14u)); 
        c.S0 = mem.ReadU32((c.SP + 0x10u)); 
        { c.SP = c.SP + 0x20u;  }
        return;
        { c.SP = c.SP - 0x18u;  }
        mem.WriteU32((c.SP + 0x10u), c.S0); 
        c.S0 = c.A0; 
        mem.WriteU32((c.SP + 0x14u), c.RA); 
        c.V0 = mem.ReadU32(c.S0); 
        c.V1 = mem.ReadU8((c.V0 + 0x24u)); 
        if (c.V1 == 0u) {
            { c.V0 = 0u | 0x0001u;  }
            goto L801C8D28;
        }
        { c.V0 = 0u | 0x0001u;  }
        if (c.V1 == c.V0) {
            goto L801C8E54;
        }
        goto L801C8E98;
        L801C8D28: ;
        { c.V0 = 0u | 0x0012u;  }
        mem.WriteU16((c.S0 + 0x1Au), (ushort)c.V0); 
        { c.V0 = 0u | 0x016Du;  }
        mem.WriteU16((c.S0 + 0xEu), (ushort)c.V0); 
        { c.V0 = 0u | 0x0050u;  }
        mem.WriteU8((c.S0 + 0xCu), (byte)c.V0); 
        c.V1 = mem.ReadU8((c.S0 + 0xCu)); 
        { c.V0 = 0u | 0x0060u;  }
        mem.WriteU8((c.S0 + 0x18u), (byte)c.V0); 
        c.A0 = mem.ReadU8((c.S0 + 0x18u)); 
        { c.V0 = 0u | 0x00EFu;  }
        mem.WriteU8((c.S0 + 0x19u), (byte)c.V0); 
        mem.WriteU8((c.S0 + 0xDu), (byte)c.V0); 
        { c.V0 = 0u | 0x00FFu;  }
        mem.WriteU8((c.S0 + 0x31u), (byte)c.V0); 
        mem.WriteU8((c.S0 + 0x25u), (byte)c.V0); 
        c.V0 = mem.ReadU32(c.S0); 
        mem.WriteU8((c.S0 + 0x24u), (byte)c.V1); 
        { c.V1 = 0u | 0x0010u;  }
        mem.WriteU8((c.S0 + 0x30u), (byte)c.A0); 
        mem.WriteU16((c.V0 + 0x1Cu), (ushort)c.V1); 
        c.V0 = mem.ReadU32(c.S0); 
        mem.WriteU16((c.V0 + 0x1Eu), (ushort)c.V1); 
        c.V1 = 0x80070000u; 
        c.V1 = mem.ReadU32((c.V1 - 0x3C48u)); 
        c.A0 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU16((c.V1 + 0x2u)); 
        mem.WriteU16((c.A0 + 0x14u), (ushort)c.V0); 
        c.A0 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU16((c.V1 + 0x6u)); 
        mem.WriteU16((c.A0 + 0xAu), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.V1 + 0x14u)); 
        if (c.V0 == 0u) {
            goto L801C8DD4;
        }
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU16((c.V1 + 0x14u)); 
        { c.V0 = c.V0 - 0x8u;  }
        goto L801C8DE8;
        L801C8DD4: ;
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU16((c.V1 + 0x14u)); 
        { c.V0 = c.V0 + 0x8u;  }
        L801C8DE8: ;
        mem.WriteU16((c.V1 + 0x14u), (ushort)c.V0); 
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU8((c.V1 + 0x28u)); 
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x4000u;  }
            goto L801C8E08;
        }
        { c.V0 = 0u | 0x4000u;  }
        c.V0 = 0xFFFFC000u; 
        L801C8E08: ;
        mem.WriteU32((c.V1 + 0xCu), c.V0); 
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = 0xFFFE0000u; 
        mem.WriteU32((c.V1 + 0x10u), c.V0); 
        c.V1 = mem.ReadU32(c.S0); 
        { c.V0 = 0u | 0x0080u;  }
        mem.WriteU8((c.V1 + 0x2Au), (byte)c.V0); 
        c.V0 = 0x80070000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3C48u)); 
        c.V0 = mem.ReadU16((c.V0 + 0x24u)); 
        { c.V1 = 0u | 0x0002u;  }
        mem.WriteU16((c.S0 + 0x32u), (ushort)c.V1); 
        c.V1 = mem.ReadU32(c.S0); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S0 + 0x26u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0001u;  }
        mem.WriteU8((c.V1 + 0x24u), (byte)c.V0); 
        goto L801C8E98;
        L801C8E54: ;
        c.A0 = c.S0; 
        c.RA = 0x801C8E5Cu; 
        SoTN_lib.UnkPrimHelper_lib(c, m);
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU32((c.V1 + 0x10u)); 
        { c.V0 = c.V0 + 0x2000u;  }
        mem.WriteU32((c.V1 + 0x10u), c.V0); 
        c.V0 = mem.ReadU32(c.S0); 
        c.V1 = mem.ReadU32((c.V0 + 0x10u)); 
        c.V0 = 0x00020000u; 
        { var _s = c.V0; var _t = c.V1; c.V0 = (int)_s < (int)_t ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L801C8E98;
        }
        c.A0 = c.S0; 
        c.RA = 0x801C8E98u; 
        SoTN_lib.UnkPolyFunc0_lib(c, m);
        L801C8E98: ;
        c.RA = mem.ReadU32((c.SP + 0x14u)); 
        c.S0 = mem.ReadU32((c.SP + 0x10u)); 
        { c.SP = c.SP + 0x18u;  }
        return;
        { c.SP = c.SP - 0x20u;  }
        mem.WriteU32((c.SP + 0x14u), c.S1); 
        c.S1 = c.A0; 
        mem.WriteU32((c.SP + 0x18u), c.RA); 
        mem.WriteU32((c.SP + 0x10u), c.S0); 
        c.V0 = mem.ReadU16((c.S1 + 0x44u)); 
        if (c.V0 == 0u) {
            goto L801C8EFC;
        }
        c.V0 = mem.ReadU16((c.S1 + 0x2Cu)); 
        { c.V0 = c.V0 & 0x0001u;  }
        if (c.V0 == 0u) {
            goto L801C8EFC;
        }
        { c.A0 = 0u | 0x0746u;  }
        c.RA = 0x801C8EECu; 
        SoTN_lib.PlaySfxPositional_lib(c, m);
        { c.A0 = 0u | 0x0748u;  }
        c.RA = 0x801C8EF4u; 
        SoTN_lib.PlaySfxPositional_lib(c, m);
        { c.A0 = 0u | 0x0006u;  }
        c.RA = 0x801C8EFCu; 
        SoTN_lib.SetStep_lib(c, m);
        L801C8EFC: ;
        c.V0 = mem.ReadU32((c.S1 + 0x34u)); 
        { c.V0 = c.V0 & 0x0100u;  }
        if (c.V0 == 0u) {
            goto L801C8F4C;
        }
        c.V0 = mem.ReadU16((c.S1 + 0x2Cu)); 
        { c.V0 = c.V0 < 0x00000008u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L801C8F4C;
        }
        { c.A0 = 0u | 0x0747u;  }
        c.RA = 0x801C8F2Cu; 
        SoTN_lib.PlaySfxPositional_lib(c, m);
        c.V1 = 0xDFFF0000u; 
        { c.V1 = c.V1 | 0xFFFFu;  }
        c.V0 = mem.ReadU32((c.S1 + 0x34u)); 
        { c.A0 = 0u | 0x0008u;  }
        mem.WriteU16((c.S1 + 0x3Cu), (ushort)0u); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s & _t;  }
        mem.WriteU32((c.S1 + 0x34u), c.V0); 
        c.RA = 0x801C8F4Cu; 
        SoTN_lib.SetStep_lib(c, m);
        L801C8F4C: ;
        c.V1 = mem.ReadU16((c.S1 + 0x2Cu)); 
        { c.V0 = c.V1 < 0x0000000Au ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.V0 = c.V1 << 2;  }
            Dispatcher.Call(c, m, 0x801C95FCu);
            return;
        }
        { c.V0 = c.V1 << 2;  }
        c.At = 0x801B0000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.V0 = mem.ReadU32((c.At - 0x2550u)); 
        switch (c.V0)
        {
            case 0x801C8F78u: goto L801C8F78;
            case 0x801C8FCCu: goto L801C8FCC;
            case 0x801C8FA8u: goto L801C8FA8;
            case 0x801C910Cu: goto L801C910C;
            default: Dispatcher.Call(c, m, c.V0); return;
        }
        L801C8F78: ;
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x86Cu;  }
        c.RA = 0x801C8F88u; 
        SoTN_lib.InitializeEntity_lib(c, m);
        { c.A0 = 0u | 0x0002u;  }
        { c.V0 = 0u | 0x0001u;  }
        mem.WriteU16((c.S1 + 0x10u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0004u;  }
        mem.WriteU16((c.S1 + 0x12u), (ushort)c.V0); 
        c.RA = 0x801C8FA0u; 
        SoTN_lib.SetStep_lib(c, m);
        Dispatcher.Call(c, m, 0x801C95FCu);
        return;
        L801C8FA8: ;
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x2714u;  }
        c.RA = 0x801C8FB8u; 
        SoTN_lib.UnkCollisionFunc3_lib(c, m);
        { c.V0 = c.V0 & 0x0001u;  }
        if (c.V0 == 0u) {
            Dispatcher.Call(c, m, 0x801C95FCu);
            return;
        }
        SoTN_lib.func_801C923C(c, m);
        return;
        L801C8FCC: ;
        c.V0 = mem.ReadU16((c.S1 + 0x2Eu)); 
        if (c.V0 != 0u) {
            { c.V1 = 0u | 0x0080u;  }
            goto L801C8FEC;
        }
        { c.V1 = 0u | 0x0080u;  }
        c.V0 = mem.ReadU16((c.S1 + 0x2Eu)); 
        mem.WriteU16((c.S1 + 0x80u), (ushort)c.V1); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S1 + 0x2Eu), (ushort)c.V0); 
        L801C8FEC: ;
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x272Cu;  }
        c.A1 = c.S1; 
        c.RA = 0x801C8FFCu; 
        SoTN_lib.AnimateEntity_lib(c, m);
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x2724u;  }
        c.RA = 0x801C900Cu; 
        SoTN_lib.UnkCollisionFunc2_lib(c, m);
        c.V0 = mem.ReadU16((c.S1 + 0x14u)); 
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x6000u;  }
            goto L801C9020;
        }
        { c.V0 = 0u | 0x6000u;  }
        c.V0 = 0xFFFFA000u; 
        L801C9020: ;
        mem.WriteU32((c.S1 + 0x8u), c.V0); 
        c.V0 = mem.ReadU16((c.S1 + 0x80u)); 
        { c.V0 = c.V0 - 0x1u;  }
        mem.WriteU16((c.S1 + 0x80u), (ushort)c.V0); 
        { c.V0 = c.V0 << 16;  }
        if (c.V0 != 0u) {
            { c.V1 = 0u | 0x0080u;  }
            goto L801C9050;
        }
        { c.V1 = 0u | 0x0080u;  }
        c.V0 = mem.ReadU16((c.S1 + 0x14u)); 
        mem.WriteU16((c.S1 + 0x80u), (ushort)c.V1); 
        { c.V0 = c.V0 ^ 0x0001u;  }
        mem.WriteU16((c.S1 + 0x14u), (ushort)c.V0); 
        L801C9050: ;
        c.RA = 0x801C9058u; 
        SoTN_lib.Random_lib(c, m);
        { c.V0 = c.V0 & 0x003Fu;  }
        if (c.V0 != 0u) {
            goto L801C90C8;
        }
        c.A0 = 0x80080000u; 
        { c.A0 = c.A0 - 0x27A8u;  }
        { c.A1 = c.A0 + 0x1780u;  }
        c.RA = 0x801C9074u; 
        SoTN_lib.AllocEntity_lib(c, m);
        c.S0 = c.V0; 
        if (c.S0 == 0u) {
            { c.A0 = 0u | 0x001Du;  }
            goto L801C90C8;
        }
        { c.A0 = 0u | 0x001Du;  }
        c.A1 = c.S1; 
        c.A2 = c.S0; 
        c.RA = 0x801C908Cu; 
        SoTN_lib.CreateEntityFromEntity_lib(c, m);
        c.V0 = mem.ReadU16((c.S1 + 0x14u)); 
        if (c.V0 == 0u) {
            goto L801C90A8;
        }
        c.V0 = mem.ReadU16((c.S0 + 0x2u)); 
        { c.V0 = c.V0 + 0x10u;  }
        goto L801C90B4;
        L801C90A8: ;
        c.V0 = mem.ReadU16((c.S0 + 0x2u)); 
        { c.V0 = c.V0 - 0x10u;  }
        L801C90B4: ;
        mem.WriteU16((c.S0 + 0x2u), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S0 + 0x6u)); 
        { c.V0 = c.V0 + 0xCu;  }
        mem.WriteU16((c.S0 + 0x6u), (ushort)c.V0); 
        L801C90C8: ;
        c.RA = 0x801C90D0u; 
        Dispatcher.Call(c, m, 0x801C29A4u);
        c.V1 = 0x80070000u; 
        c.V1 = mem.ReadU16((c.V1 + 0x33ECu)); 
        { c.S0 = c.V0 & 0x0001u;  }
        if (c.V1 != c.S0) {
            Dispatcher.Call(c, m, 0x801C95FCu);
            return;
        }
        c.RA = 0x801C90ECu; 
        SoTN_lib.GetDistanceToPlayerX_lib(c, m);
        { c.V0 = (int)c.V0 < 128 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.V0 = c.S0 ^ 0x0001u;  }
            Dispatcher.Call(c, m, 0x801C95FCu);
            return;
        }
        { c.V0 = c.S0 ^ 0x0001u;  }
        mem.WriteU16((c.S1 + 0x14u), (ushort)c.V0); 
        { c.A0 = 0u | 0x0003u;  }
        c.RA = 0x801C9104u; 
        SoTN_lib.SetStep_lib(c, m);
        Dispatcher.Call(c, m, 0x801C95FCu);
        return;
        L801C910C: ;
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x27BCu;  }
        c.A1 = c.S1; 
        c.RA = 0x801C911Cu; 
        SoTN_lib.AnimateEntity_lib(c, m);
        if (c.V0 != 0u) {
            goto L801C9138;
        }
        c.RA = 0x801C912Cu; 
        Dispatcher.Call(c, m, 0x801C29A4u);
        { c.V0 = c.V0 & 0x0001u;  }
        { c.V0 = c.V0 ^ 0x0001u;  }
        mem.WriteU16((c.S1 + 0x14u), (ushort)c.V0); 
        L801C9138: ;
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x2724u;  }
        c.RA = 0x801C9148u; 
        SoTN_lib.UnkCollisionFunc2_lib(c, m);
        c.V0 = mem.ReadU16((c.S1 + 0x14u)); 
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0xC000u;  }
            goto L801C9160;
        }
        { c.V0 = 0u | 0xC000u;  }
        c.V0 = 0xFFFF0000u; 
        { c.V0 = c.V0 | 0x4000u;  }
        L801C9160: ;
        mem.WriteU32((c.S1 + 0x8u), c.V0); 
        c.RA = 0x801C9168u; 
        SoTN_lib.Random_lib(c, m);
        { c.V0 = c.V0 & 0x003Fu;  }
        SoTN_no1.EntityBigRedFireball_no1(c, m);
        }
    public static bool EntityMessageBox_lib(CpuContext c, IMemory m)
    {
        if (!ScriptMemory.Enabled("lib", m, false)) return true;
        EntityMessageBox_lib_Body(c, m);
        return false;
    }
    private static void EntityMessageBox_lib_Body(CpuContext c, IMemory m)
    {
        var mem = new ScriptMemory(m, "lib", 0x801D51D8u);
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
            goto L801C87D0;
        }
        { c.V0 = c.V1 << 2;  }
        c.At = 0x801B0000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.V0 = mem.ReadU32((c.At - 0x2564u)); 
        switch (c.V0)
        {
            case 0x801C82DCu: goto L801C82DC;
            case 0x801C83C0u: goto L801C83C0;
            case 0x801C859Cu: goto L801C859C;
            case 0x801C8674u: goto L801C8674;
            case 0x801C8778u: goto L801C8778;
            case 0x801C8F78u: goto L801C8F78;
            case 0x801C8FCCu: goto L801C8FCC;
            case 0x801C8FA8u: goto L801C8FA8;
            case 0x801C910Cu: goto L801C910C;
            case 0x801C91FCu: goto L801C91FC;
            case 0x801C95FCu: goto L801C95FC;
            case 0x801C924Cu: goto L801C924C;
            case 0x801C92D8u: goto L801C92D8;
            case 0x801C9588u: goto L801C9588;
            default: Dispatcher.Call(c, m, c.V0); return;
        }
        L801C82DC: ;
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x80Cu;  }
        c.RA = 0x801C82ECu; 
        SoTN_lib.InitializeEntity_lib(c, m);
        c.V1 = 0x00010000u; 
        c.V0 = mem.ReadU32((c.S0 + 0x34u)); 
        c.A0 = mem.ReadU16((c.S0 + 0x30u)); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s | _t;  }
        c.V1 = 0x08000000u; 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s ^ _t;  }
        if (c.A0 != 0u) {
            mem.WriteU32((c.S0 + 0x34u), c.V0); 
            goto L801C8314;
        }
        mem.WriteU32((c.S0 + 0x34u), c.V0); 
        { c.V0 = 0u | 0x0060u;  }
        mem.WriteU16((c.S0 + 0x30u), (ushort)c.V0); 
        L801C8314: ;
        { c.A0 = 0u | 0x0004u;  }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3848u)); 
        { c.A1 = 0u | 0x0003u;  }
        c.RA = 0x801C832Cu;
        Dispatcher.Call(c, m, c.V0);
        { c.V0 = c.V0 << 16;  }
        { c.A0 = (uint)((int)c.V0 >> 16);  }
        c.V0 = 0xFFFFFFFFu; 
        if (c.A0 != c.V0) {
            { c.V0 = c.A0 << 1;  }
            goto L801C8348;
        }
        { c.V0 = c.A0 << 1;  }
        mem.WriteU16((c.S0 + 0x2Cu), (ushort)0u); 
        goto L801C87D0;
        L801C8348: ;
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
            goto L801C8394;
        }
        mem.WriteU32((c.S0 + 0x34u), c.V0); 
        { c.V0 = 0u | 0x0008u;  }
        L801C8380: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        mem.WriteU16((c.A1 + 0x32u), (ushort)c.V0); 
        c.A1 = mem.ReadU32(c.A1); 
        if (c.A1 != 0u) {
            goto L801C8380;
        }
        L801C8394: ;
        c.A0 = mem.ReadU32((c.S0 + 0x7Cu)); 
        c.V0 = mem.ReadU8(c.A0); 
        mem.WriteU16((c.S0 + 0x80u), (ushort)c.V0); 
        c.V0 = mem.ReadU32((c.S0 + 0x7Cu)); 
        c.V1 = mem.ReadU8((c.A0 + 0x1u)); 
        { c.V0 = c.V0 + 0x2u;  }
        mem.WriteU32((c.S0 + 0x7Cu), c.V0); 
        mem.WriteU16((c.S0 + 0x82u), (ushort)c.V1); 
        goto L801C87D0;
        L801C83C0: ;
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
        c.RA = 0x801C83F0u; 
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
            goto L801C8590;
        }
        c.A2 = 0u; 
        { c.A0 = 0u | 0x0080u;  }
        L801C8424: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        if (c.A2 != 0u) {
            { c.V0 = 0u | 0x0003u;  }
            goto L801C849C;
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
        goto L801C8580;
        L801C849C: ;
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
            goto L801C853C;
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
        goto L801C8560;
        L801C853C: ;
        c.V1 = mem.ReadU16((c.S0 + 0x82u)); 
        c.V0 = mem.ReadU16((c.S0 + 0x6u)); 
        mem.WriteU8((c.A1 + 0x29u), (byte)c.A0); 
        mem.WriteU8((c.A1 + 0x1Du), (byte)c.A0); 
        mem.WriteU8((c.A1 + 0x11u), (byte)c.A0); 
        mem.WriteU8((c.A1 + 0x5u), (byte)c.A0); 
        { c.V1 = c.V1 >> 1;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 + 0x4u;  }
        L801C8560: ;
        mem.WriteU16((c.A1 + 0x2Eu), (ushort)c.V0); 
        mem.WriteU16((c.A1 + 0x22u), (ushort)c.V0); 
        mem.WriteU16((c.A1 + 0x16u), (ushort)c.V0); 
        mem.WriteU16((c.A1 + 0xAu), (ushort)c.V0); 
        { c.V0 = 0u | 0x01FCu;  }
        mem.WriteU16((c.A1 + 0x26u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0011u;  }
        mem.WriteU16((c.A1 + 0x32u), (ushort)c.V0); 
        L801C8580: ;
        c.A1 = mem.ReadU32(c.A1); 
        if (c.A1 != 0u) {
            { c.A2 = c.A2 + 0x1u;  }
            goto L801C8424;
        }
        { c.A2 = c.A2 + 0x1u;  }
        L801C8590: ;
        c.V0 = mem.ReadU16((c.S0 + 0x2Cu)); 
        { c.V0 = c.V0 + 0x1u;  }
        goto L801C8770;
        L801C859C: ;
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
            goto L801C85F8;
        }
        mem.WriteU16((c.SP + 0x28u), (ushort)0u); 
        L801C85CC: ;
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
            goto L801C85CC;
        }
        { c.S1 = c.S1 + 0x1u;  }
        c.S1 = c.S2; 
        L801C85F8: ;
        { c.S3 = 0u | 0x0001u;  }
        L801C85FC: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V0 = mem.ReadU8(c.A0); 
        if (c.V0 == 0u) {
            c.A1 = 0u; 
            goto L801C8644;
        }
        c.A1 = 0u; 
        if (c.V0 != c.S3) {
            { c.A1 = c.SP + 0x28u;  }
            goto L801C862C;
        }
        { c.A1 = c.SP + 0x28u;  }
        c.V0 = mem.ReadU16((c.S0 + 0x80u)); 
        { c.A0 = c.A0 + 0x1u;  }
        mem.WriteU16((c.SP + 0x28u), (ushort)0u); 
        { c.V0 = c.V0 << 3;  }
        { var _s = c.S2; var _t = c.V0; c.S1 = _s + _t;  }
        goto L801C85FC;
        L801C862C: ;
        c.A3 = mem.ReadU16((c.S0 + 0x80u)); 
        c.A2 = c.S1; 
        { c.A3 = c.A3 >> 1;  }
        c.RA = 0x801C863Cu; 
        SoTN_lib.BlitChar_lib(c, m);
        c.A0 = c.V0; 
        goto L801C85FC;
        L801C8644: ;
        c.A0 = c.S2; 
        { c.V0 = 0u | 0x0180u;  }
        mem.WriteU32((c.SP + 0x10u), c.V0); 
        c.V0 = mem.ReadU16((c.S0 + 0x80u)); 
        c.A2 = 0u; 
        mem.WriteU32((c.SP + 0x14u), c.V0); 
        c.V0 = mem.ReadU16((c.S0 + 0x82u)); 
        c.A3 = 0u; 
        mem.WriteU32((c.SP + 0x18u), c.V0); 
        c.RA = 0x801C866Cu; 
        SoTN_main.LoadTPage(c, m);
        goto L801C8764;
        L801C8674: ;
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
            goto L801C8754;
        }
        c.A2 = 0u; 
        L801C86B0: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        if (c.A2 != 0u) {
            goto L801C8700;
        }
        c.V0 = mem.ReadU16((c.S0 + 0x82u)); 
        c.V1 = mem.ReadU16((c.S0 + 0x86u)); 
        { c.V0 = c.V0 + 0x8u;  }
        { var _s = c.V0; var _t = c.V1; var _r = (long)(int)_s * (int)_t; c.LO = (uint)_r; c.HI = (uint)(_r >> 32);  }
        c.V0 = c.LO; 
        if ((int)c.V0 >= 0) {
            goto L801C86D8;
        }
        { c.V0 = c.V0 + 0x7u;  }
        L801C86D8: ;
        { c.V0 = (uint)((int)c.V0 >> 3);  }
        c.V1 = mem.ReadU16((c.A1 + 0xAu)); 
        c.A0 = mem.ReadU8((c.A1 + 0x12u)); 
        { var _s = c.V1; var _t = c.V0; c.V1 = _s + _t;  }
        { c.A0 = c.A0 - 0x10u;  }
        mem.WriteU16((c.A1 + 0x2Eu), (ushort)c.V1); 
        mem.WriteU16((c.A1 + 0x22u), (ushort)c.V1); 
        mem.WriteU8((c.A1 + 0x12u), (byte)c.A0); 
        mem.WriteU8((c.A1 + 0x6u), (byte)c.A0); 
        goto L801C8744;
        L801C8700: ;
        c.V0 = mem.ReadU16((c.S0 + 0x82u)); 
        c.V1 = mem.ReadU16((c.S0 + 0x86u)); 
        { c.V0 = c.V0 + 0x8u;  }
        { var _s = c.V0; var _t = c.V1; var _r = (long)(int)_s * (int)_t; c.LO = (uint)_r; c.HI = (uint)(_r >> 32);  }
        c.V0 = c.LO; 
        if ((int)c.V0 >= 0) {
            goto L801C8720;
        }
        { c.V0 = c.V0 + 0x7u;  }
        L801C8720: ;
        { c.V0 = (uint)((int)c.V0 >> 3);  }
        c.V1 = mem.ReadU16((c.A1 + 0x22u)); 
        c.A0 = mem.ReadU8((c.A1 + 0x29u)); 
        { var _s = c.V1; var _t = c.V0; c.V1 = _s - _t;  }
        { c.A0 = c.A0 - 0x10u;  }
        mem.WriteU16((c.A1 + 0x16u), (ushort)c.V1); 
        mem.WriteU16((c.A1 + 0xAu), (ushort)c.V1); 
        mem.WriteU8((c.A1 + 0x29u), (byte)c.A0); 
        mem.WriteU8((c.A1 + 0x1Du), (byte)c.A0); 
        L801C8744: ;
        c.A1 = mem.ReadU32(c.A1); 
        if (c.A1 != 0u) {
            { c.A2 = c.A2 + 0x1u;  }
            goto L801C86B0;
        }
        { c.A2 = c.A2 + 0x1u;  }
        L801C8754: ;
        c.V1 = mem.ReadU16((c.S0 + 0x86u)); 
        { c.V0 = 0u | 0x0008u;  }
        if (c.V1 != c.V0) {
            goto L801C87D0;
        }
        L801C8764: ;
        c.V0 = mem.ReadU16((c.S0 + 0x2Cu)); 
        mem.WriteU16((c.S0 + 0x86u), (ushort)0u); 
        { c.V0 = c.V0 + 0x1u;  }
        L801C8770: ;
        mem.WriteU16((c.S0 + 0x2Cu), (ushort)c.V0); 
        goto L801C87D0;
        L801C8778: ;
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
            goto L801C87D0;
        }
        c.A0 = c.S0; 
        c.RA = 0x801C87D0u; 
        SoTN_lib.DestroyEntity_lib(c, m);
        L801C87D0: ;
        c.RA = mem.ReadU32((c.SP + 0x48u)); 
        c.S3 = mem.ReadU32((c.SP + 0x44u)); 
        c.S2 = mem.ReadU32((c.SP + 0x40u)); 
        c.S1 = mem.ReadU32((c.SP + 0x3Cu)); 
        c.S0 = mem.ReadU32((c.SP + 0x38u)); 
        { c.SP = c.SP + 0x50u;  }
        return;
        { c.SP = c.SP - 0x20u;  }
        mem.WriteU32((c.SP + 0x14u), c.S1); 
        c.S1 = c.A0; 
        mem.WriteU32((c.SP + 0x18u), c.RA); 
        mem.WriteU32((c.SP + 0x10u), c.S0); 
        c.V1 = mem.ReadU16((c.S1 + 0x2Cu)); 
        { c.V0 = 0u | 0x0001u;  }
        if (c.V1 == c.V0) {
            { c.V0 = (int)c.V1 < 2 ? 1u : 0u;  }
            goto L801C8860;
        }
        { c.V0 = (int)c.V1 < 2 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L801C882C;
        }
        if (c.V1 == 0u) {
            goto L801C8848;
        }
        goto L801C8CD8;
        L801C882C: ;
        { c.V0 = 0u | 0x0002u;  }
        if (c.V1 == c.V0) {
            { c.V0 = 0u | 0x0003u;  }
            goto L801C88D0;
        }
        { c.V0 = 0u | 0x0003u;  }
        if (c.V1 == c.V0) {
            goto L801C8B14;
        }
        goto L801C8CD8;
        L801C8848: ;
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x818u;  }
        c.RA = 0x801C8858u; 
        SoTN_lib.InitializeEntity_lib(c, m);
        goto L801C8CD8;
        L801C8860: ;
        { c.A0 = 0u | 0x0004u;  }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3848u)); 
        { c.A1 = 0u | 0x0008u;  }
        c.RA = 0x801C8878u;
        Dispatcher.Call(c, m, c.V0);
        { c.V0 = c.V0 << 16;  }
        { c.A1 = (uint)((int)c.V0 >> 16);  }
        c.V0 = 0xFFFFFFFFu; 
        if (c.A1 == c.V0) {
            { c.V0 = c.A1 << 1;  }
            goto L801C8CD0;
        }
        { c.V0 = c.A1 << 1;  }
        { var _s = c.V0; var _t = c.A1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.A1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.V1 = 0x80080000u; 
        { c.V1 = c.V1 + 0x6FECu;  }
        { var _s = c.V0; var _t = c.V1; c.S0 = _s + _t;  }
        c.A0 = mem.ReadU16((c.S1 + 0x2Cu)); 
        c.V0 = mem.ReadU32((c.S1 + 0x34u)); 
        c.V1 = 0x00800000u; 
        mem.WriteU32((c.S1 + 0x64u), c.A1); 
        mem.WriteU32((c.S1 + 0x7Cu), c.S0); 
        { c.A0 = c.A0 + 0x1u;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s | _t;  }
        mem.WriteU32((c.S1 + 0x34u), c.V0); 
        mem.WriteU16((c.S1 + 0x2Cu), (ushort)c.A0); 
        goto L801C8CD8;
        L801C88D0: ;
        c.A0 = mem.ReadU32((c.S1 + 0x7Cu)); 
        { c.A1 = 0u | 0x0002u;  }
        c.RA = 0x801C88DCu; 
        SoTN_lib.FindFirstUnkPrim2_lib(c, m);
        c.S0 = c.V0; 
        if (c.S0 == 0u) {
            c.A0 = c.S0; 
            goto L801C8A00;
        }
        c.A0 = c.S0; 
        mem.WriteU32((c.S1 + 0x8Cu), c.S0); 
        c.RA = 0x801C88F0u; 
        SoTN_lib.UnkPolyFunc2_lib(c, m);
        { c.V1 = 0u | 0x0030u;  }
        mem.WriteU8((c.S0 + 0xDu), (byte)c.V1); 
        mem.WriteU8((c.S0 + 0x25u), (byte)c.V1); 
        c.V1 = mem.ReadU32(c.S0); 
        { c.V0 = 0u | 0x001Au;  }
        mem.WriteU16((c.S0 + 0x1Au), (ushort)c.V0); 
        { c.V0 = 0u | 0x01B7u;  }
        mem.WriteU16((c.S0 + 0xEu), (ushort)c.V0); 
        { c.V0 = 0u | 0x0050u;  }
        mem.WriteU8((c.S0 + 0xCu), (byte)c.V0); 
        mem.WriteU8((c.S0 + 0x18u), (byte)c.V0); 
        { c.V0 = 0u | 0x0040u;  }
        mem.WriteU8((c.S0 + 0x24u), (byte)c.V0); 
        mem.WriteU8((c.S0 + 0x30u), (byte)c.V0); 
        mem.WriteU8((c.S0 + 0x19u), (byte)c.V0); 
        mem.WriteU8((c.S0 + 0x31u), (byte)c.V0); 
        { c.V0 = 0u | 0x0060u;  }
        mem.WriteU8((c.V1 + 0x2Au), (byte)c.V0); 
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU16((c.S1 + 0x2u)); 
        mem.WriteU16((c.V1 + 0x14u), (ushort)c.V0); 
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU16((c.S1 + 0x6u)); 
        mem.WriteU16((c.V1 + 0xAu), (ushort)c.V0); 
        c.V0 = mem.ReadU32(c.S0); 
        { c.V1 = 0u | 0x0010u;  }
        mem.WriteU16((c.V0 + 0x1Cu), (ushort)c.V1); 
        c.V0 = mem.ReadU32(c.S0); 
        mem.WriteU16((c.V0 + 0x1Eu), (ushort)c.V1); 
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = 0xFFFFA000u; 
        mem.WriteU32((c.V1 + 0x10u), c.V0); 
        c.V0 = mem.ReadU16((c.S1 + 0x14u)); 
        if (c.V0 == 0u) {
            { c.V0 = 0u | 0xA000u;  }
            goto L801C89B8;
        }
        { c.V0 = 0u | 0xA000u;  }
        c.V1 = mem.ReadU32(c.S0); 
        mem.WriteU32((c.V1 + 0xCu), c.V0); 
        c.V1 = mem.ReadU32(c.S0); 
        { c.V0 = 0u | 0x0200u;  }
        mem.WriteU16((c.V1 + 0x1Au), (ushort)c.V0); 
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU16((c.V1 + 0x14u)); 
        { c.V0 = c.V0 + 0x4u;  }
        goto L801C89E8;
        L801C89B8: ;
        c.V1 = 0xFFFF0000u; 
        c.V0 = mem.ReadU32(c.S0); 
        { c.V1 = c.V1 | 0x6000u;  }
        mem.WriteU32((c.V0 + 0xCu), c.V1); 
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = 0xFFFFFE00u; 
        mem.WriteU16((c.V1 + 0x1Au), (ushort)c.V0); 
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU16((c.V1 + 0x14u)); 
        { c.V0 = c.V0 - 0x4u;  }
        L801C89E8: ;
        mem.WriteU16((c.V1 + 0x14u), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S1 + 0x24u)); 
        { c.V1 = 0u | 0x0006u;  }
        mem.WriteU16((c.S0 + 0x32u), (ushort)c.V1); 
        { c.V0 = c.V0 + 0x2u;  }
        mem.WriteU16((c.S0 + 0x26u), (ushort)c.V0); 
        L801C8A00: ;
        c.A0 = mem.ReadU32((c.S1 + 0x7Cu)); 
        { c.A1 = 0u | 0x0002u;  }
        c.RA = 0x801C8A0Cu; 
        SoTN_lib.FindFirstUnkPrim2_lib(c, m);
        c.S0 = c.V0; 
        if (c.S0 == 0u) {
            c.A0 = c.S0; 
            goto L801C8B00;
        }
        c.A0 = c.S0; 
        mem.WriteU32((c.S1 + 0x90u), c.S0); 
        c.RA = 0x801C8A20u; 
        SoTN_lib.UnkPolyFunc2_lib(c, m);
        { c.V1 = 0u | 0x0040u;  }
        mem.WriteU8((c.S0 + 0x19u), (byte)c.V1); 
        mem.WriteU8((c.S0 + 0x31u), (byte)c.V1); 
        c.V1 = mem.ReadU32(c.S0); 
        { c.V0 = 0u | 0x001Au;  }
        mem.WriteU16((c.S0 + 0x1Au), (ushort)c.V0); 
        { c.V0 = 0u | 0x01B7u;  }
        mem.WriteU16((c.S0 + 0xEu), (ushort)c.V0); 
        { c.V0 = 0u | 0x0020u;  }
        mem.WriteU8((c.S0 + 0xCu), (byte)c.V0); 
        mem.WriteU8((c.S0 + 0x18u), (byte)c.V0); 
        mem.WriteU8((c.S0 + 0x24u), (byte)0u); 
        mem.WriteU8((c.S0 + 0x30u), (byte)0u); 
        mem.WriteU8((c.S0 + 0xDu), (byte)c.V0); 
        mem.WriteU8((c.S0 + 0x25u), (byte)c.V0); 
        c.V0 = mem.ReadU16((c.S1 + 0x2u)); 
        mem.WriteU16((c.V1 + 0x14u), (ushort)c.V0); 
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU16((c.S1 + 0x6u)); 
        mem.WriteU16((c.V1 + 0xAu), (ushort)c.V0); 
        c.V1 = mem.ReadU32(c.S0); 
        { c.V0 = 0u | 0x0008u;  }
        mem.WriteU16((c.V1 + 0x1Cu), (ushort)c.V0); 
        c.V1 = mem.ReadU32(c.S0); 
        { c.V0 = 0u | 0x0010u;  }
        mem.WriteU16((c.V1 + 0x1Eu), (ushort)c.V0); 
        c.V1 = mem.ReadU32(c.S0); 
        { c.V0 = 0u | 0x0080u;  }
        mem.WriteU8((c.V1 + 0x2Au), (byte)c.V0); 
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = 0xFFFF8000u; 
        mem.WriteU32((c.V1 + 0x10u), c.V0); 
        c.V0 = mem.ReadU16((c.S1 + 0x14u)); 
        if (c.V0 == 0u) {
            { c.V0 = 0u | 0xC000u;  }
            goto L801C8AD0;
        }
        { c.V0 = 0u | 0xC000u;  }
        c.V1 = mem.ReadU32(c.S0); 
        mem.WriteU32((c.V1 + 0xCu), c.V0); 
        c.V1 = mem.ReadU32(c.S0); 
        { c.V0 = 0u | 0x0200u;  }
        goto L801C8AE8;
        L801C8AD0: ;
        c.V1 = 0xFFFF0000u; 
        c.V0 = mem.ReadU32(c.S0); 
        { c.V1 = c.V1 | 0x4000u;  }
        mem.WriteU32((c.V0 + 0xCu), c.V1); 
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = 0xFFFFFE00u; 
        L801C8AE8: ;
        mem.WriteU16((c.V1 + 0x1Au), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S1 + 0x24u)); 
        { c.V1 = 0u | 0x0006u;  }
        mem.WriteU16((c.S0 + 0x32u), (ushort)c.V1); 
        { c.V0 = c.V0 + 0x2u;  }
        mem.WriteU16((c.S0 + 0x26u), (ushort)c.V0); 
        L801C8B00: ;
        c.V0 = mem.ReadU16((c.S1 + 0x2Cu)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S1 + 0x2Cu), (ushort)c.V0); 
        goto L801C8CD8;
        L801C8B14: ;
        c.S0 = mem.ReadU32((c.S1 + 0x8Cu)); 
        c.A0 = c.S0; 
        c.RA = 0x801C8B20u; 
        SoTN_lib.UnkPrimHelper_lib(c, m);
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3668u)); 
        { c.V0 = c.V0 & 0x0001u;  }
        if (c.V0 == 0u) {
            goto L801C8B70;
        }
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU16((c.V1 + 0x1Cu)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.V1 + 0x1Cu), (ushort)c.V0); 
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU16((c.V1 + 0x1Eu)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.V1 + 0x1Eu), (ushort)c.V0); 
        { c.V0 = 0u | 0x01B7u;  }
        goto L801C8B74;
        L801C8B70: ;
        { c.V0 = 0u | 0x016Du;  }
        L801C8B74: ;
        mem.WriteU16((c.S0 + 0xEu), (ushort)c.V0); 
        c.V0 = mem.ReadU32(c.S0); 
        c.V1 = mem.ReadU32((c.V0 + 0x10u)); 
        { c.V1 = c.V1 + 0xC00u;  }
        mem.WriteU32((c.V0 + 0x10u), c.V1); 
        c.V0 = mem.ReadU16((c.S1 + 0x14u)); 
        if (c.V0 == 0u) {
            goto L801C8BB4;
        }
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU16((c.V1 + 0x1Au)); 
        { c.V0 = c.V0 + 0x18u;  }
        goto L801C8BC8;
        L801C8BB4: ;
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU16((c.V1 + 0x1Au)); 
        { c.V0 = c.V0 - 0x18u;  }
        L801C8BC8: ;
        mem.WriteU16((c.V1 + 0x1Au), (ushort)c.V0); 
        c.V1 = mem.ReadU32(c.S0); 
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x27CCu;  }
        c.V0 = mem.ReadU8((c.V1 + 0x2Au)); 
        c.A1 = c.S0; 
        { c.V0 = c.V0 + 0xFEu;  }
        mem.WriteU8((c.V1 + 0x2Au), (byte)c.V0); 
        c.RA = 0x801C8BECu; 
        SoTN_lib.UpdateAnimation_lib(c, m);
        if (c.V0 != 0u) {
            goto L801C8BFC;
        }
        c.A0 = c.S0; 
        c.RA = 0x801C8BFCu; 
        SoTN_lib.UnkPolyFunc0_lib(c, m);
        L801C8BFC: ;
        c.S0 = mem.ReadU32((c.S1 + 0x90u)); 
        c.A0 = c.S0; 
        c.RA = 0x801C8C08u; 
        SoTN_lib.UnkPrimHelper_lib(c, m);
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU16((c.V1 + 0x1Cu)); 
        { c.V0 = c.V0 + 0x2u;  }
        mem.WriteU16((c.V1 + 0x1Cu), (ushort)c.V0); 
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU16((c.V1 + 0x1Eu)); 
        { c.V0 = c.V0 + 0x2u;  }
        mem.WriteU16((c.V1 + 0x1Eu), (ushort)c.V0); 
        c.V0 = mem.ReadU8((c.S0 + 0x13u)); 
        { c.V0 = c.V0 < 0x00000004u ? 1u : 0u;  }
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x0010u;  }
            goto L801C8C58;
        }
        { c.V0 = 0u | 0x0010u;  }
        c.V1 = mem.ReadU32(c.S0); 
        mem.WriteU16((c.V1 + 0x1Eu), (ushort)c.V0); 
        L801C8C58: ;
        c.V0 = mem.ReadU32(c.S0); 
        c.V1 = mem.ReadU8((c.V0 + 0x2Au)); 
        { c.V1 = c.V1 + 0xFDu;  }
        mem.WriteU8((c.V0 + 0x2Au), (byte)c.V1); 
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU8((c.V1 + 0x2Au)); 
        { c.V0 = c.V0 < 0x000000F1u ? 1u : 0u;  }
        if (c.V0 != 0u) {
            goto L801C8C90;
        }
        mem.WriteU8((c.V1 + 0x2Au), (byte)0u); 
        L801C8C90: ;
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x27E4u;  }
        c.A1 = c.S0; 
        c.RA = 0x801C8CA0u; 
        SoTN_lib.UpdateAnimation_lib(c, m);
        if (c.V0 != 0u) {
            goto L801C8CB0;
        }
        c.A0 = c.S0; 
        c.RA = 0x801C8CB0u; 
        SoTN_lib.UnkPolyFunc0_lib(c, m);
        L801C8CB0: ;
        c.V0 = mem.ReadU16((c.S1 + 0x80u)); 
        { c.V1 = c.V0 + 0x1u;  }
        { c.V0 = c.V0 << 16;  }
        { c.V0 = (uint)((int)c.V0 >> 16);  }
        { c.V0 = (int)c.V0 < 129 ? 1u : 0u;  }
        if (c.V0 != 0u) {
            mem.WriteU16((c.S1 + 0x80u), (ushort)c.V1); 
            goto L801C8CD8;
        }
        mem.WriteU16((c.S1 + 0x80u), (ushort)c.V1); 
        L801C8CD0: ;
        c.A0 = c.S1; 
        c.RA = 0x801C8CD8u; 
        SoTN_lib.DestroyEntity_lib(c, m);
        L801C8CD8: ;
        c.RA = mem.ReadU32((c.SP + 0x18u)); 
        c.S1 = mem.ReadU32((c.SP + 0x14u)); 
        c.S0 = mem.ReadU32((c.SP + 0x10u)); 
        { c.SP = c.SP + 0x20u;  }
        return;
        { c.SP = c.SP - 0x18u;  }
        mem.WriteU32((c.SP + 0x10u), c.S0); 
        c.S0 = c.A0; 
        mem.WriteU32((c.SP + 0x14u), c.RA); 
        c.V0 = mem.ReadU32(c.S0); 
        c.V1 = mem.ReadU8((c.V0 + 0x24u)); 
        if (c.V1 == 0u) {
            { c.V0 = 0u | 0x0001u;  }
            goto L801C8D28;
        }
        { c.V0 = 0u | 0x0001u;  }
        if (c.V1 == c.V0) {
            goto L801C8E54;
        }
        goto L801C8E98;
        L801C8D28: ;
        { c.V0 = 0u | 0x0012u;  }
        mem.WriteU16((c.S0 + 0x1Au), (ushort)c.V0); 
        { c.V0 = 0u | 0x016Du;  }
        mem.WriteU16((c.S0 + 0xEu), (ushort)c.V0); 
        { c.V0 = 0u | 0x0050u;  }
        mem.WriteU8((c.S0 + 0xCu), (byte)c.V0); 
        c.V1 = mem.ReadU8((c.S0 + 0xCu)); 
        { c.V0 = 0u | 0x0060u;  }
        mem.WriteU8((c.S0 + 0x18u), (byte)c.V0); 
        c.A0 = mem.ReadU8((c.S0 + 0x18u)); 
        { c.V0 = 0u | 0x00EFu;  }
        mem.WriteU8((c.S0 + 0x19u), (byte)c.V0); 
        mem.WriteU8((c.S0 + 0xDu), (byte)c.V0); 
        { c.V0 = 0u | 0x00FFu;  }
        mem.WriteU8((c.S0 + 0x31u), (byte)c.V0); 
        mem.WriteU8((c.S0 + 0x25u), (byte)c.V0); 
        c.V0 = mem.ReadU32(c.S0); 
        mem.WriteU8((c.S0 + 0x24u), (byte)c.V1); 
        { c.V1 = 0u | 0x0010u;  }
        mem.WriteU8((c.S0 + 0x30u), (byte)c.A0); 
        mem.WriteU16((c.V0 + 0x1Cu), (ushort)c.V1); 
        c.V0 = mem.ReadU32(c.S0); 
        mem.WriteU16((c.V0 + 0x1Eu), (ushort)c.V1); 
        c.V1 = 0x80070000u; 
        c.V1 = mem.ReadU32((c.V1 - 0x3C48u)); 
        c.A0 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU16((c.V1 + 0x2u)); 
        mem.WriteU16((c.A0 + 0x14u), (ushort)c.V0); 
        c.A0 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU16((c.V1 + 0x6u)); 
        mem.WriteU16((c.A0 + 0xAu), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.V1 + 0x14u)); 
        if (c.V0 == 0u) {
            goto L801C8DD4;
        }
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU16((c.V1 + 0x14u)); 
        { c.V0 = c.V0 - 0x8u;  }
        goto L801C8DE8;
        L801C8DD4: ;
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU16((c.V1 + 0x14u)); 
        { c.V0 = c.V0 + 0x8u;  }
        L801C8DE8: ;
        mem.WriteU16((c.V1 + 0x14u), (ushort)c.V0); 
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU8((c.V1 + 0x28u)); 
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x4000u;  }
            goto L801C8E08;
        }
        { c.V0 = 0u | 0x4000u;  }
        c.V0 = 0xFFFFC000u; 
        L801C8E08: ;
        mem.WriteU32((c.V1 + 0xCu), c.V0); 
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = 0xFFFE0000u; 
        mem.WriteU32((c.V1 + 0x10u), c.V0); 
        c.V1 = mem.ReadU32(c.S0); 
        { c.V0 = 0u | 0x0080u;  }
        mem.WriteU8((c.V1 + 0x2Au), (byte)c.V0); 
        c.V0 = 0x80070000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3C48u)); 
        c.V0 = mem.ReadU16((c.V0 + 0x24u)); 
        { c.V1 = 0u | 0x0002u;  }
        mem.WriteU16((c.S0 + 0x32u), (ushort)c.V1); 
        c.V1 = mem.ReadU32(c.S0); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S0 + 0x26u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0001u;  }
        mem.WriteU8((c.V1 + 0x24u), (byte)c.V0); 
        goto L801C8E98;
        L801C8E54: ;
        c.A0 = c.S0; 
        c.RA = 0x801C8E5Cu; 
        SoTN_lib.UnkPrimHelper_lib(c, m);
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU32((c.V1 + 0x10u)); 
        { c.V0 = c.V0 + 0x2000u;  }
        mem.WriteU32((c.V1 + 0x10u), c.V0); 
        c.V0 = mem.ReadU32(c.S0); 
        c.V1 = mem.ReadU32((c.V0 + 0x10u)); 
        c.V0 = 0x00020000u; 
        { var _s = c.V0; var _t = c.V1; c.V0 = (int)_s < (int)_t ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L801C8E98;
        }
        c.A0 = c.S0; 
        c.RA = 0x801C8E98u; 
        SoTN_lib.UnkPolyFunc0_lib(c, m);
        L801C8E98: ;
        c.RA = mem.ReadU32((c.SP + 0x14u)); 
        c.S0 = mem.ReadU32((c.SP + 0x10u)); 
        { c.SP = c.SP + 0x18u;  }
        return;
        { c.SP = c.SP - 0x20u;  }
        mem.WriteU32((c.SP + 0x14u), c.S1); 
        c.S1 = c.A0; 
        mem.WriteU32((c.SP + 0x18u), c.RA); 
        mem.WriteU32((c.SP + 0x10u), c.S0); 
        c.V0 = mem.ReadU16((c.S1 + 0x44u)); 
        if (c.V0 == 0u) {
            goto L801C8EFC;
        }
        c.V0 = mem.ReadU16((c.S1 + 0x2Cu)); 
        { c.V0 = c.V0 & 0x0001u;  }
        if (c.V0 == 0u) {
            goto L801C8EFC;
        }
        { c.A0 = 0u | 0x0746u;  }
        c.RA = 0x801C8EECu; 
        SoTN_lib.PlaySfxPositional_lib(c, m);
        { c.A0 = 0u | 0x0748u;  }
        c.RA = 0x801C8EF4u; 
        SoTN_lib.PlaySfxPositional_lib(c, m);
        { c.A0 = 0u | 0x0006u;  }
        c.RA = 0x801C8EFCu; 
        SoTN_lib.SetStep_lib(c, m);
        L801C8EFC: ;
        c.V0 = mem.ReadU32((c.S1 + 0x34u)); 
        { c.V0 = c.V0 & 0x0100u;  }
        if (c.V0 == 0u) {
            goto L801C8F4C;
        }
        c.V0 = mem.ReadU16((c.S1 + 0x2Cu)); 
        { c.V0 = c.V0 < 0x00000008u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L801C8F4C;
        }
        { c.A0 = 0u | 0x0747u;  }
        c.RA = 0x801C8F2Cu; 
        SoTN_lib.PlaySfxPositional_lib(c, m);
        c.V1 = 0xDFFF0000u; 
        { c.V1 = c.V1 | 0xFFFFu;  }
        c.V0 = mem.ReadU32((c.S1 + 0x34u)); 
        { c.A0 = 0u | 0x0008u;  }
        mem.WriteU16((c.S1 + 0x3Cu), (ushort)0u); 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s & _t;  }
        mem.WriteU32((c.S1 + 0x34u), c.V0); 
        c.RA = 0x801C8F4Cu; 
        SoTN_lib.SetStep_lib(c, m);
        L801C8F4C: ;
        c.V1 = mem.ReadU16((c.S1 + 0x2Cu)); 
        { c.V0 = c.V1 < 0x0000000Au ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.V0 = c.V1 << 2;  }
            goto L801C95FC;
        }
        { c.V0 = c.V1 << 2;  }
        c.At = 0x801B0000u; 
        { var _s = c.At; var _t = c.V0; c.At = _s + _t;  }
        c.V0 = mem.ReadU32((c.At - 0x2550u)); 
        switch (c.V0)
        {
            case 0x801C8F78u: goto L801C8F78;
            case 0x801C8FCCu: goto L801C8FCC;
            case 0x801C8FA8u: goto L801C8FA8;
            case 0x801C910Cu: goto L801C910C;
            case 0x801C91FCu: goto L801C91FC;
            case 0x801C95FCu: goto L801C95FC;
            case 0x801C924Cu: goto L801C924C;
            case 0x801C92D8u: goto L801C92D8;
            case 0x801C9588u: goto L801C9588;
            default: Dispatcher.Call(c, m, c.V0); return;
        }
        L801C8F78: ;
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x86Cu;  }
        c.RA = 0x801C8F88u; 
        SoTN_lib.InitializeEntity_lib(c, m);
        { c.A0 = 0u | 0x0002u;  }
        { c.V0 = 0u | 0x0001u;  }
        mem.WriteU16((c.S1 + 0x10u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0004u;  }
        mem.WriteU16((c.S1 + 0x12u), (ushort)c.V0); 
        c.RA = 0x801C8FA0u; 
        SoTN_lib.SetStep_lib(c, m);
        goto L801C95FC;
        L801C8FA8: ;
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x2714u;  }
        c.RA = 0x801C8FB8u; 
        SoTN_lib.UnkCollisionFunc3_lib(c, m);
        { c.V0 = c.V0 & 0x0001u;  }
        if (c.V0 == 0u) {
            goto L801C95FC;
        }
        goto L801C923C;
        L801C8FCC: ;
        c.V0 = mem.ReadU16((c.S1 + 0x2Eu)); 
        if (c.V0 != 0u) {
            { c.V1 = 0u | 0x0080u;  }
            goto L801C8FEC;
        }
        { c.V1 = 0u | 0x0080u;  }
        c.V0 = mem.ReadU16((c.S1 + 0x2Eu)); 
        mem.WriteU16((c.S1 + 0x80u), (ushort)c.V1); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S1 + 0x2Eu), (ushort)c.V0); 
        L801C8FEC: ;
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x272Cu;  }
        c.A1 = c.S1; 
        c.RA = 0x801C8FFCu; 
        SoTN_lib.AnimateEntity_lib(c, m);
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x2724u;  }
        c.RA = 0x801C900Cu; 
        SoTN_lib.UnkCollisionFunc2_lib(c, m);
        c.V0 = mem.ReadU16((c.S1 + 0x14u)); 
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0x6000u;  }
            goto L801C9020;
        }
        { c.V0 = 0u | 0x6000u;  }
        c.V0 = 0xFFFFA000u; 
        L801C9020: ;
        mem.WriteU32((c.S1 + 0x8u), c.V0); 
        c.V0 = mem.ReadU16((c.S1 + 0x80u)); 
        { c.V0 = c.V0 - 0x1u;  }
        mem.WriteU16((c.S1 + 0x80u), (ushort)c.V0); 
        { c.V0 = c.V0 << 16;  }
        if (c.V0 != 0u) {
            { c.V1 = 0u | 0x0080u;  }
            goto L801C9050;
        }
        { c.V1 = 0u | 0x0080u;  }
        c.V0 = mem.ReadU16((c.S1 + 0x14u)); 
        mem.WriteU16((c.S1 + 0x80u), (ushort)c.V1); 
        { c.V0 = c.V0 ^ 0x0001u;  }
        mem.WriteU16((c.S1 + 0x14u), (ushort)c.V0); 
        L801C9050: ;
        c.RA = 0x801C9058u; 
        SoTN_lib.Random_lib(c, m);
        { c.V0 = c.V0 & 0x003Fu;  }
        if (c.V0 != 0u) {
            goto L801C90C8;
        }
        c.A0 = 0x80080000u; 
        { c.A0 = c.A0 - 0x27A8u;  }
        { c.A1 = c.A0 + 0x1780u;  }
        c.RA = 0x801C9074u; 
        SoTN_lib.AllocEntity_lib(c, m);
        c.S0 = c.V0; 
        if (c.S0 == 0u) {
            { c.A0 = 0u | 0x001Du;  }
            goto L801C90C8;
        }
        { c.A0 = 0u | 0x001Du;  }
        c.A1 = c.S1; 
        c.A2 = c.S0; 
        c.RA = 0x801C908Cu; 
        SoTN_lib.CreateEntityFromEntity_lib(c, m);
        c.V0 = mem.ReadU16((c.S1 + 0x14u)); 
        if (c.V0 == 0u) {
            goto L801C90A8;
        }
        c.V0 = mem.ReadU16((c.S0 + 0x2u)); 
        { c.V0 = c.V0 + 0x10u;  }
        goto L801C90B4;
        L801C90A8: ;
        c.V0 = mem.ReadU16((c.S0 + 0x2u)); 
        { c.V0 = c.V0 - 0x10u;  }
        L801C90B4: ;
        mem.WriteU16((c.S0 + 0x2u), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S0 + 0x6u)); 
        { c.V0 = c.V0 + 0xCu;  }
        mem.WriteU16((c.S0 + 0x6u), (ushort)c.V0); 
        L801C90C8: ;
        c.RA = 0x801C90D0u; 
        Dispatcher.Call(c, m, 0x801C29A4u);
        c.V1 = 0x80070000u; 
        c.V1 = mem.ReadU16((c.V1 + 0x33ECu)); 
        { c.S0 = c.V0 & 0x0001u;  }
        if (c.V1 != c.S0) {
            goto L801C95FC;
        }
        c.RA = 0x801C90ECu; 
        SoTN_lib.GetDistanceToPlayerX_lib(c, m);
        { c.V0 = (int)c.V0 < 128 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.V0 = c.S0 ^ 0x0001u;  }
            goto L801C95FC;
        }
        { c.V0 = c.S0 ^ 0x0001u;  }
        mem.WriteU16((c.S1 + 0x14u), (ushort)c.V0); 
        { c.A0 = 0u | 0x0003u;  }
        c.RA = 0x801C9104u; 
        SoTN_lib.SetStep_lib(c, m);
        goto L801C95FC;
        L801C910C: ;
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x27BCu;  }
        c.A1 = c.S1; 
        c.RA = 0x801C911Cu; 
        SoTN_lib.AnimateEntity_lib(c, m);
        if (c.V0 != 0u) {
            goto L801C9138;
        }
        c.RA = 0x801C912Cu; 
        Dispatcher.Call(c, m, 0x801C29A4u);
        { c.V0 = c.V0 & 0x0001u;  }
        { c.V0 = c.V0 ^ 0x0001u;  }
        mem.WriteU16((c.S1 + 0x14u), (ushort)c.V0); 
        L801C9138: ;
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x2724u;  }
        c.RA = 0x801C9148u; 
        SoTN_lib.UnkCollisionFunc2_lib(c, m);
        c.V0 = mem.ReadU16((c.S1 + 0x14u)); 
        if (c.V0 != 0u) {
            { c.V0 = 0u | 0xC000u;  }
            goto L801C9160;
        }
        { c.V0 = 0u | 0xC000u;  }
        c.V0 = 0xFFFF0000u; 
        { c.V0 = c.V0 | 0x4000u;  }
        L801C9160: ;
        mem.WriteU32((c.S1 + 0x8u), c.V0); 
        c.RA = 0x801C9168u; 
        SoTN_lib.Random_lib(c, m);
        { c.V0 = c.V0 & 0x003Fu;  }
        if (c.V0 != 0u) {
            goto L801C91D8;
        }
        c.A0 = 0x80080000u; 
        { c.A0 = c.A0 - 0x27A8u;  }
        { c.A1 = c.A0 + 0x1780u;  }
        c.RA = 0x801C9184u; 
        SoTN_lib.AllocEntity_lib(c, m);
        c.S0 = c.V0; 
        if (c.S0 == 0u) {
            { c.A0 = 0u | 0x001Du;  }
            goto L801C91D8;
        }
        { c.A0 = 0u | 0x001Du;  }
        c.A1 = c.S1; 
        c.A2 = c.S0; 
        c.RA = 0x801C919Cu; 
        SoTN_lib.CreateEntityFromEntity_lib(c, m);
        c.V0 = mem.ReadU16((c.S1 + 0x14u)); 
        if (c.V0 == 0u) {
            goto L801C91B8;
        }
        c.V0 = mem.ReadU16((c.S0 + 0x2u)); 
        { c.V0 = c.V0 + 0x12u;  }
        goto L801C91C4;
        L801C91B8: ;
        c.V0 = mem.ReadU16((c.S0 + 0x2u)); 
        { c.V0 = c.V0 - 0x12u;  }
        L801C91C4: ;
        mem.WriteU16((c.S0 + 0x2u), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S0 + 0x6u)); 
        { c.V0 = c.V0 + 0xCu;  }
        mem.WriteU16((c.S0 + 0x6u), (ushort)c.V0); 
        L801C91D8: ;
        c.RA = 0x801C91E0u; 
        SoTN_lib.GetDistanceToPlayerX_lib(c, m);
        { c.V0 = (int)c.V0 < 40 ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L801C95FC;
        }
        { c.A0 = 0u | 0x0004u;  }
        c.RA = 0x801C91F4u; 
        SoTN_lib.SetStep_lib(c, m);
        goto L801C95FC;
        L801C91FC: ;
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x273Cu;  }
        c.A1 = c.S1; 
        c.RA = 0x801C920Cu; 
        SoTN_lib.AnimateEntity_lib(c, m);
        c.S0 = c.V0; 
        { c.V0 = c.S0 & 0x0080u;  }
        if (c.V0 == 0u) {
            { c.V0 = 0u | 0x000Au;  }
            goto L801C9234;
        }
        { c.V0 = 0u | 0x000Au;  }
        c.V1 = mem.ReadU16((c.S1 + 0x50u)); 
        if (c.V1 != c.V0) {
            goto L801C9234;
        }
        { c.A0 = 0u | 0x060Bu;  }
        c.RA = 0x801C9234u; 
        SoTN_lib.PlaySfxPositional_lib(c, m);
        L801C9234: ;
        if (c.S0 != 0u) {
            goto L801C95FC;
        }
        L801C923C: ;
        { c.A0 = 0u | 0x0001u;  }
        c.RA = 0x801C9244u; 
        SoTN_lib.SetStep_lib(c, m);
        goto L801C95FC;
        L801C924C: ;
        c.V0 = mem.ReadU16((c.S1 + 0x2Eu)); 
        if (c.V0 != 0u) {
            goto L801C92A4;
        }
        c.A0 = 0x80080000u; 
        { c.A0 = c.A0 - 0x27A8u;  }
        { c.A1 = c.A0 + 0x1780u;  }
        c.RA = 0x801C926Cu; 
        SoTN_lib.AllocEntity_lib(c, m);
        c.S0 = c.V0; 
        if (c.S0 == 0u) {
            { c.A0 = 0u | 0x001Eu;  }
            goto L801C9294;
        }
        { c.A0 = 0u | 0x001Eu;  }
        c.A1 = c.S1; 
        c.A2 = c.S0; 
        c.RA = 0x801C9284u; 
        SoTN_lib.CreateEntityFromEntity_lib(c, m);
        c.RA = 0x801C928Cu; 
        Dispatcher.Call(c, m, 0x801C29A4u);
        { c.V0 = c.V0 & 0x0001u;  }
        mem.WriteU16((c.S0 + 0x14u), (ushort)c.V0); 
        L801C9294: ;
        c.V0 = mem.ReadU16((c.S1 + 0x2Eu)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S1 + 0x2Eu), (ushort)c.V0); 
        L801C92A4: ;
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x2760u;  }
        c.A1 = c.S1; 
        c.RA = 0x801C92B4u; 
        SoTN_lib.AnimateEntity_lib(c, m);
        if (c.V0 != 0u) {
            goto L801C95FC;
        }
        { c.A0 = 0u | 0x0001u;  }
        c.RA = 0x801C92C4u; 
        SoTN_lib.SetStep_lib(c, m);
        c.V0 = mem.ReadU16((c.S1 + 0x2Eu)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S1 + 0x2Eu), (ushort)c.V0); 
        goto L801C95FC;
        L801C92D8: ;
        c.V0 = mem.ReadU16((c.S1 + 0x2Eu)); 
        if (c.V0 != 0u) {
            { c.A0 = 0u | 0x0004u;  }
            goto L801C9360;
        }
        { c.A0 = 0u | 0x0004u;  }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3848u)); 
        { c.A1 = 0u | 0x0014u;  }
        c.RA = 0x801C92FCu;
        Dispatcher.Call(c, m, c.V0);
        { c.V0 = c.V0 << 16;  }
        { c.A1 = (uint)((int)c.V0 >> 16);  }
        c.V0 = 0xFFFFFFFFu; 
        if (c.A1 != c.V0) {
            { c.V0 = c.A1 << 1;  }
            goto L801C9320;
        }
        { c.V0 = c.A1 << 1;  }
        c.A0 = c.S1; 
        c.RA = 0x801C9318u; 
        SoTN_lib.DestroyEntity_lib(c, m);
        goto L801C964C;
        L801C9320: ;
        { var _s = c.V0; var _t = c.A1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        { var _s = c.V0; var _t = c.A1; c.V0 = _s + _t;  }
        { c.V0 = c.V0 << 2;  }
        c.V1 = 0x80080000u; 
        { c.V1 = c.V1 + 0x6FECu;  }
        { var _s = c.V0; var _t = c.V1; c.S0 = _s + _t;  }
        c.A0 = mem.ReadU16((c.S1 + 0x2Eu)); 
        c.V0 = mem.ReadU32((c.S1 + 0x34u)); 
        c.V1 = 0x00800000u; 
        mem.WriteU32((c.S1 + 0x64u), c.A1); 
        mem.WriteU32((c.S1 + 0x7Cu), c.S0); 
        { c.A0 = c.A0 + 0x1u;  }
        { var _s = c.V0; var _t = c.V1; c.V0 = _s | _t;  }
        mem.WriteU32((c.S1 + 0x34u), c.V0); 
        mem.WriteU16((c.S1 + 0x2Eu), (ushort)c.A0); 
        L801C9360: ;
        c.V0 = mem.ReadU16((c.S1 + 0x50u)); 
        { c.V0 = c.V0 < 0x0000000Du ? 1u : 0u;  }
        if (c.V0 == 0u) {
            goto L801C941C;
        }
        c.V0 = 0x80040000u; 
        c.V0 = mem.ReadU32((c.V0 - 0x3668u)); 
        { c.V0 = c.V0 & 0x0007u;  }
        if (c.V0 != 0u) {
            goto L801C9414;
        }
        { c.A0 = 0u | 0x0749u;  }
        c.RA = 0x801C9394u; 
        SoTN_lib.PlaySfxPositional_lib(c, m);
        c.A0 = 0x80080000u; 
        { c.A0 = c.A0 - 0x27A8u;  }
        { c.A1 = c.A0 + 0x1780u;  }
        c.RA = 0x801C93A4u; 
        SoTN_lib.AllocEntity_lib(c, m);
        c.S0 = c.V0; 
        if (c.S0 == 0u) {
            { c.A0 = 0u | 0x001Eu;  }
            goto L801C9404;
        }
        { c.A0 = 0u | 0x001Eu;  }
        c.A1 = c.S1; 
        c.A2 = c.S0; 
        c.RA = 0x801C93BCu; 
        SoTN_lib.CreateEntityFromEntity_lib(c, m);
        c.V0 = mem.ReadU8((c.S1 + 0x84u)); 
        mem.WriteU16((c.S0 + 0x14u), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S1 + 0x14u)); 
        if (c.V0 == 0u) {
            goto L801C93E4;
        }
        c.V0 = mem.ReadU16((c.S0 + 0x2u)); 
        { c.V0 = c.V0 - 0x4u;  }
        goto L801C93F0;
        L801C93E4: ;
        c.V0 = mem.ReadU16((c.S0 + 0x2u)); 
        { c.V0 = c.V0 + 0x4u;  }
        L801C93F0: ;
        mem.WriteU16((c.S0 + 0x2u), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S0 + 0x6u)); 
        { c.V0 = c.V0 + 0x4u;  }
        mem.WriteU16((c.S0 + 0x6u), (ushort)c.V0); 
        L801C9404: ;
        c.V0 = mem.ReadU8((c.S1 + 0x84u)); 
        { c.V0 = c.V0 ^ 0x0001u;  }
        mem.WriteU8((c.S1 + 0x84u), (byte)c.V0); 
        L801C9414: ;
        mem.WriteU16((c.S1 + 0x80u), (ushort)0u); 
        goto L801C9490;
        L801C941C: ;
        c.V0 = (uint)(short)mem.ReadU16((c.S1 + 0x80u)); 
        if (c.V0 != 0u) {
            goto L801C9434;
        }
        { c.A0 = 0u | 0x0749u;  }
        c.RA = 0x801C9434u; 
        SoTN_lib.PlaySfxPositional_lib(c, m);
        L801C9434: ;
        c.V0 = mem.ReadU16((c.S1 + 0x80u)); 
        c.V1 = 0x80040000u; 
        c.V1 = mem.ReadU32((c.V1 - 0x3668u)); 
        { c.V0 = c.V0 + 0x1u;  }
        { c.V1 = c.V1 & 0x0003u;  }
        if (c.V1 != 0u) {
            mem.WriteU16((c.S1 + 0x80u), (ushort)c.V0); 
            goto L801C9490;
        }
        mem.WriteU16((c.S1 + 0x80u), (ushort)c.V0); 
        c.A0 = mem.ReadU32((c.S1 + 0x7Cu)); 
        { c.A1 = 0u | 0x0002u;  }
        c.RA = 0x801C945Cu; 
        SoTN_lib.FindFirstUnkPrim2_lib(c, m);
        c.S0 = c.V0; 
        if (c.S0 == 0u) {
            goto L801C9480;
        }
        c.A0 = c.S0; 
        c.RA = 0x801C9470u; 
        SoTN_lib.UnkPolyFunc2_lib(c, m);
        c.V1 = mem.ReadU32(c.S0); 
        c.V0 = mem.ReadU8((c.S1 + 0x84u)); 
        mem.WriteU8((c.V1 + 0x28u), (byte)c.V0); 
        L801C9480: ;
        c.V0 = mem.ReadU8((c.S1 + 0x84u)); 
        { c.V0 = c.V0 ^ 0x0001u;  }
        mem.WriteU8((c.S1 + 0x84u), (byte)c.V0); 
        L801C9490: ;
        c.V0 = mem.ReadU32((c.S1 + 0x34u)); 
        c.V1 = 0x00800000u; 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s & _t;  }
        if (c.V0 == 0u) {
            goto L801C94E0;
        }
        c.S0 = mem.ReadU32((c.S1 + 0x7Cu)); 
        if (c.S0 == 0u) {
            goto L801C94E0;
        }
        L801C94B4: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V0 = mem.ReadU8((c.S0 + 0x2Bu)); 
        { c.V0 = c.V0 & 0x0008u;  }
        if (c.V0 == 0u) {
            goto L801C94D0;
        }
        c.A0 = c.S0; 
        c.RA = 0x801C94D0u; 
        SoTN_lib.func_801C53AC_lib(c, m);
        L801C94D0: ;
        c.S0 = mem.ReadU32(c.S0); 
        if (c.S0 != 0u) {
            goto L801C94B4;
        }
        L801C94E0: ;
        c.A0 = 0x80180000u; 
        { c.A0 = c.A0 + 0x2774u;  }
        c.A1 = c.S1; 
        c.RA = 0x801C94F0u; 
        SoTN_lib.AnimateEntity_lib(c, m);
        if (c.V0 != 0u) {
            goto L801C95FC;
        }
        c.A0 = 0x80080000u; 
        { c.A0 = c.A0 - 0x27A8u;  }
        { c.A1 = c.A0 + 0x1780u;  }
        c.RA = 0x801C9508u; 
        SoTN_lib.AllocEntity_lib(c, m);
        c.S0 = c.V0; 
        if (c.S0 == 0u) {
            { c.A0 = 0u | 0x0002u;  }
            goto L801C9560;
        }
        { c.A0 = 0u | 0x0002u;  }
        c.A1 = c.S1; 
        c.A2 = c.S0; 
        c.RA = 0x801C9520u; 
        SoTN_lib.CreateEntityFromEntity_lib(c, m);
        c.V0 = mem.ReadU16((c.S0 + 0x6u)); 
        { c.V1 = 0u | 0x0002u;  }
        mem.WriteU16((c.S0 + 0x30u), (ushort)c.V1); 
        { c.V0 = c.V0 + 0x10u;  }
        mem.WriteU16((c.S0 + 0x6u), (ushort)c.V0); 
        c.V0 = mem.ReadU16((c.S1 + 0x14u)); 
        if (c.V0 == 0u) {
            goto L801C9550;
        }
        c.V0 = mem.ReadU16((c.S0 + 0x2u)); 
        { c.V0 = c.V0 - 0x8u;  }
        goto L801C955C;
        L801C9550: ;
        c.V0 = mem.ReadU16((c.S0 + 0x2u)); 
        { c.V0 = c.V0 + 0x8u;  }
        L801C955C: ;
        mem.WriteU16((c.S0 + 0x2u), (ushort)c.V0); 
        L801C9560: ;
        { c.A0 = 0u | 0x0693u;  }
        { c.V0 = 0u | 0x0040u;  }
        mem.WriteU16((c.S1 + 0x80u), (ushort)c.V0); 
        mem.WriteU16((c.S1 + 0x56u), (ushort)0u); 
        c.RA = 0x801C9574u; 
        SoTN_lib.PlaySfxPositional_lib(c, m);
        c.V0 = mem.ReadU16((c.S1 + 0x2Cu)); 
        { c.V0 = c.V0 + 0x1u;  }
        mem.WriteU16((c.S1 + 0x2Cu), (ushort)c.V0); 
        goto L801C95FC;
        L801C9588: ;
        c.V0 = mem.ReadU32((c.S1 + 0x34u)); 
        c.V1 = 0x00800000u; 
        { var _s = c.V0; var _t = c.V1; c.V0 = _s & _t;  }
        if (c.V0 == 0u) {
            goto L801C95D8;
        }
        c.S0 = mem.ReadU32((c.S1 + 0x7Cu)); 
        if (c.S0 == 0u) {
            goto L801C95D8;
        }
        L801C95AC: ;
        RecompOne.Runtime.Interrupts.Poll(c, m);
        c.V0 = mem.ReadU8((c.S0 + 0x2Bu)); 
        { c.V0 = c.V0 & 0x0008u;  }
        if (c.V0 == 0u) {
            goto L801C95C8;
        }
        c.A0 = c.S0; 
        c.RA = 0x801C95C8u; 
        SoTN_lib.func_801C53AC_lib(c, m);
        L801C95C8: ;
        c.S0 = mem.ReadU32(c.S0); 
        if (c.S0 != 0u) {
            goto L801C95AC;
        }
        L801C95D8: ;
        c.V0 = mem.ReadU16((c.S1 + 0x80u)); 
        { c.V0 = c.V0 - 0x1u;  }
        mem.WriteU16((c.S1 + 0x80u), (ushort)c.V0); 
        { c.V0 = c.V0 << 16;  }
        if (c.V0 != 0u) {
            goto L801C95FC;
        }
        c.A0 = c.S1; 
        c.RA = 0x801C95FCu; 
        SoTN_lib.DestroyEntity_lib(c, m);
        L801C95FC: ;
        c.V0 = mem.ReadU16((c.S1 + 0x56u)); 
        { c.V0 = c.V0 - 0xBu;  }
        { c.V0 = c.V0 < 0x00000002u ? 1u : 0u;  }
        if (c.V0 == 0u) {
            { c.V0 = 0u | 0x0012u;  }
            goto L801C962C;
        }
        { c.V0 = 0u | 0x0012u;  }
        mem.WriteU8((c.S1 + 0x46u), (byte)c.V0); 
        { c.V0 = 0u | 0x000Cu;  }
        mem.WriteU8((c.S1 + 0x47u), (byte)c.V0); 
        c.V0 = 0xFFFFFFF4u; 
        mem.WriteU16((c.S1 + 0x10u), (ushort)c.V0); 
        goto L801C9648;
        L801C962C: ;
        { c.V0 = 0u | 0x0004u;  }
        mem.WriteU8((c.S1 + 0x46u), (byte)c.V0); 
        { c.V0 = 0u | 0x0016u;  }
        mem.WriteU8((c.S1 + 0x47u), (byte)c.V0); 
        { c.V0 = 0u | 0x0001u;  }
        mem.WriteU16((c.S1 + 0x10u), (ushort)c.V0); 
        { c.V0 = 0u | 0x0004u;  }
        L801C9648: ;
        mem.WriteU16((c.S1 + 0x12u), (ushort)c.V0); 
        L801C964C: ;
        c.RA = mem.ReadU32((c.SP + 0x18u)); 
        c.S1 = mem.ReadU32((c.SP + 0x14u)); 
        c.S0 = mem.ReadU32((c.SP + 0x10u)); 
        { c.SP = c.SP + 0x20u;  }
        return;
        }
}
