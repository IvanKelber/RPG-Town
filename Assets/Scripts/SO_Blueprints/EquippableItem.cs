using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EquippableItem", menuName = "Equipment/EquippableItem", order = 1)]
public class EquippableItem : BaseItem
{

    public PrimaryStats stats;
    public EquipSlot slot;

    public Equipment equipment;

    public override void OnItemUse() {
        Debug.Log("Equipping " + this.Name);
        equipment.Equip(slot, this);
    }

}
