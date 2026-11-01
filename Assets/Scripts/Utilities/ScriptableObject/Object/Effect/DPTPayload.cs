using UnityEngine;
using System;
using System.Threading.Tasks;

[Serializable]
public class DPTPayload : EffectPayload
{
    public int duration;
    public float damagePerTurn;
    public float canHitPercent;
    public override bool CanApply(ICombatMonster a, ICombatMonster t)
    {
        return Roll(a,t);
    }
    public override bool Roll(ICombatMonster a, ICombatMonster t)
    {
        var randomRoll = UnityEngine.Random.Range(0f, 100f);
        if (randomRoll <= canHitPercent) return true;
        return false;
    }
    public override void Apply(ICombatMonster a, ICombatMonster t)
    {
        t.Stats.TakeDamage(damagePerTurn);
    }

}