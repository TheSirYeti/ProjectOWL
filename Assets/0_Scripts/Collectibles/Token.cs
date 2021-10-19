using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : Collectible
{
    public override void OnCollect()
    {
        EventManager.Trigger("OnCoinCollected", value, value);
        SoundManager.instance.PlaySound(SoundID.COIN);
    }

    public Token(float value, float speed) : base(value, speed)
    {
        this.value = value;
        this.speed = speed;
        collectible = this;
    }
}
