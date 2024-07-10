using System;
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
        GridMatrix.Instance.OnGameEnd += GridMatrix_OnGameEnd;
    }

    private void GridMatrix_OnGameEnd(object sender, int e)
    {
        hideBoardButton.gameObject.SetActive(true);
    }

    public void HideGameHud()
    {
        foreach (GameObject HudElement in HudElements)
        {
            HudElement.SetActive(false);
        }
    }
}
