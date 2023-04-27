using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowState : EnemyState
{
    private void Update()
    {
        if (EnemyController.Player.transform.position.x > transform.position.x)
        {
            transform.parent.Translate(1 * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.parent.Translate(-1 * Time.deltaTime, 0, 0);
        }
    }
}
