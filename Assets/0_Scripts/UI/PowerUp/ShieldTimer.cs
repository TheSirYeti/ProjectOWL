using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldTimer : PowerUpTimer
{
    private void Start()
    {
        EventManager.Subscribe("EnableShield", StartTimer);
        EventManager.Subscribe("DisableShield", ResetTimer);
    }

    public override void OnTimerOver()
    {
        EventManager.Trigger("DisableShield", false);
    }
}
