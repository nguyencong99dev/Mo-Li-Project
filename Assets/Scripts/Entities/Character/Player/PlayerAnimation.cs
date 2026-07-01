using UnityEngine;


public class PlayerAnimation: MonoBehaviour
{
    [SerializeField] Animator animator;
    private Vector2 facingDirection = Vector2.down;
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    private const string LAST_HORIZONTAL = "LastHorizontal";
    private const string LAST_VERTICAL = "LastVertical";

    private const string CHOPPING_TRIGGER = "Chopping";
    private const string ATTACKING_TRIGGER = "Attacking";
    private const string MINING_TRIGGER = "Mining";
    private const string WATERING_TRIGGER = "Watering";
    private const string FISHING_TRIGGER = "Fishing";


    public void SetMovement(Vector2 movement)
    {
        animator.SetFloat(HORIZONTAL, movement.x);
        animator.SetFloat(VERTICAL, movement.y);
    }
    public void SetFacingDirection(Vector2 direction)
    {
        animator.SetFloat(LAST_HORIZONTAL, direction.x);
        animator.SetFloat(LAST_VERTICAL, direction.y);
        facingDirection = direction.normalized;
    }

    public void TriggerAction(ItemType CurrentTool)
    {
        switch (CurrentTool)
        {
            case ItemType.Axe:
                animator.SetTrigger(CHOPPING_TRIGGER);
                break;
            case ItemType.Sword:
                animator.SetTrigger(ATTACKING_TRIGGER);
                break;
            case ItemType.Pickaxe:
                animator.SetTrigger(MINING_TRIGGER);
                break;
            case ItemType.WateringCan:
                animator.SetTrigger(WATERING_TRIGGER);
                break;
            case ItemType.FishingRod:
                animator.SetTrigger(FISHING_TRIGGER);
                break;
            default:
                break;
        }
    }

}
