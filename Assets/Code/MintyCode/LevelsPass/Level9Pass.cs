using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level9Pass : MonoBehaviour
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

            if (finalScore > PlayerPrefs.GetInt("Level9Score"))
            {   
                PlayerPrefs.SetInt("Level9Score", finalScore);
                PlayerPrefs.SetInt("Level9Stars", starRatingController.stars);
            }
            
            if (oven.SpecialsMet == true)
            {
                PlayerPrefs.SetString("Level9Pass", "Yes");
            }
        } 
    }
}

