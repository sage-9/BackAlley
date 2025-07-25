using UnityEngine;

namespace Managers
{
    [CreateAssetMenu(fileName = "GameResults", menuName = "Scriptable Objects/GameResults")]
    public class GameResults : ScriptableObject
    {
        public int score;
        public int numberOfEnemiesKilled;

    }
}
