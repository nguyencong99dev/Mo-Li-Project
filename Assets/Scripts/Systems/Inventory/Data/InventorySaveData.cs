using System;
using System.Collections.Generic;

[Serializable]
public class ItemData
{
    public string ItemId;
    public int qty = 0;
}

[Serializable]
public class InventorySaveData
{
    public List<ItemData> Inventory = new();
    public List<ItemData> Toolbar = new();
}

