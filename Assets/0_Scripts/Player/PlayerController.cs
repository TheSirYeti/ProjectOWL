using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
public class PlayerController : MonoBehaviour, ISubscriber
{
    private Action _artificialUpdate; 
    [SerializeField] private MovementCalculator _movementCalculator = null;
    [SerializeField] private PlayerMovement _playerMovement = null;

    private void Start()
    {
        _movementCalculator.Subscribe(this);
        
        EventManager.Subscribe("OnPauseGame", PauseInputs);
        EventManager.Subscribe("OnNoMoreLives", PauseInputs);
        EventManager.Subscribe("OnAdFailed", UnpauseInputs);
        EventManager.Subscribe("OnResumeGame", UnpauseInputs);
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
        _movementCalculator.NotifySubscribers("Resume");
        //_movementCalculator.isGamePaused = false;
        Time.timeScale = 1f;
    }
    
    public void PauseInputs(object[] parameters)
    {
        _movementCalculator.NotifySubscribers("Play");
        //_movementCalculator.isGamePaused = true;
        Time.timeScale = 0f;
    }
    
    //via AnimationEvent
    void EndGame()
    {
        PauseInputs(null);
        _playerMovement.enabled = false;
        EventManager.Trigger("OnEndGame");
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
