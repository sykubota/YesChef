using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class Oven : MonoBehaviour
{
    public MenuRecipe[] menuRecipes;
    public ScoreManager scoreManager;
    public SpriteRenderer dumplingResultRenderer;
    public Sprite ovenActiveSprite;
    public PlateSpawner plateSpawner;
    public AudioSource soundPlayer;
    public AudioClip recipeMatchedSound;
    public TextMeshProUGUI recipeCountText;
    public TodaysSpecials todaysSpecials;

    private PlatePickup[] platePickups;
    private Sprite ovenDefaultSprite;
    private Dictionary<MenuRecipe, int> recipeCounts;

    public bool cooking = false;
    private int currentScore;

    private void Start()
    {
        ovenDefaultSprite = GetComponent<SpriteRenderer>().sprite;
        recipeCounts = new Dictionary<MenuRecipe, int>();
        UpdateRecipeCountText();
        GlobalGameManager.instance.levelPassed = false; // Reset levelPassed variable
        currentScore = 0;
        scoreManager.UpdateScore(currentScore);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                platePickups = FindObjectsOfType<PlatePickup>();
                foreach (PlatePickup platePickup in platePickups)
                {
                    Debug.Log("Platepickup null" + platePickup);
                    Debug.Log("Plate is equipped value" + platePickup.isPlateEquipped);

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
                                Debug.Log(plate.ItemCount(null));
                                Debug.Log("Plate is incomplete. Adding 0 score.");
                                scoreManager.AddScore(0);
                            }
                            else
                            {
                                // Get the combination of items on the plate
                                Item[] items = plate.GetItems();
                                MenuRecipe highestMatchedRecipe = null;
                                int highestMatchedScore = 0;

                                foreach (MenuRecipe recipe in menuRecipes)
                                {
                                    if (recipe.IsMatch(items))
                                    {
                                        int dumplingScore = recipe.GetDumplingScore(items);
                                        if (dumplingScore > highestMatchedScore)
                                        {
                                            highestMatchedRecipe = recipe;
                                            highestMatchedScore = dumplingScore;
                                        }
                                    }
                                }

                                if (highestMatchedRecipe != null)
                                {
                                    StartCoroutine(ProcessRecipeWithDelay(highestMatchedRecipe, items));
                                    cooking = true;
                                    // Increment the recipe count
                                    if (recipeCounts.ContainsKey(highestMatchedRecipe))
                                    {
                                        recipeCounts[highestMatchedRecipe]++;
                                    }
                                    else
                                    {
                                        recipeCounts.Add(highestMatchedRecipe, 1);
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
                            plateSpawner.SpawnPlate();
                        }
                    }
                }
            }
        }
    }

    private IEnumerator ProcessRecipeWithDelay(MenuRecipe recipe, Item[] items)
    {
        // Change the oven sprite to active
        GetComponent<SpriteRenderer>().sprite = ovenActiveSprite;
        // Play the sound 
        soundPlayer.PlayOneShot(recipeMatchedSound);

        // Delay for a certain amount of time
        yield return new WaitForSeconds(2.0f); // Adjust the delay time as needed

        // Get the corresponding dumpling score
        int dumplingScore = recipe.GetDumplingScore(items);
        Debug.Log("Recipe matched! Adding dumpling score: " + dumplingScore);
        currentScore += dumplingScore;

        // Assign the sprite to DumplingResult sprite renderer
        if (dumplingResultRenderer != null)
        {
            dumplingResultRenderer.sprite = recipe.recipeSprite;
        }
        else
        {
            Debug.LogWarning("DumplingResult SpriteRenderer is not assigned!");
        }

        // Change the oven sprite back to default
        GetComponent<SpriteRenderer>().sprite = ovenDefaultSprite;

        UpdateRecipeCountText(); // Call the method to update the text display

        // Check if the recipe counts meet the requirements of Today's Specials
        if (todaysSpecials != null && CheckSpecialsRequirements())
        {
            currentScore += todaysSpecials.points;
            scoreManager.UpdateScore(currentScore);
            GlobalGameManager.instance.levelPassed = true;
        }
    }

    private bool CheckSpecialsRequirements()
    {
        foreach (Dumpling dumpling in todaysSpecials.dumplings)
        {
            int requiredQuantity = dumpling.requiredQuantity;
            int actualQuantity = GetRecipeCount(dumpling.dumplingObject);

            if (actualQuantity < requiredQuantity)
            {
                return false; // Requirements not met
            }
        }

        return true; // All requirements met
    }

    private int GetRecipeCount(ScriptableObject recipeObject)
    {
        foreach (var recipeCount in recipeCounts)
        {
            if (recipeCount.Key == recipeObject)
            {
                return recipeCount.Value;
            }
        }
        return 0; // Recipe not found
    }

    private void UpdateRecipeCountText()
    {
        string countText = "Recipe Counts:\n";

        foreach (var recipeCount in recipeCounts)
        {
            countText += recipeCount.Key.recipeName + ": " + recipeCount.Value + "\n";
        }

        recipeCountText.text = countText;
    }
}
