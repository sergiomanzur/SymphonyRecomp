# 

AHOY!!! BIG UPDATE AHEAD!

0.5b is a bit of a big update, it massively revamps the UI, and makes the game way more stable!

Requirements have been lowered once again, now even if your gpu is from 2009 you can play, tho opengl 2.1 still a bit unstable!

# Changes

- massive UI rework, added themes, different langauges, and better font
- added a hard reset option and a soft reset one
- added a controller selector in settings
- added .chd suport
- reduced minimum opengl requirement to 2.1, it is highly experimental still and has problems
- improved opengl 3.3 rendering backend, some minor graphical problems and slowdowns have been fixed
- replaced the "native resolution" toggle with a proper resolution scale slider
- entities, collision and enemy processing now work on the extended screen instead of being faked around it, so there is no pop in and out on the sides
- sotn gets more virtual memory(to help the tile memory being exceeded in some parts of the castle causing some tiles not to render)
- mods dropped into the mods folder are now detected automatically
- added an experimental asset replacement system, documentation for it will come in the near future(it may have already come when you read this)
- fixed some minor bugs on randomizer
- randomizer now saves metadata on your save, so when you load a randomized save the same configuration is applied again!
- randomizer now warns when you enter a save with different settings applied, also pretty notification system yay
- other stability improvements
- removed herobrine

# future plans

these are short and long-therm plans for the future of the 0.5b version, this will come in the next subversions for it

- proper system to take panels out of the main window
- polishing of the asset replacing system, adding menus to manage loaded assets and etc, also make it easier to use whenever possible
- finish the mod hub and mod browsing system

# known bugs

 - opengl 2.1 support has problems with bitmasking not working properly, i havent found a proper solution yet

# Removed
- linux-arm64 build was removed, the libraries dont have good support for it and i dont have the necessary hardware to make proper testing

# Help Wanted!

If you want to help the development but dont know how to code, you can help us by providing(human made) translations for the UI! we tried to the best of our abbilities to add support to the most langauges we know, but any improvement and addition is welcome!

# a note from flaffy

Hello there, im flaffy, the "lead" developer? i think? i just want to say that i will be taking a small break after this release, my univeristy semester started and things are getting messy, i will go on for smaller projects for fun, this doesnt mean SymphonyRecomp will be abandoned xD there still a team and i will be still arround fixing some minor bugs, it will just not be my main focus for now

if you want to follow what i will be up to next you can follow my [youtube channel](https://www.youtube.com/@flaffymg), i plan on doing some devlogs of the stuff im up to, i also made a patreon but since i dont want to make it related to the recomp, due to legal reasons, i wont link it here.

See you all arround! i hope you enjoy this project, me and the rest of the team have put a lot of effort on it! <3

# Dependencies

You're required to install [dotnet 10 runtime](https://dotnet.microsoft.com/pt-br/download/dotnet/10.0) to run the recomp, otherwise the game will not open, ideally also make sure to install [OpenAL](https://www.openal.org/downloads/), as of the current version no further dependencies are required

you can find instructions downloading dotnet 10 for linux systems that dont have it on their packages [here](https://wiki.archlinux.org/title/.NET), or you can run "run.sh" wich will install dotent if not available and execute sotn for you
