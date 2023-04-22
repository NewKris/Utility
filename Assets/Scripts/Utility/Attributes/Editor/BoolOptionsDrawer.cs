using UnityEditor;
using UnityEngine;

namespace BaraGames.Utility.Attributes.Editor
{
	[CustomPropertyDrawer(typeof(BoolOptions))]
	public class BoolOptionsDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			BoolOptions boolOptions = attribute as BoolOptions;
			string[] options = { boolOptions.trueOption, boolOptions.falseOption };

			int currentSelected = property.boolValue ? 0 : 1;
			currentSelected = EditorGUI.Popup(position, boolOptions.inspectorName, currentSelected, options);

			property.boolValue = currentSelected == 0;
		}
	}
}