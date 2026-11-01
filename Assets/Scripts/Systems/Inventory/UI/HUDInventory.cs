using System.Collections.Generic;
using UnityEngine;

public class HUDInventory : MonoBehaviour
{
    [SerializeField] BuildSlot _Inventory;
    [SerializeField] BuildSlot _Toolbar;
    void Awake()
    {
        if (_Toolbar == null) return;
        _Toolbar.BuildSlots();

        if (_Inventory == null) return;
        _Inventory.BuildSlots();
    }
    void OnEnable()
    {
        EventBus<SToolbar>.Subscribe(InitToolbarItems);
        EventBus<SInventory>.Subscribe(InitInventoryItems);
    }
    void OnDisable()
    {
        EventBus<SToolbar>.Unsubscribe(InitToolbarItems);
        EventBus<SInventory>.Unsubscribe(InitInventoryItems);
    }
    void InitToolbarItems(SToolbar toolbar)
    {
        _Toolbar.InitItemData(toolbar.Toolbar);
    }
    void InitInventoryItems(SInventory inventory)
    {
        _Inventory.InitItemData(inventory.Inventory);
    }

}