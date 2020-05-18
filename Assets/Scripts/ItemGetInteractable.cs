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
        this.dialogue.sentences[0] = "You found a " + item.Name + "!";
        inventoryManager.AddItem(item);
        Destroy(this);
        return base.OnInteraction(cb);
    }

}
