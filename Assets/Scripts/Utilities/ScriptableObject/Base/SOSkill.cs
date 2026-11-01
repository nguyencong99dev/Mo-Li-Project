using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
[CreateAssetMenu(fileName = "New Attack Skill", menuName = "Character/Skill")]
public class SOSkill : ScriptableObject
{
    public string ID;
    public string Name;
    public Sprite Image;
    public float mpCost;
    public SkillType skillType;
    public TargetType targetType;
    public AnimationClip AnimationClip;
    [SerializeReference] public List<EffectContext> _effects;
    [ContextMenu("Add Attack Payload")]
    public void AddAttackPayload()
    {
        _effects.Add(new EffectContext { payload = new DamagePayload() });
    }
    [ContextMenu("Add Restore Payload")]
    public void AddRestorePayload()
    {
        _effects.Add(new EffectContext { payload = new RestorePayload() });
    }
    [ContextMenu("Add Bleeding Payload")]
    public void AddDpsPayload()
    {
        _effects.Add(new EffectContext { payload = new DPTPayload() });
    }
}

