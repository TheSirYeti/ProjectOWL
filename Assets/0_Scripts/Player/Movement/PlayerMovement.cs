using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
public class PlayerMovement : MonoBehaviour, ISubscriber
{
    [SerializeField] private float moveAmount = 0f;
    [SerializeField] private float jumpForce = 0f;
    private float _originalJumpForce = 0f;
    [SerializeField] private Rigidbody rb = null;

    [SerializeField] private LaneManager lanes = null;
    [SerializeField] private bool isGrounded = false;

    private bool _canPlay = true;
    
    [SerializeField] private Observer _playerObserver = null, _groundStatus = null;

    private void Awake()
    {
        _groundStatus.Subscribe(this);
        _playerObserver.Subscribe(this);

        EventManager.Subscribe("OnHighJumpCollected", ChangeJumpValue);
        EventManager.Subscribe("OnHighJumpOver", ResetJumpValue);
        EventManager.Subscribe("OnPlayerDeath", KillPlayer);
    }

    private void Start()
    {
        _originalJumpForce = jumpForce;
    }

    public void ChangeLane(int direction)
    {
        if (lanes.IsLaneChangeAllowed(direction) && _canPlay)
        {
            Vector3 target = new Vector3(moveAmount * direction, 0, 0);
            transform.position += target;
            lanes.SetCurrentLane(lanes.currentLane += 1 * direction);
            SoundManager.instance.PlaySound(SoundID.CHANGE_LANE);
        }
    }

    public void VerticalAction(int direction)
    {
        if (direction == 1 && isGrounded && _canPlay)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            SoundManager.instance.PlaySound(SoundID.JUMP);
            _playerObserver.NotifySubscribers("Jump");
        }
        else if(direction == -1 && isGrounded && _canPlay)
        {
            _playerObserver.NotifySubscribers("Slide");
            //ability.OnSlideDown();
        }
    }

    public void OnNotify(string eventID)
    {
        if (eventID == "enterGround")
        {
            isGrounded = true;
        }
        
        if (eventID == "leftGround")
        {
            isGrounded = false;
        }
    }

    void ChangeJumpValue(object[] parameters)
    {
        jumpForce = (float)parameters[0];
        _playerObserver.NotifySubscribers("HighJumpVFX");
    }

    void ResetJumpValue(object[] parameters)
    {
        jumpForce = _originalJumpForce;
        _playerObserver.NotifySubscribers("ResetVFX");
    }

    void KillPlayer(object[] parameters)
    {
        _canPlay = false;
        _playerObserver.NotifySubscribers("Die");
    }
}
