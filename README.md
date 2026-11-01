# MiniGames (s&box)

Multiplayer minigames project for [s&box](https://sbox.game).

## Current features
- Built-in `PlayerController` with a third person, over-the-shoulder camera (`Code/ThirdPersonPlayerScript.cs`)
- Mouse wheel zoom
- `Code/PlayerDebug.cs`: prints player position, ground state and velocity to the console
- Map: `facepunch.construct` (loaded with a `Map Instance` component)
- Multiplayer spawning with `Network Helper` and `Assets/Player.prefab`

## How to open
1. Run `sbox-dev.exe` (the s&box editor, found in the Steam folder of the game).
2. Open this folder as a project (`minigames.sbproj`).
3. Open `Assets/scenes/minimal.scene` and press Play.
