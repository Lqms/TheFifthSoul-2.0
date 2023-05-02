using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTransition : EnemyTransition
{
    private void Update()
    {
        if (CheckAttackingPossibility())
            NeedTransit = true;
    }

    private bool CheckAttackingPossibility()
    {
        Ray2D ray = new Ray2D(transform.parent.position, transform.right);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, EnemyController.AttackRange);
        Debug.DrawRay(ray.origin, ray.direction * EnemyController.AttackRange, Color.red);

        return (hit.collider != null && hit.collider.TryGetComponent(out Player player));
    }
}
