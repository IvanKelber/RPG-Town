using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "UserInput", menuName = "Objects/UserInput", order = 1)]
public class UserInput : ScriptableObject
{

    [SerializeField]
    private KeyCode actionKey;
    [SerializeField]
    private KeyCode runKey;
    [SerializeField]
    private KeyCode inventoryKey;
    [SerializeField]
    private KeyCode equipmentKey;

    public Vector2 DirectionalInput() {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    public bool ActionKey() {
        return Input.GetKeyDown(actionKey);
    }

    public bool RunKey() {
        return Input.GetKey(runKey);
    }

    public bool InventoryKey() {
        return Input.GetKeyDown(inventoryKey);
    }

    public bool EquipmentKey() {
        return Input.GetKeyDown(equipmentKey);
    }


}
