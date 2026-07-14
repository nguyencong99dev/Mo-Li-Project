using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BattleState
{
    BattleStart,
    PlayerTurn,
    EnemyTurn,
    ExecuteAction,
    CheckBattleEnd,
    BattleEnd
}
public enum ActionType
{
    Attack,  // dùng skill tấn công
    Item,    // dùng item
    Capture, // bắt monster
    Flee     // bỏ chạy
}

// Struct chứa thông tin action được chọn
public struct BattleAction
{
    public ActionType actionType;
    public MonsterStats actor;   // ai đang thực hiện
    public MonsterStats target;  // mục tiêu
    public DataSkill skill;         // skill được chọn (nếu Attack)
    public DataItem item;           // item được chọn (nếu Item)
}

public struct SkillExecutedEvent
{
    public MonsterStats actor;
    public float damage;
    public MonsterStats target;
}
public struct SPlayerTurnEvent
{
    public MonsterStats monster;
}
public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance { get; private set; }
    public BattleState CurrentState { get; private set; }
    [SerializeField] BuildSlotCombatMonster slotCombatMonster;
    BattleAction _pendingAction;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            return;
        }
        Debug.Log("Manager Combat Initialized");
    }
    void Start() => ChangeState(BattleState.BattleStart);

    public void ChangeState(BattleState newState)
    {
        CurrentState = newState;
        Debug.Log($"BattleState: {newState}");

        switch (newState)
        {
            case BattleState.BattleStart:
                StartCoroutine(HandleBattleStart());
                break;
            case BattleState.PlayerTurn:
                StartCoroutine(HandlePlayerTurn());
                break;
            case BattleState.EnemyTurn:
                StartCoroutine(HandleEnemyTurn());
                break;
            case BattleState.ExecuteAction:
                StartCoroutine(HandleExecuteAction());
                break;
            case BattleState.CheckBattleEnd:
                HandleCheckBattleEnd();
                break;
            case BattleState.BattleEnd:
                StartCoroutine(HandleBattleEnd());
                break;
        }
    }
    void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
    // ── BattleStart ──────────────────────────────────────
    IEnumerator HandleBattleStart()
    {
        // Load data từ GameManager
        // var encounter = GameManager.Instance.PendingEncounter;
        // var enemyData = DatabaseManager.Instance.Monsters
        //     .GetById(encounter.enemyMonsterId);

        // // Khởi tạo runtime instance
        // PlayerMonster = new MonsterInstance(
        //     GameManager.Instance.CurrentParty[0]);
        // EnemyMonster = new MonsterInstance(enemyData);

        // // Publish event để UI setup
        // EventBus<BattleStartEvent>.Publish(new BattleStartEvent
        // {
        //     playerMonster = PlayerMonster,
        //     enemyMonster = EnemyMonster
        // });
        Debug.Log("Battle Start");
        yield return new WaitForSeconds(1.5f); // chờ animation intro

        ChangeState(BattleState.PlayerTurn);
    }

    // // ── PlayerTurn ───────────────────────────────────────
    IEnumerator HandlePlayerTurn()
    {
        Debug.Log("Player Turn");
        // Bật UI chọn action, chờ player bấm
        EventBus<SPlayerTurnEvent>.Publish(new SPlayerTurnEvent
        {
            monster = slotCombatMonster.PlayerParty[0]
        });

        // Chờ đến khi player chọn action xong
        // UIManager_Battle sẽ gọi SubmitAction() khi player confirm
        yield return new WaitUntil(() => _pendingAction.actor != null && _pendingAction.target != null);

        ChangeState(BattleState.ExecuteAction);
        Debug.Log("Player Turn Ended");
    }

    // // Được gọi từ UIManager_Battle khi player chọn skill/item
    public void SubmitAction(BattleAction action)
    {
        _pendingAction = action;
    }

    // ── EnemyTurn ────────────────────────────────────────
    IEnumerator HandleEnemyTurn()
    {
        Debug.Log("Enemy Turn");
        yield return new WaitForSeconds(1f); 
        
        var skill = slotCombatMonster.EnemyParty[0].Monster.
            Skills[0];
        DataSkill _skill = ManagerAssets.Instance.SkillDB.GetByID(skill);
        _pendingAction = new BattleAction
        {
            actionType = ActionType.Attack,
            actor = slotCombatMonster.EnemyParty[0],
            target = slotCombatMonster.PlayerParty[0],
            skill  = _skill
        };

        ChangeState(BattleState.ExecuteAction);
        Debug.Log("Enemy Turn Ended");
    }

    // // ── ExecuteAction ────────────────────────────────────
    IEnumerator HandleExecuteAction()
    {
        switch (_pendingAction.actionType)
        {
            case ActionType.Attack:
                yield return StartCoroutine(ExecuteSkill(_pendingAction));
                break;
            case ActionType.Item:
                // yield return StartCoroutine(ExecuteItem(_pendingAction));
                break;
            case ActionType.Flee:
                // yield return StartCoroutine(ExecuteFlee());
                break;
            case ActionType.Capture:
                // yield return StartCoroutine(ExecuteCapture(_pendingAction));
                break;
        }

        // Reset pending action
        _pendingAction = new BattleAction();
        ChangeState(BattleState.CheckBattleEnd);
    }

    IEnumerator ExecuteSkill(BattleAction action)
    {
        // Tính damage
        // float damage = CalculateDamage(action.actor, action.target, action.skill);

        // Publish event để UI hiện animation
        EventBus<SkillExecutedEvent>.Publish(new SkillExecutedEvent
        {
            actor = action.actor,
            damage = 5f,
            target = action.target
        });
        Debug.Log("Execute Skill");
        // Chờ animation xong
        yield return new WaitForSeconds(1f);
        Debug.Log("Execute Skill Ended");
        // Áp dụng damage
        action.target.TakeDame(50f);
    }

    // ── CheckBattleEnd ───────────────────────────────────
    void HandleCheckBattleEnd()
    {
        // if (EnemyMonster.CurrentHP <= 0)
        // {
        //     ChangeState(BattleState.BattleEnd);
        //     return;
        // }

        // if (PlayerMonster.CurrentHP <= 0)
        // {
        //     ChangeState(BattleState.BattleEnd);
        //     return;
        // }
        // Chưa kết thúc → đổi lượt
        bool wasPlayerTurn = CurrentState == BattleState.PlayerTurn;
        ChangeState(wasPlayerTurn
            ? BattleState.EnemyTurn
            : BattleState.PlayerTurn);
    }

    // ── BattleEnd ─────────────────────────────────────────
    IEnumerator HandleBattleEnd()
    {
        // bool playerWon = EnemyMonster.CurrentHP <= 0;

        // EventBus<BattleEndEvent>.Publish(new BattleEndEvent
        // {
        //     playerWon = playerWon,
        //     expGained = playerWon ? EnemyMonster.Data.baseExp : 0,
        //     goldGained = playerWon ? EnemyMonster.Data.baseGold : 0
        // });

        yield return new WaitForSeconds(2f);

        // Unload Battle Scene
        // ManagerScene.Instance.UnloadSceneAsync("Battle");
    }
}
