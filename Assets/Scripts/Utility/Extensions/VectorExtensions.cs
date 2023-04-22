using UnityEngine;

namespace BaraGames.Utility.Extensions
{
	public static class VectorExtensions
	{
		public static float YRotation(this Vector3 vector)
		{
			return Mathf.Atan2(vector.x, vector.z) * Mathf.Rad2Deg;
		}

		public static Vector3 ToHorizontalVector(this Vector2 vector)
		{
			return new Vector3(vector.x, 0, vector.y);
		}
		
		public static Vector3 ToHorizontalVector(this Vector3 vector)
		{
			return new Vector3(vector.x, 0, vector.z);
		}
		
	}
}