using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    
    private Slider musicSlider;
    private AudioSource audioS;
    
    void awake()
    {
        PlayerPrefs.SetFloat("musicVolume", 0.5F);
    }

    // Start is called before the first frame update
    void Start()
    {
        musicSlider = GameObject.Find("MusicSlider").GetComponent<Slider>();
        audioS = GameObject.Find("MainMenuCanvas").GetComponent<AudioSource>();
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
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
    }
}
