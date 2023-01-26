using UnityEngine;

namespace VirtualDeviants.Utility.CommonGizmos
{
#if UNITY_EDITOR
	public class GizmoArrow : MonoBehaviour
	{

		public Color color = Color.red;
		public float size = 2;

		public Vector3 direction = Vector3.forward;
		public bool local = true;

		public bool alwaysDraw;

		private void OnDrawGizmos()
		{
			if(!alwaysDraw) return;
			DrawArrow();
		}

		private void OnDrawGizmosSelected()
		{
			if(alwaysDraw) return;
			DrawArrow();
		}

		private void DrawArrow()
		{
			UnityEditor.Handles.color = color;

			Quaternion rotation;

			if (local) rotation = Quaternion.LookRotation(transform.TransformDirection(direction), transform.up);
			else rotation = Quaternion.LookRotation(direction, Vector3.up);
			
			UnityEditor.Handles.ArrowHandleCap(0, transform.position, rotation, size, EventType.Repaint);
		}

	}	
#endif

}