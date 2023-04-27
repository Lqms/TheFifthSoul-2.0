using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : State
{
    protected EnemyController EnemyController;

    private void Awake()
    {
        EnemyController = GetComponentInParent<EnemyController>();
    }
}
