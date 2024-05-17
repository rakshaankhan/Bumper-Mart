using System.Collections;
using UnityEngine;

public class NicControls : MonoBehaviour
{

    ///
    ///DONT USE THESE MOVEMENT CONTROLS
    ///
 

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




    /// 
    /// THIS IS HANDLING THE BOUNCE EFFECT
    ///


    public float bounceOffset = 0.5f;
    public float bounceDuration = 1f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Isle")
        {
            // Calculate bounce direction
            Vector2 bounceDirection = -collision.contacts[0].normal;

            // Bounce away from collision
            transform.position -= (Vector3)(bounceDirection * bounceOffset);

            
            StartCoroutine(HandleBounce());
        }
    }


    private bool canMove = true;

    IEnumerator HandleBounce()
    {
        canMove = false;
        
        yield return new WaitForSeconds(bounceDuration);

        GetComponent<Rigidbody2D>().angularVelocity = 0f;

        canMove = true;
    }
}
