using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectible : MonoBehaviour
{
    public int value;
    private void OnTriggerEnter(Collider other)
    {
        OnCollect();
    }
    public abstract void OnCollect();
}
