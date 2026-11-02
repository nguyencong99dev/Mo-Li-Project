# Mo-Li

> A solo-developed, turn-based monster-collection RPG built with **Unity 6** and **C#**, with a focus on decoupled, data-driven architecture.

**Status:** In active development · **Developer:** Solo · **Started:** 02/2026
[Uploading gamedemo.webm…]()

## Highlights

- **Decoupled architecture**: asynchronous Bootstrapper, persistent singleton managers, strict World/Combat scene boundaries
- **Event-driven communication**: generic EventBus with struct events and last-value replay caching
- **Command-based combat**: State Pattern for player input flow, Command objects executed through an async ActionQueue
- **Designer-friendly content pipeline**: ScriptableObjects + Addressables + polymorphic effects, so abilities are configured without touching code
- **Robust persistence**: 3-slot JSON saves through an `ISaveable` registry
- **Original pixel art** and animation created in Aseprite

## Screenshots

| Main Menu | World | Combat |
|-------|--------|--------|
| Docs/Images/mainmenu.png | Docs/Images/world.png | Docs/Images/combat.png |

## Architecture

### Game Flow & Managers

An asynchronous **Bootstrapper** initializes the game sequence and the persistent singleton managers (`DontDestroyOnLoad`):

| Manager | Responsibility |
|---|---|
| `ManagerAssets` | Addressables loading and release |
| `ManagerAudio` | Audio playback |
| `ManagerInput` | Input handling (Input System) |
| `ManagerSave` | Save/load orchestration |
| `ManagerScene` | Scene transitions and loading |
| `ManagerGame` | Global game state |

The **World** and **Combat** scenes are strictly separated, and the two communicate only through events.

### Event-Driven Communication

A generic **EventBus** built on struct events (no heap allocation per event) with **last-value replay caching**: late subscribers receive the most recent event of a type. This fully isolates gameplay simulation from UI updates and audio playback; the simulation never references the UI.

### Combat Engine

- **State Pattern**: combat phases (Start → Player → Enemy → Execute → Check) are states, and the player's decision flow is a set of sub-states: **Select Action → Select Target → Confirm**.
- **Command Pattern**: skills, item usage, and fleeing are modeled as Command objects (`UseSkillCommand`, `UseItemCommand`, `FleeCommand`).
- **Async ActionQueue**: commands are executed sequentially and asynchronously. **Priority insertion** lets interrupt reactions (e.g., a monster fainting) jump the queue, and **reentrancy guards** prevent the queue from being processed recursively.
- `CombatCalculator` isolates damage and stat math from state logic.

### Content Pipeline (Data-Driven Design)

- **ScriptableObjects** (`SOMonster`, `SOSkill`, `SOItem`, `SOEffect`) hold all static data and are loaded through **Addressables**.
- **Polymorphic effect pipeline**: effects use `[SerializeReference]` with the **Strategy Pattern**, shared by skills and consumable items. New effects (damage, restore, damage-over-time) plug in without changing existing code.
- **Bitwise flag target types** (`[Flags]`) express single-target and AoE selection in one enum.
- A custom editor drawer improves effect authoring in the Inspector.

### Persistence & Memory

- **3-slot JSON save system**: every system that needs saving (player, party, inventory) implements `ISaveable` and registers itself, so `ManagerSave` never depends on concrete systems.
- **Generic object pool** (`IPoolable`) for dynamic combat UI elements and floating damage indicators, which avoids per-frame instantiation and garbage collection spikes.

### Art & UI/UX

- Original pixel art sprites and animations hand-crafted in Aseprite
- Responsive combat UI: dynamic **turn-order timeline**, **unit cards** (HP / MP / status), and clear visual states for skills on **cooldown** versus **insufficient MP**
- Stat bars driven by small binder components (`HPBinder`, `MPBinder`, `SPBinder`)

## Gameplay Systems

- Turn-based combat with skills, items, guard, and flee
- Party management (monster team, skills)
- Inventory with drag & drop and item categories (consumables, equipment, resources, tools)
- Enemy parties and NPC interaction
- Main menu, loading scene, and 3 save slots

## Tech Stack

| Tool | Purpose |
|---|---|
| Unity `6000.4.6f1` | Game engine |
| C# | Programming language |
| Universal Render Pipeline (URP) | 2D rendering |
| Addressables | Asset management |
| Input System | Player input |
| Cinemachine | Camera control |
| 2D Animation / Aseprite Importer | Sprite animation pipeline |
| Unity Tilemap + Tiled | World building |
| Unity UI (uGUI) | In-game interface |
| Aseprite | Pixel art and animation |

## Project Structure

```
Mo-Li-Project/
├── Assets/
│   ├── Scenes/              # Initialization, MainMenu, LoadingScene, Base, Combat
│   └── Scripts/
│       ├── Core/            # Bootstrapper, EventBus, Managers
│       ├── Entities/        # Player, Enemy, NPC, Monster, world objects
│       ├── Systems/         # Combat, Inventory, Party, SaveLoad, UI
│       ├── Utilities/       # Databases, ScriptableObjects, helpers
│       └── Editor/          # Custom Inspector drawers
├── Packages/
├── ProjectSettings/
└── Tiled map editor/        # Ti led source maps (.tmx / .tsx)
```

## Roadmap

- [x] Core architecture (Bootstrapper, EventBus, managers)
- [x] Combat state machine and ActionQueue
- [x] Save/load, inventory, and party systems
- [ ] Build a world featuring interactive objects and NPCs. 
- [ ] A farming system that uses monsters for assistance.
- [ ] Developing an evolution system for monsters
