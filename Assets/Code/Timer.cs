using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float countdownTime = 50f;
    public int finalScore;
    public ScoreManager scoreManager;
    public GameObject endLevelScreen;
    public GameObject music;
    public GameObject conveyorSound;
    public StarRatingController starRatingController;
    private bool levelended;

    private void Start()
    {
        // Set the initial time on the timer text.
        UpdateTimerText();
        levelended=false;

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
        if (levelended==false)
        {
            if (countdownTime <= 0f)
            {
                levelended=true;
                endLevelScreen.SetActive(true);
                music.SetActive(false);
                conveyorSound.SetActive(false);
                starRatingController.UpdateStarRating(scoreManager);
            }
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