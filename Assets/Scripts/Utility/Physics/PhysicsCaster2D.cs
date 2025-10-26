using UnityEngine;

namespace NewKris.Utility.Physics {
    public abstract class PhysicsCaster2D : MonoBehaviour {
        [Header("Debug")] 
        public float thickness = 1;
        
        [Space(25)]
        
        public Vector2 direction = Vector2.down;
        public float length = 1;
        public LayerMask mask = 1;
        public bool localDirection;
        
        public abstract bool Evaluate(out RaycastHit2D hit);
        
        protected Vector2 GetDirection() {
            Vector2 dir = localDirection ? transform.TransformDirection(direction) : direction;
            return dir.normalized;
        }
    }
}