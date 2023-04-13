using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
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
        print(animationTime);

        yield return new WaitForSeconds(animationTime);

        IsAttacking = false;
    }
}
