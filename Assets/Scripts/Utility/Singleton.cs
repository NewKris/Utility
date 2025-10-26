using UnityEngine;

namespace NewKris.Utility {
    public static class Singleton {
        public static bool SetSingleton<T>(ref T singleton, T instance) where T : MonoBehaviour {
            if (singleton == null) {
                singleton = instance;
                Object.DontDestroyOnLoad(instance.gameObject);
                return true;
            }

            Object.Destroy(instance);
            return false;
        }

        public static bool UnsetSingleton<T>(ref T singleton, T instance) where T : MonoBehaviour {
            if (singleton == instance) {
                singleton = null;
                return true;
            }

            return false;
        }
    }
}