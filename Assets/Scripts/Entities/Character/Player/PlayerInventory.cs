using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public struct SPlayerInventory
{
    public List<string> Inventory;
}
public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<string> _Inventory;
    void Start()
    {
        EventBus<SPlayerInventory>.Publish(new SPlayerInventory { Inventory = _Inventory });
    }
    public void AddItem(DataItem item)
    {
        if (item != null)
        {
            _Inventory.Add(item.ID);
            EventBus<SPlayerInventory>.Publish(new SPlayerInventory { Inventory = _Inventory });
        }
    }
    public void RemoveItem(DataItem item)
    {

    }
    public void SetInventory(List<string> inventoryId)
    {
        if (inventoryId == null) return;
        _Inventory = inventoryId;
    }
}
