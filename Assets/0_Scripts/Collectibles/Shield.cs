using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Collectible
{
    public int _value;
    public float duration;
    public override void OnCollect()
    {
        SoundManager.instance.PlaySound(SoundID.SHIELD);
        EventManager.Trigger("OnShieldCollected", true, _value, duration);
    }
}
