using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleTransition : Transition
{
    private void OnEnable()
    {
        PlayerInput.MoveKeyPressing += OnMoveKeyPressing;
    }

    private void OnDisable()
    {
        PlayerInput.MoveKeyPressing -= OnMoveKeyPressing;
    }

    private void OnMoveKeyPressing(Vector2 direction)
    {
        if (direction == Vector2.zero)
            NeedTransit = true;
    }
}
