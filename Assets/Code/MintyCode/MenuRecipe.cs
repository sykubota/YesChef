using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MenuRecipe : ScriptableObject
{
    [System.Serializable]
    public class RecipeEntry
    {
        public Item item;
        public int requiredCount;
    }

    public List<RecipeEntry> recipe;
    public Sprite recipeSprite;
    public int dumplingScore;
    public string recipeName; // New field for the recipe's name

public bool IsMatch(Item[] items)
{
    if (items.Length != recipe.Count)
    {
        return false;
    }

    // Create a copy of the recipe entries list
    List<RecipeEntry> remainingRecipeEntries = new List<RecipeEntry>(recipe);

    foreach (Item item in items)
    {
        bool foundMatch = false;

        for (int i = 0; i < remainingRecipeEntries.Count; i++)
        {
            RecipeEntry recipeEntry = remainingRecipeEntries[i];

            if (recipeEntry.item == item)
            {
                // Check if the required count is matched
                if (recipeEntry.requiredCount == 1)
                {
                    // Remove the matched entry from the remaining list
                    remainingRecipeEntries.RemoveAt(i);
                }
                else
                {
                    // Decrement the required count
                    recipeEntry.requiredCount--;
                    remainingRecipeEntries[i] = recipeEntry;
                }

                foundMatch = true;
                break;
            }
        }

        if (!foundMatch)
        {
            return false;
        }
    }

    return remainingRecipeEntries.Count == 0;
}



    public int GetDumplingScore(Item[] items)
    {
        if (IsMatch(items))
        {
            return dumplingScore;
        }
        else
        {
            return 0;
        }
    }

    private int GetItemCount(Item[] items, Item item)
    {
        int count = 0;
        foreach (Item currentItem in items)
        {
            if (currentItem == item)
                count++;
        }
        return count;
    }
}
