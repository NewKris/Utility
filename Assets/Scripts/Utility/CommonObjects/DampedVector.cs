using UnityEngine;

namespace VirtualDeviants.Utility.CommonObjects
{
	public struct DampedVector
	{
		private Vector3 _velocity;

		public Vector3 Current { get; private set; }
		public Vector3 Target { get; set; }

		public DampedVector(Vector3 startValue)
		{
			Current = startValue;
			Target = startValue;
			_velocity = Vector3.zero;
		}

		public void Tick(float damping)
		{
			Current = Vector3.SmoothDamp(Current, Target, ref _velocity, damping);
		}
	}
}