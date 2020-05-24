using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ScriptableObjectArchitecture;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private Image itemImage;    

    [SerializeField]
    private ItemCollection inventory;

    [SerializeField]
    private BaseItemGameEvent itemSelected;
    BaseItem item;

    [SerializeField]
    private UnityEvent onRightClick;
    public void OnPointerClick(PointerEventData eventData) {
        if(eventData.button == PointerEventData.InputButton.Right) {
            onRightClick.Invoke();
        }
    }

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
