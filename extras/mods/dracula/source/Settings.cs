namespace DraculaMod;

/// <summary>Who the player is currently controlling.</summary>
public enum Playable
{
    Alucard = 0,
    Dracula = 1,
}

/// <summary>
/// Everything the player can configure, persisted through the host's settings store so the
/// same values are visible to the desktop ImGui panel and the Android menu.
///
/// Kept as a plain static bag rather than spread across the move classes: the options list,
/// the save/load pair and the moves all need to see the same fields, and one flat surface is
/// easier to keep honest than six.
/// </summary>
public static class Settings
{
    const string Prefix = "mods.dracula.";

    public static Playable Playing = Playable.Alucard;

    // Moves. Each is independently switchable so a single misbehaving move can be turned off
    // without giving up the character.
    public static bool HellfireVolley = true;
    public static bool DarkInferno = true;
    public static bool DemonicTeleport = true;
    public static bool MeteorRain = true;
    public static bool BatSwarm = true;

    // Presence (passives).
    public static bool Recolour = true;
    public static bool MpRegen = true;
    public static bool DamageResistance = true;
    public static bool StrongerAttacks = true;

    /// <summary>
    /// Movement feel. Off by default and deliberately so: slower walking can shorten a running
    /// jump enough to make a gap somewhere in the castle uncrossable, and a softlock is a far
    /// worse bug than a stat that reads as bland. Opt in knowingly.
    /// </summary>
    public static bool HeavyMovement = false;

    public static float MpCostScale = 1.0f;

    public static bool IsDracula => Playing == Playable.Dracula;

    public static void Load()
    {
        Playing = (Playable)RecompOne.Runtime.Config.Settings.Get(Prefix + "character", (int)Playable.Alucard);
        Input.Mod = (Modifier)RecompOne.Runtime.Config.Settings.Get(Prefix + "modifier", (int)Modifier.Circle);
        HellfireVolley = RecompOne.Runtime.Config.Settings.Get(Prefix + "hellfireVolley", true);
        DarkInferno = RecompOne.Runtime.Config.Settings.Get(Prefix + "darkInferno", true);
        DemonicTeleport = RecompOne.Runtime.Config.Settings.Get(Prefix + "demonicTeleport", true);
        MeteorRain = RecompOne.Runtime.Config.Settings.Get(Prefix + "meteorRain", true);
        BatSwarm = RecompOne.Runtime.Config.Settings.Get(Prefix + "batSwarm", true);
        Recolour = RecompOne.Runtime.Config.Settings.Get(Prefix + "recolour", true);
        MpRegen = RecompOne.Runtime.Config.Settings.Get(Prefix + "mpRegen", true);
        DamageResistance = RecompOne.Runtime.Config.Settings.Get(Prefix + "damageResistance", true);
        StrongerAttacks = RecompOne.Runtime.Config.Settings.Get(Prefix + "strongerAttacks", true);
        HeavyMovement = RecompOne.Runtime.Config.Settings.Get(Prefix + "heavyMovement", false);
        MpCostScale = RecompOne.Runtime.Config.Settings.Get(Prefix + "mpCostScale", 1.0f);
    }

    public static void Save()
    {
        RecompOne.Runtime.Config.Settings.Set(Prefix + "character", (int)Playing);
        RecompOne.Runtime.Config.Settings.Set(Prefix + "modifier", (int)Input.Mod);
        RecompOne.Runtime.Config.Settings.Set(Prefix + "hellfireVolley", HellfireVolley);
        RecompOne.Runtime.Config.Settings.Set(Prefix + "darkInferno", DarkInferno);
        RecompOne.Runtime.Config.Settings.Set(Prefix + "demonicTeleport", DemonicTeleport);
        RecompOne.Runtime.Config.Settings.Set(Prefix + "meteorRain", MeteorRain);
        RecompOne.Runtime.Config.Settings.Set(Prefix + "batSwarm", BatSwarm);
        RecompOne.Runtime.Config.Settings.Set(Prefix + "recolour", Recolour);
        RecompOne.Runtime.Config.Settings.Set(Prefix + "mpRegen", MpRegen);
        RecompOne.Runtime.Config.Settings.Set(Prefix + "damageResistance", DamageResistance);
        RecompOne.Runtime.Config.Settings.Set(Prefix + "strongerAttacks", StrongerAttacks);
        RecompOne.Runtime.Config.Settings.Set(Prefix + "heavyMovement", HeavyMovement);
        RecompOne.Runtime.Config.Settings.Set(Prefix + "mpCostScale", MpCostScale);
        RecompOne.Runtime.Config.Settings.Save();
    }
}
