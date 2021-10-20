using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
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
