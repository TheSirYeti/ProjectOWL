using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IPublisher
{
    [SerializeField] private float speed;
    [SerializeField] private float moveAmount;
    [SerializeField] private float jumpForce;
    
    [SerializeField] private List<ISubscriber> _subscribers = new List<ISubscriber>();
    
    [SerializeField] private LaneManager lanes;
    
    public void ChangeLane(int direction)
    {
        if (lanes.IsLaneChangeAllowed(direction))
        {
            Vector3 target = new Vector3(moveAmount * direction, 0, 0);
            transform.position += target;//Vector3.MoveTowards(transform.position, target, speed * Time.fixedDeltaTime);
            lanes.SetCurrentLane(lanes.currentLane += 1 * direction);
        }
    }

    public void VerticalAction(int direction)
    {
        transform.position += new Vector3(0, 2.4f, 0);
        NotifySubscribers("Jump");
    }
    
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
