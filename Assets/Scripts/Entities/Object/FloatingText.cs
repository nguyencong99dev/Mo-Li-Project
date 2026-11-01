using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] TextMesh textMesh;
    [SerializeField] Animator _animator;
    private TaskCompletionSource<bool> _tcs;
    public event Action<FloatingText> OnComplete;
    public void Setup(string text)
    {
        meshRenderer.sortingLayerName = "UI";
        meshRenderer.sortingOrder = 5;
        textMesh.text = text;
    }

    public void OnAnimationEnd(bool result) => _tcs?.TrySetResult(result);

    public async Task WaitForHitFrame()
    {
        _tcs = new TaskCompletionSource<bool>();

        _animator.SetTrigger("Active");
        await Task.WhenAny(_tcs.Task, Task.Delay(TimeSpan.FromSeconds(3000)));
    }

}
