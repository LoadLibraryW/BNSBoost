## BNSBoost

BNSBoost is a simple loader for starting NCSoft's Blade and Soul.

BNSBoost:

* Fakes file verification, so you can run patched game files
* Starts the game using all cores
* Disables texture streaming for smoother loads

BNSBoost does not provide any editor for your game files (use BNSBuddy for that!)

## Installation

[Grab a release](https://github.com/Xyene/BNSBoost/releases), and unzip!

Your antivirus might complain since BNSBoost does some sketchy stuff (see below) to run, in which case you'll have to
whitelist BNSBoost before proceeding. If you're jumpy about security, you can always compile it from the source in this repository
yourself.

## Usage 
Just run the BNSBoost.exe you got from the release archive. **Make sure you run BNSBoost.exe with administrator privileges!**

This will start the game set to use all cores and with texture streaming disabled.
BNSBoost will open in one of those nice DOS-style windows, which will be safe to close as soon as you've logged in.
Depending on your computer, you may also hear an audible beep.

### Using BNSBoost to run patched files

To enable e.g. the DPS meter, locate the directory containing your install's config files.
That's the one containing `xml(64).dat` and `config(64).dat`.
For example, it may be something like `D:\Blade and Soul\BnS\contents\Local\NCWEST\data`.

Ensuring you have unpatched game files (vanilla BNS), create a folder in that directory called `unpatched`, and copy the `xml*` and `config*` files into it.
Then, you can use whatever game file editor you wish to patch the files however you wish. BNSBoost will make the game *launcher* read
from the `unpatched` folder, while the regular game _client_ will read from the regular folder.

This'll trick the launcher's verifier into thinking you're running an unmodified game, and allow the game to start.
The game does no further verification.

## How it works

The code itself is pretty short and fairly easy to follow, but for the curious non-programmer types:

* BNSBoost detects your launcher path from the registry
* Launches it suspended
* Writes the agent DLL into the memory of the launcher, and runs it
  * At this point there will likely be an audible beep, and BNSBoost can be safely closed
* The agent modifies the game's [import address table (IAT)](https://en.wikipedia.org/wiki/Portable_Executable#Import_Table)
  * Redirects all calls to `CreateFile`, `CreateProcess` and `LoadLibrary`
  * Relevant calls to `CreateFile` are sourced from the `unpatched` directory
  * `CreateProcess` hook adds no texture streaming and use all CPU core flags to the game
  * `LoadLibrary` hook applies the `CreateFile` hook to any libraries loaded later

BNSBoost never touches the game client (Client.exe), only its launcher.

## Compilation

You might want to compile BNSBoost yourself, in which case the compilation commands are located in the first line of each file.
I'll make a Makefile sometime, but not today.
