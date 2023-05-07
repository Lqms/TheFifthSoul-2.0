using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleTransition : EnemyTransition
{
    private void OnEnable()
    {
        EnemyController.Player.Died += OnPlayerDied;
    }

    private void OnDisable()
    {
        NeedTransit = false;
        EnemyController.Player.Died -= OnPlayerDied;
    }

    private void Update()
    {
        if (transform.parent.position.x == EnemyController.LastPlayerPositionX && EnemyController.IsPlayerSeen == false)
        {
            print(transform.parent.position.x);
            NeedTransit = true;
        }
    }

    private void OnPlayerDied()
    {
        NeedTransit = true;
    }
}
