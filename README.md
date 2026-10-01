# BackAlley

A first-person arcade shooting gallery built in Unity. You have 60 seconds, a 12-round pistol, and a stream of enemies walking at you from both ends of the alley. Hit as many as you can and keep your accuracy up.

![Unity](https://img.shields.io/badge/Unity-6000.0.44f1-black?logo=unity)
![C#](https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=white)
![Render Pipeline](https://img.shields.io/badge/URP-17.0.4-blue)
![Status](https://img.shields.io/badge/status-prototype-orange)

## Gameplay

- **60-second rounds.** A countdown timer ends the run and brings up a summary screen.
- **Enemies spawn from the left and right** of the alley at a fixed rate, walk forward, and despawn after 20 seconds if you miss them.
- **Hitscan pistol.** Shots are raycast from the camera, with a 12-round magazine, a fire-rate limiter, and a reload animation. Dry-firing plays a click.
- **Scoring.** Each enemy hit is worth 5 points.
- **End-of-round summary.** Score, bullets fired, enemies hit, and a hit ratio (accuracy).
- **Pause** at any time; spawning, enemy movement, and the timer all freeze.

## Controls

| Action | Keyboard / Mouse | Gamepad |
| ------ | ---------------- | ------- |
| Look   | Mouse | Right stick |
| Shoot  | Left click / Enter | West button (X / Square) |
| Reload | C | East button (B / Circle) |
| Pause  | Esc | Start |

## Getting Started

### Requirements

- Unity **6000.0.44f1** (Unity 6). Newer 6000.0.x patch versions should open fine.
- Git
- Visual Studio, Rider, or VS Code with the C# extension

### Run it

```bash
git clone https://github.com/sage-9/BackAlley.git
cd BackAlley
```

1. Open **Unity Hub** > **Add** > **Add project from disk** and select the `BackAlley` folder.
2. Open it with editor version `6000.0.44f1` (Hub will offer to install it).
3. Open `Assets/Scenes/MainMenu.unity`.
4. Press **Play**.

The first open takes a while because Unity regenerates the `Library/` folder.

### Build

`File > Build Profiles`, add `MainMenu` and `Game` to the scene list (in that order), pick your platform, then **Build**.

## Project Structure

```
Assets/
├── Scenes/            # MainMenu, Game, test
├── Scripts/
│   ├── Enemy/         # EnemyMovement, EnemySpawnManager
│   ├── Managers/      # GameSceneManager (game state events), SceneLoader
│   ├── Player & Gun/  # InputHandler, AimLogic, Fire, PlayerAnimationHandler
│   ├── SFX/           # SFXManager
│   └── UI & Stage/    # TimerLogic, ScoreLogic, GameSummary, UiHandler, HandleLoad
├── Animations/        # Player controller, Shoot, Reload
├── Input/             # Input System actions asset
├── Rendering/         # Custom URP render features (outline pass)
├── Models/            # Pistol and first-person arm/torso/leg meshes
└── Settings/          # PC and Mobile URP assets
```

## Architecture Notes

- **Event-driven game state.** `GameSceneManager` exposes static events (`PreStart`, `Play`, `Pause`, `GameOver`). The timer, spawner, and enemies subscribe to them, so pausing or ending a round needs no direct references between systems.
- **New Input System.** `InputHandler` wraps the Input System actions and raises `ShootAction` / `ReloadAction` events that `Fire` listens to.
- **Custom URP render features.** An outline render feature and a depth-texture shader graph live under `Assets/Rendering`.
- **UI.** UGUI with TextMesh Pro, plus a UI Toolkit panel setup.
  
## Contact

Open to collabs and freelance work.

- itch.io: https://sage9.itch.io
- Email: olayiwolaladipo@gmail.com
