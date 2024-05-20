using System.Collections.Generic;
using UnityEngine;




public class InventoryManager : MonoBehaviour
{
    
    public List<Item> inventoryItems = new List<Item>(); // The list of items in player inventory //
    private ShoppingListUI shoppingListUI;

    private void Start()
    {
        shoppingListUI = FindObjectOfType<ShoppingListUI>();
    }


    ///////////// METHOD TO ADD AN ITEM TO THE INVENTORY //////////////////
    public void AddItem(Item item)
    {
        inventoryItems.Add(item);

        // Build a single string with all item names
        string inventoryContents = "Currently holding: ";
        foreach (Item items in inventoryItems)
        {
            inventoryContents += items.itemName + ", ";
        }

        // Print the entire inventory in one log statement
        Debug.Log(inventoryContents.TrimEnd(',', ' '));
    }


    /////////////////// CHECKS FOR A SPECIFIC ITEM ///////////////
    public bool HasItem(ItemType itemType)
    {
        foreach (Item item in inventoryItems)
        {
            if (item.itemType == itemType)
            {
                return true;
            }
        }
        return false;
    }



    public void MarkItemCollected(ItemType itemType)
    {
        shoppingListUI.MarkItemCollected(itemType);
    }
}
