using UnityEngine;

namespace BaraGames.Utility.CommonObjects {
	public struct DampedVector
	{
		private Vector3 _velocity;

		public Vector3 Current { get; private set; }
		public Vector3 Target { get; set; }

		public DampedVector(Vector3 startValue) {
			Current = startValue;
			Target = startValue;
			_velocity = Vector3.zero;
		}

		public Vector3 Tick(float damping) {
			float deltaTime = Time.deltaTime;
			return Tick(damping, deltaTime);
		}
		
		public Vector3 Tick(float damping, float deltaTime) {
			Current = Vector3.SmoothDamp(Current, Target, ref _velocity, damping, Mathf.Infinity, deltaTime);
			return Current;
		}
	}
}