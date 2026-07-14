using UnityEngine;
using UnityEngine.UI;
using System;

public class SlotItem : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private bool isSelected;
    public DataItem Item { get; private set; }
    public void SetItem(DataItem item)
    {
        Item = item;

        if (iconImage != null)
        {
            iconImage.sprite = item != null ? item.Image : null;
        }
    }
}
