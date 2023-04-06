using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    protected override void OnEnable()
    {
        base.OnEnable();

        Physics.Jump();
    }

    private void Update()
    {
        Physics.Move(PlayerInput.CheckMoveKeys());
    }
}
