using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public GameObject options;
    public Slider musicSlider;
    public AudioSource audioS;

    public GameObject menuButtons = null;
    
    void awake()
    {
        if(PlayerPrefs.HasKey("musicVolume"))
        {
            audioS.volume = PlayerPrefs.GetFloat("musicVolume");
            musicSlider.value = audioS.volume;
        }
        else 
        {
            PlayerPrefs.SetFloat("musicVolume", 0.5F);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // musicSlider = GameObject.Find("MusicSlider").GetComponent<Slider>();
        // audioS = GameObject.Find("MainMenuCanvas").GetComponent<AudioSource>();
        Debug.Log("here");
        Load();
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void ChangeMusicVolume()
    {
        audioS.volume = musicSlider.value;
        Save();
    }

    private void Load()
    {
        Debug.Log("here2");
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        PlayerPrefs.SetFloat("musicVolumePrev", audioS.volume);
        Debug.Log(audioS.volume);

    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
    }
    public void ReturnAndSave()
    {
        options.SetActive(false);
        if (menuButtons != null)
        {
            menuButtons.SetActive(true);
        }
    }

    public void ReturnWithoutSave()
    {
        audioS.volume = PlayerPrefs.GetFloat("musicVolumePrev");
        PlayerPrefs.SetFloat("musicVolume", audioS.volume);
        musicSlider.value = audioS.volume;
        options.SetActive(false);
        if (menuButtons != null)
        {
            menuButtons.SetActive(true);
        }
    }
}
