using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "UserInput", menuName = "Objects/UserInput", order = 1)]
public class UserInput : ScriptableObject
{

    const KeyCode actionKey = KeyCode.Space;
    const KeyCode runKey = KeyCode.LeftShift;

    public Vector2 DirectionalInput() {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    public bool ActionKey() {
        return Input.GetKeyDown(actionKey);
    }

    public bool RunKey() {
        return Input.GetKey(runKey);
    }


}
