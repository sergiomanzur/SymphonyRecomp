using RecompOne.Runtime.Config;

namespace Recompiled;

public static class TrackerOptions
{
    public static readonly Option<bool> Sectioning = Options.Bool("tracker.sectioning", true);
    public static readonly Option<bool> FixedIconSize = Options.Bool("tracker.fixed_icon_size");
    public static readonly Option<bool> ShowJp = Options.Bool("tracker.show_jp");
    public static readonly Option<bool> ShowHand = Options.Bool("tracker.show_hand");
    public static readonly Option<bool> ShowBody = Options.Bool("tracker.show_body");
    public static readonly Option<bool> ShowProgress = Options.Bool("tracker.show_progress");

    public static readonly Option<int> Columns = Options.Int("tracker.columns", 5)
        .Normalized(static v => Math.Clamp(v, 1, 12));

    public static readonly Option<int> MapCheckSet = Options.Int("map.check_set", 2)
        .Normalized(static v => Math.Clamp(v, 0, 6));
}
