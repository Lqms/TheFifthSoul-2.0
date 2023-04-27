using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimationNames
{
    Attack,
    Idle,
    Run,
    Jump,
    Falling,
    Dash
}

public class State : MonoBehaviour
{
    [SerializeField] private AnimationNames _animationName;
    [SerializeField] private List<Transition> _transitions;

    private Animator _animator;

    protected Animator Animator => _animator;
    protected AnimationNames AnimationName => _animationName;

    protected virtual void OnEnable()
    {
        _animator.Play(AnimationName.ToString());
    }

    protected virtual void OnDisable()
    {
        _animator.StopPlayback();
    }

    public void Enter(Animator animator)
    {
        _animator = animator;

        if (enabled == false)
        {
            enabled = true;

            foreach (var transition in _transitions)
                transition.enabled = true;
        }
    }

    public void Exit()
    {
        if (enabled == true)
        {
            foreach (var transition in _transitions)
                transition.enabled = false;

            enabled = false;
        }
    }

    public State TryGetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
                return transition.TargetState;
        }

        return null;
    }
}
