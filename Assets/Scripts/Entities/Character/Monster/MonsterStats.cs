using System;
using System.Threading.Tasks;
using UnityEngine;

public class MonsterStats 
{
    public DataMonster Member;
    // === BASIC INFOMATION === //
    public int level = 1;
    public float exp = 0;

    // === STATS === //
    public float CurrentHP;
    public float CurrentMP;

    public float MaxHP => level * Member.HPPerLV;
    public float MaxMP => level * Member.MPPerLV;

    public event Action<float, float> OnHealthChanged;
    public event Action<float, float> OnManaChanged;

    public void SetMonsterStats(MonsterData _monsterData)
    {
        Member = ManagerAssets.Instance.Monster.GetById(_monsterData.ID);
        level = _monsterData.level;
        CurrentHP = _monsterData.currentHP;
        CurrentMP = _monsterData.currentMP;
    }

}