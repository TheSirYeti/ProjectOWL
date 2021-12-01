using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
public class HUDStats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText = null;
    [SerializeField] private TextMeshProUGUI distanceText = null;
    [SerializeField] private TextMeshProUGUI hpText = null;

    private void Awake()
    {
        EventManager.Subscribe("OnDistanceChange", UpdateDistanceText);
        EventManager.Subscribe("OnScoreChange", UpdateScoreText);
        EventManager.Subscribe("OnHPChange", UpdateHpText);
    }

    void UpdateScoreText(object[] parameters)
    {
        scoreText.text = "               : " + parameters[0];
    }
    
    void UpdateDistanceText(object[] parameters)
    {
        distanceText.text = "                   : " + parameters[0] +  "m";
    }

    void UpdateHpText(object[] parameters)
    {
        hpText.text = "HP: " + parameters[0];
    }
}
