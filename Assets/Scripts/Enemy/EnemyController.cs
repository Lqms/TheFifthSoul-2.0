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
    public bool IsPlayerReachable { get; private set; }
    public Vector3 StartingPoint { get; private set; }

    private void Start()
    {
        LastPlayerPositionX = transform.position.x;
        StartingPoint = transform.position;
    }

    private void Update()
    {
        print(CheckGroundUnderFallingPoint());

        if (IsPlayerInViewRange() && CheckGroundUnderFallingPoint())
        {
            LastPlayerPositionX = _player.transform.position.x;
        }
    }

    private bool CheckGroundUnderFallingPoint()
    {
        float x = LastPlayerPositionX > transform.position.x ? 0.7f : -0.7f;
        IsPlayerReachable = Physics2D.Raycast(transform.position + new Vector3(x, -0.7f), Vector2.down, 1, _obstacleMask);

        return IsPlayerReachable;
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
                IsPlayerSeen = true;
                return true;
            }
        }

        IsPlayerSeen = false;
        return false;
    }
}
