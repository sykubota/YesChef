using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private int score;

    private void Start()
    {
        // Initialize the score to 0
        score = 0;
        UpdateScoreUI();
    }

    public void AddScore(int scoreToAdd)
    {
        // Add the provided score to the total score
        score += scoreToAdd;

        // Update the UI to reflect the updated score
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        // Update the text component to display the current score
        scoreText.text = score.ToString();
    }
}
