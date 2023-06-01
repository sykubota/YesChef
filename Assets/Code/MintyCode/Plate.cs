using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour, IItemContainer
{
    public Transform plateSpawnPoint;
    [SerializeField] private List<Item> items = new List<Item>();

    public bool IsCollidingWithPlayer()
{
    Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2);
    foreach (Collider collider in colliders)
    {
        if (collider.CompareTag("Player"))
        {
            return true;
        }
    }
    return false;
}

    public bool AddItem(Item item)
    {
        if (items.Count >= 3) // Assuming the plate can hold a maximum of 3 items
            return false;

        items.Add(item);
        UpdateUI();
        return true;
    }

    public bool RemoveItem(Item item)
    {
        if (items.Remove(item))
        {
            UpdateUI();
            RespawnPlate(); // Respawn a plate when it is removed
            return true;
        }
        return false;
    }

    public bool IsFull()
    {
        return items.Count == 3; // Assuming the plate can hold a maximum of 3 items
    }

    public bool IsEmpty()
    {
        return items.Count == 0;
    }

    public bool ContainsItem(Item item)
    {
        return items.Contains(item);
    }

    public int ItemCount(Item item)
    {
        int count = 0;
        foreach (Item currentItem in items)
        {
            if (currentItem == item)
                count++;
        }
        return count;
    }

    public Item[] GetItems()
    {
        return items.ToArray();
    }

    public void Clear()
    {
        items.Clear();
        UpdateUI();
    }

    private void UpdateUI()
    {
        // Update the UI to reflect the items on the plate
    }

    private void RespawnPlate()
    {
        Instantiate(gameObject, plateSpawnPoint.position, plateSpawnPoint.rotation);
    }
}
