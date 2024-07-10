using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenSpawner : MonoBehaviour
{
    public static TokenSpawner Instance { get; private set; }
    public static event EventHandler OnAfterTokenPlaced;
    public event EventHandler<OnTokenSpawnedEventArgs> OnTokenSpawned;
    public class OnTokenSpawnedEventArgs
    {
        public Token token;
    }

    public event EventHandler<OnColumnChangedEventArgs> OnColumnChanged;
    public class OnColumnChangedEventArgs
    {
        public int col;
    }

    [SerializeField] private Transform tokenPrefab;
    [SerializeField] private int col;

    private readonly float startXPosition = -4.5f;
    private readonly float startYPosition = -3.75f;
    private readonly float xDistance = 1.5f;
    private readonly float yDistance = 1.5f;
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
        if (GameManager.Instance.IsGamePlaying())
        {
            col = col > 0 ? (col - 1) % GridMatrix.Instance.GetNumColumns() : GridMatrix.Instance.GetNumColumns() - 1;
            OnColumnChanged?.Invoke(this, new OnColumnChangedEventArgs
            {
                col = col
            });
        }
    }

    private void GameInput_OnNextKeyPressed(object sender, EventArgs e)
    {
        if (GameManager.Instance.IsGamePlaying())
        {
            col = (col + 1) % GridMatrix.Instance.GetNumColumns();
            OnColumnChanged?.Invoke(this, new OnColumnChangedEventArgs
            {
                col = col
            });
        }
    }

    private bool CalculateCoordinates(out float xPosition, out float yPosition)
    {
        row = GridMatrix.Instance.GetLowestEmptyRow(col);
        xPosition = startXPosition + xDistance * col;
        yPosition = startYPosition + yDistance * row;
        if (row == -1) return false;
        else return true;
    }

    private void SpawnToken(int tokenKey)
    {
        if (CalculateCoordinates(out float xPosition, out float yPosition))
        {
            Token token = Token.CreateTokenObject(tokenPrefab, new Vector3(xPosition, yPosition));
            token.SetTokenCharacteristics(tokenKey, row, col);
            OnTokenSpawned?.Invoke(this, new OnTokenSpawnedEventArgs
            {
                token = token
            });
            OnAfterTokenPlaced?.Invoke(this, EventArgs.Empty);
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