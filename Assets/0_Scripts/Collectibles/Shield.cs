using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Collectible
{
    public int _value;
    public float duration;
    public override void OnCollect()
    {
        EventManager.Trigger("UpdateScore", _value);
        SoundManager.instance.PlaySound(SoundID.SHIELD);
        EventManager.Trigger("EnableShield", true, duration);
    }
}
