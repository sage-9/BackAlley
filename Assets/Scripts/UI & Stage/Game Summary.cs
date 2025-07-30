using System;
using System.Globalization;
using System.Threading.Tasks;
using Managers;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

namespace UI___Stage
{
    public class GameSummary : MonoBehaviour
    {
        [SerializeField]private GameObject summaryPanel;
        [SerializeField]private TMP_Text scoreText;
        [SerializeField]private TMP_Text bulletsShotsText;
        [SerializeField]private TMP_Text enemiesShotsText;
        [SerializeField] private TMP_Text killRatioText;
        
        private int _score;
        private int _bulletsShot;
        private int _enemiesShot;
        private float _killRatio;

        private void Start()
        {
            ScoreLogic.Summary += CalculateValues;
            ScoreLogic.Summary += AssignValues;
            GameSceneManager.GameOver += ActivateGameover;
        }

        private void OnDisable()
        {
            ScoreLogic.Summary -= CalculateValues;
            ScoreLogic.Summary -= AssignValues;
            GameSceneManager.GameOver -= ActivateGameover;
        }

        async void AssignValues(int num1,int num2)
        {
            await Task.Delay(1000);
            scoreText.text = _score.ToString();
            await Task.Delay(250);
            bulletsShotsText.text = _bulletsShot.ToString();
            await Task.Delay(250);
            enemiesShotsText.text = _enemiesShot.ToString();
            await Task.Delay(250);
            killRatioText.text = _killRatio.ToString(CultureInfo.CurrentCulture);
        }

        void CalculateValues(int score,int bulletsShot)
        {
            _score = score;
            _bulletsShot = bulletsShot;
            _enemiesShot = score / 5;
            float ratio = (float)_enemiesShot / _bulletsShot;
            _killRatio = (float)Math.Round(ratio,2);

        }

        void ActivateGameover()
        {
            summaryPanel.SetActive(true);
        }
        
        
    }
}
