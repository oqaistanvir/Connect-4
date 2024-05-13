using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private enum State
    {
        WaitingToStart,
        GamePlaying,
        PlayerChanging,
        GamePaused,
        GameOver,
    }

    private State state;

    private void Awake()
    {
        Instance = this;
        state = State.WaitingToStart;
    }

    private void Start()
    {
        GameInput.Instance.OnPlaceTokenKeyPressed += GameInput_OnPlaceTokenKeyPressed;
    }

    private void GameInput_OnPlaceTokenKeyPressed(object sender, EventArgs e)
    {
        if (state == State.WaitingToStart)
        {
            state = State.GamePlaying;
        }
    }
}
