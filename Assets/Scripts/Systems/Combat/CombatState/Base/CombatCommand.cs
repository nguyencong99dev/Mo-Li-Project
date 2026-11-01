using System.Threading.Tasks;

public abstract class CombatCommand
{
    protected CombatController controller;
    protected SBattleContext BattleActionContext ;
    public CombatSlotMonster Actor => BattleActionContext.Actor;
    public CombatSlotMonster Target => BattleActionContext.Target;
    public CombatCommand(CombatController controller)
    {
        this.controller = controller;
        BattleActionContext = controller._pendingAction;
    }
    public abstract Task Execute();

}