namespace NewKris.Utility.Timers {
    public class Timer {
        private float _time;

        public bool Elapsed => _time <= 0;

        internal Timer(float seconds = 0) {
            _time = seconds;
        }
        
        public void SetTimer(float time) {
            _time = time;
        }

        internal void Tick(float dt) {
            _time -= dt;
        }
    }
}