using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ScriptableObjectArchitecture;

public class ItemSlot : MonoBehaviour
{
    [SerializeField]
    private Image itemImage;    

    [SerializeField]
    private ItemCollection inventory;

    [SerializeField]
    private BaseItemGameEvent itemSelected;
    BaseItem item;


    public void AddItem(BaseItem item) {
        this.item = item;
        itemImage.sprite = item.sprite;
        itemImage.enabled = true;
    }

    public void RemoveItem() {
        this.item = null;
        itemImage.sprite = null;
        itemImage.enabled = false;
    }

    public void OnRemoveButtonClicked() {
        inventory.Remove(item);
    }

    public void OnItemSelected() {
        itemSelected.Raise(item);
    }

}
