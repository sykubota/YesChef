using UnityEngine;

public class Oven : MonoBehaviour
{
    public MenuRecipe menuRecipe;
    public ScoreManager scoreManager;
    public GameObject platePrefab;

    private PlatePickup platePickup;

    private void Start()
    {
        platePickup = FindObjectOfType<PlatePickup>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (platePickup != null && platePickup.isPlateEquipped)
                {
                    Plate plate = platePickup.plate;
                    if (plate != null)
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

                        // Destroy the plate after processing
                        Destroy(plate.gameObject);
                    }
                }
            }
        }
    }
}
