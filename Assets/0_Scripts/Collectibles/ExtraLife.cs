﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : Collectible
{
    public int _value;

    public ExtraLife(int value)
    {
        _value = value;
    }

    public override void OnCollect()
    {
        SoundManager.instance.PlaySound(SoundID.EXTRA_LIFE);
        EventManager.Trigger("SetHP", 1f);
        EventManager.Trigger("UpdateScore", _value);
    }
}
