using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "New Database Item", menuName = "Inventory/DatabaseInventory")]
public class DatabaseItem : ScriptableObject
{
    public List<SOItem> allItems;
    private Dictionary<string, SOItem> _lookup;
    public void BuildLookup()
    {
        _lookup = allItems.ToDictionary(i => i.itemId, i => i);
    }
    public SOItem GetById(string id)
    {
        return _lookup.TryGetValue(id, out var item) ? item : null;
    }
    // public List<SOItem> GetSOItems(List<ItemData> data)
    // {   var _data  = data.OrderBy(i => i.ItemId);
    //     var result = allItems.OrderBy(i => i.itemId);
    //     result.
    //     return result;
    // }
}
