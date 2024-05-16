using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenColorizer : MonoBehaviour
{
    [SerializeField] Material[] materialArray;
    [SerializeField] private int tokenKey;
    [SerializeField] private MeshRenderer meshRenderer;

    public void SetPlayerTokenColor(int tokenKey)
    {
        if (tokenKey == 1) meshRenderer.material = materialArray[0];
        else if (tokenKey == 2) meshRenderer.material = materialArray[1];
    }
}
