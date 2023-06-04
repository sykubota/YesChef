using UnityEngine;
using System.Collections.Generic;

public class Oven : MonoBehaviour
{
    public MenuRecipe[] menuRecipes;
    public ScoreManager scoreManager;
    public GameObject platePrefab;
    public SpriteRenderer dumplingResultRenderer;

    public List<GameObject> plateObjects; // List of plate objects

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
                    Plate plate = platePickup.GetPlate();
                    if (plate != null)
                    {
                        if (plate.IsEmpty())
                        {
                            Debug.Log("Plate is empty. Adding 0 score.");
                            scoreManager.AddScore(0);
                        }
                        else if (plate.ItemCount2 < 3)
                        {
                            Debug.Log(plate.ItemCount(null));
                            Debug.Log("Plate is incomplete. Adding 0 score.");
                            scoreManager.AddScore(0);
                        }
                        else
                        {
                            // Get the combination of items on the plate
                            Item[] items = plate.GetItems();
                            bool isRecipeMatched = false;
                            MenuRecipe matchedRecipe = null;

                            foreach (MenuRecipe recipe in menuRecipes)
                            {
                                if (recipe.IsMatch(items))
                                {
                                    isRecipeMatched = true;
                                    matchedRecipe = recipe;
                                    break; // Exit the loop if a match is found
                                }
                            }

                            if (isRecipeMatched)
                            {
                                // Get the corresponding dumpling score
                                int dumplingScore = matchedRecipe.GetDumplingScore(items);
                                Debug.Log("Recipe matched! Adding dumpling score: " + dumplingScore);
                                scoreManager.AddScore(dumplingScore);

                                // Assign the sprite to DumplingResult sprite renderer
                                if (dumplingResultRenderer != null)
                                {
                                    dumplingResultRenderer.sprite = matchedRecipe.recipeSprite;
                                }
                                else
                                {
                                    Debug.LogWarning("DumplingResult SpriteRenderer is not assigned!");
                                }
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

    // Check if the specified GameObject is a plate object
    private bool IsPlateObject(GameObject gameObject)
    {
        return plateObjects.Contains(gameObject);
    }
}
