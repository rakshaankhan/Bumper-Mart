using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class TimerScript : MonoBehaviour
{
    public float m_desiredTimer = 0;
    private float m_deltaTime = 0;  

    private GameObject m_TimerUI;  

    // Start is called before the first frame update
    void Start() 
    { 
        m_TimerUI = GameObject.FindWithTag("TimerUI");
    }

    // Update is called once per frame
    void Update()
    {
        m_deltaTime += Time.deltaTime;
        int m_timeChanged = (int) (m_desiredTimer - m_deltaTime);
        if(m_timeChanged <= 0)
        {
            m_timeChanged = 0;
            SceneManager.LoadScene("FailedEndScreenScene");
        }
        m_TimerUI.GetComponent<TextMeshProUGUI>().text = "Time before parents get home: " + m_timeChanged;

    }
}
