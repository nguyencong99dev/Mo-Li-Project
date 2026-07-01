using System;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] public DataItem itemData;
    [SerializeField] private LayerMask playerLayer;
    private PlayerController _player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // _player = collision.GetComponent<PlayerController>();
        // if (!GameObjectHelper.IsInLayerMask(collision.gameObject.layer, playerLayer)) return;
        // _player.playerInventory.AddItem(itemData);
        // Destroy(gameObject);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!GameObjectHelper.IsInLayerMask(collision.gameObject.layer, playerLayer)) return;
        _player = null;
    }
}
