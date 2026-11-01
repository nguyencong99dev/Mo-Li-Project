using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class UseSkillCommand : CombatCommand
{
    public UseSkillCommand(CombatController controller) : base(controller) { }
    public override async Task Execute()
    {
        BattleActionContext.Queue.EnqueueLast(new PlayAnimationAction(Actor, BattleActionContext.Skill));

        BattleActionContext.Queue.EnqueueLast(new SpawnVFXAction(BattleActionContext.Skill.AnimationClip, Target.transform));

        BattleActionContext.Queue.EnqueueLast(new UseSkillAction(Actor, BattleActionContext.Skill));

        foreach (var e in BattleActionContext.Skill._effects)
        {
            if (e.payload.Roll(Actor, Target)) // true
            {
                BattleActionContext.Queue.EnqueueLast(new SpawnVFXAction(e.Effect.AnimationClip, Target.transform));
                BattleActionContext.Queue.EnqueueLast(new ApplyEffectAction(Target, e, ActionState.Add));
                continue;
            }
            if (e.payload.CanApply(Actor, Target)) // false
            {
                BattleActionContext.Queue.EnqueueLast(new ApplyDamageAction(Actor, Target, e));
            }
            else
            {
                continue;
            }
        }

        await BattleActionContext.Queue.RunUntilEmpty(BattleActionContext);
    }
}