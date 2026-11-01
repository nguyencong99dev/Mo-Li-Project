using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    [SerializeField] CombatDataManager combatDataManager;
    public List<CombatSlotMonster> PlayerParty => combatDataManager.PlayerParty;
    public List<CombatSlotMonster> EnemyParty => combatDataManager.EnemyParty;
    public List<CombatSlotMonster> TurnOrder => combatDataManager.TurnOrder;
    public SBattleContext _pendingAction = new();
    public int CurrentTurnIndex = 0;
    public CombatSlotMonster CurrentActor => TurnOrder[CurrentTurnIndex];
    private CombatState _currentState;
    private CombatState LastState;
    async void Awake()
    {
        var Queue = new ActionQueue();
        _pendingAction.Queue = Queue;
        await ChangeState(new CombatStartState(this));
    }
    void Update()
    {
        // _currentState?.UpdateState();
    }
    public async Task ChangeState(CombatState newState)
    {
        LastState = _currentState;

        _currentState?.ExitState();
        _currentState = newState;
        await _currentState?.EnterState();
    }

    // // ── BattleEnd ─────────────────────────────────────────
    // IEnumerator HandleBattleEnd()
    // {
    //     // bool playerWon = EnemyMonster.CurrentHP <= 0;

    //     // EventBus<BattleEndEvent>.Publish(new BattleEndEvent
    //     // {
    //     //     playerWon = playerWon,
    //     //     expGained = playerWon ? EnemyMonster.Data.baseExp : 0,
    //     //     goldGained = playerWon ? EnemyMonster.Data.baseGold : 0
    //     // });

    //     yield return new WaitForSeconds(2f);

    //     // Unload Battle Scene
    //     // ManagerScene.Instance.UnloadSceneAsync("Battle");
    // }
}
