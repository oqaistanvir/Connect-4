using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenSpawner : MonoBehaviour
{
    public static TokenSpawner Instance { get; private set; }

    public event EventHandler<OnTokenSpawnedEventArgs> OnTokenSpawned;
    public class OnTokenSpawnedEventArgs
    {
        public Transform tokenTransform;
        public int row;
        public int column;
        public bool isFirstPlayer;
    }

    public event EventHandler<OnColumnChangedEventArgs> OnColumnChanged;
    public class OnColumnChangedEventArgs
    {
        public int column;
    }

    [SerializeField] private Transform tokenPrefab;
    [SerializeField] private int column;

    private float startXPosition = -4.5f;
    private float startYPosition = 3.75f;
    private float xDistance = 1.5f;
    private float yDistance = 1.5f;
    private int row;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameInput.Instance.OnPlaceTokenKeyPressed += GameInput_OnPlaceTokenKeyPressed;
        GameInput.Instance.OnNextKeyPressed += GameInput_OnNextKeyPressed;
        GameInput.Instance.OnPreviousKeyPressed += GameInput_OnPreviousKeyPressed;
    }

    private void GameInput_OnPreviousKeyPressed(object sender, EventArgs e)
    {
        column = column > 0 ? (column - 1) % GridMatrix.Instance.GetNumColumns() : GridMatrix.Instance.GetNumColumns() - 1;
        OnColumnChanged?.Invoke(this, new OnColumnChangedEventArgs
        {
            column = column
        });
    }

    private void GameInput_OnNextKeyPressed(object sender, EventArgs e)
    {
        column = (column + 1) % GridMatrix.Instance.GetNumColumns();
        OnColumnChanged?.Invoke(this, new OnColumnChangedEventArgs
        {
            column = column
        });
    }

    private bool CalculateCoordinates(out float xPosition, out float yPosition)
    {
        row = GridMatrix.Instance.GetLowestEmptyRow(column);
        xPosition = startXPosition + xDistance * column;
        yPosition = startYPosition - yDistance * row;
        if (row == -1) return false;
        else return true;
    }

    private void SpawnToken(bool isFirstPlayer)
    {
        float xPosition, yPosition;
        if (CalculateCoordinates(out xPosition, out yPosition))
        {
            Transform tokenTransform = Token.CreateTokenObject(tokenPrefab, new Vector3(xPosition, yPosition), isFirstPlayer);
            OnTokenSpawned?.Invoke(this, new OnTokenSpawnedEventArgs
            {
                tokenTransform = tokenTransform,
                row = row,
                column = column,
                isFirstPlayer = isFirstPlayer
            });
            TurnManager.Instance.ToggleCurrentPlayer();
        }
    }
    private void GameInput_OnPlaceTokenKeyPressed(object sender, EventArgs e)
    {
        if (GameManager.Instance.IsGamePlaying())
        {
            SpawnToken(TurnManager.Instance.GetCurrentPlayer());
        }
    }
}