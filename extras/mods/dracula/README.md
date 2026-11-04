# Playable Dracula

Play the castle as its master.

Dracula trades Alucard's agility for reach and weight. He does not dodge — he teleports. His
kit is ranged, telegraphed and expensive, which turns the castle into a zoning problem instead
of an attrition one.

## Controls

Everything is the **move button** plus a direction. The move button defaults to **Circle**, and
that is a checked choice rather than a guess: sweeping the pad reads in the `dra` overlay, mask
`0x0020` is only ever tested against `0x7498`/`0x749C` — the *second* controller. Pad one never
tests Circle, so binding to it takes nothing away from Alucard. (L1 and R1 both looked tempting
and both turned out to be taken, backdash among them.) L2 and R2 are offered as alternatives if
Circle clashes with a rebind.

| Input | Move | MP | What it does |
|---|---|---|---|
| Circle | **Hellfire Volley** | 8 | Three fireballs in a fan |
| Circle + Down (grounded) | **Dark Inferno** | 25 | One slow, heavy fireball |
| Circle + Left/Right | **Demonic Teleport** | 10 | A brief, invulnerable blink |
| Circle + Up | **Meteor Rain** | 40 | A staggered wave of fire from above |
| Circle + Down (airborne) | **Bat Swarm** | 15 | Bats, and a lift |

No move waits for a release, so the main attack has no charge latency.

## Passives

- **Crimson palette** — recolours Alucard's sprite to crimson and black.
- **Regenerating magic** — MP returns slowly, because the kit spends it constantly.
- **Dracula's constitution** — shrugs off part of every hit.
- **Empowered magic** — scales the attack value of projectiles this mod spawned. Enemies are
  *not* buffed. If the game sources a projectile's damage from somewhere other than its own
  `Attack` field, this is a safe no-op rather than a change — it has not been confirmed in play yet.

## Where the settings are

**Android:** ⚙ MENU → Mods → Playable Dracula → Settings.

**Desktop:** the Mods panel, gear icon on the mod's card.

Both render the same list. Before this mod, Android could configure no mod at all — `DrawSettings()`
is ImGui and the Android menu is native views, so nothing was drawn. Mods can now *describe*
their options (`IModOptions`, `ModOption`) and each host draws them in its own idiom. That is a
runtime change, not part of this folder.

## Two things worth being straight about

**The sprite is Alucard's, recoloured.** Dracula's own entities and artwork live in `ST0`, the
final-stage overlay. Every stage overlay shares base `0x80180000`, so exactly one is resident at
a time — his art physically cannot follow you into the Marble Gallery. What *can* travel is the
machinery Alucard inherited from his father, resident in `DRA` in every room: Hellfire's
fireballs, the teleport shatter, the bat projectiles. The moveset is built from those, which is
using the right seam rather than working around a missing one. `Params` 0/1/2 on
`EntityHellfireNormalFireball` are the same three the vanilla Hellfire cast uses, so the fan's
spread and speeds are the game's own.

**Nothing here is written to your save.** Switching characters is live and works on any file.
The recolour goes to the palette in VRAM and is restored from the cached original. Toughness is
a post-hit HP refund rather than a change to `HpMax` — which would otherwise be written into your
file the next time you used a save room. Magic power is stamped onto projectiles this mod itself
spawned. Toggle Dracula off and the save is byte-identical.

## Movement is opt-in, and off by default

"Walk like something ancient" slows his walk, and it ships **off**. A shorter running jump can
make a gap somewhere in the castle uncrossable, and that is a softlock rather than a bland stat.
Every move and every passive is independently switchable for the same reason: one misbehaving
piece should never cost you the character.

## Layout

```
extras/mods/dracula/
  mod.json
  source/
    PlayableDracula.cs   IMod + IModOptions entry, options, event wiring
    Settings.cs          persisted configuration
    Input.cs             modifier + direction reads, edge detection
    Moves.cs             the five moves, run from player step hooks
    Presence.cs          palette, MP regen, damage refund, magic power
    Spawn.cs             creates the resident DRA projectiles
```

Moves run from `PreHook`s on the player's step functions rather than from the frame boundary,
because that is where the game itself sets velocity — anything written at VSync gets overwritten
by the player update later in the same frame. Frame bookkeeping (cooldowns, palette, input edges)
does run at VSync, which involves no detour at all.

## Verification status

Confirmed on the desktop build: the mod compiles at runtime, all 8 hooks resolve by name, the
options round-trip, and the hook mechanism holds indefinitely (a control hook on `UpdateGame`
fired 7,900+ times without the detour degrading).

**The moves have not yet been watched firing in Alucard gameplay.** Reaching Alucard from a cold
boot means getting past the prologue, which is Richter versus Dracula — `ric` and `st0` load, so
`dra`'s Alucard step functions correctly never run there. That needs a real save file or a human
at the controls.
