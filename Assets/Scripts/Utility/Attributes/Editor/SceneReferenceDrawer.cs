using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace VirtualDeviants.Utility.Attributes.Editor
{
	[CustomPropertyDrawer(typeof(SceneReference))]
	public class SceneReferenceDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{

			string[] levelScenes = GetLevelScenes();

			if (levelScenes.Length == 0)
			{
				EditorGUI.LabelField(position, "Missing Scenes in Build");
				return;
			}

			int selected = Array.IndexOf(levelScenes, property.stringValue);
			selected = Mathf.Max(0, selected);
			selected = EditorGUI.Popup(position, property.displayName, selected, levelScenes);

			property.stringValue = levelScenes[selected];

		}

		private string[] GetLevelScenes()
		{
			EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;
			List<string> levelScenes = new List<string>();
			foreach (EditorBuildSettingsScene scene in scenes)
			{
				if(!scene.path.Contains("Levels")) continue;

				string sceneName = scene.path.Split('/')[^1].Replace(".unity", "");
				levelScenes.Add(sceneName);
			}

			return levelScenes.ToArray();
		}
	}
}