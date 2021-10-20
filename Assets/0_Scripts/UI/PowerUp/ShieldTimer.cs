using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
public class ShieldTimer : PowerUpTimer
{
    private void Start()
    {
        EventManager.Subscribe("OnShieldCollected", StartTimer);
    }

    public override void OnTimerOver()
    {
        ResetTimer();
        EventManager.Trigger("OnShieldOver", false);
    }
}
