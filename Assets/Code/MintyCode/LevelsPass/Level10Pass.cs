using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level10Pass : MonoBehaviour
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

            if (finalScore > PlayerPrefs.GetInt("Level10Score"))
            {   
                PlayerPrefs.SetInt("Level10Score", finalScore);
                PlayerPrefs.SetInt("Level10Stars", starRatingController.stars);
            }
            
            if (oven.SpecialsMet == true)
            {
                PlayerPrefs.SetString("Level10Pass", "Yes");
            }
        } 
    }
}

