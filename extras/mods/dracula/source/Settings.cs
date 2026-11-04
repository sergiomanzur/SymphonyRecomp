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
        var v = RecompOne.Runtime.Runtime.View;
        Playing = (Playable)v.GetInt(Prefix + "character", (int)Playable.Alucard);
        Input.Mod = (Modifier)v.GetInt(Prefix + "modifier", (int)Modifier.Circle);
        HellfireVolley = v.GetBool(Prefix + "hellfireVolley", true);
        DarkInferno = v.GetBool(Prefix + "darkInferno", true);
        DemonicTeleport = v.GetBool(Prefix + "demonicTeleport", true);
        MeteorRain = v.GetBool(Prefix + "meteorRain", true);
        BatSwarm = v.GetBool(Prefix + "batSwarm", true);
        Recolour = v.GetBool(Prefix + "recolour", true);
        MpRegen = v.GetBool(Prefix + "mpRegen", true);
        DamageResistance = v.GetBool(Prefix + "damageResistance", true);
        StrongerAttacks = v.GetBool(Prefix + "strongerAttacks", true);
        HeavyMovement = v.GetBool(Prefix + "heavyMovement", false);
        MpCostScale = v.GetFloat(Prefix + "mpCostScale", 1.0f);
    }

    public static void Save()
    {
        var v = RecompOne.Runtime.Runtime.View;
        v.SetInt(Prefix + "character", (int)Playing);
        v.SetInt(Prefix + "modifier", (int)Input.Mod);
        v.SetBool(Prefix + "hellfireVolley", HellfireVolley);
        v.SetBool(Prefix + "darkInferno", DarkInferno);
        v.SetBool(Prefix + "demonicTeleport", DemonicTeleport);
        v.SetBool(Prefix + "meteorRain", MeteorRain);
        v.SetBool(Prefix + "batSwarm", BatSwarm);
        v.SetBool(Prefix + "recolour", Recolour);
        v.SetBool(Prefix + "mpRegen", MpRegen);
        v.SetBool(Prefix + "damageResistance", DamageResistance);
        v.SetBool(Prefix + "strongerAttacks", StrongerAttacks);
        v.SetBool(Prefix + "heavyMovement", HeavyMovement);
        v.SetFloat(Prefix + "mpCostScale", MpCostScale);
        RecompOne.Runtime.Runtime.SaveView();
    }
}
