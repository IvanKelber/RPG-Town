using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayEquipment : MonoBehaviour
{
    [SerializeField]
    Equipment equipment;
    [SerializeField]
    DerivedStats stats;

    private int displayAlpha = 0;
    private CanvasGroup cg;


    [SerializeField]
    private TMP_Text playerStrength;
    [SerializeField]
    private TMP_Text playerAgility;
    [SerializeField]
    private TMP_Text playerDefense;
    [SerializeField]
    private TMP_Text playerConstitution;
    [SerializeField]
    private TMP_Text playerWisdom;
    [SerializeField]
    private TMP_Text playerLck;

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

    public void Update() {
        UpdateStats();
    }

    public void UpdateStats() {
        playerStrength.text = "Str: " + stats.Strength;
        playerAgility.text = "Agi: " + stats.Agility;
        playerDefense.text = "Def: " + stats.Defense;
        playerConstitution.text = "Con: " + stats.Constitution;
        playerWisdom.text = "Wis: " + stats.Wisdom;
        playerLck.text = "Lck: " + stats.Luck;
    }

    public void OnToggleDisplay() {
        cg.alpha = displayAlpha;
        displayAlpha = (displayAlpha + 1) % 2;
    }
}
