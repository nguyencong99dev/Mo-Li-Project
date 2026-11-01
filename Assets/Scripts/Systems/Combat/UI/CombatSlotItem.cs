using System;
using TMPro;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.UI;
public class CombatSlotItem : MonoBehaviour
{
    [SerializeField] Image iconSelected;
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI itemQty;
    [SerializeField] Button button;
    public ItemData ItemData {get; private set;}
    public SOItem   Item {get; private set;}
    public event Action<CombatSlotItem> OnCombatItemChanged;
    public void SetValueData(ItemData _item, SOItem _itemdata)
    {
        ItemData = _item;
        Item = _itemdata;
        itemName.text = Item.itemName;
        itemQty.text = ItemData.qty.ToString();
        iconSelected.gameObject.SetActive(false);
        button.onClick.AddListener(() => OnCombatItemChanged?.Invoke(this));
    }
    public void SetSelected(bool value) => iconSelected.gameObject.SetActive(value);

}