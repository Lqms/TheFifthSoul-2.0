using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _dashCooldown = 3;

    public bool CanDash { get; private set; } = true;

    public void StartReloadingDash()
    {
        if (CanDash == true)
            StartCoroutine(DashReloading());
    }

    private IEnumerator DashReloading()
    {
        print("dash start reload");
        CanDash = false;

        yield return new WaitForSeconds(_dashCooldown);

        CanDash = true;
        print("dash is ready");
    }
}
