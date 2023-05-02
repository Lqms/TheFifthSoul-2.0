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
    public float ViewRange => _agroRange;
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
}
