using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FailScreenScript : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Main Level");
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Debug.Log("Exiting");
        Application.Quit();
    }
}
