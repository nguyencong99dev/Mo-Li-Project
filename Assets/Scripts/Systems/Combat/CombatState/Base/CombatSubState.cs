using System;
using System.Threading.Tasks;

public abstract class CombatSubState
{
    public CombatPlayerState combatPlayerState;
    public SBattleContext Result;
    public CombatSubState(CombatPlayerState state,SBattleContext _result)
    {
        combatPlayerState = state;
        Result = _result;
    }
    public abstract Task<SubStateStatus> Execute();
    public void SetResult(SBattleContext action)
    {
        Result.Action = action.Action;
        Result.Item = action.Item != null ? action.Item : null;
        Result.Skill = action.Skill != null ? action.Skill : null;
        Result.Target = action.Target;
        Result.Confirm = action.Confirm;
    }
}