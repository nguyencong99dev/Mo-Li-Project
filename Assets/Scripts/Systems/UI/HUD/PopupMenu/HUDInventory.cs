using UnityEngine;

public class HUDInventory : MonoBehaviour
{
    [SerializeField] private BuildSlotToolbarItems UIToolbar;
    [SerializeField] private BuildSlotInventoryItems UIInventory;

    public void InitToolbarItem(SPlayerToolbar data)
    {
        if (UIToolbar == null) return;
        UIToolbar.BuildSlots();
        UIToolbar.InitItem(data.Toolbar);
    }
    public void InitInventoryItem(SPlayerInventory data)
    {
        if (UIInventory == null) return;
        UIInventory.BuildSlots();
        UIInventory.InitItem(data.Inventory);
    }

}