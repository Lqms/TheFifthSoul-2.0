using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunTransition : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private State _state;
 
    private void Update()
    {
        if (_rigidbody.velocity.x != 0)
            Transit();
    }

    private void Transit()
    {

    }
}
