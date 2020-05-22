using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SelectedItem : MonoBehaviour
{
    BaseItem item;

    [SerializeField]
    Button useItemButton;
    [SerializeField]
    TMP_Text useItemButtonText;

    [SerializeField]
    TMP_Text itemName;

    [SerializeField]
    TMP_Text itemDescription;

    [SerializeField]
    Image itemImage;


    public void SetItem(BaseItem item) {
        this.item = item;
        if(item == null) {
            useItemButton.interactable = false;
            useItemButtonText.text = "";
            itemName.text = "";
            itemDescription.text = "";
            itemImage.sprite = null;
            itemImage.color = new Color(0,0,0,0);
            return;
        }
        useItemButton.interactable = true;
        useItemButtonText.text = item.useText;
        itemName.text = item.Name;
        itemDescription.text = item.Description;
        itemImage.sprite = item.sprite;
        itemImage.color = new Color(1,1,1,1);
    }

    public void OnItemUse() {
        if(item) {
            item.OnItemUse();
        }
    }



}
