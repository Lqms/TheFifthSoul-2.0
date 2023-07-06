using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleTransition : EnemyTransition
{
    [SerializeField] private EnemyArea _enemeyArea;

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
        if ((Mathf.Abs(transform.parent.position.x - EnemyController.LastPlayerPositionX) <= 0.1f && EnemyController.IsPlayerSeen == false) ||
            EnemyController.IsPlayerReachable == false)
        {
            NeedTransit = true;
        }

        if (_enemeyArea.inArea == false)
        {
            NeedTransit = true;
            print("suck some dick");
        }
    }

    private void OnPlayerDied()
    {
        NeedTransit = true;
    }
}
