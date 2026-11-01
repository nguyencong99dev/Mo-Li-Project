using System;
using System.Collections.Generic;
using UnityEngine;


public abstract class SOItem : ScriptableObject
{
    public string itemId;
    public string itemName;
    [TextArea] public string description;
    public Sprite image;
    public ItemType type;
    public int maxStack = 64;
    public bool isUnique;      // true = chỉ sở hữu 1 món duy nhất (Tool, Key Item quan trọng)
    public bool isDiscardable;
    public bool isSellable;
    public int buyPrice;
    public int sellPrice;
    public bool isTradeable;
    public UsageContext usableIn;   // enum flag: Battle, Overworld, Both
    public TargetType targetType;   // Self, SingleAlly, AllAllies, SingleEnemy...
}
