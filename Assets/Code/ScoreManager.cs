using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI scoreText;

    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
       scoreText.text = score.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
