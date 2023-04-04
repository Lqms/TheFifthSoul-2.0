using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _jumpPower = 5;
    [SerializeField] private float _speed = 5;

    protected override void OnEnable()
    {
        base.OnEnable();

        Jump();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Move(horizontalInput);
    }

    private void Move(float direction)
    {
        if (direction > 0)
            transform.parent.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        else if (direction < 0)
            transform.parent.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);

        _rigidbody.velocity = new Vector2(direction * _speed, _rigidbody.velocity.y);
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
    }
}
