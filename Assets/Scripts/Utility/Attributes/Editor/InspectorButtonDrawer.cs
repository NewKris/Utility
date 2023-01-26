using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace VirtualDeviants.Utility.Attributes.Editor
{
	[CustomPropertyDrawer(typeof(InspectorButton))]
	public class InspectorButtonDrawer : PropertyDrawer
	{

		private const float ButtonHeight = 25;
		private const float Padding = 15;
		
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{

			InspectorButton button = attribute as InspectorButton;
			
			Rect buttonRect = position;
			buttonRect.y += Padding;
			buttonRect.height = ButtonHeight;
			
			if(GUI.Button(buttonRect, button.buttonName))
				CallMethodByName(property.serializedObject.targetObject, button.methodName);
			
			position.y += ButtonHeight + Padding;
			EditorGUI.PropertyField(position, property, label, true);
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return base.GetPropertyHeight(property, label) + ButtonHeight + Padding;
		}

		private static void CallMethodByName(Object instance, string methodName)
		{
			Type targetType = instance.GetType();
			
			MethodInfo targetMethod = targetType.GetMethod(methodName, 
				BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

			if (targetMethod == null)
			{
				Debug.LogError("The method " + methodName + " does not exist in the target object " + targetType);
				return;
			}
				
			targetMethod.Invoke(instance, Array.Empty<object>());
		}
	}
}