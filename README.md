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

## You need your own copy of the game

No game data is distributed here, and none ever will be. You need a legally owned copy of
the North American PlayStation release, dumped to bin/cue, with these exact filenames:

```
Castlevania - Symphony of the Night (Track 1).bin
Castlevania - Symphony of the Night (Track 2).bin
Castlevania - Symphony of the Night (USA).cue
```

Put them in the `disc/` folder before you build.

> **Heads up:** right now the disc is packaged *into* the APK, so the build weighs about
> 470 MB and contains your dump. Build it for yourself and don't hand it around. Letting
> the app ask for your bin/cue at runtime is the top item on the [Todo](#todo), and it's
> what will finally make a clean, shareable APK possible.

---

## What works

- **Native performance.** No emulator, no BIOS file.
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

There's no download. You build it yourself, because the disc has to be yours.

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

Copy them into `disc/`, named exactly as listed above. They must be in place *before* you
publish, since they're packaged as app assets.

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

Needs Android 5.0 (API 21) or newer, arm64 or x64. First launch unpacks the disc out of
the APK, so give it a moment before the title screen appears.

Once you're in, the **⚙ MENU** button in the top corner opens everything.

---

## Known limitations

- **Save states are best used within one session**, and work most reliably when you save
  and load at similar moments. The emulated sound chip isn't captured in a state, so one
  loaded in a different area can play the wrong samples until the game reloads them.
- **The APK carries your disc**, which is why it's huge and why I won't distribute builds.
- Desktop-only features — the map tracker, the randomizer panel — aren't in the Android
  menu yet.

## Todo

- **Pick your own bin/cue from inside the app.** The disc is currently baked in at build
  time, which makes the APK enormous and impossible to share. The app should ask for your
  files on first launch instead, so a clean APK can be distributed and everyone brings
  their own legally owned dump.
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
