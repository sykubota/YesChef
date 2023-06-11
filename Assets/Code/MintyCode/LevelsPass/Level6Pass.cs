using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level6Pass : MonoBehaviour
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

            if (finalScore > PlayerPrefs.GetInt("Level6Score"))
            {   
                PlayerPrefs.SetInt("Level6Score", finalScore);
                PlayerPrefs.SetInt("Level6Stars", starRatingController.stars);
            }
            
            if (oven.SpecialsMet == true)
            {
                PlayerPrefs.SetString("Level6Pass", "Yes");
            }
        } 
    }
}

