using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour, ISubscriber
{
    [SerializeField] private Animator _animator;
    
    public IPublisher _playerMovement;

    private void Awake()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
        _playerMovement.Subscribe(this);
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
