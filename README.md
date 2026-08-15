# SymphonyRecomp — Android

Castlevania: Symphony of the Night, running natively on Android. Not an emulator — the
PlayStation code is statically recompiled into C# and built into a real app.

I started this because Symphony of the Night is a work of art, and art deserves to be
kept playable. I wanted it in my hands, on a handheld, running properly — not
approximated. That's the whole reason this fork exists.

---

## Please read this first

**The BlackLabelHQ team does not endorse this Android port, and it is not affiliated with
them.**

This fork was built with heavy AI assistance, verified by hand on real devices. The
upstream project's position is that they value human work, and they intend to release
their **own** Android port in their own time. That is their call and I respect it
completely — their work is the foundation everything here stands on.

So, plainly:

- **Do not** open issues about this port on the BlackLabelHQ repo.
- **Do not** ask their Discord for support with this build.
- If you want the official Android experience, wait for theirs.
- Everything in this fork is **maintained 100% by me**. Bugs here are mine, not theirs.

This is also **not** the SOTN Decomp project. A recomp translates the original machine
code; a decomp rebuilds the source by hand. Two different efforts, both worth your time,
and the Decomp folks deserve enormous respect for what they're doing. Don't take questions
about this port to their Discord either.

**Forks and contributions are welcome here.** Open a PR, fork it, take it somewhere I
never would — that's the point.

---

## Download

**[Get the APK from the releases page →](https://github.com/sergiomanzur/SymphonyRecomp/releases/latest)**

Current release: **Beta 0.9** — about 54 MB, Android 5.0 (API 21) or newer, arm64 or x64.

The APK holds **no game data**. You supply your own disc the first time you open it, and the
app never asks again. If your device refuses the install, allow "install unknown apps" for
whichever browser or file manager you downloaded it with.

Rather compile what you run? [Build it yourself](#building-it).

---

## You need your own copy of the game

No game data is distributed here, and none ever will be. You need a legally owned copy of
the North American PlayStation release, dumped to bin/cue.

**The app never ships with the disc.** On first launch it asks for your files, copies them
into its own storage, and never asks again. You can name them anything — the importer reads
your `.cue`, pulls in exactly the tracks it names, and rewrites it to match. It checks the
disc really is the USA release before accepting it, and tells you if you handed it a
Japanese or European dump by mistake.

**Building from source is separate.** The recompiler has to read the disc to translate the
game's code, so a copy must sit in `disc/` at build time, named exactly as `config/sotn.json`
expects:

```
Castlevania - Symphony of the Night (USA) (Track 1).bin
Castlevania - Symphony of the Night (USA) (Track 2).bin
Castlevania - Symphony of the Night (USA).cue
```

The `.bin` names only have to match whatever your `.cue` names internally — that block is
just the layout a standard dump arrives in.

---

## What works

- **Native performance.** No emulator, no BIOS file.
- **Bring your own disc.** The app holds no game data and asks for your dump on first run.
  Swap it later from **Game disc** in the menu.
- **Touch controls** — full PSX overlay, switchable D-pad or virtual stick, adjustable
  opacity, and a HIDE toggle that gets the buttons out of the way.
- **Physical controllers** — Bluetooth, USB and handhelds (Retroid, Odin, Xbox,
  DualSense), with PlayStation / Xbox / Nintendo button layouts so the face buttons land
  where you expect.
- **Save states** — five slots.
- **Quality of life** — colour blind fixes, remove screen flashes, bug fixes, easy spell
  inputs, extra invincibility frames and more, all carried over from the desktop build.
- **Cheats, stats and inventory** — heal, level, gold, attributes, and a full item, relic
  and spell editor.
- **Mods** — compiled on device, so source mods work the same as they do on desktop.
- **Display** — 4:3, 16:9, stretch or auto-fit, with orientation lock. Settings persist
  between sessions.

It's a beta. Expect rough edges, and keep real in-game saves alongside your save states.

---

## Building it

You don't have to — there's [a prebuilt APK](#download) — but building it yourself is the
only way to change anything, and it's how you verify what you're running. What comes out
holds no game data either way; every player supplies their own disc on first launch.

Budget an hour or so, mostly waiting on tool downloads.

### 1. Tools

- [Git](https://git-scm.com/downloads)
- [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)
- A JDK (17 or newer) and the Android SDK — installing Visual Studio's
  **.NET Multi-platform App UI development** workload, or Android Studio, gets you both

Then:

```bash
dotnet workload install android
```

### 2. Source

Clone **with submodules** — the Android build needs the RecompOne runtime, and a plain
clone will not build:

```bash
git clone --recursive https://github.com/sergiomanzur/SymphonyRecomp.git
cd SymphonyRecomp
```

Already cloned without it? `git submodule update --init --recursive`

### 3. Your disc files

Copy them into `disc/`, named as listed above. They must be in place *before* the next step,
because the recompiler reads the disc to translate the game's code. They are **not** packaged
into the APK — the finished app asks each player for their own copy.

### 4. Translate the game code

```bash
dotnet run --project RecompOne/RecompOne.Recompiler config/sotn.json
```

This is the recompilation step, and it's required — the Android build compiles the
`generated/` folder just like the desktop one. On Windows, `windows_initial_build.bat`
does it for you.

### 5. Build the APK

```bash
dotnet publish RecompOne.SoTN.Android.csproj -c Release
```

Your APK lands at `bin/Release/net10.0-android/com.blacklabelhq.sotn-Signed.apk`.

### 6. Install it

Copy it to your device and tap it, or:

```bash
adb install -r bin/Release/net10.0-android/com.blacklabelhq.sotn-Signed.apk
```

Needs Android 5.0 (API 21) or newer, arm64 or x64.

On first launch it asks for your disc. Select the `.cue` and both `.bin` tracks together —
long-press to multi-select — and it copies them in, which takes a minute or two. After that
it boots straight to the game.

Once you're in, the **⚙ MENU** button in the top corner opens everything.

---

## Known limitations

- **Save states are best used within one session**, and work most reliably when you save
  and load at similar moments. The emulated sound chip isn't captured in a state, so one
  loaded in a different area can play the wrong samples until the game reloads them.
- **Importing copies the disc**, so you need roughly 600 MB free on top of the app itself.
  The originals can be deleted afterwards.
- Desktop-only features — the map tracker, the randomizer panel — aren't in the Android
  menu yet.

## Todo

- Map tracker and randomizer screens for Android.
- Ongoing: whatever breaks. Tell me about it.

---

## Credits

None of this exists without the people who did the hard part first.

- **[BlackLabelHQ](https://github.com/BlackLabelHQ/SymphonyRecomp)** — SymphonyRecomp
  itself. The recompilation, the patches, the widescreen work, the years of effort. This
  fork is a port of their achievement, nothing more.
- **flaffy** — [RecompOne](https://github.com/BlackLabelHQ/RecompOne), the static
  recompiler this whole thing runs on.
- **The SOTN Decomp community** — for the reverse engineering that made so many function
  names and patches possible. Go support them.
- **Konami and KCET, 1997** — for making something people still care about this much,
  three decades later.

If you enjoy this, the right thing to do is go star the upstream project.
