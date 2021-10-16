using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
