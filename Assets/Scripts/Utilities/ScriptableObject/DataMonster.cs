using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Monster", menuName = "Character/Monster")]
public class DataMonster : ScriptableObject
{
    public string ID;
    public string Name;
    public Sprite Image;
    public int HPPerLV;
    public int MPPerLV;
    public List<string> Skills = new();
}
