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
        _currentState.Enter();
    }

    private void ChangeState(State state)
    {
        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }
}
