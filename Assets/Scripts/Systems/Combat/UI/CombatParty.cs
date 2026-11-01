using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.UI;
public class CombatParty : MonoBehaviour
{
    [SerializeField] CombatSlotMonster CombatMonsterSlot;
    [SerializeField] CombatMonsterStat MonsterStat;
    [SerializeField] CombatEffectStatus EffectStatus;
    public List<CombatSlotMonster> InitParty(List<MonsterData> party, bool isPlayerParty = false)
    {
        List<CombatSlotMonster> monsterStatsList = new();
        MonsterStats monsterStats = new();
        monsterStats.SetMonsterStats(party[0]);
        CombatMonsterSlot.Setup(monsterStats, isPlayerParty);
        CombatMonsterSlot.OnMonsterClick += HandleMonsterSelection;
        CombatMonsterSlot.OnEffectStatusChange += HandleMonsterEffectStatus;
        MonsterStat.Setup(CombatMonsterSlot.Stats);
        monsterStatsList.Add(CombatMonsterSlot);
        return monsterStatsList;
    }
    public void HandleMonsterSelection(CombatSlotMonster targetMonster)
    {
        if (targetMonster.IsSelected == false)
        {
            EventBus<SBattleContext>.Publish(new SBattleContext
            {
                Target = targetMonster,
            });
            targetMonster.IsSelected = true;
            return;
        }
        else
        {
            EventBus<SBattleContext>.Publish(new SBattleContext
            {
                Confirm = true
            });
        }
    }
    public void HandleMonsterEffectStatus(EffectContext ctx, ActionState action)
    {
        if (action == ActionState.Add)
        {
            EffectStatus.AddEffect(ctx);
        }
        else EffectStatus.RemoveEffect(ctx);
    }
}