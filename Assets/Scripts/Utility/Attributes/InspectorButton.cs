using UnityEngine;

namespace VirtualDeviants.Utility.Attributes
{
	public class InspectorButton : PropertyAttribute
	{

		public string buttonName;
		public string methodName;

		public InspectorButton(string btnName, string targetMethod)
		{
			buttonName = btnName;
			methodName = targetMethod;
		}
	}
}