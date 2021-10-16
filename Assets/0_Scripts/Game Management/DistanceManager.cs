using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceManager : MonoBehaviour
{
    private int distance;
    private bool running = true;
    
    private void Start()
    {
        StartCoroutine(AddSteps());
        EventManager.Subscribe("OnEndGame", SaveDistance);
        EventManager.Subscribe("OnPlayerDeath", StopCountingDistance);
    }

    IEnumerator AddSteps()
    {
        while (running)
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
    }

    void StopCountingDistance(object[] parameters)
    {
        running = false;
    }
}
