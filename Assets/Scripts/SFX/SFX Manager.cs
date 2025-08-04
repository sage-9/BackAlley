using UnityEngine;

namespace SFX
{
    public class SFXManager : MonoBehaviour
    {
        public static SFXManager Instance;
        
        

        void Start()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
        
        
        
        
    }
}
