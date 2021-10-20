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
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI distanceText;

    [Header("Images")] 
    [SerializeField] private Image scoreCheckImage, scoreCrossImage;
    [SerializeField] private Image distanceCheckImage, distanceCrossImage;

    private void Awake()
    {
        EventManager.Subscribe("OnChallengeGenerated", SetPauseChallengeText);
        EventManager.Subscribe("OnScoreChange", EnableScorePauseCheck);
        EventManager.Subscribe("OnDistanceChange", EnableDistancePauseCheck);
    }

    public void SetPauseChallengeText(object[] parameters)
    {
        scoreText.text = "SCORE " + parameters[0] + " POINTS: ";

        distanceText.text = "RUN " + parameters[1] + " METERS:";

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
