using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ItemAmount
{
    public Item Item;
    [Range(0,3)]
    public int Amount;
}

[CreateAssetMenu]
public class MenuRecipe : ScriptableObject
{
   public List<ItemAmount> Ingredients;
   public List<ItemAmount> Dumplings;

   public bool CanCraft(IItemContainer itemContainer)
   {
        foreach(ItemAmount itemAmount in Ingredients)
        {
            if (itemContainer.ItemCount(itemAmount.Item) < itemAmount.Amount)
            {
                return false;
            }
        }
        return true;
   }
    
    public void Craft(IItemContainer itemContainer)
    {
        if (CanCraft(itemContainer))
        {
            foreach (ItemAmount itemAmount in Ingredients)
            {
                for (int i = 0; i < itemAmount.Amount; i++)
                {
                    itemContainer.RemoveItem(itemAmount.Item);
                }
            }

            foreach (ItemAmount itemAmount in Dumplings)
            {
                for (int i = 0; i < itemAmount.Amount; i++)
                {
                    itemContainer.AddItem(itemAmount.Item);
                }
            }
        }
        
    }

}
