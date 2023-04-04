using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _jumpPower = 5;

    protected override void OnEnable()
    {
        base.OnEnable();

        Jump();
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
    }
}
