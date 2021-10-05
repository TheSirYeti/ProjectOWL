using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : ICollectible
{
    private int _value;

    public Token(int value)
    {
        _value = value;
    }
    public void OnCollect()
    {
        EventManager.Trigger("UpdateScore", _value);
    }
}
