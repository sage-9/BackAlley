using Managers;
using UnityEngine;
using TMPro;

public class TimerLogic : MonoBehaviour
{
    public float targetTime = 60.0f; // The initial time for the countdown
    public TMP_Text timerText; // Reference to the UI Text element

    private float _currentTime;
    private bool _isRunning;

    void Start()
    {
        GameManager.OnGameStateChanged += StartTimer;
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

    private void StartTimer(GameState gameState)
    {
        if (gameState == GameState.Play)
        {
            _currentTime = targetTime;
            UpdateTimerDisplay();
            _isRunning = true;
        }
    }

    public void StopTimer()
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
        // Stop the timer
        _isRunning = false; 
        GameManager.Instance.UpdateGameState(GameState.GameOver);
    }

}
