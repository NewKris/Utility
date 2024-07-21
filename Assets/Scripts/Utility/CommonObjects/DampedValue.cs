using UnityEngine;

namespace BaraGames.Utility.CommonObjects {
	public struct DampedValue {
		private float _velocity;

		public float Current { get; private set; }
		public float Target { get; set; }

		public DampedValue(float startValue) {
			Current = startValue;
			Target = startValue;
			_velocity = 0;
		}

		public float Tick(float damping) {
			float deltaTime = Time.deltaTime;
			return Tick(damping, deltaTime);
		}
		
		public float Tick(float damping, float deltaTime) {
			Current = Mathf.SmoothDamp(Current, Target, ref _velocity, damping, Mathf.Infinity, deltaTime);
			return Current;
		}

		public float TickAngle(float damping) {
			float deltaTime = Time.deltaTime;
			return TickAngle(damping, deltaTime);
		}
		
		public float TickAngle(float damping, float deltaTime) {
			Current = Mathf.SmoothDampAngle(Current, Target, ref _velocity, damping, Mathf.Infinity, deltaTime);
			return Current;
		}
	}
}