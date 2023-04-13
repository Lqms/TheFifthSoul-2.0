using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerPhysics : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D _rigidbody;

    [Header("Jump")]
    [SerializeField] private float _jumpPower = 10;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _legs;
    [SerializeField] private float _legsRadius = 0.2f;

    [Header("Movement")]
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _dashPower = 10;
    [SerializeField] private float _dashCooldown = 3;

    public Vector2 Velocity => _rigidbody.velocity;
    public bool CanDash { get; private set; } = true;

    public bool CheckOnGround()
    {
        return Physics2D.OverlapCircle(_legs.position, _legsRadius, _groundMask);
    }

    public void Move(float direction)
    {
        if (direction > 0)
            _rigidbody.transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        else if (direction < 0)
            _rigidbody.transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);

        _rigidbody.velocity = new Vector2(direction * _speed, _rigidbody.velocity.y);
    }

    public void Dash()
    {
        StartCoroutine(Dashing());
    }

    public void ResetVelocity()
    {
        _rigidbody.velocity = Vector2.zero;
    }

    public void ResetVelocityX()
    {
        _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
    }

    public void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
    }

    private IEnumerator Dashing()
    {
        _rigidbody.AddForce(Vector2.right * transform.localScale.x * _dashPower, ForceMode2D.Impulse);
        CanDash = false;

        yield return new WaitForSeconds(0.1f);

        _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);

        yield return new WaitForSeconds(_dashCooldown);

        CanDash = true;
    }
}
