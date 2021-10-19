using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pool<T> 
{
    private List<T> _uninstantiated = new List<T>();
    private Func<T> _create;
    private Func<T, T> _turnOff;
    private Func<T, T> _turnOn;

    public Pool()
    {
    }

    public Pool(Func<T> create, Func<T, T> turnOff, Func<T, T> turnOn, int amount)
    {
        _create = create;
        _turnOff = turnOff;
        _turnOn = turnOn;

        for (var i = 0; i < amount; i++)
        {
            var element = _create();
            _uninstantiated.Add(_turnOff(element));
        }

    }

    public T Get()
    {
        if (_uninstantiated.Count > 0)
        {
            var element = _uninstantiated[0];
            _uninstantiated.RemoveAt(0);
            return _turnOn(element);
        }

        var instance = _create();
        return _turnOn(instance);
    }

    public void Return(T element)
    {
        _uninstantiated.Add(_turnOff(element));
    }
}
