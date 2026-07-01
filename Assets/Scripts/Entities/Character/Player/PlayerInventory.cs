using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{    
    [SerializeField] private List<string> _Inventory;
    public event Action<List<string>> OnInventoryChanged;

    public void AddItem(DataItem item)
    {
        if (item != null)
        {
            _Inventory.Add(item.Id);
            OnInventoryChanged?.Invoke(_Inventory);
        }
    }
    public void RemoveItem(DataItem item)
    {
        
    }
    public List<string> GetInventoryItems()
    {
        return _Inventory;
    }
    public void SetInventory(List<string> inventoryId)
    {
        if (inventoryId == null) return;
        _Inventory = inventoryId;
    }
}
