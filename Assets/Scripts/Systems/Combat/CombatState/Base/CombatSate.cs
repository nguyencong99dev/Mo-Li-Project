using System.Collections;
using System.Threading.Tasks;

public abstract class CombatState
{
    protected CombatController combatController;
    protected SBattleContext BattleActionContext;
    public CombatState(CombatController controller)
    {
        BattleActionContext = controller._pendingAction;
        combatController = controller;
    }
    public abstract Task EnterState();
    public abstract Task UpdateState();
    public abstract Task ExitState();
}