using UnityEngine;
using UnityEngine.UI;
using System;

public class UISlotItem : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private bool isSelected;

    public DataItem Item { get; private set; }
    public static event Action<DataItem> ItemSelected;

    public void SetItem(DataItem item)
    {
        Item = item;

        if (iconImage != null)
        {
            iconImage.sprite = item != null ? item.Image : null;
        }
    }

    public void SetSelected(bool selected)
    {
        isSelected = selected;
    }
}
