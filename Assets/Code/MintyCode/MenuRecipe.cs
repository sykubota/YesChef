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
