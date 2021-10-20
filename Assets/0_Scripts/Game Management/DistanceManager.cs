using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
public class DistanceManager : MonoBehaviour, IValueRecorder
{
    private int totalDistance;
    private bool isRunning = true;
    
    private void Start()
    {
        AddValue(null);
        EventManager.Subscribe("OnEndGame", SaveValue);
        EventManager.Subscribe("OnPlayerDeath", StopCountingDistance);
    }

    public void AddValue(object[] parameters)
    {
        StartCoroutine(AddSteps());
    }
    
    IEnumerator AddSteps()
    {
        while (isRunning)
        {
            totalDistance += 1;
            EventManager.Trigger("OnDistanceChange", totalDistance);
            yield return new WaitForSeconds(0.1f);
        }
    }
    
    public void SaveValue(object[] parameters)
    {
        if(PlayerPrefs.GetFloat("HighDistance") < totalDistance)
            PlayerPrefs.SetFloat("HighDistance", totalDistance);
    }

    void StopCountingDistance(object[] parameters)
    {
        isRunning = false;
    }
}
