using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public void Startgame()
    {
        Debug.Log("Starting Game");
        SceneManager.LoadScene("Game");
    }

    public void Options()
    {
        Debug.Log("Options");
        // SceneManager.LoadScene("");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Exit()
    {
        Debug.Log("Exiting");
        Application.Quit();
    }
}
