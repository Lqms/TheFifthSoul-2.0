using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState : State
{
    private void Update()
    {
        if (!Physics.CheckOnGround())
            Physics.Move(PlayerInput.CheckMoveKeys());
        else
            Physics.Stop();
    }
}
