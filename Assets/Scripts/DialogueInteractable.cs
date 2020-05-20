using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteractable : Interactable
{
    [SerializeField]
    protected Dialogue dialogue;

    [SerializeField]
    private DialogueManager dialogueManager;

    public override bool OnInteraction() {
        dialogueManager.StartDialogue(dialogue);
        return true; // return true since we will freeze player action while dialogue is open
    }


}
