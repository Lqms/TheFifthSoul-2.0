using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;

    public bool IsAttacking { get; private set; } = false;

    public void Attack(Animator animator)
    {
        StartCoroutine(Attacking(animator));
    }

    private IEnumerator Attacking(Animator animator)
    {
        IsAttacking = true;

        float delay = 0.01f;

        yield return new WaitForSeconds(delay);

        float animationTime = animator.GetCurrentAnimatorStateInfo(0).length;

        var attackRange = Vector2.Distance(transform.position, _attackPoint.position);
        var collisions = Physics2D.OverlapCircleAll(_attackPoint.position, attackRange);

        foreach (var collision in collisions)
            if (collision.TryGetComponent(out Health health) && collision != GetComponent<Collider2D>())
                health.ApplyDamage(1);

        yield return new WaitForSeconds(animationTime);

        IsAttacking = false;
    }
}
