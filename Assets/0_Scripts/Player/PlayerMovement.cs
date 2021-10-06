using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, ISubscriber
{
    [SerializeField] private float moveAmount;
    [SerializeField] private float jumpForce;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private LaneManager lanes;
    [SerializeField] private bool isGrounded;
    
    
    [SerializeField] private PlayerObserver _playerObserver;
    [SerializeField] private GroundStatus _groundStatus;
    
    private void Awake()
    {
        _groundStatus.Subscribe(this);
    }

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
        if (direction == 1 && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _playerObserver.NotifySubscribers("Jump");
        }
        else if(direction == -1 && isGrounded)
        {
            _playerObserver.NotifySubscribers("Slide");
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
}
