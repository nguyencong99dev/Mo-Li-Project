using System;
using TMPro;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.UI;
public class CombatInventory : MonoBehaviour
{
    [SerializeField] CombatSlotItem CombatSlotItem;
    [SerializeField] Transform Inventory;
    public void InitInventoryItem(SInventory data)
    {
        foreach (ItemData item in data.Inventory)
        {
            SOItem dataItem = ManagerAssets.Instance.ItemDB.GetById(item.ItemId);
            if (dataItem.type == ItemType.Consumable)
            {
                CombatSlotItem slotCombatItem = Instantiate(CombatSlotItem, Inventory);
                slotCombatItem.OnCombatItemChanged += SetItemSelected;
                slotCombatItem.SetValueData(item, dataItem);
            }
        }
    }
    private void SetItemSelected(CombatSlotItem item)
    {
        EventBus<SBattleContext>.Publish(new SBattleContext
        {
            Action = ActionType.Item,
            Item = item,
        });
    }
}