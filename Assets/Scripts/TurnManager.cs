using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public event EventHandler<int> OnPlayerChanged;
    public event EventHandler<int> OnNextTurn;
    public event EventHandler<int> OnPreviousTurn;
    public static TurnManager Instance { get; private set; }
    private int currentPlayer = 2;
    private int turnNumber = 0;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        TokenSpawner.OnAfterTokenPlaced += TokenSpawner_OnAfterTokenPlaced;
        GameInput.Instance.OnUndoKeyPressed += GameInput_OnUndoKeyPressed;
        NextTurn();
    }

    public void ToggleCurrentPlayer()
    {
        currentPlayer = currentPlayer == 2 ? 1 : 2;
    }
    private void NextTurn()
    {
        turnNumber++;
        ToggleCurrentPlayer();
        OnNextTurn?.Invoke(this, currentPlayer);
        OnPlayerChanged?.Invoke(this, currentPlayer);
    }
    private void PreviousTurn()
    {
        if (turnNumber > 1)
        {
            turnNumber--;
            ToggleCurrentPlayer();
            OnPreviousTurn?.Invoke(this, currentPlayer);
            OnPlayerChanged?.Invoke(this, currentPlayer);
        }
    }
    public int GetCurrentPlayer()
    {
        return currentPlayer;
    }
    private void TokenSpawner_OnAfterTokenPlaced(object sender, EventArgs e)
    {
        NextTurn();
    }

    private void GameInput_OnUndoKeyPressed(object sender, EventArgs e)
    {
        PreviousTurn();
    }

}
