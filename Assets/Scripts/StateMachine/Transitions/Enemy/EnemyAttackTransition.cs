using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTransition : EnemyTransition
{
    private void Update()
    {
        if (EnemyController.Player == null)
            return;

        if (Vector2.Distance(EnemyController.Player.transform.position, transform.position) < 1)
        {
            NeedTransit = true;
        }
    }
}
