using UnityEngine;
using UnityEngine.UI;

public class StarRatingController : MonoBehaviour
{
    public Image starImage;
    public Sprite oneStarSprite;
    public Sprite twoStarSprite;
    public Sprite threeStarSprite;

    private void Start()
    {
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        UpdateStarRating(scoreManager);
    }

    public void UpdateStarRating(ScoreManager scoreManager)
    {
        int score = scoreManager.score;

        if (score >= 900)
        {
            starImage.sprite = threeStarSprite;
        }
        else if (score >= 600)
        {
            starImage.sprite = twoStarSprite;
        }
        else if (score >= 400)
        {
            starImage.sprite = oneStarSprite;
        }
        else
        {
            // No stars earned
            starImage.sprite = null;
        }
    }
}
