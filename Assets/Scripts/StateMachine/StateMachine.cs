using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State _startState;

    private Animator _animator;
    private State _currentState;

    public State CurrentState => _currentState;

    private void Start()
    {
        _currentState = _startState;
        _animator = GetComponentInParent<Animator>();

        if (_currentState != null)
            _currentState.Enter(_animator);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        var nextState = _currentState.TryGetNextState();

        if (nextState != null)
            Transit(nextState);

    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)
            _currentState.Enter(_animator);
    }
}
