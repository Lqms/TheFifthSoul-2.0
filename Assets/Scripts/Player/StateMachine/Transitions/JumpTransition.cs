using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTransition : Transition
{
    private void Update()
    {
        if (PlayerInput.CheckJumpKey() && Physics.CheckOnGround())
            NeedTransit = true;
    }
}
