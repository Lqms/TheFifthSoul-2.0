using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private StateMachine _stateMachine;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _agroRange = 5;
    [SerializeField] private float _attackRange = 1;
    [SerializeField] private float _movementSpeed = 1;

    public Player Player => _player;
    public float AttackRange => _attackRange;
    public float AgroRange => _agroRange;
    public float MovementSpeed => _movementSpeed;   

    private void OnEnable()
    {
        _player.Died += OnPlayerDied;
    }

    private void OnDisable()
    {
        _player.Died -= OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        _stateMachine.gameObject.SetActive(false);
        _animator.Play(AnimationNames.Idle.ToString());
    }

    private void Update()
    {
        if (CheckAttackingPossibility())
            print("can attack");
    }

    private bool CheckAttackingPossibility()
    {
        Ray2D ray = new Ray2D(transform.position, transform.right);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 2);
        Debug.DrawRay(ray.origin, ray.direction * 2, Color.red);

        return (hit.collider != null && hit.collider.TryGetComponent(out Player player));
    }
}
