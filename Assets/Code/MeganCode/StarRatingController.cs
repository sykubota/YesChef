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
    public float threeStarPoints = 1f;
    public float twoStarPoints = 1f;
    public float oneStarPoints = 1f;
    public int stars;


public void UpdateStarRating(ScoreManager scoreManager)
{
    int score = scoreManager.score;

    if (score >= threeStarPoints)
    {
        Debug.Log("3 star");
        stars = 3;
        starImage.sprite = threeStarSprite;
    }
    else if (score >= twoStarPoints)
    {
        Debug.Log("2 star");
        stars = 2;
        starImage.sprite = twoStarSprite;
    }
    else if (score >= oneStarPoints)
    {
        Debug.Log("1 star");
        stars = 1;
        starImage.sprite = oneStarSprite;
    }
    else
    {
        // No stars earned
        Debug.Log("0 star");
        stars = 0;
        starImage.sprite = zeroStarSprite;
    }
}

}
