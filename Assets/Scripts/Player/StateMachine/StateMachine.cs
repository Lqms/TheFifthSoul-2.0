using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State _startState;

    private State _currentState;

    private void Start()
    {
        _currentState = _startState;
        _currentState.enabled = true;
        _currentState.Enter();
        _currentState.TransitionConditionCompleted += OnTransitionConditionCompleted;
    }

    private void TryChangeState(State state)
    {
        if (state == _currentState)
            return;

        _currentState.TransitionConditionCompleted -= OnTransitionConditionCompleted;
        _currentState.Exit();

        _currentState.enabled = false;
        _currentState = state;
        _currentState.enabled = true;

        _currentState.Enter();
        _currentState.TransitionConditionCompleted += OnTransitionConditionCompleted;
    }

    private void OnTransitionConditionCompleted(State state)
    {
        TryChangeState(state);
    }
}
