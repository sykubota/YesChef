using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Pass : MonoBehaviour
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

            if (finalScore > PlayerPrefs.GetInt("Level2Score"))
            {   
                PlayerPrefs.SetInt("Level2Score", finalScore);
                PlayerPrefs.SetInt("Level2Stars", starRatingController.stars);
            }
            
            if (oven.SpecialsMet == true)
            {
                PlayerPrefs.SetString("Level2Pass", "Yes");
            }
        } 
    }
}

