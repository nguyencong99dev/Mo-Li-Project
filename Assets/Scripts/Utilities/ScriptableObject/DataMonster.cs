using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Monster", menuName = "Character/Monster")]
public class DataMonster : ScriptableObject
{
    public string ID;
    public string Name;
    public Sprite FrontImage;
    public Sprite BackImage;
    public int HPPerLV;
    public int MPPerLV;
    public int SpeedPerLV;
    public List<string> Skills = new();
}
