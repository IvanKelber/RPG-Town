using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseItem : ScriptableObject
{

    public string Name;
    [TextArea(2,3)]
    public string Description;

    public Sprite sprite;
    public virtual void OnItemUse() {
        Debug.Log("Used item " + Name);
    }


}
