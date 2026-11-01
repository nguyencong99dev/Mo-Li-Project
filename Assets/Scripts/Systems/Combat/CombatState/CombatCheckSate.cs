using System.Collections;
using System.Threading.Tasks;

public class CombatCheckSate : CombatState
{
    public CombatCheckSate(CombatController controller) : base(controller) { }

    public override async Task EnterState()
    {
        await HandleEnterState();
    }
    public override async Task UpdateState() { }
    public override async Task ExitState()
    {
        await HandleExitState();
    }
    async Task HandleEnterState()
    {
        UnityEngine.Debug.Log("Start Check State");
        combatController.CurrentTurnIndex = (combatController.CurrentTurnIndex + 1) % combatController.TurnOrder.Count;
        await Task.Delay(1000);
        if (combatController.CurrentActor.IsPlayerMonster)
            await combatController.ChangeState(new CombatPlayerState(combatController));
        else
            await combatController.ChangeState(new CombatEnemyState(combatController));
    }
    async Task HandleExitState()
    {
        UnityEngine.Debug.Log("End Check State");
    }
}