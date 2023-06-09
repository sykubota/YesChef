using UnityEngine;

public class SpawnInterval : MonoBehaviour
{
    // The set of items to spawn from, along with their respective weights.
    public WeightedItem[] weightedItems;

    // The function to call when an item is spawned.
    public void OnItemSpawned(GameObject item)
    {
        // Do something with the item.
        ConveyorBelt conveyor = item.GetComponent<ConveyorBelt>();
        if (conveyor != null)
        {
            conveyor.SetMoveState(true); // Start moving the item
        }
    }

    // The timer.
    private float timer;

    // The interval between spawns.
    public float interval = 1f;

    // Flag indicating if it's the second spawner.
    public bool isSecondSpawner = false;

    void Start()
    {
        // Start the timer.
        timer = 0f;

        // Spawn an item based on the weighted distribution.
        GameObject item = SpawnWeightedItem();

        // Set the correct initial position.
        Vector3 newPosition = item.transform.position;
        newPosition.z = 12f; // Ensure the Z-coordinate is set to 0.
        item.transform.position = newPosition;

        // Call the OnItemSpawned function.
        OnItemSpawned(item);
    }

    void Update()
    {
        // Update the timer.
        timer += Time.deltaTime;

        // If the timer has reached the desired interval, spawn a new item.
        if (timer >= interval)
        {
            timer = 0f;

            // Spawn an item based on the weighted distribution.
            GameObject item = SpawnWeightedItem();

            // Call the OnItemSpawned function.
            OnItemSpawned(item);
        }
    }

    GameObject SpawnWeightedItem()
    {
        // Calculate the total weight of all items.
        float totalWeight = 0f;
        foreach (var weightedItem in weightedItems)
        {
            totalWeight += weightedItem.weight;
        }

        // Generate a random number within the total weight range.
        float randomWeight = Random.Range(0f, totalWeight);

        // Select the item based on its weight.
        float weightSum = 0f;
        foreach (var weightedItem in weightedItems)
        {
            weightSum += weightedItem.weight;

            // If the random weight falls within the current weight range, spawn the corresponding item.
            if (randomWeight <= weightSum)
            {
                GameObject newItem = Instantiate(weightedItem.item, transform.position, Quaternion.identity);
                ConveyorBelt conveyor = newItem.GetComponent<ConveyorBelt>();
                if (conveyor != null)
                {
                    conveyor.isSecondSpawner = isSecondSpawner; // Set the flag indicating if it's the second spawner
                    conveyor.SetMoveState(false); // Stop moving the item initially
                }
                return newItem;
            }
        }

        // This line should not be reached, but return null just in case.
        return null;
    }

    [System.Serializable]
    public class WeightedItem
    {
        public GameObject item;
        public float weight;
    }
}
