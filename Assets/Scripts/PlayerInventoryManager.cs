using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
public class PlayerInventoryManager : MonoBehaviour
{
    [SerializeField]
    private ItemCollection inventory;

    public void AddItem(BaseItem item) {
        Debug.Log("adding item: "  + item.Name);
        inventory.Add(item);
    }

    public void RemoveItem(BaseItem item) {
        inventory.Remove(item);
    }

    public void PrintAllItems() {
        string s = "";
        foreach(BaseItem item in inventory) {
            s += item.Name + ",";
        }
        Debug.Log("Items in inventory: " + s);
    }
}
