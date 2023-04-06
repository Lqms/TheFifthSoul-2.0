using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTransition : Transition
{
    private void Update()
    {
        if (PlayerInput.CheckAttackKey() && !Combat.IsAttacking)
            NeedTransit = true;
    }
}
