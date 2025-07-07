using System;
using UnityEngine;



public class InputHandler : MonoBehaviour
{
    public PlayerControls PlayerControls;
    public static event Action<Vector2> LookAction;
    public static event Action ShootAction;
    public static event Action ReloadAction;
    
    void Awake()
    {
        PlayerControls = new PlayerControls();
        PlayerControls.Player.Look.performed += ctx => LookAction?.Invoke(ctx.ReadValue<Vector2>());
        PlayerControls.Player.Look.canceled += ctx => LookAction?.Invoke(Vector2.zero);
        PlayerControls.Player.Attack.performed+= ctx => ShootAction?.Invoke();
        PlayerControls.Player.Reload.performed += ctx => ReloadAction?.Invoke();
    }

    void OnEnable()
    {
        PlayerControls.Enable();
        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnDisable()
    {
        PlayerControls.Disable();
    }
    
}
