using System;
using UnityEngine;

namespace NewKris.Utility.Physics {
    public class SphereCaster : PhysicsCaster {
        public float radius = 0.5f;
        
        public override bool Evaluate(out RaycastHit hit) {
            Ray ray = new Ray(transform.position, GetDirection());
            return UnityEngine.Physics.SphereCast(ray, radius, out hit, length, mask);
        }

        private void OnDrawGizmos() {
            Vector3 p1 = transform.position;
            Vector3 p2 = p1 + GetDirection() * length;
            
            HandlesProxy.DrawSphere(p1, radius, true, Color.red, thickness);
            HandlesProxy.DrawSphere(p2, radius, true, Color.red, thickness);
            HandlesProxy.DrawLine(p1, p2, thickness, false, Color.red);

            if (Evaluate(out RaycastHit hit)) {
                Vector3 p3 = p1 + GetDirection() * hit.distance;
                HandlesProxy.DrawSphere(p3, radius, true, Color.green, thickness);
            }
        }
    }
}