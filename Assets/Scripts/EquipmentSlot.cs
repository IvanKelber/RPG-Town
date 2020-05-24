using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    [SerializeField]
    private Image equipmentImage;    

    [SerializeField]
    private Equipment equipment;

    private EquippableItem item;

    public EquipSlot slot;

    public void AddItem(EquippableItem item) {
        if(item.slot == slot) {
            Debug.Log("enabling itemslot");
            this.item = item;
            equipmentImage.sprite = item.sprite;
            equipmentImage.enabled = true;
        }
        Debug.Log("failed to enable itemslot");

    }

    private void RemoveItem() {
        this.item = null;
        equipmentImage.sprite = null;
        equipmentImage.enabled = false;
    }

    public void OnUnequipClicked() {
        if(equipment.Unequip(slot)) {
            RemoveItem();
        }
    }

}
