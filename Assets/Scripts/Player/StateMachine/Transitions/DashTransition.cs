using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashTransition : Transition
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && Physics.CanDash)
        {
            NeedTransit = true;
        }
    }
}
