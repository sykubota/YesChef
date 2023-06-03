using System.Collections.Generic;
using UnityEngine;

public class DishManager : MonoBehaviour
{
    public Dictionary<List<GameObject>, int> dishCombinations = new Dictionary<List<GameObject>, int>();

    public List<GameObject> trashPieces; // List of all trash pieces available
    public int dishSize = 3; // Number of trash pieces required to create a dish

    private void Start()
    {
        // Define the dish combinations and their point values
        List<List<GameObject>> combinations = GenerateCombinations(trashPieces, dishSize);

        // Assign random point values to each combination
        foreach (var combination in combinations)
        {
            int pointValue = Random.Range(1, 10); // Random point value
            dishCombinations.Add(combination, pointValue);
        }
    }

    // Get the point value for a given dish combination
    public int GetDishPointValue(List<GameObject> combination)
    {
        int pointValue = 0;
        dishCombinations.TryGetValue(combination, out pointValue);
        return pointValue;
    }

    // Generate all possible combinations of a given size from a list of items
    private List<List<GameObject>> GenerateCombinations(List<GameObject> items, int size)
    {
        List<List<GameObject>> combinations = new List<List<GameObject>>();
        GenerateCombinationsRecursive(items, size, new List<GameObject>(), combinations);
        return combinations;
    }

    // Recursive function to generate combinations
    private void GenerateCombinationsRecursive(List<GameObject> items, int size, List<GameObject> currentCombination, List<List<GameObject>> combinations)
    {
        if (currentCombination.Count == size)
        {
            combinations.Add(new List<GameObject>(currentCombination));
            return;
        }

        for (int i = 0; i < items.Count; i++)
        {
            GameObject currentItem = items[i];

            if (!currentCombination.Contains(currentItem))
            {
                currentCombination.Add(currentItem);
                GenerateCombinationsRecursive(items, size, currentCombination, combinations);
                currentCombination.Remove(currentItem);
            }
        }
    }
}
