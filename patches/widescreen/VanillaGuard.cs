using RecompOne.Runtime.Context;
using RecompOne.Runtime.Memory;

namespace Recompiled;

//i could do it by changing the function signature but this way is more fun (and easier to not rbeak stuff by accident)
//doing this so rsl works, but it will require the original aspect ratio, because the patches maked for the widescreen and camera accidentaly fixes rsl
public static partial class WidescreenPatch
{

    //if screen is using original aspect itll skip executing the patches, this fixes the behaviour
    static bool Wide(System.Action<CpuContext, IMemory> impl, CpuContext c, IMemory m)
    {
        if (OriginalAspect) return true; //return true for using original func
        impl(c, m);
        return false; //false for skip so wont execute it again
    }

    public static bool ConfigStageClipWide(CpuContext c, IMemory m) => Wide(ConfigStageClip, c, m);
    public static bool RenderTilemapWideHook(CpuContext c, IMemory m) => Wide(RenderTilemapWide, c, m);
    public static bool SetTitleDisplayBufferWide(CpuContext c, IMemory m) => Wide(SetTitleDisplayBuffer, c, m);
    public static bool SetTitleDisplayBuffer256Wide(CpuContext c, IMemory m) => Wide(SetTitleDisplayBuffer256, c, m);
    public static bool InitFadeWide(CpuContext c, IMemory m) => Wide(InitFade, c, m);
    public static bool SetFadeWidthWide(CpuContext c, IMemory m) => Wide(SetFadeWidth, c, m);
    public static bool VortexWideHook(CpuContext c, IMemory m) => Wide(VortexWide, c, m);
    public static bool CloudsWideHook(CpuContext c, IMemory m) => Wide(CloudsWide, c, m);
    public static bool TitleFadeoutWideHook(CpuContext c, IMemory m) => Wide(TitleFadeoutWide, c, m);
    public static bool TransparentWaterWide_no3Hook(CpuContext c, IMemory m) => Wide(TransparentWaterWide_no3, c, m);
    public static bool TransparentWaterWide_np3Hook(CpuContext c, IMemory m) => Wide(TransparentWaterWide_np3, c, m);
    public static bool WaterSurface801C12B0Wide_no4Hook(CpuContext c, IMemory m) => Wide(WaterSurface801C12B0Wide_no4, c, m);
    public static bool LavaGlowWide_catHook(CpuContext c, IMemory m) => Wide(LavaGlowWide_cat, c, m);
    public static bool CamColWide(CpuContext c, IMemory m) => Wide(CamCol, c, m);

    static bool WideExt(System.Action<CpuContext, IMemory> impl, CpuContext c, IMemory m, params string[] needs)
    {
        if (!Extended || !StageHas(m, needs)) return true;
        impl(c, m);
        return false;
    }

    public static bool UpdateWide(CpuContext c, IMemory m)
    {
        if (!Extended || !StageHas(m, "DestroyEntity")) return true;
        if (!StageUpdateSymbols(m, out _, out _)) return true;
        Update(c, m);
        return false;
    }

    public static bool UpdateRoomPositionWide(CpuContext c, IMemory m) => WideExt(UpdateRoomPosition, c, m,"CreateEntitiesToTheRight", "CreateEntitiesToTheLeft", "CreateEntitiesAbove", "CreateEntitiesBelow"); //ima a long line :3
    public static bool CreateEntityWhenInHorizontalRangeWide(CpuContext c, IMemory m) => WideExt(CreateEntityWhenInHorizontalRange, c, m, "CreateEntityFromLayout");
    public static bool CreateEntityWhenInVerticalRangeWide(CpuContext c, IMemory m) => WideExt(CreateEntityWhenInVerticalRange, c, m, "CreateEntityFromLayout");
   
    //st0 has a different hit detection method, for simplicity im just going to skip the patch on it, since the dracula batle occurs in a 4:3 field this wouldnt cause any problems i would believe
    static bool IsSt0(IMemory m) => StageOverlay(m) is { } ov && string.Equals(ov.Name, "st0", StringComparison.OrdinalIgnoreCase);

    public static bool HitDetectionWide(CpuContext c, IMemory m) => IsSt0(m) || WideExt(HitDetection, c, m, "AllocEntity", "CreateEntityFromEntity", "DestroyEntity", "PreventEntityFromRespawning", "BottomCornerText");
}
