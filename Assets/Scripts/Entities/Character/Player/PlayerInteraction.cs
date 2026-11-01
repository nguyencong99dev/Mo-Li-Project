using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Detection")]
    [SerializeField] private LayerMask interacableLayer;
    [SerializeField] private LayerMask encounterLayer;
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (GameObjectHelper.IsInLayerMask(collision.gameObject.layer, interacableLayer))
        {

        }
        else if (GameObjectHelper.IsInLayerMask(collision.gameObject.layer, encounterLayer))
        {
            List<MonsterData> enemyParty = collision.gameObject.GetComponentInParent<EnemyController>()._EnemyPartyData;
            EventBus<SEncounterMonster>.Publish(new SEncounterMonster
            {
                Party = enemyParty,
                IsEncounter = true
            });
            StartCoroutine(ManagerScene.Instance.LoadScene("Combat"));
        }
        ;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (!GameObjectHelper.IsInLayerMask(collision.gameObject.layer, interacableLayer)) return;

    }
}