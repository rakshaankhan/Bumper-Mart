using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public void Startgame()
    {
        Debug.Log("Starting Game");
        // SceneManager.LoadScene("");
    }

    public void Options()
    {
        Debug.Log("Options");
        // SceneManager.LoadScene("");
    }

    public void Credits()
    {
        Debug.Log("Credits");
        // SceneManager.LoadScene("");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
