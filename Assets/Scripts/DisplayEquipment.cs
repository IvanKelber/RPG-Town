using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayEquipment : MonoBehaviour
{
    [SerializeField]
    Equipment equipment;

    private int displayAlpha = 0;
    private CanvasGroup cg;


    // [SerializeField]
    // private GameObject itemSlotsParent;

    // private ItemSlot[] inventorySlots;

    private void Awake() {
        cg = GetComponent<CanvasGroup>();
        // inventorySlots = itemSlotsParent.GetComponentsInChildren<ItemSlot>(); 
        // selectedItem = GetComponentInChildren<SelectedItem>();
        // Debug.Log("Inventory slots: " + inventorySlots);
        // inventory.Clear(); //While there is no saving of course
        OnToggleDisplay();
    }

    public void UpdateUI() {

    }

    public void OnToggleDisplay() {
        cg.alpha = displayAlpha;
        displayAlpha = (displayAlpha + 1) % 2;
    }
}
