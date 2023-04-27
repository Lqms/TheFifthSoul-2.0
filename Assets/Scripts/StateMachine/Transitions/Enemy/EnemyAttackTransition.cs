using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTransition : EnemyTransition
{
    private void Update()
    {
        if (Vector2.Distance(EnemyController.Player.transform.position, transform.position) < EnemyController.AttackRange)
        {
            NeedTransit = true;
        }
    }
}
