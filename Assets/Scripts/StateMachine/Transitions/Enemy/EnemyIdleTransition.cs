using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleTransition : Transition
{
    private float _playerHealth;

    private void Start()
    {
        FindObjectOfType<Player>().TryGetComponent(out Health health);
        _playerHealth = health.Current;
    }

    private void Update()
    {
        if (_playerHealth <= 0)
        {
            NeedTransit = true;
        }
    }
}
