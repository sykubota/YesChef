using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float countdownTime = 200f;

    private void Start()
    {
        // Set the initial time on the timer text.
        UpdateTimerText();
    }

    private void Update()
    {
        // Decrease the countdown time by the time elapsed since the last frame.
        countdownTime -= Time.deltaTime;

        // Ensure the countdown time doesn't go below 0.
        countdownTime = Mathf.Max(countdownTime, 0f);

        // Update the timer text.
        UpdateTimerText();

        // Check if the countdown has reached 0.
        if (countdownTime <= 0f)
        {
            // Do something when the countdown reaches 0.
            // For example, you can display a message or trigger an event.
            //megan added this line and line 3 using scenemanager. has to be int value of scene not the name
            SceneManager.LoadScene(6);

        }
    }

    private void UpdateTimerText()
    {
        // Convert the countdown time to an integer.
        int seconds = Mathf.FloorToInt(countdownTime);

        // Update the timer text with the remaining seconds.
        timerText.text = seconds.ToString();
    }
}
