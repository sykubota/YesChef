using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IntegerPrinter : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    private void Start()
    {
        // Get the integer value from the ScoreManager script
        int score = 60;

        // Update the TextMeshPro component
        textMeshPro.text = score.ToString();
    }
}