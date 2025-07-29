using Player___Gun;
using System;
using Managers;
using TMPro;
using UnityEngine;

namespace UI___Stage
{
    public class ScoreLogic : MonoBehaviour
    {
        TMP_Text _scoreText;
        int _score;
        private int _bulletsShot;
        public static event Action<int, int> Summary;

        void Start()
        {
            _score = 0;
            _bulletsShot = 0;
            _scoreText = GetComponent<TMP_Text>();
            Fire.AddScore+=UpdateScore;
            Fire.AddBullets+=UpdateBullets;
            GameSceneManager.GameOver += CallCalculate;
        }

        void OnDisable()
        {
            Fire.AddScore -= UpdateScore;
            Fire.AddBullets -= UpdateBullets;
        }

        void UpdateScore()
        {
            _score += 5;
            _scoreText.text = "Score : " + _score;
        }

        void UpdateBullets()
        {
            _bulletsShot += 1;
        }
        
        void CallCalculate()
        {
            Summary?.Invoke(_score, _bulletsShot);
        }
    }
}
