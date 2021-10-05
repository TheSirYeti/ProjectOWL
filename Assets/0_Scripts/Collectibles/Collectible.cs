using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public abstract class Collectible : MonoBehaviour
{
    public ICollectible collectible;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ExecuteStrategyMethod();
            gameObject.SetActive(false);
        }
    }

    private void ExecuteStrategyMethod()
    {
        collectible.OnCollect();
    }
}
