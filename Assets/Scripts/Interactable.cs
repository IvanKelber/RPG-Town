using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
  
    public string Name;

    public virtual void OnInteraction() {
        Debug.Log("Interacting with " + Name);
    }


}
