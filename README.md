# BNSBoost [![Build status](https://ci.appveyor.com/api/projects/status/pdx1o24nlghtx64g?svg=true)](https://ci.appveyor.com/project/Xyene/bnsboost)

BNSBoost is a simple loader for starting NCSoft's Blade and Soul. Not endorsed by them in any way, shape, or form; Blade and Soul, etc. are all trademarks of NCSoft.

BNSBoost bypasses NCSoft's file verification, so you can run a patched game straight from the official launcher.

![](https://i.imgur.com/be93xbx.png)

It features options for:

* Using all cores
* Disabling texture streaming
* Disabling loading screens
* Disabling XIGNCODE3<sup>*</sup>
* Enabling multi-client support
* Autopatching common XML edits (DPS meter, AFK check, etc.)
* Arbitrary game XML edits

<sup><b>*</b></sup> If you are not disabling XIGNCODE3,  BNSBoost never touches the game client (`Client.exe`), only its launcher. If you are, it injects an agent DLL (see below) into it.

## Installation

[Grab a release](https://github.com/Xyene/BNSBoost/releases), and unzip! If you like living life on the edge, you can also pick up the latest build [from AppVeyor](https://ci.appveyor.com/project/Xyene/bnsboost).

Your antivirus might complain since BNSBoost does some sketchy stuff (see below) to run, in which case you'll have to
whitelist BNSBoost before proceeding. If you're jumpy about security, you can always compile it from the source in this repository
yourself.

## Usage 
Just run the `BNSBoost.exe` you got from the release archive!

### Using BNSBoost to run patched files

When using the built-in DAT editor, BNSBoost takes care of patching details iteslf.

Before you patch any file, navigate to its directory first, and create a subdirectory called `unpatched`, then copy the file(s) you wish to patch into `unpatched`.
Then, you can use whatever game file editor you wish to patch the files however you wish. BNSBoost will make the game *launcher* read
from the `unpatched` folder, while the regular game *client* will read from the regular folder.

This'll trick the launcher's verifier into thinking you're running an unmodified game, and allow the game to start.
The game does no further verification.

You can use this to run your own version of `xinput.dll`, run custom voice packs, and so on.

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

### `x3.xem` / `xcorona_x64.xem`

[VirtualPuppet/**XignCode3-bypass**](https://github.com/VirtualPuppet/XignCode3-bypass) built for 32-bit and 64-bit targets, respectively.

## Reporting an issue

I should say that I wrote this project for myself, and it works for me &mdash; in that sense, the goal of this project is complete.
However, since I figure this may be useful for others, I'll be happy to provide a best-effort attempt at helping out with any
errors caused by BNSBoost.

You can use the [ticket tracker](https://github.com/Xyene/BNSBoost/issues/) to [report issues](https://github.com/Xyene/BNSBoost/issues/new), and I'll probably get to them fairly quickly. 

Good luck!
