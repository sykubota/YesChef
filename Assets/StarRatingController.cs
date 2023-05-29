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
        int score = 195; // Score for testing (can be modified)
        UpdateStarRating(score);
    }

    public void UpdateStarRating(int score)
    {
        if (score >= 280)
        {
            starImage.sprite = threeStarSprite;
        }
        else if (score >= 190)
        {
            starImage.sprite = twoStarSprite;
        }
        else if (score >= 125)
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