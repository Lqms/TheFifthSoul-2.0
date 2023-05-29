using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedAttackTransition : EnemyTransition
{
    private void Update()
    {
        var hitInfo = Physics2D.Raycast(EnemyController.RayPoint.transform.position, Vector2.right, EnemyController.AttackRange);
        
        if (hitInfo.collider.TryGetComponent(out Player player))
        {
            NeedTransit = true;
        }
    }
}
