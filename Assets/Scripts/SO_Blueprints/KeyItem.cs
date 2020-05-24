using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[CreateAssetMenu(fileName = "KeyItem", menuName = "InventoryItems/KeyItem", order = 1)]
public class KeyItem : BaseItem
{
    public override void OnItemUse() {
        Debug.Log("Can't use " + Name + " right now but it might come in handy later.");
    }
}
