using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowState : State
{
    private void Update()
    {
        if (FindObjectOfType<Player>().transform.position.x > transform.position.x)
        {
            transform.parent.Translate(1 * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.parent.Translate(-1 * Time.deltaTime, 0, 0);
        }
    }
}