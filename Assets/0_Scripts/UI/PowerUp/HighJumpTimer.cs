using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighJumpTimer : PowerUpTimer
{
    private void Start()
    {
        EventManager.Subscribe("EnableHighJump", StartTimer);
        EventManager.Subscribe("ResetHighJump", ResetTimer);
    }

    public override void OnTimerOver()
    {
        EventManager.Trigger("ResetHighJump");
    }
}
