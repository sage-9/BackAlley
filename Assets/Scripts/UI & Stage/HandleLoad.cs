using Managers;
using UnityEngine;

namespace UI___Stage
{
   public class HandleLoad : MonoBehaviour
   {
      public void SwitchToGame()
      {
         SceneLoader.Instance.LoadScene(Scenes.Game);
      }

      public void Quit()
      {
         Application.Quit();  
      }

   
   }
}
