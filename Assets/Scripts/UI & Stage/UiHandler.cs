using Managers;
using UnityEngine;

namespace UI___Stage
{
    public class UiHandler : MonoBehaviour
    {
        private void Awake()
        {
            GameSceneManager.Play += DeactivateCursor;
            GameSceneManager.Pause += ActivateCursor;
        }

        private void OnDisable()
        {
            
            GameSceneManager.Play -= DeactivateCursor;
            GameSceneManager.Pause -= ActivateCursor;
        }

        public void PauseGame()
        {
            GameSceneManager.SwitchStates(GamePlayStates.Pause);
            //show Pause menu
        }

        public void StartGame()
        {
            GameSceneManager.SwitchStates(GamePlayStates.InGame);
            //hide other UIs
        }

        private void DeactivateCursor()
        {
            Cursor.visible = false; 
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void ActivateCursor()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
