using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
public class HighJumpTimer : PowerUpTimer
{
    private void Start()
    {
        
        EventManager.Subscribe("OnHighJumpCollected", StartTimer);
    }

    public override void OnTimerOver()
    {
        ResetTimer();
        EventManager.Trigger("OnHighJumpOver");
    }
}
