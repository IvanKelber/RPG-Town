using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public abstract bool OnInteraction(EndDialogueCallback cb);

    public delegate void EndDialogueCallback();
}
