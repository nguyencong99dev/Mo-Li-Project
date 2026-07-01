using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class StatBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    public void SetValue( float current, float max)
    {
        if (_slider == null ) return;
        _slider.maxValue = max;
        _slider.value = current;
    }
}
