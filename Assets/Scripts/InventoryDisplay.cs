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

    private bool displayOn;
    private CanvasGroup cg;


    [SerializeField]
    private GameObject itemSlotsParent;

    private ItemSlot[] inventorySlots;
    private SelectedItem selectedItem;

    private void Awake() {
        cg = GetComponent<CanvasGroup>();
        inventorySlots = itemSlotsParent.GetComponentsInChildren<ItemSlot>(); 
        selectedItem = GetComponentInChildren<SelectedItem>();
    }

    private void Start() {
        UpdateUI();
        displayOn = ToggleDisplay(false); //Default to off
        Debug.Log("setting inventory invisible");

    }

    private void OnDestroy() {
        displayOn = ToggleDisplay(false); //Ensure it's off when destroyed
        Debug.Log("setting inventory invisible on destroy");
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

    private bool ToggleDisplay(bool turnOn){
        if(turnOn) {
            cg.alpha = 1;
        } else {
            cg.alpha = 0;
        }
        return !turnOn;
    }

    public void OnToggleDisplay() {
        displayOn = ToggleDisplay(displayOn);
        selectedItem.SetItem(inventory.Get(0));
    }
}
