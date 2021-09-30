using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDStats : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text distanceText;
    [SerializeField] private Text hpText;

    private void Awake()
    {
        EventManager.Subscribe("UpdateUIDistance", UpdateDistanceText);
        EventManager.Subscribe("UpdateUIScore", UpdateScoreText);
        EventManager.Subscribe("UpdateUIhp", UpdateHpText);
    }

    void UpdateScoreText(object[] parameters)
    {
        scoreText.text = "SCORE: " + parameters[0];
    }
    
    void UpdateDistanceText(object[] parameters)
    {
        distanceText.text = "DISTANCE: " + parameters[0] +  "m";
    }

    void UpdateHpText(object[] parameters)
    {
        hpText.text = "HP: " + parameters[0];
    }
}
