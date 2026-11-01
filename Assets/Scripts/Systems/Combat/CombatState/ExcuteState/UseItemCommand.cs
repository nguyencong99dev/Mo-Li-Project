using System.Threading.Tasks;
using UnityEngine;

public class UseItemCommand : CombatCommand
{
    public UseItemCommand(CombatController controller) : base(controller) { }
    public override async Task Execute()
    {
        // if (BattleActionContext.item is IConsumable item && item.CanUse(Target.Stats,Target.IsPlayerMonster))
        // {
        //     item.Use(Target.Stats);
        // }
        // float damage = CombatCalculator.CalculateDamage(Actor, Target, BattleActionContext.skill);

        // await CombatCalculator.WaitForHitFrame(Actor, "Attack");

        // Actor.Stats.UseSkill(BattleActionContext.skill.mpCost);

        // await CombatCalculator.WaitForHitFrame(Target, "TakeDame");

        // EventBus<SExecutedEvent>.Publish(new SExecutedEvent
        // {
        //     State = Actor.IsPlayerMonster ? BattleState.PlayerTurn : BattleState.EnemyTurn,
        //     Actor = Actor,
        //     Target = Target,
        //     Notification = $"{BattleActionContext.skill.name} Active",
        //     Damage = damage
        // });

        // Target.Stats.TakeDame(damage);
        // if (Target.Stats.CurrentHP <= 0) Target.gameObject.SetActive(false);
    }
}