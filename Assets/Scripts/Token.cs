using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Token : MonoBehaviour
{
    [SerializeField] TokenColorizer tokenColorizer;
    [SerializeField] GameObject victoryParticles;
    private int tokenKey;
    private int row;
    private int column;

    private void Awake()
    {
        HideVictoryParticles();
    }
    public static Token CreateTokenObject(Transform tokenPrefab, Vector3 position)
    {
        Transform tokenTransform = Instantiate(tokenPrefab);
        tokenTransform.localPosition = position;
        return tokenTransform.GetComponent<Token>();
    }

    public void SetTokenCharacteristics(int tokenKey, int row, int column)
    {
        this.tokenKey = tokenKey;
        this.row = row;
        this.column = column;
        tokenColorizer.SetPlayerTokenColor(tokenKey);
    }

    public void ShowVictoryParticles()
    {
        victoryParticles.SetActive(true);
    }

    public void HideVictoryParticles()
    {
        victoryParticles.SetActive(false);
    }

    public int GetTokenKey()
    {
        return tokenKey;
    }
    public int GetTokenRow()
    {
        return row;
    }
    public int GetTokenColumn()
    {
        return column;
    }
}
