using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
    private AudioSource AudSource;
    private float speed = 100.0f;

    void Start()
    {
        AudSource = GameObject.Find("Canvas").GetComponent<AudioSource>();
        Debug.Log(PlayerPrefs.HasKey("musicTime"));
        AudSource.time = PlayerPrefs.GetFloat("MusicTime");
        Debug.Log(PlayerPrefs.HasKey("musicVolume"));
        AudSource.volume = PlayerPrefs.GetFloat("musicVolume");
    }

    void Update()
    {
        if(transform.position.y < 1000)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }

    public void ReturnToMainMenu()
    {
        PlayerPrefs.SetFloat("MusicTime", AudSource.time);
        SceneManager.LoadScene("MainMenu");
    }
}
