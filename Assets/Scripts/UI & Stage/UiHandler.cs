using Managers;
using Player___Gun;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI___Stage
{
    public class UiHandler : MonoBehaviour
    {
        [SerializeField] private GameObject pausePanel;
        [SerializeField] private GameObject gamePanel;
        private void Awake()
        {
            GameSceneManager.Play += DeactivateCursor;
            GameSceneManager.Pause += ActivateCursor;
            GameSceneManager.GameOver+=ActivateCursor;
            InputHandler.PauseAction += PauseGame;
        }
        
        

        private void OnDisable()
        {
            GameSceneManager.Play -= DeactivateCursor;
            GameSceneManager.Pause -= ActivateCursor;
            InputHandler.PauseAction -= PauseGame;
            GameSceneManager.GameOver -= ActivateCursor;
        }

        public void PauseGame()
        {
            GameSceneManager.SwitchStates(GamePlayStates.Pause);
            pausePanel.SetActive(true);
            gamePanel.SetActive(false);
            //show Pause menu
        }

        public void MoveToMainMenu()
        {
            SceneLoader.Instance.LoadScene(Scenes.MainMenu);
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
