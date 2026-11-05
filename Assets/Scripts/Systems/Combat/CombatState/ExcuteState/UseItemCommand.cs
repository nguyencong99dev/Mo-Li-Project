using System.Threading.Tasks;
using UnityEngine;

public class UseItemCommand : CombatCommand
{
    public UseItemCommand(CombatController controller) : base(controller) { }
    public override async Task Execute()
    {
        ActionQueue actionContext = BattleActionContext.Queue;

        // Animation throw item or display item usage animation

        // Animation Used item on target

        // Apply item effect on target

        // 

    }
}