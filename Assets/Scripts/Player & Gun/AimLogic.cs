using UnityEngine;

public class AimLogic : MonoBehaviour
{
    [Header("aim settings")]
    [SerializeField] private float aimSensitivity;
    
    
    float _horizontal, _vertical,_xRotation;
    
    [Header("Camera settings")]
    [SerializeField] private Transform cameraTransform;
    
    void Start()
    {
        
        InputHandler.LookAction += CalculateInput;
       
    }
    void Update()
    {
        RotateCamHolder();
    }
    
    #region Camera Rotation Logic 
        void CalculateInput(Vector2 input)
        {
            _horizontal = input.x * aimSensitivity * Time.deltaTime;
            _vertical = input.y * aimSensitivity * Time.deltaTime;
            _xRotation -= _vertical;
            _xRotation = Mathf.Clamp(_xRotation, -80f, 80f);
        }    
        void RotateCamHolder()
        {
            //vertical camera rotation
            cameraTransform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f); 
            
            // Horizontal player body rotation
            transform.Rotate(Vector3.up * _horizontal);
        }
    #endregion

   
}
