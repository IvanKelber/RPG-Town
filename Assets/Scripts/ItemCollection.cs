using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(
        fileName = "ItemCollection.asset",
        menuName = SOArchitecture_Utility.COLLECTION_SUBMENU + "Item",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 6)]
    public class ItemCollection : Collection<BaseItem>
    {
    } 
}