using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, ISubscriber
{
    [SerializeField] private float moveAmount;
    [SerializeField] private float jumpForce;
    private float originalJumpForce;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private LaneManager lanes;
    [SerializeField] private bool isGrounded;
    
    
    [SerializeField] private PlayerObserver _playerObserver;
    [SerializeField] private GroundStatus _groundStatus;

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
        originalJumpForce = jumpForce;
    }

    public void ChangeLane(int direction)
    {
        if (lanes.IsLaneChangeAllowed(direction))
        {
            Vector3 target = new Vector3(moveAmount * direction, 0, 0);
            transform.position += target;
            lanes.SetCurrentLane(lanes.currentLane += 1 * direction);
            SoundManager.instance.PlaySound(SoundID.CHANGE_LANE);
        }
    }

    public void VerticalAction(int direction)
    {
        if (direction == 1 && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _playerObserver.NotifySubscribers("Jump");
            SoundManager.instance.PlaySound(SoundID.JUMP);
        }
        else if(direction == -1 && isGrounded)
        {
            _playerObserver.NotifySubscribers("Slide");
            SoundManager.instance.PlaySound(SoundID.SLIDE);
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
        jumpForce = originalJumpForce;
        _playerObserver.NotifySubscribers("ResetVFX");
    }

    void KillPlayer(object[] parameters)
    {
        _playerObserver.NotifySubscribers("Die");
    }
}
