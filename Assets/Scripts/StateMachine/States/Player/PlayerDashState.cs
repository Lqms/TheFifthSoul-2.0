using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    protected override void OnEnable()
    {
        if (PlayerController.CheckOnGround())
            Animator.Play(AnimationNames.Roll.ToString());
        else
            base.OnEnable();

        PlayerController.Dash();
    }
}
