using UnityEngine;
using System;
using System.Threading.Tasks;


[Serializable]
public class DamagePayload : EffectPayload
{
    public float damage;

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
        t.Stats.TakeDamage(damage);
    }

}