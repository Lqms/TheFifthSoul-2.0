using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private StateMachine _stateMachine;
    [SerializeField] private Animator _animator;

    [SerializeField] private LayerMask _playerMask;
    [SerializeField] private LayerMask _obstacleMask;
    [SerializeField] private float _attackRange = 1;
    [SerializeField] private float _detectionRange = 5;
    [SerializeField] private float _movementSpeed = 1;
    [SerializeField] private Transform _rayPoint;

    public Player Player => _player;
    public float MovementSpeed => _movementSpeed;
    public float AttackRange => _attackRange;
    public float LastPlayerPositionX { get; private set; }
    public bool IsPlayerSeen { get; private set; }

    private void Start()
    {
        LastPlayerPositionX = transform.position.x;
    }

    private void Update()
    {
        if (IsPlayerSeen = IsPlayerInViewRange2())
        {
            LastPlayerPositionX = _player.transform.position.x;
        }
    }

    private bool IsPlayerInViewRange()
    {
        Ray2D ray = new Ray2D(_rayPoint.position, transform.right);
        var hit = Physics2D.Raycast(ray.origin, ray.direction, _detectionRange, _playerMask);
        Debug.DrawRay(ray.origin, ray.direction * _detectionRange, Color.red);

        return (hit != default);
    }

    private bool IsPlayerInViewRange2()
    {
        var targetsInViewRadius = Physics2D.OverlapCircleAll(_rayPoint.position, _detectionRange, _playerMask);

        foreach (var target in targetsInViewRadius)
        {
            Vector3 directionToTarget = (target.transform.position - transform.position).normalized;
            float distanceToTarget = Vector2.Distance(transform.position, target.transform.position);

            if (Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, _obstacleMask) == false)
            {
                return true;
            }
        }

        return false;
    }
}
