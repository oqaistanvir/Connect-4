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
    private Token[,] tokenObjectMatrix = new Token[boardRows, boardColumns];

    private void Awake()
    {
        Instance = this;

        for (int i = 0; i < boardRows; i++)
        {
            for (int j = 0; j < boardColumns; j++)
            {
                tokenObjectMatrix[i, j] = null;
            }
        }
    }

    private void Start()
    {
        TokenSpawner.Instance.OnTokenSpawned += TokenSpawner_OnTokenSpawned;
    }

    private void TokenSpawner_OnTokenSpawned(object sender, TokenSpawner.OnTokenSpawnedEventArgs e)
    {
        emptyCells--;
        tokenObjectMatrix[e.token.GetTokenRow(), e.token.GetTokenColumn()] = e.token;
        if (CheckWinCondition(e.token.GetTokenRow(), e.token.GetTokenColumn(), e.token.GetTokenKey()))
        {
            GameManager.Instance.SetGameOver();
            GameOverUI.Instance.SetResultText(e.token.GetTokenKey());
        }
        else if (emptyCells == 0)
        {
            GameManager.Instance.SetGameOver();
            GameOverUI.Instance.SetResultText(0);
        }
    }

    public int GetLowestEmptyRow(int column)
    {
        for (int i = 0; i < boardRows; i++)
        {
            if (tokenObjectMatrix[i, column] == null) return i;
        }
        return -1;
    }

    private bool CheckWinCondition(int row, int column, int tokenKey)
    {
        //Check Horizontal
        if (CountTokens(row, column, 0, -1, tokenKey) + 1 + CountTokens(row, column, 0, 1, tokenKey) >= 4)
        {
            tokenObjectMatrix[row, column].ShowVictoryParticles();
            ActivateParticles(row, column, 0, -1, tokenKey);
            ActivateParticles(row, column, 0, 1, tokenKey);
            return true;
        }
        //Check Vertical
        if (CountTokens(row, column, -1, 0, tokenKey) + 1 + CountTokens(row, column, 1, 0, tokenKey) >= 4)
        {
            tokenObjectMatrix[row, column].ShowVictoryParticles();
            ActivateParticles(row, column, -1, 0, tokenKey);
            ActivateParticles(row, column, 1, 0, tokenKey);
            return true;
        }
        //Check Diagonal Top Left to Bottom Right
        if (CountTokens(row, column, -1, 1, tokenKey) + 1 + CountTokens(row, column, 1, -1, tokenKey) >= 4)
        {
            tokenObjectMatrix[row, column].ShowVictoryParticles();
            ActivateParticles(row, column, -1, 1, tokenKey);
            ActivateParticles(row, column, 1, -1, tokenKey);
            return true;
        }
        //Check Diagonal Bottom Left to Top Right
        if (CountTokens(row, column, -1, -1, tokenKey) + 1 + CountTokens(row, column, 1, 1, tokenKey) >= 4)
        {
            tokenObjectMatrix[row, column].ShowVictoryParticles();
            ActivateParticles(row, column, -1, -1, tokenKey);
            ActivateParticles(row, column, 1, 1, tokenKey);
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
            if (CheckOutOfBounds(row, column) || tokenObjectMatrix[row, column] == null || tokenObjectMatrix[row, column].GetTokenKey() != tokenKey) return count;
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

    private void ActivateParticles(int row, int column, int dirRow, int dirCol, int tokenKey)
    {
        for (int i = 0; i < 4; i++)
        {
            row = row + dirRow;
            column = column + dirCol;
            if (CheckOutOfBounds(row, column) || tokenObjectMatrix[row, column] == null || tokenObjectMatrix[row, column].GetTokenKey() != tokenKey) return;
            tokenObjectMatrix[row, column].ShowVictoryParticles();
        }
    }
}
