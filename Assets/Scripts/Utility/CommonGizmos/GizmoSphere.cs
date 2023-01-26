using UnityEngine;

namespace VirtualDeviants.Utility.CommonGizmos
{
	#if UNITY_EDITOR
	public class GizmoSphere : MonoBehaviour
	{
		public Color color = Color.red;
		public float radius = 0.2f;
		
		[Space]
		
		public bool alwaysDraw = true;
		public bool wire = false;

		private void OnDrawGizmos()
		{
			if(!alwaysDraw) return;
			DrawSphere();
		}

		private void OnDrawGizmosSelected()
		{
			if(alwaysDraw) return;
			DrawSphere();
		}

		private void DrawSphere()
		{
			Gizmos.color = color;
			
			if(wire) Gizmos.DrawWireSphere(transform.position, radius);
			else Gizmos.DrawSphere(transform.position, radius);
		}
		
	}
	#endif
}