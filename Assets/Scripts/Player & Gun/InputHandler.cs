using System;
using Managers;
using UnityEngine;

namespace Player___Gun
{
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
            GameSceneManager.Play += ActivatePlayerControls;
            GameSceneManager.Pause += DeactivatePlayerControls;
            GameSceneManager.GameOver += DeactivatePlayerControls;
        }

        void OnDisable()
        {
            PlayerControls.Disable();
            GameSceneManager.Play -= ActivatePlayerControls;
            GameSceneManager.Pause -= DeactivatePlayerControls;
            GameSceneManager.GameOver -= DeactivatePlayerControls;
        }

        void ActivatePlayerControls()
        {
            PlayerControls.Enable();
        }

        void DeactivatePlayerControls()
        {
            PlayerControls.Disable();
        }
    
    }
}
