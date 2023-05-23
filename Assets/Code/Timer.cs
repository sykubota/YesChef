using UnityEngine;
using TMPro;

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
    public float interval = 1f;

    void Start()
    {
        // Start the timer.
        timer = 0f;

        // Spawn a random item from the set.
        int randomIndex = Random.Range(0, items.Length);
        GameObject item = Instantiate(items[randomIndex], transform.position, Quaternion.identity);

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

            // Spawn a random item from the set.
            int randomIndex = Random.Range(0, items.Length);
            GameObject item = Instantiate(items[randomIndex], transform.position, Quaternion.identity);

            // Call the OnItemSpawned function.
            OnItemSpawned(item);
        }
    }
}