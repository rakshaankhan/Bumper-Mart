using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
    private float speed = 100.0f;

    void Update()
    {
        if(transform.position.y < 1500)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
