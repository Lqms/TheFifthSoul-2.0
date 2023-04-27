using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowTransition : EnemyTransition
{
    private void Update()
    {
        float distance = Vector2.Distance(EnemyController.Player.transform.position, transform.position);

        if (distance < EnemyController.AgroRange && distance > EnemyController.AttackRange)
        {
            NeedTransit = true;
        }
    }
}
