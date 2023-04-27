using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingTransition : PlayerTransition
{
    private void Update()
    {
        if (PlayerController.Velocity.y < 0 && !PlayerController.CheckOnGround() && !PlayerController.IsAttacking)
            NeedTransit = true;
    }
}
