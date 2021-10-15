using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceManager : MonoBehaviour, IUpdater
{
    private int distance;

    private void Start()
    {
        StartCoroutine(AddSteps());
        EventManager.Subscribe("EndGame", SaveDistance);
    }

    IEnumerator AddSteps()
    {
        while (true)
        {
            distance += 1;
            EventManager.Trigger("OnDistanceChange", distance);
            yield return new WaitForSeconds(0.1f);
        }
    }
    
    void SaveDistance(object[] parameters)
    {
        if(PlayerPrefs.GetFloat("HighDistance") < distance)
            PlayerPrefs.SetFloat("HighDistance", distance);
        UpdateChallenges();
    }
    
    public void UpdateChallenges()
    {
        if (distance > PlayerPrefs.GetFloat("DistanceToBeat"))
        {
            EventManager.Trigger("SetDistancePauseCheck");
        }
    }
}
