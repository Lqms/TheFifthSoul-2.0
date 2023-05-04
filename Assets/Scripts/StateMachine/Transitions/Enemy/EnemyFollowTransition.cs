using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowTransition : EnemyTransition
{
    private void Update()
    {
        if (EnemyController.IsPlayerInDetectionRange == true && EnemyController.IsPlayerInAttackRange == false)
        {
            NeedTransit = true;
        }
    }
}
