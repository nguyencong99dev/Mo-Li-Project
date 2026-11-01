using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.EventSystems;
using System.Collections.Generic;
public enum SlotType
{
    Inventory, Toolbar
}
public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private bool isSelected;
    [SerializeField] private TextMeshProUGUI quantity;

    public void SetItem(ItemData item)
    {
        if (item == null) return;
        SOItem _item = ManagerAssets.Instance.ItemDB.GetById(item.ItemId);
        if (iconImage != null)
        {
            iconImage.sprite = item != null ? _item.image : null;
        }
        if (quantity != null)
        {
            quantity.text = $"{item.qty}";
            if (item.qty == 1) quantity.gameObject.SetActive(false);
        }
    }
    // public bool CanAcceptDrop(SOItem item)
    // {
    //     // Có thể thêm logic kiểm tra loại item
    //     // ví dụ: Toolbar chỉ nhận Quick Item
    //     return item != null;
    // }

    // public void OnItemDropped(SOItem item)
    // {
    //     // Swap item nếu slot đang có item
    //     SOItem currentItem = Item;

    //     // Cập nhật UI
    //     SetItem(item,0);

    //     // Publish event để PlayerData cập nhật data thật
    //     // EventBus<ItemSlotSwappedEvent>.Publish(new ItemSlotSwappedEvent
    //     // {
    //     //     fromItem = DragDropManager.Instance.DraggingItem,
    //     //     toItem   = currentItem,
    //     //     toSlot   = slotType
    //     // });
    // }

    // public void OnBeginDrag(PointerEventData eventData)
    // {
    //     ManagerDragDrop.Instance.BeginDrag(this);
    // }

    // // IDragHandler - đang kéo (bắt buộc implement nhưng logic ở Manager)
    // public void OnDrag(PointerEventData eventData)
    // {
    //     // PointerEventData đã có sẵn position - không cần Input class
    //     // if (ManagerDragDrop.Instance._ghostInstance != null)
    //     //     ManagerDragDrop.Instance._ghostInstance.transform.position
    //     //         = eventData.position;
    // }

    // // IEndDragHandler - thả ra
    // public void OnEndDrag(PointerEventData eventData)
    // {
    //     // Tìm DropTarget tại vị trí thả
    //     var results = new List<RaycastResult>();
    //     EventSystem.current.RaycastAll(eventData, results);

    //     IDropTarget target = null;
    //     foreach (var result in results)
    //     {
    //         target = result.gameObject.GetComponent<IDropTarget>();
    //         if (target != null) break;
    //     }

    //     ManagerDragDrop.Instance.EndDrag(target);
    // }
    // public void OnBeginDrag()
    // {
    //     // Ẩn icon gốc khi đang kéo (ghost item sẽ thay thế)
    //     _canvasGroup.alpha = 0.3f;
    //     _canvasGroup.blocksRaycasts = false; // cho phép raycast xuyên qua
    // }

    // public void OnEndDrag()
    // {
    //     // Hiện lại icon gốc
    //     _canvasGroup.alpha = 1f;
    //     _canvasGroup.blocksRaycasts = true;
    // }
}
