using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // public event EventHandler OnGameStateChanged;
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
        GridMatrix.Instance.OnGameEnd += GridMatrix_OnGameEnd;
        PauseUI.Instance.OnGamePaused += PauseUI_OnGamePaused;
        PauseUI.Instance.OnGameResumed += PauseUI_OnGameResumed;
        state = State.GamePlaying;
    }
    private void SetGamePlaying()
    {
        state = State.GamePlaying;
    }
    public bool IsGamePlaying()
    {
        return state == State.GamePlaying;
    }
    private void SetGamePaused()
    {
        state = State.GamePaused;
    }
    public bool IsGamePaused()
    {
        return state == State.GamePaused;
    }
    private void SetGameOver()
    {
        state = State.GameOver;
    }
    public bool IsGameOver()
    {
        return state == State.GameOver;
    }
    private void GridMatrix_OnGameEnd(object sender, int e)
    {
        SetGameOver();
    }
    private void PauseUI_OnGameResumed(object sender, EventArgs e)
    {
        SetGamePlaying();
    }
    private void PauseUI_OnGamePaused(object sender, EventArgs e)
    {
        SetGamePaused();
    }
}
