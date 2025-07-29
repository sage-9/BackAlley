using System;
using Managers;
using UnityEngine;

namespace Player___Gun
{
    public class InputHandler : MonoBehaviour
    {
        private PlayerControls _playerControls;
        public static event Action<Vector2> LookAction;
        public static event Action ShootAction;
        public static event Action ReloadAction;
        public static event Action PauseAction;
    
        void Awake()
        {
            _playerControls = new PlayerControls();
            _playerControls.Player.Look.performed += ctx => LookAction?.Invoke(ctx.ReadValue<Vector2>());
            _playerControls.Player.Look.canceled += ctx => LookAction?.Invoke(Vector2.zero);
            _playerControls.Player.Attack.performed+= ctx => ShootAction?.Invoke();
            _playerControls.Player.Reload.performed += ctx => ReloadAction?.Invoke();
            _playerControls.Player.Pause.performed += ctx => PauseAction?.Invoke();
            GameSceneManager.Play += ActivatePlayerControls;
            GameSceneManager.Pause += DeactivatePlayerControls;
            GameSceneManager.GameOver += DeactivatePlayerControls;
        }

        void OnDisable()
        {
            _playerControls.Disable();
            GameSceneManager.Play -= ActivatePlayerControls;
            GameSceneManager.Pause -= DeactivatePlayerControls;
            GameSceneManager.GameOver -= DeactivatePlayerControls;
        }

        void ActivatePlayerControls()
        {
            _playerControls.Enable();
        }

        void DeactivatePlayerControls()
        {
            _playerControls.Disable();
        }
    
    }
}
