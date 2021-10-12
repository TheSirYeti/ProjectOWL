using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public abstract class Collectible : MonoBehaviour, IMovable, ICollectible
{ 
    [SerializeField] float  speed;
    private ICollectible collectible;

    private void Start()
    {
        collectible = this;
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

    public abstract void OnCollect();
}
