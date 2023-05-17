using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{

    // This variable will store the time remaining in the countdown.
    public float timeRemaining = 90;

    // This variable will store the text object that will display the countdown.
    public Text countdownText;

    // This method will be called every frame.
    void Update()
    {
        if (timeRemaining > 0) {
            timeRemaining -= Time.deltaTime;
        } else {
            timeRemaining = 0;
        }

        DisplayTime(timeRemaining);
    }

    void DisplayTime(float time) {
        if(time < 0) {
            time = 0;
        }

        float min = Mathf.FloorToInt(time/60);
        float sec = Mathf.FloorToInt(time%60);

        countdownText.text = string.Format("{0:00}:{1:00}", min, sec);
    }
}

