using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "New Database Item", menuName = "Inventory/DatabaseInventory")]
public class DatabaseItem : ScriptableObject
{
    public List<DataItem> allItems;
    private Dictionary<string, DataItem> _lookup;
    public void BuildLookup()
    {
        _lookup = allItems.ToDictionary(i => i.ID, i => i);
    }
    public DataItem GetById(string id)
    {
        return _lookup.TryGetValue(id, out var item) ? item : null;
    }
}
