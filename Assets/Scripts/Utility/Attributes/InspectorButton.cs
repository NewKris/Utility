using UnityEngine;

namespace VirtualDeviants.Utility.Attributes
{
	public class InspectorButton : PropertyAttribute
	{

		public readonly string buttonName;
		public readonly string methodName;

		public InspectorButton(string btnName, string targetMethod)
		{
			buttonName = btnName;
			methodName = targetMethod;
		}
	}
}