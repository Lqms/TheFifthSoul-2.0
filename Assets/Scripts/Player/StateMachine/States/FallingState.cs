using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState : State
{
    private void Update()
    {
        if (!PlayerController.CheckOnGround())
            PlayerController.Move(PlayerInput.CheckMoveKeys());
        else
            PlayerController.ResetVelocity();
    }
}
