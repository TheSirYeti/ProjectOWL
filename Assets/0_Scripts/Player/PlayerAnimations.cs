using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour, ISubscriber
{
    [SerializeField] private Animator _animator;
    
    public PlayerObserver _playerObserver;

    private void Awake()
    {
        _playerObserver.Subscribe(this);
    }

    public void PlayAnimation(string animationID)
    {
        _animator.Play(animationID);
    }

    public void OnNotify(string eventID)
    {
        PlayAnimation(eventID);
    }
}
