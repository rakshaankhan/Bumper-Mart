using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour
{
    public GameObject cashierCounter; // The cashier counter GameObject

    private InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        if (inventoryManager == null)
        {
            Debug.LogError("InventoryManager not found!");
        }
    }

    // Check if all items have been collected
    public bool AllItemsCollected()
    {
        foreach (ItemType requiredItem in inventoryManager.shoppingListItems)
        {
            bool itemFound = false;
            foreach (Item inventoryItem in inventoryManager.inventoryItems)
            {
                if (inventoryItem.itemType == requiredItem)
                {
                    itemFound = true;
                    break;
                }
            }
            if (!itemFound)
            {
                return false;
            }
        }
        return true;
    }

    // Method to call when the game is finished
    public void FinishGame()
    {
        Debug.Log("Congratulations! You've collected all items and finished the game.");
        // Add any additional game completion logic here
    }
}
