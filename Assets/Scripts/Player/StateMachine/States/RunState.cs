using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : State
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed = 5;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Move(horizontalInput);      
    }

    private void Move(float direction)
    {
        _rigidbody.velocity = new Vector2(direction * _speed, _rigidbody.velocity.y);
    }
}
