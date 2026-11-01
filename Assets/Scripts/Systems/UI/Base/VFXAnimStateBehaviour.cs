using UnityEngine;

public class VFXAnimStateBehaviour : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // animator.GetComponentInParent<FloatingVFX>()?.OnAnimationEnd(false);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var vfx = animator.GetComponentInParent<FloatingVFX>();
        if (vfx) vfx.OnAnimationEnd(true);
    }
}
