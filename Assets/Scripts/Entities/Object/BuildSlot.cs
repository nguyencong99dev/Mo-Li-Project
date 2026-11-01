using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildSlot : MonoBehaviour
{
    [SerializeField] private GameObject slotItemPrefab;
    [SerializeField] private int numberSlotItem;
    public Transform slotContainer;
    public void BuildSlots()
    {
        for (int i = 0; i < numberSlotItem; i++)
        {
            GameObject slotObject = Instantiate(slotItemPrefab, slotContainer);
            if (slotObject.TryGetComponent<Button>(out var button))
            {
                button.onClick.AddListener(() => SelectSlot());
            }
        }
    }
    public void InitItemData(List<ItemData> data)
    {
        for (int i = 0; i < slotContainer.childCount; i++)
        {
            if (!slotContainer.GetChild(i).TryGetComponent<ItemSlot>(out var slotUI)) continue;
            if (i < data.Count)
            {
                slotUI.SetItem(data[i]);
            }
            else
            {
                slotUI.SetItem(null);
            }
        }
    }
    public void InitMonsterData(List<MonsterData> data)
    {
        for (int i = 0; i < slotContainer.childCount; i++)
        {
            if (!slotContainer.GetChild(i).TryGetComponent<MonsterSlot>(out var monstreUI)) continue;
            if (i < data.Count)
            {
                monstreUI.SetMemberData(data[i]);
            }
            else
            {
                monstreUI.SetMemberData(null);
            }
        }
    }
    private void SelectSlot()
    {

    }
}
