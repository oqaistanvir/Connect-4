using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    public static PauseUI Instance { get; private set; }
    private const string GAME_SCENE = "GameScene";
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameInput.Instance.OnPauseKeyPressed += GameInput_OnPauseKeyPressed;
        resumeButton.onClick.AddListener(() =>
        {
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

    private void GameInput_OnPauseKeyPressed(object sender, EventArgs e)
    {
        Show();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
