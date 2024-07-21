using UnityEngine;

namespace BaraGames.Utility.CommonBehaviours {
	/// <summary>
	/// A UI element that follows a GameObject
	/// </summary>
	public class UIDrone : MonoBehaviour {
		public Transform target;
		
		private RectTransform _rect;

		private void Start() {
			_rect = GetComponent<RectTransform>();
		}

		private void LateUpdate() {
			if (!target) return;
			
			Vector2 screenPoint = Camera.main.WorldToScreenPoint(target.position);
			_rect.position = screenPoint;
		}
		
	}
}