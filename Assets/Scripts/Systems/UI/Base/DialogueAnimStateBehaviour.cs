using UnityEngine;

public class DialogueAnimStateBehaviour : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // animator.GetComponentInParent<FloatingVFX>()?.OnAnimationEnd(false);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var text = animator.GetComponentInParent<FloatingText>();
        if (text) text.OnAnimationEnd(true);
    }
}
