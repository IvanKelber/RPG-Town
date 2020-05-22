using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "BaseItem")]
	public sealed class BaseItemGameEventListener : BaseGameEventListener<BaseItem, BaseItemGameEvent, BaseItemUnityEvent>
	{
	}
}