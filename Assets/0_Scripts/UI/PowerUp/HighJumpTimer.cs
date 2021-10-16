using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
