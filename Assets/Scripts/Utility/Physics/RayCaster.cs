using System;
using UnityEngine;

namespace NewKris.Utility.Physics {
    public class RayCaster : PhysicsCaster {
        public override bool Evaluate(out RaycastHit hit) {
            Ray ray = new Ray(transform.position, GetDirection());
            return UnityEngine.Physics.Raycast(ray, out hit, length, mask);
        }

        private void OnDrawGizmos() {
            Vector3 p1 = transform.position;
            Vector3 p2 = p1 + GetDirection() * length;
            HandlesProxy.DrawLine(p1, p2, thickness, false, Color.red);

            if (Evaluate(out RaycastHit hit)) {
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(hit.point, 0.1f);
            }
        }
    }
}