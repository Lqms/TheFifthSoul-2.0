using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTransition : EnemyTransition
{
    private void Update()
    {
        if (EnemyController.Player.gameObject.activeSelf == false)
            return;

        // bool isPlayerInAttackRange = Mathf.Abs(EnemyController.LastPlayerPositionX - transform.parent.position.x) <= EnemyController.AttackRange;
        bool isPlayerInAttackRange = Vector2.Distance(EnemyController.Player.transform.position, transform.parent.position) <= EnemyController.AttackRange;

        if (EnemyController.IsPlayerSeen == true && isPlayerInAttackRange == true)
        {
            NeedTransit = true;
        }
    }
}
