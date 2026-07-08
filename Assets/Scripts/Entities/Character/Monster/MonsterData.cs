using System;

[Serializable]
public class MonsterData
{
    public string ID;   // dùng để tra lại MemeberSpeciesData
    public int level;
    public int exp;
    public float currentHP = 75;
    public float currentMP = 75;
}