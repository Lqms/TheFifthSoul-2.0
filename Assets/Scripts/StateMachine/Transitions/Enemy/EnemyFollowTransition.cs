using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowTransition : EnemyTransition
{
    private void Update()
    {
        if (EnemyController.Player == null)
            return;

        float distance = Vector2.Distance(EnemyController.Player.transform.position, transform.position);

        if (distance < 5 && distance > 1)
        {
            NeedTransit = true;
        }
    }
}
