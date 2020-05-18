using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
public class PlayerInventoryManager : MonoBehaviour
{
    [SerializeField]
    private ObjectCollection inventory;

    public void AddItem(BaseItem item) {
        inventory.Add(item);
    }

    public void RemoveItem(BaseItem item) {
        inventory.Remove(item);
    }
}
