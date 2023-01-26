using UnityEngine;
using VirtualDeviants.Utility.CommonObjects;

namespace VirtualDeviants.Utility.CommonBehaviours
{
    /// <summary>
    /// Follows a target with soft damping.
    /// </summary>
    public class Drone : MonoBehaviour
    {

        public Transform target;
        public float damping;

        private DampedVector _position;

        private void Awake()
        {
            _position = new DampedVector(target.position);
        }

        private void LateUpdate()
        {
            _position.Target = target.position;
            _position.Tick(damping);
            transform.position = _position.Current;
        }
    }
}
