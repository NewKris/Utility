using UnityEngine;

namespace BaraGames.Utility.CommonBehaviours
{
    public class SpectatorController : MonoBehaviour
    {

        public float mouseSensitivity;
        public float flightSpeed;
        public float scrollSpeed;

        private float _speedScale;
        private float _pitch;
        private Vector3 _velocity;
        private Transform _cameraTransform;
        
        private void Reset()
        {
            if (GetComponentInChildren<Camera>() != null) return;

            GameObject newCameraObject = new GameObject();
            newCameraObject.transform.parent = transform;
            newCameraObject.transform.localPosition = Vector3.zero;
            newCameraObject.name = "Main Camera";
            newCameraObject.AddComponent<Camera>();
        }

        private void Update()
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivity);

            _pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            _pitch = Mathf.Clamp(_pitch, -90, 90);
            _cameraTransform.localRotation = Quaternion.Euler(_pitch, 0, 0);

            _velocity = _cameraTransform.TransformDirection(new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")));

            if (Input.GetKey(KeyCode.Space)) _velocity += Vector3.up;
            if (Input.GetKey(KeyCode.LeftControl)) _velocity += Vector3.down;

            _speedScale += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
            _speedScale = Mathf.Max(_speedScale, 0);
            
            transform.position += _velocity.normalized * flightSpeed * _speedScale * Time.deltaTime;
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            _cameraTransform = GetComponentInChildren<Camera>().transform;
            _speedScale = 1;
        }
    }
}
