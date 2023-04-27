using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowTransition : Transition
{
    private void Update()
    {
        if (Vector2.Distance(FindObjectOfType<Player>().transform.position, transform.position) < 5)
        {
            NeedTransit = true;
        }
    }
}
