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
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
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

    public void SetResultText(int resultKey)
    {
        if (resultKey == 0) resultText.text = "The Game ended in a Draw!";
        else if (resultKey == 1) resultText.text = "Player 1 Won";
        else resultText.text = "Player 2 Won";
        Show();
    }
}
