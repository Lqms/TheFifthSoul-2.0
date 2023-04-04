using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public override void Enter()
    {
        base.Enter();

        Rigidbody.velocity = new Vector2(0, Rigidbody.velocity.y);
    }
}
