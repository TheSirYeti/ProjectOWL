using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.AssetImporters;
using UnityEngine;
using UnityEngine.UI;

public class HUDStats : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text distanceText;

    private void Awake()
    {
        EventManager.Subscribe("UpdateDistance", UpdateDistanceText);
        EventManager.Subscribe("UpdateScore", UpdateScoreText);
    }

    void UpdateScoreText(object[] parameters)
    {
        scoreText.text = "SCORE: " + parameters[0];
    }
    
    void UpdateDistanceText(object[] parameters)
    {
        distanceText.text = "DISTANCE: " + parameters[0] +  "m";
    }
}
