using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour
{
    public GameObject[] items; // Array to hold all items to be collected
    public GameObject cashierCounter; // The cashier counter GameObject
    private bool[] itemsCollected; // Array to keep track of collected items

    void Start()
    {
        // Initialize the itemsCollected array
        itemsCollected = new bool[items.Length];
    }

    void Update()
    {
        // Check if the player reaches the cashier counter
        if (Vector3.Distance(transform.position, cashierCounter.transform.position) < 1.0f)
        {
            if (AllItemsCollected())
            {
                FinishGame();
            }
            else
            {
                Debug.Log("You need to collect all items before checking out!");
            }
        }
    }

    // Method to call when an item is collected
    public void CollectItem(GameObject item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == item)
            {
                itemsCollected[i] = true;
                Destroy(item); // Optionally destroy the item GameObject
                break;
            }
        }
    }

    // Check if all items have been collected
    bool AllItemsCollected()
    {
        foreach (bool collected in itemsCollected)
        {
            if (!collected)
            {
                return false;
            }
        }
        return true;
    }

    // Method to call when the game is finished
    void FinishGame()
    {
        Debug.Log("Congratulations! You've collected all items and finished the game.");
        // Add any additional game completion logic here
    }
}
