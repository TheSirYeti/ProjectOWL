using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Action artificialUpdate;
    [SerializeField] float minimumSwipeTriggerValue;
    [SerializeField] private PlayerMovement movement;

    private Vector2 playerStartAction;
    private Vector2 playerEndAction;
    private bool isGamePaused = false;
    private bool hasTakenAction = false;

    private void Start()
    {
        EventManager.Subscribe("PauseGame", PauseInputs);
        EventManager.Subscribe("ResumeGame", UnpauseInputs);

        SwipeManager.instance.OnEndTouch += CheckInputs;
        SwipeManager.instance.OnUpdateTouch += UpdatePlayerAction;
        SwipeManager.instance.OnStartTouch += StartPlayerAction;
    }

    private void Update()
    {
        //artificialUpdate();
        if (Input.GetKeyDown(KeyCode.D))
        {
            movement.ChangeLane(1);
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            movement.ChangeLane(-1);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            movement.VerticalAction(1);
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            movement.VerticalAction(-1);
        }
    }

    void StartPlayerAction(Vector2 position)
    {
        playerStartAction = position;
    }

    private void UpdatePlayerAction(Vector2 position)
    {
        if (!isGamePaused)
        {
            playerEndAction = position;
            if (Vector3.Distance(playerStartAction, playerEndAction) >= minimumSwipeTriggerValue && !hasTakenAction)
            {
                if (Mathf.Abs(playerEndAction.y - playerStartAction.y) >= minimumSwipeTriggerValue)
                {
                    float differenceY = playerEndAction.y - playerStartAction.y;
                    if (Mathf.Abs(differenceY) >= minimumSwipeTriggerValue)
                        movement.VerticalAction(1 * (int) Mathf.Sign(differenceY));
                }
                else
                {
                    float differenceX = playerEndAction.x - playerStartAction.x;
                    if (Mathf.Abs(differenceX) >= minimumSwipeTriggerValue)
                        movement.ChangeLane(1 * (int) Mathf.Sign(differenceX));
                }
                hasTakenAction = true;
            }
        }
    }
    
    void CheckInputs(Vector2 position)
    {
        hasTakenAction = false;
    }

    public void UnpauseInputs(object[] parameters)
    {
        isGamePaused = false;
        Time.timeScale = 1f;
    }
    
    public void PauseInputs(object[] parameters)
    {
        isGamePaused = true;
        Time.timeScale = 0f;
    }
    
    
    void EndGame()
    {
        EventManager.Trigger("EndGame");
        isGamePaused = true;
        Time.timeScale = 0f;
    }
    
    
}
