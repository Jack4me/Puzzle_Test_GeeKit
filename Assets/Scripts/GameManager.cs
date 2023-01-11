using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameField;
    public bool activateGameField;


    private void Start()
    {
        activateGameField = true;
    }

    private void Update()
    {
        if (activateGameField == true)
        {
            gameField.SetActive(true);
        }
        else
        {
            gameField.SetActive(false);
            
        }
        
    }
}
