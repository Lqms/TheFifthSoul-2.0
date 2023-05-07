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
    [SerializeField] private float _attackRange = 1;
    [SerializeField] private float _detectionRange = 5;
    [SerializeField] private float _movementSpeed = 1;
    [SerializeField] private Transform _eyes;

    public Player Player => _player;
    public float MovementSpeed => _movementSpeed;
    public float AttackRange => _attackRange;
    public float LastPlayerPositionX { get; private set; }
    public bool IsPlayerSeen { get; private set; } 

    private void Start()
    {
        LastPlayerPositionX = _player.transform.position.x;
    }

    private void Update()
    {
        if (IsPlayerSeen = IsPlayerInViewRange())
        {
            LastPlayerPositionX = _player.transform.position.x;
        }
    }

    private bool IsPlayerInViewRange()
    {
        Ray2D ray = new Ray2D(_eyes.position, transform.right);
        var hit = Physics2D.Raycast(ray.origin, ray.direction, _detectionRange, _playerMask);
        Debug.DrawRay(ray.origin, ray.direction * _detectionRange, Color.red);

        return (hit != default);
    }
}
