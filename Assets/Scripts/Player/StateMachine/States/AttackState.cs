using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    protected override void OnEnable()
    {
        base.OnEnable();

        if (Physics.CheckOnGround())
            Physics.SetVelocityX(0); // поинтереснее

        Combat.Attack();
    }
}
