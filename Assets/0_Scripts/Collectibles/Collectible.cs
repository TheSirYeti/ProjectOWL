using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public abstract class Collectible : MonoBehaviour, IMovable, ICollectible, ISubscriber
{ 
    [SerializeField] private float  speed;
    [SerializeField] private Observer collectibleObserver;
    private ICollectible collectible;

    private void Start()
    {
        collectibleObserver.Subscribe(this);
        collectible = this;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            collectibleObserver.NotifySubscribers(null);
        }
    }

    private void FixedUpdate()
    {
        StartMoving();
    }

    public void StartMoving()
    {
        transform.position -= transform.forward * Time.deltaTime * speed;
    }
    
    public void OnNotify(string eventID)
    {
        collectible.OnCollect();
    }
    
    public abstract void OnCollect();
}
