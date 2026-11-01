using UnityEngine;
using UnityEngine.UI;

public class MPBinder : MonoBehaviour
{
    [SerializeField] Slider mpBar;
    private IHasMana _target;

    public void Bind(IHasMana target)
    {
        Unbind();
        _target = target;
        _target.OnMPChanged += UpdateBar;
        UpdateBar(target.CurrentMP, target.MaxMP);
    }

    void UpdateBar(float current, float max)
    {
        mpBar.maxValue = max;
        mpBar.value = current;
    }

    void Unbind()
    {
        if (_target != null) _target.OnMPChanged -= UpdateBar;
    }

    void OnDestroy() => Unbind();
}