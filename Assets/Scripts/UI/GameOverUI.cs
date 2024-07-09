using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI Instance { get; private set; }

    private const string GAME_SCENE = "GameScene";
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private Button showBoardButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GridMatrix.Instance.OnGameEnd += GridMatrix_OnGameEnd;

        showBoardButton.onClick.AddListener(() =>
        {
            GameUI.Instance.HideGameHud();
            Hide();
        });

        restartButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(GAME_SCENE);
        });

        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void SetResultText(int resultKey)
    {
        if (resultKey == 0) resultText.text = "DRAW";
        else if (resultKey == 1) resultText.text = "PLAYER 1 WON";
        else resultText.text = "PLAYER 2 WON";
        Show();
    }

    private void GridMatrix_OnGameEnd(object sender, int resultKey)
    {
        SetResultText(resultKey);
    }
}
