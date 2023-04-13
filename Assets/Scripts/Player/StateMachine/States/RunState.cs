using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : State
{
    private void Update()
    {
        PlayerController.Move(PlayerInput.CheckMoveKeys());      
    }
}
