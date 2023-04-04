using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum AnimationNames
{
    Idle,
    Run
}


public class State : MonoBehaviour
{
    [SerializeField] private Transition[] _transitions;
    [SerializeField] private AnimationNames _animationName;

    protected Rigidbody2D Rigidbody;

    private Animator _animator;

    public event UnityAction<State> TransitionConditionCompleted;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    public virtual void Enter()
    {
        foreach (var transition in _transitions)
            transition.enabled = true;

        _animator.Play(_animationName.ToString());
    }

    public virtual void Exit()
    {
        foreach (var transition in _transitions)
            transition.enabled = false;
    }

    private void Update()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit == true)
            {
                TransitionConditionCompleted?.Invoke(transition.State);
                break;
            }
        }
    }
}
