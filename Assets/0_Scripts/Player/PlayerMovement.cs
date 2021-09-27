﻿using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float moveAmount;
    [SerializeField] private float jumpForce;

    [SerializeField] private LaneManager lanes;

    [SerializeField] private PlayerObserver _playerObserver;

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
        if (direction == 1)
        {
            transform.position += new Vector3(0, 2.4f, 0);
            _playerObserver.NotifySubscribers("Jump");
        }
        else
        {
            _playerObserver.NotifySubscribers("Slide");
        }
    }
}
