using UnityEngine;
using UnityEngine.UI;

public class StarRatingController : MonoBehaviour
{
    public Image starImage;
    public Sprite oneStarSprite;
    public Sprite twoStarSprite;
    public Sprite threeStarSprite;
    public Sprite zeroStarSprite;
    public ScoreManager scoreManager;

public void UpdateStarRating(ScoreManager scoreManager)
{
    int score = scoreManager.score;

    if (score >= 600)
    {
        Debug.Log("3 star");
        starImage.sprite = threeStarSprite;
    }
    else if (score >= 400)
    {
        Debug.Log("2 star");
        starImage.sprite = twoStarSprite;
    }
    else if (score >= 200)
    {
        Debug.Log("1 star");
        starImage.sprite = oneStarSprite;
    }
    else
    {
        // No stars earned
        Debug.Log("0 star");
        starImage.sprite = zeroStarSprite;
    }
}

}
