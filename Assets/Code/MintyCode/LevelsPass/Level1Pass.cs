using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Pass : MonoBehaviour
{

    public ScoreManager scoreManager;
    public Timer timer;
    public Oven oven;
    public int finalScore;
    public int stars;
    public StarRatingController starRatingController;

    // Update is called once per frame
    void Update()
    {
        if (timer.countdownTime <= 0f)
        {
            finalScore = scoreManager.score;

            if (finalScore > PlayerPrefs.GetInt("Level1Score"))
            {   
                PlayerPrefs.SetInt("Level1Score", finalScore);
                PlayerPrefs.SetInt("Level1Stars", starRatingController.stars);
            }
            
            if (oven.SpecialsMet == true)
            {
                PlayerPrefs.SetString("Level1Pass", "Yes");
            }
        } 
    }
}
