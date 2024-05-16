using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenVisual : MonoBehaviour
{
    private const string TOKEN_SPAWN = "TokenSpawn";
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        animator.SetTrigger(TOKEN_SPAWN);
    }
}
