using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
public class DialogueInteractable : Interactable
{
    [SerializeField]
    protected Dialogue dialogue;

    [SerializeField]
    private DialogueGameEvent startDialogueEvent;

    [SerializeField]
    private BoolGameEvent freezePlayerEvent;

    public override void OnInteraction() {
        startDialogueEvent.Raise(dialogue);
        freezePlayerEvent.Raise(true);
    }


}
