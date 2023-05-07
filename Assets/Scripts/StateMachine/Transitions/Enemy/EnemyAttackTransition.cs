using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTransition : EnemyTransition
{
    private void Update()
    {
        if (EnemyController.Player.gameObject.activeSelf == false)
            return;

        bool isPlayerInAttackRange = Mathf.Abs(EnemyController.LastPlayerPositionX - transform.parent.position.x) <= EnemyController.AttackRange;

        if (EnemyController.IsPlayerSeen == true && isPlayerInAttackRange == true)
        {
            NeedTransit = true;
        }
    }
}
