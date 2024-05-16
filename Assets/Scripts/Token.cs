using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Token : MonoBehaviour
{
    [SerializeField] TokenColorizer tokenColorizer;
    private int tokenKey;
    private Vector3 position;
    public static Token CreateTokenObject(Transform tokenPrefab, Vector3 position)
    {
        Transform tokenTransform = Instantiate(tokenPrefab);
        tokenTransform.localPosition = position;
        return tokenTransform.GetComponent<Token>();
    }

    public void SetTokenCharacteristics(int tokenKey)
    {
        tokenColorizer.SetPlayerTokenColor(tokenKey);
    }
}
