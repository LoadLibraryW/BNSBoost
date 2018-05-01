# BNSBoost [![Build Status](https://ci.appveyor.com/api/projects/status/pdx1o24nlghtx64g?svg=true)](https://ci.appveyor.com/project/Xyene/bnsboost) [![Releases](https://img.shields.io/github/downloads/Xyene/BNSBoost/total.svg)](https://github.com/Xyene/BNSBoost/releases) [![Chat on Discord](https://img.shields.io/discord/438880622472331271.svg?label=discord&logo=discord&colorA=7078C2&colorB=7B81D8&x=x)](https://discord.gg/yAvFxET)



BNSBoost is a simple loader for starting NCSoft's Blade and Soul. Not endorsed by them in any way, shape, or form; Blade and Soul, etc. are all trademarks of NCSoft.

BNSBoost bypasses NCSoft's file verification, so you can run a patched game straight from the official launcher.

<img src="https://i.imgur.com/hQs6SqO.png" width="275" />&nbsp;&nbsp;&nbsp;&nbsp;<img src="https://i.imgur.com/FhguWrv.png" width="275" />&nbsp;&nbsp;&nbsp;&nbsp;<img src="https://i.imgur.com/iIQrCKn.png" width="275" />

<img src="https://i.imgur.com/AioB1QW.png" width="275" />&nbsp;&nbsp;&nbsp;&nbsp;<img src="https://i.imgur.com/f6AJRJK.png" width="275" />&nbsp;&nbsp;&nbsp;&nbsp;<img src="https://i.imgur.com/LF9q5b7.png" width="275" />

It features options for:

* Enabling game to use all cores
* Disabling texture streaming
* Disabling loading screens
* Disabling XIGNCODE3
* Enabling multi-client support
* Autopatching common XML edits (DPS meter, AFK check, etc.)
* Arbitrary game XML edits
* Custom mods (voice packs, etc.)
* Randomized splash changing
* Forcing the default launcher to open up with BNSBoost

## Downloads

**[Latest stable build](https://github.com/Xyene/BNSBoost/releases) &mdash; you probably want this.**

[Unstable builds](https://ci.appveyor.com/project/Xyene/bnsboost/build/artifacts) &mdash; don't file bug reports regarding these builds, but feel free to mention them in Discord.

## Usage 
Just run the `BNSBoost.exe` you got from the release archive!

We also maintain [a wiki](https://github.com/Xyene/BNSBoost/wiki) on using BNSBoost. Some topics you may be interested in:

* [Changing splash screen](https://github.com/Xyene/BNSBoost/wiki/Changing-splash-screens); randomized splashes for your enjoyment
* [Modding your game](https://github.com/Xyene/BNSBoost/wiki/Modding-your-game); voice packs, model changes, etc.
* [Arbitrary game file patches](https://github.com/Xyene/BNSBoost/wiki/Arbitrary-game-file-patches); for running things like custom `xinput.dll` builds

## FAQ

### My antivirus complains about your binaries!
Your antivirus might complain since BNSBoost's launcher hooking can match its malware definitions, in which case you'll have to
whitelist BNSBoost before proceeding. If you're jumpy about security, you can always compile it from the source in this repository
yourself.

Most antiviruses are alright with it, though.

### Can I be banned using this?
Absolutely! The use of any 3rd-party tools to run the game is strictly against [NCSoft's EULA](http://us.ncsoft.com/en/legal/user-agreements/blade-and-soul-user-agreement.php), and could land you a ban. But if you've already been using a 3rd-party launcher, this isn't really any different.

### But you're using injection! Isn't that more likely to get me banned?
I figure half the reason people shy away from injection is that it sounds like you're getting a flu shot, and relate that unpleasant experience to what's going on in the launcher. However, injection is a pretty common practice in tools that interface with games nowadays.

So let's be clear: **if you're using Discord, Steam, TeamSpeak, etc., you're already injecting into Blade and Soul.** These tools inject into the game to provide things like overlays. Though, they avoid mentioning words like "injection" or "hooking" to avoid sounding scary.

Now, many anti-cheats know these platforms inject, and may have whitelists for them. However, if you've enabled client-injecting features, you have already disabled XIGNCODE3. The launcher is not protected by any anti-cheat, so there's no concern regarding the base functionality of BNSBoost ceasing to work if NCSoft decides to switch off XIGNCODE3 to another anti-cheat.

### So what's being injected?

| Feature                | Launcher | Client |
|------------------------|----------|--------|
| Extra game flags       | ✔️        | ❌      |
| XML patching           | ✔️        | ❌      |
| Modding          | ✔️        | ❌      |
| Splash changing           | ✔️        | ❌      |
| XIGNCODE3 bypass       | ✔️        | ✔️      |
| Multi-client enabling  | ✔️        | ✔️      |

## How it works

There's a bunch of files included alongside BNSBoost that are necessary for it to function. Below is a brief overview of what each does.

### `inject32.exe` / `inject64.exe`

Writes a DLL into a given process' memory. BNSBoost uses these to write agent DLLs into either the launcher or the client.

### `agent_launcher.dll`

Injected into `NCLauncherR.exe` by BNSBoost. Sets up two hooks:

* #### `CreateFileW` hook
    Used to bypass file verification by redirecting calls to the `unpatched` directory, when it exists.

* #### `CreateProcessW` hook
    Used to add client flags (`-UNATTENDED`, `-NOTEXTURESTREAMING`, `-USEALLAVAILABLECORES`) when the launcher spawns the client. If bypassing XIGNCODE3, launches `inject32.exe` or `inject64.exe` (depending on client bitness) to inject `agent_client32.dll` or `agent_client64.dll` into the client.

### `agent_client32.dll` / `agent_client64.dll`

Injected into `Client.exe` by the `agent_launcher.dll`'s `CreateProcessW` hook. Sets up three hooks:

* #### `LoadLibraryW` hook
    Detects if the client is trying to load `x3.xem` or `xcorona_x64.xem`, and if so redirects the library to our patched ones instead.

* #### `CreateMutexW` hook
    Used for multi-client support. The game creates a named mutex "BnSGameClient" to prevent multiple instances from starting; this hook strips the name from it and allows further clients to be started.

* #### `CreateFileW` hook
    The client grabs exclusive access to `xml[bit].dat` / `config[bit].dat`, which causes clients to exit with "corrupt game file" messages even if the mutex is patched out. This hook is used to ensure that exclusive access cannot be obtained on any file used by the client, downgrading to sharing read access.

### `iphlpapi_nclauncher.dll`
Copied into the launcher's directory as `iphlpapi.dll`, it warns you if you're launching NC Launcher without BNSBoost (as this would destroy any patches you have applied). It can also be configured to launch BNSBoost unconditionally, without first prompting. The showing of this warning can be toggled in BNSBoost's *Settings* tab.

### `x3.xem` / `xcorona_x64.xem`

[VirtualPuppet/**XignCode3-bypass**](https://github.com/VirtualPuppet/XignCode3-bypass) built for 32-bit and 64-bit targets, respectively.

## Reporting an issue

I should say that I wrote this project for myself, and it works for me &mdash; in that sense, the goal of this project is complete.
However, since I figure this may be useful for others, I'll be happy to provide a best-effort attempt at helping out with any
errors caused by BNSBoost.

You can use the [ticket tracker](https://github.com/Xyene/BNSBoost/issues/) to [report issues](https://github.com/Xyene/BNSBoost/issues/new), and I'll probably get to them fairly quickly. 

Good luck!
