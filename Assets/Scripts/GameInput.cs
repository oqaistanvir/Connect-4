using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnPlaceTokenKeyPressed;
    public event EventHandler OnNextKeyPressed;
    public event EventHandler OnPreviousKeyPressed;
    public event EventHandler OnPauseKeyPressed;
    public static GameInput Instance { get; private set; }

    private PlayerInputActions playerInputActions;
    private void Awake()
    {
        Instance = this;
        playerInputActions = new PlayerInputActions();

        playerInputActions.Player.Enable();
        playerInputActions.Player.TokenPlacement.performed += TokenPlacement_performed;
        playerInputActions.Player.NextColumn.performed += NextColumn_performed;
        playerInputActions.Player.PrevColumn.performed += PrevColumn_performed;
        playerInputActions.Player.Pause.performed += Pause_performed;
    }

    private void OnDestroy()
    {
        playerInputActions.Player.TokenPlacement.performed -= TokenPlacement_performed;
        playerInputActions.Player.NextColumn.performed -= NextColumn_performed;
        playerInputActions.Player.PrevColumn.performed -= PrevColumn_performed;
        playerInputActions.Player.Pause.performed -= Pause_performed;
        playerInputActions.Dispose();
    }
    private void TokenPlacement_performed(InputAction.CallbackContext context)
    {
        OnPlaceTokenKeyPressed?.Invoke(this, EventArgs.Empty);
    }

    private void PrevColumn_performed(InputAction.CallbackContext context)
    {
        OnPreviousKeyPressed?.Invoke(this, EventArgs.Empty);
    }

    private void NextColumn_performed(InputAction.CallbackContext context)
    {
        OnNextKeyPressed?.Invoke(this, EventArgs.Empty);
    }

    private void Pause_performed(InputAction.CallbackContext context)
    {
        OnPauseKeyPressed?.Invoke(this, EventArgs.Empty);
    }
}
