using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameField : MonoBehaviour
{
    [SerializeField] private GameObject puzzlePrefab;
    [SerializeField] private RectTransform gameFieldRect;
    [SerializeField] private int countX;
    [SerializeField] private int countY;
    [SerializeField] private int sizePuzzle = 100;

    private List<GameObject> puzzlesList = new List<GameObject>();
    //private Vector3 shift;


    void Start()
    {
        PuzzleInstantiate();
        GenerateField();
    }

    public void PuzzleInstantiate()
    {
        for (int i = 0; i < countX * countY; i++)
        {
            GameObject newPuzzle = Instantiate(puzzlePrefab, gameFieldRect);

            puzzlesList.Add(newPuzzle);
        }
    }

    public void GenerateField()
    {
        for (int i = 0; i < countX * countY; i++)
        {
            int Y = i / countX;
            int X = i - Y * countX;
            Vector3 puzzlePosition = new Vector3(X * sizePuzzle, Y * sizePuzzle, 0);


            GameObject puzzleInstance = puzzlesList[i];
            RectTransform m_RectTransform = puzzleInstance.GetComponent<RectTransform>();
            m_RectTransform.anchorMin = new Vector2(0, 0);
            m_RectTransform.anchorMax = new Vector2(0, 0);


            puzzleInstance.transform.localPosition = puzzlePosition;
        }
    }
}