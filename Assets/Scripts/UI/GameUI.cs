using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public static GameUI Instance { get; private set; }
    [SerializeField] private Button hideBoardButton;
    [SerializeField] private GameObject[] HudElements;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        hideBoardButton.onClick.AddListener(() =>
        {
            GameOverUI.Instance.Show();
        });

        hideBoardButton.gameObject.SetActive(false);
        GameManager.Instance.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    private void GameManager_OnGameStateChanged(object sender, EventArgs e)
    {
        if (GameManager.Instance.IsGamePlaying())
        {
            // ShowGameHud();
            // hideBoardButton.gameObject.SetActive(false);
        }
        else if (GameManager.Instance.IsGameOver())
        {
            hideBoardButton.gameObject.SetActive(true);
        }
    }

    public void HideGameHud()
    {
        foreach (GameObject HudElement in HudElements)
        {
            HudElement.SetActive(false);
        }
    }

    // private void ShowGameHud()
    // {
    //     foreach (GameObject HudElement in HudElements)
    //     {
    //         HudElement.SetActive(true);
    //     }
    // }
}
