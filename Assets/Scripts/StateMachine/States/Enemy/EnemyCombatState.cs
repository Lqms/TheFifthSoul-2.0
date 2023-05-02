using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatState : EnemyState
{
    [SerializeField] private Transform _attackPoint;

    private Coroutine _coroutine;

    private void Update()
    {
        LookAtPlayer();

        if (CheckAttackingPossibility())
            Attack();
        else
            MoveToPlayer();
    }

    private void Attack()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Attacking());
    }

    private void LookAtPlayer()
    {
        if (EnemyController.Player.transform.position.x > transform.position.x)
            transform.parent.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        else
            transform.parent.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    private bool CheckAttackingPossibility()
    {
        Ray2D ray = new Ray2D(transform.parent.position, transform.right);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, EnemyController.AttackRange);
        Debug.DrawRay(ray.origin, ray.direction * EnemyController.AttackRange, Color.red);

        return (hit.collider != null && hit.collider.TryGetComponent(out Player player));
    }

    private void MoveToPlayer()
    {
        if (EnemyController.Player.transform.position.x > transform.position.x)
            transform.parent.Translate(EnemyController.MovementSpeed * Time.deltaTime, 0, 0);
        else
            transform.parent.Translate(-EnemyController.MovementSpeed * Time.deltaTime, 0, 0);
    }


    private IEnumerator Attacking()
    {
        float delay = 0.01f;
        Animator.Play(AnimationNames.Attack.ToString());

        yield return new WaitForSeconds(delay);
        float animationTime = Animator.GetCurrentAnimatorStateInfo(0).length;

        while (true)
        {
            yield return new WaitForSeconds(animationTime / 2);
            DealDamage();
            yield return new WaitForSeconds(animationTime / 2);
        }
    }

    private void DealDamage()
    {
        var attackRange = Vector2.Distance(transform.position, _attackPoint.position);
        var collisions = Physics2D.OverlapCircleAll(_attackPoint.position, attackRange);

        foreach (var collision in collisions)
            if (collision.TryGetComponent(out Health health) && collision.TryGetComponent(out Enemy player) == false)
                health.ApplyDamage(1);
    }
}
