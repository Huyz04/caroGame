using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{

    public GameObject cellPrefab;
    public Transform board;
    public GridLayoutGroup gridLayout;
    public int boardSize;
    public string currentTurn = "x";
    private string[,] matrix;



    void Start()
    {
        matrix = new string[boardSize + 1, boardSize + 1];
        gridLayout.constraintCount = boardSize;
        CreateBoard();
    }

    private void CreateBoard()
    {
        for (int i = 0; i < boardSize; i++)
        {
            for (int j = 0; j < boardSize; j++)
            {
                Cell cell = Instantiate(cellPrefab, board).GetComponent<Cell>();
                cell.row = i;
                cell.col = j;
                matrix[i, j] = "";
            }
        }
    }

    public bool CheckWin (int row, int col)
    {
        matrix[row, col] = currentTurn;

        int count = 0;
        for (int i = row - 1; i >= 1; i--)
        {
            if (matrix[i, col] == currentTurn) { count++; }
            else break;
        }

        for (int i = row + 1; i <= boardSize; i++)
        {
            if (matrix[i, col] == currentTurn) { count++; }
            else break;
        }

        if (count + 1 >= 5) return true;

        count = 0;
        for (int i = col - 1; i >= 1; i--)
        {
            if (matrix[row, i] == currentTurn) { count++; }
            else break;
        }

        for (int i = col + 1; i <= boardSize; i++)
        {
            if (matrix[row, i] == currentTurn) { count++; }
            else break;
        }

        if (count + 1 >= 5) return true;

        count = 0;
        for (int i = 1; row - i >= 1 && col - i >= 1; i++)
        {
            if (matrix[row - i, col - i] == currentTurn) count++;
            else break;
        }

        for (int i = 1; row + i <= boardSize && col + i >= boardSize; i++)
        {
            if (matrix[row - i, col - i] == currentTurn) count++;
            else break;
        }
        if (count + 1 >= 5) return true;


        return false;
    }
}
