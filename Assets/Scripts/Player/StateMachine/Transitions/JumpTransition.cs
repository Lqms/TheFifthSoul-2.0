using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTransition : Transition
{
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _legs;
    [SerializeField] private float _legsRadius = 0.2f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && OnGround())
        {
            NeedTransit = true;
        }
    }

    private bool OnGround()
    {
        return Physics2D.OverlapCircle(_legs.position, _legsRadius, _groundMask);
    }
}
