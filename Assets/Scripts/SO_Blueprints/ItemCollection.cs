using UnityEngine;
using System.Collections.Generic;
using ScriptableObjectArchitecture;

[CreateAssetMenu(
    fileName = "ItemCollection.asset",
    menuName = SOArchitecture_Utility.COLLECTION_SUBMENU + "Item",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 6)]
[System.Serializable]
public class ItemCollection : ScriptableObject
{


    public int Count {
        get {return items.Count;} 
    }
    public int capacity;
    public GameEvent itemCollectionChanged;

    private List<BaseItem> items;

    public bool Add(BaseItem item) {
        Debug.Log("attempting to add" + item.Name);
        Debug.Log(this.Count + "::" + capacity);
        if(items.Count < capacity && !items.Contains(item)) {
            items.Add(item);
            itemCollectionChanged.Raise();
            Debug.Log("added");
            return true;
        }
        Debug.Log("failed to add");
        return false;
    }

    public void Remove(BaseItem item) {
        items.Remove(item);
        itemCollectionChanged.Raise();
    }

    public void Clear() {
        items = new List<BaseItem>();
        itemCollectionChanged.Raise();
    }

    public BaseItem Get(int index) {
        if (index < Count) {
            return items[index];
        }
        return null;
    }

    public int GetIndexOfItem(BaseItem item) {
        return items.IndexOf(item);
    }


} 
