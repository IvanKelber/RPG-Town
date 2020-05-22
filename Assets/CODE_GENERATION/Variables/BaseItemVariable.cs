using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class BaseItemEvent : UnityEvent<BaseItem> { }

	[CreateAssetMenu(
	    fileName = "BaseItemVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Inventory",
	    order = 120)]
	public class BaseItemVariable : BaseVariable<BaseItem, BaseItemEvent>
	{
	}
}