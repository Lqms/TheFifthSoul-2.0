using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransition : Transition
{
    protected PlayerController PlayerController;
    private void Awake()
    {
        PlayerController = GetComponentInParent<PlayerController>();
    }
}
