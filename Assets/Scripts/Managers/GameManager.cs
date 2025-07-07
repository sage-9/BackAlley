using System;
using UnityEngine;

namespace Managers
{
    public class GameManager: MonoBehaviour
    {
        public static GameManager Instance;
        public GameState state;
        public static event Action<GameState> OnGameStateChanged;

        void Awake()
        {
            Instance = this;  
        }

        public void UpdateGameState(GameState newState)
        {
            state = newState;

            switch (state)
            {
                case GameState.MainMenu:
                    break;
                case GameState.Settings:
                    break;
                case GameState.Play:
                    break;
                case GameState.GameOver:
                    break;
                case GameState.Leaderboard:
                    break;
                default:
                    break;
            }
            OnGameStateChanged?.Invoke(newState);
        }
    
    
    
    }

    public enum GameState
    {
        MainMenu,
        Settings,
        SoundSettings,
        GamePlaySettings,
        SetStageParameters,
        Play,
        PauseMenu,
        GameOver,
        Leaderboard,
        Quit
    }
}