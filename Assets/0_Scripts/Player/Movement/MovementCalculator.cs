using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
public class MovementCalculator : MonoBehaviour, IPublisher
{

    [SerializeField] float minimumSwipeTriggerValue;
    public bool isGamePaused = false;
    
    private List<ISubscriber> _subscribers = new List<ISubscriber>();
    private Vector2 playerStartAction;
    private Vector2 playerEndAction;
    private bool hasTakenAction = false;
    
    
    void Start()
    {
        SwipeManager.instance.OnEndTouch += CheckInputs;
        SwipeManager.instance.OnUpdateTouch += CalculatePlayerAction;
        SwipeManager.instance.OnStartTouch += StartPlayerAction;
    }

    void StartPlayerAction(Vector2 position)
    {
        playerStartAction = position;
    }
    
    void CalculatePlayerAction(Vector2 position)
    {
        if (!isGamePaused)
        {
            playerEndAction = position;
            if (Vector3.Distance(playerStartAction, playerEndAction) >= minimumSwipeTriggerValue && !hasTakenAction)
            {
                if (Mathf.Abs(playerEndAction.y - playerStartAction.y) >= minimumSwipeTriggerValue)
                {
                    float differenceY = playerEndAction.y - playerStartAction.y;
                    if (Mathf.Abs(differenceY) >= minimumSwipeTriggerValue)
                    {
                        if (Mathf.Sign(differenceY) > 0)
                        {
                            NotifySubscribers("Jump");
                        }
                        else NotifySubscribers("Slide");
                    }
                }
                else
                {
                    float differenceX = playerEndAction.x - playerStartAction.x;
                    if (Mathf.Abs(differenceX) >= minimumSwipeTriggerValue)
                    {
                        if (Mathf.Sign(differenceX) > 0)
                        {
                            NotifySubscribers("MoveRight");
                        }
                        else NotifySubscribers("MoveLeft");
                    }
                }
                hasTakenAction = true;
            }
        }
    }
    
    void CheckInputs(Vector2 position)
    {
        hasTakenAction = false;
    }

    public void Subscribe(ISubscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }

    public void Unsubscribe(ISubscriber subscriber)
    {
        _subscribers.Remove(subscriber);
    }

    public void NotifySubscribers(string action)
    {
        foreach (ISubscriber subscriber in _subscribers)
        {
            subscriber.OnNotify(action);
        }
    }
}
