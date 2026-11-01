using System.Collections;
using System.Threading.Tasks;

public class CombatExcuteState : CombatState
{
    public CombatExcuteState(CombatController controller) : base(controller) { }

    public override async Task EnterState()
    {
        await HandleEnterState();
    }
    public override async Task UpdateState() { }
    public override async Task ExitState()
    {
        await HandleExitState();
    }
    private async Task HandleEnterState()
    {
        UnityEngine.Debug.Log("Action State Start");

        CombatCommand Command = ToCommand(combatController,combatController._pendingAction.Action);

        await Command.Execute();
        
        await combatController.ChangeState(new CombatCheckSate(combatController));
    }
    private async Task HandleExitState()
    {
        // combatController.Tar.SetActorActive(false);
        var Queue = new ActionQueue();
        combatController._pendingAction = new()
        {
            Queue = Queue
        };
        UnityEngine.Debug.Log("Action State End");
    }

    public CombatCommand ToCommand(CombatController controller,ActionType action)
    {
        return action switch
        {
            ActionType.Skill => new UseSkillCommand(controller),
            ActionType.Item => new UseItemCommand(controller),
            ActionType.Flee => new FleeCommand(controller),
            _ => throw new System.ArgumentOutOfRangeException($"Chưa cấu hình Command cho {action}")
        };
    }
}