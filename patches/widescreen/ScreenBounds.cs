using RecompOne.Runtime.Context;
using RecompOne.Runtime.Dispatch;
using RecompOne.Runtime.Memory;

namespace Recompiled;

public static partial class WidescreenPatch
{
    public static int Margin
    {
        get
        {
            EnsureInitialized();
            return OriginalAspect ? 0 : StageMargin();
        }
    }

    public static bool Extended => Margin > 0;

    public static int ViewLeft => -Margin;
    public static int ViewRight => 256 + Margin;

    static int OutsetLeft(int bound) => bound - Margin;
    static int OutsetRight(int bound) => bound + Margin;

    const uint StageOverlayHeader = 0x80180000; //stage can be stale overlay (not fully overwriten so the recomp still marks it as loaded so head it via the header isntead

    static uint _stageOvlKey;
    static IOverlay? _stageOverlay;
    static readonly Dictionary<string, (Action<CpuContext, IMemory>? Fn, uint Addr)> _stageFns = [];

    static IOverlay? StageOverlay(IMemory m)
    {
        uint key = m.ReadU32(StageOverlayHeader);
        if (key == _stageOvlKey) return _stageOverlay;

        _stageOvlKey = key;
        _stageOverlay = null;
        _stageFns.Clear();
        if (key == 0) return null;

        var active = Dispatcher.ActiveNames;
        for (int i = active.Length - 1; i >= 0; i--)
        {
            if (!Dispatcher.Overlays.TryGetValue(active[i], out var overlay)) continue;
            if (!overlay.Functions.ContainsKey(key)) continue;
            _stageOverlay = overlay;
            break;
        }
        return _stageOverlay;
    }

    static (Action<CpuContext, IMemory>? Fn, uint Addr) StageSym(IMemory m, string name)
    {
        var ov = StageOverlay(m);
        if (ov == null) return (null, 0);
        if (_stageFns.TryGetValue(name, out var cached)) return cached;

        string suffix = "_" + ov.Name;
        string exported = ov.Name.ToUpperInvariant() + "_" + name;
        var hit = ((Action<CpuContext, IMemory>?)null, 0u);

        foreach (var (addr, fn) in ov.Functions)
        {
            string em = fn.Method.Name;
            if (em.EndsWith(suffix, StringComparison.OrdinalIgnoreCase))
                em = em[..^suffix.Length];

            if (!string.Equals(em, name, StringComparison.Ordinal) &&
                !string.Equals(em, exported, StringComparison.Ordinal)) continue;
            hit = (fn, addr);
            break;
        }

        _stageFns[name] = hit;
        return hit;
    }

    static Action<CpuContext, IMemory>? StageFn(IMemory m, string name) => StageSym(m, name).Fn;

   
    //direct call resolv by name, not most eficient but works
    static bool StageHas(IMemory m, params string[] names)
    {
        if (StageOverlay(m) == null) return false;
        foreach (var n in names)
            if (StageFn(m, n) == null) return false;
        return true;
    }

    static void CallStage(CpuContext c, IMemory m, string name, uint a0 = 0, uint a1 = 0)
        => CallStageRet(c, m, name, a0, a1);

    static uint CallStageRet(CpuContext c, IMemory m, string name, uint a0 = 0, uint a1 = 0, uint a2 = 0)
    {
        var fn = StageFn(m, name);
        if (fn == null) return 0;
        var snap = c.Snapshot();
        c.A0 = a0;
        c.A1 = a1;
        c.A2 = a2;
        fn(c, m);
        uint ret = c.V0;
        c.Restore(snap);
        return ret;
    }
}
