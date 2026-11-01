public enum ItemType
{
    Equipment,
    Consumable,
    Tool,
    Resource
}
public enum SkillType
{
    Attack,
    Restore,
    Buff,
    Debuff,
}
public enum EffectType
{
    Harmful,
    Beneficial 
}
[System.Flags]
public enum UsageContext
{
    None = 0,
    Battle = 1 << 0,
    Overworld = 1 << 1,
    Both = Battle | Overworld
}

public enum TargetType
{
    Self,
    Ally,
    Enemy,
    AllAllies,
    AllEnemies
}
