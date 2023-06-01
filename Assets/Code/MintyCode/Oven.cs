using UnityEngine;

public class Oven : MonoBehaviour
{
    public Plate plate;
    public MenuRecipe menuRecipe;
    public ScoreManager scoreManager;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.F))
            {
                if (plate.IsEmpty() || plate.ItemCount(null) < 3)
                {
                    // Create a mystery dumpling that earns 0 points
                    scoreManager.AddScore(0);
                }
                else
                {
                    // Get the combination of items on the plate
                    Item[] items = plate.GetItems();
                    bool isRecipeMatched = menuRecipe.IsMatch(items);

                    if (isRecipeMatched)
                    {
                        // Get the corresponding dumpling score
                        int dumplingScore = menuRecipe.GetDumplingScore(items);

                        // Add the dumpling score to the total score
                        scoreManager.AddScore(dumplingScore);
                    }
                    else
                    {
                        // Create a mystery dumpling that earns 0 points
                        scoreManager.AddScore(0);
                    }
                }

                // Clear the plate after processing
                plate.Clear();
            }
        }
    }
}
