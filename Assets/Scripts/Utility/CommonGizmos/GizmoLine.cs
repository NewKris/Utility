using UnityEngine;

namespace BaraGames.Utility.CommonGizmos
{

#if UNITY_EDITOR
	public class GizmoLine : MonoBehaviour
	{

		public Transform start;
		public Transform end;

		[Space]
		
		public Color color = Color.red;
		public float thickness = 1;

		[Space]

		public bool alwaysDraw = true;
		public bool dotted = false;
		public bool toArrow = false;
		public bool fromArrow = false;

		private void OnDrawGizmos()
		{
			if(!alwaysDraw) return;
			DrawLine();
		}

		private void OnDrawGizmosSelected()
		{
			if(alwaysDraw) return;
			DrawLine();
		}

		private void DrawLine()
		{
			if(!start || !end) return;
			
			UnityEditor.Handles.color = color;
			
			if(dotted) UnityEditor.Handles.DrawDottedLine(start.position, end.position, thickness);
			else UnityEditor.Handles.DrawLine(start.position, end.position, thickness);

			if (toArrow)
			{
				Vector3 direction = end.position - start.position;
				Quaternion arrowRotation = Quaternion.LookRotation(direction);
				UnityEditor.Handles.ArrowHandleCap(0, end.position - direction.normalized * 2, arrowRotation, 2, EventType.Repaint);
			}
			
			if (fromArrow)
			{
				Vector3 direction = start.position - end.position;
				Quaternion arrowRotation = Quaternion.LookRotation(direction);
				UnityEditor.Handles.ArrowHandleCap(0, start.position - direction.normalized * 2, arrowRotation, 2, EventType.Repaint);
			}
		}
		

	}
#endif
}