using UnityEngine;
using UnityEngine.UI;

public class StarRatingController : MonoBehaviour
{
    public Image starImage;

    public Sprite oneStarSprite;
    public Sprite twoStarSprite;
    public Sprite threeStarSprite;
    int score = ScoreManager.score;

    private void Start()
    {
        UpdateStarRating(score);
    }

    public void UpdateStarRating(int score)
    {
        if (score >= 900)
        {
            starImage.sprite = threeStarSprite;
        }
        else if (score >= 600)
        {
            starImage.sprite = twoStarSprite;
        }
        else if (score >= 0)
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