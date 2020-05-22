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

  
    private void Update() {
        // DisplayItem(inventory.Count > 0 ? inventory[0] : null);
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

    public void TEST() {
        Debug.Log("TEST");
    }


    public void OnToggleDisplay() {
        cg.alpha = displayAlpha;
        displayAlpha = (displayAlpha + 1) % 2;
    }
}
