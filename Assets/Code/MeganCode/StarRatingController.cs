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


public void UpdateStarRating(ScoreManager scoreManager)
{
    int score = scoreManager.score;

    if (score >= threeStarPoints)
    {
        Debug.Log("3 star");
        starImage.sprite = threeStarSprite;
    }
    else if (score >= twoStarPoints)
    {
        Debug.Log("2 star");
        starImage.sprite = twoStarSprite;
    }
    else if (score >= oneStarPoints)
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
