using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleTransition : Transition
{
    private void Update()
    {
        if (PlayerController.Velocity == Vector2.zero && !PlayerController.IsAttacking)
            NeedTransit = true;
    }
}
