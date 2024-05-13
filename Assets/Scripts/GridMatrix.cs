using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GridMatrix : MonoBehaviour
{
    public static GridMatrix Instance { get; private set; }
    private static int boardRows = 6;
    private static int boardColumns = 7;
    private int emptyCells = boardRows * boardColumns;
    private int[,] tokenMatrix = new int[boardRows, boardColumns];

    private void Awake()
    {
        Instance = this;

        for (int i = 0; i < boardRows; i++)
        {
            for (int j = 0; j < boardColumns; j++)
            {
                tokenMatrix[i, j] = 0;
            }
        }
    }

    private void Start()
    {
        TokenSpawner.Instance.OnTokenSpawned += TokenSpawner_OnTokenSpawned;
    }

    private void TokenSpawner_OnTokenSpawned(object sender, TokenSpawner.OnTokenSpawnedEventArgs e)
    {
        int tokenKey;
        if (e.isFirstPlayer) tokenKey = 1;
        else tokenKey = 2;
        emptyCells--;
        tokenMatrix[e.row, e.column] = tokenKey;
        if (CheckWinCondition(e.row, e.column, e.isFirstPlayer))
        {
            Debug.Log(e.isFirstPlayer ? "Player 1" + " is the winner" : "Player 2" + " is the winner");
        }
        else if (emptyCells == 0)
        {
            Debug.Log("The game ended in a draw");
        }
    }

    public int GetLowestEmptyRow(int column)
    {
        for (int i = boardRows - 1; i >= 0; i--)
        {
            if (tokenMatrix[i, column] == 0) return i;
        }
        return -1;
    }

    private bool CheckWinCondition(int row, int column, bool isFirstPlayer)
    {
        int tokenKey;
        if (isFirstPlayer) tokenKey = 1;
        else tokenKey = 2;
        //Check Horizontal
        if (CountTokens(row, column, 0, -1, tokenKey) + 1 + CountTokens(row, column, 0, 1, tokenKey) >= 4)
        {
            return true;
        }
        //Check Vertical
        if (CountTokens(row, column, -1, 0, tokenKey) + 1 + CountTokens(row, column, 1, 0, tokenKey) >= 4)
        {
            return true;
        }
        //Check Diagonal Top Left to Bottom Right
        if (CountTokens(row, column, -1, 1, tokenKey) + 1 + CountTokens(row, column, 1, -1, tokenKey) >= 4)
        {
            return true;
        }
        //Check Diagonal Bottom Left to Top Right
        if (CountTokens(row, column, -1, -1, tokenKey) + 1 + CountTokens(row, column, 1, 1, tokenKey) >= 4)
        {
            return true;
        }
        return false;
    }

    private int CountTokens(int row, int column, int dirRow, int dirCol, int tokenKey)
    {
        int count = 0;
        for (int i = 0; i < 4; i++)
        {
            row = row + dirRow;
            column = column + dirCol;
            if (CheckOutOfBounds(row, column) || tokenMatrix[row, column] != tokenKey) return count;
            count++;
        }
        return count;
    }

    private bool CheckOutOfBounds(int row, int column)
    {
        if (row < 0 || row >= boardRows || column < 0 || column >= boardColumns) return true;
        else return false;
    }

    public int GetNumColumns()
    {
        return boardColumns;
    }
}
