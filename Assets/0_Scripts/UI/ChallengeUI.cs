using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeUI : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI scorePauseText;
    [SerializeField] private TextMeshProUGUI distancePauseText;
    [SerializeField] private TextMeshProUGUI scoreGameOverText;
    [SerializeField] private TextMeshProUGUI distanceGameOverText;

    [Header("Image")] 
    [SerializeField] private Image scorePauseCheck, scorePauseCross;
    [SerializeField] private Image distancePauseCheck, distancePauseCross;
    [SerializeField] private Image scoreGameOverCheck, scoreGameOverCross;
    [SerializeField] private Image distanceGameOverCheck, distanceGameOverCross;

    private void Awake()
    {
        EventManager.Subscribe("SetPauseChallengeUI", SetPauseChallengeText);
        EventManager.Subscribe("SetGameOverChallengeUI", SetGameOverChallengeText);
        EventManager.Subscribe("SetScorePauseCheck", EnableScorePauseCheck);
        EventManager.Subscribe("SetDistancePauseCheck", EnableDistancePauseCheck);
        EventManager.Subscribe("SetGameOverChecks", SetGameOverChecks);
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
    
    public void SetGameOverChallengeText(object[] parameters)
    {
        scoreGameOverText.text = "SCORE " + parameters[0] + " POINTS: ";
        
        distanceGameOverText.text = "RUN " + parameters[1] + " METERS:";
        
        scoreGameOverCheck.enabled = false;
        distanceGameOverCheck.enabled = false;
        
        scoreGameOverCross.enabled = true;
        distanceGameOverCross.enabled = true;
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

    void SetGameOverChecks(object[] parameters)
    {
        if ((bool) parameters[0] == true)
        {
            scoreGameOverCross.enabled = false;
            scoreGameOverCheck.enabled = true;
        }
        
        if ((bool) parameters[1] == true)
        {
            distanceGameOverCross.enabled = false;
            distanceGameOverCheck.enabled = true;
        }
    }
}
