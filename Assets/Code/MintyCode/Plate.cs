using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour, IItemContainer
{
    public Transform plateSpawnPoint;
    [SerializeField] private List<Item> items = new List<Item>();

    public float registrationRange = 1f; // Adjust the range value as needed

    private bool isCollidingWithPlayer = false;

    public bool IsCollidingWithPlayer()
    {
        return isCollidingWithPlayer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCollidingWithPlayer = true;
        }
        else if (other.CompareTag("Item"))
        {
            ItemHolder itemHolder = other.GetComponent<ItemHolder>();
            if (itemHolder != null && itemHolder.item != null)
            {
                // Check if the dropped object is close enough to this plate
                float distance = Vector3.Distance(transform.position, other.transform.position);
                if (distance <= registrationRange)
                {
                    AddItem(itemHolder.item);
                    Destroy(other.gameObject);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCollidingWithPlayer = false;
        }
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
