using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class RightClickHandler : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent onRightClick;

    [SerializeField]
    public void OnPointerClick(PointerEventData eventData) {
        if(eventData.button == PointerEventData.InputButton.Right) {
            onRightClick.Invoke();
        }
    }
}
