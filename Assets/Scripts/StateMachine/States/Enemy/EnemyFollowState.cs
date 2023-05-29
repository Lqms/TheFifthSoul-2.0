using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowState : EnemyState
{
    private void Update()
    {
        Vector3 moveVector = transform.parent.position;
        moveVector.x = EnemyController.LastPlayerPositionX;
        transform.parent.position = Vector3.MoveTowards(transform.parent.position, moveVector, EnemyController.MovementSpeed * Time.deltaTime);

        float rotation = EnemyController.LastPlayerPositionX > transform.position.x ? 0 : 180;
        transform.parent.rotation = Quaternion.Euler(0, rotation, 0);
    }
}
