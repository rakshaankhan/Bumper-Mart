using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameInfomation : MonoBehaviour
{

    public static int currentLevel = 0;
    public static int score = 0;

    public static 

    void Awake()
    {
        DontDestroyOnLoad(GameObject.FindWithTag("DontDestroy"));
    }

    public void setscore(int scoreIn)
    {
        score = scoreIn;
    }

    public int getScore()
    {
        return score;
    }

    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
