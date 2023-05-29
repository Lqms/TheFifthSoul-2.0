using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunTransition : PlayerTransition
{
    private void Update()
    {
        if (PlayerInput.CheckMoveKeys() != 0 && PlayerController.Velocity.y == 0)
            NeedTransit = true;
    }
}
