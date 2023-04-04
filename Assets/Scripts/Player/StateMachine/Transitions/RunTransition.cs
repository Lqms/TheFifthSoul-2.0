using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunTransition : Transition
{
    [SerializeField] private Rigidbody2D _rigidbody;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0 && _rigidbody.velocity.y == 0)
            NeedTransit = true;
    }
}
