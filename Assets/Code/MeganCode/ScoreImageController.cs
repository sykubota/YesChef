using UnityEngine;
using UnityEngine.UI;

public class ScoreImageController : MonoBehaviour
{
    public Image imageElement;
    public Sprite[] starImages; // Array of star images from least to highest

public void UpdateScoreImage()
{
    int score = 60;
    int stars = GetStarsForScore(score);
    imageElement.sprite = starImages[stars];
}

    private int GetStarsForScore(int score)
    {
        if (score >= 280)
        {
            return 3;
        }
        else if (score >= 190)
        {
            return 2;
        }
        else if (score >= 125)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}