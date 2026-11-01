using System;
using System.Threading.Tasks;
using UnityEngine;

public class MonsterStats : IHasHealth, IHasMana, IHasStamina
{
    public SOMonster Monster;
    [SerializeField] private float _level = 1;
    // [SerializeField] private float _exp = 0;
    [SerializeField] private float _currentHP;
    [SerializeField] private float _currentMP;
    [SerializeField] private float _currentSP;
    public float Level
    {
        get => _level;
        set { _level = Mathf.Clamp(value, 1, 99); OnLevelChanged?.Invoke(_level); }
    }
    public float CurrentHP
    {
        get => _currentHP;
        set { _currentHP = Mathf.Clamp(value, 0, MaxHP); OnHPChanged?.Invoke(_currentHP, MaxHP); }
    }
    public float CurrentMP
    {
        get => _currentMP;
        set { _currentMP = Mathf.Clamp(value, 0, MaxMP); OnMPChanged?.Invoke(_currentMP, MaxMP); }
    }
    public float CurrentSP
    {
        get => _currentSP;
        set { _currentSP = Mathf.Clamp(value, 0, MaxSP); OnSPChanged?.Invoke(_currentSP, MaxSP); }
    }
    public float MaxHP => _level * Monster.HPPerLV;
    public float MaxMP => _level * Monster.MPPerLV;
    public float MaxSP => 0;
    public float Speed => _level * Monster.SpeedPerLV;
    public event Action<float> OnLevelChanged;
    public event Action<float, float> OnHPChanged;
    public event Action<float, float> OnMPChanged;
    public event Action<float, float> OnSPChanged;
    public void SetMonsterStats(MonsterData _monsterData)
    {
        Monster = ManagerAssets.Instance.MonsterDB.GetById(_monsterData.ID);
        JsonUtility.FromJsonOverwrite(JsonUtility.ToJson(_monsterData), this);
    }
    public void TakeDamage(float damage)
    {
        CurrentHP = Mathf.Max(_currentHP - damage, 0);
    }
    public void RestoreHP(float amount)
    {
        CurrentHP += amount;
    }
    public void RestoreMP(float amount)
    {
        CurrentMP += amount;
    }
    public void UseSkill(float mana)
    {
        CurrentMP = Mathf.Max(_currentMP - mana, 0);
    }
    public void Attack()
    {
        
    }
}