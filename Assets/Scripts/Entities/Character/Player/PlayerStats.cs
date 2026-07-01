using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // === BASIC INFOMATION === //
    public string playerName = "Player 1";
    public int level = 1;
    public float exp = 0;
    public int currrency = 0;

    // === STATUS === //
    public float CurrentHP;
    public float CurrentMP ;
    public float CurrentSP;
    private const int HPPerLv = 100;
    private const int MPPerLv = 100;
    private const int SPPerLv = 50;
    public float MaxHP => level * HPPerLv;
    public float MaxMP => level * MPPerLv;
    public float MaxSP => level * SPPerLv;

    public event Action<float, float> OnHealthChanged;
    public event Action <float, float> OnManaChanged;
    public event Action<float, float> OnStaminaChanged;
    public event Action<int> OnCurrencyChanged;

    public void SetPlayerStats(PlayerData _playerData)
    {
        level = _playerData.level;
        CurrentHP = _playerData.currentHP;
        CurrentMP = _playerData.currentMP;
        CurrentSP = _playerData.currentSP;
        currrency = _playerData.currrency;
    }
    public void TakeDamage(float amount)
    {
        CurrentHP = Mathf.Max(0, CurrentHP - amount);
        OnHealthChanged?.Invoke(CurrentHP, MaxHP);
    }
    public void UseMana(float amount)
    {
        CurrentMP = Mathf.Max(0, CurrentMP - amount);
        OnManaChanged?.Invoke(CurrentMP, MaxMP);
    }
}