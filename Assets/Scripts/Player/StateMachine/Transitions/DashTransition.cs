using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashTransition : Transition
{
    [SerializeField] private Player _player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && _player.CanDash)
        {
            NeedTransit = true;
        }
    }
}
