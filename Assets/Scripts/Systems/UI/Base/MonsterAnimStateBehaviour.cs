using UnityEngine;

public class MonsterAnimStateBehaviour : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log($"[{Time.frameCount}] EXIT monster normalizedTime={stateInfo.normalizedTime:F2}", animator);
        animator.GetComponentInParent<CombatSlotMonster>()?.OnAnimationEnd(true);
    }
}
