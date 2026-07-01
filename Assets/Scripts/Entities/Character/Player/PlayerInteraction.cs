using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Detection")]
    [SerializeField] private LayerMask interacableLayer;
    public event Action<Transform> OnInteracableEntered;
    public event Action<Transform> OnInteracableExited;
    public event Action OnInteractObject;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!GameObjectHelper.IsInLayerMask(collision.gameObject.layer, interacableLayer)) return;
        OnInteracableEntered?.Invoke(collision.transform);
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (!GameObjectHelper.IsInLayerMask(collision.gameObject.layer, interacableLayer)) return;
        OnInteracableExited?.Invoke(collision.transform);
    }
    public void OnInteracted()
    {
        OnInteractObject?.Invoke();
    }
}