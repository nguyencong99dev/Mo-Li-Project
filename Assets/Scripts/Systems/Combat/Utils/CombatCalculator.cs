using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public static class CombatCalculator
{
    public static List<CombatSlotMonster> ArrangeTurn(List<CombatSlotMonster> playerParty, List<CombatSlotMonster> enemyParty)
    {
        // Gộp 2 bên vào 1 list
        List<CombatSlotMonster> allMonsters = new List<CombatSlotMonster>();
        allMonsters.AddRange(playerParty);
        allMonsters.AddRange(enemyParty);

        // Sort theo Speed giảm dần (cao hơn đi trước)
        List<CombatSlotMonster> turnOrder = allMonsters
            .OrderByDescending(m => m.GetMonsterSpeed())
            .ToList();

        return turnOrder;
    }
    public static float CalculateDamage(CombatSlotMonster attacker, CombatSlotMonster defender, SOSkill skill)
    {
        // float baseDamage = (attacker.ATK * skill.power) / defender.DEF;
        // float typeMultiplier = TypeChart.GetMultiplier(skill.element, defender.element);
        // float variance = Random.Range(0.9f, 1.1f);
        return Mathf.Max(1f, 10f);
    }
    public static bool IsValidTarget(CombatSlotMonster slot, TargetType targetType, bool isPlayerTurn)
    {
        // Kiểm tra xem quái vật thuộc phe nào đối với người đang đi lượt
        bool isAlly = slot.IsPlayerMonster; // (Giả sử bạn có biến bool này trong Slot để phân biệt phe)
        bool isDead = slot.Stats.CurrentHP <= 0;

        switch (targetType)
        {
            case TargetType.Enemy:
            case TargetType.AllEnemies:
                // Mục tiêu phải là kẻ địch (không cùng phe với người đi lượt) và phải CÒN SỐNG
                return !isAlly && !isDead;

            case TargetType.Ally:
            case TargetType.AllAllies:
                // Mục tiêu phải là đồng đội (cùng phe) và phải CÒN SỐNG
                return isAlly && !isDead;
            default:
                return false;
        }
    }
    // public static async Task WaitForHitFrame(ICombatMonster slot, string animator)
    // {
    //     var tcs = new TaskCompletionSource<bool>();
    //     void OnHit(bool value)
    //     {
    //         tcs?.TrySetResult(value);
    //     }
    //     slot.IsAnimationDone += OnHit;
    //     try
    //     {
    //         slot.ActiveAnimator(animator);
    //         await tcs.Task;
    //     }
    //     finally
    //     {
    //         slot.IsAnimationDone -= OnHit;
    //     }
    // }
}