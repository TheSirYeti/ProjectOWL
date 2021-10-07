using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeUI : MonoBehaviour
{
    [Header("Text")] 
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI scorePauseText;
    [SerializeField] private TextMeshProUGUI distancePauseText;

    [Header("Image")] 
    [SerializeField] private Image scorePauseCheck, scorePauseCross;
    [SerializeField] private Image distancePauseCheck, distancePauseCross;

    private void Awake()
    {
        EventManager.Subscribe("SetPauseChallengeUI", SetPauseChallengeText);
        EventManager.Subscribe("SetScorePauseCheck", EnableScorePauseCheck);
        EventManager.Subscribe("SetDistancePauseCheck", EnableDistancePauseCheck);
        EventManager.Subscribe("SetGameOver", SetGameOver);
    }

    public void SetPauseChallengeText(object[] parameters)
    {
        scorePauseText.text = "SCORE " + parameters[0] + " POINTS: ";

        distancePauseText.text = "RUN " + parameters[1] + " METERS:";

        scorePauseCheck.enabled = false;
        distancePauseCheck.enabled = false;

        scorePauseCross.enabled = true;
        distancePauseCross.enabled = true;
    }

    void EnableScorePauseCheck(object[] parameters)
    {
        scorePauseCross.enabled = false;
        scorePauseCheck.enabled = true;
    }

    void EnableDistancePauseCheck(object[] parameters)
    {
        distancePauseCross.enabled = false;
        distancePauseCheck.enabled = true;
    }

    void SetGameOver(object[] parameters)
    {
        title.text = "GAME OVER!";
    }
}
