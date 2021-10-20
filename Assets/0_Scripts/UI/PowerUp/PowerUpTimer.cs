using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.Video;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
public abstract class PowerUpTimer : MonoBehaviour
{
    public Image timerImage;
    private bool isActive;
    private float timer;
    private float totalTimerValue;

    public void StartTimer(object[] parameters)
    {
        timerImage.enabled = true;
        timerImage.fillAmount = 1;
        timer = (float) parameters[2];
        totalTimerValue = (float)parameters[2];
        isActive = true;
    }

    private void FixedUpdate()
    {
        if (isActive)
        {
            timer -= Time.fixedDeltaTime;
            timerImage.fillAmount = timer / totalTimerValue;
            if(timer <= 0) OnTimerOver();
        }
    }

    public void ResetTimer()
    {
        timerImage.fillAmount = 1;
        isActive = false;
        timerImage.enabled = false;
    }

    public abstract void OnTimerOver();
}
