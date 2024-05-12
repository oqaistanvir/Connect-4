using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenColorizer : MonoBehaviour
{
    [SerializeField] Material[] materialArray;
    [SerializeField] private bool isFirstPlayer;
    [SerializeField] private MeshRenderer meshRenderer;

    public void SetPlayerTokenColor(bool isFirstPlayer)
    {
        if (isFirstPlayer) meshRenderer.material = materialArray[0];
        else meshRenderer.material = materialArray[1];
    }
}
