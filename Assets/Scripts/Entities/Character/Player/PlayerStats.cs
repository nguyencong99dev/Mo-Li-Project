using System;
using UnityEngine;


public class PlayerStats : IHasHealth, IHasMana, IHasStamina
{
    [SerializeField] private float _currentHP;
    [SerializeField] private float _currentMP;
    [SerializeField] private float _currentSP;
    [SerializeField] private string _playerName;
    [SerializeField] private int _level = 1;
    [SerializeField] private float _exp = 0;
    [SerializeField] private int _currency = 0;
    public string GetPlayerName() => _playerName;
    public int GetLevel() => _level;
    public float GetExp() => _exp;
    public int GetCurrency() => _currency;
    public float CurrentHP
    {
        get => _currentHP;
        set
        {
            _currentHP = Mathf.Clamp(value, 0, MaxHP);
            OnHPChanged?.Invoke(_currentHP, MaxHP);
        }
    }
    public float CurrentMP
    {
        get => _currentMP;
        set
        {
            _currentMP = Mathf.Clamp(value, 0, MaxMP);
            OnMPChanged?.Invoke(_currentMP, MaxMP);
        }
    }
    public float CurrentSP
    {
        get => _currentSP;
        set
        {
            _currentSP = Mathf.Clamp(value, 0, MaxSP);
            OnSPChanged?.Invoke(_currentSP, MaxSP);
        }
    }
    private const int HPPerLv = 100;
    private const int MPPerLv = 100;
    private const int SPPerLv = 50;
    public float MaxHP => _level * HPPerLv;
    public float MaxMP => _level * MPPerLv;
    public float MaxSP => _level * SPPerLv;
    public event Action<float, float> OnHPChanged;
    public event Action<float, float> OnMPChanged;
    public event Action<float, float> OnSPChanged;

    public void SetPlayerStats(string _playerData)
    {
        JsonUtility.FromJsonOverwrite(_playerData, this);
        EventBus<SPlayerStats>.Publish(new SPlayerStats { player = this });
    }
    public PlayerSaveData GetPlayerSaveData()
    {
        PlayerSaveData savedata = new();
        string _data = JsonUtility.ToJson(this);
        JsonUtility.FromJsonOverwrite(_data, savedata);
        return savedata;
    }

}