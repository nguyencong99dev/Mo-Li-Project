using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildSlotInventoryItems : MonoBehaviour
{
    [SerializeField] private Transform slotContainer;
    [SerializeField] private GameObject slotItemPrefab;
    [SerializeField] private int numberSlotItem;
    public void BuildSlots()
    {
        ClearSlots();

        for (int i = 0; i < numberSlotItem; i++)
        {
            int slotIndex = i;
            GameObject slotObject = Instantiate(slotItemPrefab, slotContainer);
            Button button = slotObject.GetComponent<Button>();

            if (button != null)
            {
                button.onClick.AddListener(() => SelectSlot(slotIndex));
            }
        }
    }

    public void InitItem(List<string> list)
    {
        if (slotContainer == null || ManagerAssets.Instance == null || ManagerAssets.Instance.Item == null)
        {
            return;
        }

        for (int i = 0; i < slotContainer.childCount; i++)
        {
            SlotItem slotUI = slotContainer.GetChild(i).GetComponent<SlotItem>();

            if (slotUI == null)
            {
                continue;
            }

            if (i < list.Count)
            {
                DataItem itemData = ManagerAssets.Instance.Item.GetById(list[i]);
                slotUI.SetItem(itemData);
            }
            else
            {
                slotUI.SetItem(null);
            }
        }
    }

    private void ClearSlots()
    {
        if (slotContainer == null)
        {
            return;
        }

        for (int i = slotContainer.childCount - 1; i >= 0; i--)
        {
            Destroy(slotContainer.GetChild(i).gameObject);
        }
    }

    private void SelectSlot(int idx)
    {
        Debug.Log($"Selected slot index: {idx}");
    }
}
