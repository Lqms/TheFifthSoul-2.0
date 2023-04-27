using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTransition : Transition
{
    protected PlayerController PlayerController;
    private void Awake()
    {
        PlayerController = GetComponentInParent<PlayerController>();
    }
}
