using TMPro;
using UnityEngine;

public class IntegerPrinter : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    private void Start()
    {
        if (textMeshPro == null)
        {
            Debug.LogError("TextMeshProUGUI component is not assigned!");
            return;
        }

        // Get the integer value from the ScoreManager script
        int score = ScoreManager.score;

        // Update the TextMeshPro component
        textMeshPro.text = score.ToString();
    }
}