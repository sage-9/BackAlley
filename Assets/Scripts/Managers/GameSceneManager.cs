using System;
using UnityEngine;

namespace Managers
{
    public class GameSceneManager : MonoBehaviour
    {
        public static event Action PreStart;
        public static event Action Play;
        public static event Action Pause;
        public static event Action GameOver;
        

        void Start()
        {
            SwitchStates(GamePlayStates.PreStart);
        }
        
       
        
        public static void SwitchStates(GamePlayStates states)
        {
            switch (states)
            {
                case GamePlayStates.PreStart:
                    //PreStartStage
                    PreStart?.Invoke();
                        //Disable Player game Controls
                        //Set initial values
                        //prompt for user Input
                        //Spawn heavy Objects
                    break;
                case GamePlayStates.InGame:
                    //Start
                    Play?.Invoke();
                        //enable Player Controls
                        //start spawning Enemies
                        //start Timer
                        //show HUD -------(undone)
                    //In game
                        //Handle score logic
                        //Collect game stats ------(undone)
                    //Resume
                        //resume timer
                        //resume Enemy spawner
                        //enable player game controls
                        //resume Enemy movement
                        //hide pause menu
                        //show HUD
                    break;
                case GamePlayStates.Pause:
                    //Pause
                    Pause?.Invoke();
                        //pause timer
                        //pause Enemy spawning
                        //pause Enemy movement
                        //pause Player game controls
                        //show pause menu -------(undone)
                        //hide HUD ---------(undone)
                    //Back to Main menu(persistent data isn't kept)
                    break;
                case GamePlayStates.GameOver:
                    GameOver?.Invoke();
                    //Time up
                    //Stop Spawning Enemies
                    //Pause Enemy Movement
                    //Disable Player Controls
                    //Show game over screen
                    Debug.Log("GameOver");
                    //Scene clean up
                    //move to game summary and leaderBoard
                    break;
            }
        }
    }

    public enum GamePlayStates
    {
        PreStart,
        InGame,
        Pause,
        GameOver
    }
    
}
