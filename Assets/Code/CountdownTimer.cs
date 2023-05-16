using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{

    // This variable will store the time remaining in the countdown.
    public float timeRemaining;

    // This variable will store the text object that will display the countdown.
    private Text countdownText;

    // This method will be called when the game starts.
    void Start()
    {
        timeRemaining = 10.0f;
        countdownText = GetComponent<Text>();
    }

    // This method will be called every frame.
    void Update()
    {
        // Decrement the time remaining.
        timeRemaining -= Time.deltaTime;

        // Update the countdown text.
        countdownText.text = timeRemaining.ToString();

        // If the time remaining is less than or equal to zero, then stop the countdown.
        if (timeRemaining <= 0.0f)
        {
            StopCoroutine("Countdown");
        }
    }

    // This method will start the countdown.
    public void StartCountdown()
    {
        timeRemaining = 10.0f;
        countdownText.text = timeRemaining.ToString();
        StartCoroutine("Countdown");
    }

    // This is the coroutine that will countdown the time.
    IEnumerator Countdown()
    {
        while (timeRemaining > 0.0f)
        {
            yield return null;
            timeRemaining -= Time.deltaTime;
            countdownText.text = timeRemaining.ToString();
        }
    }
}

