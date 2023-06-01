using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Inventory : MonoBehaviour, IItemContainer
{
    [FormerlySerializedAs("items")]
    [SerializeField] List<Item> startingItems;
    [SerializeField] Transform itemsParent;
    [SerializeField] ItemSlot[] itemSlots;



    private void Start()
    {

       for(int i = 0; i < itemSlots.Length; i++)
       {
        
        
       }
        SetStartingItems();
    }

    
    private void OnValidate()
    {
        if (itemsParent != null)
            itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();

        SetStartingItems();
    }

    private void SetStartingItems()
    {

        int i = 0;
        for (; i < startingItems.Count && i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = startingItems[i];
        }

        for (; i< itemSlots.Length; i++)
        {
            itemSlots[i].Item = null;
        }
    }

    public bool AddItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == null)
            {
                itemSlots[i].Item = item;
                return true;
            }
        }
        return false;
    }

    public bool RemoveItem(Item item)
    {
         for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == item)
            {
                itemSlots[i].Item = null;
                return true;
            }
        }
        return false;       
    }

    public bool IsFull()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == null)
            {
                return false;
            }
        }
        return true;
    }

    public bool ContainsItem(Item item)
    {
         for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == item)
            {
                return true;
            }
        }
        return false;       
    }

    public int ItemCount(Item item)
    {
        int number = 0;
         for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == item)
            {
                number++;
            }
        }
        return number;       
    }

}
