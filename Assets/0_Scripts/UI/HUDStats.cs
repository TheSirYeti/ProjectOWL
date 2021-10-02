using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDStats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private TextMeshProUGUI hpText;

    private void Awake()
    {
        EventManager.Subscribe("UpdateUIDistance", UpdateDistanceText);
        EventManager.Subscribe("UpdateUIScore", UpdateScoreText);
        EventManager.Subscribe("UpdateUIhp", UpdateHpText);
    }

    void UpdateScoreText(object[] parameters)
    {
        scoreText.text = "Score: " + parameters[0];
    }
    
    void UpdateDistanceText(object[] parameters)
    {
        distanceText.text = "Distance: " + parameters[0] +  "m";
    }

    void UpdateHpText(object[] parameters)
    {
        hpText.text = "HP: " + parameters[0];
    }
}
