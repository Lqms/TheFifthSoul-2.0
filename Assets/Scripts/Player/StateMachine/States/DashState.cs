using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : State
{
    protected override void OnEnable()
    {
        base.OnEnable();

        PlayerController.Dash();
    }
}
