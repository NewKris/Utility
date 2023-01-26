using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace VirtualDeviants.Utility.Editor
{
    public class ExtendedEditorWindow : EditorWindow
    {

        protected SerializedObject serializedObject;
        protected SerializedProperty currentProperty;

        

        protected void DrawProperties(SerializedProperty property, bool drawChildren)
        {
            string lastPropertyPath = "";
            foreach (SerializedProperty child in property)
            {
                if(child.isArray && child.propertyType == SerializedPropertyType.Generic)
                {
                    EditorGUILayout.BeginHorizontal();
                    child.isExpanded = EditorGUILayout.Foldout(child.isExpanded, child.displayName);
                    EditorGUILayout.EndHorizontal();

                    if (child.isExpanded)
                    {
                        EditorGUI.indentLevel++;
                        DrawProperties(child, drawChildren);
                        EditorGUI.indentLevel--;
                    }

                }
                else
                {
                    if (!string.IsNullOrEmpty(lastPropertyPath) && child.propertyPath.Contains(lastPropertyPath)) 
                        continue;

                    lastPropertyPath = child.propertyPath;
                    EditorGUILayout.PropertyField(child, drawChildren);
                }
            }
        }

    }
}
