using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ScriptableObjectArchitecture;
public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    [SerializeField] 
    private TMP_Text speakerText;

    [SerializeField] 
    private TMP_Text dialogueText;

    [SerializeField]
    private BoolGameEvent playerFrozenEvent;

    [SerializeField]
    private UserInput input;
    private CanvasGroup cg;
    private bool activated = false;
    private void Awake() {
        sentences = new Queue<string>();
        cg = GetComponent<CanvasGroup>();
        OnDisplayDialogue(0f);
    }

    private void Update() {
        if(activated && input.ActionKey()) {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue) {
        OnDisplayDialogue(1f);
        this.speakerText.text = dialogue.speakerName;
        sentences.Clear();
        foreach(string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void EndDialogue() {
        OnDisplayDialogue(0f);
        playerFrozenEvent.Raise(false);
    }

    public void DisplayNextSentence() {
        if(sentences.Count == 0) {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(DisplayLetters(sentence));
    }

    IEnumerator DisplayLetters(string sentence) {
        dialogueText.text = "";
        foreach(char c in sentence.ToCharArray()) {
            dialogueText.text += c;

            yield return null;
        }
    }

    public void OnDisplayDialogue(float alpha) {
        cg.alpha = alpha;
        activated = alpha > 0;
    }
}
