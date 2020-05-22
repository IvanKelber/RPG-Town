﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemSlot : MonoBehaviour
{
    [SerializeField]
    private Image itemImage;    
    [SerializeField]
    private Button removeButton;
    [SerializeField]
    private ItemCollection inventory;
    BaseItem item;

    public void AddItem(BaseItem item) {
        this.item = item;
        itemImage.sprite = item.sprite;
        itemImage.enabled = true;
        removeButton.interactable = true;
    }

    public void RemoveItem() {
        this.item = null;
        itemImage.sprite = null;
        itemImage.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButtonClicked() {
        inventory.Remove(item);
    }

}
