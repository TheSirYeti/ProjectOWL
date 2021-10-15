using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.Video;

public abstract class PowerUpTimer : MonoBehaviour
{
    public Image timerUI;
    private bool isActive;
    private float timer;
    private float totalTimerValue;

    public void StartTimer(object[] parameters)
    {
        timerUI.enabled = true;
        timerUI.fillAmount = 1;
        timer = (float) parameters[2];
        totalTimerValue = (float)parameters[2];
        isActive = true;
    }

    private void Update()
    {
        if (isActive)
        {
            timer -= Time.deltaTime;
            timerUI.fillAmount = timer / totalTimerValue;
            if(timer <= 0) OnTimerOver();
        }
    }

    public void ResetTimer(object[] parameters)
    {
        timerUI.fillAmount = 1;
        isActive = false;
        timerUI.enabled = false;
    }

    public abstract void OnTimerOver();
}
