using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

// [CreateAssetMenu(fileName = "New Attack Skill", menuName = "Character/Skill/Attack")]
// public class AttackSkill : SOSkill
// {
//     public bool CanUse(ICombatMonster a, ICombatMonster t)
//     {
//         return _effects.Any();
//     }
//     public override void  Use(ICombatMonster a, ICombatMonster t)
//     {
//         a.Stats.UseSkill(mpCost);
//         var ctx = new SkillContext(a, t, this);
//         foreach (var effect in _effects)
//         {
//             effect.payload.Apply(ctx);
//         }
//     }
//     public override ICombatAction CombatActionType(ICombatMonster a)
//     {
//        PlayAnimationAction action  = new(a,"Attack");
//        return action;
//     }
// }