using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseItem : ScriptableObject
{

    public string Name;
    [TextArea(2,3)]
    public string Description;

    public string FoundText;

    public Sprite sprite;
    public virtual void OnItemUse() {
        Debug.Log("Used item " + Name);
    }

    public Dialogue GetItemFoundDialogue() {
        
        return new Dialogue("", 
            new string[] {
                "You found a" + (StartsWithVowel()? "n ": " ") + Name,
                FoundText    
            });
    }

    private bool StartsWithVowel() {
        string vowels = "aeiou";
        return vowels.IndexOf(Name.ToLower().ToCharArray()[0]) >= 0;
    }

}
