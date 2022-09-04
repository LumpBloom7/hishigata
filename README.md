![hishigata](assets/logo.png)

# hishigata

[![.NET Core](https://github.com/LumpBloom7/hishigata/workflows/.NET%20Core/badge.svg)](https://github.com/LumpBloom7/hishigata/actions?query=workflow%3A%22.NET+Core%22)
[![CodeFactor](https://www.codefactor.io/repository/github/lumpbloom7/hishigata/badge)](https://www.codefactor.io/repository/github/lumpbloom7/hishigata)
[![Crowdin](https://badges.crowdin.net/hishigata/localized.svg)](https://crowdin.com/project/hishigata)
[![Discord Shield](https://discordapp.com/api/guilds/700619421466624050/widget.png?style=shield)](https://discord.gg/CQPNADu)

[![ko-fi](https://www.ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/E1E01N56M)

A ruleset based on Project Rhombus.

## Trying the ruleset

Prebuilt binaries are provided for users who doesn't want to create a development environment. Releases are guaranteed to work with the latest version of lazer at the time of release.

| [Releases](https://github.com/lumpbloom7/hishigata/releases/) |
| ------------------------------------------------------------- |

| [Installation Guide](https://github.com/LumpBloom7/sentakki/wiki/Ruleset-installation-guide) |
| -------------------------------------------------------------------------------------------- |

## Debugging and Developing

Some prerequisites are required before attempting to debug or develop:

* A desktop platform with the .NET 6 SDK or higher installed.
* An IDE with support for C#, providing auto completion and syntax highlighting. I recommend using Visual Studio, Rider or Visual Studio Code.
* Other requirements are shared with osu!lazer and osu!framework

### Downloading the source code

Clone the repository:

```sh
git clone https://github.com/lumpbloom7/hishigata
cd hishigata
```

To update the source code to the latest commit, run the following command inside the osu directory:

```she
git pull
```

### Building

Using the `Build` command from your IDE should generate a DLL file within the output directory. If you're debugging or developing, it is a bit more convenient to run the `VisualTests` project instead since that'll remove the need to copy the dll to your lazer directory.

You can also build hishigata from the command-line with a single command:

```sh
dotnet build osu.Game.Rulesets.Hishigata
```

## Contributing

There are a few ways one can look to contribute to Hishigata.

### Code contributions

If you are interested in implementing new features or improving current features, you can fork the repository and develop the feature/improvement on a topic branch of your fork before PR'ing the changes to this repository.

### Localization contributions

Want to see Sentakki display text in your language? You can help localize Hishigata via the [project's crowdin page](https://crowdin.com/project/hishigata).

### Feedback / bug reports

Notice a problem during gameplay? Feel free to leave an issue/suggestion over at [GitHub issues](https://github.com/LumpBloom7/hishigata/issues).


## Licence

hishigata is licensed under the [MIT licence](https://opensource.org/licenses/MIT). Please see the licence file for more information. tl;dr you can do whatever you want as long as you include the original copyright and license notice in any copy of the software/source.

Do take note that project dependencies may not share the same license.
