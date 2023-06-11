using UnityEngine;
using TMPro;

public class textrandom : MonoBehaviour
{
    public TMP_Text resultText;        // Reference to the TextMeshPro UI element
    public string[] goodResults;       // Array of strings for good results
    public string[] mediumResults;     // Array of strings for medium results
    public string[] badResults;        // Array of strings for bad results
    public string[] terribleResults;   // Array of strings for terrible results
    public ScoreManager scoreManager;
    public float threeStarPoints = 1f;
    public float twoStarPoints = 1f;
    public float oneStarPoints = 1f;

private void Start()
{
    int playerScore = scoreManager.score;

    string selectedResult = "";

    if (playerScore >= threeStarPoints)
        selectedResult = GetRandomString(goodResults);
    else if (playerScore >= twoStarPoints)
        selectedResult = GetRandomString(mediumResults);
    else if (playerScore >= oneStarPoints)
        selectedResult = GetRandomString(badResults);
    else
        selectedResult = GetRandomString(terribleResults);

    // Print the selected result
    resultText.text = selectedResult;
}

    private string GetRandomString(string[] sourceArray)
    {
        if (sourceArray.Length == 0)
            return "";

        int randomIndex = Random.Range(0, sourceArray.Length);
        return sourceArray[randomIndex];
    }

    private int CalculatePlayerScore()
    {
        // Replace this method with your own score calculation logic
        // Return the player's score as an integer value
        // Example: return yourScoreCalculationLogic();
        return 80;
    }
}