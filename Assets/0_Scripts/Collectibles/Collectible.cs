using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class Collectible : MonoBehaviour, IMovable
{
    public float speed;
    public int value;
    public int strategyID;
    private ICollectible collectible;

    private void Start()
    {
        if (strategyID == 0)
            collectible = new Token(value);
        else if (strategyID == 1)
            collectible = new ExtraLife(value);
    }

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
    
        
    private void FixedUpdate()
    {
        StartMoving();
    }

    public void StartMoving()
    {
        transform.position -= transform.forward * Time.deltaTime * speed;
    }
}
