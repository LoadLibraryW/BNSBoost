# BNSBoost [![Build status](https://ci.appveyor.com/api/projects/status/pdx1o24nlghtx64g?svg=true)](https://ci.appveyor.com/project/Xyene/bnsboost)

BNSBoost is a simple loader for starting NCSoft's Blade and Soul. Not endorsed by them in any way, shape, or form; Blade and Soul, etc. are all trademarks of NCSoft.

BNSBoost bypasses NCSoft's file verification, so you can run a patched game straight from the official launcher.

![](https://cloud.githubusercontent.com/assets/1403503/25560753/7538c358-2d2a-11e7-8ae2-b9eae9a9dd26.png)

It features options for:

* Using all cores
* Disabling texture streaming
* Disabling loading screens
* Disabling XIGNCODE3<sup>*</sup>
* Arbitrary game XML edits

<sup><b>*</b></sup> If you are not disabling XIGNCODE3,  BNSBoost never touches the game client (`Client.exe`), only its launcher. If you are, it replaces the game's
`x3.xem` from [this Reddit thread](https://www.reddit.com/r/bladeandsoul/comments/6vj9ih/does_xigncode_bypass_work_now_after_the_update/dm2nx02/). **Only use this option
if you trust the source of the binary.** A future update will have the bypass being built alongside BNSBoost, so there are no magic binaries floating around.

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

The code itself is pretty short and fairly easy to follow, but in general:

* BNSBoost detects your launcher path from the registry
* Launches it suspended
* Writes the agent DLL into the memory of the launcher, and runs it
  * At this point there will likely be an audible beep, and BNSBoost can be safely closed
* Unsuspends the game; NCSoft login page shows up
* The agent modifies the game's [import address table (IAT)](https://en.wikipedia.org/wiki/Portable_Executable#Import_Table)
  * Redirects all calls to `CreateFile`, `CreateProcess` and `LoadLibrary`
  * Relevant calls to `CreateFile` are sourced from the `unpatched` directory
  * `CreateProcess` hook adds no texture streaming and use all CPU core flags to the game
  * `LoadLibrary` hook applies the `CreateFile` hook to any libraries loaded later

The injection procedure itself is mostly sourced from the [DMOJ's](https://dmoj.ca/) Windows sandbox, which is [also open source](https://github.com/DMOJ/judge).

## Reporting an issue

I should say that I wrote this project for myself, and it works for me &mdash; in that sense, the goal of this project is complete.
However, since I figure this may be useful for others, I'll be happy to provide a best-effort attempt at helping out with any
errors caused by BNSBoost.

You can use the [ticket tracker](https://github.com/Xyene/BNSBoost/issues/) to [report issues](https://github.com/Xyene/BNSBoost/issues/new), and I'll probably get to them fairly quickly. 

Where possible, include a copy of your `log.txt` from the folder containing BNSBoost.
If that's not possible because BNSBoost is crashing too early (e.g., a flickering black window), open an **administrator**
command prompt, `cd` to your BNSBoost directory, and run `BNSBoost.exe` from there. There'll probably be some extra info printed there.

Good luck!
