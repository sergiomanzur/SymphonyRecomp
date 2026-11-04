# Playable Dracula — design

**Date:** 2026-08-21
**Status:** implemented; in-game move behaviour pending a play session

## Goal

Add a second playable character to SymphonyRecomp, selectable against Alucard from the menu, with
a moveset that does not exist in vanilla. Must work on Android, which is the primary platform for
this fork.

## What the codebase allows

Mods are folders of C# source plus a `mod.json`. `ModLoader` discovers them and `ModCompiler` runs
Roslyn **at runtime** against the live assemblies, caching the DLL against a source hash. That is
why source mods behave identically on device: Android bundles `mods/**` as APK assets, unpacks
them, and points `ModLoader.RootOverride` at the writable copy.

Three hook attributes resolve by *function name* against the recompiled overlays:

```csharp
[PreHook("dra", "PlayerStepJump")]   // static void|bool (CpuContext, IMemory); false skips the original
[PostHook("dra", "PlayerStepWalk")]
[Replace("dra", "...")]              // may take an `orig` first parameter
```

Plus the `Sotn` wrapper layer (`Player`, `Entity`, `Palette`, `GameApi`, `Stages`) and a typed
event bus (`VSyncEvent`, `PadReadEvent`, …).

### Constraint 1 — Android could not configure any mod

`IMod.DrawSettings()` is raw ImGui. The Android menu is native Android views and has no ImGui
surface, so `DrawSettings` was never drawn there: **no mod was configurable on Android at all**.
A character picker could not live in `DrawSettings`.

### Constraint 2 — Dracula's art cannot leave the throne room

`EntityDracula*` and his sprites live in `generated/st0.cs`. Every stage overlay is based at
`0x80180000`, so exactly one is resident at a time. His artwork physically cannot follow the
player around the castle.

What *is* resident everywhere is `dra`, which contains the powers Alucard inherited from him:

| Address | Entity |
|---|---|
| `0x801274DC` | `EntityHellfireNormalFireball` |
| `0x80127840` | `EntityHellfireBigFireball` |
| `0x801243B0` | `EntityTeleport` |
| `0x8012768C` | `EntityBatFireball` |

`Entity.Update` (offset `0x28`) is a raw PSX function pointer, so a free entity slot pointed at one
of these runs it. `EntityHellfireNormalFireball` self-initialises from step 0 and uses `Params` as
an index into the game's own speed tables (`0x800B0830` X, `0x800B083C` Y) — `Params` 0/1/2 are
exactly the three the vanilla Hellfire cast spawns, i.e. a three-way fan. That *is* Dracula's
signature attack, built from the game's own velocities. `Params` is clamped to 0..2 because going
past the end of those tables reads whatever follows and launches at a garbage velocity.

## Decisions

1. **Identity layer, not new art.** Alucard's rig, recoloured crimson. Framed honestly rather than
   sold as new sprites.
2. **Live toggle on any save.** Nothing written to the save file, ever (see below).
3. **Declarative options, not drawn options.** New `IModOptions` / `ModOption` in the runtime; each
   host renders them in its own idiom. Fixes the Android gap for every mod, not just this one.
4. **Driver + targeted step interception.** Not a wholesale `EntityAlucard` replacement (which
   would mean reimplementing collision, animation and damage), and not a VSync-only driver (which
   fights the vanilla state machine — velocity written at the frame boundary is overwritten by the
   player update later in the same frame).

### Non-destructive by construction

| Effect | Naive approach | What was done instead |
|---|---|---|
| Tougher | raise `HpMax` | let the hit land, refund a fraction after (`AlucardHandleDamage` pre/post) |
| Stronger | raise `Strength` | stamp `Attack` on projectiles this mod spawned |
| Recolour | overwrite palette | `Palette.Shade` (non-cumulative, caches the original), restored on toggle-off |

`HpMax` and `Strength` are written into the player's file at the next save room. Refund and stamp
are not.

### Softlock avoidance

Two deliberate choices, both because a softlock is worse than a bland stat:

- **Demonic Teleport is a fast invulnerable slide, not a position write.** Setting `PosX` directly
  walks through walls and can strand the player inside geometry. The flourish entities and the fade
  sell the teleport instead; collision still applies.
- **Movement changes are opt-in and default off.** A shorter running jump can make a gap somewhere
  in the castle uncrossable.

Every move and passive is independently switchable, so one misbehaving piece never costs the
character.

## Moveset

Modifier (default Circle — verified free: pad one never tests mask `0x0020`) plus a direction. All
taps; nothing waits for a release.

| Input | Move | MP | Cooldown |
|---|---|---|---|
| Mod | Hellfire Volley — three-way fan | 8 | 22f |
| Mod + Down (grounded) | Dark Inferno — heavy fireball | 25 | 55f |
| Mod + Left/Right | Demonic Teleport — invulnerable blink | 10 | 30f |
| Mod + Up | Meteor Rain — staggered wave from above | 40 | 110f |
| Mod + Down (airborne) | Bat Swarm — projectiles plus lift | 15 | 45f |

Meteors need a velocity the table does not provide, so they are re-stamped every frame while alive
rather than written once at spawn — the entity sets its own velocity in step 0, which runs on the
frame *after* creation.

## Files

```
RecompOne/RecompOne.Runtime/Modding/ModOptions.cs          IModOptions, ModOption
RecompOne/RecompOne.Runtime/Modding/ModLoader.cs           HasOptions, Options()
RecompOne/RecompOne.Runtime/Host/Window/ModOptionsImGui.cs desktop renderer
RecompOne/.../Popups/ModsPopup.cs                          gear now opens options too
Android/MainActivity.cs                                    ShowModOptionsMenu / Choice / Slider
RecompOne.SoTN.csproj, RecompOne.SoTN.Android.csproj       bundle extras/mods
extras/mods/dracula/**                                     the mod
```

The mod lives in `extras/mods/` rather than `mods/`, which is the BlackLabelHQ
`SymphonyRecompMods` submodule — a folder added there would be untracked in someone else's
repository. Both csprojs link it into the `mods/` path so it lands where `ModLoader` looks.

## Verification

Confirmed on the desktop build with the real disc:

- The mod compiles at runtime; all 8 hooks resolve by name.
- The hook mechanism holds indefinitely — a control hook on `UpdateGame` fired 7,900+ times with
  no degradation, ruling out tiered-JIT re-compilation discarding the detour.
- Pad injection through `PadReadEvent` works, and drove the game from the title screen into
  gameplay.

A false alarm worth recording: the first harness ran in the "Prologue" stage and saw **zero**
player hooks fire. That was not a mod defect. The prologue is Richter versus Dracula — `ric` and
`st0` load — so Richter's player code runs and `dra`'s Alucard step functions correctly never
execute there. Diagnosis came from the loaded-overlay log plus a control hook that *did* fire.

**Outstanding:** the moves have not been observed firing in Alucard gameplay. Reaching Alucard from
a cold boot requires clearing the prologue, whose end is gated on scripted boss phases rather than
raw HP, so it needs a save file or a human at the controls. Android menu rendering also needs a
device.
