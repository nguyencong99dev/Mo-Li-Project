using System.Collections.Generic;
using UnityEngine;

public enum TargetType
{
    Self,
    Ally,
    Enemy,
    AllAllies,
    AllEnemies
}

[CreateAssetMenu(fileName = "New Skill", menuName = "Character/Skill")]
public class DataSkill : ScriptableObject
{
    public string ID;
    public string Name;
    public Sprite Image;
    public int power;
    public int mpCost;
    public TargetType targetType;
}
