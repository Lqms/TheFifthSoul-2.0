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
            transform.parent.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.parent.Translate(-1 * Time.deltaTime, 0, 0);
            transform.parent.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
}
