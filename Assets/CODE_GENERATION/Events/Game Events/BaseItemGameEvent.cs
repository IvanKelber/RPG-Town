using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "BaseItemGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "Inventory/ItemGameEvent",
	    order = 120)]
	public sealed class BaseItemGameEvent : GameEventBase<BaseItem>
	{
	}
}