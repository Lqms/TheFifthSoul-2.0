using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimationNames
{
    Idle,
    Run
}


public class State : MonoBehaviour
{
    [SerializeField] private Transition[] _transitions;
    [SerializeField] private AnimationNames _animationName;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        enabled = false;
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
}
