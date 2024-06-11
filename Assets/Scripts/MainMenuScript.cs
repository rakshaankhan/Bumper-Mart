using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject options;

    public AudioSource musicSlider;

    void awake()
    {
        if(PlayerPrefs.HasKey("musicVolume"))
        {
            musicSlider.volume = PlayerPrefs.GetFloat("musicVolume");
        }
    }

    public void Startgame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Options()
    {
        options.SetActive(true);
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ReturnAndSave()
    {
        options.SetActive(false);
    }
}
