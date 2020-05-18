using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ScriptableObjectArchitecture;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField]
    ItemCollection inventory;

        [SerializeField]
        SpriteRenderer itemSprite;
        [SerializeField]
        TMP_Text itemName;
        [SerializeField]
        TMP_Text itemDescription;


    private void OnEnable() {
        DisplayItem(inventory.Count > 0 ? inventory[0] : null);
    }


    public void DisplayItem(BaseItem item) {
        if(item == null) {
            return;
        }
        itemName.text = item.Name;
        itemDescription.text = item.Description;
        itemSprite.sprite = item.sprite;
    }
}
