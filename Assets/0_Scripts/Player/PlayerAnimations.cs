using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
public class PlayerAnimations : MonoBehaviour, ISubscriber
{
    [SerializeField] private Animator _animator = new Animator();
    [SerializeField] private List<string> animatorStatesNames = new List<string>();
    [SerializeField] private Observer _playerObserver = null, _groundStatus = null;
    
    private void Start()
    {
        _playerObserver.Subscribe(this);
        _groundStatus.Subscribe(this);
        
        EventManager.Subscribe("OnPlayerDeath", OnEventReaction);
        EventManager.Subscribe("OnFootballCollected", OnEventReaction);
    }

    public void PlayAnimation(string animationID)
    {
        _animator.Play(animationID);
    }

    public void OnNotify(string eventID)
    {
        if (eventID == "enterGround")
        {
            _animator.SetBool("isGrounded", true);
        }
        else if (eventID == "leftGround")
        {
            _animator.SetBool("isGrounded", false);
        }
        else
        {
            foreach (string s in animatorStatesNames)
            {
                if(s == eventID)
                    PlayAnimation(eventID);
            }
        }
    }
    
    public void OnEventReaction(object[] parameters)
    {
        PlayAnimation((string)parameters[0]);
    }
}
