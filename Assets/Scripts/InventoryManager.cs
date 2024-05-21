using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<Item> potentialItems = new List<Item>(); // List of all possible items
    public List<Item> inventoryItems = new List<Item>(); // List of collected items
    public List<ItemType> shoppingListItems = new List<ItemType>(); // List of required items

    private ShoppingListUI shoppingListUI;

    private void Start()
    {
        shoppingListUI = FindObjectOfType<ShoppingListUI>();
        if (shoppingListUI == null)
        {
            Debug.LogError("ShoppingListUI not found!");
        }
    }

    public void SetShoppingList(List<ItemType> items)
    {
        shoppingListItems = items;
    }

    public void AddItem(Item item)
    {
        inventoryItems.Add(item);

        string inventoryContents = "Currently holding: ";
        foreach (Item inventoryItem in inventoryItems)
        {
            inventoryContents += inventoryItem.itemName + ", ";
        }

        Debug.Log(inventoryContents.TrimEnd(',', ' '));
    }

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

    public List<Item> GetInventoryItems()
    {
        return inventoryItems;
    }
}
