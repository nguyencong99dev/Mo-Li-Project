using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

// [CreateAssetMenu(fileName = "New Restore Skill", menuName = "Character/Skill/Restore")]
// public class RestoreSkill : SOSkill
// {
//     public bool CanUse(MonsterStats target)
//     {
//         return _effects.Any();
//     }
//     public override void Use(ICombatMonster a, ICombatMonster t)
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
//         PlayAnimationAction action = new(a, "UseSkill");
//         return action;
//     }
// }