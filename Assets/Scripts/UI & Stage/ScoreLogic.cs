using TMPro;
using UnityEngine;


public class ScoreLogic : MonoBehaviour
{
    TMP_Text _scoreText;
    int _score;

    void Start()
    {
        _score = 0;
        _scoreText = GetComponent<TMP_Text>();
        Fire.AddScore+=UpdateScore;
        
    }

    void UpdateScore()
    {
        _score += 5;
        _scoreText.text = "Score : " + _score;
    }
}
