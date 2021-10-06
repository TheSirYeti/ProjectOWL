using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : Collectible
{
    public int _value;

    public override void OnCollect()
    {
        EventManager.Trigger("UpdateScore", _value);
    }
}
