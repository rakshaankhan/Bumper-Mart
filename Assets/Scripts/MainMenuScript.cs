using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public GameObject options;
    public GameObject mainMenuGO;
    public GameObject ExitText;

    public Slider musicSlider;
    public AudioSource audioS;

    void Awake()
    {
        if(PlayerPrefs.HasKey("musicVolume"))
        {
            audioS.volume = PlayerPrefs.GetFloat("musicVolume");
        }
        if(PlayerPrefs.HasKey("musicTime"))
        {
            audioS.time = PlayerPrefs.GetFloat("musicTime");
        }
    }

    public void Startgame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Options()
    {
        options.SetActive(true);
        PlayerPrefs.SetFloat("musicVolumePrev", audioS.volume);
    }

    public void Credits()
    {
        PlayerPrefs.SetFloat("musicTime", audioS.time);
        SceneManager.LoadScene("Credits");
    }

    public void Exit()
    {
        mainMenuGO.SetActive(false);
        ExitText.SetActive(true);
        Application.Quit();
    }

    public void ReturnAndSave()
    {
        options.SetActive(false);
    }

    public void ReturnWithoutSave()
    {
        audioS.volume = PlayerPrefs.GetFloat("musicVolumePrev");
        PlayerPrefs.SetFloat("musicVolume", audioS.volume);
        musicSlider.value = audioS.volume;
        options.SetActive(false);
    }
}
