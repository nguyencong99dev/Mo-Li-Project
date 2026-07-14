using System;
using System.Threading.Tasks;
using UnityEngine;

public class MonsterStats : MonoBehaviour
{
    public DataMonster Monster;
    // === BASIC INFOMATION === //
    public int level = 1;
    public float exp = 0;

    // === STATS === //
    public float CurrentHP;
    public float CurrentMP;

    public float MaxHP => level * Monster.HPPerLV;
    public float MaxMP => level * Monster.MPPerLV;
    public float Speed => level * Monster.SpeedPerLV;
    public Action<float,float> OnHPChanged;
    public Action<float,float> OnMPChanged;
    public void SetMonsterStats(MonsterData _monsterData)
    {
        Monster = ManagerAssets.Instance.Monster.GetById(_monsterData.ID);
        level = _monsterData.level;
        CurrentHP = _monsterData.currentHP;
        CurrentMP = _monsterData.currentMP;
    }
    public void TakeDame(float dame)
    {
        CurrentHP -= dame;
        OnHPChanged?.Invoke(CurrentHP,MaxHP);
    }
    
}