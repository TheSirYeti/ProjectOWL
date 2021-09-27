using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Action artificialUpdate;
    [SerializeField] float minimumSwipeTriggerValue;
    [SerializeField] private PlayerMovement movement;

    private Vector2 playerStartAction;
    private Vector2 playerEndAction;
    private void Start()
    {
        SwipeManager.instance.OnEndTouch += CheckInputs;
        SwipeManager.instance.OnStartTouch += StartPlayerAction;
        //artificialUpdate = CheckInputs;
    }

    private void Update()
    {
        //artificialUpdate();
        if (Input.GetKeyDown(KeyCode.D))
        {
            movement.ChangeLane(1);
            Debug.Log("DER");
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            movement.ChangeLane(-1);
            Debug.Log("IZQ");
        }
    }

    void StartPlayerAction(Vector2 position)
    {
        playerStartAction = position;
    }
    
    void CheckInputs(Vector2 position)
    {
        Debug.Log(position);
        if (position.x >= minimumSwipeTriggerValue)
        {
            movement.ChangeLane(-1);
        }
        if (position.x <= (minimumSwipeTriggerValue * -1))
        {
            movement.ChangeLane(1);
        }
    }

    public void PauseInputs()
    {
        
    }
}
