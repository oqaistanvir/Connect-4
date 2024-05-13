using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnTKeyPressed;
    public event EventHandler OnYKeyPressed;
    public event EventHandler OnNextKeyPressed;
    public event EventHandler OnPreviousKeyPressed;
    public static GameInput Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            OnTKeyPressed?.Invoke(this, EventArgs.Empty);

        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            OnYKeyPressed?.Invoke(this, EventArgs.Empty);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            OnNextKeyPressed?.Invoke(this, EventArgs.Empty);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            OnPreviousKeyPressed?.Invoke(this, EventArgs.Empty);
        }
    }
}
