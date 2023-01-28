using UnityEngine;

namespace VirtualDeviants.Utility.CommonBehaviours
{
	/// <summary>
	/// A UI element that follows a GameObject
	/// </summary>
	public class UIDrone : MonoBehaviour
	{

		public Transform target;
		
		private RectTransform _rect;
		private RectTransform _canvasRect;

		public Transform Target
		{
			set
			{
				target = value;
				gameObject.SetActive(value != null);
			}
		}

		private void Start()
		{
			_rect = GetComponent<RectTransform>();
			_canvasRect = transform.parent.GetComponent<RectTransform>();
			
			if(!target) gameObject.SetActive(false);
		}

		private void LateUpdate()
		{
			if(!Camera.main) return;
            
			Vector2 screenPoint = Camera.main.WorldToScreenPoint(target.position);
			RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasRect, screenPoint, null, out Vector2 canvasPos);
			_rect.localPosition = canvasPos;
		}
		
	}
}