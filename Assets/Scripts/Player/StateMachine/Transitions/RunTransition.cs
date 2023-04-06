using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunTransition : Transition
{
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0 && Physics.Velocity.y == 0)
            NeedTransit = true;
    }
}
