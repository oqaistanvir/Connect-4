using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public event EventHandler<int> OnPlayerChanged;
    public static TurnManager Instance { get; private set; }
    private int currentPlayer = 1;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        OnPlayerChanged?.Invoke(this, currentPlayer);
    }
    public void ToggleCurrentPlayer()
    {
        currentPlayer = currentPlayer == 2 ? 1 : 2;
        OnPlayerChanged?.Invoke(this, currentPlayer);
    }

    public int GetCurrentPlayer()
    {
        return currentPlayer;
    }


}
