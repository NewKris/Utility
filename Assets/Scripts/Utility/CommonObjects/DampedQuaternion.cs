using UnityEngine;

namespace BaraGames.Utility.CommonObjects
{
	public struct DampedQuaternion
	{

		private Quaternion _velocity;
		
		public Quaternion Current { get; private set; }
		public Quaternion Target { get; set; }

		public Quaternion Tick(float damping)
		{
			float deltaTime = Time.deltaTime;
			return Tick(damping, deltaTime);
		}

		public Quaternion Tick(float damping, float deltaTime)
		{
			
			return Current;
		}

	}
}