using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Observer : MonoBehaviour, IPublisher
{
    private List<ISubscriber> _subscribers = new List<ISubscriber>();

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

    public List<ISubscriber> GetSubscribers()
    {
        return _subscribers;
    }
}
