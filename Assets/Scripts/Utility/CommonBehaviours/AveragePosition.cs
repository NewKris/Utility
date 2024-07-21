using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BaraGames.Utility.CommonBehaviours {
    /// <summary>
    /// Follows the average position of its assigned targets
    /// </summary>
    public class AveragePosition : MonoBehaviour {
        public List<Transform> targets;
        
        [Space]
        public bool lockXAxis;
        public bool lockYAxis;
        public bool lockZAxis;

        private float _invCount;

        private void Start() {
            if (targets.Count == 0) return;

            _invCount = 1f / targets.Count;
        }

        private void LateUpdate() {
            Vector3 averagePosition = targets.Aggregate(
                Vector3.zero, 
                (current, target) => current + target.position
            );

            averagePosition *= _invCount;

            Vector3 delta = averagePosition - transform.position;
            Vector3 scalar = new Vector3(
                x: lockXAxis ? 0 : 1,
                y: lockYAxis ? 0 : 1,
                z: lockZAxis ? 0 : 1
            );

            delta = Vector3.Scale(delta, scalar);
            transform.position += delta;
        }

        public void AddTarget(Transform target) {
            targets.Add(target);
            _invCount = 1f / targets.Count;
        }

        public void RemoveTarget(Transform target) {
            targets.Remove(target);

            if (targets.Count == 0) {
                _invCount = 0;
            }
            else {
                _invCount = 1f / targets.Count;
            }
        }

    }
}
