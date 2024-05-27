using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovementScript : MonoBehaviour
{

    public float m_speed = 10.0f;
    public float m_rotationspeed = 90.0f;

    private InventoryManager inventoryManager;
    private GameManager gameManager;
    private Shelf shelf;
    private AudioSource Bump;

    void Start()
    {

        inventoryManager = FindObjectOfType<InventoryManager>();
        gameManager = FindObjectOfType<GameManager>();
        Bump = GetComponent<AudioSource>();
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


            //targets the shelf that was collided with
            Shelf shelf = other.gameObject.GetComponent<Shelf>(); 
            shelf.DisableIcon();
            shelf.BrokenSprite();


            BounceEffect(other);


            // Handles the UI invantory and shopping list for now
            ItemType itemType = shelf.GetItemType();
            inventoryManager.AddItem(new Item(itemType, itemType.ToString(), null, 1));
            inventoryManager.MarkItemCollected(itemType);

        }
        else if (other.gameObject.CompareTag("Cashier"))
        {
            BounceEffect(other);


            gameManager.EndGame();
        }
        Debug.Log("Enter collision");
        if (gameObject.CompareTag("Player")
        && other.gameObject.CompareTag("NPC"))
        {

            Bump.Play();
            Debug.Log(" Play Sound ");

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

