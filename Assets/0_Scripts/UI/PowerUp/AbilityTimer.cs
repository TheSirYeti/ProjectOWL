using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityTimer : PowerUpTimer
{
    private void Start()
    {
        EventManager.Subscribe("OnAbilityCollected", StartTimer);
    }

    public override void OnTimerOver()
    {
        EventManager.Trigger("OnAbilityEnd");
    }
}
