
using System;
using System.Threading.Tasks;
using UnityEngine;

public interface IConsumable<T> where T : EffectContext
{
    bool CanUse(MonsterStats target, T context);
    void Use(MonsterStats target, T context);
}
[Serializable]
public abstract class EffectPayload
{
    public abstract bool CanApply(ICombatMonster a, ICombatMonster t);
    public abstract bool Roll(ICombatMonster a, ICombatMonster t);
    public abstract void Apply(ICombatMonster a, ICombatMonster t);
    
}

[Serializable]
public class EffectContext
{   public SOEffect Effect;
    [SerializeReference]
    public EffectPayload payload;
}
