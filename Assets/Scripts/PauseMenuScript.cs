using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{

    public GameObject m_pausemenuUI;

    public GameObject options;

    public GameObject menuButtons;

    public Slider musicSlider;
    public AudioSource audioS;

    private bool m_isPaused = false;

    // // Start is called before the first frame update
    // void Start() { }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(m_isPaused)
            {
                Resume();
            }
            else 
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Pause();
            }
        }
    }

    public void Resume()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        m_pausemenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        m_isPaused = false;
    }

    void Pause()
    {
        m_pausemenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        m_isPaused = true;
    }

    public void ReturnMainMenu()
    {
        Time.timeScale = 1.0f;
        Debug.Log("Going to Main Menu");
        SceneManager.LoadScene("MainMenu");
    }

    public void Options()
    {
        Debug.Log("Opened Options page");
        PlayerPrefs.SetFloat("musicVolumePrev", audioS.volume);
        menuButtons.SetActive(false);
        options.SetActive(true);
    }

    public void ReturnAndSave()
    {
        options.SetActive(false);
        menuButtons.SetActive(true);
    }

    public void ReturnWithoutSave()
    {
        audioS.volume = PlayerPrefs.GetFloat("musicVolumePrev");
        PlayerPrefs.SetFloat("musicVolume", audioS.volume);
        musicSlider.value = audioS.volume;
        options.SetActive(false);
        menuButtons.SetActive(true);
    }
}
