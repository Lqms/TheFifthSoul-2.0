using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Player _player;

    public Player Player => _player;

    private void Update()
    {
        if (CheckAttackingPossibility())
            print("can attack");
    }

    private bool CheckAttackingPossibility()
    {
        Ray2D ray = new Ray2D(transform.position, transform.right);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 2);
        Debug.DrawRay(ray.origin, ray.direction * 2, Color.red);

        return (hit.collider != null && hit.collider.TryGetComponent(out Player player));
    }
}
