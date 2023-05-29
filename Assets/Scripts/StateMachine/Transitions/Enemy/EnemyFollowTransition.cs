using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowTransition : EnemyTransition
{
    private void Update()
    {
        if (EnemyController.Player.gameObject.activeSelf == false)
            return;

        bool isPlayerInAttackRange = Mathf.Abs(EnemyController.Player.transform.position.x - transform.parent.position.x) <= EnemyController.AttackRange;

        if (Mathf.Abs(transform.parent.position.x - EnemyController.LastPlayerPositionX) >= 0.1f && isPlayerInAttackRange == false && EnemyController.IsPlayerReachable)
        {
            NeedTransit = true;
        }
    }
}
