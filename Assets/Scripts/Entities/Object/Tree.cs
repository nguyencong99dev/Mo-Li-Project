using Unity.VisualScripting;
using UnityEngine;

public class Tree : Interactable
{
    public GameObject itemPrefab;
    [SerializeField] GameObject tree;
    private int CurrentHealth = 3;

    public override void Interact()
    {
        // if (playerController.CurrentItem == ItemType.Axe)
        // {
        //     CurrentHealth--;
        //     if (CurrentHealth == 0)
        //     {
        //         Instantiate(itemPrefab, transform.position, Quaternion.identity);
        //         Destroy(gameObject);
        //     }
        // }
    }
}
