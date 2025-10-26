using UnityEngine;

namespace NewKris.Utility {
    public static class MathU {
        /// <summary>
        /// Returns 1 for all positive values and -1 for all negative values
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float Normalize(float value) {
            return Mathf.Sign(value);
        }
    }
}