using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
public class MovementCalculator : MonoBehaviour, IPublisher, ISubscriber
{

    [SerializeField] float minimumSwipeTriggerValue = 0f;
    private bool _isGamePaused = false;
    
    private List<ISubscriber> _subscribers = null;
    private Vector2 _playerStartAction = Vector2.zero;
    private Vector2 _playerEndAction = Vector2.zero;
    private bool _hasTakenAction = false;


    private void Awake()
    {
        _subscribers = new List<ISubscriber>();
    }

    void Start()
    {
        Subscribe(this);
        SwipeManager.instance.OnEndTouch += CheckInputs;
        SwipeManager.instance.OnUpdateTouch += CalculatePlayerAction;
        SwipeManager.instance.OnStartTouch += StartPlayerAction;
    }

    void StartPlayerAction(Vector2 position)
    {
        _playerStartAction = position;
    }
    
    void CalculatePlayerAction(Vector2 position)
    {
        if (!_isGamePaused)
        {
            _playerEndAction = position;
            if (Vector3.Distance(_playerStartAction, _playerEndAction) >= minimumSwipeTriggerValue && !_hasTakenAction)
            {
                if (Mathf.Abs(_playerEndAction.y - _playerStartAction.y) >= minimumSwipeTriggerValue)
                {
                    float differenceY = _playerEndAction.y - _playerStartAction.y;
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
                    float differenceX = _playerEndAction.x - _playerStartAction.x;
                    if (Mathf.Abs(differenceX) >= minimumSwipeTriggerValue)
                    {
                        if (Mathf.Sign(differenceX) > 0)
                        {
                            NotifySubscribers("MoveRight");
                        }
                        else NotifySubscribers("MoveLeft");
                    }
                }
                _hasTakenAction = true;
            }
        }
    }
    
    void CheckInputs(Vector2 position)
    {
        _hasTakenAction = false;
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

    public void OnNotify(string eventID)
    {
        if (eventID == "Resume")
        {
            _isGamePaused = false;
        }
        else if (eventID == "Pause")
        {
            _isGamePaused = true;
        }
    }
}
