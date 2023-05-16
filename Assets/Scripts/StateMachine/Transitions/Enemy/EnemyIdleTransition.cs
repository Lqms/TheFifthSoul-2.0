using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleTransition : EnemyTransition
{
    [SerializeField] private Transform _fallingPoint;
    [SerializeField] private LayerMask _obstacleMask;

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
        if (Mathf.Abs(transform.parent.position.x - EnemyController.LastPlayerPositionX) <= 0.1f && EnemyController.IsPlayerSeen == false)
        {
            print(transform.parent.position.x);
            NeedTransit = true;
        }

        // это все в енеми контроллере
        var grounds = Physics2D.OverlapCircleAll(_fallingPoint.position, 0.2f, _obstacleMask);
        print(grounds.Length);

        if (grounds.Length == 0)
            NeedTransit = true;
    }

    private void OnPlayerDied()
    {
        NeedTransit = true;
    }
}
