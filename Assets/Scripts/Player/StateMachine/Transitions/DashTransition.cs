using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashTransition : Transition
{
    private void Update()
    {
        if (PlayerInput.CheckDashKeyDown() && PlayerController.CanDash)
            NeedTransit = true;
    }
}
