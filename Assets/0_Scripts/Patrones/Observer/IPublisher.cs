using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPublisher
{
    void Subscribe(ISubscriber subscriber);
    void Unsubscribe(ISubscriber subscriber);
}
