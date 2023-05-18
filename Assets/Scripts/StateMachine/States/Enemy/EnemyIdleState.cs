using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    private void Update()
    {
        if (Mathf.Abs(EnemyController.StartingPoint.x - transform.parent.position.x) < 0.1f)
        {
            Animator.Play(AnimationNames.Idle.ToString());
            return;
        }

        Animator.Play(AnimationNames.Run.ToString());
        Vector3 moveVector = transform.parent.position;
        moveVector.x = EnemyController.StartingPoint.x;
        transform.parent.position = Vector3.MoveTowards(transform.parent.position, moveVector, EnemyController.MovementSpeed * Time.deltaTime);

        float rotation = EnemyController.StartingPoint.x > transform.position.x ? 0 : 180;
        transform.parent.rotation = Quaternion.Euler(0, rotation, 0);
    }
}
