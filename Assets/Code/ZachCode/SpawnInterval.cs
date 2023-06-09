using UnityEngine;

public class SpawnInterval : MonoBehaviour
{
    // The set of items to spawn from.
    public GameObject[] items;

    // The function to call when an item is spawned.
    public void OnItemSpawned(GameObject item)
    {
        // Do something with the item.
    }

    // The timer.
    private float timer;

    // The interval between spawns.
    public float interval = 1;

    // Flag indicating if it's the second spawner.
    public bool isSecondSpawner = false;

    void Start()
    {
        // Start the timer.
        timer = 0;

        // Spawn a random item from the set.
        int randomIndex = Random.Range(0, items.Length);
        GameObject item = Instantiate(items[randomIndex], transform.position, Quaternion.identity);

        // Set the correct initial position
        Vector3 newPosition = item.transform.position;
        newPosition.z = 20; // Ensure the Z-coordinate is set to 0
        item.transform.position = newPosition;

        // Call the OnItemSpawned function.
        OnItemSpawned(item);

        // Set the appropriate movement behavior based on the spawner
        ConveyorBelt conveyorBelt = item.GetComponent<ConveyorBelt>();
        if (conveyorBelt != null)
        {
            conveyorBelt.isSecondSpawner = isSecondSpawner;
        }
    }

    void Update()
    {
        // Update the timer.
        timer += Time.deltaTime;

        // If the timer has reached the desired interval, spawn a new item.
        if (timer >= interval)
        {
            timer = 0;

            // Spawn a random item from the set.
            int randomIndex = Random.Range(0, items.Length);
            GameObject item = Instantiate(items[randomIndex], transform.position, Quaternion.identity);

            // Set the appropriate movement behavior based on the spawner
            ConveyorBelt conveyorBelt = item.GetComponent<ConveyorBelt>();
            if (conveyorBelt != null)
            {
                conveyorBelt.isSecondSpawner = isSecondSpawner;
            }

            // Call the OnItemSpawned function.
           OnItemSpawned(item);
        }
    }
}
