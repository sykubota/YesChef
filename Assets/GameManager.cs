using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ScoreImageController scoreImageController;

    private int playerScore;

    // Call this method to update the player's score
    public void UpdatePlayerScore(int newScore)
    {
        playerScore = newScore;
        scoreImageController.UpdateScoreImage(playerScore);
    }
}