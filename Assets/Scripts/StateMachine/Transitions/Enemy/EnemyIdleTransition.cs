using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleTransition : EnemyTransition
{
    private void Update()
    {
        if (CheckAttackingPossibility() == false)
            NeedTransit = true;
    }

    private bool CheckAttackingPossibility()
    {
        Ray2D ray = new Ray2D(transform.parent.position, transform.right);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, EnemyController.ViewRange);
        Debug.DrawRay(ray.origin, ray.direction * EnemyController.ViewRange, Color.red);

        return (hit.collider != null && hit.collider.TryGetComponent(out Player player));
    }
}
