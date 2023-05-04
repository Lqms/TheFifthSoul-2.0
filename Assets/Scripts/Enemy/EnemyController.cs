using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private StateMachine _stateMachine;
    [SerializeField] private Animator _animator;

    [SerializeField] private float _attackRange = 1;
    [SerializeField] private float _detectionRange = 5;
    [SerializeField] private float _movementSpeed = 1;

    public Player Player => _player;
    public float MovementSpeed => _movementSpeed;
    public bool IsPlayerInDetectionRange { get; private set; }
    public bool IsPlayerInAttackRange { get; private set; }

    private void Update()
    {
        if (Vector2.Distance(_player.transform.position, transform.position) < _attackRange)
        {
            IsPlayerInAttackRange = true;
        }
        else
        {
            IsPlayerInAttackRange = false;
        }

        if (Vector2.Distance(_player.transform.position, transform.position) < _detectionRange)
        {
            IsPlayerInDetectionRange = true;
        }
        else
        {
            IsPlayerInDetectionRange = false;
        }
    }
}
