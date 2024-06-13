using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject options;
    public GameObject mainMenuGO;
    public GameObject ExitText;

    public AudioSource musicSlider;

    void Awake()
    {
        if(PlayerPrefs.HasKey("musicVolume"))
        {
            musicSlider.volume = PlayerPrefs.GetFloat("musicVolume");
        }
        if(PlayerPrefs.HasKey("musicTime"))
        {
            musicSlider.time = PlayerPrefs.GetFloat("musicTime");
        }
    }

    public void Startgame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Options()
    {
        options.SetActive(true);
        PlayerPrefs.SetFloat("musicVolumePrev", musicSlider.volume);
    }

    public void Credits()
    {
        PlayerPrefs.SetFloat("musicTime", musicSlider.time);
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
        musicSlider.volume = PlayerPrefs.GetFloat("musicVolumePrev");
        PlayerPrefs.SetFloat("musicVolume", musicSlider.volume);
        GameObject.Find("MusicSlider").GetComponent<Slider>().value = musicSlider.volume;
        options.SetActive(false);
    }
}
