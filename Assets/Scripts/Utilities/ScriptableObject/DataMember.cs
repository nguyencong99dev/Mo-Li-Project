using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Member", menuName = "Character/Member")]
public class DataMember : ScriptableObject
{
    public string Id;
    public string Name;
    public Sprite Image;
    public int Level;
    public int MaxHP => 50 * Level;
    // public List<DataItem> MemberEquip;
}
