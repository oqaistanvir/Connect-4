using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Log
{
    public int currentPlayer;
    public int row;
    public int col;
    public Log(int currentPlayer, int row, int col)
    {
        this.currentPlayer = currentPlayer;
        this.row = row;
        this.col = col;
    }
    public override readonly string ToString()
    {
        return $"Player {currentPlayer} : {row}, {col}";
    }
}
