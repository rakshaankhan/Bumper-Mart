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
        float m_vertialInput = Input.GetAxis("Vertical");
        float m_horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.up * Time.deltaTime * m_speed * m_vertialInput);
        transform.Rotate(Vector3.back, Time.deltaTime * m_rotationspeed * m_horizontalInput);

    }
}
