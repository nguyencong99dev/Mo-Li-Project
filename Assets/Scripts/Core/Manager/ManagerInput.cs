using System;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.InputSystem;

public class ManagerInput : MonoBehaviour
{
    public static ManagerInput Instance { get; private set; }
    private PlayerInput _inputAction;
    InputAction _moveAction;
    InputAction _interactAction;
    public event Action<Vector2> OnMovement;
    public event Action OnInteration;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        Debug.Log("Manager Input Initialized");
        if (!gameObject.TryGetComponent<PlayerInput>(out var pInput)) return;
        _inputAction = pInput;
        _moveAction = _inputAction.actions["Move"];
        _interactAction = _inputAction.actions["Interact"];
    }
    private void OnEnable()
    {
        _moveAction.performed += OnMovePerformed;
        _moveAction.canceled += OnMoveCanceled;
    }
    private void OnDisable()
    {
        _moveAction.performed -= OnMovePerformed;
        _moveAction.canceled -= OnMoveCanceled;
    }
    private void OnMovePerformed(InputAction.CallbackContext ctx) => OnMovement?.Invoke(ctx.ReadValue<Vector2>());
    private void OnMoveCanceled(InputAction.CallbackContext ctx) => OnMovement?.Invoke(Vector2.zero);
    private void OnInterationInput(InputAction.CallbackContext ctx)
    {
        if (ctx.performed) OnInteration?.Invoke();
    }
    public void SwitchActionMap(string action)
    {
        _inputAction.SwitchCurrentActionMap(action);
    }
    public void DisableInput()
    {
        _inputAction.DeactivateInput();
    }
    public void EnableInput()
    {
        _inputAction.ActivateInput();
    }
}
