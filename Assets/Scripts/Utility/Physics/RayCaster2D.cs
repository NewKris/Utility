using UnityEngine;

namespace NewKris.Utility.Physics {
    public class RayCaster2D : PhysicsCaster2D {
        public override bool Evaluate(out RaycastHit2D hit) {
            hit = Physics2D.Raycast(transform.position, GetDirection(), length, mask);
            return hit.collider != null;
        }
        
        private void OnDrawGizmos() {
            Vector2 p1 = transform.position;
            Vector2 p2 = p1 + GetDirection() * length;
            HandlesProxy.DrawLine(p1, p2, thickness, false, Color.red);

            if (Evaluate(out RaycastHit2D hit)) {
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(hit.point, 0.1f);
            }
        }
    }
}