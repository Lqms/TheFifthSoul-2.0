using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedAttackState : EnemyState
{
    [SerializeField] private Projectile _projectile;
    [SerializeField] private Transform _attackPoint;

    private Coroutine _coroutine;

    protected override void OnEnable()
    {
        base.OnEnable();

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Attacking());
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = null;
    }

    private IEnumerator Attacking()
    {
        float delay = 0.01f;
        yield return new WaitForSeconds(delay);

        float animationTime = Animator.GetCurrentAnimatorStateInfo(0).length;

        while (true)
        {
            yield return new WaitForSeconds(animationTime);
            Attack();
        }
    }

    private void Attack()
    {
        var projectile = Instantiate(_projectile);
        var direction = EnemyController.Player.transform.position.x > transform.parent.position.x ? Vector2.right : Vector2.left;

        projectile.Init(_attackPoint.position, direction, 1);
    }
}
