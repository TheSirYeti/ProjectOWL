using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour, ISubscriber
{
    [SerializeField] private Animator _animator;
    [SerializeField] private List<string> animatorStatesNames;
    [SerializeField] private GroundStatus _groundStatus;
    
    public PlayerObserver playerObserver;

    private void Start()
    {
        playerObserver.Subscribe(this);
        _groundStatus.Subscribe(this);
        
        EventManager.Subscribe("OnPlayerDeath", KillAnimations);
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
    
    public void KillAnimations(object[] parameters)
    {
        PlayAnimation((string)parameters[0]);
    }
}
