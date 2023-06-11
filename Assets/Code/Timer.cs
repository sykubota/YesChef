using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float countdownTime = 200f;
    public int finalScore;
    public ScoreManager scoreManager;
    public GameObject endLevelScreen;
    public GameObject music;
    public GameObject conveyorSound;
    public StarRatingController starRatingController;
    public AudioSource countdownSound; // Reference to the countdown sound
    public AudioClip countdownClip; // Reference to the audio clip for countdown

    private bool levelEnded;
    private bool isPlayingCountdownSound;

    private void Start()
    {
        // Set the initial time on the timer text.
        UpdateTimerText();
        levelEnded = false;
        isPlayingCountdownSound = false;
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
        if (!levelEnded)
        {
            if (countdownTime <= 0f)
            {
                levelEnded = true;
                endLevelScreen.SetActive(true);
                music.SetActive(false);
                conveyorSound.SetActive(false);
                starRatingController.UpdateStarRating(scoreManager);
            }
            else if (countdownTime <= 10f && !isPlayingCountdownSound)
            {
                isPlayingCountdownSound = true;
                PlayCountdownSound();
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

    private void PlayCountdownSound()
    {
        // Play the countdown sound
        countdownSound.PlayOneShot(countdownClip);
    }
}
