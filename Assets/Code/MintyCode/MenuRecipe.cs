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
    public Sprite recipeSprite; // New field for the recipe's sprite

    public bool IsMatch(Item[] items)
    {
        if (items.Length != recipe.Count)
        {
            return false;
        }

        for (int i = 0; i < items.Length; i++)
        {
            int requiredCount = recipe[i].requiredCount;
            int itemCount = GetItemCount(items, recipe[i].item);

            if (itemCount < requiredCount)
            {
                return false;
            }
        }

        return true;
    }

    public int GetDumplingScore(Item[] items)
    {
        if (IsMatch(items))
        {
            // Implement your logic to calculate the dumpling score based on the matched items
            // Return the corresponding score for the given items
            // You can access properties of the items to determine the score
            // For example: return items[0].score;
            return 0; // Default score if no specific score logic is implemented
        }
        else
        {
            return 0; // Score for mismatched items
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
