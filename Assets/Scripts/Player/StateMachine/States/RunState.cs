using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : State
{
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Physics.Move(horizontalInput);      
    }
}
