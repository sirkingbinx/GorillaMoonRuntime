# MoonMonke
MoonMonke is a work-in-progress Lua/Luau[^1] library and script loader that allows developers to write mods in Luau. You may recognize Luau from Gorilla Tag's very own [Virtual Stump](Another-Axiom/GT_CustomMapExample), however, that and MoonMonke do different things. *Virtual Stump* uses Luau to code single-threaded scripts that control interactive maps. MoonMonke uses Luau to run multi-threaded mods that are coded in Luau.

MoonMonke provides many libraries that Luau can access that help with the modding process, dumbing down many internal methods to make it as easy as possible to develop mods. I left an example here:
> *Join Room on Button Click (Luau / MoonMonke vs. C# / BepInEx)*
> ```luau
> -- Luau
> function Step()
>     if Input.LeftPrimary then
>         Network.TryConnectToRoom("ROOMCODE", "MODDED_CASUAL")
>     end
> end
> ```
> ```cs
> // Now C#
> using BepInEx;
> using GorillaNetworking;
> 
> [BepInPlugin("my.mod", "MyMod", "1.0.0")]
> public class Mod {
>     void Update() {
>         if (ControllerInputPoller.instance.leftControllerPrimaryButton) {
>             GorillaComputer.instance.SetGameModeWithoutButton("MODDED_CASUAL");
>             PhotonNetworkController.Instance.AttemptToJoinSpecificRoom("ROOMCODE", JoinType.Solo);
>         }
>     }
> }
> ```

## Pros / Cons
| Pros | Cons |
|------|------|
| Multi-threaded support via. coroutines | Gives less control than C# |
| Much simpler than C#, more approachable for beginners | Function limited by internal libraries |
| Easily approachable by Roblox / VStump developers | Sometimes slower than C# mods |
| Simple installation, just drag scripts into a folder | - |

Versus VStump's Luau implementation:
| Feature | MonkeMoon | VStump |
|---------|-----------|--------|
| GameObject control | ✔️ | ✔️ |
| Networking | ✔️[^2] | ✔️ |
| Multithreading | ✔️ | ✖️ |
| Input gathering | ✔️ | ✖️ |
| Usable outside of VStump (ex. in moddeds) | ✔️ | ✖️ |

## Installation
-- coming soon --

## Docs
Examples and docs are in [DOCS.md](DOCS.md)

## Footnotes
[^1]: I'm still deciding on most of the features, how it will work, and other stuff. A lot of this info will change.
[^2]: A lot of networking controls (at the moment) are limited, it provides less control than VStump Luau
