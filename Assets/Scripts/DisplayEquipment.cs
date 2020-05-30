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
    [SerializeField]
    private TMP_Text playerHP;
    [SerializeField]
    private TMP_Text playerMP;

    [SerializeField]
    private GameObject equipmentSlotsParent;

    private EquipmentSlot[] equipmentSlots;

    private Dictionary<EquipSlot, EquipmentSlot> slotMap;

    private void Awake() {
        cg = GetComponent<CanvasGroup>();
        equipmentSlots = equipmentSlotsParent.GetComponentsInChildren<EquipmentSlot>(); 
        slotMap = new Dictionary<EquipSlot, EquipmentSlot>();
        foreach(EquipmentSlot equipmentSlot in equipmentSlots) {
            slotMap.Add(equipmentSlot.slot, equipmentSlot);
        }
        OnToggleDisplay();
        UpdateUI();
    }

    private void OnDestroy() {
        equipment.SerializeEquipment();
    }

    public void UpdateUI() {
        Debug.Log("updating equipment UI");
        Debug.Log("equipment size: " + equipment.EquipmentMap.Count);
        UpdatePlayerStats();
        UpdateEquipment();
    }



    public void UpdateEquipment() {
        foreach(var pair in equipment.EquipmentMap) {
            EquipSlot slot = pair.Key;
            EquippableItem item = pair.Value;
            slotMap[slot].AddItem(item);
        }
    }

    public void UpdatePlayerStats() {
        playerStrength.text = "Str: " + stats.Strength;
        playerAgility.text = "Agi: " + stats.Agility;
        playerDefense.text = "Def: " + stats.Defense;
        playerConstitution.text = "Con: " + stats.Constitution;
        playerWisdom.text = "Wis: " + stats.Wisdom;
        playerLck.text = "Lck: " + stats.Luck;
        playerHP.text = "HP: " + stats.MaxHealth;
        playerMP.text = "MP: " + stats.MaxMana;
    }

    public void OnToggleDisplay() {
        cg.alpha = displayAlpha;
        displayAlpha = (displayAlpha + 1) % 2;
    }
}
