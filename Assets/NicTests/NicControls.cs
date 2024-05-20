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
    public float m_speed = 10.0f;
    public float m_rotationspeed = 90.0f;
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




   
    //////////////// COLLISION BEHAVIORS ////////////////

    public float bounceOffset = 0.5f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        // Currently set only to trigger against "Shelf" tag
        if (collision.gameObject.tag == "Shelf")
        {

            ////////////// BOUNCE EFFECT ////////////////
            Vector2 bounceDirection = -collision.contacts[0].normal;
            transform.position -= (Vector3)(bounceDirection * bounceOffset);
            StartCoroutine(HandleBounce());



            //////////////// PLAYER BUMPING INTO ITEMS CODE /////////////////

            Shelf shelf = collision.gameObject.GetComponent<Shelf>();
            if (shelf != null)
            {
                ItemType itemType = shelf.GetItemType(); // get the type of item that is attached to that shelf
                inventoryManager.AddItem(new Item(itemType, itemType.ToString(), null, 1)); // adding item properties to the inventory manager
                inventoryManager.MarkItemCollected(itemType);  // Notify UI of new item

            }
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
