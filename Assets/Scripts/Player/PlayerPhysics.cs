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
    [SerializeField] private LayerMask _obstacleMask;
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
        return Physics2D.OverlapCircle(_legs.position, _legsRadius, _obstacleMask);
    }

    public void Move(float direction)
    {
        if (direction > 0)
            _rigidbody.transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        else if (direction < 0)
            _rigidbody.transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);

        _rigidbody.velocity = new Vector2(direction * _speed, _rigidbody.velocity.y);
    }

    public void Dash(Animator animator)
    {
        StartCoroutine(Dashing(animator));
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

    private IEnumerator Dashing(Animator animator)
    {
        float delay = 0.01f;

        yield return new WaitForSeconds(delay);

        float animationTime = animator.GetCurrentAnimatorStateInfo(0).length;
        print(animationTime);

        _rigidbody.AddForce(Vector2.right * transform.localScale.x * _dashPower, ForceMode2D.Impulse);
        CanDash = false;

        yield return new WaitForSeconds(animationTime);

        _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);

        yield return new WaitForSeconds(_dashCooldown);

        CanDash = true;
    }
}
