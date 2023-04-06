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

    protected Animator Animator;
    protected PlayerPhysics Physics;
    protected PlayerCombat Combat;

    private void Awake()
    {
        Animator = GetComponentInParent<Animator>();
        Physics = GetComponentInParent<PlayerPhysics>();
        Combat = GetComponentInParent<PlayerCombat>();
    }

    protected virtual void OnEnable()
    {
        Animator.Play(_animationName.ToString());
    }

    private void OnDisable()
    {
        Animator.StopPlayback();
    }

    public void Enter()
    {
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
