using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackTransition : PlayerTransition
{
    private void Update()
    {
        if (PlayerInput.CheckAttackKeyDown() && !PlayerController.IsAttacking)
            NeedTransit = true;
    }
}
