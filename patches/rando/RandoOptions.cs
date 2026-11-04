using RecompOne.Runtime.Config;

namespace Recompiled;

public static class RandoOptions
{
    public static readonly Option<int> Seed = Options.Int("rando.seed");
    public static readonly Option<bool> Items = Options.Bool("rando.items");
    public static readonly Option<bool> Drops = Options.Bool("rando.drops");
    public static readonly Option<bool> Relics = Options.Bool("rando.relics");
    public static readonly Option<bool> StartingGear = Options.Bool("rando.starting_gear");
    public static readonly Option<bool> RemoveDeathFromEntrance = Options.Bool("rando.remove_death");
    public static readonly Option<bool> SkipPrologue = Options.Bool("rando.skip_prologue");
}
