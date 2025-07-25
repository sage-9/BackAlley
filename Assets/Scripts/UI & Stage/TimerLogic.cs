using Managers;
using TMPro;
using UnityEngine;

namespace UI___Stage
{
    public class TimerLogic : MonoBehaviour
    {
        public float targetTime = 60.0f; // The initial time for the countdown
        public TMP_Text timerText; // Reference to the UI Text element

        private float _currentTime;
        private bool _isRunning;


        void OnEnable()
        {
            GameSceneManager.PreStart += StartTimer;
            GameSceneManager.Play += ResumeTimer;
            GameSceneManager.Pause += StopTimer;
        }

        void Update()
        {
            if (_isRunning)
            {
                _currentTime -= Time.deltaTime;
                if (_currentTime <= 0.0f)
                {
                    _currentTime = 0.0f;
                    TimerEnded();
                }
                UpdateTimerDisplay();
            }
        }

        private void StartTimer()
        {
            _currentTime = targetTime;
            UpdateTimerDisplay();
        }

        private void ResumeTimer()
        {
            _isRunning = true;

        }

        private void StopTimer()
        {
            _isRunning = false;
        }

        void UpdateTimerDisplay()
        {
            if (timerText)
            {
                int minutes = Mathf.FloorToInt(_currentTime / 60.0f);
                int seconds = Mathf.FloorToInt(_currentTime % 60.0f);
                timerText.text = $"{minutes:00}:{seconds:00}";
            }
        }
        // ReSharper disable Unity.PerformanceAnalysis
        void TimerEnded()
        {
            // Code to execute when the timer reaches zero
            Debug.Log("Time's up!");
            GameSceneManager.SwitchStates(GamePlayStates.GameOver);
            // Stop the timer
            _isRunning = false; 
        }

    }
}
