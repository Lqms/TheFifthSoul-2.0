using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState : State
{
    private void Update()
    {
        if (Physics.CheckOnGround() == false)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            Physics.Move(horizontalInput);
        }
        else
        {
            Physics.Stop();
        }
    }
}
