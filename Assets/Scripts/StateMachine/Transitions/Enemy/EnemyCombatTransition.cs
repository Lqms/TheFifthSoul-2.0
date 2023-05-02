using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatTransition : EnemyTransition
{
    private void Update()
    {
        if (CheckPlayerInViewRange())
            NeedTransit = true;
    }

    private bool CheckPlayerInViewRange()
    {
        Ray2D ray = new Ray2D(transform.parent.position, transform.right);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, EnemyController.ViewRange);
        Debug.DrawRay(ray.origin, ray.direction * EnemyController.ViewRange, Color.red);

        return (hit.collider != null && hit.collider.TryGetComponent(out Player player));
    }
}
