using UnityEngine;

namespace VirtualDeviants.Utility.CommonGizmos
{
#if UNITY_EDITOR
	public class GizmoDisc : MonoBehaviour
	{

		public Color color = Color.white;
		public float radius = 0.5f;

		[Space]
		
		public bool alwaysDraw = true;
		public bool wire = false;

		private void OnDrawGizmos()
		{
			if(!alwaysDraw) return;
			DrawDisc();
		}

		private void OnDrawGizmosSelected()
		{
			if(alwaysDraw) return;
			DrawDisc();
		}

		private void DrawDisc()
		{
			UnityEditor.Handles.color = color;
			
			if(wire) UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.up, radius);
			else UnityEditor.Handles.DrawSolidDisc(transform.position, Vector3.up, radius);
		}

	}
#endif
}