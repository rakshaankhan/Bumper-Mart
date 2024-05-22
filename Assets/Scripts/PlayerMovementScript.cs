using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

    public float m_speed = 10.0f;
    public float m_rotationspeed = 90.0f;

    private InventoryManager inventoryManager;
    private GameManager gameManager;


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

        gameManager = FindObjectOfType<GameManager>();

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



    private void OnCollisionEnter2D(Collision2D other)
    {

        if (gameManager.collectibles.Contains(other.gameObject))
        {
            Debug.Log("Player bumped into: " + other.gameObject.name);
            gameManager.CollectItem(other.gameObject);
            // Destroy(other.gameObject); // Optional: Destroy the collected item when we make items drop


            BounceEffect(other);


            // Handles the UI invantory and shopping list for now
            Shelf shelf = other.gameObject.GetComponent<Shelf>();
            ItemType itemType = shelf.GetItemType();
            inventoryManager.AddItem(new Item(itemType, itemType.ToString(), null, 1));
            inventoryManager.MarkItemCollected(itemType);

        }
        else if (other.gameObject.CompareTag("Cashier"))
        {
            BounceEffect(other);


            gameManager.EndGame();
        }
    }




    ////////////// BOUNCE EFFECT ////////////////
    public void BounceEffect(Collision2D collision)
    {
        Vector2 bounceDirection = -collision.contacts[0].normal;
        transform.position -= (Vector3)(bounceDirection * bounceOffset);
        StartCoroutine(HandleBounce());
    }

    private bool canMove = true; 
    public float bounceDuration = 1f;
    IEnumerator HandleBounce()
    {
        canMove = false;

        yield return new WaitForSeconds(bounceDuration);

        GetComponent<Rigidbody2D>().angularVelocity = 0f;

        canMove = true;
    }
}

