using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI resultText;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
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
