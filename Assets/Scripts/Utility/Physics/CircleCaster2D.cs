using System;
using UnityEngine;

namespace NewKris.Utility.Physics {
    public class CircleCaster2D : PhysicsCaster2D {
        public float radius = 0.5f;
        
        public override bool Evaluate(out RaycastHit2D hit) {
            hit = Physics2D.CircleCast(transform.position, radius, GetDirection(), length, mask);
            return hit.collider != null;
        }

        private void OnDrawGizmos() {
            Vector2 p1 = transform.position;
            Vector2 p2 = p1 + GetDirection() * length;
            
            HandlesProxy.DrawDisc(p1, Vector3.forward, radius, true, Color.red, thickness);
            HandlesProxy.DrawDisc(p2, Vector3.forward, radius, true, Color.red, thickness);
            HandlesProxy.DrawLine(p1, p2, thickness, false, Color.red);

            if (Evaluate(out RaycastHit2D hit)) {
                Vector3 p3 = p1 + GetDirection() * hit.distance;
                HandlesProxy.DrawDisc(p3, Vector3.forward, radius, true, Color.green, thickness);
            }
        }
    }
}