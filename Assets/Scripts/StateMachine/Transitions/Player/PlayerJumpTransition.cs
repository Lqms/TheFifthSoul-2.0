using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpTransition : PlayerTransition
{
    private void Update()
    {
        if (PlayerInput.CheckJumpKeyDown() && PlayerController.CheckOnGround())
            NeedTransit = true;
    }
}
