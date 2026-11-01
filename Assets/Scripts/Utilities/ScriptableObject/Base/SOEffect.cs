using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "New Effect", menuName = "Game/Effect")]
public class SOEffect : ScriptableObject
{
    public string EffectId;
    public string EffectName;
    public EffectType type;
    public Sprite Image;
    [TextArea] public string description;
    public AnimationClip AnimationClip;
}

