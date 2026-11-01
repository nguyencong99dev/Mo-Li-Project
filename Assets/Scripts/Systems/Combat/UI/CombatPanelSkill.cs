using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.UI;
public class CombatPanelSkill : MonoBehaviour
{
    [SerializeField] CombatSlotSkill CombatSlotSkill;
    [SerializeField] Transform SkillPanel;
    public void InitSkill(List<SOSkill> _skills, bool isPlayerTurn = false)
    {
        foreach (Transform child in SkillPanel)
        {
            Destroy(child.gameObject);
        }
        if (isPlayerTurn == false) return;
        foreach (SOSkill skill in _skills)
        {
            CombatSlotSkill slotCombatSkill = Instantiate(CombatSlotSkill, SkillPanel);
            slotCombatSkill.OnCombatSkillChanged += HandleSkillSelection;
            slotCombatSkill.SetSkillValue(skill);
        }
    }
    private void HandleSkillSelection(CombatSlotSkill skill)
    {
        EventBus<SBattleContext>.Publish(new SBattleContext
        {
            Action = ActionType.Skill,
            Skill = skill.SkillData,
        });
    }
}