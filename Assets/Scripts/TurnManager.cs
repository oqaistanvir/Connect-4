using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance { get; private set; }
    bool isFirstPlayer = true;
    private void Awake()
    {
        Instance = this;
    }

    public void ToggleCurrentPlayer()
    {
        isFirstPlayer = !isFirstPlayer;
    }

    public bool GetCurrentPlayer()
    {
        return isFirstPlayer;
    }
}
