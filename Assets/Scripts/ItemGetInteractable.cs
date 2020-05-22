using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class ItemGetInteractable : Interactable
{

    [SerializeField]
    BaseItem item;
    [SerializeField]
    DialogueGameEvent startDialogueEvent;

    [SerializeField]
    BoolGameEvent freezePlayerEvent;

    [SerializeField]
    ItemCollection inventory;

    public override void OnInteraction() {
        inventory.Add(item);
        Destroy(this);
        startDialogueEvent.Raise(item.GetItemFoundDialogue());
        freezePlayerEvent.Raise(true);
    }

}
