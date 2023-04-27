using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashTransition : PlayerTransition
{
    private void Update()
    {
        if (PlayerInput.CheckDashKeyDown() && PlayerController.CanDash)
            NeedTransit = true;
    }
}
