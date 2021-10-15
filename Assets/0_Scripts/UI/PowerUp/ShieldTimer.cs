using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldTimer : PowerUpTimer
{
    private void Start()
    {
        EventManager.Subscribe("OnShieldEnabled", StartTimer);
    }

    public override void OnTimerOver()
    {
        ResetTimer(null);
        EventManager.Trigger("OnShieldEnd", false);
    }
}
