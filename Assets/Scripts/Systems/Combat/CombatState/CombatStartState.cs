using System.Threading.Tasks;

public class CombatStartState : CombatState
{
    public CombatStartState(CombatController controller) : base(controller) { }

    public override async Task EnterState()
    {
        await HandleBattleStart();
    }
    public override async Task UpdateState() { }
    public override async Task ExitState()
    {
        await HandleExitState();
    }
    async Task HandleBattleStart()
    {
        UnityEngine.Debug.Log("Start State start");
        EventBus<SCombatState>.Publish(new SCombatState
        {
            State = BattleState.BattleStart,
            Notification = $"Battle Start"
        });

        await Task.Delay(2000);
        
        combatController.CurrentTurnIndex = (combatController.CurrentTurnIndex + 1) % combatController.TurnOrder.Count;

        if (combatController.CurrentActor.IsPlayerMonster)
            await combatController.ChangeState(new CombatPlayerState(combatController));
        else
            await combatController.ChangeState(new CombatEnemyState(combatController));
    }
    async Task HandleExitState()
    {
        UnityEngine.Debug.Log("Start State end");
    }
}