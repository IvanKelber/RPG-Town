﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    [SerializeField] 
    private TMP_Text speakerText;

    [SerializeField] 
    private TMP_Text dialogueText;

    private void Awake() {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue) {
        gameObject.SetActive(true);
        this.speakerText.text = dialogue.speakerName;
        sentences.Clear();
        foreach(string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void EndDialogue() {
        gameObject.SetActive(false);
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
}