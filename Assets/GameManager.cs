using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [Tooltip("List of collectible items in the game.")]
    public List<GameObject> collectibles;

    [Tooltip("The object to collide with to end the game.")]
    public GameObject endGameObject;

    private HashSet<GameObject> collectedItems = new HashSet<GameObject>();

    [Tooltip("Event triggered when the game ends.")]
    public UnityEvent onGameEnd;

    private void Start()
    {
        if (collectibles == null)
        {
            Debug.LogError("Collectibles list is not assigned.");
        }

        if (endGameObject == null)
        {
            Debug.LogError("End game object is not assigned.");
        }

        if (onGameEnd == null)
        {
            onGameEnd = new UnityEvent();
        }
    }

    // Check if all items are collected
    public bool AreAllItemsCollected()
    {
        return collectedItems.Count == collectibles.Count;
    }

    // Mark an item as collected
    public void CollectItem(GameObject item)
    {
        if (collectibles.Contains(item) && !collectedItems.Contains(item))
        {
            collectedItems.Add(item);
            Debug.Log($"Item collected: {item.name}");
        }
    }

    // End game logic
    public void EndGame()
    {
        if (AreAllItemsCollected())
        {
            onGameEnd.Invoke();
            Debug.Log("Game Over! All items collected.");
            // Implement your end game logic here (e.g., load a new scene, display a message, etc.)
            SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("You need to collect all items first!");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject == endGameObject)
        {
            EndGame();
        }
    }
   
}
