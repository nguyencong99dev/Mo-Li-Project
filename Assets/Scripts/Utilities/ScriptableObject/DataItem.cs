using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data Item", menuName = "Inventory/DataItem")]
public class DataItem : ScriptableObject
{
    public string Id;
    public string Name;
    public Sprite Image;
    public string GetItemId()
    {
        return Id;
    }
}
