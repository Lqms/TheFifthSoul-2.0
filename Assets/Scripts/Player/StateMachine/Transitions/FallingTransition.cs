using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTransition : Transition
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _legs;
    [SerializeField] private float _legsRadius = 0.2f;

    private void Update()
    {
        if (_rigidbody.velocity.y < 0 && OnGround() == false)
        {
            NeedTransit = true;
        }
    }

    private bool OnGround()
    {
        return Physics2D.OverlapCircle(_legs.position, _legsRadius, _groundMask);
    }
}
