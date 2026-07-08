using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Detection")]
    [SerializeField] private LayerMask interacableLayer;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!GameObjectHelper.IsInLayerMask(collision.gameObject.layer, interacableLayer)) return;
        Debug.Log("Player Interaction Triggered"); 
        StartCoroutine(ManagerScene.Instance.LoadScene("Combat"));  
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (!GameObjectHelper.IsInLayerMask(collision.gameObject.layer, interacableLayer)) return;

    }
}