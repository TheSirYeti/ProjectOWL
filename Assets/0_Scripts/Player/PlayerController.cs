using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, ISubscriber
{
    private Action artificialUpdate;
    [SerializeField] private MovementCalculator _movementCalculator;
    [SerializeField] private PlayerMovement _playerMovement;

    private void Start()
    {
        _movementCalculator.Subscribe(this);
        
        EventManager.Subscribe("OnPauseGame", PauseInputs);
        EventManager.Subscribe("OnResumeGame", UnpauseInputs);
        EventManager.Subscribe("OnEndGame", EndGame);
    }

    private void Update()
    {
        //Inputs para probar el movimiento con teclado
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            _playerMovement.ChangeLane(1);
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            _playerMovement.ChangeLane(-1);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            _playerMovement.VerticalAction(1);
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            _playerMovement.VerticalAction(-1);
        }
    }

    public void UnpauseInputs(object[] parameters)
    {
        _movementCalculator.isGamePaused = false;
        Time.timeScale = 1f;
    }
    
    public void PauseInputs(object[] parameters)
    {
        _movementCalculator.isGamePaused = true;
        Time.timeScale = 0f;
    }
    
    //via AnimationEvent
    void EndGame(object[] parameters)
    {
        PauseInputs(null);
        _playerMovement.enabled = false;
    }


    public void OnNotify(string eventID)
    {
        if (eventID == "MoveRight")
        {
            _playerMovement.ChangeLane(1);
        }
        else if (eventID == "MoveLeft")
        {
            _playerMovement.ChangeLane(-1);
        }
        else if (eventID == "Jump")
        {
            _playerMovement.VerticalAction(1);
        }
        else if (eventID == "Slide")
        {
            _playerMovement.VerticalAction(-1);
        }
    }
}
