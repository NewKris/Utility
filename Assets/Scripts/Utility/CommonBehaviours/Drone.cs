using BaraGames.Utility.Attributes;
using BaraGames.Utility.CommonObjects;
using UnityEngine;

namespace BaraGames.Utility.CommonBehaviours
{
    /// <summary>
    /// Follows a target with soft damping.
    /// </summary>
    public class Drone : MonoBehaviour
    {

        public Transform target;
        public float damping;
        [InspectorButton("Set Offset", "SetOffset")]
        public Vector3 offset;

        private DampedVector _position;

        private void Awake()
        {
            _position = new DampedVector(target.position + offset);
        }

        private void LateUpdate()
        {
            _position.Target = target.position + offset;
            _position.Tick(damping);
            transform.position = _position.Current;
        }

        private void SetOffset()
        {
            offset = transform.position - target.position;
        }
        
    }
}
