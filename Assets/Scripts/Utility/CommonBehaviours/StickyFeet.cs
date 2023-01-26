using System;
using UnityEngine;

namespace VirtualDeviants.Utility.CommonBehaviours
{
    /// <summary>
    /// Makes sure an object is always stuck to the ground.
    /// 
    /// This is useful for character models whose feet should
    /// be planted on the ground.
    ///
    /// This is to counteract the effect where a character
    /// floats/clips on the ground due to the collider.
    /// </summary>
    public class StickyFeet : MonoBehaviour
    {

        public float rayStartHeight;
        public LayerMask groundMask;

        private Vector3 RayStart => transform.position + Vector3.up * rayStartHeight;
        private Vector3 RayDirection => Vector3.down;
        
        private void LateUpdate()
        {
            RaycastHit hit;
            if(!Physics.Raycast(RayStart, RayDirection, out hit, 1, groundMask)) return;

            Vector3 pos = transform.position;
            pos.y = hit.point.y;
            transform.position = pos;

        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(RayStart, RayDirection);
        }
#endif
    }
}
