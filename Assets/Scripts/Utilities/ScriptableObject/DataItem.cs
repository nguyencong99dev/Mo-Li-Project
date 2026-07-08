using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data Item", menuName = "Inventory/DataItem")]
public class DataItem : ScriptableObject
{
    public string ID;
    public string Name;
    public Sprite Image;
}
