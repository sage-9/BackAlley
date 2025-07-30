using UnityEngine;

namespace Player___Gun
{
    public class AimLogic : MonoBehaviour
    {
        [Header("Settings")]
        [Tooltip("The sensitivity of the mouse look.")]
        [SerializeField] private float aimSensitivity = 15f;
        [Tooltip("The speed of the smoothing. Higher values are snappier.")]
        [SerializeField] private float smoothSpeed = 20f;

        [Header("Object References")]
        [SerializeField] private Transform cameraTransform;

        private Vector2 _mouseInput;
        private float _targetYaw;   // Target horizontal rotation (Y-axis)
        private float _targetPitch; // Target vertical rotation (X-axis)

        void Start()
        {
            // Subscribe to the input event
            InputHandler.LookAction += OnLookInput;
            
            // Initialize target rotations to the current orientation to prevent a snap on start
            _targetYaw = transform.eulerAngles.y;
            _targetPitch = cameraTransform.localEulerAngles.x;
        }

        void OnDisable()
        {
            // Unsubscribe to prevent memory leaks
            InputHandler.LookAction -= OnLookInput;
        }

        // This method simply captures the raw input from the InputHandler
        private void OnLookInput(Vector2 input)
        {
            _mouseInput = input;
        }

        void Update()
        {
            // Update the target rotations based on mouse input
            // A small multiplier (e.g., 0.01f) is often used to scale raw mouse delta values
            _targetYaw += _mouseInput.x * aimSensitivity * 0.01f;
            _targetPitch -= _mouseInput.y * aimSensitivity * 0.01f;

            // Clamp the vertical rotation to prevent the camera from flipping over
            _targetPitch = Mathf.Clamp(_targetPitch, -80f, 80f);

            // This creates a frame-rate independent smoothing factor.
            // It results in a very responsive yet smooth interpolation.
            float smoothFactor = 1f - Mathf.Exp(-smoothSpeed * Time.deltaTime);

            // Apply rotations using spherical linear interpolation (Slerp) for smooth movement
            // Horizontal rotation (Yaw) on the player body
            transform.rotation = Quaternion.Slerp
            (
                transform.rotation, 
                Quaternion.Euler(0f, _targetYaw, 0f), 
                smoothFactor
            );

            // Vertical rotation (Pitch) on the camera itself
            cameraTransform.localRotation = Quaternion.Slerp
            (
                cameraTransform.localRotation, 
                Quaternion.Euler(_targetPitch, 0f, 0f), 
                smoothFactor
            );
        }
    }
}