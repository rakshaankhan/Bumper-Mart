using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

    public float m_speed = 10.0f;
    public float m_rotationspeed = 90.0f;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
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

    void OnCollisionEnter2D(Collision2D collision)
    {

        // Currently set only to trigger against "Shelf" tag
        if (collision.gameObject.tag == "Shelf")
        {

            ////////////// BOUNCE EFFECT ////////////////
            Vector2 bounceDirection = -collision.contacts[0].normal;
            transform.position -= (Vector3)(bounceDirection * bounceOffset);
            StartCoroutine(HandleBounce());
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
