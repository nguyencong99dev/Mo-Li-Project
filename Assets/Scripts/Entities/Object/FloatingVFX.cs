using System;
using System.Threading.Tasks;
using UnityEngine;

public class FloatingVFX : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] AnimatorOverrideController _overide;
    private TaskCompletionSource<bool> _tcs;
    public void Setup(AnimationClip vfx)
    {
        if (vfx != null)
        {
            _animator.runtimeAnimatorController = _overide;
            _overide["BaseSkill"] = vfx;
        }
    }
    public void OnAnimationEnd(bool result) => _tcs?.TrySetResult(result);

    public async Task WaitForHitFrame()
    {
        _tcs = new TaskCompletionSource<bool>();

        _animator.SetTrigger("Active");
        await Task.WhenAny(_tcs.Task, Task.Delay(TimeSpan.FromSeconds(3000)));
    }
}
