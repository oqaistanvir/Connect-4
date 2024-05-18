using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event EventHandler OnGameStateChanged;
    public static GameManager Instance { get; private set; }
    public enum State
    {
        GamePlaying,
        GamePaused,
        GameOver,
    }

    private State state;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        state = State.GamePlaying;
        OnGameStateChanged?.Invoke(this, EventArgs.Empty);
    }

    public void SetGamePlaying()
    {
        state = State.GamePlaying;
    }

    public bool IsGamePlaying()
    {
        return state == State.GamePlaying;
    }

    public void SetGamePaused()
    {
        state = State.GamePaused;
    }

    public bool IsGamePaused()
    {
        return state == State.GamePaused;
    }

    public void SetGameOver()
    {
        state = State.GameOver;
        OnGameStateChanged?.Invoke(this, EventArgs.Empty);
    }

    public bool IsGameOver()
    {
        return state == State.GameOver;
    }
}
