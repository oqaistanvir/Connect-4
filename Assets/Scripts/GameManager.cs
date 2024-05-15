using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private enum State
    {
        GamePlaying,
        GameOver,
    }

    private State state;

    private void Awake()
    {
        Instance = this;
        state = State.GamePlaying;
    }

    public bool IsGamePlaying()
    {
        return state == State.GamePlaying;
    }

    public void SetGameOver()
    {
        state = State.GameOver;
    }
}
