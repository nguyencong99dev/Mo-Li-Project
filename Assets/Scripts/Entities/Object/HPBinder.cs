using UnityEngine;
using UnityEngine.UI;

public class HPBinder : MonoBehaviour
{
    [SerializeField] Slider hpBar;
    private IHasHealth _target;

    public void Bind(IHasHealth target)
    {
        Unbind();
        _target = target;
        _target.OnHPChanged += UpdateBar;
        UpdateBar(target.CurrentHP, target.MaxHP);
    }

    void UpdateBar(float current, float max)
    {
        hpBar.maxValue = max;
        hpBar.value = current;
    }

    void Unbind()
    {
        if (_target != null) _target.OnHPChanged -= UpdateBar;
    }

    void OnDestroy() => Unbind();
}