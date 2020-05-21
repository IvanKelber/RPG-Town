using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "Dialogue")]
	public sealed class DialogueGameEventListener : BaseGameEventListener<Dialogue, DialogueGameEvent, DialogueUnityEvent>
	{
	}
}