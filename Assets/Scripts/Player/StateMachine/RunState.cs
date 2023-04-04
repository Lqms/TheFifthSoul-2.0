using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : State
{
    [SerializeField] private float _speed = 5;

    public override void Enter()
    {
        base.Enter();

        PlayerInput.MoveKeyPressing += OnMoveKeyPressing;
    }

    public override void Exit()
    {
        base.Exit();

        PlayerInput.MoveKeyPressing -= OnMoveKeyPressing;
    }

    private void OnMoveKeyPressing(Vector2 direction)
    {
        Rigidbody.velocity = new Vector2(direction.x * _speed, Rigidbody.velocity.y);
    }
}
