using TMPro;
using UnityEngine;

public class IntegerPrinter : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        if (textMeshPro == null)
        {
            Debug.LogError("TextMeshProUGUI component is not assigned!");
            return;
        }

        // Get the integer value from the ScoreManager script
        int score = scoreManager.score;

        // Update the TextMeshPro component
        textMeshPro.text = score.ToString();
    }

}