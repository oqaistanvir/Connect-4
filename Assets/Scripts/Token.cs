using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    public static Transform CreateTokenObject(Transform tokenPrefab, Vector3 position, bool isFirstPlayer)
    {
        Transform tokenTransform = Instantiate(tokenPrefab);
        TokenColorizer tokenColorizer = tokenTransform.GetComponent<TokenColorizer>();
        tokenColorizer.SetPlayerTokenColor(isFirstPlayer);
        tokenTransform.localPosition = position;
        return tokenTransform;
    }
}
