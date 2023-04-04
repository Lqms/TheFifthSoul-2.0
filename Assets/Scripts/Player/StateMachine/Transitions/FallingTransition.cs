using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTransition : Transition
{
    [SerializeField] private Rigidbody2D _rigidbody;

    private void Update()
    {
        if (_rigidbody.velocity.y < 0)
        {
            NeedTransit = true;
        }
    }
}
