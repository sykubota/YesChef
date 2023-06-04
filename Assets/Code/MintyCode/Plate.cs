using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
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
            if (itemHolder != null && itemHolder.item != null && isCollidingWithPlayer)
            {
                float distance = Vector3.Distance(transform.position, other.transform.position);
                if (distance <= registrationRange)
                {
                    if (IsFull())
                    {

                    }
                    else
                    {
                        AddItem(itemHolder.item);
                        Destroy(other.gameObject);
                    }
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
        if (IsFull()) // Check if the plate is already full
            return false;

        items.Add(item);
        return true;
    }

    public bool RemoveItem(Item item)
    {
        if (items.Remove(item))
        {
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
    }

    private void RespawnPlate()
    {
        Instantiate(gameObject, plateSpawnPoint.position, plateSpawnPoint.rotation);
    }
}
