using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGetInteractable : DialogueInteractable
{

    [SerializeField]
    BaseItem item;
    [SerializeField]
    PlayerInventoryManager inventoryManager;
    public override bool OnInteraction(EndDialogueCallback cb) {
        this.dialogue.sentences = new string[2] {"You found a " + item.Name + "!", item.Description};
        inventoryManager.AddItem(item);
        Destroy(this);
        return base.OnInteraction(cb);
    }

}
