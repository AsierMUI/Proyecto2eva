using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public Text timerText;
    private float timeElapsed;
    private bool isTimerRunning;

    void Start()
    {
        timeElapsed = 0f;
        isTimerRunning = true;
    }

    void Update()
    {
        if (isTimerRunning)
        {
            timeElapsed += Time.deltaTime;
            DisplayTime(timeElapsed);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void ResetTimer()
    {
        timeElapsed = 0f;
        isTimerRunning = true;
    }
}
