using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleObserver : IPublisher
{
    public List<ISubscriber> subscribers = new List<ISubscriber>();
    
    public void Subscribe(ISubscriber subscriber)
    {
        subscribers.Add(subscriber);
    }

    public void Unsubscribe(ISubscriber subscriber)
    {
        subscribers.Remove(subscriber);
    }

    public void NotifySubscribers(string eventID)
    {
        foreach (ISubscriber subscriber in subscribers)
        {
            subscriber.OnNotify(eventID);
        }
    } 
}
