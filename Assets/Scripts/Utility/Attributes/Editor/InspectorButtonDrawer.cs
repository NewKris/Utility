using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BaraGames.Utility.Attributes.Editor {
	[CustomPropertyDrawer(typeof(InspectorButton))]
	public class InspectorButtonDrawer : PropertyDrawer {
		private const float PADDING = 15;
		
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			Rect buttonRect = position;
			buttonRect.y += PADDING;
			buttonRect.height = base.GetPropertyHeight(property, label);

			if (GUI.Button(buttonRect, label.text)) {
				CallMethodByName(property.serializedObject.targetObject, property.stringValue);
			}
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
			return base.GetPropertyHeight(property, label) + PADDING * 2;
		}

		private static void CallMethodByName(Object instance, string methodName) {
			Type targetType = instance.GetType();
			
			MethodInfo targetMethod = targetType.GetMethod(methodName, 
				BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

			if (targetMethod == null) {
				Debug.LogError("The method " + methodName + " does not exist in the target object " + targetType);
				return;
			}
				
			targetMethod.Invoke(instance, Array.Empty<object>());
		}
	}
}