using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : Collectible
{
    public int _value;

    public override void OnCollect()
    {
        EventManager.Trigger("OnCoinCollected", _value, _value);
        SoundManager.instance.PlaySound(SoundID.COIN);
    }
}
