using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    protected override void OnEnable()
    {
        base.OnEnable();

        PlayerController.Dash();
    }
}
