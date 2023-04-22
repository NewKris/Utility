using UnityEngine;

namespace BaraGames.Utility.CommonBehaviours
{
    
    /// <summary>
    /// Aligns the forward axis with the direction to a target
    /// </summary>
    
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
