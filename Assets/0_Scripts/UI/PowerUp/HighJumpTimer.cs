using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighJumpTimer : PowerUpTimer
{
    private void Start()
    {
        EventManager.Subscribe("OnHighJumpEnabled", StartTimer);
    }

    public override void OnTimerOver()
    {
        ResetTimer(null);
        EventManager.Trigger("OnHighJumpOver");
    }
}
