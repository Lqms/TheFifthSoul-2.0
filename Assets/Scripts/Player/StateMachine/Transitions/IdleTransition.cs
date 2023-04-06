using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleTransition : Transition
{
    private void Update()
    {
        if (Physics.Velocity == Vector2.zero)
            NeedTransit = true;
    }
}
