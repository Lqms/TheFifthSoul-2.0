using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    protected override void OnEnable()
    {
        base.OnEnable();

        // Animator.Play(AnimationName.ToString() + Random.Range(1, 3));
        EnemyController.Attack();
    }
}
