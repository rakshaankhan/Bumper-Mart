using System.Collections;
using UnityEngine;

public class NicControls : MonoBehaviour
{
    private InventoryManager inventoryManager;

    private void Start()
    {
        if (inventoryManager == null)
        {
            inventoryManager = FindObjectOfType<InventoryManager>();

            if (inventoryManager == null)
            {
                Debug.LogError("InventoryManager not found!");
            }
        }
    }

    /////////// DONT USE THESE MOVEMENT CONTROLS ///////////
    public float moveSpeed = 5f;
    void Update()
    {
        if (canMove)
        {
            // Get raw input from WASD keys
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            // Create a new movement vector
            Vector2 movement = new Vector2(moveX, moveY).normalized;

            // Move the player
            transform.Translate(movement * moveSpeed * Time.deltaTime);
        }
    }




   
    ///////// THIS IS HANDLING THE BOUNCE EFFECT /////////

    public float bounceOffset = 0.5f;
    public float bounceDuration = 1f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Currently set only to trigger against "Isle" tag
        if (collision.gameObject.tag == "Shelf")
        {
            // Calculate bounce direction
            Vector2 bounceDirection = -collision.contacts[0].normal;

            // Bounce away from collision
            transform.position -= (Vector3)(bounceDirection * bounceOffset);

            StartCoroutine(HandleBounce());


            Shelf shelf = collision.gameObject.GetComponent<Shelf>();
            if (shelf != null)
            {
                ItemType itemType = shelf.GetItemType();
                inventoryManager.AddItem(new Item(itemType, itemType.ToString(), null, 1));  // Adjust as needed
                inventoryManager.MarkItemCollected(itemType);  // Notify UI

            }
        }
    }

    // Add this bool to the update section of player controller (WASD)
    private bool canMove = true;

    IEnumerator HandleBounce()
    {
        canMove = false;
        
        yield return new WaitForSeconds(bounceDuration);

        GetComponent<Rigidbody2D>().angularVelocity = 0f;

        canMove = true;
    }
}
