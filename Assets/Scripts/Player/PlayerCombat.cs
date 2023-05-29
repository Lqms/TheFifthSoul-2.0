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

        yield return new WaitForSeconds(animationTime / 2);
        DealDamage();
        yield return new WaitForSeconds(animationTime / 2);

        IsAttacking = false;
    }

    private void DealDamage()
    {
        var attackRange = Vector2.Distance(transform.position, _attackPoint.position);
        print(attackRange);
        var collisions = Physics2D.OverlapCircleAll(_attackPoint.position, attackRange);

        foreach (var collision in collisions)
        {
            if (collision.TryGetComponent(out Health health) && collision.TryGetComponent(out Player player) == false)
            {
                Vector2 pushDirection = transform.position.x > health.transform.position.x ? Vector2.left : Vector2.right;
                health.ApplyDamage(1, pushDirection);
            }
        }
    }
}
