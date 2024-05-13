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
    public void UpdateTurnIndicator(bool isFirstPlayer)
    {
        turnIndicatorFlash.text = "PLAYER " + (isFirstPlayer ? "1" : "2") + " TURN";
        turnIndicator.text = "PLAYER " + (isFirstPlayer ? "1" : "2");
        animator.SetTrigger(FADE_IN_FADE_OUT);
    }
}
