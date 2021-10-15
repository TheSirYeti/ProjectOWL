using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : IPublisher
{
    [SerializeField] private List<ISubscriber> _subscribers = new List<ISubscriber>();
    
    public void Subscribe(ISubscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }

    public void Unsubscribe(ISubscriber subscriber)
    {
        _subscribers.Remove(subscriber);
    }

    public void NotifySubscribers(string id)
    {
        foreach (ISubscriber subscriber in _subscribers)
        {
            subscriber.OnNotify(id);
        }
    }
}
