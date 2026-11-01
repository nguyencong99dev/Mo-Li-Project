using UnityEngine;
using UnityEngine.UI;

public class SPBinder : MonoBehaviour
{
    [SerializeField] Slider spBar;
    private IHasStamina _target;

    public void Bind(IHasStamina target)
    {
        Unbind();
        _target = target;
        _target.OnSPChanged += UpdateBar;
        UpdateBar(target.CurrentSP, target.MaxSP);
    }

    void UpdateBar(float current, float max)
    {
        spBar.maxValue = max;
        spBar.value = current;
    }

    void Unbind()
    {
        if (_target != null) _target.OnSPChanged -= UpdateBar;
    }

    void OnDestroy() => Unbind();
}