# GorillaMoonRuntime Docs
This is a small overview of everything provided by GorillaMoonRuntime. Code examples are provided for some features.

## Mod Initialization
You can start writing mods just like any other Lua script. GorillaMoonRuntime will call `init()` when the game finishes loading and `step()` every frame.
```lua
function Init()
    print("the game has loaded")
end

function Step()
    print("this is called every frame")
end
```

## Networking
You can check if rooms are modded, get the player count, and join rooms with relative ease with the `Networking` table.
```lua
if Networking.IsModded then
    -- modded stuff
end
```

### Join/Leave Game
```lua
-- you can set the gamemode too
-- here's a list of defaults:
-- CASUAL INFECTION GUARDIAN PAINTBRAWL
-- append MODDED_ to the start of any of these for modded games
Networking.TryConnectToRoom("code", "MODDED_CASUAL")
Networking.TryConnectToPublic("MODDED_CASUAL") -- to just join some random public
```

### Player Count / Connection Status
```lua
-- as easy as it seems
local count = Networking.PlayerCount

if count == -1 or Networking.IsConnected then
    print("not in a room")
else
    print("there are " .. count .. " players in the room")
end
```

## Player
```lua
-- Valid platforms:
-- "steam", "rift", "quest"
print(Player.Platform)

-- nickname / player ID
-- you can't set them obviously
print("hello " .. Player.Nickname)
print("your ID is " .. Player.PlayerId)

if Player.PlayerId == "123456789" then
    print("OMG its lemming")
end
```

## Input
We provide a basic input class with about any value you would need.
```lua
-- Boolean values: primary, secondary
local lPrim = Input.LeftPrimary
local rScnd = Input.RightSecondary

print(lPrim and rScnd)

-- Number values for trigger and grip.
-- Both are on a scale of 0 to 1.

print(Input.LeftTrigger > 0.25) -- holding 25% of the way in

-- [*]ThumbstickAxis is more interesting, as they use Vector2 instead.
-- Vector2 gives you an X and Y value. They support math operations and tostring(), 
-- so they should work in most cases.
local LeftXAxisWest = Input.LeftThumbstickAxis.X > 0.5
local LeftXAxisEast = Input.LeftThumbstickAxis.X < -0.5
local LeftXAxisNorth = Input.LeftThumbstickAxis.Y > 0.5
local LeftXAxisSouth = Input.LeftThumbstickAxis.Y < -0.5

print(tostring(Input.LeftThumbstickAxis)) -- Would return " X: *, Y: *".
```