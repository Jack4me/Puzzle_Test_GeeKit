using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleCreator : MonoBehaviour
{
    public GameObject puzzle;
    private Vector2 puzzlePosition;
    public Transform transformParent;

    private void Awake()
    {
        puzzlePosition = new Vector2(0, 0f);
        for (int i = 0; i < 5; i++)
        {
            CreatePuzzle();
        }
    }


    public void CreatePuzzle()
    {
        var newPuzzle = Instantiate(puzzle, puzzlePosition, Quaternion.identity);
        newPuzzle.transform.SetParent(transformParent);
        newPuzzle.GetComponent<Transform>().localScale = Vector3.one;
    }
}