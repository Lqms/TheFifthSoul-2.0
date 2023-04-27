using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : State
{
    protected PlayerController PlayerController;

    private void Awake()
    {
        PlayerController = GetComponentInParent<PlayerController>();
    }

    protected virtual void OnEnable()
    {
        PlayerController.PlayAnimation(AnimationName.ToString());
    }

    protected virtual void OnDisable()
    {
        PlayerController.StopAnimatorPlayback();
    }
}
