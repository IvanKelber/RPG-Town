using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ScriptableObjectArchitecture;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField]
    ItemCollection inventory;

    private int displayAlpha = 0;
    private CanvasGroup cg;


    [SerializeField]
    private GameObject itemSlotsParent;

    private ItemSlot[] inventorySlots;
    private SelectedItem selectedItem;

    private void Awake() {
        cg = GetComponent<CanvasGroup>();
        inventorySlots = itemSlotsParent.GetComponentsInChildren<ItemSlot>(); 
        selectedItem = GetComponentInChildren<SelectedItem>();
        Debug.Log("Inventory slots: " + inventorySlots);
        inventory.Clear(); //While there is no saving of course
        OnToggleDisplay();
    }

    public void UpdateUI() {
        for(int i = 0; i < inventorySlots.Length; i++) {
            inventorySlots[i].RemoveItem();
            if(i < inventory.Count) {
                inventorySlots[i].AddItem(inventory.Get(i));
            }
        }
        selectedItem.SetItem(null);
    }

    public void OnToggleDisplay() {
        cg.alpha = displayAlpha;
        displayAlpha = (displayAlpha + 1) % 2;
        selectedItem.SetItem(inventory.Get(0));
    }
}
