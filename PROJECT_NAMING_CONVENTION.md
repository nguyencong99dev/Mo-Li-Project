# 📋 PROJECT NAMING CONVENTION - Top-down 2D Game

> Dự án: [Tên game của bạn]  
> Áp dụng từ ngày: [Ngày bắt đầu]  
> Version: 1.0

---

## 📑 MỤC LỤC
1. [Thư mục (Folders)](#1-thư-mục)
2. [GameObject & Hierarchy](#2-gameobject--hierarchy)
3. [Script C#](#3-script-c)
4. [Prefab](#4-prefab)
5. [Scene](#5-scene)
6. [Tag & Layer](#6-tag--layer)
7. [Animation & Audio](#7-animation--audio)
8. [ScriptableObjects & Assets](#8-scriptableobjects--assets)
9. [Quick Reference](#9-quick-reference)

---

## 1️⃣ THƯ MỤC (FOLDERS)

**Convention cơ bản:**

| Loại | Convention | Ví dụ |
|------|-----------|-------|
| Top-level folder | PascalCase | `Scripts/`, `Prefabs/`, `Scenes/` |
| Subfolder (feature) | PascalCase | `Combat/`, `Inventory/`, `Dialogue/` |
| Subfolder (type) | PascalCase (số nhiều) | `Animations/`, `Sprites/`, `Audio/` |
| Third-party | `_ThirdParty/` | `_ThirdParty/TextMeshPro/` |
| Temp / Ignore | Tiền tố `_` | `_Deprecated/`, `_WIP/` |

**Cấu trúc thư mục Assets chuẩn:**

```
Assets/
├─ _ThirdParty/          (asset store, không chỉnh sửa)
├─ Animations/
│  ├─ Characters/
│  ├─ Enemies/
│  └─ UI/
├─ Audio/
│  ├─ Music/
│  └─ SFX/
├─ Data/
│  └─ ScriptableObjects/
├─ Prefabs/
│  ├─ Characters/
│  ├─ Enemies/
│  ├─ UI/
│  └─ Systems/
├─ Scenes/
│  ├─ Core/
│  └─ Levels/
├─ Scripts/
│  ├─ Core/
│  ├─ Entities/
│  ├─ Systems/
│  └─ Utilities/
├─ Sprites/
│  ├─ Characters/
│  ├─ Environments/
│  └─ UI/
└─ Tilemaps/
```

---

## 2️⃣ GAMEOBJECT & HIERARCHY

## 2️⃣ GAMEOBJECT & HIERARCHY

**Convention đặt tên:**

| Loại | Convention | Ví dụ |
|------|-----------|-------|
| Folder separator | `--- TÊN ---` | `--- MANAGERS ---`, `--- WORLD ---` |
| Empty parent | `[TÊN]` | `[SpawnPoints]`, `[DynamicObjects]` |
| Manager | `XyzManager` | `GameManager`, `LevelManager` |
| Spawn point | `Spawn_TÊN` | `Spawn_Player`, `Spawn_Enemy_01` |
| Trigger zone | `Trig_TÊN` | `Trig_Door`, `Trig_Exit` |
| Waypoint | `WP_XX` | `WP_01`, `WP_Boss` |
| Dynamic instance | `TênPrefab_XX` | `Enemy_01`, `Bullet_023` |

**Hierarchy mẫu cho Level Scene:**

```
--- MANAGERS ---
├─ GameManager
├─ LevelManager
└─ AudioManager

--- WORLD ---
├─ Grid
│  ├─ Tilemap_Ground
│  ├─ Tilemap_Collision
│  └─ Tilemap_Details
├─ Environment/
└─ [Triggers]

--- SPAWNERS ---
├─ Spawn_PlayerStart
└─ Spawn_Enemy_01

--- DYNAMIC ---
├─ Player
├─ [Enemies]
└─ [Projectiles]

--- UI ---
└─ Canvas_HUD
```

---

## 3️⃣ SCRIPT (C#)

## 3️⃣ SCRIPT (C#)

**Convention class & file:**

| Loại | Convention | Ví dụ |
|------|-----------|-------|
| Class / Struct | PascalCase | `PlayerController`, `DamageData` |
| Interface | `I` + PascalCase | `IDamageable`, `IInteractable` |
| Enum | PascalCase | `ItemType`, `StateType` |
| Script file | Trùng tên class | `PlayerController.cs` |
| Controller | `XyzController` | `PlayerController` |
| Manager | `XyzManager` | `LevelManager` |
| System | `XyzSystem` | `CombatSystem` |
| Data / SO | `SO_Xyz` | `SO_PlayerData` |

**Convention biến trong Script:**

| Scope | Convention | Ví dụ |
|-------|-----------|-------|
| public field | PascalCase | `public float MoveSpeed;` |
| serialized private | camelCase | `[SerializeField] private float moveSpeed;` |
| private field | `_camelCase` | `private float _currentHealth;` |
| static private | `s_PascalCase` | `private static GameManager s_Instance;` |
| static public | PascalCase | `public static GameManager Instance;` |
| const | `UPPER_SNAKE_CASE` | `public const float MAX_HEALTH = 100f;` |
| property | PascalCase | `public float Health { get; private set; }` |
| method param | camelCase | `void TakeDamage(float amount)` |
| local variable | camelCase | `int enemyCount = 0;` |
| event | PascalCase + `Event` | `public event Action OnDamageEvent;` |

**Code Template:**

```csharp
public class PlayerController : MonoBehaviour
{
    // Const
    private const float MAX_HEALTH = 100f;
    
    // Static
    public static PlayerController s_Instance;
    
    // Public fields
    public float MoveSpeed;
    
    // Serialized private
    [SerializeField] private float health;
    [SerializeField] private GameObject projectilePrefab;
    
    // Private fields
    private float _currentHealth;
    private bool _isMoving;
    
    // Properties
    public float HealthPercent => _currentHealth / MAX_HEALTH;
    public bool IsDead => _currentHealth <= 0;
    
    // Events
    public event System.Action OnPlayerDeath;
    
    private void Awake() => s_Instance = this;
    
    public void TakeDamage(float amount)
    {
        _currentHealth -= amount;
        if (_currentHealth <= 0) Die();
    }
    
    private void Die()
    {
        _isMoving = false;
        OnPlayerDeath?.Invoke();
    }
}
```

---

## 4️⃣ PREFAB

| Loại | Convention | Ví dụ |
|------|-----------|-------|
| Entity | PascalCase | `Player.prefab`, `Goblin.prefab` |
| UI | `UI_Xyz` | `UI_HealthBar.prefab` |
| System | `Sys_Xyz` | `Sys_Camera.prefab` |
| Variant | Tên gốc + `_Variant` | `Player_Variant2.prefab` |
| Temp / Test | Tiền tố `_` | `_TestEnemy.prefab` |

---

## 5️⃣ SCENE

| Loại | Convention | Ví dụ |
|------|-----------|-------|
| Core | PascalCase | `Bootstrapper.unity`, `Persistent.unity` |
| Level | `Level_XX` | `Level_01.unity`, `Level_02.unity` |
| Menu | PascalCase | `MainMenu.unity`, `PauseMenu.unity` |
| Testing | `Test_PascalCase` | `Test_Combat.unity` |

---

## 6️⃣ TAG & LAYER

**Tags:**

| Convention | Ví dụ |
|-----------|-------|
| PascalCase | `Player`, `Enemy`, `Interactable` |

**Layers:**

| Convention | Ví dụ |
|-----------|-------|
| PascalCase | `Player`, `Enemy`, `Ground`, `UI` |

**Sorting Layers (theo thứ tự render từ dưới lên):**

1. `Background` - mây, núi xa
2. `Ground` - tilemap nền
3. `Shadow` - bóng object
4. `Character` - player, enemy, NPC
5. `Foreground` - cây, mái nhà
6. `UI` - giao diện

---

## 7️⃣ ANIMATION & AUDIO

**Animation:**

| Loại | Convention | Ví dụ |
|------|-----------|-------|
| Animation Clip | `Anim_Entity_Action` | `Anim_Player_Idle`, `Anim_Enemy_Attack` |
| Animator Controller | `AC_Xyz` | `AC_Player.controller`, `AC_Enemy.controller` |

**Audio:**

| Loại | Convention | Ví dụ |
|------|-----------|-------|
| Music | `Music_Xyz` | `Music_Battle.ogg`, `Music_Menu.ogg` |
| Sound Effect | `SFX_Xyz` | `SFX_Footstep.wav`, `SFX_Hit.wav` |

---

## 8️⃣ SCRIPTABLEOBJECTS & ASSETS

| Loại | Convention | Ví dụ |
|------|-----------|-------|
| ScriptableObject | `SO_Xyz` | `SO_PlayerData.asset`, `SO_EnemyWave.asset` |
| Material | `Mat_Xyz` | `Mat_Outline.mat`, `Mat_Glow.mat` |
| Shader | `Shader_Xyz` | `Shader_SpriteGlow.shader` |
| Tile Palette | PascalCase | `GrassPalette.asset`, `ForestPalette.asset` |

---

## 9️⃣ QUICK REFERENCE

**Tóm tắt nhanh - In ra để dễ nhớ:**

| Loại | Convention |
|------|-----------|
| **Folders** | PascalCase / _ThirdParty / _Temp |
| **Hierarchy** | `--- NAME ---` / `[Name]` / `Spawn_Name` / `Name_01` |
| **C# Class** | PascalCase (PlayerController.cs) |
| **C# Interface** | IPascalCase (IDamageable) |
| **C# Private** | _camelCase |
| **C# Const** | UPPER_SNAKE_CASE |
| **Prefab** | Entity.prefab / UI_Name.prefab / Sys_Name.prefab |
| **Scene** | Level_01.unity / MainMenu.unity / Test_Name.unity |
| **Tag/Layer** | PascalCase |
| **Animation** | Anim_Entity_Action |
| **Audio** | Music_Name.ogg / SFX_Name.wav |
| **ScriptableObject** | SO_Name.asset |
| **Material** | Mat_Name.mat |

---

**Cheat Sheet Sorting Layer (thứ tự từ dưới lên):**
```
6. UI
5. Foreground (cây, mái nhà)
4. Character (player, enemy, NPC)
3. Shadow (bóng)
2. Ground (tilemap)
1. Background (mây, núi)
```

---

*Last updated: June 3, 2026*