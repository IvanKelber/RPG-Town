using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue 
{
    public string speakerName;
    [TextArea(3,10)]
    public string[] sentences;

    public Dialogue() {
        
    }

    public Dialogue(string speakerName, string[] sentences) {
        this.speakerName = speakerName;
        this.sentences = sentences;
    }

}
