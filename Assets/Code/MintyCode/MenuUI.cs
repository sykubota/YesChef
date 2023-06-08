using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuUI : MonoBehaviour
{
    public Oven oven;
    public Image[] recipeSprites; // Array of image objects representing the menu recipe sprites
    public Image[] ingredientIcons; // Array of image objects representing the ingredient icons
    public TextMeshProUGUI[] scoreTexts; // Array of TMP text objects representing the dumpling scores

    private void Start()
    {
        UpdateMenuUI();
    }

    private void UpdateMenuUI()
    {
        MenuRecipe[] menuRecipes = oven.menuRecipes;

        for (int i = 0; i < 3; i++) // Only update the first three recipes
        {
            if (i < menuRecipes.Length)
            {
                MenuRecipe recipe = menuRecipes[i];
                recipeSprites[i].sprite = recipe.recipeSprite;

                for (int j = 0; j < 3; j++) // Only update the first three ingredients
                {
                    if (j < recipe.recipe.Count)
                    {
                        MenuRecipe.RecipeEntry recipeEntry = recipe.recipe[j];
                        if (recipeEntry.item != null)
                        {
                            ingredientIcons[i * 3 + j].sprite = recipeEntry.item.icon;
                        }
                    }
                    else
                    {
                        ingredientIcons[i * 3 + j].sprite = null; // No ingredient, clear the icon
                    }
                }

                scoreTexts[i].text = "" + recipe.dumplingScore; // Update the TMP text with dumpling score
            }
            else
            {
                recipeSprites[i].sprite = null; // No recipe, clear the sprite
                ClearIngredientIcons(i * 3);
                scoreTexts[i].text = ""; // Clear the TMP text
            }
        }
    }

    private void ClearIngredientIcons(int startIndex)
    {
        for (int i = startIndex; i < startIndex + 3; i++)
        {
            ingredientIcons[i].sprite = null;
        }
    }
}
