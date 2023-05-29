using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : State
{
    protected PlayerController PlayerController;

    private void Awake()
    {
        PlayerController = GetComponentInParent<PlayerController>();
    }
}
