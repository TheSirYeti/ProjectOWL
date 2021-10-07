using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceManager : MonoBehaviour
{
    private int distance;
    private bool enableCount = true;

    private void Start()
    {
        StartCoroutine(AddSteps());
        EventManager.Subscribe("EndGame", SaveDistance);
    }

    IEnumerator AddSteps()
    {
        while (true)
        {
            if (enableCount)
            {
                distance += 1;
                EventManager.Trigger("UpdateUIDistance", distance);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
    
    void SaveDistance(object[] parameters)
    {
        if(PlayerPrefs.GetFloat("HighDistance") < distance)
            PlayerPrefs.SetFloat("HighDistance", distance);
    }
    
    public void UpdatePauseChallenges()
    {
        if (distance > PlayerPrefs.GetFloat("DistanceToBeat"))
        {
            EventManager.Trigger("SetDistancePauseCheck");
        }
    }
}
