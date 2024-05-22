using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public List<Item> potentialItems = new List<Item>(); // List of all possible items
    public List<Item> inventoryItems = new List<Item>(); // List of collected items
    public List<ItemType> shoppingListItems = new List<ItemType>(); // List of required items
    public TextMeshProUGUI allItemsText;

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

        //if (AllItemsCollected())
        //{
        //    Debug.Log("Congratulations! You've collected all items and finished the game.");

        //    allItemsText.enabled = true;
        //}
        //else
        //{
        //    allItemsText.enabled = false;
        //}
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

    //public bool AllItemsCollected()
    //{
    //    HashSet<ItemType> requiredItemsSet = new HashSet<ItemType>(shoppingListItems);
    //    HashSet<ItemType> collectedItemsSet = new HashSet<ItemType>();

    //    foreach (Item inventoryItem in inventoryItems)
    //    {
    //        collectedItemsSet.Add(inventoryItem.itemType);
    //    }

    //    foreach (ItemType requiredItem in requiredItemsSet)
    //    {
    //        if (!collectedItemsSet.Contains(requiredItem))
    //        {
    //            Debug.Log("Item not found in inventory: " + requiredItem);
    //            return false;
    //        }
    //    }

    //    Debug.Log("All items collected!");
    //    return true;

    //}

    public void FinishGame()
    {
        Debug.Log("Congratulations! You've collected all items and finished the game.");
        // Add any additional game completion logic here
    }
}
