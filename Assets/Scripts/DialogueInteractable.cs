using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteractable : Interactable
{
    [SerializeField]
    private Dialogue dialogue;

    [SerializeField]
    private DialogueManager dialogueManager;

    public override bool OnInteraction(EndDialogueCallback cb) {
        dialogueManager.StartDialogue(dialogue, cb);
        return true; // return true since we will freeze player action while dialogue is open
    }


}
