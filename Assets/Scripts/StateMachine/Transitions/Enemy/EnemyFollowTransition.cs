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

        if (transform.parent.position.x != EnemyController.LastPlayerPositionX && isPlayerInAttackRange == false)
        {
            NeedTransit = true;
        }
    }
}
