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

    [SerializeField] private Transform _fallingPoint;

    public Player Player => _player;
    public float MovementSpeed => _movementSpeed;
    public float AttackRange => _attackRange;
    public float LastPlayerPositionX { get; private set; }
    public bool IsPlayerSeen { get; private set; }
    public bool IsPlayerUnreachable { get; private set; }

    private void Start()
    {
        LastPlayerPositionX = transform.position.x;
    }

    private void Update()
    {
        print(CheckGroundUnderFallingPoint());

        if (IsPlayerSeen = IsPlayerInViewRange() && CheckGroundUnderFallingPoint())
        {
            LastPlayerPositionX = _player.transform.position.x;
        }
    }

    private bool CheckGroundUnderFallingPoint()
    {
        return Physics2D.Raycast(_fallingPoint.position, Vector2.down, 1, _obstacleMask);
    }

    private bool IsPlayerInViewRange()
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
