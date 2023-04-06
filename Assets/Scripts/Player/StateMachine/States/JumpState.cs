using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    protected override void OnEnable()
    {
        base.OnEnable();

        PlayerController.Jump();
    }

    private void Update()
    {
        PlayerController.Move(PlayerInput.CheckMoveKeys());
    }
}
