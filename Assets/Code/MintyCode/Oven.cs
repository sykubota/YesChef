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
                        if (plate.IsEmpty())
                        {
                            Debug.Log("Plate is empty. Adding 0 score.");
                            scoreManager.AddScore(0);
                        }
                        else if (plate.ItemCount2 < 3)
                        {
                            Debug.Log (plate.ItemCount(null));
                            Debug.Log("Plate is incomplete. Adding 0 score.");
                            scoreManager.AddScore(0);
                        }
                        else
                        {
                            // Get the combination of items on the plate
                            Item[] items = plate.GetItems();
                            bool isRecipeMatched = menuRecipe.IsMatch(items);

                            Debug.Log("Items on the plate:");
                            foreach (Item item in items)
                            {
                                Debug.Log(item.itemName);
                            }

                            Debug.Log("Recipe required items:");
                            foreach (MenuRecipe.RecipeEntry entry in menuRecipe.recipe)
                            {
                                Debug.Log(entry.item.itemName + " x" + entry.requiredCount);
                            }

                            if (isRecipeMatched)
                            {
                                // Get the corresponding dumpling score
                                int dumplingScore = menuRecipe.GetDumplingScore(items);
                                Debug.Log("Recipe matched! Adding dumpling score: " + dumplingScore);
                                scoreManager.AddScore(dumplingScore);
                            }
                            else
                            {
                                Debug.Log("Recipe did not match. Adding 0 score.");
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
