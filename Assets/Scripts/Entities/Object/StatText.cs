using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class StatText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private string _stat;
    public void SetValue(float current, float max)
    {
        if (_text == null) return;
        _text.text = $"{_stat}: {current}/{max}";
    }
    public void SetString(string value)
    {
        if (_text == null) return;
        _text.text = $"{value}";
    }
    public void SetCurrecy(int value)
    {
        if (_text == null) return;
        _text.text = $"{value}";
    }
}
