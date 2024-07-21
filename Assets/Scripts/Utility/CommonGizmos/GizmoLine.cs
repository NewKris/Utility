using UnityEngine;

namespace BaraGames.Utility.CommonGizmos {
	public class GizmoLine : MonoBehaviour {
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

		private void OnDrawGizmos() {
			if(!alwaysDraw) return;
			
			DrawLine();
		}

		private void OnDrawGizmosSelected() {
			if(alwaysDraw) return;
			
			DrawLine();
		}

		private void DrawLine() {
			if(!start || !end) return;
			
			HandlesProxy.DrawLine(start.position, end.position, thickness, dotted, color);

			if (toArrow) {
				Vector3 direction = end.position - start.position;
				Vector3 pos = end.position - direction.normalized * 0.5f;
				
				HandlesProxy.DrawArrow(pos, direction, Quaternion.identity, 0.5f, color);
			}
			
			if (fromArrow) {
				Vector3 direction = start.position - end.position;
				Vector3 pos = start.position - direction.normalized * 0.5f;
				
				HandlesProxy.DrawArrow(pos, direction, Quaternion.identity, 0.5f, color);
			}
		}
	}
}
