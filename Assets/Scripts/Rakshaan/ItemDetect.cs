using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetect : MonoBehaviour

{
    private Final shoppingGame;

    void Start()
    {
        shoppingGame = FindObjectOfType<Final>();
    }

    void OnMouseDown()
    {
        shoppingGame.CollectItem(gameObject);
    }
}

