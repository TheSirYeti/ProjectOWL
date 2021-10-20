using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
public class LaneManager: MonoBehaviour
{
    public int currentLane;
    public int amountOfLanes;

    public void AddLanes(int amount)
    {
        amountOfLanes += amount;
    }   

    public bool IsLaneChangeAllowed(int direction)
    {
        if ((direction == 1 && currentLane < amountOfLanes) || (direction == -1 && currentLane > 1))
            return true;
        else return false;
    }

    public void SetCurrentLane(int id)
    {
        currentLane = id;
    }
}
