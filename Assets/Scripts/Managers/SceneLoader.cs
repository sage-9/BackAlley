using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class SceneLoader : MonoBehaviour
    {
        
        
        public void LoadScene(Scenes scene)
        {
            var nextScene=SceneManager.LoadSceneAsync(scene.ToString());
            if (nextScene != null) nextScene.allowSceneActivation = false || nextScene.progress > 0.89;
        }

        
    }

    public enum Scenes
    {
        MainMenu,
        Game
    }
}