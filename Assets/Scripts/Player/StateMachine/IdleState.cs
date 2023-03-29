using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private void OnEnable()
    {
        PlayerInput.MoveKeyPressing += OnMoveKeyPressing;
    }

    private void OnDisable()
    {
        PlayerInput.MoveKeyPressing -= OnMoveKeyPressing;
    }

    private void OnMoveKeyPressing(Vector2 direction)
    {
        var rb = GetComponent<Rigidbody2D>()
        rb.velocity = new Vector2(direction.x, rb.velocity.y);
    }
}
