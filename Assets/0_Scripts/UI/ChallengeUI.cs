using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
public class ChallengeUI : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI scoreText = null;
    [SerializeField] private TextMeshProUGUI distanceText = null;


    [SerializeField] private Image scoreCheckImage = null, scoreCrossImage = null;
    [SerializeField] private Image distanceCheckImage = null, distanceCrossImage = null;

    private void Awake()
    {
        EventManager.Subscribe("OnChallengeGenerated", SetPauseChallengeText);
        EventManager.Subscribe("OnScoreChange", EnableScorePauseCheck);
        EventManager.Subscribe("OnDistanceChange", EnableDistancePauseCheck);
    }

    public void SetPauseChallengeText(object[] parameters)
    {
        scoreText.text = (string)parameters[0] ;

        distanceText.text = (string)parameters[1] ;

        scoreCheckImage.enabled = false;
        distanceCheckImage.enabled = false;

        scoreCrossImage.enabled = true;
        distanceCrossImage.enabled = true;
    }

    void EnableScorePauseCheck(object[] parameters)
    {
        if (PlayerPrefs.GetFloat("ScoreToBeat") <= (int)parameters[0])
        {
            scoreCrossImage.enabled = false;
            scoreCheckImage.enabled = true;
        }
    }

    void EnableDistancePauseCheck(object[] parameters)
    {
        if (PlayerPrefs.GetFloat("DistanceToBeat") <= (int)parameters[0])
        {
            distanceCrossImage.enabled = false;
            distanceCheckImage.enabled = true;
        }
    }
}
