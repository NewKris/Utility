using System.Collections.Generic;
using UnityEngine;

namespace NewKris.Utility.Timers {
    public class TimerManager : MonoBehaviour {
        private static TimerManager Instance;
        private static HashSet<Timer> Timers = new HashSet<Timer>();
        
        public static Timer CreateTimer(float seconds = 0) {
            Timer timer = new Timer(seconds);
            Timers.Add(timer);
            return timer;
        }

        public static void RemoveTimer(Timer timer) {
            Timers.Remove(timer);
        }
        
        private void Awake() {
            Singleton.SetSingleton(ref Instance, this);
        }

        private void OnDestroy() {
            Singleton.UnsetSingleton(ref Instance, this);
        }

        private void Update() {
            float dt = Time.deltaTime;
            
            foreach (Timer timer in Timers) {
                timer.Tick(dt);
            }
        }
    }
}