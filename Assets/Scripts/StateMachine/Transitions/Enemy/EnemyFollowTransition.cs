using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowTransition : EnemyTransition
{
    private void Update()
    {
        if (Vector2.Distance(EnemyController.Player.transform.position, transform.position) < 5)
        {
            NeedTransit = true;
        }
    }
}
