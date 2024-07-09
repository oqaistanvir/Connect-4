using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogsManager : MonoBehaviour
{
    public static LogsManager Instance { get; private set; }
    private List<Log> logList;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        logList = new();
        TokenSpawner.Instance.OnTokenSpawned += TokenSpawner_OnTokenSpawned;
        GameInput.Instance.OnTestingKeyPressed += GameInput_OnTestingKeyPressed;
    }

    private void GameInput_OnTestingKeyPressed(object sender, EventArgs e)
    {
        Debug.Log("Logs:");
        PrintLogs();
    }

    private void TokenSpawner_OnTokenSpawned(object sender, TokenSpawner.OnTokenSpawnedEventArgs tokenData)
    {
        AddToLogList(tokenData.token.GetTokenKey(), tokenData.token.GetTokenRow(), tokenData.token.GetTokenColumn());
    }

    public void AddToLogList(int currentPlayer, int row, int col)
    {
        logList.Add(new(currentPlayer, row, col));
    }
    public Log RemoveFromLogList()
    {
        Log log = logList[^1];
        logList.Remove(log);
        return log;
    }
    public Log GetLog(int turnNumber)
    {
        return logList[turnNumber];
    }
    public void PrintLogs()
    {
        foreach (Log log in logList)
        {
            Debug.Log(log.ToString());
        }
    }
}
