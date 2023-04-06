using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunTransition : Transition
{
    private void Update()
    {
        if (PlayerInput.CheckMoveKeys() != 0 && Physics.Velocity.y == 0)
            NeedTransit = true;
    }
}
