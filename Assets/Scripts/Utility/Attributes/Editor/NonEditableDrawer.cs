using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace VirtualDeviants.Utility.Attributes.Editor
{

    [CustomPropertyDrawer(typeof(NonEditable))]
    public class NonEditableDrawer : PropertyDrawer
    {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            string text = property.displayName + ": ";

            switch (property.propertyType)
            {
                case SerializedPropertyType.String:
                    text += property.stringValue;
                    break;
                case SerializedPropertyType.Integer:
                    text += property.intValue;
                    break;
                case SerializedPropertyType.Float:
                    text += property.floatValue;
                    break;
                case SerializedPropertyType.Vector2:
                    text += property.vector2Value;
                    break;
                case SerializedPropertyType.Vector3:
                    text += property.vector3Value;
                    break;
                default:
                    text = "Attribute not applicable to this Property Type!";
                    break;
            }

            EditorGUI.LabelField(position, text);
        }

    }
}
