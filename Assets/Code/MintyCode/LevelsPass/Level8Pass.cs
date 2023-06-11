using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level8Pass : MonoBehaviour
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

            if (finalScore > PlayerPrefs.GetInt("Level8Score"))
            {   
                PlayerPrefs.SetInt("Level8Score", finalScore);
                PlayerPrefs.SetInt("Level8Stars", starRatingController.stars);
            }
            
            if (oven.SpecialsMet == true)
            {
                PlayerPrefs.SetString("Level8Pass", "Yes");
            }
        } 
    }
}

