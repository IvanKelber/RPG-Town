using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteractable : Interactable
{
    [SerializeField]
    private Dialogue dialogue;

    [SerializeField]
    private DialogueManager dialogueManager;
    public override void OnInteraction() {
        base.OnInteraction();
        dialogueManager.StartDialogue(dialogue);
    }
}
