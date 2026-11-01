using System;
using System.Threading.Tasks;
using UnityEngine;


[Serializable]
public class RestorePayload : EffectPayload
{
    public float amount;
    public override bool CanApply(ICombatMonster a, ICombatMonster t)
    {
        return !Roll(a,t);
    }
    public override bool Roll(ICombatMonster a, ICombatMonster t)
    {
        return false;
    }
    public override void Apply(ICombatMonster a, ICombatMonster t)
    {
        t.Stats.RestoreHP(amount);
    }

}