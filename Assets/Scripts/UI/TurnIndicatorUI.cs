using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnIndicatorUI : MonoBehaviour
{
    public static TurnIndicatorUI Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI turnIndicatorFlash;
    [SerializeField] private TextMeshProUGUI turnIndicator;
    private const string FADE_IN_FADE_OUT = "FadeInFadeOut";
    private Animator animator;
    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
    }
    public void UpdateTurnIndicator(int currentPlayer)
    {
        turnIndicatorFlash.text = "PLAYER " + (currentPlayer) + " TURN";
        turnIndicator.text = "PLAYER " + (currentPlayer);
        animator.SetTrigger(FADE_IN_FADE_OUT);
    }
}
