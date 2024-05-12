using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMatrix : MonoBehaviour
{
    public static GridMatrix Instance { get; private set; }
    private static int boardRows = 6;
    private static int boardColumns = 7;
    private int[,] tokenMatrix = new int[boardRows, boardColumns];

    private void Awake()
    {
        Instance = this;

        for (int i = 0; i < tokenMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < tokenMatrix.GetLength(1); j++)
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
        int token_Key;
        if (e.isFirstPlayer) token_Key = 1;
        else token_Key = 2;
        tokenMatrix[e.row, e.column] = token_Key;
    }

    public int GetLastEmptyRow(int column)
    {
        for (int i = tokenMatrix.GetLength(0) - 1; i >= 0; i--)
        {
            if (tokenMatrix[i, column] == 0) return i;
        }
        return -1;
    }
}
