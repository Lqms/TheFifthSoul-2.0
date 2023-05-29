using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerState
{
    private void Update()
    {
        PlayerController.Move(PlayerInput.CheckMoveKeys());      
    }
}
