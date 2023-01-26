using UnityEngine;

namespace VirtualDeviants.Utility.CommonBehaviours
{
    [ExecuteInEditMode]
    public class Stare : MonoBehaviour
    {

        public Transform target;

        private void LateUpdate()
        {
            if (target == null) return;

            transform.LookAt(target);
        }

    }
}
