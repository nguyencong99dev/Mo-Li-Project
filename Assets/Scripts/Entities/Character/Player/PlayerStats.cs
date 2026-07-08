using System;
using UnityEngine;

public struct SPlayerStats
{
    public float CurrentHP;
    public float MaxHP;
    public float CurrentMP;
    public float MaxMP;
    public float CurrentSP;
    public float MaxSP;
    public int Currency;
}
public class PlayerStats : MonoBehaviour
{
    // === BASIC INFOMATION === //
    public string playerName = "Player 1";
    public int level = 1;
    public float exp = 0;
    public int currrency = 0;

    // === STATUS === //
    public float CurrentHP;
    public float CurrentMP;
    public float CurrentSP;
    private const int HPPerLv = 100;
    private const int MPPerLv = 100;
    private const int SPPerLv = 50;
    public float MaxHP => level * HPPerLv;
    public float MaxMP => level * MPPerLv;
    public float MaxSP => level * SPPerLv;

    void Start()
    {
        EventBus<SPlayerStats>.Publish(new SPlayerStats
        {
            Currency = currrency,
            CurrentHP = CurrentHP,
            CurrentMP = CurrentMP,
            CurrentSP = CurrentSP,
            MaxHP = MaxHP,
            MaxMP = MaxMP,
            MaxSP = MaxSP
        });
    }
    public void SetPlayerStats(PlayerData _playerData)
    {
        level = _playerData.level;
        CurrentHP = _playerData.currentHP;
        CurrentMP = _playerData.currentMP;
        CurrentSP = _playerData.currentSP;
        currrency = _playerData.currrency;
    }
}