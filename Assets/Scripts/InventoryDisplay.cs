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


    private void Awake() {
        cg = GetComponent<CanvasGroup>();
        inventory.Clear();
    }

    private void OnEnable() {
        OnToggleDisplay();
    }

    private void Update() {
        DisplayItem(inventory.Count > 0 ? inventory[0] : null);
    }

    public void DisplayItem(BaseItem item) {
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
