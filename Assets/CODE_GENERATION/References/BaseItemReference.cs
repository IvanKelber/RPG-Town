using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class BaseItemReference : BaseReference<BaseItem, BaseItemVariable>
	{
	    public BaseItemReference() : base() { }
	    public BaseItemReference(BaseItem value) : base(value) { }
	}
}