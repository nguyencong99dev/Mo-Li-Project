using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private Animator anim;

    public bool isActice = false;
    [SerializeField] protected PlayerController playerController;
    public static event Action OnIntaract;
    private void OnEnable()
    {
        // playerController.playerInteraction.OnInteractObject += Interact;
    }

    private void OnDisable()
    {
        // playerController.playerInteraction.OnInteractObject += Interact;
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // public virtual void OnPlayerEntered(Transform other)
    // {
        

    // }
    // public virtual void OnPlayerExited(Transform other)
    // {


    // }
    public virtual void Interact()
    {


    }
    protected Animator GetAnimation()
    {
        return anim;
    }
}
