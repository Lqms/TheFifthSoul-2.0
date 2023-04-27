using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingState : PlayerState
{
    private void Update()
    {
        if (!PlayerController.CheckOnGround())
            PlayerController.Move(PlayerInput.CheckMoveKeys());
        else
            PlayerController.ResetVelocity();
    }
}
