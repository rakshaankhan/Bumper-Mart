using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinEndScript : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadScene("Main level");
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
