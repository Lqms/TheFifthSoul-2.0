using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleTransition : Transition
{
    [SerializeField] private Rigidbody2D _rigidbody;

    private void Update()
    {
        if (_rigidbody.velocity == Vector2.zero)
            NeedTransit = true;
    }
}
