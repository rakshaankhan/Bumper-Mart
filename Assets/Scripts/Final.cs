using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour
{
    private GameObject[] items; // Array to hold all items to be collected
    public GameObject cashierCounter; // The cashier counter GameObject

    private bool[] itemsCollected; // Array to keep track of collected items
    private InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        if (inventoryManager == null)
        {
            Debug.LogError("InventoryManager not found!");
        }
    }

    public void InitializeItems(GameObject[] collectedItems)
    {
        items = collectedItems;
    }

    // Check if all items have been collected
    public bool AllItemsCollected()
    {
        foreach (GameObject item in items)
        {
            ItemType itemType = item.GetComponent<Shelf>().GetItemType();
            bool itemFound = false;
            foreach (Item inventoryItem in inventoryManager.inventoryItems)
            {
                if (inventoryItem.itemType == itemType)
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
