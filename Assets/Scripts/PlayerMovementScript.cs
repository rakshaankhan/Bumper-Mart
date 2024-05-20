using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

    public float m_speed = 10.0f;
    public float m_rotationspeed = 90.0f;

    private InventoryManager inventoryManager;
    private Final finalScript;


    void Start()
    {
        if (inventoryManager == null)
        {
            inventoryManager = FindObjectOfType<InventoryManager>();

            if (inventoryManager == null)
            {
                Debug.LogError("InventoryManager not found!");
            }
        }

        finalScript = FindObjectOfType<Final>();

    }

    void Update()
    {
        if (canMove)
        {
            float m_vertialInput = Input.GetAxis("Vertical");
            float m_horizontalInput = Input.GetAxis("Horizontal");

            transform.Translate(Vector3.up * Time.deltaTime * m_speed * m_vertialInput);
            transform.Rotate(Vector3.back, Time.deltaTime * m_rotationspeed * m_horizontalInput);
        }
    }

    public float bounceOffset = 0.5f;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Shelf"))
        {
            HandleShelfCollision(collision);
        }
        else if (collision.gameObject.CompareTag("Cashier"))
        {
            HandleCashierCounterCollision(collision);
        }
    }

    private void HandleShelfCollision(Collision2D collision)
    {
        // BOUNCE EFFECT
        Vector2 bounceDirection = -collision.contacts[0].normal;
        transform.position -= (Vector3)(bounceDirection * bounceOffset);
        StartCoroutine(HandleBounce());


        Shelf shelf = collision.gameObject.GetComponent<Shelf>();
        if (shelf != null)
        {
            ItemType itemType = shelf.GetItemType(); // get the type of item that is attached to that shelf
            inventoryManager.AddItem(new Item(itemType, itemType.ToString(), null, 1)); // adding item properties to the inventory manager
            inventoryManager.MarkItemCollected(itemType);  // Notify UI of new item
        }
    }

    private void HandleCashierCounterCollision(Collision2D collision)
    {
        // BOUNCE EFFECT
        Vector2 bounceDirection = -collision.contacts[0].normal;
        transform.position -= (Vector3)(bounceDirection * bounceOffset);
        StartCoroutine(HandleBounce());

        if (finalScript.AllItemsCollected())
        {
            finalScript.FinishGame();
        }
        else
        {
            Debug.Log("You need to collect all items before checking out!");
        }

    }

    ////////////// BOUNCE EFFECT ////////////////
    private bool canMove = true; // add this bool to an if statement to stop player from moving for 1 second
    public float bounceDuration = 1f;
    IEnumerator HandleBounce()
    {
        canMove = false;

        yield return new WaitForSeconds(bounceDuration);

        GetComponent<Rigidbody2D>().angularVelocity = 0f;

        canMove = true;
    }
}
