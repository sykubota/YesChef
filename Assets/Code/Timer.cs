using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float totalTime = 300f; // Total time in seconds (5 minutes)
    private float currentTime; // Current time in seconds
    private TextMeshProUGUI timerText; // Reference to the TextMeshProUGUI component

    private void Start()
    {
        currentTime = totalTime;
        timerText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        // Update the timer and display the time
        currentTime -= Time.deltaTime;
        UpdateTimerDisplay();

        // Check if time has run out
        if (currentTime <= 0)
        {
            // Perform any actions when the timer reaches zero
        }
    }

    private void UpdateTimerDisplay()
    {
        // Convert time to minutes and seconds
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        // Update the timer text
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
