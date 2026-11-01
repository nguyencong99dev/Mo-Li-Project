
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour
{
    [SerializeField] Image _skillIcon;

    public SOSkill SetSkillValue(string skillId)
    {
        SOSkill _skill = ManagerAssets.Instance.SkillDB.GetByID(skillId);
        if (_skillIcon != null)
        {
            _skillIcon.sprite = _skill.Image;
        }
        return _skill;
    }
}
