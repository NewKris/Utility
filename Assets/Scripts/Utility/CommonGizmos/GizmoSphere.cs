using UnityEngine;

namespace BaraGames.Utility.CommonGizmos {
	public class GizmoSphere : MonoBehaviour {
		public Color color = Color.red;
		public float radius = 0.2f;
		
		[Space]
		
		public bool alwaysDraw = true;
		public bool wire = false;

		private void OnDrawGizmos() {
			if(!alwaysDraw) return;
			
			HandlesProxy.DrawSphere(transform.position, radius, wire, color);
		}

		private void OnDrawGizmosSelected() {
			if(alwaysDraw) return;
			
			HandlesProxy.DrawSphere(transform.position, radius, wire, color);
		}
		
	}
}
