using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerCombat _combat;
    [SerializeField] private PlayerPhysics _physics;
    [SerializeField] private Animator _animator;

    public bool IsAttacking => _combat.IsAttacking;
    public bool CanDash => _physics.CanDash;
    public Vector2 Velocity => _physics.Velocity;

    public void Attack()
    {
        _combat.Attack(_animator);
        _physics.ResetVelocityX(); // test
    }

    public void Move(float direction)
    {
        _physics.Move(direction);
    }

    public void Dash()
    {
        _physics.Dash();
    }

    public void ResetVelocity()
    {
        _physics.ResetVelocity();
    }

    public void Jump()
    {
        _physics.Jump();
    }

    public bool CheckOnGround()
    {
        return _physics.CheckOnGround();
    }

    public void PlayAnimation(string animationName)
    {
        _animator.Play(animationName);
    }

    public void StopAnimatorPlayback()
    {
        _animator.StopPlayback();
    }
}
