using UnityEngine;

namespace BaraGames.Utility.CommonGizmos {
	public class GizmoArrow : MonoBehaviour {
		public Color color = Color.red;
		public float size = 2;

		public Vector3 direction = Vector3.forward;
		public bool local = true;

		public bool alwaysDraw;

		private void OnDrawGizmos() {
			if(!alwaysDraw) return;

			Quaternion rotation = local ? transform.rotation : Quaternion.identity;
			HandlesProxy.DrawArrow(transform.position, direction, rotation, size, color);
		}

		private void OnDrawGizmosSelected() {
			if(alwaysDraw) return;
			
			Quaternion rotation = local ? transform.rotation : Quaternion.identity;
			HandlesProxy.DrawArrow(transform.position, direction, rotation, size, color);
		}
	}	
}