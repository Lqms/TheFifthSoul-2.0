using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState : State
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed = 5;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _legs;
    [SerializeField] private float _legsRadius = 0.2f;

    private void Update()
    {
        if (OnGround() == false)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            Move(horizontalInput);
        }
        else
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }

    private void Move(float direction)
    {
        _rigidbody.velocity = new Vector2(direction * _speed, _rigidbody.velocity.y);
    }

    private bool OnGround()
    {
        return Physics2D.OverlapCircle(_legs.position, _legsRadius, _groundMask);
    }
}
