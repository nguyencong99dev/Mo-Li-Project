using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "New Monster", menuName = "Character/Monster")]
public class SOMonster : ScriptableObject
{
    public string ID;
    public string Name;
    public Sprite FrontImage;
    public Sprite BackImage;
    public int HPPerLV;
    public int MPPerLV;
    public int SpeedPerLV;
    public List<SOSkill> Skills = new();
    public AnimatorOverrideController AnimatorOverrideRef;
}
