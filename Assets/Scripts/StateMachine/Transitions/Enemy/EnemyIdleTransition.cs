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
        EnemyController.Player.Died -= OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        NeedTransit = true;
    }
}
