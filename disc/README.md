# Disc Directory Instructions

In order for you to run the game, you'll need to provide your game files named in the following format. BlackLabelHQ does not provide you these copyrighted files, you'll need to provide your own which you can obtain by ripping them from your original PSX (PlayStation) copy of the game.

## Place The Following Files Here:

* Castlevania - Symphony of the Night (USA) (Track 1).bin
* Castlevania - Symphony of the Night (USA) (Track 2).bin
* Castlevania - Symphony of the Night (USA).cue

The `.cue` name is the one `config/sotn.json` points at, so it must match exactly. The `.bin`
names only have to match what that `.cue` names inside it.

These files are needed to *build* — the recompiler reads the disc to translate the game's
code. The Android app does not ship them; it asks each player for their own copy instead.
