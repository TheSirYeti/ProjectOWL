using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBarLogic : MonoBehaviour
{
    public float timer;
    public Image timerImage;
    public float originalTimer;

    private void Start()
    {
        EventManager.Subscribe("OnStartScan", SetupTimeValues);
        EventManager.Subscribe("OnTargetPressed", StopTimer);
    }

    private void Update()
    {
        if (timer < Time.fixedDeltaTime)
        {
            timerImage.enabled = false;
        }
        else
        {
            timer -= Time.fixedDeltaTime;
            timerImage.fillAmount = timer / originalTimer;
        }
    }

    void SetupTimeValues(object[] parameters)
    {
        timer = Time.fixedDeltaTime + (float) parameters[0];
        originalTimer = timer;
        timerImage.enabled = true;
    }

    void StopTimer(object[] parameters)
    {
        timer = -1;
    }
}
