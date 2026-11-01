using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class CombatPlayerState : CombatState
{
    public CombatPlayerState(CombatController controller) : base(controller) { }
    public CombatSlotMonster CurrentActor => combatController.CurrentActor;
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
        UnityEngine.Debug.Log("Player State Start");
        EventBus<SCombatState>.Publish(new SCombatState
        {
            State = BattleState.PlayerTurn,
            Actor = combatController.CurrentActor,
            Notification = $"Your Turn"
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

        SubStateAction CurrentSubstate = SubStateAction.SelectedAction;

        while (CurrentSubstate <= SubStateAction.ConfirmAction)
        {
            switch (CurrentSubstate)
            {
                case SubStateAction.SelectedAction:
                    var action = new SelectActionSubState(this, BattleActionContext);
                    var actionStatus = await action.Execute();
                    if (actionStatus == SubStateStatus.Completed)
                    {
                        CurrentSubstate = SubStateAction.SelectedTarget;
                        if (action.Result.Action == ActionType.Item)
                        {
                            action.Result.Item.SetSelected(true);

                            ShowTargetUI(
                                action.Result.Item.Item.targetType
                            );
                        }
                        else if (action.Result.Action == ActionType.Skill)
                        {
                            ShowTargetUI(
                                action.Result.Skill.targetType
                            );
                        }
                        BattleActionContext = action.Result;
                    }
                    break;
                case SubStateAction.SelectedTarget:
                    var target = new SelectTargetSubState(this, BattleActionContext);
                    var targetStatus = await target.Execute();
                    if (targetStatus == SubStateStatus.ChangeAction)
                    {
                        CurrentSubstate = SubStateAction.SelectedAction;
                        BattleActionContext = target.Result;
                    }
                    else
                    {
                        CurrentSubstate = SubStateAction.ConfirmAction;
                        SelectTarget(target.Result.Target);
                        BattleActionContext.Target = target.Result.Target;
                    }
                    break;
                case SubStateAction.ConfirmAction:
                    var confirm = new ConfirmActionSubState(this, BattleActionContext);
                    var confirmStatus = await confirm.Execute();
                    switch (confirmStatus)
                    {
                        case SubStateStatus.ChangeAction:
                            CurrentSubstate = SubStateAction.SelectedAction;
                            BattleActionContext = confirm.Result;
                            break;
                        case SubStateStatus.Back:
                            CurrentSubstate = SubStateAction.SelectedTarget;
                            BattleActionContext.Target = confirm.Result.Target;
                            break;
                        case SubStateStatus.Completed:
                            CurrentSubstate = SubStateAction.End;
                            BattleActionContext.Actor = combatController.CurrentActor;
                            BattleActionContext.Confirm = confirm.Result.Confirm;
                            break;
                    }
                    break;
            }
        }

        combatController._pendingAction = BattleActionContext;
        await combatController.ChangeState(new CombatExcuteState(combatController));
    }
    async Task HandleExitState()
    {
        Debug.Log("Player State End");
        foreach (CombatSlotMonster monster in combatController.TurnOrder)
        {
            monster.SetTargetActive(false);
            monster.IsSelected = false;
        }
    }
    public void ShowTargetUI(TargetType targetType)
    {
        foreach (CombatSlotMonster monster in combatController.TurnOrder)
        {
            if (monster == null) continue;
            bool canBeTargeted = CombatCalculator.IsValidTarget(monster, targetType, monster.IsPlayerMonster);
            monster.SetTargetActive(canBeTargeted);
        }
    }
    public void SelectTarget(CombatSlotMonster slot)
    {
        foreach (CombatSlotMonster monster in combatController.TurnOrder)
        {
            monster.SetTargetActive(false);
        }
        slot.SetTargetActive(true);
    }
}