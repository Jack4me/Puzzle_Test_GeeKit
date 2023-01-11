using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class VitaliyScript : MonoBehaviour
{
   [SerializeField] private GameObject puzzlePrefab;
   [SerializeField] private int countX;
   [SerializeField] private int countY;
   [SerializeField] private float puzzleSizeInitial = 100f;
   [SerializeField] private RectTransform field;
   private List<GameObject> puzzles = new List<GameObject>();

   public void Start()
   {
      InstantiatePuzzles();
      GenerateField();
   }

   private void InstantiatePuzzles()
   {
      for (int i = 0; i < countY * countX; i++)
      {
         GameObject puzzleInstance = Instantiate(puzzlePrefab, field);
         puzzles.Add(puzzleInstance);
      }
   }

   public void GenerateField()
   {
      float fieldWidth = field.rect.width;
      float fieldHeight = field.rect.height;

      float horizontalInitial = puzzleSizeInitial * countX;
      float verticalInitial = puzzleSizeInitial * countY;

      float dX = horizontalInitial / fieldWidth;
      float dY = verticalInitial / fieldHeight;
      
      Debug.Log($"{fieldWidth}:{fieldHeight}   x   {horizontalInitial}:{verticalInitial}   =   {dX}:{dY}");

      float d = Math.Max(dX, dY);
      
      float puzzleSize = puzzleSizeInitial * (1/d);
      
      
      Vector3 fieldCenter = new Vector3(fieldWidth / 2f, fieldHeight / 2f, 0f);
      Vector3 puzzlesCenter = new Vector3((puzzleSize * countX) / 2f, (puzzleSize * countY) / 2f, 0f);
      Vector3 singlePuzzleShift = new Vector3(puzzleSize / 2f, puzzleSize / 2f, 0f);
      Vector3 shift = fieldCenter - puzzlesCenter + singlePuzzleShift;

      for (int i = 0; i < countY * countX; i++)
      {
         int y = i / countX;
         int x = i - y * countX;
         Vector3 puzzlePosition = new Vector3(puzzleSize * x, puzzleSize * y, 0f);
         
         GameObject puzzleInstance = puzzles[i];
         puzzleInstance.transform.localPosition = puzzlePosition + shift;
         puzzleInstance.transform.localScale *= puzzleSize / puzzleSizeInitial;
      }
   }
}