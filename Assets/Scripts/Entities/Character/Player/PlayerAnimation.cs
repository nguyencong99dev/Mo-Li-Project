using UnityEngine;


public class PlayerAnimation: MonoBehaviour
{
    [SerializeField] Animator animator;
    private Vector2 facingDirection = Vector2.down;

    public void SetMovement(Vector2 movement)
    {
        animator.SetFloat(PlayerConst.HORIZONTAL, movement.x);
        animator.SetFloat(PlayerConst.VERTICAL, movement.y);
    }
    public void SetFacingDirection(Vector2 direction)
    {
        animator.SetFloat(PlayerConst.LAST_HORIZONTAL, direction.x);
        animator.SetFloat(PlayerConst.LAST_VERTICAL, direction.y);
        facingDirection = direction.normalized;
    }

    public void TriggerAction(ItemType CurrentTool)
    {
        // switch (CurrentTool)
        // {
        //     case ItemType.Axe:
        //         animator.SetTrigger(CHOPPING_TRIGGER);
        //         break;
        //     case ItemType.Sword:
        //         animator.SetTrigger(ATTACKING_TRIGGER);
        //         break;
        //     case ItemType.Pickaxe:
        //         animator.SetTrigger(MINING_TRIGGER);
        //         break;
        //     case ItemType.WateringCan:
        //         animator.SetTrigger(WATERING_TRIGGER);
        //         break;
        //     case ItemType.FishingRod:
        //         animator.SetTrigger(FISHING_TRIGGER);
        //         break;
        //     default:
        //         break;
        // }
    }

}
