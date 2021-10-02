﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundStatus : MonoBehaviour, IPublisher
{
    [SerializeField] private List<ISubscriber> _subscribers = new List<ISubscriber>();
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            foreach (ISubscriber sub in _subscribers)
            {
                sub.OnNotify("enterGround");
            }
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            foreach (ISubscriber sub in _subscribers)
            {
                sub.OnNotify("enterGround");
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            foreach (ISubscriber sub in _subscribers)
            {
                sub.OnNotify("leftGround");
            }
        }
    }

    public void Subscribe(ISubscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }

    public void Unsubscribe(ISubscriber subscriber)
    {
        _subscribers.Remove(subscriber);
    }
}