using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public int score;
    public Oven oven;

    public void Start()
    {
        // Initialize the score to 0
        score = 0;
        oven = GetComponent<Oven>();
        UpdateScoreUI();
    }

   public void AddScore(int scoreToAdd)
   {
        // Add the provided score to the total score
        score += scoreToAdd;

        // Update the UI to reflect the updated score
        UpdateScoreUI();
    }

    public void UpdateScore(int newScore)
    {
        // Update the score with the provided new score
        score = oven.currentScore;

        // Update the UI to reflect the updated score
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        // Update the text component to display the current score
        scoreText.text = score.ToString();
    }
}
