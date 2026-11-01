using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rigidbody2d;
    [SerializeField] PlayerAnimation _playerAnimation;
    private Vector2 _movement;
    void OnEnable()
    {
        ManagerInput.Instance.OnMovement += HandleMovement;
    }
    void OnDisable()
    {
        ManagerInput.Instance.OnMovement -= HandleMovement;
    }
    void Update()
    {

    }
    void FixedUpdate()
    {
        rigidbody2d.linearVelocity = _movement * speed;
        _playerAnimation.SetMovement(_movement);
        if (_movement != Vector2.zero)
        {
            _playerAnimation.SetFacingDirection(_movement);
        }
    }
    public void HandleMovement(Vector2 Movement) => _movement = Movement;
}
