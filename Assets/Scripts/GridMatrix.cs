using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GridMatrix : MonoBehaviour
{
    public static GridMatrix Instance { get; private set; }
    public event EventHandler<int> OnGameEnd;
    private static readonly int boardRows = 6;
    private static readonly int boardCols = 7;
    private int emptyCells = boardRows * boardCols;
    private Token[,] tokenObjectMatrix = new Token[boardRows, boardCols];

    private void Awake()
    {
        Instance = this;

        for (int i = 0; i < boardRows; i++)
        {
            for (int j = 0; j < boardCols; j++)
            {
                tokenObjectMatrix[i, j] = null;
            }
        }
    }

    private void Start()
    {
        TokenSpawner.Instance.OnTokenSpawned += TokenSpawner_OnTokenSpawned;
        GameInput.Instance.OnUndoKeyPressed += GameInput_OnUndoKeyPressed;
    }

    private void TokenSpawner_OnTokenSpawned(object sender, TokenSpawner.OnTokenSpawnedEventArgs tokenData)
    {
        emptyCells--;
        tokenObjectMatrix[tokenData.token.GetTokenRow(), tokenData.token.GetTokenColumn()] = tokenData.token;
        if (CheckWinCondition(tokenData.token.GetTokenRow(), tokenData.token.GetTokenColumn(), tokenData.token.GetTokenKey()))
        {
            OnGameEnd?.Invoke(this, tokenData.token.GetTokenKey());
        }
        else if (emptyCells == 0)
        {
            OnGameEnd?.Invoke(this, 0);
        }
    }

    private void GameInput_OnUndoKeyPressed(object sender, EventArgs e)
    {
        emptyCells++;
        if (LogsManager.Instance.HasLogInLogList())
        {
            Log log = LogsManager.Instance.RemoveFromLogList();
            Destroy(tokenObjectMatrix[log.row, log.col].gameObject);
        }
    }

    public int GetLowestEmptyRow(int col)
    {
        for (int i = 0; i < boardRows; i++)
        {
            if (tokenObjectMatrix[i, col] == null) return i;
        }
        return -1;
    }

    private bool CheckWinCondition(int row, int col, int tokenKey)
    {
        //Check Horizontal
        if (CountTokens(row, col, 0, -1, tokenKey) + 1 + CountTokens(row, col, 0, 1, tokenKey) >= 4)
        {
            tokenObjectMatrix[row, col].ShowVictoryParticles();
            ActivateParticles(row, col, 0, -1, tokenKey);
            ActivateParticles(row, col, 0, 1, tokenKey);
            return true;
        }
        //Check Vertical
        if (CountTokens(row, col, -1, 0, tokenKey) + 1 + CountTokens(row, col, 1, 0, tokenKey) >= 4)
        {
            tokenObjectMatrix[row, col].ShowVictoryParticles();
            ActivateParticles(row, col, -1, 0, tokenKey);
            ActivateParticles(row, col, 1, 0, tokenKey);
            return true;
        }
        //Check Diagonal Top Left to Bottom Right
        if (CountTokens(row, col, -1, 1, tokenKey) + 1 + CountTokens(row, col, 1, -1, tokenKey) >= 4)
        {
            tokenObjectMatrix[row, col].ShowVictoryParticles();
            ActivateParticles(row, col, -1, 1, tokenKey);
            ActivateParticles(row, col, 1, -1, tokenKey);
            return true;
        }
        //Check Diagonal Bottom Left to Top Right
        if (CountTokens(row, col, -1, -1, tokenKey) + 1 + CountTokens(row, col, 1, 1, tokenKey) >= 4)
        {
            tokenObjectMatrix[row, col].ShowVictoryParticles();
            ActivateParticles(row, col, -1, -1, tokenKey);
            ActivateParticles(row, col, 1, 1, tokenKey);
            return true;
        }
        return false;
    }

    private int CountTokens(int row, int col, int dirRow, int dirCol, int tokenKey)
    {
        int count = 0;
        for (int i = 0; i < 4; i++)
        {
            row += dirRow;
            col += dirCol;
            if (CheckOutOfBounds(row, col) || tokenObjectMatrix[row, col] == null || tokenObjectMatrix[row, col].GetTokenKey() != tokenKey) return count;
            count++;
        }
        return count;
    }

    private bool CheckOutOfBounds(int row, int col)
    {
        if (row < 0 || row >= boardRows || col < 0 || col >= boardCols) return true;
        else return false;
    }

    public int GetNumColumns()
    {
        return boardCols;
    }

    private void ActivateParticles(int row, int col, int dirRow, int dirCol, int tokenKey)
    {
        for (int i = 0; i < 4; i++)
        {
            row += dirRow;
            col += dirCol;
            if (CheckOutOfBounds(row, col) || tokenObjectMatrix[row, col] == null || tokenObjectMatrix[row, col].GetTokenKey() != tokenKey) return;
            tokenObjectMatrix[row, col].ShowVictoryParticles();
        }
    }
}
