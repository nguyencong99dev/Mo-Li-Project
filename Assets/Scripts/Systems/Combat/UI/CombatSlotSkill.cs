using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatSlotSkill : MonoBehaviour
{
    [SerializeField] Image SkillIcon;
    [SerializeField] Button SkillBtn;
    public event Action<CombatSlotSkill> OnCombatSkillChanged;
    public SOSkill SkillData { get; private set; }
    public void SetSkillValue(SOSkill skillId)
    {

        if (skillId == null) return;
        SkillIcon.sprite = skillId.Image;
        SkillData = skillId;
        if (SkillBtn != null)
        {
            SkillBtn.onClick.RemoveAllListeners();
            SkillBtn.onClick.AddListener(
                () => OnCombatSkillChanged?.Invoke(this)
            );
        }
    }
}
