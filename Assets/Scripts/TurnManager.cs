using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public event EventHandler OnPlayerChanged;
    public static TurnManager Instance { get; private set; }
    private int currentPlayer = 1;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        TurnIndicatorUI.Instance.UpdateTurnIndicator(currentPlayer);
    }
    public void ToggleCurrentPlayer()
    {
        currentPlayer = currentPlayer == 2 ? 1 : 2;
        OnPlayerChanged?.Invoke(this, EventArgs.Empty);
        TurnIndicatorUI.Instance.UpdateTurnIndicator(currentPlayer);
    }

    public int GetCurrentPlayer()
    {
        return currentPlayer;
    }


}
