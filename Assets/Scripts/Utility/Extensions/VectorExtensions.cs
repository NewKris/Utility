﻿using UnityEngine;

namespace VirtualDeviants.Utility.Extensions
{
	public static class VectorExtensions
	{
		public static float YAngle(this Vector3 vector)
		{
			return Mathf.Atan2(vector.x, vector.z) * Mathf.Rad2Deg;
		}
	}
}