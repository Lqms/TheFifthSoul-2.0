using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTransition : Transition
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Physics.CheckOnGround())
        {
            NeedTransit = true;
        }
    }
}
