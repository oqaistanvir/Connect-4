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
        TokenSpawner.Instance.OnTokenSpawned += TokenSpawner_OnTokenSpawned;
    }

    private void TokenSpawner_OnTokenSpawned(object sender, TokenSpawner.OnTokenSpawnedEventArgs e)
    {
        if (e.tokenTransform == transform)
        {
            animator.SetTrigger(TOKEN_SPAWN);
            TokenSpawner.Instance.OnTokenSpawned -= TokenSpawner_OnTokenSpawned;
        }
    }
}
