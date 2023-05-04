using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTransition : EnemyTransition
{
    private void Update()
    {
        if (EnemyController.IsPlayerInAttackRange == true)
        {
            NeedTransit = true;
        }
    }
}
