using System;
using System.Collections.Generic;
using RecompOne.Runtime.Events;
using RecompOne.Runtime.Modding;
using Sotn;

namespace DraculaMod;

/// <summary>
/// Play the castle as its master.
///
/// What this is honestly doing: Dracula's own entities and sprites live in ST0, the final-stage
/// overlay, and every stage overlay shares base 0x80180000 - only one is resident at a time, so
/// his art cannot follow the player around the castle. The rig stays Alucard's, recoloured. What
/// does travel is the machinery Alucard inherited from him, resident in DRA everywhere: Hellfire's
/// fireballs, the teleport shatter, the bat projectiles. His moveset is built from those, which is
/// the right seam rather than a workaround.
///
/// Options are declared rather than drawn, so the same list renders as ImGui on desktop and as
/// native rows in the Android menu - which previously could configure no mod at all.
/// </summary>
public class PlayableDracula : IMod, IModOptions
{
    public void OnLoad()
    {
        Settings.Load();
        Moves.Reset();
        Presence.Reset();
        Input.Reset();
        MenuIdentity.Reset();

        Event.AddListener<VSyncEvent>(OnVSync);
        Console.WriteLine($"[Dracula] loaded, playing as {Settings.Playing}");
    }

    public void OnUnload()
    {
        Event.RemoveListener<VSyncEvent>(OnVSync);
        // Leave nothing behind: put the palette back and drop any in-flight state.
        Presence.RestoreRecolour();
        MenuIdentity.Restore();
        Moves.Reset();
    }

    /// <summary>
    /// Deliberately empty, and deliberately present. Settings are declared through
    /// <see cref="IModOptions"/> so both hosts can draw them, so there is no ImGui to write here -
    /// but the Android runtime does not support default interface implementations, and omitting
    /// this fails the on-device build with CS8702. Every defaulted IMod member has to be declared.
    /// </summary>
    public void DrawSettings() { }

    /// <summary>
    /// Frame bookkeeping only - input edges, cooldowns, palette, regen. The moves themselves run
    /// from the player's step hooks, because velocity written at the frame boundary is overwritten
    /// by the player update later in the same frame.
    /// </summary>
    static void OnVSync(VSyncEvent e)
    {
        Moves.Tick();
        Presence.Tick();
        MenuIdentity.Tick();
        Input.Sample();
    }

    public IReadOnlyList<ModOption> GetOptions()
    {
        var opts = new List<ModOption>
        {
            ModOption.MakeChoice(
                "character", "Character",
                new[] { "Alucard", "Dracula" },
                () => (int)Settings.Playing,
                i => { Settings.Playing = (Playable)i; OnCharacterChanged(); },
                description: "Switching is instant and works on any save. Nothing here is ever written to your save file.",
                section: "Who you play"),

            ModOption.MakeChoice(
                "modifier", "Move button",
                new[] { "Circle", "L2", "R2" },
                () => (int)Input.Mod,
                i => { Input.Mod = (Modifier)i; Settings.Save(); },
                description: "Held with a direction to cast. Circle is unused by Alucard, so it takes nothing away.",
                section: "Who you play",
                isAvailable: () => Settings.IsDracula),
        };

        // Moves, each independently switchable so one misbehaving move never costs the character.
        opts.Add(Move("hellfireVolley", "Hellfire Volley", "Move  -  three fireballs in a fan",
            () => Settings.HellfireVolley, v => Settings.HellfireVolley = v));
        opts.Add(Move("darkInferno", "Dark Inferno", "Move + Down  -  one slow, heavy fireball",
            () => Settings.DarkInferno, v => Settings.DarkInferno = v));
        opts.Add(Move("demonicTeleport", "Demonic Teleport", "Move + Left/Right  -  a brief, invulnerable blink",
            () => Settings.DemonicTeleport, v => Settings.DemonicTeleport = v));
        opts.Add(Move("meteorRain", "Meteor Rain", "Move + Up  -  a wave of fire from above",
            () => Settings.MeteorRain, v => Settings.MeteorRain = v));
        opts.Add(Move("batSwarm", "Bat Swarm", "Move + Down, airborne  -  bats, and a lift",
            () => Settings.BatSwarm, v => Settings.BatSwarm = v));

        opts.Add(ModOption.MakeSlider("mpCostScale", "Magic cost", 0f, 2f, 0.1f,
            () => Settings.MpCostScale,
            v => { Settings.MpCostScale = v; Settings.Save(); },
            format: "%.1f",
            description: "Scales every move's MP cost. 0 makes them free.",
            section: "Moves",
            isAvailable: () => Settings.IsDracula));

        // Passives.
        opts.Add(Passive("recolour", "Crimson palette",
            "Recolours Alucard's sprite to Dracula's crimson and black. Restored from the original, never destructive.",
            () => Settings.Recolour, v =>
            {
                Settings.Recolour = v;
                if (!v) Presence.RestoreRecolour();
            }));
        opts.Add(Passive("mpRegen", "Regenerating magic",
            "MP returns slowly on its own, because his kit spends it constantly.",
            () => Settings.MpRegen, v => Settings.MpRegen = v));
        opts.Add(Passive("damageResistance", "Dracula's constitution",
            "Shrugs off part of every hit. Applied as a refund after the hit lands, so HpMax and your save are untouched.",
            () => Settings.DamageResistance, v => Settings.DamageResistance = v));
        opts.Add(Passive("strongerAttacks", "Empowered magic",
            "Scales the attack value of projectiles this mod spawned. Never touches enemies. A safe no-op if the game sets that damage elsewhere.",
            () => Settings.StrongerAttacks, v => Settings.StrongerAttacks = v));

        // Development aid: dumps VRAM next to the mod so the sprite sheet can actually be looked
        // at before anything is drawn over it.
        opts.Add(ModOption.MakeAction("dumpVram", "Dump VRAM to file",
            () => VramTool.DumpAll(),
            description: "Writes vram.bin (1024x512, raw 16-bit) beside the mod. For authoring the sprite.",
            section: "Development"));

        opts.Add(ModOption.MakeToggle("heavyMovement", "Walk like something ancient",
            () => Settings.HeavyMovement,
            v => { Settings.HeavyMovement = v; Settings.Save(); },
            description: "Slows his walk. OFF by default on purpose: a shorter running jump can make a gap "
                       + "somewhere in the castle uncrossable, and that is a softlock, not a stat. Opt in knowingly.",
            section: "Movement (risky)",
            isAvailable: () => Settings.IsDracula));

        return opts;
    }

    static ModOption Move(string id, string label, string description, Func<bool> get, Action<bool> set) =>
        ModOption.MakeToggle(id, label, get,
            v => { set(v); Settings.Save(); },
            description: description,
            section: "Moves",
            isAvailable: () => Settings.IsDracula);

    static ModOption Passive(string id, string label, string description, Func<bool> get, Action<bool> set) =>
        ModOption.MakeToggle(id, label, get,
            v => { set(v); Settings.Save(); },
            description: description,
            section: "Presence",
            isAvailable: () => Settings.IsDracula);

    static void OnCharacterChanged()
    {
        // Drop any half-finished move and undo the recolour immediately when going back to Alucard.
        Moves.Reset();
        Input.Reset();
        if (!Settings.IsDracula) Presence.RestoreRecolour();
        MenuIdentity.Reset();   // re-apply the menu name promptly after a switch
        Settings.Save();
        Console.WriteLine($"[Dracula] now playing as {Settings.Playing}");
    }
}
