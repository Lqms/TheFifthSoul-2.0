using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _dashCooldown = 3;

    public bool CanDash { get; private set; } = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && CanDash == true)
        {
            StartCoroutine(DashReloading());
        }
    }

    private IEnumerator DashReloading()
    {
        yield return new WaitForSeconds(0.01f);
        print("dash start reload");
        CanDash = false;

        yield return new WaitForSeconds(_dashCooldown);

        CanDash = true;
        print("dash is ready");
    }
}
