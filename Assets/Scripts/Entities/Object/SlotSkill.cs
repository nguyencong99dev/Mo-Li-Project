
using UnityEngine;
using UnityEngine.UI;

public class SlotSkill : MonoBehaviour
{
    [SerializeField] Image _skillIcon;

    public DataSkill SetSkillValue(string skillId)
    {
        DataSkill _skill = ManagerAssets.Instance.SkillDB.GetByID(skillId);
        if (_skillIcon != null)
        {
            _skillIcon.sprite = _skill.Image;
        }
        return _skill;
    }
}
