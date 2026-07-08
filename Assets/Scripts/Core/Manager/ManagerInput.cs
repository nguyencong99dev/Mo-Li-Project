using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ManagerInput : MonoBehaviour
{
    public static ManagerInput Instance { get; private set; }
    public event Action<Vector2> OnMovement;
    public event Action OnInteration;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            return;
        }
        Debug.Log("Manager Input Initialized");
    }
    public void OnMoveInput(InputAction.CallbackContext ctx)
    {
        OnMovement?.Invoke(ctx.ReadValue<Vector2>());
    }
    public void OnInterationInput(InputAction.CallbackContext ctx)
    {
        if (ctx.performed) OnInteration?.Invoke();
    }

}
