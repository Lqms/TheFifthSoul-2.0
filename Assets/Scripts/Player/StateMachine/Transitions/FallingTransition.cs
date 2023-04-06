using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTransition : Transition
{
    private void Update()
    {
        if (PlayerController.Velocity.y < 0 && !PlayerController.CheckOnGround())
            NeedTransit = true;
    }
}
