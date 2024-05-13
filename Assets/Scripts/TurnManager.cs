using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public event EventHandler OnPlayerChanged;
    public static TurnManager Instance { get; private set; }
    private bool isFirstPlayer = true;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        TurnIndicatorUI.Instance.UpdateTurnIndicator(isFirstPlayer);
    }
    public void ToggleCurrentPlayer()
    {
        isFirstPlayer = !isFirstPlayer;
        OnPlayerChanged?.Invoke(this, EventArgs.Empty);
        TurnIndicatorUI.Instance.UpdateTurnIndicator(isFirstPlayer);
    }

    public bool GetCurrentPlayer()
    {
        return isFirstPlayer;
    }


}
