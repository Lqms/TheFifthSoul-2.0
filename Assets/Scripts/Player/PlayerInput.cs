using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode _moveLeftKey = KeyCode.A;
    [SerializeField] private KeyCode _moveRightKey = KeyCode.D;
    [SerializeField] private KeyCode _dashKey = KeyCode.LeftShift;
    [SerializeField] private KeyCode _jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode _interactKey = KeyCode.E;
    [SerializeField] private KeyCode _sprinktKey = KeyCode.LeftControl;
    [SerializeField] private KeyCode _attackKey = KeyCode.Mouse0;

    public static event UnityAction<Vector2> MoveKeyPressing;
    public static event UnityAction DashKeyPressed;
    public static event UnityAction JumpKeyPressed;
    public static event UnityAction InteractKeyPressed;
    public static event UnityAction<bool> SprintKeyPressed;
    public static event UnityAction AttackKeyPressed;

    private void FixedUpdate()
    {
        CheckMoveKeys();
    }

    private void Update()
    {
        CheckDashKey();
        CheckJumpKey();
        CheckInteractKey();
        CheckSprintKey();
        CheckAttackKey();
    }

    private void CheckAttackKey()
    {
        if (Input.GetKeyDown(_attackKey))
        {
            AttackKeyPressed?.Invoke();
        }
    }

    private void CheckJumpKey()
    {
        if (Input.GetKeyDown(_jumpKey))
        {
            JumpKeyPressed?.Invoke();
        }
    }

    private void CheckDashKey()
    {
        if (Input.GetKeyDown(_dashKey))
        {
            DashKeyPressed?.Invoke();
        }
    }

    private void CheckSprintKey()
    {
        if (Input.GetKeyDown(_sprinktKey))
        {
            SprintKeyPressed?.Invoke(true);
        }

        if (Input.GetKeyUp(_sprinktKey))
        {
            SprintKeyPressed?.Invoke(false);
        }
    }

    private void CheckInteractKey()
    {
        if (Input.GetKeyDown(_interactKey))
        {
            InteractKeyPressed?.Invoke();
        }
    }

    private void CheckMoveKeys()
    {
        Vector2 direction = Vector2.zero;

        if (Input.GetKey(_moveLeftKey))
        {
            direction += Vector2.left;
        }
        else if (Input.GetKey(_moveRightKey))
        {
            direction += Vector2.right;
        }

        MoveKeyPressing?.Invoke(direction);
    }
}
