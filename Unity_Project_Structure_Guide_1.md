# Đề xuất Folder Structure & Naming Convention

> Dựa trên kiến trúc hiện tại: Bootstrapper pattern, persistent Managers, EventBus, ScriptableObject cho dữ liệu tĩnh (Species/Item/Class), state machine cho combat.

---

## 1. Vấn đề gốc rễ

Khi project "phình ra" mà không có convention rõ ràng, thường là do **thiếu một trục tổ chức nhất quán**. Có 2 trục phổ biến:

- **Tổ chức theo loại (by type)**: `Scripts/Managers/`, `Scripts/UI/`, `Scripts/Data/`...
- **Tổ chức theo tính năng (by feature/system)**: `Scripts/Combat/`, `Scripts/Inventory/`, `Scripts/Monster/`...

Trộn cả hai mà không có quy tắc rõ ràng (như bạn đang gặp) là nguyên nhân chính gây rối. Đề xuất: **feature-first, type-second** — vì hệ thống của bạn (Combat, Inventory, Monster) đã tách khá rõ về mặt logic (state machine riêng, EventBus riêng), nên nhóm theo feature sẽ giúp bạn tìm code nhanh hơn khi debug một hệ thống cụ thể.

---

## 2. Folder Structure đề xuất

```
Assets/
├── _Project/                          ← prefix "_" để luôn nằm trên cùng, tách biệt code của bạn với asset bên thứ 3
│   ├── Art/
│   │   ├── Characters/
│   │   ├── Monsters/
│   │   ├── Environment/
│   │   ├── UI/
│   │   └── VFX/
│   ├── Audio/
│   │   ├── Music/
│   │   ├── SFX/
│   │   └── Ambience/
│   ├── Prefabs/
│   │   ├── Managers/                  ← prefab cho các persistent manager
│   │   ├── Combat/
│   │   ├── Monsters/
│   │   ├── Items/
│   │   └── UI/
│   ├── Scenes/
│   │   ├── Boot/
│   │   ├── World/
│   │   └── Combat/
│   ├── ScriptableObjects/             ← instance dữ liệu (asset), KHÔNG phải class definition
│   │   ├── Species/
│   │   ├── Items/
│   │   ├── Skills/
│   │   └── Classes/
│   ├── Scripts/
│   │   ├── Core/                      ← nền tảng dùng chung toàn game
│   │   │   ├── Bootstrapper/
│   │   │   ├── Managers/              ← ManagerInput, ManagerAssets, SaveManager...
│   │   │   ├── EventBus/
│   │   │   ├── Interfaces/            ← IHasHealth, IUsableItem, IDraggable...
│   │   │   └── Utilities/
│   │   ├── Systems/                   ← mỗi feature 1 folder con, tự chứa
│   │   │   ├── World/                 ← MỌI THỨ chỉ tồn tại ở World Scene
│   │   │   │   ├── Player/            ← PlayerController, movement, world interaction
│   │   │   │   ├── Encounter/         ← EncounterManager, EncounterTrigger
│   │   │   │   │   └── Data/          ← EncounterTableData (SO)
│   │   │   │   └── NPC/               ← nếu có NPC, dialogue trigger...
│   │   │   ├── Combat/                ← MỌI THỨ chỉ tồn tại ở Combat Scene
│   │   │   │   ├── StateMachine/      ← PlayerTurnState, BattleAction...
│   │   │   │   ├── Data/              ← MonsterStats (plain C# class)
│   │   │   │   └── UI/                ← script UI CHỈ dùng cho combat
│   │   │   ├── Party/                 ← CROSS-CUTTING: roster dùng cả World lẫn Combat
│   │   │   │   ├── Data/              ← PartyMember, PartyRoster
│   │   │   │   └── UI/                ← party menu (world) — KHÔNG phải combat unit card
│   │   │   ├── Inventory/
│   │   │   │   ├── Data/              ← ItemData, ConsumableItemData...
│   │   │   │   └── UI/
│   │   │   ├── Monster/               ← species/collection logic, KHÔNG phải combat stats
│   │   │   │   ├── Data/
│   │   │   │   └── UI/
│   │   │   └── SaveLoad/
│   │   ├── UI/                        ← UI dùng chung nhiều hệ thống
│   │   │   ├── Common/                ← StatBarDisplay, TabSystem
│   │   │   └── DragDrop/              ← DragDropManager, ghost item
│   │   └── Editor/                    ← custom editor script (nếu có)
│   └── Settings/                      ← Input Actions, Addressables Groups, Render Settings...
├── Plugins/
└── ThirdParty/                        ← asset store, package ngoài — KHÔNG sửa trực tiếp
```

**Quy tắc chọn chỗ đặt file:**
- Nếu code chỉ phục vụ **1 hệ thống duy nhất** (ví dụ `PlayerTurnState`) → nằm trong `Systems/Combat/`.
- Nếu code được **nhiều hệ thống dùng chung** (ví dụ `StatBarDisplay` dùng cho cả HP bar combat lẫn HP bar overworld) → nằm trong `UI/Common/`.
- Nếu code là **nền tảng/hạ tầng** (Manager, EventBus, Interface dùng toàn cục) → nằm trong `Core/`.

Nguyên tắc kiểm tra nhanh: *"Nếu tôi xoá cả hệ thống Combat, file này có bị xoá theo không?"* → Có thì nó thuộc `Systems/Combat/`, không thì nó thuộc `Core/` hoặc `UI/Common/`.

### 2.1. Vì sao gom `Player` + `Encounter` vào `World/`

Cấu trúc code nên phản ánh cấu trúc scene, vì đó là ranh giới tự nhiên nhất trong game của bạn — bạn đã có sẵn 2 "cụm" scene-local manager tương ứng: `EncounterManager` (World) và `CombatManager` (Combat). Việc gom `World/` và `Combat/` làm 2 nhánh song song giúp:

- Khi debug lỗi ở overworld, bạn chỉ cần nhìn trong `Systems/World/`, không lẫn với logic combat.
- Ranh giới bàn giao rõ ràng: `EncounterManager` (trong `World/Encounter/`) là nơi **kích hoạt** trận đấu — nó gọi `SceneLoader` (ở `Core/`) để chuyển sang Combat Scene, kèm dữ liệu encounter (danh sách monster địch) truyền qua `EventBus` hoặc một shared data object. Bản thân logic trận đấu (state machine, turn order...) hoàn toàn không nằm trong `World/`.
- `Player/` nằm trong `World/` vì `PlayerController` (di chuyển, tương tác overworld) không tồn tại trong Combat Scene — đơn vị người chơi điều khiển trong Combat là monster/party member, không phải `PlayerController`.

### 2.2. Vì sao `Party` và `Monster` tách riêng, không nằm trong `World/` hay `Combat/`

- **`Party/`** là cross-cutting: dữ liệu roster (đội hình hiện tại) được đọc ở world (menu quản lý đội hình) *và* ở combat (ai ra trận). Nếu nhét vào `World/` thì `Combat/` phải reference ngược lại `World/` — vi phạm ranh giới bạn vừa tạo ra. Để nó độc lập ở `Systems/Party/`, cả `World/` và `Combat/` đều được phép reference nó.
- **`Monster/`** ở đây nên hiểu là hệ thống **species/collection** (bắt, sở hữu, xem thông tin loài) — khác với `MonsterStats` (chỉ số chiến đấu tức thời) nằm trong `Combat/Data/`. Nếu một class vừa mô tả "loài monster này là gì" thì thuộc `Monster/`, còn nếu mô tả "monster này đang có bao nhiêu HP/MP trong trận" thì thuộc `Combat/Data/`.

> Quy tắc chung khi phân vân 1 script thuộc `World/`, `Combat/`, hay top-level: hỏi *"Script này có được reference bởi cả 2 scene không?"* — Có → top-level (`Party/`, `Inventory/`, `Monster/`, `SaveLoad/`). Không, chỉ 1 scene → nest vào `World/` hoặc `Combat/`.

---

## 3. Naming Convention

### 3.1. Script & Class

| Loại | Convention | Ví dụ |
|---|---|---|
| MonoBehaviour (component) | PascalCase, tên = chức năng | `HealthBarBinder`, `PlayerController` |
| Manager (persistent, singleton) | **Chọn 1 kiểu và áp dụng toàn bộ** — xem lưu ý bên dưới | `InputManager` (khuyến nghị đổi từ `ManagerInput`) |
| Manager (scene-local) | Cùng convention với manager persistent | `CombatManager`, `EncounterManager` |
| Interface | Prefix `I` + tính từ/khả năng | `IHasHealth`, `IUsableItem`, `IDraggable` |
| ScriptableObject data class | Suffix `Data` | `ItemData`, `ConsumableItemData`, `SpeciesData` |
| Plain C# data class (non-MonoBehaviour) | PascalCase, tên là danh từ | `MonsterStats`, `BattleAction` |
| State (trong state machine) | Suffix `State` | `SelectSkillState`, `SelectTargetState` |
| Event (EventBus) | Dạng "ChuyệnGìĐãXảyRa" thì hậu tố Event, hoặc tiền tố On | `MonsterDefeatedEvent`, `OnTurnStarted` |

> **Lưu ý quan trọng:** bạn hiện có `ManagerInput`, `ManagerAssets` (prefix "Manager") nhưng lại có `CombatManager`, `EncounterManager`, `GameManager` (suffix "Manager") — đây chính là một phần gây rối. Khuyến nghị **thống nhất về suffix** (`InputManager`, `AssetsManager`...) vì:
> - Trong Solution Explorer / Project window, các file sẽ tự nhóm lại gần nhau khi sort alphabet (`AssetsManager`, `CombatManager`, `InputManager`... đứng cạnh nhau theo chữ cái đầu của domain).
> - Đây cũng là convention phổ biến hơn trong cộng đồng Unity/C#.

### 3.2. Folder

- PascalCase, không dùng khoảng trắng: `ScriptableObjects/`, không phải `Scriptable Objects/`.
- Số nhiều cho folder chứa nhiều item cùng loại: `Managers/`, `Prefabs/`, `Interfaces/`.
- Tên folder feature phải khớp tên hệ thống dùng trong code/EventBus, để tránh lệch thuật ngữ (ví dụ nếu EventBus có `CombatEventBus` thì folder phải là `Combat/`, không phải `Battle/`).

### 3.3. Prefab & Asset

| Loại | Convention | Ví dụ |
|---|---|---|
| Prefab UI | `UI_TênChứcNăng` | `UI_BattleHUD`, `UI_InventorySlot` |
| Prefab Manager | Trùng tên script | `InputManager.prefab` |
| ScriptableObject asset (instance) | `SO_TênLoại_TênCụThể` | `SO_Item_HealingPotion`, `SO_Species_Firewolf` |
| Scene | `TênLoại_TênCảnh` | `Scene_Boot`, `Scene_Combat_Forest` |

### 3.4. Namespace (khuyến nghị bổ sung)

Nếu chưa dùng namespace, nên thêm để namespace phản ánh đúng folder, giúp tránh trùng tên class và làm rõ ranh giới hệ thống:

```csharp
namespace Game.Core.Managers { ... }
namespace Game.Systems.Combat.StateMachine { ... }
namespace Game.Systems.Inventory.Data { ... }
```

---

## 4. Bước triển khai thực tế (tránh "big bang refactor")

Refactor toàn bộ project cùng lúc rất dễ vỡ (đặc biệt với references trong Inspector — di chuyển file có thể làm mất reference nếu không cẩn thận). Đề xuất làm theo thứ tự:

1. **Tạo cấu trúc folder mới song song**, chưa xoá folder cũ.
2. Trong Unity, luôn di chuyển file bằng cách **kéo-thả trong Project window** (không thao tác ở File Explorer ngoài Unity) — Unity sẽ tự cập nhật `.meta` file và giữ nguyên reference.
3. Refactor theo **từng hệ thống một**, bắt đầu từ hệ thống ít dependency nhất (ví dụ Inventory trước, Combat sau vì Combat phụ thuộc nhiều thứ hơn).
4. Sau khi gom xong 1 hệ thống, dùng `Find References` (hoặc rebuild + check Console) để đảm bảo không có broken reference trước khi qua hệ thống tiếp theo.
5. Đổi tên class (như `ManagerInput` → `InputManager`) làm **riêng một pass cuối cùng**, dùng tính năng Rename của IDE (Rider/VS) để tự động cập nhật mọi chỗ gọi tới, tránh sửa tay.

---

## 5. Nâng cao (khi project lớn hơn nữa)

- **Assembly Definition (`.asmdef`)** theo từng `Systems/*` và `Core/` — giúp giảm thời gian compile (Unity chỉ recompile assembly bị thay đổi) và ép buộc ranh giới dependency (Inventory không thể vô tình reference thẳng vào Combat nếu không khai báo asmdef reference).
- Cân nhắc tách `Core/EventBus` thành package riêng nếu bạn dự định tái sử dụng cho project khác sau này.
