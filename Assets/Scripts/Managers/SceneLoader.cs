using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class SceneLoader : MonoBehaviour
    {
        
        public static SceneLoader Instance;


        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            Instance = this;
        }

        public void LoadScene(Scenes scene)
        {
            var nextScene=SceneManager.LoadSceneAsync(scene.ToString());
            if (nextScene != null)
            {
                while (nextScene.progress < 0.89f)
                {
                    nextScene.allowSceneActivation = false;
                }
                nextScene.allowSceneActivation = true;
            }
        }
    }

    public enum Scenes
    {
        MainMenu,
        Game
    }
}