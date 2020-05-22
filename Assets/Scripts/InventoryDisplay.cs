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
    private Image itemImage;
    [SerializeField]
    TMP_Text itemName;
    [SerializeField]
    TMP_Text itemDescription;


    [SerializeField]
    private GameObject itemSlotsParent;

    private ItemSlot[] inventorySlots;


    private void Awake() {
        cg = GetComponent<CanvasGroup>();
        OnToggleDisplay();
        inventorySlots = itemSlotsParent.GetComponentsInChildren<ItemSlot>();
        Debug.Log("Inventory slots: " + inventorySlots);
        inventory.Clear(); //While there is no saving of course
    }

    public void UpdateUI() {
        for(int i = 0; i < inventorySlots.Length; i++) {
            inventorySlots[i].RemoveItem();
            if(i < inventory.Count) {
                inventorySlots[i].AddItem(inventory.Get(i));
            }
        }
    }

    public void DisplaySelectedItem(BaseItem item) {
        if(item == null) {
            return;
        }
        itemName.text = item.Name;
        itemDescription.text = item.Description;
        itemImage.sprite = item.sprite;
    }


    public void OnToggleDisplay() {
        cg.alpha = displayAlpha;
        displayAlpha = (displayAlpha + 1) % 2;
    }
}
