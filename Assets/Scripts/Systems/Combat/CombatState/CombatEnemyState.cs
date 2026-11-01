using System.Collections;
using System.Threading.Tasks;

public class CombatEnemyState : CombatState
{
    public CombatEnemyState(CombatController controller) : base(controller) { }

    public override async Task EnterState()
    {
        await HandleEnterState();
    }
    public override async Task UpdateState()
    {
        
    }
    public override async Task ExitState()
    {
        await HandleExitState();
    }
    async Task HandleEnterState()
    {
        UnityEngine.Debug.Log("Enemy State Start");
        EventBus<SCombatState>.Publish(new SCombatState
        {
            State = BattleState.EnemyTurn,
            Actor = combatController.CurrentActor,
            Notification = $"Enemy Turn",
        });
        await Task.Delay(2000);

        if (combatController.CurrentActor.ActiveEffects is not null)
        {
            foreach (var e in combatController.CurrentActor.ActiveEffects)
            {
                if (e._effect.Effect.AnimationClip)
                {
                    BattleActionContext.Queue.EnqueueLast(new SpawnVFXAction(e._effect.Effect.AnimationClip, combatController.CurrentActor.transform));
                }
                BattleActionContext.Queue.EnqueueLast(new ApplyDamageAction(combatController.CurrentActor, combatController.CurrentActor, e._effect));
                BattleActionContext.Queue.EnqueueLast(new ApplyEffectAction(combatController.CurrentActor, e._effect, ActionState.Remove));     
            }

            await BattleActionContext.Queue.RunUntilEmpty(BattleActionContext);
        }

        System.Random random = new();
        var skill = combatController.CurrentActor.GetMonsterSkill()[0];

        combatController._pendingAction.Action = ActionType.Skill;
        combatController._pendingAction.Actor = combatController.CurrentActor;
        combatController._pendingAction.Target = combatController.PlayerParty[0];
        combatController._pendingAction.Skill = skill;

        await combatController.ChangeState(new CombatExcuteState(combatController));
    }
    async Task HandleExitState()
    {
        UnityEngine.Debug.Log("Enemy State End");
    }

}