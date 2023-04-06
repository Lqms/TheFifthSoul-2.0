using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static KeyCode AttackKey = KeyCode.Mouse0;
    public static KeyCode MoveLeftKey = KeyCode.A;
    public static KeyCode MoveRightKey = KeyCode.D;
    public static KeyCode JumpKey = KeyCode.Space;
    public static KeyCode DashKey = KeyCode.LeftShift;

    public static float CheckMoveKeys()
    {
        if (Input.GetKey(MoveLeftKey))
        {
            return -1;
        }
        else if (Input.GetKey(MoveRightKey))
        {
            return 1;
        }

        return 0;
    }

    public static bool CheckDashKeyDown()
    {
        if (Input.GetKeyDown(DashKey))
        {
            return true;
        }

        return false;
    }

    public static bool CheckJumpKeyDown()
    {
        if (Input.GetKeyDown(JumpKey))
        {
            return true;
        }

        return false;
    }

    public static bool CheckAttackKeyDown()
    {
        if (Input.GetKeyDown(AttackKey))
        {
            return true;
        }

        return false;
    }
}
