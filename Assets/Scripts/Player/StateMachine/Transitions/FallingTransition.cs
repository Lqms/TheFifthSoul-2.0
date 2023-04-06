using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTransition : Transition
{
    private void Update()
    {
        if (Physics.Velocity.y < 0 && !Physics.CheckOnGround())
            NeedTransit = true;
    }
}
