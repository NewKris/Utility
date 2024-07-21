using BaraGames.Utility.Attributes;
using BaraGames.Utility.CommonObjects;
using UnityEngine;

namespace BaraGames.Utility.CommonBehaviours {
    /// <summary>
    /// Follows a target with soft damping.
    /// </summary>
    public class Drone : MonoBehaviour {
        public Transform target;
        public float damping;

        private DampedVector _position;

        private void Awake() {
            _position = new DampedVector(target.position);
        }

        private void LateUpdate() {
            if (!target) return;
            
            _position.Target = target.position;
            transform.position = _position.Tick(damping);
        }
    }
}
