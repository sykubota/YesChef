using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonActivator : MonoBehaviour
{
    public Button buttonL2;
    public Button buttonL3;
    public Button buttonL4;
    public Button buttonL5;
    public Button buttonL6;
    public Button buttonL7;
    public Button buttonL8;
    public Button buttonL9;
    public Button buttonL10;

    public TMP_Text pointsL1;
    public TMP_Text pointsL2;
    public TMP_Text pointsL3;
    public TMP_Text pointsL4;
    public TMP_Text pointsL5;
    public TMP_Text pointsL6;
    public TMP_Text pointsL7;
    public TMP_Text pointsL8;
    public TMP_Text pointsL9;
    public TMP_Text pointsL10;

    public Image starsL1;
    public Image starsL2;
    public Image starsL3;
    public Image starsL4;
    public Image starsL5;
    public Image starsL6;
    public Image starsL7;
    public Image starsL8;
    public Image starsL9;
    public Image starsL10;

    public Sprite zeroStars;
    public Sprite oneStar;
    public Sprite twoStars;
    public Sprite threeStars;


    void Start()
    {
        //buttons
        string level1Pass = PlayerPrefs.GetString("Level1Pass", "");
        
        if (level1Pass == "Yes")
        {
            buttonL2.interactable = true;
        }
        else
        {
            buttonL2.interactable = false;
        }

        string level2Pass = PlayerPrefs.GetString("Level2Pass", "");
        if (level2Pass == "Yes")
        {
            buttonL3.interactable = true;
        }
        else
        {
            buttonL3.interactable = false;
        }

        string level3Pass = PlayerPrefs.GetString("Level3Pass", "");
        if (level3Pass == "Yes")
        {
            buttonL4.interactable = true;
        }
        else
        {
            buttonL4.interactable = false;
        }

        string level4Pass = PlayerPrefs.GetString("Level4Pass", "");
        if (level4Pass == "Yes")
        {
            buttonL5.interactable = true;
        }
        else
        {
            buttonL5.interactable = false;
        }

        string level5Pass = PlayerPrefs.GetString("Level5Pass", "");
        if (level5Pass == "Yes")
        {
            buttonL6.interactable = true;
        }
        else
        {
            buttonL6.interactable = false;
        }

        string level6Pass = PlayerPrefs.GetString("Level6Pass", "");
        if (level6Pass == "Yes")
        {
            buttonL7.interactable = true;
        }
        else
        {
            buttonL7.interactable = false;
        }

        string level7Pass = PlayerPrefs.GetString("Level7Pass", "");
        if (level7Pass == "Yes")
        {
            buttonL8.interactable = true;
        }
        else
        {
            buttonL8.interactable = false;
        }

        string level8Pass = PlayerPrefs.GetString("Level8Pass", "");
        if (level8Pass == "Yes")
        {
            buttonL9.interactable = true;
        }
        else
        {
            buttonL9.interactable = false;
        }

        string level9Pass = PlayerPrefs.GetString("Level9Pass", "");
        if (level9Pass == "Yes")
        {
            buttonL10.interactable = true;
        }
        else
        {
            buttonL10.interactable = false;
        }

        string level10Pass = PlayerPrefs.GetString("Level10Pass", "");

    /// points and stars

            //Level1
            if (PlayerPrefs.GetInt("Level1Score") == 0)
            {
                pointsL1.text = "";
            }
            else
            {
                pointsL1.text = PlayerPrefs.GetInt("Level1Score").ToString();
            }

            if (PlayerPrefs.GetInt("Level1Stars")==0)
            {
                starsL1.sprite = zeroStars;
            }

            if (PlayerPrefs.GetInt("Level1Stars")==1)
            {
                starsL1.sprite = oneStar;
            }

            if (PlayerPrefs.GetInt("Level1Stars")==2)
            {
                starsL1.sprite = twoStars;
            }

            if (PlayerPrefs.GetInt("Level1Stars")==3)
            {
                starsL1.sprite = threeStars;
            }

            //Level2
            if (PlayerPrefs.GetInt("Level2Score") == 0)
            {
                pointsL2.text = "";
            }
            else
            {
                pointsL2.text = PlayerPrefs.GetInt("Level2Score").ToString();
            }

            if (PlayerPrefs.GetInt("Level2Stars")==0)
            {
                starsL2.sprite = zeroStars;
            }

            if (PlayerPrefs.GetInt("Level2Stars")==1)
            {
                starsL2.sprite = oneStar;
            }

            if (PlayerPrefs.GetInt("Level2Stars")==2)
            {
                starsL2.sprite = twoStars;
            }

            if (PlayerPrefs.GetInt("Level2Stars")==3)
            {
                starsL2.sprite = threeStars;
            }

            //Level3
            if (PlayerPrefs.GetInt("Level3Score") == 0)
            {
                pointsL3.text = "";
            }
            else
            {
                pointsL3.text = PlayerPrefs.GetInt("Level3Score").ToString();
            }

            if (PlayerPrefs.GetInt("Level3Stars")==0)
            {
                starsL3.sprite = zeroStars;
            }

            if (PlayerPrefs.GetInt("Level3Stars")==1)
            {
                starsL3.sprite = oneStar;
            }

            if (PlayerPrefs.GetInt("Level3Stars")==2)
            {
                starsL3.sprite = twoStars;
            }

            if (PlayerPrefs.GetInt("Level3Stars")==3)
            {
                starsL3.sprite = threeStars;
            }

            //Level4
            if (PlayerPrefs.GetInt("Level4Score") == 0)
            {
                pointsL4.text = "";
            }
            else
            {
                pointsL4.text = PlayerPrefs.GetInt("Level4Score").ToString();
            }

            if (PlayerPrefs.GetInt("Level4Stars")==0)
            {
                starsL4.sprite = zeroStars;
            }

            if (PlayerPrefs.GetInt("Level4Stars")==1)
            {
                starsL4.sprite = oneStar;
            }

            if (PlayerPrefs.GetInt("Level4Stars")==2)
            {
                starsL4.sprite = twoStars;
            }

            if (PlayerPrefs.GetInt("Level4Stars")==3)
            {
                starsL4.sprite = threeStars;
            }

            //Level5
            if (PlayerPrefs.GetInt("Level5Score") == 0)
            {
                pointsL5.text = "";
            }
            else
            {
                pointsL5.text = PlayerPrefs.GetInt("Level5Score").ToString();
            }

            if (PlayerPrefs.GetInt("Level5Stars")==0)
            {
                starsL5.sprite = zeroStars;
            }

            if (PlayerPrefs.GetInt("Level5Stars")==1)
            {
                starsL5.sprite = oneStar;
            }

            if (PlayerPrefs.GetInt("Level5Stars")==2)
            {
                starsL5.sprite = twoStars;
            }

            if (PlayerPrefs.GetInt("Level5Stars")==3)
            {
                starsL5.sprite = threeStars;
            }

            //Level6
            if (PlayerPrefs.GetInt("Level6Score") == 0)
            {
                pointsL6.text = "";
            }
            else
            {
                pointsL6.text = PlayerPrefs.GetInt("Level6Score").ToString();
            }

            if (PlayerPrefs.GetInt("Level6Stars")==0)
            {
                starsL6.sprite = zeroStars;
            }

            if (PlayerPrefs.GetInt("Level6Stars")==1)
            {
                starsL6.sprite = oneStar;
            }

            if (PlayerPrefs.GetInt("Level6Stars")==2)
            {
                starsL6.sprite = twoStars;
            }

            if (PlayerPrefs.GetInt("Level6Stars")==3)
            {
                starsL6.sprite = threeStars;
            }

            //Level7
            if (PlayerPrefs.GetInt("Level7Score") == 0)
            {
                pointsL7.text = "";
            }
            else
            {
                pointsL7.text = PlayerPrefs.GetInt("Level7Score").ToString();
            }

            if (PlayerPrefs.GetInt("Level7Stars")==0)
            {
                starsL7.sprite = zeroStars;
            }

            if (PlayerPrefs.GetInt("Level7Stars")==1)
            {
                starsL7.sprite = oneStar;
            }

            if (PlayerPrefs.GetInt("Level7Stars")==2)
            {
                starsL7.sprite = twoStars;
            }

            if (PlayerPrefs.GetInt("Level7Stars")==3)
            {
                starsL7.sprite = threeStars;
            }

            //Level8
            if (PlayerPrefs.GetInt("Level8Score") == 0)
            {
                pointsL8.text = "";
            }
            else
            {
                pointsL8.text = PlayerPrefs.GetInt("Level8Score").ToString();
            }

            if (PlayerPrefs.GetInt("Level8Stars")==0)
            {
                starsL8.sprite = zeroStars;
            }

            if (PlayerPrefs.GetInt("Level8Stars")==1)
            {
                starsL8.sprite = oneStar;
            }

            if (PlayerPrefs.GetInt("Level8Stars")==2)
            {
                starsL8.sprite = twoStars;
            }

            if (PlayerPrefs.GetInt("Level8Stars")==3)
            {
                starsL8.sprite = threeStars;
            }

            //Level9
            if (PlayerPrefs.GetInt("Level9Score") == 0)
            {
                pointsL9.text = "";
            }
            else
            {
                pointsL9.text = PlayerPrefs.GetInt("Level9Score").ToString();
            }

            if (PlayerPrefs.GetInt("Level9Stars")==0)
            {
                starsL9.sprite = zeroStars;
            }

            if (PlayerPrefs.GetInt("Level9Stars")==1)
            {
                starsL9.sprite = oneStar;
            }

            if (PlayerPrefs.GetInt("Level9Stars")==2)
            {
                starsL9.sprite = twoStars;
            }

            if (PlayerPrefs.GetInt("Level9Stars")==3)
            {
                starsL9.sprite = threeStars;
            }

            //Level10
            if (PlayerPrefs.GetInt("Level10Score") == 0)
            {
                pointsL10.text = "";
            }
            else
            {
                pointsL10.text = PlayerPrefs.GetInt("Level10Score").ToString();
            }

            if (PlayerPrefs.GetInt("Level10Stars")==0)
            {
                starsL10.sprite = zeroStars;
            }

            if (PlayerPrefs.GetInt("Level10Stars")==1)
            {
                starsL10.sprite = oneStar;
            }

            if (PlayerPrefs.GetInt("Level10Stars")==2)
            {
                starsL10.sprite = twoStars;
            }

            if (PlayerPrefs.GetInt("Level10Stars")==3)
            {
                starsL10.sprite = threeStars;
            }

        
    }
}
