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

    public GameObject test1, test2;
    private void Start()
    {
        SwipeManager.instance.OnEndTouch += CheckInputs;
        SwipeManager.instance.OnUpdateTouch += UpdatePlayerAction;
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
        test1.transform.position = position;
    }

    private void UpdatePlayerAction(Vector2 position)
    {
        playerEndAction = position;
        test2.transform.position = position;
    }
    
    void CheckInputs(Vector2 position)
    {
        if (Vector3.Distance(playerStartAction, playerEndAction) >= minimumSwipeTriggerValue)
        {
            if (Mathf.Abs(playerEndAction.y - playerStartAction.y) >= minimumSwipeTriggerValue)
            {
                float differenceY = playerEndAction.y - playerStartAction.y;
                if(Mathf.Abs(differenceY) >= minimumSwipeTriggerValue)
                    movement.VerticalAction(1 * (int)Mathf.Sign(differenceY));
            }
            else
            {
                float differenceX = playerEndAction.x - playerStartAction.x;
                if(Mathf.Abs(differenceX) >= minimumSwipeTriggerValue)
                    movement.ChangeLane(1 * (int)Mathf.Sign(differenceX));
            }
        }
    }

    public void PauseInputs()
    {
        
    }
}
