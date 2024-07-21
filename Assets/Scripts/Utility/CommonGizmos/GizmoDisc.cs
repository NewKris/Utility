using UnityEngine;

namespace BaraGames.Utility.CommonGizmos {
	public class GizmoDisc : MonoBehaviour {
		public Color color = Color.white;
		public float radius = 0.5f;

		[Space]
		
		public bool alwaysDraw = true;
		public bool wire = false;

		private void OnDrawGizmos() {
			if(!alwaysDraw) return;
			
			HandlesProxy.DrawDisc(transform.position, Vector3.up, radius, wire, color);
		}

		private void OnDrawGizmosSelected() {
			if(alwaysDraw) return;

			HandlesProxy.DrawDisc(transform.position, Vector3.up, radius, wire, color);
		}
	}
}