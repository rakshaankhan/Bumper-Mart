using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryInstructionsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.0f;
        GameObject.FindWithTag("ShoppingListCanvas").GetComponent<Canvas>().enabled = false;
    }

    public void Play()
    {
        Time.timeScale = 1.0f;
        GameObject.FindWithTag("ShoppingListCanvas").GetComponent<Canvas>().enabled = true;
        Destroy(GameObject.FindWithTag("StoryInstructions"));
    }
}
