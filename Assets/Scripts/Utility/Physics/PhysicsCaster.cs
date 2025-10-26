using UnityEngine;

namespace NewKris.Utility.Physics {
    public abstract class PhysicsCaster : MonoBehaviour {
        [Header("Debug")] 
        public float thickness = 1;
        
        [Space(25)]
        
        public Vector3 direction = Vector3.down;
        public float length = 1;
        public LayerMask mask = 1;
        public bool localDirection;
        
        public abstract bool Evaluate(out RaycastHit hit);
        
        protected Vector3 GetDirection() {
            return (localDirection ? transform.TransformDirection(direction) : direction).normalized;
        }
    }
}