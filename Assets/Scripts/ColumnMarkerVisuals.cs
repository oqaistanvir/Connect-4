using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnMarkerVisuals : MonoBehaviour
{
    [SerializeField] private Transform[] columnMarkerArray;
    private int selectedColumnMarker = 0;
    private void Start()
    {
        foreach (Transform columnMarker in columnMarkerArray)
        {
            columnMarker.gameObject.SetActive(false);
        }
        columnMarkerArray[selectedColumnMarker].gameObject.SetActive(true);
        TokenSpawner.Instance.OnColumnChanged += TokenSpawner_OnColumnChanged;
    }

    private void TokenSpawner_OnColumnChanged(object sender, TokenSpawner.OnColumnChangedEventArgs e)
    {
        if (GameManager.Instance.IsGamePlaying())
        {
            columnMarkerArray[selectedColumnMarker].gameObject.SetActive(false);
            selectedColumnMarker = e.col;
            columnMarkerArray[selectedColumnMarker].gameObject.SetActive(true);
        }
    }
}
