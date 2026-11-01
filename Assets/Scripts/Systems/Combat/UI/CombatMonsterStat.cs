using System;
using System.Collections;
using TMPro;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.UI;
public class CombatMonsterStat : MonoBehaviour
{
    [SerializeField] private Slider HpBar;
    [SerializeField] private Slider MpBar;
    [SerializeField] private TextMeshProUGUI NameText;
    [SerializeField] private TextMeshProUGUI LevelText;
    [SerializeField] private float FILL_SPEED = 200f;
    private Coroutine hpCoroutine;
    private Coroutine mpCoroutine;
    public void Setup(MonsterStats _stats)
    {
        if (_stats == null) return;

        if (_stats != null)
        {
            _stats.OnHPChanged -= OnHpChanged;
            _stats.OnMPChanged -= OnMpChanged;
        }

        HpBar.maxValue = _stats.MaxHP;
        HpBar.value = _stats.CurrentHP;
        MpBar.maxValue = _stats.MaxMP;
        MpBar.value = _stats.CurrentMP;

        _stats.OnHPChanged += OnHpChanged;
        _stats.OnMPChanged += OnMpChanged;
        NameText.text = _stats.Monster.name.ToString();
        LevelText.SetText(_stats.Level.ToString());
    }

    private void OnHpChanged(float current, float max)
    {
        if (HpBar == null) return;
        HpBar.maxValue = max;
        if (hpCoroutine != null)
        {
            StopCoroutine(hpCoroutine);
        }
        hpCoroutine = StartCoroutine(SmoothHpDecrease(HpBar, current));
    }

    private IEnumerator SmoothHpDecrease(Slider slider, float targetPoint)
    {
        while (!Mathf.Approximately(slider.value, targetPoint))
        {
            slider.value = Mathf.MoveTowards(slider.value, targetPoint, Time.deltaTime * FILL_SPEED);
            yield return null;
        }
        slider.value = targetPoint;
    }
    private void OnMpChanged(float current, float max)
    {
        if (MpBar == null) return;
        MpBar.maxValue = max;
        if (HpBar == null) return;
        HpBar.maxValue = max;
        if (mpCoroutine != null)
        {
            StopCoroutine(mpCoroutine);
        }
        mpCoroutine = StartCoroutine(SmoothHpDecrease(MpBar, current));
    }
}